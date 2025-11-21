using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
// Thư viện này cần thiết cho Dictionary
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuanLyThuVien.DAO // Hoặc QuanLyNhanSu.DAO
{
    public class DauSachDAO
    {
        // Ta vẫn dùng Singleton cho DAO để BUS gọi
        private static DauSachDAO _instance;
        public static DauSachDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DauSachDAO();
                return _instance;
            }
            private set { _instance = value; }
        }
        private DauSachDAO() { }

        public DataTable GetAllDauSach()
        {
                string query = @"
                SELECT 
                    ds.MaDauSach as 'Mã đầu sách',
                    ds.TenDauSach as 'Tên đầu sách',
                    nxb.tenNXB as 'Nhà xuất bản', 
                    ds.NamXuatBan as 'Năm xuất bản',
                    ds.NgonNgu as 'Ngôn ngữ',
                    ds.SoLuong as 'Số lượng'
                FROM 
                    dau_sach ds
                JOIN 
                    nha_xuat_ban nxb ON ds.NhaXuatBan = nxb.MaNXB
                ORDER BY 
                    ds.MaDauSach ASC";

            // THAY ĐỔI 1: Gọi trực tiếp DataProvider.ExecuteQuery
            // vì hàm của bạn là static, không dùng Instance
            DataTable data = DataProvider.ExecuteQuery(query);

            return data;
        }

        public DataTable SearchDauSach(string keyword)
        {
            string searchKeyword = "%" + keyword + "%";

            string query = @"
                SELECT 
                    ds.MaDauSach, 
                    ds.TenDauSach,
                    ds.HinhAnh,
                    ds.NhaXuatBan, 
                    ds.NamXuatBan,
                    ds.NgonNgu,
                    ds.SoLuong
                FROM 
                    dau_sach ds
                WHERE 
                        ds.TenDauSach LIKE @keyword OR 
                        ds.TenTacGia LIKE @keyword OR 
                        ds.NhaXuatBan LIKE @keyword
                ORDER BY 
                    ds.MaDauSach ASC";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@keyword", searchKeyword);

            // Gọi DataProvider với Dictionary parameters
            DataTable data = DataProvider.ExecuteQuery(query, parameters);

            return data;
        }

        public DauSachDTO GetDauSachByID(int dauSach)
        {
            string query = @"
                SELECT 
                    MaDauSach,
                    TenDauSach,
                    NhaXuatBan,
                    NamXuatBan,
                    NgonNgu,
                    SoLuong,
                    HinhAnh
                FROM 
                    dau_sach
                WHERE 
                    MaDauSach = @dauSachID";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@dauSachID", dauSach);
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0)
                return null;
            DataRow row = dt.Rows[0];
            DauSachDTO dauSachDTO = new DauSachDTO
            {
                MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                TenDauSach = row["TenDauSach"].ToString(),
                NhaXuatBan = Convert.ToInt32(row["NhaXuatBan"]),
                NamXuatBan = Convert.ToInt32(row["NamXuatBan"]),
                NgonNgu = row["NgonNgu"].ToString(),
                SoLuong = Convert.ToInt32(row["SoLuong"]),
                HinhAnh = row["HinhAnh"].ToString()
            };
            return dauSachDTO;
        }

        public List<TacGiaDTO> GetTacGiaByDauSachID(int dauSachID)
        {
            string query = @"
                SELECT 
                    tg.MaTacGia,
                    tg.TenTacGia,
                    tg.NamSinh,
                    tg.QuocTich
                FROM 
                    tac_gia tg
                JOIN
                    tacgia_dausach ON tacgia_dausach.MaTacGia = tg.MaTacGia
                WHERE 
                    MaDauSach = @dauSachID";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@dauSachID", dauSachID);
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            List<TacGiaDTO> tacGiaList = new List<TacGiaDTO>();
            foreach (DataRow row in dt.Rows)
            {
                TacGiaDTO tacGia = new TacGiaDTO
                {
                    maTacGia = Convert.ToInt32(row["MaTacGia"]),
                    tenTacGia = row["TenTacGia"].ToString(),
                    namSinh = row["NamSinh"].ToString(),
                    quocTich = row["QuocTich"].ToString()
                };
                tacGiaList.Add(tacGia);
            }
            return tacGiaList;
        }

        public bool AddDauSach(string tenDauSach, int maNXB, string hinhAnhPath, string namXuatBan, string NgonNgu, List<int> maTacGiaList)
        {
            using (MySqlConnection connection = DataProvider.GetConnection())
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                MySqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    string queryDauSach = @"
                        INSERT INTO dau_sach (TenDauSach, NhaXuatBan, HinhAnh, NamXuatBan, NgonNgu)
                        VALUES (@tenDauSach, @maNXB, @hinhAnhPath, @namXuatBan, @NgonNgu); SELECT LAST_INSERT_ID();";

                    command.CommandText = queryDauSach;
                    command.Parameters.AddWithValue("@tenDauSach", tenDauSach);
                    command.Parameters.AddWithValue("@maNXB", maNXB);
                    command.Parameters.AddWithValue("@hinhAnhPath", hinhAnhPath);
                    command.Parameters.AddWithValue("@namXuatBan", namXuatBan);
                    command.Parameters.AddWithValue("@NgonNgu", NgonNgu);

                    int newMaDauSach = Convert.ToInt32(command.ExecuteScalar());

                    if (newMaDauSach == 0)
                    {
                        throw new Exception("Không thể tạo đầu sách mới.");
                    }

                    // Xóa các tham số cũ
                    command.Parameters.Clear();

                    var queryTacGia = new StringBuilder();
                    queryTacGia.Append("INSERT INTO tacgia_dausach (MaDauSach, MaTacGia) VALUES ");

                    for (int i = 0; i < maTacGiaList.Count; i++)
                    {
                        string maDSParam = "@MaDS" + i;
                        string maTGParam = "@MaTG" + i;

                        queryTacGia.AppendFormat("({0}, {1})", maDSParam, maTGParam);
                        if (i < maTacGiaList.Count - 1)
                        {
                            queryTacGia.Append(", ");
                        }

                        // Thêm tham số cho vòng lặp
                        command.Parameters.AddWithValue(maDSParam, newMaDauSach);
                        command.Parameters.AddWithValue(maTGParam, maTacGiaList[i]);
                    }

                    // Chạy câu query thêm tác giả
                    command.CommandText = queryTacGia.ToString();
                    command.ExecuteNonQuery();

                    // BƯỚC 3: Nếu mọi thứ OK, commit transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi CSDL khi thêm đầu sách: " + ex.Message);
                }
            }

        }
    }
}