using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class PhieuNhapDTO
    {
        public int MaPhieuNhap { get; set; }
        public DateTime ThoiGian { get; set; }
        public int MaNV { get; set; }
        public int MaNCC { get; set; }
        public string TenNV { get; set; }
        public string TenNCC { get; set; }

        public List<CTPhieuNhapDTO> ct { get; set; }

        public PhieuNhapDTO()
        {
            ct = new List<CTPhieuNhapDTO>();
        }

    }
}
