using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    internal class PhieuPhatDTO
    {
        public int MaPhieuPhat { get; set; }
        public DateTime NgayPhat { get; set; }
        public int TrangThai { get; set; }
        public int MaCTPhieuPhat { get; set; }
        public DateTime NgayTra { get; set; }
        public int tienPhat { get; set; }
        public String TenSach { get; set; }
        public String TenDG { get; set; }
    }
}
