using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.BUS
{
    internal class PhieuPhatBUS
    {
        private static PhieuPhatBUS instance;

        public static PhieuPhatBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuPhatBUS();
                return instance;
            }
        }

        private PhieuPhatBUS() { }

        public List<PhieuPhatDTO> GetAllPhieuPhat()
        {
            return PhieuPhatDAO.Instance.GetAll();
        }
        public List<PhieuPhatDTO> GetTrangThaiPhieuPhat(int? trangThai = null)
        {
            if (trangThai.HasValue)
                return PhieuPhatDAO.Instance.GetByTrangThai(trangThai.Value);
            else
                return PhieuPhatDAO.Instance.GetAll();
        }
        public List<PhieuPhatDTO> GetByDateRange(DateTime starDate, DateTime endDate)
        {
            return PhieuPhatDAO.Instance.GetByDateRange(starDate, endDate);
        }
        public List<PhieuPhatDTO> GetByKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllPhieuPhat();
            return PhieuPhatDAO.Instance.GetByKeyword(keyword.Trim());
        }
        public bool AddPhieuPhat(PhieuPhatDTO phieuPhat)
        {
            if (phieuPhat == null)
                throw new ArgumentNullException(nameof(phieuPhat));

            return PhieuPhatDAO.Instance.Add(phieuPhat);
        }

        public bool UpdatePhieuPhat(PhieuPhatDTO phieuPhat)
        {
            if (phieuPhat == null)
                throw new ArgumentNullException(nameof(phieuPhat));

            return PhieuPhatDAO.Instance.Update(phieuPhat);
        }

        public bool XoaPhieuPhat(int maPhieuPhat)
        {
            return PhieuPhatDAO.Instance.SetTrangThai(maPhieuPhat, 0);
        }

        // New: set TrangThai = 1 (đóng / mark as paid)
        public bool DongPhieuPhat(int maPhieuPhat)
        {
            return PhieuPhatDAO.Instance.SetTrangThai(maPhieuPhat, 1);
        }

        // Set TrangThai tùy chỉnh (0 hoặc 1)
        public bool SetTrangThai(int maPhieuPhat, int trangThai)
        {
            return PhieuPhatDAO.Instance.SetTrangThai(maPhieuPhat, trangThai);
        }

        public List<PhieuTraViPhamDTO> GetDanhSachViPham()
        {
            return PhieuPhatDAO.Instance.GetDanhSachViPham();
        }

        public bool CreatePhieuPhatFromViolations(List<PhieuTraViPhamDTO> items)
        {
            if (items == null || items.Count == 0) return false;
            return PhieuPhatDAO.Instance.CreatePhieuPhatFromViolations(items);
        }

        // Add this helper in PhieuPhatBUS
        public DataTable GetChiTietPhieuPhat(int maPhieuTra)
        {
            return PhieuPhatDAO.Instance.GetChiTietPhieuPhat(maPhieuTra);
        }
        public DataTable GetChiTietPhieuPhatDaLuu(int maPhieuPhat)
        {
            return PhieuPhatDAO.Instance.GetListChiTietDaLuu(maPhieuPhat);
        }

        // New: wrapper to get/save MucPhat via DAO
        public MucPhatDTO GetMucPhat()
        {
            return PhieuPhatDAO.Instance.GetMucPhat();
        }

        public bool SaveMucPhat(MucPhatDTO dto)
        {
            return PhieuPhatDAO.Instance.SaveMucPhat(dto);
        }
    }
}
