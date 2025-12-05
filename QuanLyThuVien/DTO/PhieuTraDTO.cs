using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class PhieuTraDTO
    {
        public int MaPhieuTra { get; set; }
        public int MaPhieuMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public int MADG { get; set; }
        public string TENDG { get; set; }
        public int MaNV { get; set; }
        public string TENNV { get; set; }
 
        public List<CTPhieuTraDTO> list { get; set; }

        public PhieuTraDTO()
        {
            list = new List<CTPhieuTraDTO>();
        }
    }
}
