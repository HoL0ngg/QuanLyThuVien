using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class DocGiaDAO
    {
        public List<DocGiaDTO> GetAll()
        {
            List<DocGiaDTO> list = new List<DocGiaDTO>();
            string query = "SELECT * FROM doc_gia";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                DocGiaDTO docGia = new DocGiaDTO
                {
                    MaDG = row["MaDG"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaDG"]),
                    TenDG = row["TenDG"]?.ToString(),
                    SDT = row["SDT"]?.ToString(),
                    DiaChi = row["DiaChi"]?.ToString(),
                    TrangThai = row["TrangThai"] == DBNull.Value ? 0 : Convert.ToInt32(row["TrangThai"])
                };
                list.Add(docGia);
            }
            return list;
        }

        public DocGiaDTO GetById(int maDG)
        {
            string query = "SELECT * FROM doc_gia WHERE MaDG=@MaDG";
            var parameters = new Dictionary<string, object> { { "@MaDG", maDG } };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;
            DataRow row = dt.Rows[0];
            DocGiaDTO docGia = new DocGiaDTO
            {
                MaDG = Convert.ToInt32(row["MaDG"]),
                TenDG = row["TenDG"]?.ToString(),
                SDT = row["SDT"]?.ToString(),
                DiaChi = row["DiaChi"]?.ToString(),
                TrangThai = Convert.ToInt32(row["TrangThai"])
            };
            return docGia;
        }

        public bool Create(DocGiaDTO dg)
        {
            string query = @"INSERT INTO doc_gia (TenDG, SDT, DiaChi, TrangThai)
                           VALUES (@TenDG, @SDT, @DiaChi, @TrangThai)";
            var parameters = new Dictionary<string, object>
            {
                {"@TenDG", dg.TenDG},
                {"@SDT", dg.SDT},
                {"@DiaChi", dg.DiaChi},
                {"@TrangThai", dg.TrangThai}
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(DocGiaDTO dg)
        {
            string query = @"UPDATE doc_gia
                           SET TenDG=@TenDG, SDT=@SDT, DiaChi=@DiaChi, TrangThai=@TrangThai
                           WHERE MaDG=@MaDG";
            var parameters = new Dictionary<string, object>
            {
                {"@MaDG", dg.MaDG},
                {"@TenDG", dg.TenDG},
                {"@SDT", dg.SDT},
                {"@DiaChi", dg.DiaChi},
                {"@TrangThai", dg.TrangThai}
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int maDG)
        {
            string query = "DELETE FROM doc_gia WHERE MaDG=@MaDG";
            var parameters = new Dictionary<string, object> { { "@MaDG", maDG } };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
