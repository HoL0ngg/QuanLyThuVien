using System;
using System.Collections.Generic;

namespace QuanLyThuVien.DTO
{
    public class NhomQuyenDTO
    {
        public int MaNhomQuyen { get; set; }
        public string TenNhomQuyen { get; set; }
        
        // Danh sách quy?n theo t?ng ch?c n?ng
        public List<QuyenChucNangDTO> DanhSachQuyen { get; set; }

        public NhomQuyenDTO() 
        {
            DanhSachQuyen = new List<QuyenChucNangDTO>();
        }

        public NhomQuyenDTO(int maNhomQuyen, string tenNhomQuyen)
        {
            MaNhomQuyen = maNhomQuyen;
            TenNhomQuyen = tenNhomQuyen;
            DanhSachQuyen = new List<QuyenChucNangDTO>();
        }

        public override string ToString()
        {
            return TenNhomQuyen;
        }
    }
}
