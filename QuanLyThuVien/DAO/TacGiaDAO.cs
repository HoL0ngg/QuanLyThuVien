using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class TacGiaDAO
    {
        private static TacGiaDAO _instance;
        public static TacGiaDAO Instance => _instance ?? (_instance = new TacGiaDAO());
        private TacGiaDAO() { }

        public DataTable GetAllTacGia()
        {
            // Return all columns for tac_gia
            string query = "SELECT MaTacGia, TenTacGia, NamSinh, QuocTich FROM tac_gia ORDER BY TenTacGia";
            return DataProvider.ExecuteQuery(query);
        }

        public bool Create(DTO.TacGiaDTO tg)
        {
            if (tg == null) return false;
            string query = "INSERT INTO tac_gia (TenTacGia, NamSinh, QuocTich) VALUES (@TenTacGia, @NamSinh, @QuocTich)";
            var parameters = new Dictionary<string, object>
            {
                { "@TenTacGia", tg.tenTacGia ?? string.Empty },
                { "@NamSinh", string.IsNullOrWhiteSpace(tg.namSinh) ? (object)DBNull.Value : tg.namSinh },
                { "@QuocTich", tg.quocTich ?? string.Empty }
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public DTO.TacGiaDTO GetById(int maTacGia)
        {
            string query = "SELECT MaTacGia, TenTacGia, NamSinh, QuocTich FROM tac_gia WHERE MaTacGia = @MaTacGia";
            var parameters = new Dictionary<string, object> { { "@MaTacGia", maTacGia } };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt == null || dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new DTO.TacGiaDTO
            {
                maTacGia = Convert.ToInt32(row["MaTacGia"]),
                tenTacGia = row["TenTacGia"]?.ToString(),
                namSinh = row["NamSinh"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["NamSinh"]).ToString("yyyy-MM-dd"),
                quocTich = row["QuocTich"]?.ToString()
            };
        }
    }
}
