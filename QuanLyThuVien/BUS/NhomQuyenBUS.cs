using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyThuVien.BUS
{
    public class NhomQuyenBUS
    {
        private static NhomQuyenBUS instance;

        public static NhomQuyenBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomQuyenBUS();
                return instance;
            }
        }

        private NhomQuyenBUS() { }

        /// <summary>
        /// Lay tat ca nhom quyen
        /// </summary>
        public List<NhomQuyenDTO> GetAllNhomQuyen()
        {
            return NhomQuyenDAO.Instance.GetAllNhomQuyen();
        }

        /// <summary>
        /// Lay tat ca chuc nang
        /// </summary>
        public List<ChucNangDTO> GetAllChucNang()
        {
            return NhomQuyenDAO.Instance.GetAllChucNang();
        }

        /// <summary>
        /// Lay nhom quyen theo ma
        /// </summary>
        public NhomQuyenDTO GetNhomQuyenById(int maNhomQuyen)
        {
            if (maNhomQuyen < 0)
                throw new ArgumentException("Ma nhom quyen khong hop le");

            return NhomQuyenDAO.Instance.GetNhomQuyenById(maNhomQuyen);
        }

        /// <summary>
        /// Lay quyen cua mot nhom quyen tren tat ca chuc nang
        /// </summary>
        public List<QuyenChucNangDTO> GetQuyenByNhomQuyen(int maNhomQuyen)
        {
            return NhomQuyenDAO.Instance.GetQuyenByNhomQuyen(maNhomQuyen);
        }

        /// <summary>
        /// Cap nhat quyen cho mot nhom quyen tren mot chuc nang
        /// </summary>
        public bool UpdateQuyenChucNang(QuyenChucNangDTO quyen)
        {
            if (quyen == null)
                throw new ArgumentNullException("Thong tin quyen khong duoc de trong");

            return NhomQuyenDAO.Instance.UpdateQuyenChucNang(quyen);
        }

        /// <summary>
        /// Them nhom quyen moi
        /// </summary>
        public int ThemNhomQuyen(string tenNhomQuyen)
        {
            if (string.IsNullOrWhiteSpace(tenNhomQuyen))
                throw new Exception("Ten nhom quyen khong duoc de trong");

            return NhomQuyenDAO.Instance.InsertNhomQuyen(tenNhomQuyen);
        }

        /// <summary>
        /// Xoa nhom quyen
        /// </summary>
        public bool XoaNhomQuyen(int maNhomQuyen)
        {
            if (maNhomQuyen <= 0)
                throw new ArgumentException("Ma nhom quyen khong hop le");

            // Khong cho xoa nhom Admin (ma = 0 hoac 1)
            if (maNhomQuyen <= 1)
                throw new Exception("Khong the xoa nhom quyen Admin!");

            return NhomQuyenDAO.Instance.DeleteNhomQuyen(maNhomQuyen);
        }

        /// <summary>
        /// Kiem tra quyen cua mot nhom quyen tren mot chuc nang
        /// </summary>
        public bool KiemTraQuyen(int maNhomQuyen, string tenChucNang, string hanhDong)
        {
            return NhomQuyenDAO.Instance.KiemTraQuyen(maNhomQuyen, tenChucNang, hanhDong);
        }

        /// <summary>
        /// Kiem tra co it nhat 1 quyen tren chuc nang khong (de hien thi menu)
        /// </summary>
        public bool CoItNhatMotQuyen(int maNhomQuyen, string tenChucNang)
        {
            return NhomQuyenDAO.Instance.CoItNhatMotQuyen(maNhomQuyen, tenChucNang);
        }
    }
}
