using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class NxbDAO
    {
        private static NxbDAO _instance;

        public static NxbDAO Instance => _instance ?? (_instance = new NxbDAO());

        private NxbDAO() { }

        public DataTable getAllNxb() {
            string query = "SELECT MaNCC, TenNCC FROM nha_cung_cap ORDER BY TenNCC";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
