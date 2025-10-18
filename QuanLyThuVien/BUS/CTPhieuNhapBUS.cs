using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    public class CTPhieuNhapBUS
    {
        private CTPhieuNhapDAO dao = new CTPhieuNhapDAO();

        // lay ct phieu nhap theo ma phieu nhap
        public List<CTPhieuNhapDTO> GetByPhieuNhap(int maPhieuNhap)
        {
            if(maPhieuNhap <= 0)
                throw new Exception("Mã phiếu nhập không hợp lệ");
            return dao.GetByPhieuNhap(maPhieuNhap);
        }

        // them chi tiet phieu nhap
        public bool Insert(CTPhieuNhapDTO ct)
        {
            if (ct == null)
                throw new ArgumentNullException(nameof(ct));
            if (ct.MaPhieuNhap <= 0 || ct.MaDauSach <= 0)
                throw new Exception("Thong tin khong hop le");
            if (ct.SoLuong <= 0)
                throw new Exception("So luong phai lon hon 0");
            return dao.Insert(ct);
        }

        // xoa ct phieu nhap theo ma phieu nhap
        public bool DeleteByPhieuNhap(int maPhieuNhap)
        {
            if (maPhieuNhap <= 0)
                throw new Exception("Ma phieu nhap khong hop le");
            return dao.DeleteByPhieuNhap(maPhieuNhap);
        }

        // tinh tong so luong sach trong phieu nhap
        public int TinhTongSoLuong(int maPhieuNhap)
        {
            var list = dao.GetByPhieuNhap(maPhieuNhap);
            int sum = 0;
            foreach(var ct in list)
                sum += ct.SoLuong;
            return sum;
        }
    }
}
