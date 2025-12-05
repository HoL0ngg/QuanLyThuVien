using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class ThongKeDAO
    {
        private static ThongKeDAO _instance;
        public static ThongKeDAO Instance => _instance ?? (_instance = new ThongKeDAO());
        private ThongKeDAO() { }

        #region Helper Methods

        /// <summary>
        /// Thực hiện truy vấn scalar và trả về giá trị int an toàn
        /// </summary>
        public int SafeIntScalar(string sql, Dictionary<string, object> parameters)
        {
            object result = DataProvider.ExecuteScalar(sql, parameters);
            if (result == null || result == DBNull.Value) return 0;
            int value;
            return int.TryParse(result.ToString(), out value) ? value : 0;
        }

        #endregion

        #region Thống kê Tổng quan (Overview)

        /// <summary>
        /// Lấy tổng lượt mượn trong khoảng thời gian
        /// </summary>
        public int GetTongLuotMuon(DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM ctphieu_muon cm
                JOIN phieu_muon pm ON pm.MaPhieuMuon = cm.MaPhieuMuon
                WHERE pm.NgayMuon BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return SafeIntScalar(sql, parameters);
        }

        /// <summary>
        /// Lấy tổng sách trong kho
        /// </summary>
        public int GetTongSachTrongKho()
        {
            const string sql = "SELECT IFNULL(SUM(SoLuong),0) FROM dau_sach WHERE TrangThai = 1";
            return SafeIntScalar(sql, null);
        }

        /// <summary>
        /// Lấy số lượng sách quá hạn trong khoảng thời gian
        /// </summary>
        public int GetSoSachQuaHan(DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM phieu_tra pt
                JOIN phieu_muon pm ON pm.MaPhieuMuon = pt.MaPhieuMuon
                WHERE pt.NgayTra BETWEEN @from AND @to
                  AND pt.NgayTra > pm.NgayTraDuKien";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return SafeIntScalar(sql, parameters);
        }

        /// <summary>
        /// Lấy tổng thu phí phạt trong khoảng thời gian
        /// </summary>
        public int GetTongThuPhiPhat(DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT IFNULL(SUM(ct.TienPhat),0)
                FROM ctphieu_phat ct
                JOIN phieu_phat pp ON pp.MaPhieuPhat = ct.MaPhieuPhat
                WHERE pp.NgayPhat BETWEEN @from AND @to AND pp.TrangThai = 1";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return SafeIntScalar(sql, parameters);
        }

        /// <summary>
        /// Lấy số phiếu mượn trong khoảng thời gian
        /// </summary>
        public int GetSoPhieuMuon(DateTime from, DateTime to)
        {
            const string sql = "SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return SafeIntScalar(sql, parameters);
        }

        /// <summary>
        /// Lấy số phiếu trả trong khoảng thời gian
        /// </summary>
        public int GetSoPhieuTra(DateTime from, DateTime to)
        {
            const string sql = "SELECT COUNT(*) FROM phieu_tra WHERE NgayTra BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return SafeIntScalar(sql, parameters);
        }

        /// <summary>
        /// Lấy số độc giả liên quan trong khoảng thời gian
        /// </summary>
        public int GetSoDocGiaLienQuan(DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT COUNT(DISTINCT MaDG)
                FROM phieu_phat
                WHERE NgayPhat BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return SafeIntScalar(sql, parameters);
        }

        #endregion

        #region Thống kê Phiếu Mượn

        /// <summary>
        /// Lấy danh sách phiếu mượn với chi tiết số lượng sách mượn
        /// </summary>
        public DataTable GetAllPhieuMuonWithDetails()
        {
            const string sql = @"
                SELECT 
                    pm.MaPhieuMuon,
                    pm.NgayMuon,
                    pm.NgayTraDuKien,
                    pm.TrangThai,
                    pm.MaDocGia,
                    pm.MaNhanVien,
                    dg.TenDG AS TenDocGia,
                    nv.TenNV AS TenNhanVien,
                    (SELECT COUNT(*) FROM ctphieu_muon ct WHERE ct.MaPhieuMuon = pm.MaPhieuMuon) AS SoLuongSach
                FROM phieu_muon pm
                LEFT JOIN doc_gia dg ON pm.MaDocGia = dg.MaDG
                LEFT JOIN nhan_vien nv ON pm.MaNhanVien = nv.MaNV
                ORDER BY pm.NgayMuon DESC";

            return DataProvider.ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy xu hướng mượn/trả theo ngày trong khoảng thời gian
        /// </summary>
        public DataTable GetPhieuMuonTrend(DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT 
                    dates.Ngay,
                    IFNULL(borrow.SoMuon, 0) AS SoMuon,
                    IFNULL(ret.SoTra, 0) AS SoTra
                FROM (
                    SELECT DISTINCT DATE(NgayMuon) AS Ngay FROM phieu_muon 
                    WHERE NgayMuon BETWEEN @from AND @to
                    UNION
                    SELECT DISTINCT DATE(NgayTra) AS Ngay FROM phieu_tra 
                    WHERE NgayTra BETWEEN @from AND @to
                ) dates
                LEFT JOIN (
                    SELECT DATE(NgayMuon) AS Ngay, COUNT(*) AS SoMuon 
                    FROM phieu_muon 
                    WHERE NgayMuon BETWEEN @from AND @to
                    GROUP BY DATE(NgayMuon)
                ) borrow ON dates.Ngay = borrow.Ngay
                LEFT JOIN (
                    SELECT DATE(NgayTra) AS Ngay, COUNT(*) AS SoTra 
                    FROM phieu_tra 
                    WHERE NgayTra BETWEEN @from AND @to
                    GROUP BY DATE(NgayTra)
                ) ret ON dates.Ngay = ret.Ngay
                ORDER BY dates.Ngay";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return DataProvider.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Lấy tỷ lệ trả đúng hạn/trễ hạn trong khoảng thời gian
        /// </summary>
        public DataTable GetTyLeTra(DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT 
                    CASE 
                        WHEN pt.NgayTra <= pm.NgayTraDuKien THEN 'DungHan'
                        ELSE 'TreHan'
                    END AS LoaiTra,
                    COUNT(*) AS SoLuong
                FROM phieu_tra pt
                JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                WHERE pt.NgayTra BETWEEN @from AND @to
                GROUP BY CASE WHEN pt.NgayTra <= pm.NgayTraDuKien THEN 'DungHan' ELSE 'TreHan' END";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return DataProvider.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Lấy KPI thống kê phiếu mượn
        /// </summary>
        public DataTable GetPhieuMuonKPIs(DateTime from, DateTime to)
        {
            const string sql = @"
                SELECT 
                    (SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to) AS TongPhieu,
                    (SELECT COUNT(*) FROM ctphieu_muon cm 
                     JOIN phieu_muon pm ON cm.MaPhieuMuon = pm.MaPhieuMuon 
                     WHERE pm.NgayMuon BETWEEN @from AND @to) AS TongLuotSach,
                    (SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to AND TrangThai = 2) AS DaTraHoanTat,
                    (SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to AND TrangThai IN (1, 3)) AS DangMoQuaHan";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            return DataProvider.ExecuteQuery(sql, parameters);
        }

        #endregion

        #region Thống kê Độc Giả

        /// <summary>
        /// Lấy KPI thống kê độc giả
        /// </summary>
        public DataTable GetDocGiaKPIs()
        {
            const string sql = @"
                SELECT 
                    (SELECT COUNT(*) FROM doc_gia WHERE TRANGTHAI = 1) AS TongDocGia,
                    (SELECT COUNT(*) FROM doc_gia WHERE TRANGTHAI = 1 
                        AND MADG IN (SELECT DISTINCT MaDocGia FROM phieu_muon WHERE NgayMuon >= DATE_SUB(CURDATE(), INTERVAL 30 DAY))) AS DocGiaMoi,
                    (SELECT COUNT(DISTINCT MaDocGia) FROM phieu_muon WHERE TrangThai IN (1, 3)) AS DocGiaHoatDong,
                    (SELECT COUNT(DISTINCT MaDG) FROM phieu_phat WHERE TrangThai = 0) AS DocGiaNoTien";

            return DataProvider.ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy cơ cấu hoạt động độc giả (đang mượn, đã trả, quá hạn)
        /// </summary>
        public DataTable GetCoCauHoatDongDocGia()
        {
            const string sql = @"
                SELECT 'Đang mượn sách' AS TrangThai, COUNT(DISTINCT MaDocGia) AS SoLuong 
                FROM phieu_muon WHERE TrangThai = 1
                UNION ALL
                SELECT 'Đã trả hết sách' AS TrangThai, COUNT(DISTINCT MaDocGia) AS SoLuong 
                FROM phieu_muon WHERE TrangThai = 2
                UNION ALL
                SELECT 'Có sách quá hạn' AS TrangThai, COUNT(DISTINCT MaDocGia) AS SoLuong 
                FROM phieu_muon WHERE TrangThai = 3
                UNION ALL
                SELECT 'Chưa mượn sách' AS TrangThai, 
                    (SELECT COUNT(*) FROM doc_gia WHERE TRANGTHAI = 1) - 
                    (SELECT COUNT(DISTINCT MaDocGia) FROM phieu_muon) AS SoLuong";

            return DataProvider.ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy top 5 độc giả mượn nhiều nhất
        /// </summary>
        public DataTable GetTop5DocGiaMuonNhieu()
        {
            const string sql = @"
                SELECT 
                    dg.MADG AS MaDocGia,
                    dg.TENDG AS TenDocGia,
                    COUNT(cm.MaSach) AS TongLuotMuon
                FROM doc_gia dg
                INNER JOIN phieu_muon pm ON dg.MADG = pm.MaDocGia
                INNER JOIN ctphieu_muon cm ON pm.MaPhieuMuon = cm.MaPhieuMuon
                WHERE dg.TRANGTHAI = 1
                GROUP BY dg.MADG, dg.TENDG
                ORDER BY TongLuotMuon DESC
                LIMIT 5";

            return DataProvider.ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy danh sách chi tiết độc giả với thống kê
        /// </summary>
        public DataTable GetChiTietDocGia(string trangThai, string keyword)
        {
            string sql = @"
                SELECT 
                    dg.MADG AS MaDocGia,
                    dg.TENDG AS TenDocGia,
                    dg.SDT,
                    IFNULL(muon.TongLuotMuon, 0) AS TongLuotMuon,
                    IFNULL(dangGiu.SachDangGiu, 0) AS SachDangGiu,
                    IFNULL(quaHan.SachQuaHan, 0) AS SachQuaHan,
                    IFNULL(no.TongPhiNo, 0) AS TongPhiNo
                FROM doc_gia dg
                LEFT JOIN (
                    SELECT pm.MaDocGia, COUNT(cm.MaSach) AS TongLuotMuon
                    FROM phieu_muon pm
                    JOIN ctphieu_muon cm ON pm.MaPhieuMuon = cm.MaPhieuMuon
                    GROUP BY pm.MaDocGia
                ) muon ON dg.MADG = muon.MaDocGia
                LEFT JOIN (
                    SELECT pm.MaDocGia, COUNT(cm.MaSach) AS SachDangGiu
                    FROM phieu_muon pm
                    JOIN ctphieu_muon cm ON pm.MaPhieuMuon = cm.MaPhieuMuon
                    WHERE pm.TrangThai IN (1, 3)
                    GROUP BY pm.MaDocGia
                ) dangGiu ON dg.MADG = dangGiu.MaDocGia
                LEFT JOIN (
                    SELECT pm.MaDocGia, COUNT(cm.MaSach) AS SachQuaHan
                    FROM phieu_muon pm
                    JOIN ctphieu_muon cm ON pm.MaPhieuMuon = cm.MaPhieuMuon
                    WHERE pm.TrangThai = 3
                    GROUP BY pm.MaDocGia
                ) quaHan ON dg.MADG = quaHan.MaDocGia
                LEFT JOIN (
                    SELECT pp.MaDG, SUM(ct.TienPhat) AS TongPhiNo
                    FROM phieu_phat pp
                    JOIN ctphieu_phat ct ON pp.MaPhieuPhat = ct.MaPhieuPhat
                    WHERE pp.TrangThai = 0
                    GROUP BY pp.MaDG
                ) no ON dg.MADG = no.MaDG
                WHERE dg.TRANGTHAI = 1";

            var parameters = new Dictionary<string, object>();

            // Lọc theo trạng thái
            if (trangThai == "Đang mượn")
            {
                sql += " AND IFNULL(dangGiu.SachDangGiu, 0) > 0 AND IFNULL(quaHan.SachQuaHan, 0) = 0";
            }
            else if (trangThai == "Quá hạn")
            {
                sql += " AND IFNULL(quaHan.SachQuaHan, 0) > 0";
            }
            else if (trangThai == "Có nợ phạt")
            {
                sql += " AND IFNULL(no.TongPhiNo, 0) > 0";
            }
            else if (trangThai == "Không nợ")
            {
                sql += " AND IFNULL(no.TongPhiNo, 0) = 0 AND IFNULL(dangGiu.SachDangGiu, 0) = 0";
            }

            // Tìm kiếm theo từ khóa
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += " AND (dg.TENDG LIKE @keyword OR dg.SDT LIKE @keyword OR dg.MADG LIKE @keyword)";
                parameters.Add("@keyword", "%" + keyword + "%");
            }

            sql += " ORDER BY TongLuotMuon DESC";

            return DataProvider.ExecuteQuery(sql, parameters.Count > 0 ? parameters : null);
        }

        #endregion
    }
}
