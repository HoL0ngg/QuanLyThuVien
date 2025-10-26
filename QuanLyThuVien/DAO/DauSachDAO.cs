using System;
using System.Data;
// Thư viện này cần thiết cho Dictionary
using System.Collections.Generic;
// Đảm bảo using đúng namespace của DataProvider
using QuanLyThuVien.DAO;

namespace QuanLyThuVien.DAO // Hoặc QuanLyNhanSu.DAO
{
    public class DauSachDAO
    {
        // Ta vẫn dùng Singleton cho DAO để BUS gọi
        private static DauSachDAO _instance;
        public static DauSachDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DauSachDAO();
                return _instance;
            }
            private set { _instance = value; }
        }
        private DauSachDAO() { }

        public DataTable GetAllDauSach()
        {
            string query = @"
                SELECT 
                    ds.MaDauSach, 
                    ds.TenDauSach,
                    ds.HinhAnh,
                    ds.NhaXuatBan, 
                    ds.NamXuatBan,
                    ds.NgonNgu,
                    ds.SoLuong
                FROM 
                    dau_sach ds
                ORDER BY 
                    ds.MaDauSach ASC";

            // THAY ĐỔI 1: Gọi trực tiếp DataProvider.ExecuteQuery
            // vì hàm của bạn là static, không dùng Instance
            DataTable data = DataProvider.ExecuteQuery(query);

            return data;
        }

        public DataTable SearchDauSach(string keyword)
        {
            string searchKeyword = "%" + keyword + "%";

            string query = @"
                SELECT 
                    ds.MaDauSach, 
                    ds.TenDauSach,
                    ds.HinhAnh,
                    ds.NhaXuatBan, 
                    ds.NamXuatBan,
                    ds.NgonNgu,
                    ds.SoLuong
                FROM 
                    dau_sach ds
                WHERE 
                        ds.TenDauSach LIKE @keyword OR 
                        ds.TenTacGia LIKE @keyword OR 
                        ds.NhaXuatBan LIKE @keyword
                ORDER BY 
                    ds.MaDauSach ASC";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@keyword", searchKeyword);

            // Gọi DataProvider với Dictionary parameters
            DataTable data = DataProvider.ExecuteQuery(query, parameters);

            return data;
        }

        public bool AddDauSach(string tenDauSach, int maTacGia, int maNXB, DateTime ngayNhap)
        {
            string query = @"
            INSERT INTO DAUSACH (TenDauSach, MaTacGia, MaNXB, NgayNhap)
            VALUES (@tenDauSach, @maTacGia, @maNXB, @ngayNhap)";

            var parameters = new Dictionary<string, object>
            {
                { "@tenDauSach", tenDauSach },
                { "@maTacGia", maTacGia },
                { "@maNXB", maNXB },
                { "@ngayNhap", ngayNhap }
            };

            // Gọi hàm ExecuteNonQuery đã sửa
            int result = DataProvider.ExecuteNonQuery(query, parameters);

            return result > 0; // Trả về true nếu thành công (có > 0 dòng bị ảnh hưởng)
        }
    }
}