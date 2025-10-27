using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    public class TacGiaDTO
    {
        public int maTacGia { get; set; }
        public string tenTacGia { get; set; }
        public string quocTich { get; set; }

        public string namSinh { get; set; }

        public override string ToString()
        {
            return tenTacGia;
        }

    }
}
