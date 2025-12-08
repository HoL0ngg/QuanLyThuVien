using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class TaiKhoanDTO
    {
        public string TenNhanVien { get; set; }
        public string TenDangNhap { get; set; }
        public int MaNV { get; set; }
        public string ChucVu { get; set; }
        public string MatKhau { get; set; }
        public int MaNhomQuyen { get; set; }
        public int TrangThai { get; set; }  // 1 = Đang làm việc, 0 = Nghỉ việc
        
        /// <summary>
        /// Kiểm tra nhân viên còn làm việc không
        /// </summary>
        public bool DangLamViec => TrangThai == 1;
    }
}
