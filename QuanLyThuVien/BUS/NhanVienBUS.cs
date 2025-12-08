using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace QuanLyThuVien.BUS
{
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;

        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienBUS();
                return instance;
            }
        }

        private NhanVienBUS() { }

        // L?y t?t c? nhân viên
        public DataTable GetAllNhanVien()
        {
            return NhanVienDAO.Instance.GetAllNhanVien();
        }

        // L?y nhân viên theo mã
        public NhanVienDTO GetNhanVienById(int maNV)
        {
            if (maNV <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");

            return NhanVienDAO.Instance.GetNhanVienById(maNV);
        }

        // Thêm nhân viên m?i
        public bool ThemNhanVien(NhanVienDTO nv)
        {
            // Validate d? li?u
            if (nv == null)
                throw new ArgumentNullException("Thông tin nhân viên không được trống");

            if (string.IsNullOrWhiteSpace(nv.TenNV))
                throw new Exception("Tên nhân viên không được trống");

            if (nv.TenNV.Length < 3 || nv.TenNV.Length > 100)
                throw new Exception("Tên nhân viên phải từ 3-100 ký tự");

            if (nv.NgaySinh >= DateTime.Now)
                throw new Exception("Ngày sinh phải nhỏ hơn ngày hiện tại");

            int tuoi = DateTime.Now.Year - nv.NgaySinh.Year;
            if (tuoi < 18 || tuoi > 65)
                throw new Exception("Tuổi nhân viên phải từ 18-65");

            if (string.IsNullOrWhiteSpace(nv.GioiTinh))
                throw new Exception("Giới tính không được trống");

            if (!string.IsNullOrWhiteSpace(nv.SDT))
            {
                if (!Regex.IsMatch(nv.SDT, @"^0\d{9}$"))
                    throw new Exception("Số điện thoại không hợp lệ");
            }

            if (!string.IsNullOrWhiteSpace(nv.Email))
            {
                if (!Regex.IsMatch(nv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new Exception("Email không h?p l?");
            }

            return NhanVienDAO.Instance.InsertNhanVien(nv);
        }

        // S?a nhân viên
        public bool SuaNhanVien(NhanVienDTO nv)
        {
            if (nv == null || nv.MaNV <= 0)
                throw new Exception("Thông tin nhân viên không hợp lệ");

            if (string.IsNullOrWhiteSpace(nv.TenNV))
                throw new Exception("Tên nhân viên không được trống");

            if (nv.TenNV.Length < 3 || nv.TenNV.Length > 100)
                throw new Exception("Tên nhân viên phải từ 3-100 ký tự");

            if (!string.IsNullOrWhiteSpace(nv.SDT))
            {
                if (!Regex.IsMatch(nv.SDT, @"^0\d{9,10}$"))
                    throw new Exception("Số điện thoại không hợp lệ");
            }

            if (!string.IsNullOrWhiteSpace(nv.Email))
            {
                if (!Regex.IsMatch(nv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new Exception("Email không hợp lệ");
            }

            return NhanVienDAO.Instance.UpdateNhanVien(nv);
        }

        // Xóa nhân viên
        public bool XoaNhanVien(int maNV)
        {
            if (maNV <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");

            return NhanVienDAO.Instance.DeleteNhanVien(maNV);
        }

        // Tìm ki?m nhân viên
        public DataTable TimKiemNhanVien(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllNhanVien();

            return NhanVienDAO.Instance.SearchNhanVien(keyword.Trim());
        }

        // ??i m?t kh?u
        public bool DoiMatKhau(int maNV, string matKhauCu, string matKhauMoi)
        {
            if (maNV <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");

            if (string.IsNullOrWhiteSpace(matKhauCu))
                throw new Exception("Mật khẩu cũ không được để trống");

            if (string.IsNullOrWhiteSpace(matKhauMoi))
                throw new Exception("Mật khẩu mới không được để trống");

            if (matKhauMoi.Length < 6)
                throw new Exception("Mật khẩu mới phải có ít nhất 6 ký tự");

            return NhanVienDAO.Instance.DoiMatKhau(maNV, matKhauCu, matKhauMoi);
        }

        // Cập nhật nhóm quyền cho nhân viên
        public bool CapNhatNhomQuyen(int maNV, int maNhomQuyen)
        {
            if (maNV <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");

            if (maNhomQuyen <= 0)
                throw new ArgumentException("Mã nhóm quyền không hợp lệ");

            return NhanVienDAO.Instance.CapNhatNhomQuyen(maNV, maNhomQuyen);
        }
    }
}
