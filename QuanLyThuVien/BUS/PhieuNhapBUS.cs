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
        private CTPhieuNhapDAO ctDao = new CTPhieuNhapDAO();
        private DauSachBUS dauSachBus = DauSachBUS.Instance;
        private DauSachDAO dauSachDAO = DauSachDAO.Instance;

        // lay danh sach phieu nhap
        public List<PhieuNhapDTO> GetALL()
        {
            return dao.GetAll();
        }

        // them phieu nhap
        public int Insert(PhieuNhapDTO pn)
        {
            int maPhieuNhapMoi = dao.Insert(pn);

            if (maPhieuNhapMoi <= 0)
            {
                return -1;
            }

            foreach (CTPhieuNhapDTO ct in pn.ct)
            {
                ct.MaPhieuNhap = maPhieuNhapMoi;

                bool ctSuccess = ctDao.Insert(ct);

                if (!ctSuccess)
                {
                    
                    return -1;
                }

                // 3. Cập nhật tồn kho (Nếu cần)
                // Ví dụ: DauSachBUS.Instance.CapNhatSoLuongTon(ct.MaDauSach, ct.SoLuong);
            }

            // Thành công
            return maPhieuNhapMoi;
        }
        public bool Update(PhieuNhapDTO pn)
        {
            if (pn == null || pn.MaPhieuNhap <= 0)
            {
                throw new Exception("Thông tin phiếu nhập không hợp lệ");
            }
            return dao.Update(pn);  
        }
        public bool UpdateFullPhieuNhap(PhieuNhapDTO pnMoi)
        {
            return dao.UpdatePhieuNhapTransaction(pnMoi);
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
        public bool ProcessPhieuNhap(PhieuNhapDTO phieuNhap)
        {
            bool result = false;
            try
            {
                if (dao.UpdatePhieuNhapTransaction(phieuNhap))
                {
                    foreach (var ct in phieuNhap.ct)
                    {
                        int maDauSach = ct.MaDauSach;
                        int soLuongNhap = ct.SoLuong;
                        double donGiaNhap = ct.DonGia;
                        if (!dauSachBus.CapNhatSoLuongTon(maDauSach, soLuongNhap))
                        {
                            throw new Exception($"Lỗi cập nhật tồn kho cho Mã: {maDauSach}.");
                        }
                        double giaBanMoi = donGiaNhap;
                        if (!dauSachBus.CapNhatGiaBan(maDauSach, giaBanMoi))
                        {
                            throw new Exception($"Lỗi cập nhật giá bán cho Mã: {maDauSach}.");
                        }
                    }
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xử lý tồn kho/giá bán (ProcessPhieuNhap): " + ex.Message, ex);
            }
            return result;
        }
    }

}
