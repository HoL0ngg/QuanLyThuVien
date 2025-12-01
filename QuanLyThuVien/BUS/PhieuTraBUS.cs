using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.BUS
{
    public class PhieuTraBUS
    {
        private static PhieuTraBUS instance;

        public static PhieuTraBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuTraBUS();
                return instance;
            }
        }

        private PhieuTraBUS() { }

        // L?y t?t c? phi?u tr?
        public List<PhieuTraDTO> GetAllPhieuTra()
        {
            return PhieuTraDAO.Instance.GetAll();
        }

        // L?y phi?u tr? theo ID
        public PhieuTraDTO GetPhieuTraById(int maPhieuTra)
        {
            if (maPhieuTra <= 0)
                throw new ArgumentException("Mã phi?u tr? không h?p l?");
            
            return PhieuTraDAO.Instance.GetById(maPhieuTra);
        }

        // L?y chi ti?t phi?u tr?
        public List<CTPhieuTraDTO> GetChiTietPhieuTra(int maPhieuTra)
        {
            if (maPhieuTra <= 0)
                throw new ArgumentException("Mã phi?u tr? không h?p l?");
            
            return PhieuTraDAO.Instance.GetChiTietByMaPhieuTra(maPhieuTra);
        }

        // Thêm phi?u tr?
        public bool ThemPhieuTra(PhieuTraDTO pt)
        {
            if (pt == null)
                throw new ArgumentNullException(nameof(pt));
            
            if (pt.MaDG <= 0)
                throw new Exception("Phi?u m??n không h?p l?");
            
            if (pt.NgayTra == DateTime.MinValue)
                throw new Exception("Ngày tr? không h?p l?");
            
            if (pt.list == null || pt.list.Count == 0)
                throw new Exception("Phi?u tr? ph?i có ít nh?t 1 sách");

            // Thêm phi?u tr?
            int maPhieuTra = PhieuTraDAO.Instance.Insert(pt);
            if (maPhieuTra > 0)
            {
                // Thêm chi ti?t
                foreach (var ct in pt.list)
                {
                    ct.MaPhieuTra = maPhieuTra;
                    PhieuTraDAO.Instance.InsertChiTiet(ct);
                    
                    // C?p nh?t tr?ng thái sách
                    PhieuTraDAO.Instance.UpdateTrangThaiSachDaTra(ct.MaSach);
                }
                
                // C?p nh?t tr?ng thái phi?u m??n
                PhieuTraDAO.Instance.UpdateTrangThaiPhieuMuon(pt.MaDG);
                
                return true;
            }
            return false;
        }

        // C?p nh?t phi?u tr?
        public bool SuaPhieuTra(PhieuTraDTO pt)
        {
            if (pt == null || pt.MaPhieuTra <= 0)
                throw new Exception("Thông tin phi?u tr? không h?p l?");
            
            return PhieuTraDAO.Instance.Update(pt);
        }

        // Xóa phi?u tr?
        public bool XoaPhieuTra(int maPhieuTra)
        {
            if (maPhieuTra <= 0)
                throw new Exception("Mã phi?u tr? không h?p l?");
            
            return PhieuTraDAO.Instance.Delete(maPhieuTra);
        }

        // L?y sách ?ang m??n theo phi?u m??n
        public List<CTPhieuTraDTO> GetSachDangMuonByPhieuMuon(int maPhieuMuon)
        {
            if (maPhieuMuon <= 0)
                throw new ArgumentException("Mã phi?u m??n không h?p l?");
            
            return PhieuTraDAO.Instance.GetSachDangMuonByPhieuMuon(maPhieuMuon);
        }

        // L?y danh sách phi?u m??n ch?a tr?
        public DataTable GetPhieuMuonChuaTra()
        {
            return PhieuTraDAO.Instance.GetPhieuMuonChuaTra();
        }

        // Tính t?ng ti?n ph?t
        public decimal TinhTongTienPhat(List<CTPhieuTraDTO> chiTiet)
        {
            decimal tong = 0;
            foreach (var ct in chiTiet)
            {
                tong += ct.TienPhat;
            }
            return tong;
        }
    }
}
