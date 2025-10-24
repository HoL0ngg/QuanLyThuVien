using QuanLyNhanSu.DAO;
using QuanLyThuVien.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class TaiKhoanDAO
    {
        public TaiKhoanDTO KiemTraDangNhap(string username, string password)
        {
            string query = "SELECT * FROM nhan_vien t " +
                           //"JOIN nhanvien n ON t.MaNV = n.MaNV " +
                           "WHERE TenDangNhap=@u AND MatKhau=@p";

            var parameters = new Dictionary<string, object>
            {
                {"@u", username},
                {"@p", password}
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TaiKhoanDTO
                {
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MaNV = row["MaNV"].ToString(),
                    //ChucVu = row["ChucVu"].ToString()
                };
            }

            return null;
        }

    }
}
