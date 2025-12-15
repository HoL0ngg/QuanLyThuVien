using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLyThuVien.DAO
{
    public class DauSachDAO
    {
        // Singleton Pattern
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

        /// <summary>
        /// Lấy tất cả đầu sách dưới dạng DataTable
        /// </summary>
        public DataTable GetAllDauSach()
        {
            string query = @"
                SELECT 
                    ds.MaDauSach,
                    ds.TenDauSach,
                    nxb.tenNXB as 'NhaXuatBan', 
                    ds.NamXuatBan,
                    ds.NgonNgu,
                    ds.SoLuong
                FROM 
                    dau_sach ds
                JOIN 
                    nha_xuat_ban nxb ON ds.NhaXuatBan = nxb.MaNXB
                WHERE
                    ds.TrangThai = 1
                ORDER BY 
                    ds.MaDauSach ASC";
            return DataProvider.ExecuteQuery(query);
        }

        /// <summary>
        /// Lấy tất cả đầu sách dưới dạng List DTO - sử dụng LINQ để convert
        /// </summary>
        public List<DauSachDTO> GetAllDauSachList()
        {
            DataTable dt = GetAllDauSach();
            
            // LINQ: Convert DataTable sang List<DauSachDTO>
            // Sử dụng Convert.ToInt32 để tránh lỗi InvalidCastException
            var danhSach = dt.AsEnumerable()
                .Select(row => new DauSachDTO
                {
                    MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                    TenDauSach = row["TenDauSach"]?.ToString() ?? "",
                    NamXuatBan = Convert.ToInt32(row["NamXuatBan"]),
                    NgonNgu = row["NgonNgu"]?.ToString() ?? "",
                    SoLuong = Convert.ToInt32(row["SoLuong"])
                })
                .ToList();

            return danhSach;
        }

        /// <summary>
        /// Tìm kiếm đầu sách theo từ khóa
        /// </summary>
        public DataTable SearchDauSach(string keyword)
        {
            string searchKeyword = "%" + keyword + "%";

            string query = @"
                SELECT 
                    ds.MaDauSach, 
                    ds.TenDauSach,
                    ds.HinhAnh,
                    nxb.tenNXB as 'NhaXuatBan', 
                    ds.NamXuatBan,
                    ds.NgonNgu,
                    ds.SoLuong,
                    GROUP_CONCAT(tg.TenTacGia SEPARATOR ', ') AS TenTacGia
                FROM 
                    dau_sach ds
                LEFT JOIN
                    nha_xuat_ban nxb ON ds.NhaXuatBan = nxb.MaNXB
                LEFT JOIN
                    tacgia_dausach tgds ON ds.MaDauSach = tgds.MaDauSach
                LEFT JOIN
                    tac_gia tg ON tgds.MaTacGia = tg.MaTacGia
                WHERE 
                    ds.TrangThai = 1 AND
                    (ds.TenDauSach LIKE @keyword OR
                    tg.TenTacGia LIKE @keyword OR
                    nxb.tenNXB LIKE @keyword)
                GROUP BY
                    ds.MaDauSach
                ORDER BY
                    ds.MaDauSach ASC";

            var parameters = new Dictionary<string, object>
            {
                { "@keyword", searchKeyword }
            };

            return DataProvider.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Lấy đầu sách theo ID
        /// </summary>
        public DauSachDTO GetDauSachByID(int dauSachID)
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
            
            var parameters = new Dictionary<string, object>
            {
                { "@dauSachID", dauSachID }
            };
            
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            
            if (dt == null || dt.Rows.Count == 0)
                return null;

            // Sử dụng Convert để tránh lỗi InvalidCastException
            DataRow row = dt.Rows[0];
            var dauSach = new DauSachDTO
            {
                MaDauSach = Convert.ToInt32(row["MaDauSach"]),
                TenDauSach = row["TenDauSach"]?.ToString() ?? "",
                NhaXuatBan = Convert.ToInt32(row["NhaXuatBan"]),
                NamXuatBan = Convert.ToInt32(row["NamXuatBan"]),
                NgonNgu = row["NgonNgu"]?.ToString() ?? "",
                SoLuong = Convert.ToInt32(row["SoLuong"]),
                HinhAnh = row["HinhAnh"]?.ToString() ?? ""
            };

            return dauSach;
        }

        /// <summary>
        /// Lấy danh sách tác giả theo mã đầu sách - sử dụng LINQ
        /// </summary>
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
                    tacgia_dausach tgds ON tgds.MaTacGia = tg.MaTacGia
                WHERE 
                    tgds.MaDauSach = @dauSachID";
            
            var parameters = new Dictionary<string, object>
            {
                { "@dauSachID", dauSachID }
            };
            
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            
            // LINQ: Convert DataTable sang List<TacGiaDTO>
            // Sử dụng Convert để tránh lỗi InvalidCastException
            var tacGiaList = dt.AsEnumerable()
                .Select(row => new TacGiaDTO
                {
                    maTacGia = Convert.ToInt32(row["MaTacGia"]),
                    tenTacGia = row["TenTacGia"]?.ToString() ?? "",
                    namSinh = row["NamSinh"]?.ToString() ?? "",
                    quocTich = row["QuocTich"]?.ToString() ?? ""
                })
                .ToList();

            return tacGiaList;
        }

        /// <summary>
        /// Thêm đầu sách mới
        /// </summary>
        public bool AddDauSach(string tenDauSach, int maNXB, string hinhAnhPath, string namXuatBan, string ngonNgu, List<int> maTacGiaList)
        {
            using (MySqlConnection connection = DataProvider.GetConnection())
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                MySqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                
                try
                {
                    // Thêm đầu sách
                    string queryDauSach = @"
                        INSERT INTO dau_sach (TenDauSach, NhaXuatBan, HinhAnh, NamXuatBan, NgonNgu)
                        VALUES (@tenDauSach, @maNXB, @hinhAnhPath, @namXuatBan, @ngonNgu); 
                        SELECT LAST_INSERT_ID();";

                    command.CommandText = queryDauSach;
                    command.Parameters.AddWithValue("@tenDauSach", tenDauSach);
                    command.Parameters.AddWithValue("@maNXB", maNXB);
                    command.Parameters.AddWithValue("@hinhAnhPath", hinhAnhPath);
                    command.Parameters.AddWithValue("@namXuatBan", namXuatBan);
                    command.Parameters.AddWithValue("@ngonNgu", ngonNgu);

                    int newMaDauSach = Convert.ToInt32(command.ExecuteScalar());

                    if (newMaDauSach == 0)
                        throw new Exception("Không thể tạo đầu sách mới.");

                    command.Parameters.Clear();

                    // Thêm tác giả nếu có
                    if (maTacGiaList != null && maTacGiaList.Any())
                    {
                        var queryTacGia = new StringBuilder();
                        queryTacGia.Append("INSERT INTO tacgia_dausach (MaDauSach, MaTacGia) VALUES ");

                        // Tạo danh sách values
                        var valuesList = new List<string>();
                        for (int i = 0; i < maTacGiaList.Count; i++)
                        {
                            string maDSParam = "@MaDS" + i;
                            string maTGParam = "@MaTG" + i;
                            command.Parameters.AddWithValue(maDSParam, newMaDauSach);
                            command.Parameters.AddWithValue(maTGParam, maTacGiaList[i]);
                            valuesList.Add($"({maDSParam}, {maTGParam})");
                        }

                        queryTacGia.Append(string.Join(", ", valuesList));
                        command.CommandText = queryTacGia.ToString();
                        command.ExecuteNonQuery();
                    }

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

        /// <summary>
        /// Cập nhật đầu sách
        /// </summary>
        public bool UpdateDauSach(int dauSachID, string tenDauSach, int maNXB, string hinhAnhPath, string namXuatBan, string ngonNgu, List<int> maTacGiaList)
        {
            using (MySqlConnection connection = DataProvider.GetConnection())
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                MySqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                
                try
                {
                    // Cập nhật đầu sách
                    string queryDauSach = @"
                        UPDATE dau_sach 
                        SET TenDauSach = @tenDauSach, 
                            NhaXuatBan = @maNXB, 
                            HinhAnh = @hinhAnhPath, 
                            NamXuatBan = @namXuatBan, 
                            NgonNgu = @ngonNgu
                        WHERE MaDauSach = @dauSachID";
                    
                    command.CommandText = queryDauSach;
                    command.Parameters.AddWithValue("@tenDauSach", tenDauSach);
                    command.Parameters.AddWithValue("@maNXB", maNXB);
                    command.Parameters.AddWithValue("@hinhAnhPath", hinhAnhPath);
                    command.Parameters.AddWithValue("@namXuatBan", namXuatBan);
                    command.Parameters.AddWithValue("@ngonNgu", ngonNgu);
                    command.Parameters.AddWithValue("@dauSachID", dauSachID);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    // Xóa tác giả cũ
                    string deleteQuery = "DELETE FROM tacgia_dausach WHERE MaDauSach = @dauSachID";
                    command.CommandText = deleteQuery;
                    command.Parameters.AddWithValue("@dauSachID", dauSachID);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    // Thêm lại tác giả mới
                    if (maTacGiaList != null && maTacGiaList.Any())
                    {
                        var queryTacGia = new StringBuilder();
                        queryTacGia.Append("INSERT INTO tacgia_dausach (MaDauSach, MaTacGia) VALUES ");

                        var valuesList = new List<string>();
                        for (int i = 0; i < maTacGiaList.Count; i++)
                        {
                            string maDSParam = "@MaDS" + i;
                            string maTGParam = "@MaTG" + i;
                            command.Parameters.AddWithValue(maDSParam, dauSachID);
                            command.Parameters.AddWithValue(maTGParam, maTacGiaList[i]);
                            valuesList.Add($"({maDSParam}, {maTGParam})");
                        }

                        queryTacGia.Append(string.Join(", ", valuesList));
                        command.CommandText = queryTacGia.ToString();
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi CSDL khi cập nhật đầu sách: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Xóa đầu sách (soft delete)
        /// </summary>
        public bool DeleteDauSach(int dauSachID)
        {
            string query = @"
                UPDATE dau_sach
                SET TrangThai = 0
                WHERE MaDauSach = @dauSachID";
            
            var parameters = new Dictionary<string, object>
            {
                { "@dauSachID", dauSachID }
            };
            
            int result = DataProvider.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Lấy danh sách đầu sách theo năm xuất bản - sử dụng LINQ
        /// </summary>
        public List<DauSachDTO> GetDauSachByNamXuatBan(int namXuatBan)
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lọc theo năm xuất bản
            return allDauSach
                .Where(ds => ds.NamXuatBan == namXuatBan)
                .OrderBy(ds => ds.TenDauSach)
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách đầu sách theo ngôn ngữ - sử dụng LINQ
        /// </summary>
        public List<DauSachDTO> GetDauSachByNgonNgu(string ngonNgu)
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lọc theo ngôn ngữ (không phân biệt hoa thường)
            return allDauSach
                .Where(ds => ds.NgonNgu.Equals(ngonNgu, StringComparison.OrdinalIgnoreCase))
                .OrderBy(ds => ds.TenDauSach)
                .ToList();
        }
        public bool UpdateSoLuongTon(int maDauSach, int soLuongThayDoi)
        {
            string query = "UPDATE dau_sach SET SoLuong = IFNULL(SoLuong, 0) + @SoLuongThayDoi WHERE MaDauSach = @MaDauSach";

            var parameters = new Dictionary<String, object>
            {
                { "@SoLuongThayDoi", soLuongThayDoi },

                { "@MaDauSach", maDauSach }
            };

            int result = DataProvider.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool UpdateGiaBan(int maDauSach, double donGia)
        {
            string query = "UPDATE dau_sach SET Gia = @Gia WHERE MaDauSach = @MaDauSach";
            var param = new Dictionary<string, object>
            {
                { "@Gia", donGia },
                { "@MaDauSach", maDauSach }
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
    }
}