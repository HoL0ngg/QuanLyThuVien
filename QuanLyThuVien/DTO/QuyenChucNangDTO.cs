using System;

namespace QuanLyThuVien.DTO
{
    /// <summary>
    /// DTO ch?a quy?n c?a m?t nhóm quy?n trên m?t ch?c n?ng
    /// </summary>
    public class QuyenChucNangDTO
    {
        public int MaNhomQuyen { get; set; }
        public int MaChucNang { get; set; }
        public string TenChucNang { get; set; }
        
        // Các hành ??ng
        public bool QuyenXem { get; set; }
        public bool QuyenThem { get; set; }
        public bool QuyenSua { get; set; }
        public bool QuyenXoa { get; set; }

        public QuyenChucNangDTO() { }
    }
}
