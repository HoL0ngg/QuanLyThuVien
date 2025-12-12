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

        public List<PhieuTraDTO> GetAllPhieuTra()
        {
            return PhieuTraDAO.Instance.GetAll();
        }

        public List<CTPhieuTraDTO> GetCTPhieuTraById(int id)
        {
            return PhieuTraDAO.Instance.GetCTPhieuTraById(id);
        }

        public bool InSertPhieuTra(PhieuTraDTO pt)
        {
           
            int maPhieuTra = PhieuTraDAO.Instance.InsertPhieuTra(pt);
            if (maPhieuTra > 0)
            {
               
                foreach (var ct in pt.list)
                {
                    ct.MaPhieuTra = maPhieuTra;
                    PhieuTraDAO.Instance.InsertCTPhieuTra(ct);
                }

               if(pt.NgayTra > pt.NgayTraDuKien)
                {
                    PhieuTraDAO.Instance.UpdateTrangThaiPhieuMuon(pt.MaPhieuMuon, 3);
                }
                else
                {
                    PhieuTraDAO.Instance.UpdateTrangThaiPhieuMuon(pt.MaPhieuMuon, 2);
                }

                return true;
            }
            return false;
        }

        public bool Delete(int maPhieuTra)
        {

            return PhieuTraDAO.Instance.Delete(maPhieuTra);
        }
    }
}
