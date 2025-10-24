using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class CTPhieuNhapDAO
    {
        // lay ct phieu nhap theo ma phieu nhap
        public List<CTPhieuNhapDTO> GetByPhieuNhap(int maPhieuNhap)
        {
            List<CTPhieuNhapDTO> ls = new List<CTPhieuNhapDTO>();
            string query = "SELECT * FROM ctphieu_nhap WHERE MaPhieuNhap = @MaPhieuNhap";
            var param = new Dictionary<string, object> { { "@MaPhieuNhap", maPhieuNhap } };
            DataTable dt = DataProvider.ExecuteQuery(query, param);
            foreach (DataRow row in dt.Rows)
            {
                CTPhieuNhapDTO ct = new CTPhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDouble(row["DonGia"])
                };
                ls.Add(ct);
            }
            return ls;
        }
        //them ct phieu nhap
        public bool Insert(CTPhieuNhapDTO ct)
        {
            string query = "INSERT INTO ctphieu_nhap (MaPhieuNhap, MaDauSach, SoLuong, DonGia) VALUES (@MaPhieuNhap, @MaDauSach, @SoLuong, @DonGia)";
            //object[] param = { ct.MaPhieuNhap, ct.MaDauSach, ct.SoLuong, ct.DonGia };
            var parameters = new Dictionary<string, object>
            {
                {"@MaPhieuNhap", ct.MaPhieuNhap},
                {"@MaDauSach", ct.MaDauSach},
                {"@SoLuong", ct.SoLuong},
                {"@DonGia", ct.DonGia }
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
        // xoa ct phieu nhap theo ma phieu nhap
        public bool DeleteByPhieuNhap(int maPhieuNhap)
        {
            string query = "DELETE FROM ctphieu_nhap WHERE MaPhieuNhap=@MaPhieuNhap";
            //object[] param = { maPhieuNhap };
            var parameters = new Dictionary<string, object>
            {
                {"@MaPhieuNhap", maPhieuNhap }
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
