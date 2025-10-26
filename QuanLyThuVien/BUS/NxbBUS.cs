using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    public class NxbBUS
    {
        private static NxbBUS _instance;
        public static NxbBUS Instance => _instance ?? (_instance = new NxbBUS());
        private NxbBUS() { }
        public System.Data.DataTable getAllNxb()
        {
            return DAO.NxbDAO.Instance.getAllNxb();
        }
    }
}
