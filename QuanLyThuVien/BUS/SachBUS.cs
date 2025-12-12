using System;
using System.Collections.Generic;
using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.BUS
{
    public class SachBUS
    {
        private static SachBUS _instance;
        public static SachBUS Instance => _instance ?? (_instance = new SachBUS());
        public SachBUS() { }

        // Dùng singleton DAO
        private SachDAO dao => SachDAO.Instance;

        public List<SachDTO> SearchSachNotBorrow(string tendausach)
        {
            return dao.SearchSachNotBorrow(tendausach);
        }

        // Lấy tất cả sách
        public List<SachDTO> GetAll()
        {
            return dao.GetAll();
        }

        // Lấy sách theo mã
        public SachDTO GetById(int maSach)
        {
            if (maSach <= 0) throw new ArgumentException("Mã sách không hợp lệ");
            return dao.GetById(maSach);
        }

        // Tìm kiếm sách theo điều kiện
        public List<SachDTO> Search(int? maSach = null, int? trangThai = null, int? maDauSach = null)
        {
            return dao.Search(maSach, trangThai, maDauSach);
        }

        // Thêm sách
        public bool Add(int trangThai, int maDauSach)
        {
            if (maDauSach <= 0) throw new ArgumentException("Mã đầu sách không hợp lệ");
            var sach = new SachDTO { TrangThai = trangThai, MaDauSach = maDauSach };
            return dao.Create(sach);
        }

        // Cập nhật sách
        public bool Update(SachDTO sach)
        {
            return dao.Update(sach);
        }   

        // Xóa sách
        public bool Delete(int maSach)
        {
            if (maSach <= 0) throw new ArgumentException("Mã sách không hợp lệ");
            return dao.Delete(maSach);
        }

        // Các hàm JOIN để lấy đủ thông tin
        public List<SachDTO> GetAllWithDauSach()
        {
            return dao.GetAllWithDauSach();
        }

        public SachDTO GetByIdWithDauSach(int maSach)
        {
            if (maSach <= 0) throw new ArgumentException("Mã sách không hợp lệ");
            return dao.GetByIdWithDauSach(maSach);
        }

        public List<SachDTO> GetByMaDauSachWithDauSach(int maDauSach)
        {
            if (maDauSach <= 0) throw new ArgumentException("Mã đầu sách không hợp lệ");
            return dao.GetByMaDauSachWithDauSach(maDauSach);
        }
    }
}
