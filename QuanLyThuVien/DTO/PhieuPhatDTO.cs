using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class PhieuPhatDTO
    {
        public int MaPhieuPhat { get; set; }
        public DateTime NgayPhat { get; set; }
        public int TrangThai { get; set; }
        public int MaCTPhieuPhat { get; set; }
        public DateTime NgayTra { get; set; }
        public int tienPhat { get; set; }
        public string TenSach { get; set; }
        public string TenDG { get; set; }
        public int MaDG { get; set; }
        public int MaCTPhieuTra { get; set; }
        public string LydoPhat { get; set; }
        public int MaPhieuTra { get; set; }
        public string TrangThaiText
        {
            get
            {
                return TrangThai == 1 ? "Đã đóng" : "Chưa đóng";
            }
        }


    }
}
