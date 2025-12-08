using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;


namespace QuanLyThuVien.DAO
{
    public class ThongKeDAO
    {
        private static ThongKeDAO _instance;
        public static ThongKeDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ThongKeDAO();
                return _instance;
            }
            private set { _instance = value; }
        }

        private ThongKeDAO() { }

        #region Thống kê Tổng quan (Overview)

        /// <summary>
        /// Lấy tổng lượt mượn (tất cả thời gian)
        /// </summary>
        public int GetTongLuotMuonAll()
        {
            string query = @"SELECT COUNT(*) FROM phieu_muon";
            object result = DataProvider.ExecuteScalar(query, null);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy tổng lượt mượn trong khoảng thời gian
        /// </summary>
        public int GetTongLuotMuon(DateTime from, DateTime to)
        {
            string query = @"SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date.AddDays(1).AddSeconds(-1) }
            };

            object result = DataProvider.ExecuteScalar(query, parameters);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy tổng sách trong kho
        /// </summary>
        public int GetTongSachTrongKho()
        {
            string query = "SELECT IFNULL(SUM(SoLuong), 0) FROM dau_sach WHERE TrangThai = 1";

            object result = DataProvider.ExecuteScalar(query, null);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy số lượng sách quá hạn (tất cả thời gian)
        /// </summary>
        public int GetSoSachQuaHanAll()
        {
            string query = @"
                SELECT COUNT(*)
                FROM phieu_tra pt
                JOIN phieu_muon pm ON pm.MaPhieuMuon = pt.MaPhieuMuon
                WHERE pt.NgayTra > pm.NgayTraDuKien";

            object result = DataProvider.ExecuteScalar(query, null);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }


        public ThongKeOverviewDTO GetTrendByMonth(int thang)
        {
            string sqlMuon = "SELECT COUNT(*) FROM phieu_muon WHERE MONTH(NgayMuon) = @thang";
            string sqlTra = "SELECT COUNT(*) FROM phieu_tra WHERE MONTH(NgayTra) = @thang";

            var param = new Dictionary<string, object> { { "@thang", thang } };

            int tongMuon = Convert.ToInt32(DataProvider.ExecuteScalar(sqlMuon, param));
            int tongTra = Convert.ToInt32(DataProvider.ExecuteScalar(sqlTra, param));

            return new ThongKeOverviewDTO { 
                Thang = thang,
                TongMuon = tongMuon,
                TongTra = tongTra
            };
        }

        /// <summary>
        /// LẤY TẤT CẢ 12 THÁNG TRONG 1 QUERY - TỐI ƯU HƠN!
        /// </summary>
        public List<ThongKeOverviewDTO> GetTrendAll12Months()
        {
            string query = @"
                SELECT 
                    MONTH(NgayMuon) as Thang,
                    COUNT(*) as TongMuon,
                    0 as TongTra
                FROM phieu_muon
                WHERE YEAR(NgayMuon) = YEAR(CURDATE())
                GROUP BY MONTH(NgayMuon)
                
                UNION ALL
                
                SELECT 
                    MONTH(NgayTra) as Thang,
                    0 as TongMuon,
                    COUNT(*) as TongTra
                FROM phieu_tra
                WHERE YEAR(NgayTra) = YEAR(CURDATE())
                GROUP BY MONTH(NgayTra)";

            DataTable dt = DataProvider.ExecuteQuery(query);
            
            // Khởi tạo list 12 tháng với giá trị 0
            var result = new List<ThongKeOverviewDTO>();
            for (int i = 1; i <= 12; i++)
            {
                result.Add(new ThongKeOverviewDTO { 
                    Thang = i, 
                    TongMuon = 0, 
                    TongTra = 0 
                });
            }

            // Merge dữ liệu từ query
            foreach (DataRow row in dt.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                int tongMuon = Convert.ToInt32(row["TongMuon"]);
                int tongTra = Convert.ToInt32(row["TongTra"]);
                
                var item = result[thang - 1];
                item.TongMuon += tongMuon;
                item.TongTra += tongTra;
            }

            return result;
        }

        /// <summary>
        /// TỔNG HỢP TẤT CẢ THỐNG KÊ OVERVIEW TRONG 1 QUERY DUY NHẤT - CỰC KỲ TỐI ƯU!
        /// Thay vì gọi 7 queries riêng biệt, chỉ cần 1 query
        /// </summary>
        public ThongKeOverviewDTO GetOverviewAllInOne(DateTime from, DateTime to)
        {
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to) AS TongLuotMuon,
                    (SELECT IFNULL(SUM(SoLuong), 0) FROM dau_sach WHERE TrangThai = 1) AS TongSachTrongKho,
                    (SELECT COUNT(*) FROM ctphieu_tra ct JOIN phieu_tra pt ON ct.MaPhieuTra = pt.MaPhieuTra 
                     WHERE pt.NgayTra BETWEEN @from AND @to AND ct.TrangThai IN (2, 3)) AS SachMatHong,
                    (SELECT IFNULL(SUM(ct.TienPhat), 0) FROM ctphieu_phat ct JOIN phieu_phat pp ON pp.MaPhieuPhat = ct.MaPhieuPhat 
                     WHERE pp.NgayPhat BETWEEN @from AND @to AND pp.TrangThai = 1) AS TongThuPhiPhat,
                    (SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to) AS SoPhieuMuon,
                    (SELECT COUNT(*) FROM phieu_tra WHERE NgayTra BETWEEN @from AND @to) AS SoPhieuTra,
                    (SELECT COUNT(DISTINCT MaDG) FROM phieu_phat WHERE NgayPhat BETWEEN @from AND @to) AS SoDocGiaLienQuan";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date.AddDays(1).AddSeconds(-1) }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new ThongKeOverviewDTO
                {
                    TongLuotMuon = row["TongLuotMuon"] != DBNull.Value ? Convert.ToInt32(row["TongLuotMuon"]) : 0,
                    TongSachTrongKho = row["TongSachTrongKho"] != DBNull.Value ? Convert.ToInt32(row["TongSachTrongKho"]) : 0,
                    SachMatHong = row["SachMatHong"] != DBNull.Value ? Convert.ToInt32(row["SachMatHong"]) : 0,
                    TongThuPhiPhat = row["TongThuPhiPhat"] != DBNull.Value ? Convert.ToInt32(row["TongThuPhiPhat"]) : 0,
                    SoPhieuMuon = row["SoPhieuMuon"] != DBNull.Value ? Convert.ToInt32(row["SoPhieuMuon"]) : 0,
                    SoPhieuTra = row["SoPhieuTra"] != DBNull.Value ? Convert.ToInt32(row["SoPhieuTra"]) : 0,
                    SoDocGiaLienQuan = row["SoDocGiaLienQuan"] != DBNull.Value ? Convert.ToInt32(row["SoDocGiaLienQuan"]) : 0
                };
            }

            return new ThongKeOverviewDTO();
        }

        public  List<ThongKeOverviewDTO> GetTop5SachMuon()
        {
            string query = @"
        SELECT ds.TenDauSach, COUNT(*) AS SoLanMuon
        FROM ctphieu_muon ct
        JOIN sach s ON ct.MaSach = s.MaSach
        JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
        GROUP BY ds.MaDauSach, ds.TenDauSach
        ORDER BY SoLanMuon DESC
        LIMIT 5;
    ";

            DataTable data = DataProvider.ExecuteQuery(query);

            var list = new List<ThongKeOverviewDTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new ThongKeOverviewDTO
                {
                    TenDauSach = row["TenDauSach"].ToString(),
                    SoLanMuon = Convert.ToInt32(row["SoLanMuon"])
                });
            }

            return list;
        }
        public List<ThongKeOverviewDTO> GetTop5TheLoai()
        {
            string query = @"
        SELECT tl.TenTheLoai,
       COUNT(*) AS SoLanMuon
FROM ctphieu_muon ct
JOIN sach s ON ct.MaSach = s.MaSach
JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
JOIN the_loai tlmap ON ds.MaDauSach = tlmap.MaDauSach
JOIN ctthe_loai tl ON tlmap.MaTheLoai = tl.MaTheLoai
GROUP BY tl.MaTheLoai, tl.TenTheLoai
ORDER BY SoLanMuon DESC
LIMIT 5;
    ";

            DataTable data = DataProvider.ExecuteQuery(query);

            var list = new List<ThongKeOverviewDTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new ThongKeOverviewDTO
                {
                    TenTheLoai = row["TenTheLoai"].ToString(),
                    SoLanMuon = Convert.ToInt32(row["SoLanMuon"])
                });
            }

            return list;
        }


        public int GetSoSachHongMat()
        {
            string query = "SELECT COUNT(*) FROM ctphieu_tra WHERE TrangThai IN (2,3)";
            object result = DataProvider.ExecuteScalar(query);

            if (result == DBNull.Value || result == null)
                return 0;

            return Convert.ToInt32(result);
        }


        public int GetTongDauSach()
        {
            string query = "SELECT COUNT(*) FROM dau_sach WHERE TrangThai = 1";
            // nếu muốn chỉ tính đầu sách đang hoạt động

            object result = DataProvider.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }
        public int GetTongBanSach()
        {
            string query = "SELECT SUM(SoLuong) FROM dau_sach WHERE TrangThai = 1";
            object result = DataProvider.ExecuteScalar(query);
            return Convert.ToInt32(result);

        }
        public int GetSachSanSangChoMuon()
        {
            // 1. Tổng số sách (dựa trên SoLuong của dau_sach)
            string sqlTong = "SELECT SUM(SoLuong) FROM dau_sach WHERE TrangThai = 1";
            int tongSach = Convert.ToInt32(DataProvider.ExecuteScalar(sqlTong));

            // 2. Sách đang mượn chưa trả (phiếu mượn trạng thái = 1)
            string sqlDangMuon = @"
            SELECT COUNT(*) 
            FROM ctphieu_muon ct
            JOIN phieu_muon pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
            WHERE pm.trangthai = 1";
            int sachDangMuon = Convert.ToInt32(DataProvider.ExecuteScalar(sqlDangMuon));

            // 3. Sách hỏng/mất (trangthai = 2 hoặc 3 trong ctphieu_tra)
            string sqlHongMat = "SELECT COUNT(*) FROM ctphieu_tra WHERE TrangThai IN (2,3)";
            int sachHongMat = Convert.ToInt32(DataProvider.ExecuteScalar(sqlHongMat));

            // 4. Tính số sách sẵn sàng cho mượn
            int sachSanSang = tongSach - sachDangMuon - sachHongMat;

            return sachSanSang;
        }


        /// <summary>
        /// Lấy số lượng sách quá hạn trong khoảng thời gian
        /// </summary>
        public int GetSoSachMatHong(DateTime from, DateTime to)
        {
            // Sửa lại query: JOIN giữa ctphieu_tra và phieu_tra
            // Điều kiện: TrangThai là 2 hoặc 3 VÀ nằm trong khoảng thời gian
            string query = @"
        SELECT COUNT(*)
        FROM ctphieu_tra ct
        JOIN phieu_tra pt ON ct.MaPhieuTra = pt.MaPhieuTra
        WHERE pt.NgayTra BETWEEN @from AND @to
          AND ct.TrangThai IN (2, 3)";

            var parameters = new Dictionary<string, object>
    {
        { "@from", from.Date },
        // Lấy đến cuối ngày của ngày 'to' (23:59:59)
        { "@to", to.Date.AddDays(1).AddSeconds(-1) }
    };

            object result = DataProvider.ExecuteScalar(query, parameters);

            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy tổng thu phí phạt (tất cả thời gian)
        /// </summary>
        public int GetTongThuPhiPhatAll()
        {
            string query = @"
                SELECT IFNULL(SUM(ct.TienPhat), 0)
                FROM ctphieu_phat ct
                JOIN phieu_phat pp ON pp.MaPhieuPhat = ct.MaPhieuPhat
                WHERE pp.TrangThai = 1";

            object result = DataProvider.ExecuteScalar(query, null);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy tổng thu phí phạt trong khoảng thời gian
        /// </summary>
        public int GetTongThuPhiPhat(DateTime from, DateTime to)
        {
            string query = @"
                SELECT IFNULL(SUM(ct.TienPhat), 0)
                FROM ctphieu_phat ct
                JOIN phieu_phat pp ON pp.MaPhieuPhat = ct.MaPhieuPhat
                WHERE pp.NgayPhat BETWEEN @from AND @to AND pp.TrangThai = 1";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date.AddDays(1).AddSeconds(-1) }
            };

            object result = DataProvider.ExecuteScalar(query, parameters);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy số phiếu mượn (tất cả thời gian)
        /// </summary>
        public int GetSoPhieuMuonAll()
        {
            string query = "SELECT COUNT(*) FROM phieu_muon";
            object result = DataProvider.ExecuteScalar(query, null);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy số phiếu mượn trong khoảng thời gian
        /// </summary>
        public int GetSoPhieuMuon(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM phieu_muon WHERE NgayMuon BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date.AddDays(1).AddSeconds(-1) }
            };

            object result = DataProvider.ExecuteScalar(query, parameters);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        public  List<ThongKeSachDTO> GetSoLuongSachTheoTheLoai()
        {
            string query = @"
            SELECT tl.TenTheLoai, SUM(ds.SoLuong) AS SoLuongSach
            FROM dau_sach ds
            JOIN the_loai tlmap ON ds.MaDauSach = tlmap.MaDauSach
            JOIN ctthe_loai tl ON tlmap.MaTheLoai = tl.MaTheLoai
            WHERE ds.TrangThai = 1
            GROUP BY tl.MaTheLoai, tl.TenTheLoai
            ORDER BY SoLuongSach DESC;
        ";

            DataTable data = DataProvider.ExecuteQuery(query);

            List<ThongKeSachDTO> list = new List<ThongKeSachDTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new ThongKeSachDTO
                {
                    TheLoai = row["TenTheLoai"].ToString(),
                    TongSoBan = Convert.ToInt32(row["SoLuongSach"])
                });
            }

            return list;
        }
        public List<ThongKeSachDTO> GetSoLuongSachTheoNam()
        {
            string query = @"
            SELECT NamXuatBan, SUM(SoLuong) AS SoLuongSach
            FROM dau_sach
            WHERE TrangThai = 1
            GROUP BY NamXuatBan
            ORDER BY NamXuatBan DESC;
        ";

            DataTable data = DataProvider.ExecuteQuery(query);

            List<ThongKeSachDTO> list = new List<ThongKeSachDTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new ThongKeSachDTO
                {
                    NamXuatBan = row["NamXuatBan"].ToString(),
                    TongSoBan = Convert.ToInt32(row["SoLuongSach"])
                });
            }

            return list;
        }
        public List<ThongKeSachDTO> GetChiTietSach()
        {
            string query = @"
            SELECT 
                ds.TenDauSach,
                GROUP_CONCAT(ctl.TenTheLoai ORDER BY ctl.TenTheLoai SEPARATOR ', ') AS TenTheLoai,
                ds.SoLuong AS TongSoLuong,
                (
                    SELECT COUNT(*) 
                    FROM ctphieu_tra ct
                    WHERE ct.MaSach = ds.MaDauSach AND ct.TrangThai IN (2, 3)
                ) AS SoLuongHongMat,
                CASE WHEN ds.TrangThai = 1 THEN 'Còn sử dụng' ELSE 'Không còn sử dụng' END AS TrangThai,
                (ds.Gia * ds.SoLuong) AS GiaTriUocTinh
            FROM dau_sach ds
            JOIN the_loai tl ON ds.MaDauSach = tl.MaDauSach
            JOIN ctthe_loai ctl ON tl.MaTheLoai = ctl.MaTheLoai
            GROUP BY ds.MaDauSach, ds.TenDauSach, ds.SoLuong, ds.TrangThai, ds.Gia
            ORDER BY ds.TenDauSach ASC;
        ";

            DataTable data = DataProvider.ExecuteQuery(query);

            List<ThongKeSachDTO> list = new List<ThongKeSachDTO>();
            foreach (DataRow row in data.Rows)
            {
                string giaTriStr = row["GiaTriUocTinh"].ToString().Replace(",", "").Replace("đ", "").Trim();
                decimal giaTri = 0;
                decimal.TryParse(giaTriStr, out giaTri);


                list.Add(new ThongKeSachDTO
                {
                    TenSach = row["TenDauSach"].ToString(),
                    TheLoai = row["TenTheLoai"].ToString(),
                    TongSoBan = Convert.ToInt32(row["TongSoLuong"]),
                    SachHong= Convert.ToInt32(row["SoLuongHongMat"]),
                    TinhTrang = row["TrangThai"].ToString(),
                    GiaTriUocTinh = Convert.ToDecimal(row["GiaTriUocTinh"])
                });
            }

            return list;
        }
        public ThongKePhieuPhatDTO GetThongKePhieuPhat()
        {
            string query = @"
            SELECT 
                COUNT(DISTINCT pp.MaPhieuPhat) AS TongSoPhieuPhat,
                SUM(ct.TienPhat) AS TongTienPhat,
                SUM(CASE WHEN pp.TrangThai = 1 THEN ct.TienPhat ELSE 0 END) AS TongTienDaThu,
                SUM(CASE WHEN pp.TrangThai = 0 THEN ct.TienPhat ELSE 0 END) AS TongTienChuaThu
            FROM phieu_phat pp
            JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat;
        ";

            DataTable data = DataProvider.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new ThongKePhieuPhatDTO
                {
                    TongSoPhieuPhat = row["TongSoPhieuPhat"] == DBNull.Value ? 0 : Convert.ToInt32(row["TongSoPhieuPhat"]),
                    TongTienPhat = row["TongTienPhat"] == DBNull.Value ? 0 : Convert.ToInt32(row["TongTienPhat"]),
                    TongTienDaThu = row["TongTienDaThu"] == DBNull.Value ? 0 : Convert.ToInt32(row["TongTienDaThu"]),
                    TongTienChuaThu = row["TongTienChuaThu"] == DBNull.Value ? 0 : Convert.ToInt32(row["TongTienChuaThu"])
                };
            }

            return new ThongKePhieuPhatDTO();
        }



        /// <summary>
        /// Lấy số phiếu trả (tất cả thời gian)
        /// </summary>
        public int GetSoPhieuTraAll()
        {
            string query = "SELECT COUNT(*) FROM phieu_tra";
            object result = DataProvider.ExecuteScalar(query, null);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy số phiếu trả trong khoảng thời gian
        /// </summary>
        public int GetSoPhieuTra(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM phieu_tra WHERE NgayTra BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date.AddDays(1).AddSeconds(-1) }
            };

            object result = DataProvider.ExecuteScalar(query, parameters);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy số độc giả liên quan (tất cả thời gian)
        /// </summary>
        public int GetSoDocGiaLienQuanAll()
        {
            string query = @"SELECT COUNT(DISTINCT MaDG) FROM phieu_phat";
            object result = DataProvider.ExecuteScalar(query, null);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy số độc giả liên quan trong khoảng thời gian
        /// </summary>
        public int GetSoDocGiaLienQuan(DateTime from, DateTime to)
        {
            string query = @"
                SELECT COUNT(DISTINCT MaDG)
                FROM phieu_phat
                WHERE NgayPhat BETWEEN @from AND @to";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date.AddDays(1).AddSeconds(-1) }
            };

            object result = DataProvider.ExecuteScalar(query, parameters);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lấy xu hướng mượn/trả tất cả (group theo tháng)
        /// </summary>
        public DataTable GetPhieuMuonTrendAll()
        {
            string query = @"
                SELECT 
                    dates.Ngay,
                    IFNULL(borrow.SoMuon, 0) AS SoMuon,
                    IFNULL(ret.SoTra, 0) AS SoTra
                FROM (
                    SELECT DISTINCT DATE_FORMAT(NgayMuon, '%Y-%m-01') AS Ngay FROM phieu_muon 
                    UNION
                    SELECT DISTINCT DATE_FORMAT(NgayTra, '%Y-%m-01') AS Ngay FROM phieu_tra 
                ) dates
                LEFT JOIN (
                    SELECT DATE_FORMAT(NgayMuon, '%Y-%m-01') AS Ngay, COUNT(*) AS SoMuon 
                    FROM phieu_muon 
                    GROUP BY DATE_FORMAT(NgayMuon, '%Y-%m-01')
                ) borrow ON dates.Ngay = borrow.Ngay
                LEFT JOIN (
                    SELECT DATE_FORMAT(NgayTra, '%Y-%m-01') AS Ngay, COUNT(*) AS SoTra 
                    FROM phieu_tra 
                    GROUP BY DATE_FORMAT(NgayTra, '%Y-%m-01')
                ) ret ON dates.Ngay = ret.Ngay
                ORDER BY dates.Ngay DESC
                LIMIT 12";

            return DataProvider.ExecuteQuery(query, null);
        }

        #endregion

        #region Thống kê Phiếu Mượn

        /// <summary>
        /// Lấy danh sách phiếu mượn với chi tiết số lượng sách mượn
        /// </summary>
        public DataTable GetAllPhieuMuonWithDetails()
        {
            string query = @"
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

            return DataProvider.ExecuteQuery(query, null);
        }

        /// <summary>
        /// Lấy xu hướng mượn/trả theo ngày trong khoảng thời gian
        /// </summary>
        public DataTable GetPhieuMuonTrend(DateTime from, DateTime to)
        {
            string query = @"
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

            return DataProvider.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Lấy tỷ lệ trả đúng hạn/trễ hạn trong khoảng thời gian
        /// </summary>
        public DataTable GetTyLeTra(DateTime from, DateTime to)
        {
            string query = @"
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

            return DataProvider.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Lấy KPI thống kê phiếu mượn
        /// </summary>
        public DataRow GetPhieuMuonKPIs(DateTime from, DateTime to)
        {
            string query = @"
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

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        #endregion

        #region Thống kê Độc Giả

        /// <summary>
        /// Lấy KPI thống kê độc giả
        /// </summary>
        public DataRow GetDocGiaKPIs()
        {
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM doc_gia WHERE TRANGTHAI = 1) AS TongDocGia,
                    (SELECT COUNT(*) FROM doc_gia WHERE TRANGTHAI = 1 
                        AND MADG IN (SELECT DISTINCT MaDocGia FROM phieu_muon WHERE NgayMuon >= DATE_SUB(CURDATE(), INTERVAL 30 DAY))) AS DocGiaMoi,
                    (SELECT COUNT(DISTINCT MaDocGia) FROM phieu_muon WHERE TrangThai IN (1, 3)) AS DocGiaHoatDong,
                    (SELECT COUNT(DISTINCT MaDG) FROM phieu_phat WHERE TrangThai = 0) AS DocGiaNoTien";

            DataTable dt = DataProvider.ExecuteQuery(query, null);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        /// <summary>
        /// Lấy cơ cấu hoạt động độc giả (đang mượn, đã trả, quá hạn)
        /// </summary>
        public DataTable GetCoCauHoatDongDocGia()
        {
            string query = @"
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

            return DataProvider.ExecuteQuery(query, null);
        }

        /// <summary>
        /// Lấy top 5 độc giả mượn nhiều nhất
        /// </summary>
        public DataTable GetTop5DocGiaMuonNhieu()
        {
            string query = @"
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

            return DataProvider.ExecuteQuery(query, null);
        }

        /// <summary>
        /// Lấy danh sách chi tiết độc giả với thống kê
        /// </summary>
        public DataTable GetChiTietDocGia(string trangThai, string keyword)
        {
            string query = @"
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
                query += " AND IFNULL(dangGiu.SachDangGiu, 0) > 0 AND IFNULL(quaHan.SachQuaHan, 0) = 0";
            }
            else if (trangThai == "Quá hạn")
            {
                query += " AND IFNULL(quaHan.SachQuaHan, 0) > 0";
            }
            else if (trangThai == "Có nợ phạt")
            {
                query += " AND IFNULL(no.TongPhiNo, 0) > 0";
            }
            else if (trangThai == "Không nợ")
            {
                query += " AND IFNULL(no.TongPhiNo, 0) = 0 AND IFNULL(dangGiu.SachDangGiu, 0) = 0";
            }

            // Tìm kiếm theo từ khóa
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query += " AND (dg.TENDG LIKE @keyword OR dg.SDT LIKE @keyword OR dg.MADG LIKE @keyword)";
                parameters.Add("@keyword", "%" + keyword + "%");
            }

            query += " ORDER BY TongLuotMuon DESC";

            return DataProvider.ExecuteQuery(query, parameters.Count > 0 ? parameters : null);
        }

        #endregion

        #region Thống kê Sách

        /// <summary>
        /// Lấy KPI thống kê sách
        /// </summary>
        public DataRow GetSachKPIs()
        {
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM dau_sach WHERE TrangThai = 1) AS TongDauSach,
                    (SELECT IFNULL(SUM(SoLuong), 0) FROM dau_sach WHERE TrangThai = 1) AS TongBanSach,
                    (SELECT IFNULL(SUM(SoLuong), 0) FROM dau_sach WHERE TrangThai = 1) - 
                        (SELECT COUNT(*) FROM ctphieu_muon cm 
                         JOIN phieu_muon pm ON cm.MaPhieuMuon = pm.MaPhieuMuon 
                         WHERE pm.TrangThai IN (1, 3)) AS SachCoSan,
                    (SELECT COUNT(*) FROM dau_sach WHERE TrangThai = 0) AS SachBaoTri";

            DataTable dt = DataProvider.ExecuteQuery(query, null);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        /// <summary>
        /// Lấy thống kê theo thể loại
        /// </summary>
        public DataTable GetThongKeTheoTheLoai()
        {
            string query = @"
                SELECT 
                    tl.TenTheLoai AS TheLoai,
                    COUNT(ds.MaDauSach) AS SoLuong
                FROM the_loai tl
                LEFT JOIN theloai_dausach tlds ON tl.MaTheLoai = tlds.MaTheLoai
                LEFT JOIN dau_sach ds ON tlds.MaDauSach = ds.MaDauSach AND ds.TrangThai = 1
                GROUP BY tl.MaTheLoai, tl.TenTheLoai
                ORDER BY SoLuong DESC
                LIMIT 10";

            return DataProvider.ExecuteQuery(query, null);
        }

        /// <summary>
        /// Lấy thống kê theo năm xuất bản
        /// </summary>
        public DataTable GetThongKeTheoNamXuatBan()
        {
            string query = @"
                SELECT 
                    NamXuatBan,
                    COUNT(*) AS SoLuong
                FROM dau_sach
                WHERE TrangThai = 1
                GROUP BY NamXuatBan
                ORDER BY NamXuatBan DESC
                LIMIT 5";

            return DataProvider.ExecuteQuery(query, null);
        }

        /// <summary>
        /// Lấy top 5 sách được mượn nhiều nhất
        /// </summary>
        public DataTable GetTop5SachMuonNhieu()
        {
            string query = @"
                SELECT 
                    ds.TenDauSach AS TenSach,
                    COUNT(cm.MaSach) AS SoLuotMuon
                FROM dau_sach ds
                JOIN sach s ON ds.MaDauSach = s.MaDauSach
                JOIN ctphieu_muon cm ON s.MaSach = cm.MaSach
                WHERE ds.TrangThai = 1
                GROUP BY ds.MaDauSach, ds.TenDauSach
                ORDER BY SoLuotMuon DESC
                LIMIT 5";

            return DataProvider.ExecuteQuery(query, null);
        }

        #endregion

        #region Thống kê Phiếu Phạt

        /// <summary>
        /// Lấy KPI thống kê phiếu phạt
        /// </summary>
        public DataRow GetPhieuPhatKPIs(DateTime from, DateTime to)
        {
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM phieu_phat WHERE NgayPhat BETWEEN @from AND @to) AS TongPhieu,
                    (SELECT IFNULL(SUM(ct.TienPhat), 0) FROM ctphieu_phat ct 
                     JOIN phieu_phat pp ON ct.MaPhieuPhat = pp.MaPhieuPhat 
                     WHERE pp.NgayPhat BETWEEN @from AND @to) AS TongPhiPhat,
                    (SELECT IFNULL(SUM(ct.TienPhat), 0) FROM ctphieu_phat ct 
                     JOIN phieu_phat pp ON ct.MaPhieuPhat = pp.MaPhieuPhat 
                     WHERE pp.NgayPhat BETWEEN @from AND @to AND pp.TrangThai = 1) AS DaThu,
                    (SELECT IFNULL(SUM(ct.TienPhat), 0) FROM ctphieu_phat ct 
                     JOIN phieu_phat pp ON ct.MaPhieuPhat = pp.MaPhieuPhat 
                     WHERE pp.NgayPhat BETWEEN @from AND @to AND pp.TrangThai = 0) AS ChuaThu";

            var parameters = new Dictionary<string, object>
            {
                { "@from", from.Date },
                { "@to", to.Date }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        #endregion
    }
}
