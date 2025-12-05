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
                throw new ArgumentException("Mã nhân viên không h?p l?");

            return NhanVienDAO.Instance.GetNhanVienById(maNV);
        }

        // Thêm nhân viên m?i
        public bool ThemNhanVien(NhanVienDTO nv)
        {
            // Validate d? li?u
            if (nv == null)
                throw new ArgumentNullException("Thông tin nhân viên không ???c ?? tr?ng");

            if (string.IsNullOrWhiteSpace(nv.TenNV))
                throw new Exception("Tên nhân viên không ???c ?? tr?ng");

            if (nv.TenNV.Length < 3 || nv.TenNV.Length > 100)
                throw new Exception("Tên nhân viên ph?i t? 3-100 ký t?");

            if (nv.NgaySinh >= DateTime.Now)
                throw new Exception("Ngày sinh ph?i nh? h?n ngày hi?n t?i");

            int tuoi = DateTime.Now.Year - nv.NgaySinh.Year;
            if (tuoi < 18 || tuoi > 65)
                throw new Exception("Tu?i nhân viên ph?i t? 18-65");

            if (string.IsNullOrWhiteSpace(nv.GioiTinh))
                throw new Exception("Gi?i tính không ???c ?? tr?ng");

            if (!string.IsNullOrWhiteSpace(nv.SDT))
            {
                if (!Regex.IsMatch(nv.SDT, @"^0\d{9,10}$"))
                    throw new Exception("S? ?i?n tho?i không h?p l? (ph?i b?t ??u b?ng 0 và có 10-11 s?)");
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
                throw new Exception("Thông tin nhân viên không h?p l?");

            if (string.IsNullOrWhiteSpace(nv.TenNV))
                throw new Exception("Tên nhân viên không ???c ?? tr?ng");

            if (nv.TenNV.Length < 3 || nv.TenNV.Length > 100)
                throw new Exception("Tên nhân viên ph?i t? 3-100 ký t?");

            if (!string.IsNullOrWhiteSpace(nv.SDT))
            {
                if (!Regex.IsMatch(nv.SDT, @"^0\d{9,10}$"))
                    throw new Exception("S? ?i?n tho?i không h?p l?");
            }

            if (!string.IsNullOrWhiteSpace(nv.Email))
            {
                if (!Regex.IsMatch(nv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new Exception("Email không h?p l?");
            }

            return NhanVienDAO.Instance.UpdateNhanVien(nv);
        }

        // Xóa nhân viên
        public bool XoaNhanVien(int maNV)
        {
            if (maNV <= 0)
                throw new ArgumentException("Mã nhân viên không h?p l?");

            return NhanVienDAO.Instance.DeleteNhanVien(maNV);
        }

        // Tìm ki?m nhân viên
        public DataTable TimKiemNhanVien(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllNhanVien();

            return NhanVienDAO.Instance.SearchNhanVien(keyword.Trim());
        }
    }
}
