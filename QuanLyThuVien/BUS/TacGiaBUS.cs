using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    public class TacGiaBUS
    {
        private static TacGiaBUS _instance;
        public static TacGiaBUS Instance => _instance ?? (_instance = new TacGiaBUS());
        private TacGiaBUS() { }

        public DataTable GetAllTacGia()
        {
            return TacGiaDAO.Instance.GetAllTacGia();
        }

        public bool Create(TacGiaDTO tg)
        {
            if (tg == null) return false;
            if (string.IsNullOrWhiteSpace(tg.tenTacGia)) throw new ArgumentException("Tên tác giả không được để trống");
            return TacGiaDAO.Instance.Create(tg);
        }
    }
}
