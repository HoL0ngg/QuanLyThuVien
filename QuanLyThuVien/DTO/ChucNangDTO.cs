using System;

namespace QuanLyThuVien.DTO
{
    public class ChucNangDTO
    {
        public int MaChucNang { get; set; }
        public string TenChucNang { get; set; }

        public ChucNangDTO() { }

        public ChucNangDTO(int maChucNang, string tenChucNang)
        {
            MaChucNang = maChucNang;
            TenChucNang = tenChucNang;
        }

        public override string ToString()
        {
            return TenChucNang;
        }
    }
}
