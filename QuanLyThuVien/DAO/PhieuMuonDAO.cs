using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class PhieuMuonDAO
    {
        public List<PhieuMuonDTO> GetAll()
        {
            List<PhieuMuonDTO> list = new List<PhieuMuonDTO>();
            string query = @"SELECT pm.*, dg.TenDG, nv.TenNV
                              FROM phieu_muon pm
                              LEFT JOIN doc_gia dg ON pm.MaDocGia = dg.MaDG
                              LEFT JOIN nhan_vien nv ON pm.MaNhanVien = nv.MaNV";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                PhieuMuonDTO phieuMuon = new PhieuMuonDTO
                {
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    NgayMuon = Convert.ToDateTime(row["NgayMuon"]),
                    NgayTraDuKien = Convert.ToDateTime(row["NgayTraDuKien"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"]),
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    TenDocGia = row["TenDG"]?.ToString(),
                    TenNhanVien = row["TenNV"]?.ToString()
                };
                list.Add(phieuMuon);
            }
            return list;
        }

        public List<PhieuMuonDTO> Search(int? maPhieu, DateTime? ngayMuonFrom, DateTime? ngayMuonTo, int? trangThai, int? maDocGia, int? maNhanVien)
        {
            var sql = @"SELECT pm.*, dg.TenDG, nv.TenNV
                         FROM phieu_muon pm
                         LEFT JOIN doc_gia dg ON pm.MaDocGia = dg.MaDG
                         LEFT JOIN nhan_vien nv ON pm.MaNhanVien = nv.MaNV
                         WHERE 1=1";
            var param = new Dictionary<string, object>();
            if (maPhieu.HasValue)
            {
                sql += " AND pm.MaPhieuMuon = @MaPhieuMuon";
                param.Add("@MaPhieuMuon", maPhieu.Value);
            }
            if (ngayMuonFrom.HasValue)
            {
                sql += " AND pm.NgayMuon >= @NgayMuonFrom";
                param.Add("@NgayMuonFrom", ngayMuonFrom.Value);
            }
            if (ngayMuonTo.HasValue)
            {
                sql += " AND pm.NgayMuon <= @NgayMuonTo";
                param.Add("@NgayMuonTo", ngayMuonTo.Value);
            }
            if (trangThai.HasValue)
            {
                sql += " AND pm.TrangThai = @TrangThai";
                param.Add("@TrangThai", trangThai.Value);
            }
            if (maDocGia.HasValue)
            {
                sql += " AND pm.MaDocGia = @MaDocGia";
                param.Add("@MaDocGia", maDocGia.Value);
            }
            if (maNhanVien.HasValue)
            {
                sql += " AND pm.MaNhanVien = @MaNhanVien";
                param.Add("@MaNhanVien", maNhanVien.Value);
            }
            var dt = DataProvider.ExecuteQuery(sql, param);
            var list = new List<PhieuMuonDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PhieuMuonDTO
                {
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    NgayMuon = Convert.ToDateTime(row["NgayMuon"]),
                    NgayTraDuKien = Convert.ToDateTime(row["NgayTraDuKien"]),
                    TrangThai = Convert.ToInt32(row["TrangThai"]),
                    MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    TenDocGia = row["TenDG"]?.ToString(),
                    TenNhanVien = row["TenNV"]?.ToString()
                });
            }
            return list;
        }

        public bool Create(PhieuMuonDTO phieuMuon)
        {
            string query = "INSERT INTO phieu_muon (NgayMuon, NgayTraDuKien, TrangThai, MaDocGia, MaNhanVien) "
                         + "VALUES (@NgayMuon, @NgayTraDuKien, @TrangThai, @MaDocGia, @MaNhanVien)";
            var parameters = new Dictionary<string, object>
            {
                {"@NgayMuon", phieuMuon.NgayMuon },
                {"@NgayTraDuKien", phieuMuon.NgayTraDuKien },
                {"@TrangThai", phieuMuon.TrangThai },
                {"@MaDocGia", phieuMuon.MaDocGia },
                {"@MaNhanVien", phieuMuon.MaNhanVien}
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(PhieuMuonDTO phieuMuon)
        {
            string query = "UPDATE phieu_muon SET TrangThai=@TrangThai WHERE MaPhieuMuon=@MaPhieuMuon";
            var parameters = new Dictionary<string, object>
            {
                {"@TrangThai", phieuMuon.TrangThai},
                {"@MaPhieuMuon", phieuMuon.MaPhieuMuon}
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int maPhieuMuon)
        {
            string query = "DELETE FROM phieu_muon WHERE MaPhieuMuon = @MaPhieuMuon";
            var parameters = new Dictionary<string, object>
            {
                {"@MaPhieuMuon", maPhieuMuon}
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public PhieuMuonDTO GetById(int maPhieuMuon)
        {
            string query = @"SELECT pm.*, dg.TenDG, nv.TenNV
                              FROM phieu_muon pm
                              LEFT JOIN doc_gia dg ON pm.MaDocGia = dg.MaDG
                              LEFT JOIN nhan_vien nv ON pm.MaNhanVien = nv.MaNV
                              WHERE pm.MaPhieuMuon = @MaPhieuMuon";
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuMuon", maPhieuMuon }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            PhieuMuonDTO phieuMuon = new PhieuMuonDTO
            {
                MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                NgayMuon = Convert.ToDateTime(row["NgayMuon"]),
                NgayTraDuKien = Convert.ToDateTime(row["NgayTraDuKien"]),
                TrangThai = Convert.ToInt32(row["TrangThai"]),
                MaDocGia = Convert.ToInt32(row["MaDocGia"]),
                MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                TenDocGia = row["TenDG"]?.ToString(),
                TenNhanVien = row["TenNV"]?.ToString()
            };
            CTPhieuMuonDAO ctpmDAO = new CTPhieuMuonDAO();
            phieuMuon.CTPM = ctpmDAO.GetByMaPhieuMuon(phieuMuon.MaPhieuMuon);
            return phieuMuon;
        }

        public int GetLatestId()
        {
            string query = "SELECT MAX(MaPhieuMuon) AS LatestId FROM phieu_muon";
            DataTable dt = DataProvider.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0]["LatestId"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["LatestId"]);
            }
            return 0;
        }
    }
}
