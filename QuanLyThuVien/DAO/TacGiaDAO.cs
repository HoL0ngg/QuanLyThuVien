using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class TacGiaDAO
    {
        private static TacGiaDAO _instance;
        public static TacGiaDAO Instance => _instance ?? (_instance = new TacGiaDAO());
        private TacGiaDAO() { }

        public DataTable GetAllTacGia()
        {
            // Giả sử bảng của bạn là TACGIA(MaTacGia, TenTacGia)
            string query = "SELECT MaTacGia, TenTacGia FROM TACGIA ORDER BY TenTacGia";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
