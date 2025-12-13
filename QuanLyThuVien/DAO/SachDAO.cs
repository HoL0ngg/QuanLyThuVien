using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class SachDAO
    {
        // Singleton để dùng ở BUS
        private static SachDAO _instance;
        public static SachDAO Instance => _instance ?? (_instance = new SachDAO());
        private SachDAO() { }

        public List<SachDTO> GetAll()
        {
            var list = new List<SachDTO>();
            string query = "SELECT MaSach, TrangThai, MaDauSach FROM sach";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SachDTO
                {
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]) 
                });
            }
            return list;
        }

        public List<SachDTO> Search(int? maSach = null, int? trangThai = null, int? maDauSach = null)
        {
            string sql = "SELECT MaSach, TrangThai, MaDauSach FROM sach WHERE 1=1";
            var param = new Dictionary<string, object>();
            if (maSach.HasValue)
            {
                sql += " AND MaSach = @MaSach";
                param.Add("@MaSach", maSach.Value);
            }
            if (trangThai.HasValue)
            {
                sql += " AND TrangThai = @TrangThai";
                param.Add("@TrangThai", trangThai.Value);
            }
            if (maDauSach.HasValue)
            {
                sql += " AND MaDauSach = @MaDauSach";
                param.Add("@MaDauSach", maDauSach.Value);
            }
            DataTable dt = DataProvider.ExecuteQuery(sql, param);
            var list = new List<SachDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SachDTO
                {
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]) 
                });
            }
            return list;
        }

        public List<SachDTO> SearchSachNotBorrow(string tendausach)
        {
            string sql = @"SELECT s.MaSach, s.TrangThai, s.MaDauSach,
                                   ds.TenDauSach, ds.NgonNgu, ds.NamXuatBan, ds.SoLuong,
                                   nxb.TenNXB as 'NhaXuatBan'
                            FROM sach s
                            JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                            JOIN nha_xuat_ban nxb ON ds.NhaXuatBan = nxb.MaNXB
                            WHERE s.TrangThai = 1 AND ds.TenDauSach LIKE @TenDauSach";
            var param = new Dictionary<string, object>
            {
                {"@TenDauSach", "%" + (tendausach ?? string.Empty).Trim() + "%"}
            };
            DataTable dt = DataProvider.ExecuteQuery(sql, param);
            var list = new List<SachDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SachDTO
                {
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    TenDauSach = Convert.ToString(row["TenDauSach"]),
                    NgonNgu = Convert.ToString(row["NgonNgu"]),
                    NamXuatBan = row["NamXuatBan"] != DBNull.Value ? Convert.ToInt32(row["NamXuatBan"]) : 0,
                    SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0,
                    NhaXuatBan = Convert.ToString(row["NhaXuatBan"]) 
                });
            }
            return list;
        }

        public bool Create(SachDTO sach)
        {
            string query = "INSERT INTO sach (TrangThai, MaDauSach) VALUES (@TrangThai, @MaDauSach)";
            var parameters = new Dictionary<string, object>
            {
                { "@TrangThai", sach.TrangThai },
                { "@MaDauSach", sach.MaDauSach }
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(SachDTO sach)
        {
            string query = "UPDATE sach SET TrangThai = @TrangThai, MaDauSach = @MaDauSach WHERE MaSach = @MaSach";
            var parameters = new Dictionary<string, object>
            {
                { "@TrangThai", sach.TrangThai },
                { "@MaDauSach", sach.MaDauSach },
                { "@MaSach", sach.MaSach }
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int maSach)
        {
            string query = "DELETE FROM sach WHERE MaSach = @MaSach";
            var parameters = new Dictionary<string, object> { { "@MaSach", maSach } };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public SachDTO GetById(int maSach)
        {
            string query = "SELECT MaSach, TrangThai, MaDauSach FROM sach WHERE MaSach = @MaSach";
            var parameters = new Dictionary<string, object> { { "@MaSach", maSach } };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new SachDTO
            {
                MaSach = Convert.ToInt32(row["MaSach"]),
                TrangThai = Convert.ToInt32(row["TrangThai"]),
                MaDauSach = Convert.ToInt32(row["MaDauSach"]) 
            };
        }

        public List<SachDTO> GetAllWithDauSach()
        {
            string query = @"SELECT s.MaSach, s.TrangThai, s.MaDauSach,
                                     ds.TenDauSach, ds.NgonNgu, ds.NamXuatBan, ds.SoLuong,
                                     nxb.TenNXB
                              FROM sach s
                              INNER JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                              LEFT JOIN nha_xuat_ban nxb ON ds.MaNXB = nxb.MaNXB";
            DataTable dt = DataProvider.ExecuteQuery(query);
            var list = new List<SachDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SachDTO
                {
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    TenDauSach = Convert.ToString(row["TenDauSach"]),
                    NgonNgu = Convert.ToString(row["NgonNgu"]),
                    NamXuatBan = row["NamXuatBan"] != DBNull.Value ? Convert.ToInt32(row["NamXuatBan"]) : 0,
                    SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0,
                    NhaXuatBan = Convert.ToString(row["TenNXB"]) 
                });
            }
            return list;
        }

        public SachDTO GetByIdWithDauSach(int maSach)
        {
            string query = @"SELECT s.MaSach, s.TrangThai, s.MaDauSach,
                                     ds.TenDauSach, ds.NgonNgu, ds.NamXuatBan, ds.SoLuong,
                                     nxb.TenNXB
                              FROM sach s
                              INNER JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                              LEFT JOIN nha_xuat_ban nxb ON ds.MaNXB = nxb.MaNXB
                              WHERE s.MaSach = @MaSach";
            var parameters = new Dictionary<string, object> { { "@MaSach", maSach } };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new SachDTO
            {
                MaSach = Convert.ToInt32(row["MaSach"]),
                TrangThai = Convert.ToInt32(row["TrangThai"]),
                MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                TenDauSach = Convert.ToString(row["TenDauSach"]),
                NgonNgu = Convert.ToString(row["NgonNgu"]),
                NamXuatBan = row["NamXuatBan"] != DBNull.Value ? Convert.ToInt32(row["NamXuatBan"]) : 0,
                SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0,
                NhaXuatBan = Convert.ToString(row["TenNXB"]) 
            };
        }

        public List<SachDTO> GetByMaDauSachWithDauSach(int maDauSach)
        {
            string query = @"SELECT s.MaSach, s.TrangThai, s.MaDauSach,
                                     ds.TenDauSach, ds.NgonNgu, ds.NamXuatBan, ds.SoLuong,
                                     nxb.TenNXB
                              FROM sach s
                              INNER JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                              LEFT JOIN nha_xuat_ban nxb ON ds.MaNXB = nxb.MaNXB
                              WHERE s.MaDauSach = @MaDauSach";
            var parameters = new Dictionary<string, object> { { "@MaDauSach", maDauSach } };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            var list = new List<SachDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SachDTO
                {
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    TenDauSach = Convert.ToString(row["TenDauSach"]),
                    NgonNgu = Convert.ToString(row["NgonNgu"]),
                    NamXuatBan = row["NamXuatBan"] != DBNull.Value ? Convert.ToInt32(row["NamXuatBan"]) : 0,
                    SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0,
                    NhaXuatBan = Convert.ToString(row["TenNXB"]) 
                });
            }
            return list;
        }

        public int GetLatestId()
        {
            string query = "SELECT MAX(MaSach) AS LatestId FROM sach";
            DataTable dt = DataProvider.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0]["LatestId"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["LatestId"]);
            }
            return 0;
        }
    }
}
