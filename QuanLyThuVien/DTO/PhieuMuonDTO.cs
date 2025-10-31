using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class PhieuMuonDTO
    {
        public int MaPhieuMuon { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public int TrangThai { get; set; }
        public int MaDocGia { get; set; }
        public int MaNhanVien { get; set; }
        public List<CTPhieuMuonDTO> CTPM { get; set; }
        public PhieuMuonDTO() 
        {   
            CTPM = new List<CTPhieuMuonDTO>();
        }
    }
}
