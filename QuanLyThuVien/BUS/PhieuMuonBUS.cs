using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.BUS
{
    public class PhieuMuonBUS
    {
        private PhieuMuonDAO pmDAO = new PhieuMuonDAO();
        public List<PhieuMuonDTO> GetAll()
        {
            return pmDAO.GetAll();
        }
        public PhieuMuonDTO GetById(int maPhieuMuon)
        {
            return pmDAO.GetById(maPhieuMuon);
        }

        public bool Create(PhieuMuonDTO pm)
        {
            if (pm == null)
            {
                throw new ArgumentNullException(nameof(pm));
            }
            return pmDAO.Create(pm);
        }

        public bool Update(PhieuMuonDTO pm)
        {
            if (pm == null || GetById(pm.MaPhieuMuon) == null)
            {
                throw new Exception("Thông tin phiếu mượn không hợp lệ");
            }
            return pmDAO.Update(pm);
        }

        public bool Delete(int maPhieuMuon)
        {
            if (GetById(maPhieuMuon) == null)
            {
                throw new Exception("Mã phiếu mượn không hợp lệ");
            }
            return pmDAO.Delete(maPhieuMuon);
        }

    }
}
