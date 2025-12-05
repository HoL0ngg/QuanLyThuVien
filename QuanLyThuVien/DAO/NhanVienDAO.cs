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
                    NV.MANV, NV.TENNV, NV.NGAYSINH, NV.SDT, NV.Email,NV.TenDangNhap,NQ.TENNQ AS ChucVu,
                    CASE
                        WHEN NV.GIOITINH = 1 THEN 'Nam'
                        WHEN NV.GIOITINH = 0 THEN 'Nữ'
                        ELSE 'Khác'
                    END AS GIOITINH,
                    CASE 
                        WHEN NV.TrangThai = 1 THEN 'Đang làm việc'
                        ELSE 'Nghỉ việc'
                    END AS TrangThai
                FROM nhan_vien NV
                LEFT JOIN nhom_quyen NQ ON NV.MaNhomQuyen = NQ.MANQ
                ORDER BY NV.MANV DESC";

            return DataProvider.ExecuteQuery(query);
        }

        public NhanVienDTO GetNhanVienById(int maNV)
        {
            string query = @"
                SELECT NV.MANV, NV.TENNV, NV.NGAYSINH, NV.GIOITINH,
                       NV.SDT, NV.Email, NV.TenDangNhap, NV.MatKhau, NV.MaNhomQuyen, NV.TrangThai,
                       NQ.TENNQ AS ChucVu
                FROM nhan_vien NV
                LEFT JOIN nhom_quyen NQ ON NV.MaNhomQuyen = NQ.MANQ
                WHERE NV.MANV = @MANV";

            var parameters = new Dictionary<string, object>
            {
                { "@MANV", maNV }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new NhanVienDTO
            {
                MaNV = Convert.ToInt32(row["MANV"]),
                TenNV = row["TENNV"]?.ToString(),
                NgaySinh = Convert.ToDateTime(row["NGAYSINH"]),
                GioiTinh = row["GIOITINH"]?.ToString(),
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
                (TENNV, NGAYSINH, GIOITINH, SDT, Email, TenDangNhap, MatKhau, MaNhomQuyen, TrangThai)
                VALUES 
                (@TENNV, @NGAYSINH, @GIOITINH, @SDT, @Email, @TenDangNhap, @MatKhau, @MaNhomQuyen, @TrangThai)";

            var parameters = new Dictionary<string, object>
            {
                { "@TENNV", nv.TenNV },
                { "@NGAYSINH", nv.NgaySinh },
                { "@GIOITINH", nv.GioiTinh },
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
                SET TENNV = @TENNV,
                    NGAYSINH = @NGAYSINH,
                    GIOITINH = @GIOITINH,
                    SDT = @SDT,
                    Email = @Email,
                    TrangThai = @TrangThai
                WHERE MANV = @MANV";

            var parameters = new Dictionary<string, object>
            {
                { "@MANV", nv.MaNV },
                { "@TENNV", nv.TenNV },
                { "@NGAYSINH", nv.NgaySinh },
                { "@GIOITINH", nv.GioiTinh },
                { "@SDT", nv.SDT ?? "" },
                { "@Email", nv.Email ?? "" },
                { "@TrangThai", nv.TrangThai }
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa nhân viên (soft delete)
        public bool DeleteNhanVien(int maNV)
        {
            string query = "UPDATE nhan_vien SET TrangThai = 0 WHERE MANV = @MANV";
            var parameters = new Dictionary<string, object>
            {
                { "@MANV", maNV }
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable SearchNhanVien(string keyword)
        {
            string query = @"
                SELECT 
                    MANV, TENNV, NGAYSINH, SDT, Email,
                    CASE
                        WHEN GIOITINH = 1 THEN 'Nam'
                        WHEN GIOITINH = 0 THEN 'Nữ'
                        ELSE 'Khác'
                    END AS GIOITINH,
                    CASE 
                        WHEN TrangThai = 1 THEN 'Đang làm việc'
                        ELSE 'Nghỉ việc'
                    END AS TrangThai
                FROM nhan_vien
                WHERE TENNV LIKE @Keyword 
                   OR SDT LIKE @Keyword 
                   OR Email LIKE @Keyword
                ORDER BY MANV DESC";

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
