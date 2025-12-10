using System;

namespace QuanLyThuVien.DTO
{
    public class ThongKeSachKPIDTO
    {
        public int TongDauSach { get; set; }
        public int TongBanSach { get; set; }
        public int SachDangMuon { get; set; }
        public int SachQuaHan { get; set; }
        public int TonKhoLau { get; set; } // không mý?n trong 6 tháng
        public decimal TyLeSuDung { get; set; } // % sách ðang mý?n / t?ng
    }

    public class Top5SachDTO
    {
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public int SoLuotMuon { get; set; }
        public int MaxLuotMuon { get; set; } // Ð? tính % cho progress bar
    }

    public class Top5TheLoaiDTO
    {
        public string TenTheLoai { get; set; }
        public int TongLuotMuon { get; set; }
        public decimal TyLe { get; set; } // % so v?i t?ng
    }

    public class ChiTietKhoSachDTO
    {
        public int MaDauSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public int TongSoBan { get; set; }
        public int SobanCoSan { get; set; }
        public int SoBanDangMuon { get; set; }
        public int TongLuotMuon { get; set; }
        public int NgayTuMuonCuoi { get; set; } // S? ngày t? l?n mý?n cu?i
        public string TinhTrang { get; set; } // "Có s?n", "Ðang mý?n", "Quá h?n", "T?n kho lâu"
        public int TongDauSach { get; set; }
        public int SachCoSan { get; set; }
        public int SachHong { get; set; }
    }
    public class ThongKeSachDTO
    {
        public int MaDauSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public int TongSoBan { get; set; }
        public int SobanCoSan { get; set; }
        public int SoBanDangMuon { get; set; }
        public int TongLuotMuon { get; set; }
        public int NgayTuMuonCuoi { get; set; } // S? ngày t? l?n mý?n cu?i
        public string TinhTrang { get; set; } // "Có s?n", "Ðang mý?n", "Quá h?n", "T?n kho lâu"
        public int TongDauSach { get; set; }
        public int SachCoSan { get; set; }
        public int SachHong { get; set; }
        public string NamXuatBan { get; set; }
        public decimal GiaTriUocTinh { get; set; }
        public string TrangThai { get; set; }




    }
}
