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
    public class CTPhieuNhapDAO
    {
        // lay ct phieu nhap theo ma phieu nhap
        public List<CTPhieuNhapDTO> GetByPhieuNhap(int maPhieuNhap)
        {
            List<CTPhieuNhapDTO> ls = new List<CTPhieuNhapDTO>();
            string query = @"
                            SELECT ct.MaPhieuNhap, ct.MaDauSach, ct.SoLuong, ct.DonGia, ds.TenDauSach
                            FROM ctphieu_nhap ct
                            JOIN dau_sach ds ON ct.MaDauSach = ds.MaDauSach
                            WHERE ct.MaPhieuNhap = @MaPhieuNhap";
            var param = new Dictionary<string, object> { { "@MaPhieuNhap", maPhieuNhap } };
            DataTable dt = DataProvider.ExecuteQuery(query, param);
            foreach (DataRow row in dt.Rows)
            {
                CTPhieuNhapDTO ct = new CTPhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDouble(row["DonGia"]),
                    TenSach = row["TenDauSach"].ToString()
                };
                ls.Add(ct);
            }
            return ls;
        }
        //lay tat ca ct phieu nhap
        public List<CTPhieuNhapDTO> GetAll()
        {
            List<CTPhieuNhapDTO> list = new List<CTPhieuNhapDTO>();
            string query = @"SELECT ct.MaPhieuNhap,ct.MaDauSach,ct.SoLuong,ct.DonGia,ds.TenDauSach
                            FROM ctphieu_nhap ct 
                            JOIN dau_sach ds ON ct.MaDauSach = ds.MaDauSach";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                CTPhieuNhapDTO pn = new CTPhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDouble(row["DonGia"]),
                    TenSach = row["TenDauSach"].ToString()
                };
                list.Add(pn);
            }
            return list;
        }
        //them ct phieu nhap
        public bool Insert(CTPhieuNhapDTO ct)
        {
            string query = "INSERT INTO ctphieu_nhap (MaPhieuNhap, MaDauSach, SoLuong, DonGia) VALUES (@MaPhieuNhap, @MaDauSach, @SoLuong, @DonGia)";
            var param = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", ct.MaPhieuNhap },
                { "@MaDauSach", ct.MaDauSach },
                { "@SoLuong", ct.SoLuong },
                { "@DonGia", ct.DonGia }
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
        // xoa ct phieu nhap theo ma phieu nhap
        public bool DeletePhieuNhap(int maPhieuNhap,int maDauSach)
        {
            string query = "DELETE FROM ctphieu_nhap WHERE MaPhieuNhap=@MaPhieuNhap AND MaDauSach=@MaDauSach";
            var param = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", maPhieuNhap},
                { "@MaDauSach", maDauSach}
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
        // xoa chi thiet phieu nhap theo ma phieu nhap
        public bool DeleteAllDetailsByMaPhieuNhap(int maPhieuNhap)
        {
            string query = "DELETE FROM ctphieu_nhap WHERE MaPhieuNhap = @MaPhieuNhap";

            var param = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", maPhieuNhap }
            };
            int rowsAffected = DataProvider.ExecuteNonQuery(query, param);

            return rowsAffected >= 0;
        }
        // sua ct phieu
        public bool Update(CTPhieuNhapDTO ct)
        {
            string query = @"UPDATE ctphieu_nhap SET SoLuong=@SoLuong, DonGia=@DonGia
                             WHERE MaPhieuNhap=@MaPhieuNhap AND MaDauSach = @MaDauSach";
            var param = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", ct.MaPhieuNhap },
                { "@MaDauSach", ct.MaDauSach },
                { "@SoLuong", ct.SoLuong },
                { "@DonGia", ct.DonGia }
            };
            return DataProvider.ExecuteNonQuery(query,param) > 0;
        }
        // lay ct phieu nhap theo ten sach
        // trong CTPhieuNhapDAO
        public List<CTPhieuNhapDTO> Search(int maPhieuNhap, string tensach)
        {
            List<CTPhieuNhapDTO> ls = new List<CTPhieuNhapDTO>();
                string query = @"
                                SELECT ct.MaPhieuNhap, ct.MaDauSach, ct.SoLuong, ct.DonGia, ds.TenDauSach
                                FROM ctphieu_nhap ct
                                JOIN dau_sach ds ON ct.MaDauSach = ds.MaDauSach
                                WHERE ct.MaPhieuNhap = @MaPhieuNhap AND ds.TenDauSach LIKE @TenDauSach";

                var param = new Dictionary<string, object>
                                {
                                    { "@MaPhieuNhap", maPhieuNhap },
                                    { "@TenDauSach", "%" + tensach + "%" }
                                };

            DataTable dt = DataProvider.ExecuteQuery(query, param);
            foreach (DataRow row in dt.Rows)
            {
                CTPhieuNhapDTO ct = new CTPhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDouble(row["DonGia"]),
                    TenSach = row["TenDauSach"].ToString()
                };
                ls.Add(ct);
            }
            return ls;
        }

    }
}
