using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class PhieuNhapDAO
    {
        // lay danh sach phieu nhap
        public List<PhieuNhapDTO> GetAll()
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();
            string query =
                         "SELECT pn.MaPhieuNhap, pn.ThoiGian, pn.TrangThai,pn.MaNCC, " +
                         "ncc.TENNCC " +
                         "FROM phieu_nhap pn " +
                         "JOIN nha_cung_cap ncc ON pn.MaNCC = ncc.MANCC";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                PhieuNhapDTO pn = new PhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    ThoiGian = Convert.ToDateTime(row["ThoiGian"]),
                    TenNCC = row["TENNCC"].ToString(),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    TrangThai = row["TrangThai"].ToString()
                };
                list.Add(pn);
            }
            return list;
        }
        // them phieu nhap
        public int Insert(PhieuNhapDTO pn)
        {
            // Cần đảm bảo cột TrangThai đã được thêm vào bảng phieu_nhap
            string query = "INSERT INTO phieu_nhap (ThoiGian, MaNV, MaNCC, TrangThai) VALUES (@ThoiGian, @MaNV, @MaNCC, @TrangThai); SELECT LAST_INSERT_ID();";

            var param = new Dictionary<string, object>
            {
                { "@ThoiGian", pn.ThoiGian },
                { "@MaNV", pn.MaNV },
                { "@MaNCC", pn.MaNCC },
                { "@TrangThai", pn.TrangThai }
            };

            // ExecuteScalar để lấy ID mới chèn
            object result = DataProvider.ExecuteScalar(query, param);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            return -1;
        }

        // sua phieu nhap
        public bool Update(PhieuNhapDTO pn)
        {
            string query = "UPDATE phieu_nhap SET ThoiGian=@ThoiGian, MaNV=@MaNV, MaNCC=@MaNCC, TrangThai=@TrangThai WHERE MaPhieuNhap=@MaPhieuNhap";
            var param = new Dictionary<string, object>
            {
                { "@ThoiGian", pn.ThoiGian },
                { "@MaNV", pn.MaNV },
                { "@MaNCC", pn.MaNCC },
                { "@TrangThai", pn.TrangThai }, // Đã thêm TrangThai
                {"@MaPhieuNhap", pn.MaPhieuNhap }
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // --- HÀM MỚI QUAN TRỌNG NHẤT: XỬ LÝ GIAO DỊCH SỬA ---
        public bool UpdatePhieuNhapTransaction(PhieuNhapDTO pnMoi)
        {
            // List chứa Tuple: Item1=Query SQL, Item2=Dictionary Tham số
            List<Tuple<string, Dictionary<string, object>>> transactionCommands =
                new List<Tuple<string, Dictionary<string, object>>>();

            // A. Lệnh 1: UPDATE Phiếu Nhập Chính
            string updatePnQuery = @"UPDATE phieu_nhap 
                                     SET ThoiGian=@ThoiGian, MaNCC=@MaNCC, MaNV=@MaNV, TrangThai=@TrangThai
                                     WHERE MaPhieuNhap=@MaPhieuNhap";
            var updatePnParams = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", pnMoi.MaPhieuNhap },
                { "@ThoiGian", pnMoi.ThoiGian },
                { "@MaNCC", pnMoi.MaNCC },
                { "@MaNV", pnMoi.MaNV },
                { "@TrangThai", pnMoi.TrangThai }
            };
            transactionCommands.Add(new Tuple<string, Dictionary<string, object>>(updatePnQuery, updatePnParams));

            // B. Lệnh 2: DELETE tất cả Chi tiết cũ
            string deleteCtQuery = "DELETE FROM ctphieu_nhap WHERE MaPhieuNhap = @MaPhieuNhap";
            var deleteCtParams = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", pnMoi.MaPhieuNhap }
            };
            transactionCommands.Add(new Tuple<string, Dictionary<string, object>>(deleteCtQuery, deleteCtParams));

            // C. Lệnh 3+: INSERT từng Chi tiết mới
            string insertCtQuery = "INSERT INTO ctphieu_nhap (MaPhieuNhap, MaDauSach, SoLuong, DonGia) VALUES (@MaPhieuNhap, @MaDauSach, @SoLuong, @DonGia)";

            foreach (CTPhieuNhapDTO ctMoi in pnMoi.ct)
            {
                var insertCtParams = new Dictionary<string, object>
                {
                    { "@MaPhieuNhap", pnMoi.MaPhieuNhap },
                    { "@MaDauSach", ctMoi.MaDauSach },
                    { "@SoLuong", ctMoi.SoLuong },
                    { "@DonGia", ctMoi.DonGia }
                };
                transactionCommands.Add(new Tuple<string, Dictionary<string, object>>(insertCtQuery, insertCtParams));
            }

            // Gửi tất cả các lệnh SQL đến DataProvider để thực thi trong một Transaction duy nhất
            // Hàm này sẽ được gọi từ PhieuNhapBUS.UpdateFullPhieuNhap
            return DataProvider.ExecuteTransaction(transactionCommands);
        }
        // xoa phieu nhap
        public bool Delete(int maPhieuNhap)
        {
            string query = "DELETE FROM phieu_nhap WHERE MaPhieuNhap = @MaPhieuNhap";
            var param = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", maPhieuNhap}
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
        public PhieuNhapDTO GetById(int maPhieuNhap)
        {
            string query =
                        "SELECT pn.MaPhieuNhap, pn.ThoiGian, pn.MaNV, pn.MaNCC, pn.TrangThai, " +
                        "nv.TENNV, ncc.TENNCC " +
                        "FROM phieu_nhap pn " +
                        "JOIN nhan_vien nv ON pn.MaNV = nv.MANV " +
                        "JOIN nha_cung_cap ncc ON pn.MaNCC = ncc.MANCC " +
                        "WHERE pn.MaPhieuNhap = @MaPhieuNhap";
            var param = new Dictionary<string, object> { { "@MaPhieuNhap", maPhieuNhap } };

            DataTable dt = DataProvider.ExecuteQuery(query, param);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            PhieuNhapDTO phieu = new PhieuNhapDTO
            {
                MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                ThoiGian = Convert.ToDateTime(row["ThoiGian"]),
                MaNV = Convert.ToInt32(row["MaNV"]),
                MaNCC = Convert.ToInt32(row["MaNCC"]),
                TenNCC = row["TENNCC"].ToString(),
                TrangThai = row["TrangThai"].ToString()
            };
            CTPhieuNhapDAO ctDAO = new CTPhieuNhapDAO();
            phieu.ct = ctDAO.GetByPhieuNhap(phieu.MaPhieuNhap);

            return phieu;
        }
        public List<PhieuNhapDTO> Search(string keyword)
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();

            string query =
                "SELECT pn.MaPhieuNhap, pn.ThoiGian, pn.MaNV, pn.MaNCC, " +
                "nv.TENNV, ncc.TENNCC " +
                "FROM phieu_nhap pn " +
                "JOIN nhan_vien nv ON pn.MaNV = nv.MANV " +
                "JOIN nha_cung_cap ncc ON pn.MaNCC = ncc.MANCC " +
                "WHERE pn.MaPhieuNhap LIKE @kw " +
                "OR nv.TENNV LIKE @kw " +
                "OR ncc.TENNCC LIKE @kw";       

                var param = new Dictionary<string, object>
                {
                    { "@kw", "%" + keyword + "%" }
                };

            DataTable dt = DataProvider.ExecuteQuery(query, param);
            foreach (DataRow row in dt.Rows)
            {
                PhieuNhapDTO pn = new PhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    ThoiGian = Convert.ToDateTime(row["ThoiGian"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    TenNCC = row["TENNCC"].ToString()
                };
                list.Add(pn);
            }

            return list;
        }

    }
}
