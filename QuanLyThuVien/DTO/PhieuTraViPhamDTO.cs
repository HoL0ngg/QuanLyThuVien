using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    internal class PhieuTraViPhamDTO
    {
        public int MaCTPhieuTra { get; set; }
        public int TrangThai { get; set; }
        public int MaPhieuTra { get; set; }
        public int MaSach { get; set; }

        // --- BẮT BUỘC PHẢI CÓ DÒNG NÀY ---
        public int MaDG { get; set; }
        // ---------------------------------

        public DateTime NgayTra { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public string TenSach { get; set; }
        public string TenDocGia { get; set; }
        public bool QuaHan { get; set; }

        public int SoNgayTre
        {
            get
            {
                TimeSpan diff = NgayTra - NgayTraDuKien;
                return diff.Days > 0 ? diff.Days : 0;
            }
        }
        public int TienPhat { get; set; }
    }
}
