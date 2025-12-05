using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return instance;
            }
        }

        private NhanVienDAO() { }

        public DataTable GetAllNhanVien()
        {
            string query = @"
                SELECT 
                    MaNV, TenNV, NgaySinh, SDT, Email,
                    CASE
                        WHEN GioiTinh = 1 THEN 'Nam'
                        WHEN GioiTinh = 0 THEN 'Nữ'
                        ELSE 'Khác'
                    END AS GioiTinh,
                    CASE 
                        WHEN TrangThai = 1 THEN 'Đang làm việc'
                        ELSE 'Nghỉ việc'
                    END AS TrangThai
                FROM nhan_vien
                ORDER BY MaNV DESC";

            return DataProvider.ExecuteQuery(query);
        }

        public NhanVienDTO GetNhanVienById(int maNV)
        {
            string query = @"
                SELECT MaNV, TenNV, NgaySinh, GioiTinh,
                       SDT, Email, TenDangNhap, MatKhau, MaNhomQuyen, TrangThai
                FROM nhan_vien
                WHERE MaNV = @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new NhanVienDTO
            {
                MaNV = Convert.ToInt32(row["MaNV"]),
                TenNV = row["TenNV"]?.ToString(),
                NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                GioiTinh = row["GioiTinh"]?.ToString(),
                SDT = row["SDT"]?.ToString(),
                Email = row["Email"]?.ToString(),
                TenDangNhap = row["TenDangNhap"]?.ToString(),
                MatKhau = row["MatKhau"]?.ToString(),
                MaNhomQuyen = row["MaNhomQuyen"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaNhomQuyen"]),
                TrangThai = Convert.ToInt32(row["TrangThai"])
            };
        }

        public bool InsertNhanVien(NhanVienDTO nv)
        {
            string query = @"
                INSERT INTO nhan_vien 
                (TenNV, NgaySinh, GioiTinh, SDT, Email, TenDangNhap, MatKhau, MaNhomQuyen, TrangThai)
                VALUES 
                (@TenNV, @NgaySinh, @GioiTinh, @SDT, @Email, @TenDangNhap, @MatKhau, @MaNhomQuyen, @TrangThai)";

            var parameters = new Dictionary<string, object>
            {
                { "@TenNV", nv.TenNV },
                { "@NgaySinh", nv.NgaySinh },
                { "@GioiTinh", nv.GioiTinh },
                { "@SDT", nv.SDT ?? "" },
                { "@Email", nv.Email ?? "" },
                { "@TenDangNhap", nv.TenDangNhap ?? "" },
                { "@MatKhau", nv.MatKhau ?? "123456" }, // Mật khẩu mặc định
                { "@MaNhomQuyen", nv.MaNhomQuyen ?? (object)DBNull.Value },
                { "@TrangThai", nv.TrangThai }
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateNhanVien(NhanVienDTO nv)
        {
            string query = @"
                UPDATE nhan_vien 
                SET TenNV = @TenNV,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    SDT = @SDT,
                    Email = @Email,
                    TrangThai = @TrangThai
                WHERE MaNV = @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", nv.MaNV },
                { "@TenNV", nv.TenNV },
                { "@NgaySinh", nv.NgaySinh },
                { "@GioiTinh", nv.GioiTinh },
                { "@SDT", nv.SDT ?? "" },
                { "@Email", nv.Email ?? "" },
                { "@TrangThai", nv.TrangThai }
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa nhân viên (soft delete)
        public bool DeleteNhanVien(int maNV)
        {
            string query = "UPDATE nhan_vien SET TrangThai = 0 WHERE MaNV = @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable SearchNhanVien(string keyword)
        {
            string query = @"
                SELECT 
                    MaNV, TenNV, NgaySinh, SDT, Email,
                    CASE
                        WHEN GioiTinh = 1 THEN 'Nam'
                        WHEN GioiTinh = 0 THEN 'Nữ'
                        ELSE 'Khác'
                    END AS GioiTinh,
                    CASE 
                        WHEN TrangThai = 1 THEN 'Đang làm việc'
                        ELSE 'Nghỉ việc'
                    END AS TrangThai
                FROM nhan_vien
                WHERE TenNV LIKE @Keyword 
                   OR SDT LIKE @Keyword 
                   OR Email LIKE @Keyword
                ORDER BY MaNV DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@Keyword", "%" + keyword + "%" }
            };

            return DataProvider.ExecuteQuery(query, parameters);
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(int maNV, string matKhauCu, string matKhauMoi)
        {
            // Kiểm tra mật khẩu cũ
            string checkQuery = "SELECT COUNT(*) FROM nhan_vien WHERE MANV = @MaNV AND MatKhau = @MatKhauCu";
            var checkParams = new Dictionary<string, object>
            {
                { "@MaNV", maNV },
                { "@MatKhauCu", matKhauCu }
            };

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(checkQuery, checkParams));
            if (count == 0)
                return false;

            // Cập nhật mật khẩu mới
            string updateQuery = "UPDATE nhan_vien SET MatKhau = @MatKhauMoi WHERE MANV = @MaNV";
            var updateParams = new Dictionary<string, object>
            {
                { "@MaNV", maNV },
                { "@MatKhauMoi", matKhauMoi }
            };

            return DataProvider.ExecuteNonQuery(updateQuery, updateParams) > 0;
        }
    }
}
