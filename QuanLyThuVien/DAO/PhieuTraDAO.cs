using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class PhieuTraDAO
    {
        private static PhieuTraDAO instance;

        public static PhieuTraDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuTraDAO();
                return instance;
            }
        }

        private PhieuTraDAO() { }

        // L?y t?t c? phi?u tr?
        public List<PhieuTraDTO> GetAll()
        {
            List<PhieuTraDTO> list = new List<PhieuTraDTO>();
            string query = @"
                SELECT 
                    pt.MaPhieuTra,
                    pt.NgayTra,
                    pt.MaNV,
                    pt.MaPhieuMuon,
                    nv.TENNV,
                    dg.TENDG
                FROM phieu_tra pt
                LEFT JOIN nhan_vien nv ON pt.MaNV = nv.MANV
                LEFT JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                LEFT JOIN doc_gia dg ON pm.MaDocGia = dg.MADG
                ORDER BY pt.MaPhieuTra DESC";

            DataTable dt = DataProvider.ExecuteQuery(query);
            
            foreach (DataRow row in dt.Rows)
            {
                PhieuTraDTO pt = new PhieuTraDTO
                {
                    MaPhieuTra = Convert.ToInt32(row["MaPhieuTra"]),
                    NgayTra = Convert.ToDateTime(row["NgayTra"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    MaDG = row["MaPhieuMuon"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaPhieuMuon"])
                };
                list.Add(pt);
            }
            return list;
        }

        // L?y phi?u tr? theo ID
        public PhieuTraDTO GetById(int maPhieuTra)
        {
            string query = @"
                SELECT 
                    pt.MaPhieuTra,
                    pt.NgayTra,
                    pt.MaNV,
                    pt.MaPhieuMuon,
                    nv.TENNV,
                    pm.MaDocGia
                FROM phieu_tra pt
                LEFT JOIN nhan_vien nv ON pt.MaNV = nv.MANV
                LEFT JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                WHERE pt.MaPhieuTra = @MaPhieuTra";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuTra", maPhieuTra }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count == 0)
                return null;

            DataRow r = dt.Rows[0];
            PhieuTraDTO phieuTra = new PhieuTraDTO
            {
                MaPhieuTra = Convert.ToInt32(r["MaPhieuTra"]),
                NgayTra = Convert.ToDateTime(r["NgayTra"]),
                MaNV = Convert.ToInt32(r["MaNV"]),
                MaDG = r["MaDocGia"] == DBNull.Value ? 0 : Convert.ToInt32(r["MaDocGia"])
            };

            // L?y chi ti?t
            phieuTra.list = GetChiTietByMaPhieuTra(maPhieuTra);

            return phieuTra;
        }

        // L?y chi ti?t phi?u tr?
        public List<CTPhieuTraDTO> GetChiTietByMaPhieuTra(int maPhieuTra)
        {
            string query = @"
                SELECT 
                    ct.MaCTPhieuTra,
                    ct.MaPhieuTra,
                    ct.MaSach,
                    ct.TrangThai,
                    ds.TenDauSach AS TenSach
                FROM ctphieu_tra ct
                LEFT JOIN sach s ON ct.MaSach = s.MaSach
                LEFT JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                WHERE ct.MaPhieuTra = @MaPhieuTra
                ORDER BY ct.MaCTPhieuTra";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuTra", maPhieuTra }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            List<CTPhieuTraDTO> list = new List<CTPhieuTraDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new CTPhieuTraDTO
                {
                    MaCTPhieuTra = Convert.ToInt32(r["MaCTPhieuTra"]),
                    MaPhieuTra = Convert.ToInt32(r["MaPhieuTra"]),
                    MaSach = Convert.ToInt32(r["MaSach"]),
                    TenSach = r["TenSach"]?.ToString()
                });
            }
            return list;
        }

        // Thêm phi?u tr? m?i
        public int Insert(PhieuTraDTO pt)
        {
            string query = @"
                INSERT INTO phieu_tra (NgayTra, MaNV, MaPhieuMuon)
                VALUES (@NgayTra, @MaNV, @MaPhieuMuon);
                SELECT LAST_INSERT_ID();";

            var parameters = new Dictionary<string, object>
            {
                { "@NgayTra", pt.NgayTra },
                { "@MaNV", pt.MaNV },
                { "@MaPhieuMuon", pt.MaDG }
            };

            object result = DataProvider.ExecuteScalar(query, parameters);
            
            if (result != null && int.TryParse(result.ToString(), out int maPhieuTra))
            {
                return maPhieuTra;
            }
            return 0;
        }

        // Thêm chi ti?t phi?u tr?
        public bool InsertChiTiet(CTPhieuTraDTO ct)
        {
            string query = @"
                INSERT INTO ctphieu_tra (MaPhieuTra, MaSach, TrangThai)
                VALUES (@MaPhieuTra, @MaSach, @TrangThai)";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuTra", ct.MaPhieuTra },
                { "@MaSach", ct.MaSach },
                { "@TrangThai", 1 }
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        // C?p nh?t phi?u tr?
        public bool Update(PhieuTraDTO pt)
        {
            string query = @"
                UPDATE phieu_tra 
                SET NgayTra = @NgayTra,
                    MaNV = @MaNV,
                    MaPhieuMuon = @MaPhieuMuon
                WHERE MaPhieuTra = @MaPhieuTra";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuTra", pt.MaPhieuTra },
                { "@NgayTra", pt.NgayTra },
                { "@MaNV", pt.MaNV },
                { "@MaPhieuMuon", pt.MaDG }
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa phi?u tr?
        public bool Delete(int maPhieuTra)
        {
            // Xóa chi ti?t tr??c
            string sqlDeleteCT = "DELETE FROM ctphieu_tra WHERE MaPhieuTra = @MaPhieuTra";
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuTra", maPhieuTra }
            };
            DataProvider.ExecuteNonQuery(sqlDeleteCT, parameters);

            // Xóa phi?u tr?
            string sql = "DELETE FROM phieu_tra WHERE MaPhieuTra = @MaPhieuTra";
            return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
        }

        // L?y sách ?ang m??n c?a ??c gi? t? phi?u m??n
        public List<CTPhieuTraDTO> GetSachDangMuonByPhieuMuon(int maPhieuMuon)
        {
            string query = @"
                SELECT 
                    ct.MaSach,
                    ds.TenDauSach AS TenSach,
                    pm.NgayMuon,
                    pm.NgayTraDuKien
                FROM ctphieu_muon ct
                JOIN sach s ON ct.MaSach = s.MaSach
                JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                JOIN phieu_muon pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                WHERE ct.MaPhieuMuon = @MaPhieuMuon
                ORDER BY ct.MaSach";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuMuon", maPhieuMuon }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            List<CTPhieuTraDTO> list = new List<CTPhieuTraDTO>();

            foreach (DataRow r in dt.Rows)
            {
                DateTime ngayMuon = Convert.ToDateTime(r["NgayMuon"]);
                DateTime ngayTraDuKien = Convert.ToDateTime(r["NgayTraDuKien"]);
                DateTime ngayTraThucTe = DateTime.Now;
                
                int soNgayTre = (ngayTraThucTe - ngayTraDuKien).Days;
                if (soNgayTre < 0) soNgayTre = 0;

                decimal tienPhat = soNgayTre * 5000; // 5000 VN?/ngày tr?

                list.Add(new CTPhieuTraDTO
                {
                    MaSach = Convert.ToInt32(r["MaSach"]),
                    TenSach = r["TenSach"]?.ToString(),
                    NgayMuon = ngayMuon,
                    NgayTraThucTe = ngayTraThucTe,
                    SoNgayTre = soNgayTre,
                    TienPhat = tienPhat
                });
            }
            return list;
        }

        // L?y danh sách phi?u m??n ch?a tr?
        public DataTable GetPhieuMuonChuaTra()
        {
            string query = @"
                SELECT 
                    pm.MaPhieuMuon,
                    pm.NgayMuon,
                    pm.NgayTraDuKien,
                    dg.TENDG AS TenDocGia,
                    COUNT(ct.MaSach) AS SoSach
                FROM phieu_muon pm
                JOIN doc_gia dg ON pm.MaDocGia = dg.MADG
                LEFT JOIN ctphieu_muon ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
                WHERE pm.trangthai = 1
                  AND NOT EXISTS (
                      SELECT 1 FROM phieu_tra pt 
                      WHERE pt.MaPhieuMuon = pm.MaPhieuMuon
                  )
                GROUP BY pm.MaPhieuMuon, pm.NgayMuon, pm.NgayTraDuKien, dg.TENDG
                ORDER BY pm.MaPhieuMuon DESC";

            return DataProvider.ExecuteQuery(query);
        }

        // C?p nh?t tr?ng thái sách v? s?n sàng sau khi tr?
        public void UpdateTrangThaiSachDaTra(int maSach)
        {
            string query = "UPDATE sach SET trangthai = 0 WHERE MaSach = @MaSach";
            var parameters = new Dictionary<string, object>
            {
                { "@MaSach", maSach }
            };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        // C?p nh?t tr?ng thái phi?u m??n ?ã tr?
        public void UpdateTrangThaiPhieuMuon(int maPhieuMuon)
        {
            string query = "UPDATE phieu_muon SET trangthai = 2 WHERE MaPhieuMuon = @MaPhieuMuon";
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuMuon", maPhieuMuon }
            };
            DataProvider.ExecuteNonQuery(query, parameters);
        }
    }
}
