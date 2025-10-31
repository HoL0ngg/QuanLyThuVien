using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
