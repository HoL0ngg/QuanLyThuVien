using System;

namespace QuanLyThuVien.DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public int TrangThai { get; set; } // 0: Ngh? vi?c, 1: ?ang làm

        public NhanVienDTO() { }

        public NhanVienDTO(int maNV, string tenNV, DateTime ngaySinh, string gioiTinh, 
            string diaChi, string sdt, string email, int trangThai)
        {
            MaNV = maNV;
            TenNV = tenNV;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            SDT = sdt;
            Email = email;
            TrangThai = trangThai;
        }

        public string TrangThaiText
        {
            get { return TrangThai == 1 ? "?ang làm" : "Ngh? vi?c"; }
        }
    }
}
