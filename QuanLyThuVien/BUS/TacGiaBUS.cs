using QuanLyThuVien.DAO;
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
    }
}
