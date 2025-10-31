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
        public List<CTPhieuMuonDTO> GetByPhieuMuon(int maPhieuMuon)
        {
            List<CTPhieuMuonDTO> list = new List<CTPhieuMuonDTO>();
            string query = "SELECT * FROM ctphieu_muon WHERE MaPhieuMuon = @MaPhieuMuon";
            var param = new Dictionary<string, object> { { "@MaPhieuMuon", maPhieuMuon } };
            DataTable dt = DataProvider.ExecuteQuery(query, param);
            foreach (DataRow row in dt.Rows)
            {
                CTPhieuMuonDTO ctpm = new CTPhieuMuonDTO
                {
                    MaPhieuMuon = Convert.ToInt32(row["MaPhieuMuon"]),
                    MaSach = Convert.ToInt32(row["MaSach"])
                };
                list.Add(ctpm);
            }
            return list;
        }
    }
}
