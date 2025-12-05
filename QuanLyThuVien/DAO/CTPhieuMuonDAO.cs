using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class CTPhieuMuonDAO
    {
        public List<CTPhieuMuonDTO> GetByMaPhieuMuon(int maPhieuMuon)
        {
            List<CTPhieuMuonDTO> list = new List<CTPhieuMuonDTO>();
            string query = @"SELECT ct.MaPhieuMuon,
                                     s.MaSach,
                                     ds.MaDauSach,
                                     ds.TenDauSach,
                                     nxb.tenNXB AS NhaXuatBan,
                                     ds.NamXuatBan,
                                     ds.NgonNgu
                              FROM ctphieu_muon ct
                              JOIN sach s ON s.MaSach = ct.MaSach
                              JOIN dau_sach ds ON ds.MaDauSach = s.MaDauSach
                              JOIN nha_xuat_ban nxb ON ds.NhaXuatBan = nxb.MaNXB
                              WHERE ct.MaPhieuMuon = @MaPhieuMuon";
            var param = new Dictionary<string, object> { { "@MaPhieuMuon", maPhieuMuon } };
            DataTable dt = DataProvider.ExecuteQuery(query, param);
            foreach (DataRow row in dt.Rows)
            {
                CTPhieuMuonDTO ctpm = new CTPhieuMuonDTO
                {
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    TenDauSach = row["TenDauSach"].ToString(),
                    NhaXuatBan = row["NhaXuatBan"].ToString(),
                    NamXuatBan = row["NamXuatBan"] == DBNull.Value ? 0 : Convert.ToInt32(row["NamXuatBan"]),
                    NgonNgu = row["NgonNgu"].ToString()
                };
                list.Add(ctpm);
            }
            return list;
        }

        public bool Create(CTPhieuMuonDTO ctpm)
        {
            string query = "INSERT INTO ctphieu_muon (MaPhieuMuon, MaSach) VALUES (@MaPhieuMuon, @MaSach)";
            var parameters = new Dictionary<string, object>
            {
                {"@MaPhieuMuon", ctpm.MaPhieuMuon },
                {"@MaSach", ctpm.MaSach }
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int maPhieuMuon, int maSach)
        {
            string query = "DELETE FROM ctphieu_muon WHERE MaPhieuMuon = @MaPhieuMuon AND MaSach = @MaSach";
            var parameters = new Dictionary<string, object>
            {
                {"@MaPhieuMuon", maPhieuMuon },
                {"@MaSach", maSach }
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
