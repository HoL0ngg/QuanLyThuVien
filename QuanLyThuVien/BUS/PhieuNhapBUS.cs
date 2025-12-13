using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    public class PhieuNhapBUS
    {
        private PhieuNhapDAO dao = new PhieuNhapDAO();
        private CTPhieuNhapBUS ctBus = new CTPhieuNhapBUS();
        private DauSachBUS dauSachBus = DauSachBUS.Instance;

        // lay danh sach phieu nhap
        public List<PhieuNhapDTO> GetALL()
        {
            return dao.GetAll();
        }

        // them phieu nhap
        public bool Insert(PhieuNhapDTO pn)
        {
            if (pn == null)
                throw new ArgumentNullException(nameof(pn));
            if (pn.ThoiGian == DateTime.MinValue)
                throw new Exception("Ngày nhập không hợp lệ");
            return dao.Insert(pn);
        }
        public bool Update(PhieuNhapDTO pn)
        {
            if (pn == null || pn.MaPhieuNhap <= 0)
            {
                throw new Exception("Thông tin phiếu nhập không hợp lệ");
            }
            return dao.Update(pn);  
        }
        public bool Delete(int maPhieuNhap)
        {
            if (maPhieuNhap <= 0)
            {
                throw new ArgumentException("Mã Phiếu Nhập không hợp lệ.");
            }
            List<CTPhieuNhapDTO> listDetails = ctBus.GetByPhieuNhap(maPhieuNhap);

            if (listDetails == null || listDetails.Count == 0)
            {
                return dao.Delete(maPhieuNhap);
            }

            try
            {
                foreach (var detail in listDetails)
                {
                    int soLuongGiam = -detail.SoLuong;

                    if (!dauSachBus.CapNhatSoLuongTon(detail.MaDauSach, soLuongGiam))
                    {
                        
                        throw new Exception($"Không thể giảm tồn kho cho Đầu sách ID {detail.MaDauSach}.");
                    }
                }
                if (!ctBus.DeleteAllDetailsByMaPhieuNhap(maPhieuNhap))
                {
                    throw new Exception("Lỗi khi xóa các chi tiết Phiếu nhập.");
                }
                return dao.Delete(maPhieuNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa Phiếu nhập và cập nhật tồn kho: " + ex.Message);
            }
        }
        public PhieuNhapDTO GetById(int maPhieuNhap)
        {
            return dao.GetById(maPhieuNhap);
        }
        public List<PhieuNhapDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return dao.GetAll();
            }
            return dao.Search(keyword);
        }
    }
}
