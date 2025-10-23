using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    public class DauSachBUS
    {
        // Singleton Pattern
        private static DauSachBUS _instance;
        public static DauSachBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DauSachBUS();
                return _instance;
            }
            private set { _instance = value; }
        }
        private DauSachBUS() { }

        public DataTable SearchDauSach(string keyword)
        {
            // Trong tương lai, bạn có thể thêm logic ở đây
            // Ví dụ: if (keyword.Length < 3) return null;
            // Hoặc xử lý, chuẩn hóa keyword trước khi gọi DAO

            // Hiện tại, chỉ cần gọi thẳng xuống DAO
            return DauSachDAO.Instance.SearchDauSach(keyword);
        }

        public DataTable GetAllDauSach()
        {
            // Gọi thẳng xuống DAO
            return DauSachDAO.Instance.GetAllDauSach();
        }
    }
}
