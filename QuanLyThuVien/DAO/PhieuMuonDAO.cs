using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class PhieuMuonDAO
    {
        public List<PhieuMuonDTO> GetAll()
        {
            List<PhieuMuonDTO> list = new List<PhieuMuonDTO>();
            string query = "SELECT * FROM phieu_muon";
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
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"])
                };
                list.Add(phieuMuon);
            }
            return list;
        }

        public List<PhieuMuonDTO> Search(int? maPhieu, DateTime? ngayMuonFrom, DateTime? ngayMuonTo, int? trangThai, int? maDocGia, int? maNhanVien)
        {
            var sql = "SELECT * FROM phieu_muon WHERE 1=1";
            var param = new Dictionary<string, object>();
            if (maPhieu.HasValue)
            {
                sql += " AND MaPhieuMuon = @MaPhieuMuon";
                param.Add("@MaPhieuMuon", maPhieu.Value);
            }
            if (ngayMuonFrom.HasValue)
            {
                sql += " AND NgayMuon >= @NgayMuonFrom";
                param.Add("@NgayMuonFrom", ngayMuonFrom.Value);
            }
            if (ngayMuonTo.HasValue)
            {
                sql += " AND NgayMuon <= @NgayMuonTo";
                param.Add("@NgayMuonTo", ngayMuonTo.Value);
            }
            if (trangThai.HasValue)
            {
                sql += " AND TrangThai = @TrangThai";
                param.Add("@TrangThai", trangThai.Value);
            }
            if (maDocGia.HasValue)
            {
                sql += " AND MaDocGia = @MaDocGia";
                param.Add("@MaDocGia", maDocGia.Value);
            }
            if (maNhanVien.HasValue)
            {
                sql += " AND MaNhanVien = @MaNhanVien";
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
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"])
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
            string query = "SELECT * FROM phieu_muon WHERE MaPhieuMuon = @MaPhieuMuon";
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
                MaNhanVien = Convert.ToInt32(row["MaNhanVien"])
            };
            CTPhieuMuonDAO ctpmDAO = new CTPhieuMuonDAO();
            phieuMuon.CTPM = ctpmDAO.GetByPhieuMuon(phieuMuon.MaPhieuMuon);
            return phieuMuon;
        }
    }
}
