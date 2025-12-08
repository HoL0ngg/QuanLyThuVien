using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class TaiKhoanDAO
    {
        public TaiKhoanDTO KiemTraDangNhap(string username, string password)
        {
            // Sửa truy vấn: JOIN với bảng nhom_quyen và kiểm tra TrangThai
            string query = @"
                SELECT 
                    nv.*, 
                    nq.TENNQ
                FROM 
                    nhan_vien nv 
                JOIN 
                    nhom_quyen nq ON nv.MaNhomQuyen = nq.MANQ
                WHERE 
                    nv.TenDangNhap = @u AND nv.MatKhau = @p";

            var parameters = new Dictionary<string, object>
            {
                {"@u", username},
                {"@p", password}
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                
                // Kiểm tra trạng thái nhân viên
                int trangThai = Convert.ToInt32(row["TrangThai"]);
                
                return new TaiKhoanDTO
                {
                    TenNhanVien = row["TENNV"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    MatKhau = row["MatKhau"].ToString(),
                    ChucVu = row["TENNQ"].ToString(),
                    MaNhomQuyen = Convert.ToInt32(row["MaNhomQuyen"]),
                    TrangThai = trangThai  // Thêm trạng thái
                };
            }

            return null;
        }
    }
}
