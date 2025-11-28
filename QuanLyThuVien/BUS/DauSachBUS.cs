using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.DTO;

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

        public bool DeleteDauSach(int dauSachID)
        {
            try
            {
                return DauSachDAO.Instance.DeleteDauSach(dauSachID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateDauSach(int dauSachID, string tenDauSach, int maNXB, string hinhAnhPath, string namXuatBan, string ngonNgu, List<int> maTacGiaList)
        {
            // 1. Kiểm tra nghiệp vụ (Validation)
            if (string.IsNullOrWhiteSpace(tenDauSach))
            {
                // Có thể throw exception hoặc trả về false
                return false;
            }
            if (maTacGiaList == null || maTacGiaList.Count == 0 || maNXB <= 0)
            {
                // Sách phải có ít nhất 1 tác giả
                return false;
            }
            // 2. Gọi DAO
            try
            {
                return DauSachDAO.Instance.UpdateDauSach(dauSachID, tenDauSach, maNXB, hinhAnhPath, namXuatBan, ngonNgu, maTacGiaList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllDauSach()
        {
            // Gọi thẳng xuống DAO
            return DauSachDAO.Instance.GetAllDauSach();
        }

        public DauSachDTO GetDauSachByID(int dauSach)
        {
            try
            {
                return DauSachDAO.Instance.GetDauSachByID(dauSach);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TacGiaDTO> GetTacGiaByDauSachID(int dauSachID)
        {
            try
            {
                return DauSachDAO.Instance.GetTacGiaByDauSachID(dauSachID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddDauSach(string tenDauSach, int maNXB, string hinhAnhPath, string namXuatBan, string ngonNgu, List<int> maTacGiaList)
        {
            // 1. Kiểm tra nghiệp vụ (Validation)
            if (string.IsNullOrWhiteSpace(tenDauSach))
            {
                // Có thể throw exception hoặc trả về false
                return false;
            }
            if (maTacGiaList == null || maTacGiaList.Count == 0 || maNXB <= 0)
            {
                // Sách phải có ít nhất 1 tác giả
                return false;
            }

            // 2. Gọi DAO
            try
            {
                return DauSachDAO.Instance.AddDauSach(tenDauSach, maNXB, hinhAnhPath, namXuatBan, ngonNgu, maTacGiaList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}