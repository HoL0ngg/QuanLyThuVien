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
        public DateTime NgayTra { get; set; }
        public int MaDG { get; set; }
        public int MaNV { get; set; }
 
        public List<CTPhieuTraDTO> list { get; set; }

        public PhieuTraDTO()
        {
            list = new List<CTPhieuTraDTO>();
        }
    }
}
