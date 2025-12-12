using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace QuanLyThuVien.DAO
{
    public class PhieuTraDAO
    {
        private static PhieuTraDAO instance;

        public static PhieuTraDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuTraDAO();
                return instance;
            }
        }


        public List<PhieuTraDTO> GetAll()
        {
            List<PhieuTraDTO> list = new List<PhieuTraDTO>();
            string query = @"
        SELECT 
            pt.MaPhieuTra,
            pt.NgayTra,
            pt.MaPhieuMuon,
            nv.TENNV,
            dg.TENDG,
            dg.MADG,
            pm.NgayMuon,
            pm.NgayTraDuKien
        FROM phieu_tra pt
        LEFT JOIN nhan_vien nv ON pt.MaNV = nv.MANV
        LEFT JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
        LEFT JOIN doc_gia dg ON pm.MaDocGia = dg.MADG
        ORDER BY pt.MaPhieuTra DESC";

            DataTable dt = DataProvider.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                PhieuTraDTO pt = new PhieuTraDTO
                {
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    NgayTra = Convert.ToDateTime(row["NgayTra"]),
                    MaPhieuMuon = row["MaPhieuMuon"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaPhieuMuon"]),
                    TENDG = row["TENDG"].ToString(),
                    TENNV = row["TENNV"].ToString(),
                    NgayMuon = Convert.ToDateTime(row["NgayMuon"]),
                    NgayTraDuKien = Convert.ToDateTime(row["NgayTraDuKien"]),
                    MADG = Convert.ToInt32(row["MADG"])
                };
                list.Add(pt);
            }
            return list;
        }

        public List<CTPhieuTraDTO> GetCTPhieuTraById(int maPhieuTra)
        {
            List<CTPhieuTraDTO> list = new List<CTPhieuTraDTO>();
            string query = @"
        SELECT 
            CTPT.MaCTPhieuTra,
            CTPT.MaPhieuTra,
            CTPT.MaSach,
            CTPT.TrangThai,
            DS.TenDauSach AS TenSach,
            MIN(TG.TenTacGia) AS TenTacGia 
        FROM 
            ctphieu_tra AS CTPT
        JOIN 
            sach AS S ON CTPT.MaSach = S.MaSach
        JOIN 
            dau_sach AS DS ON S.MaDauSach = DS.MaDauSach
        LEFT JOIN
            tacgia_dausach AS TGDS ON DS.MaDauSach = TGDS.MaDauSach
        LEFT JOIN
            tac_gia AS TG ON TGDS.MaTacGia = TG.MaTacGia
        WHERE 
            CTPT.MaPhieuTra = @MaPhieuTra
        GROUP BY
            CTPT.MaCTPhieuTra, CTPT.MaPhieuTra, CTPT.MaSach, DS.TenDauSach
        ORDER BY
            CTPT.MaSach";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuTra", maPhieuTra }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                CTPhieuTraDTO ct = new CTPhieuTraDTO
                {
                    MaCTPhieuTra = Convert.ToInt32(row["MaCTPhieuTra"]),
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    TenSach = row["TenSach"].ToString(),
                    TenTacGia = row["TenTacGia"] == DBNull.Value ? "Chưa rõ" : row["TenTacGia"].ToString(),
                    TrangThai = Convert.ToInt32(row["TrangThai"])
                };
                list.Add(ct);
            }
            return list;
        }

        public int InsertPhieuTra(PhieuTraDTO pt)
        {
            // Cần phải có MaDG, MaNV, và MaPhieuMuon trong DTO
            string query = @"
        INSERT INTO phieu_tra (NgayTra, MaNV, MaPhieuMuon)
        VALUES (@NgayTra, @MaNV, @MaPhieuMuon);
        SELECT LAST_INSERT_ID();";

            // Danh sách tham số
            var parameters = new Dictionary<string, object>
            {
                {"@NgayTra",pt.NgayTra},
                {"@MaNV",pt.MaNV},
                {"@MaPhieuMuon",pt.MaPhieuMuon},
            };

            try
            {
                // ExecuteScalar thực thi câu lệnh và trả về giá trị đầu tiên (LAST_INSERT_ID)
                object result = DataProvider.ExecuteScalar(query, parameters);
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                return -1; // Trả về -1 nếu không thể lấy được ID
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Debug.WriteLine("Lỗi khi thêm Phiếu Trả: " + ex.Message);
                return -1;
            }
        }

        public bool InsertCTPhieuTra(CTPhieuTraDTO ct)
        {
            string query = @"
        INSERT INTO ctphieu_tra (TrangThai, MaPhieuTra, MaSach)
        VALUES (@TrangThai, @MaPhieuTra, @MaSach)";

            var parameters = new Dictionary<string, object>
            {
                
                {"@MaPhieuTra", ct.MaPhieuTra},
                {"@MaSach", ct.MaSach },
                {"@TrangThai", ct.TrangThai }
            };

            try
            {
                // ExecuteNonQuery trả về số dòng bị ảnh hưởng
                int rowsAffected = DataProvider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Debug.WriteLine("Lỗi khi thêm Chi tiết Phiếu Trả: " + ex.Message);
                return false;
            }
        }

        public void UpdateTrangThaiPhieuMuon(int maPhieuMuon, int trangthai)
        {
            string query = "UPDATE phieu_muon SET trangthai = @TrangThai WHERE MaPhieuMuon = @MaPhieuMuon";
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuMuon", maPhieuMuon },
                { "@TrangThai", trangthai}
            };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(int maPhieuTra)
        {
            string query = "DELETE FROM phieu_tra WHERE MaPhieuTra = @MaPhieuTra";
            var parameters = new Dictionary<string, object>
            {
                {"@MaPhieuTra", maPhieuTra}
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
