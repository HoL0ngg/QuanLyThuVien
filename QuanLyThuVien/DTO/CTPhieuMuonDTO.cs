using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class CTPhieuMuonDTO
    {
        public int MaPhieuMuon { get; set; }
        public int MaSach { get; set; }
        public int MaDauSach { get; set; } 
        public string TenDauSach { get; set; }
        public string NhaXuatBan { get; set; }
        public int NamXuatBan { get; set; }
        public string NgonNgu { get; set; }
    }
}
