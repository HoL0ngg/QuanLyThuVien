using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class PhieuTraViPhamDTO
    {
        public int MaCTPhieuTra { get; set; }
        public int TrangThai { get; set; }            // trạng thái chi tiết trả (1: bình thường, 2: hỏng, 3: mất)
        public int MaPhieuTra { get; set; }
        public int MaSach { get; set; }
        public int MaDG { get; set; }

        public DateTime NgayTra { get; set; }
        public DateTime NgayTraDuKien { get; set; }

        public string TenSach { get; set; }
        public string TenDocGia { get; set; }

        public int GiaSach { get; set; }

        // Số ngày trễ tính từ NgayTra - NgayTraDuKien (>=0)
        public int SoNgayTre { get; set; } // made writable

        // Cờ có quá hạn
        public bool QuaHan { get; set; } // made writable

        // Tiền phạt tính/tùy chỉnh
        public int TienPhat { get; set; }

        // Lý do phạt (chuỗi hiển thị)
        public string LyDo { get; set; }

        // Trạng thái mới do người dùng chọn (nếu cần)
        public int TrangThaiSachMoi { get; set; }
    }
}
