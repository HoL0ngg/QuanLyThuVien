using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.DTO;
using System.Data;
namespace QuanLyThuVien.DAO
{
    internal class PhieuPhatDAO
    {
        private static PhieuPhatDAO instance;
        public static PhieuPhatDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuPhatDAO();
                return instance;
            }

        }
        private PhieuPhatDAO() { }

        public List<PhieuPhatDTO> GetAll()
        {
            const string sql = @"
                SELECT
                    pp.MaPhieuPhat,
                    pp.NgayPhat,
                    pp.TrangThai,
                    ct.MaCTPhieuPhat,
                    pp.Ngaytra AS NgayTra,
                    ct.TienPhat,
                    ds.TenDauSach AS TenSach,
                    dg.TenDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN sach s           ON s.MaSach       = ct.MaSach
                JOIN dau_sach ds      ON ds.MaDauSach   = s.MaDauSach
                JOIN doc_gia dg       ON pp.MaDG = dg.MaDG
                ORDER BY pp.MaPhieuPhat DESC, ct.MaCTPhieuPhat DESC;";

            DataTable dt = DataProvider.ExecuteQuery(sql);
            var list = new List<PhieuPhatDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new PhieuPhatDTO
                {
                    MaPhieuPhat = Convert.ToInt32(r["MaPhieuPhat"]),
                    NgayPhat = Convert.ToDateTime(r["NgayPhat"]),
                    TrangThai = Convert.ToInt32(r["TrangThai"]),
                    MaCTPhieuPhat = Convert.ToInt32(r["MaCTPhieuPhat"]),
                    NgayTra = r["NgayTra"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayTra"]),
                    tienPhat = Convert.ToInt32(r["TienPhat"]),
                    TenSach = r["TenSach"]?.ToString(),
                    TenDG = r["TenDG"]?.ToString(),
                });
            }
            return list;
        }
        public List<PhieuPhatDTO> GetByTrangThai(int trangThai)
        {
            const string sql = @"
        SELECT
                    pp.MaPhieuPhat,
                    pp.NgayPhat,
                    pp.TrangThai,
                    ct.MaCTPhieuPhat,
                    pp.Ngaytra AS NgayTra,
                    ct.TienPhat,
                    ds.TenDauSach AS TenSach,
                    dg.TenDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN sach s           ON s.MaSach       = ct.MaSach
                JOIN dau_sach ds      ON ds.MaDauSach   = s.MaDauSach
                JOIN doc_gia dg       ON pp.MaDG = dg.MaDG
        WHERE @TrangThai IS NULL OR pp.TrangThai = @TrangThai
        ORDER BY pp.MaPhieuPhat DESC, ct.MaCTPhieuPhat DESC;";

            var parameters = new Dictionary<string, object>
    {
        { "@TrangThai", trangThai }
    };

            DataTable dt = DataProvider.ExecuteQuery(sql, parameters);
            var list = new List<PhieuPhatDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new PhieuPhatDTO
                {
                    MaPhieuPhat = Convert.ToInt32(r["MaPhieuPhat"]),
                    NgayPhat = Convert.ToDateTime(r["NgayPhat"]),
                    TrangThai = Convert.ToInt32(r["TrangThai"]),
                    MaCTPhieuPhat = Convert.ToInt32(r["MaCTPhieuPhat"]),
                    NgayTra = r["NgayTra"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayTra"]),
                    tienPhat = Convert.ToInt32(r["TienPhat"]),
                    TenSach = r["TenSach"]?.ToString(),
                    TenDG = r["TenDG"]?.ToString(),

                });
            }
            return list;
        }

    }

}



