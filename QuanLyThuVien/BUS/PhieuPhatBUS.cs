using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;

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

        public List<PhieuTraViPhamDTO> GetDanhSachViPham()
        {
            return PhieuPhatDAO.Instance.GetDanhSachViPham();
        }

        public bool CreatePhieuPhatFromViolations(List<PhieuTraViPhamDTO> items)
        {
            if (items == null || items.Count == 0) return false;
            return PhieuPhatDAO.Instance.CreatePhieuPhatFromViolations(items);
        }
    }
}
