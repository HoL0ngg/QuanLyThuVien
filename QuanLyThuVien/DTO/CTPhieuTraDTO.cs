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
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraThucTe { get; set; }
        public int SoNgayTre { get; set; }
        public decimal TienPhat { get; set; }
        public string GhiChu { get; set; }
    }
}
