using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO tkDAO = new TaiKhoanDAO();

        public TaiKhoanDTO DangNhap(string username, string password)
        {
            // Có thể thêm logic khác (VD: kiểm tra trạng thái tài khoản)
            return tkDAO.KiemTraDangNhap(username, password);
        }
    }
}
