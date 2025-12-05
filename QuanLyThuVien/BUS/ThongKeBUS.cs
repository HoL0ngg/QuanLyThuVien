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
        /// Lấy dữ liệu tổng quan thống kê trong khoảng thời gian
        /// </summary>
        public ThongKeOverviewDTO GetOverview(DateTime from, DateTime to)
        {
            var dto = new ThongKeOverviewDTO
            {
                TongLuotMuon = ThongKeDAO.Instance.GetTongLuotMuon(from, to),
                TongSachTrongKho = ThongKeDAO.Instance.GetTongSachTrongKho(),
                SachQuaHan = ThongKeDAO.Instance.GetSoSachQuaHan(from, to),
                TongThuPhiPhat = ThongKeDAO.Instance.GetTongThuPhiPhat(from, to),
                SoPhieuMuon = ThongKeDAO.Instance.GetSoPhieuMuon(from, to),
                SoPhieuTra = ThongKeDAO.Instance.GetSoPhieuTra(from, to),
                SoDocGiaLienQuan = ThongKeDAO.Instance.GetSoDocGiaLienQuan(from, to)
            };

            return dto;
        }

        #endregion

        #region Thống kê Phiếu Mượn

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
            DataTable dt = ThongKeDAO.Instance.GetPhieuMuonKPIs(from, to);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        #endregion

        #region Thống kê Độc Giả

        /// <summary>
        /// Lấy KPI thống kê độc giả
        /// </summary>
        public DataRow GetDocGiaKPIs()
        {
            DataTable dt = ThongKeDAO.Instance.GetDocGiaKPIs();
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
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
