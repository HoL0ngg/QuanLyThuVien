using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    public class CTPhieuMuonBUS
    {
        private CTPhieuMuonDAO ctpmDAO = new CTPhieuMuonDAO();
        public List<CTPhieuMuonDTO> GetByMaPhieuMuon(int maPhieuMuon)
        {
            return ctpmDAO.GetByMaPhieuMuon(maPhieuMuon);
        }

        public bool Create(CTPhieuMuonDTO ctpm)
        {
            if (ctpm == null)
            {
                throw new ArgumentNullException(nameof(ctpm));
            }
            return ctpmDAO.Create(ctpm);
        }

        public bool Delete(int maPhieuMuon, int maSach)
        {
            return ctpmDAO.Delete(maPhieuMuon, maSach);
        }
    }
}
