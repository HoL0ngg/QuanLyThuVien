using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class CTPhieuTraDTO
    {
        public int MaCTPhieuTra { get; set; }
        public int MaPhieuTra { get; set; }
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TenTacGia { get; set; }
        public int TrangThai {  get; set; }
    }
}
