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
            string query = "INSERT INTO phieu_nhap (ThoiGian,MaNV,MaNCC) VALUES (@ThoiGian,@MaNV,@MaNCC)";
            object[] param = { pn.ThoiGian, pn.MaNV, pn.MaNCC };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
        // sua phieu nhap
        public bool Update(PhieuNhapDTO pn)
        {
            string query = "UPDATE phieu_nhap SET ThoiGian=@ThoiGian, MaNV=@MaNV, MaNCC=@MaNCC WHERE MaPhieuNhap=@MaPhieuNhap";
            object[] param = { pn.ThoiGian, pn.MaNV, pn.MaNCC, pn.MaPhieuNhap };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
        // xoa phieu nhap
        public bool Delete(int maPhieuNhap)
        {
            string query = "DELETE FROM phieu_nhap WHERE MaPhieuNhap = @MaPhieuNhap";
            object[] param = { maPhieuNhap };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
    }
}
