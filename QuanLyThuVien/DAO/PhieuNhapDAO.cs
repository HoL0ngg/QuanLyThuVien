using QuanLyNhanSu.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class PhieuNhapDAO
    {
        // lay danh sach phieu nhap
        public List<PhieuNhapDTO> GetAll()
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();
            string query = "SELECT * FROM phieu_nhap";
            DataTable dt = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                PhieuNhapDTO pn = new PhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    ThoiGian = Convert.ToDateTime(row["ThoiGian"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                };
                list.Add(pn);
            }
            return list;
        }
        // them phieu nhap
        public bool Insert(PhieuNhapDTO pn)
        {
            if (pn == null)
                throw new ArgumentNullException(nameof(pn));
            if (pn.ThoiGian == DateTime.MinValue)
                throw new Exception("Ngày nhập không hợp lệ");

            string query = "INSERT INTO phieu_nhap (ThoiGian, MaNV, MaNCC) VALUES (@ThoiGian, @MaNV, @MaNCC)";

            var param = new Dictionary<string, object>
            {
                { "@ThoiGian", pn.ThoiGian },
                { "@MaNV", pn.MaNV },
                { "@MaNCC", pn.MaNCC }
            };

            return DataProvider.ExecuteNonQuery(query,param) > 0;
        }

        // sua phieu nhap
        public bool Update(PhieuNhapDTO pn)
        {
            string query = "UPDATE phieu_nhap SET ThoiGian=@ThoiGian, MaNV=@MaNV, MaNCC=@MaNCC WHERE MaPhieuNhap=@MaPhieuNhap";
            var param = new Dictionary<string, object>
            {
                { "@ThoiGian", pn.ThoiGian },
                { "@MaNV", pn.MaNV },
                { "@MaNCC", pn.MaNCC },
                {"@MaPhieuNhap", pn.MaPhieuNhap }
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
        // xoa phieu nhap
        public bool Delete(int maPhieuNhap)
        {
            string query = "DELETE FROM phieu_nhap WHERE MaPhieuNhap = @MaPhieuNhap";
            var param = new Dictionary<string, object>
            {
                { "@MaPhieuNhap", maPhieuNhap}
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
        public PhieuNhapDTO GetById(int maPhieuNhap)
        {
            string query = "SELECT * FROM phieu_nhap WHERE MaPhieuNhap = @MaPhieuNhap";
            var param = new Dictionary<string, object> { { "@MaPhieuNhap", maPhieuNhap } };

            DataTable dt = DataProvider.ExecuteQuery(query, param);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            PhieuNhapDTO phieu = new PhieuNhapDTO
            {
                MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                ThoiGian = Convert.ToDateTime(row["ThoiGian"]),
                MaNV = Convert.ToInt32(row["MaNV"]),
                MaNCC = Convert.ToInt32(row["MaNCC"])
            };
            CTPhieuNhapDAO ctDAO = new CTPhieuNhapDAO();
            phieu.ct = ctDAO.GetByPhieuNhap(phieu.MaPhieuNhap);

            return phieu;
        }

    }
}
