using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.BUS
{
    public class ThongKeBUS
    {
        private static ThongKeBUS _instance;
        public static ThongKeBUS Instance => _instance ?? (_instance = new ThongKeBUS());
        private ThongKeBUS() { }

        #region Thống kê Tổng quan (Overview)

        /// <summary>
        /// Lấy dữ liệu tổng quan thống kê tất cả (không giới hạn thời gian)
        /// </summary>
        //public ThongKeOverviewDTO GetOverviewAll()
        //{
        //    var dto = new ThongKeOverviewDTO
        //    {
        //        TongLuotMuon = ThongKeDAO.Instance.GetTongLuotMuonAll(),
        //        TongSachTrongKho = ThongKeDAO.Instance.GetTongSachTrongKho(),
        //        SachQuaHan = ThongKeDAO.Instance.GetSoSachQuaHanAll(),
        //        TongThuPhiPhat = ThongKeDAO.Instance.GetTongThuPhiPhatAll(),
        //        SoPhieuMuon = ThongKeDAO.Instance.GetSoPhieuMuonAll(),
        //        SoPhieuTra = ThongKeDAO.Instance.GetSoPhieuTraAll(),
        //        SoDocGiaLienQuan = ThongKeDAO.Instance.GetSoDocGiaLienQuanAll()
        //    };

        //    return dto;
        //}

        /// <summary>
        /// Lấy dữ liệu tổng quan thống kê trong khoảng thời gian
        /// </summary>
        public ThongKeOverviewDTO GetOverview(DateTime from, DateTime to)
        {
            var dto = new ThongKeOverviewDTO
            {
                TongLuotMuon = ThongKeDAO.Instance.GetTongLuotMuon(from, to),
                TongSachTrongKho = ThongKeDAO.Instance.GetTongSachTrongKho(),
                SachMatHong = ThongKeDAO.Instance.GetSoSachMatHong(from, to),
                TongThuPhiPhat = ThongKeDAO.Instance.GetTongThuPhiPhat(from, to),
                SoPhieuMuon = ThongKeDAO.Instance.GetSoPhieuMuon(from, to),
                SoPhieuTra = ThongKeDAO.Instance.GetSoPhieuTra(from, to),
                SoDocGiaLienQuan = ThongKeDAO.Instance.GetSoDocGiaLienQuan(from, to)
            };

            return dto;
        }

        /// <summary>
        /// Lấy dữ liệu tổng quan thống kê trong khoảng thời gian - PHIÊN BẢN TỐI ƯU
        /// Chỉ gọi 1 query thay vì 7 queries riêng biệt
        /// </summary>
        public ThongKeOverviewDTO GetOverviewOptimized(DateTime from, DateTime to)
        {
            return ThongKeDAO.Instance.GetOverviewAllInOne(from, to);
        }

        /// <summary>
        /// Lấy xu hướng mượn/trả của tất cả 12 tháng - TỐI ƯU
        /// Chỉ gọi 1 query thay vì 12 queries riêng biệt
        /// </summary>
        public List<ThongKeOverviewDTO> GetTrendAll12Months()
        {
            return ThongKeDAO.Instance.GetTrendAll12Months();
        }

        public ThongKeOverviewDTO GetTrendByMonth(int month)
        {
            ThongKeOverviewDTO result = ThongKeDAO.Instance.GetTrendByMonth(month);
            return result;
        }

        public List<ThongKeOverviewDTO> GetTop5SachMuon()
        {
            return ThongKeDAO.Instance.GetTop5SachMuon();
        }
        public List<ThongKeOverviewDTO> GetTop5TheLoai()
        {
            return ThongKeDAO.Instance.GetTop5TheLoai();
        }
        public int GetTongDauSach()
        {
            return ThongKeDAO.Instance.GetTongDauSach();
        }
        public int GetTongBanSach() { 
            return ThongKeDAO.Instance.GetTongBanSach();
        }
        #endregion

        public int GetSachSanSangChoMuon()
        {
            return ThongKeDAO.Instance.GetSachSanSangChoMuon();
        }
        public int GetSoSachHongMat()
        {
            return ThongKeDAO.Instance.GetSoSachHongMat();
        }
        


        /// <summary>
        /// Lấy danh sách phiếu mượn với chi tiết số lượng sách mượn
        /// </summary>
        public List<PhieuMuonDTO> GetAllPhieuMuonWithDetails()
        {
            DataTable dt = ThongKeDAO.Instance.GetAllPhieuMuonWithDetails();
            var list = new List<PhieuMuonDTO>();

            foreach (DataRow r in dt.Rows)
            {
                var pm = new PhieuMuonDTO
                {
                    MaPhieuMuon = Convert.ToInt32(r["MaPhieuMuon"]),
                    NgayMuon = Convert.ToDateTime(r["NgayMuon"]),
                    NgayTraDuKien = Convert.ToDateTime(r["NgayTraDuKien"]),
                    TrangThai = Convert.ToInt32(r["TrangThai"]),
                    MaDocGia = Convert.ToInt32(r["MaDocGia"]),
                    MaNhanVien = Convert.ToInt32(r["MaNhanVien"]),
                    TenDocGia = r["TenDocGia"]?.ToString(),
                    TenNhanVien = r["TenNhanVien"]?.ToString(),
                    CTPM = new List<CTPhieuMuonDTO>()
                };

                // Thêm placeholder cho số lượng sách (dùng để đếm)
                int soLuong = Convert.ToInt32(r["SoLuongSach"]);
                for (int i = 0; i < soLuong; i++)
                {
                    pm.CTPM.Add(new CTPhieuMuonDTO());
                }

                list.Add(pm);
            }

            return list;
        }
        public List<ThongKeSachDTO> GetSoLuongSachTheoTheLoai()
        {
            return ThongKeDAO.Instance.GetSoLuongSachTheoTheLoai();
        }
        public  List<ThongKeSachDTO> GetSoLuongSachTheoNam()
        {
            return ThongKeDAO.Instance.GetSoLuongSachTheoNam();
        }
        public List<ThongKeSachDTO> GetChiTietSach()
        {
            return ThongKeDAO.Instance.GetChiTietSach();
        }

        /// <summary>
        /// Lấy xu hướng mượn/trả tất cả (group theo tháng, 12 tháng gần nhất)
        /// </summary>
        public DataTable GetPhieuMuonTrendAll()
        {
            return ThongKeDAO.Instance.GetPhieuMuonTrendAll();
        }

        /// <summary>
        /// Lấy xu hướng mượn/trả theo ngày trong khoảng thời gian
        /// </summary>
        public DataTable GetPhieuMuonTrend(DateTime from, DateTime to)
        {
            return ThongKeDAO.Instance.GetPhieuMuonTrend(from, to);
        }

        /// <summary>
        /// Lấy tỷ lệ trả đúng hạn/trễ hạn trong khoảng thời gian
        /// </summary>
        public DataTable GetTyLeTra(DateTime from, DateTime to)
        {
            return ThongKeDAO.Instance.GetTyLeTra(from, to);
        }

        /// <summary>
        /// Lấy KPI thống kê phiếu mượn
        /// </summary>
        public DataRow GetPhieuMuonKPIs(DateTime from, DateTime to)
        {
            return ThongKeDAO.Instance.GetPhieuMuonKPIs(from, to);
        }

       

        #region Thống kê Độc Giả

        /// <summary>
        /// Lấy KPI thống kê độc giả
        /// </summary>
        public DataRow GetDocGiaKPIs()
        {
            return ThongKeDAO.Instance.GetDocGiaKPIs();
        }

        /// <summary>
        /// Lấy cơ cấu hoạt động độc giả (đang mượn, đã trả, quá hạn)
        /// </summary>
        public DataTable GetCoCauHoatDongDocGia()
        {
            return ThongKeDAO.Instance.GetCoCauHoatDongDocGia();
        }

        /// <summary>
        /// Lấy top 5 độc giả mượn nhiều nhất
        /// </summary>
        public DataTable GetTop5DocGiaMuonNhieu()
        {
            return ThongKeDAO.Instance.GetTop5DocGiaMuonNhieu();
        }

        /// <summary>
        /// Lấy danh sách chi tiết độc giả với thống kê
        /// </summary>
        public DataTable GetChiTietDocGia(string trangThai = "Tất cả", string keyword = "")
        {
            return ThongKeDAO.Instance.GetChiTietDocGia(trangThai, keyword);
        }

        #endregion
    }
}
