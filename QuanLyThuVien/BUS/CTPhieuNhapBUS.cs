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
        private DauSachBUS dauSachBus = DauSachBUS.Instance;

        // lay danh sach ct phieu nhap
        public List<CTPhieuNhapDTO> GetALL()
        {   
            return dao.GetAll();
        }

        // lay ct phieu nhap theo ma phieu nhap
        public List<CTPhieuNhapDTO> GetByPhieuNhap(int maPhieuNhap)
        {
            if(maPhieuNhap <= 0)
                throw new Exception("Mã phiếu nhập không hợp lệ");
            return dao.GetByPhieuNhap(maPhieuNhap);
        }
        public List<CTPhieuNhapDTO> Search(int maPhieuNhap,string tensach)
        {
            return dao.Search(maPhieuNhap, tensach);
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
            if (dao.Insert(ct))
            {
                try
                {
                    dauSachBus.CapNhatSoLuongTon(ct.MaDauSach, ct.SoLuong);

                    dauSachBus.CapNhatDonGia(ct.MaDauSach, ct.DonGia);

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật tồn kho sau khi nhập sách: " + ex.Message);
                }
            }
            return false;
        }

        // xoa ct phieu nhap theo ma phieu nhap
        public bool DeletePhieuNhap(int maPhieuNhap,int maDauSach)
        {
            if (maPhieuNhap <= 0  && maDauSach <= 0)
                throw new Exception("Ma phieu nhap khong hop le");
            CTPhieuNhapDTO ctCu = dao.GetDetail(maPhieuNhap, maDauSach);

            if (ctCu == null)
            {
                return true;
            }
            if (dao.DeletePhieuNhap(maPhieuNhap, maDauSach))
            {
                try
                {
                    return dauSachBus.CapNhatSoLuongTon(ctCu.MaDauSach, -ctCu.SoLuong);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật tồn kho sau khi xóa chi tiết phiếu: " + ex.Message);
                }
            }

            return false;
        }
        public bool DeleteAllDetailsByMaPhieuNhap(int maPhieuNhap)
        {
            if (maPhieuNhap <= 0)
                throw new Exception("Ma phieu nhap khong hop le");

            // Gọi đến hàm DAO để thực thi việc xóa hàng loạt
            return dao.DeleteAllDetailsByMaPhieuNhap(maPhieuNhap);
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
        //sua chi tiet
        public bool Update(CTPhieuNhapDTO cT)
        {
            return dao.Update(cT);
        }
    }
}
