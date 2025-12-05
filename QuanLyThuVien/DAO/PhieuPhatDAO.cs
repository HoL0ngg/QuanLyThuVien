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
        private object ex;

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
                    dg.TenDG,
                    pp.MaDG
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
                    MaDG = Convert.ToInt32(r["MaDG"])
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
                    dg.TenDG,
                    pp.MaDG
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
                    MaDG = Convert.ToInt32(r["MaDG"])
                });
            }
            return list;
        }
        public List<PhieuPhatDTO> GetByDateRange(DateTime begin, DateTime end)
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
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN sach s           ON s.MaSach       = ct.MaSach
                JOIN dau_sach ds      ON ds.MaDauSach   = s.MaDauSach
                JOIN doc_gia dg       ON pp.MaDG = dg.MaDG
                WHERE pp.NgayPhat BETWEEN @Begin AND @End
                ORDER BY pp.MaPhieuPhat DESC, ct.MaCTPhieuPhat DESC;";

            var parameters = new Dictionary<string, object>
            {
                { "@Begin", begin.Date },
                { "@End", end.Date }
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
                    MaDG = Convert.ToInt32(r["MaDG"])
                });
            }
            return list;
        }
        public List<PhieuPhatDTO> GetByKeyword(string keyword)
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
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN sach s           ON s.MaSach       = ct.MaSach
                JOIN dau_sach ds      ON ds.MaDauSach   = s.MaDauSach
                JOIN doc_gia dg       ON pp.MaDG = dg.MaDG
                WHERE ds.TenDauSach LIKE @kw OR dg.TenDG LIKE @kw OR pp.MaPhieuPhat = @Id
                ORDER BY pp.MaPhieuPhat DESC, ct.MaCTPhieuPhat DESC;";

            int id = -1;
            if (!int.TryParse(keyword, out id))
            {
                id = -1; // sẽ không khớp
            }

            var parameters = new Dictionary<string, object>
            {
                { "@kw", "%" + keyword + "%" },
                { "@Id", id }
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
                    MaDG = Convert.ToInt32(r["MaDG"])
                });
            }
            return list;
        }

    
        

        public bool Update(PhieuPhatDTO phieuPhat)
        {
            const string sql = @"
                UPDATE phieu_phat
                SET NgayPhat = @NgayPhat, TrangThai = @TrangThai, Ngaytra = @NgayTra, MaDG = @MaDG
                WHERE MaPhieuPhat = @MaPhieuPhat;";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuPhat", phieuPhat.MaPhieuPhat },
                { "@NgayPhat", phieuPhat.NgayPhat },
                { "@TrangThai", phieuPhat.TrangThai },
                { "@NgayTra", phieuPhat.NgayTra == DateTime.MinValue ? (object)DBNull.Value : phieuPhat.NgayTra },
                { "@MaDG", phieuPhat.MaDG }
            };

            return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Delete(int maPhieuPhat)
        {
            const string sql = "DELETE FROM phieu_phat WHERE MaPhieuPhat = @MaPhieuPhat;";
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieuPhat", maPhieuPhat }
            };

            return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
        }

        // New: set TrangThai value (soft-delete / mark hidden)
        public bool SetTrangThai(int maPhieuPhat, int trangThai)
        {
            // Câu lệnh này chỉ UPDATE cột TrangThai, không xóa dòng nào cả
            const string sql = "UPDATE phieu_phat SET TrangThai = @TrangThai WHERE MaPhieuPhat = @MaPhieuPhat";

            var parameters = new Dictionary<string, object>
    {
        { "@TrangThai", trangThai },
        { "@MaPhieuPhat", maPhieuPhat }
    };

            // Trả về true nếu có ít nhất 1 dòng bị ảnh hưởng
            return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
        }


      
        public List<PhieuTraViPhamDTO> GetDanhSachViPham()
        {
            const string sql = @"
        SELECT 
            ct.MaCTPhieuTra, 
            ct.TrangThai, 
            ct.MaPhieuTra, 
            ct.MaSach, 
            pt.NgayTra, 
            pm.NgayTraDuKien, 
            ds.TenDauSach AS TenSach, 
            dg.TENDG AS TenDocGia,
            
            dg.MADG  -- <--- QUAN TRỌNG: Phải Select cột này
            
        FROM ctphieu_tra ct
        JOIN phieu_tra pt ON ct.MaPhieuTra = pt.MaPhieuTra
        JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
        JOIN sach s ON ct.MaSach = s.MaSach
        JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
        JOIN doc_gia dg ON pm.MaDocGia = dg.MADG
        LEFT JOIN phieu_phat pp_exist ON pp_exist.MaCTPhieuTra = ct.MaCTPhieuTra
        WHERE (ct.TrangThai IN (2, 3) OR pt.NgayTra > pm.NgayTraDuKien)
            AND pp_exist.MaPhieuPhat IS NULL
        ORDER BY pt.NgayTra DESC;";

            DataTable dt = DataProvider.ExecuteQuery(sql);
            var list = new List<PhieuTraViPhamDTO>();

            foreach (DataRow r in dt.Rows)
            {
                // ... (các biến ngày tháng giữ nguyên)
                DateTime ngayTra = Convert.ToDateTime(r["NgayTra"]);
                DateTime ngayTraDuKien = Convert.ToDateTime(r["NgayTraDuKien"]);

                list.Add(new PhieuTraViPhamDTO
                {
                    MaCTPhieuTra = Convert.ToInt32(r["MaCTPhieuTra"]),
                    TrangThai = Convert.ToInt32(r["TrangThai"]),
                    MaPhieuTra = Convert.ToInt32(r["MaPhieuTra"]),
                    MaSach = Convert.ToInt32(r["MaSach"]),

                    // --- GÁN GIÁ TRỊ TỪ DATABASE VÀO DTO ---
                    MaDG = Convert.ToInt32(r["MADG"]),
                    // ---------------------------------------

                    NgayTra = ngayTra,
                    NgayTraDuKien = ngayTraDuKien,
                    TenSach = r["TenSach"]?.ToString(),
                    TenDocGia = r["TenDocGia"]?.ToString(),
                    QuaHan = (ngayTra > ngayTraDuKien)
                });
            }
            return list;
        }


        public bool CreatePhieuPhatFromViolations(List<PhieuTraViPhamDTO> items)
        {
            if (items == null || items.Count == 0) return false;

            using (MySqlConnection conn = DataProvider.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.Transaction = trans;

                            foreach (var item in items)
                            {
                                // -------------------------------------------------------------
                                // [QUAN TRỌNG] SỬA CÂU SQL TẠI ĐÂY
                                // Bạn phải thêm cột MaDG vào câu INSERT này
                                // -------------------------------------------------------------
                                cmd.Parameters.Clear();
                                cmd.CommandText = @"INSERT INTO phieu_phat 
                                           (NgayPhat, TrangThai, MaCTPhieuTra, Ngaytra, MaDG) 
                                           VALUES 
                                           (@NgayPhat, @TrangThai, @MaCTPhieuTra, @NgayTra, @MaDG);"; // <--- Thêm @MaDG

                                cmd.Parameters.AddWithValue("@NgayPhat", DateTime.Now.Date);
                                cmd.Parameters.AddWithValue("@TrangThai", 1);
                                cmd.Parameters.AddWithValue("@MaCTPhieuTra", item.MaCTPhieuTra);
                                cmd.Parameters.AddWithValue("@NgayTra", item.NgayTra == DateTime.MinValue ? (object)DBNull.Value : item.NgayTra);

                                // [QUAN TRỌNG] Thêm tham số MaDG lấy từ item
                                cmd.Parameters.AddWithValue("@MaDG", item.MaDG);

                                cmd.ExecuteNonQuery();
                                long newPhieuPhatId = cmd.LastInsertedId;

                                // --- PHẦN TÍNH TIỀN PHẠT (GIỮ NGUYÊN) ---
                                int tienPhat = 0;
                                if (item.QuaHan) tienPhat += item.SoNgayTre * 5000;
                                if (item.TrangThai == 2) tienPhat += 50000;
                                if (item.TrangThai == 3)
                                {
                                    // Lấy giá sách để bồi thường (logic cũ của bạn)
                                    using (MySqlCommand cmdPrice = conn.CreateCommand())
                                    {
                                        cmdPrice.Transaction = trans;
                                        cmdPrice.CommandText = "SELECT ds.Gia FROM sach s JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach WHERE s.MaSach = @MaSach LIMIT 1";
                                        cmdPrice.Parameters.AddWithValue("@MaSach", item.MaSach);
                                        object obj = cmdPrice.ExecuteScalar();
                                        if (obj != null && obj != DBNull.Value)
                                        {
                                            int.TryParse(obj.ToString(), out int gia);
                                            tienPhat += gia;
                                        }
                                    }
                                }

                                // --- INSERT CHI TIẾT PHIẾU PHẠT (GIỮ NGUYÊN) ---
                                cmd.Parameters.Clear();
                                cmd.CommandText = "INSERT INTO ctphieu_phat (TienPhat, MaSach, MaPhieuPhat) VALUES (@TienPhat, @MaSach, @MaPhieuPhat);";
                                cmd.Parameters.AddWithValue("@TienPhat", tienPhat);
                                cmd.Parameters.AddWithValue("@MaSach", item.MaSach);
                                cmd.Parameters.AddWithValue("@MaPhieuPhat", newPhieuPhatId);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { trans.Rollback(); } catch { }
                        // Hiện lỗi chi tiết để biết sai ở đâu
                        System.Windows.Forms.MessageBox.Show("Lỗi SQL khi lưu: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool Add(PhieuPhatDTO phieuPhat)
        {
            const string sql = @"
        INSERT INTO phieu_phat (NgayPhat, TrangThai, MaCTPhieuTra, Ngaytra, MaDG)
        VALUES (@NgayPhat, @TrangThai, @MaCTPhieuTra, @NgayTra, @MaDG);";

            var parameters = new Dictionary<string, object>
    {
        { "@NgayPhat", phieuPhat.NgayPhat },
        { "@TrangThai", phieuPhat.TrangThai },
        
        // [SỬA] Sử dụng đúng thuộc tính MaCTPhieuTra
        { "@MaCTPhieuTra", phieuPhat.MaCTPhieuTra },

        { "@NgayTra", phieuPhat.NgayTra == DateTime.MinValue ? (object)DBNull.Value : phieuPhat.NgayTra },
        { "@MaDG", phieuPhat.MaDG }
    };

            return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
    }





















