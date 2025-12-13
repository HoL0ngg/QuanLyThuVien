using MySql.Data.MySqlClient;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    pp.Ngaytra AS NgayTra,
                    SUM(ct.TienPhat) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                GROUP BY pp.MaPhieuPhat, pp.NgayPhat, pp.TrangThai, pp.Ngaytra, dg.TenDG, pp.MaDG
                ORDER BY pp.MaPhieuPhat DESC;";

            DataTable dt = DataProvider.ExecuteQuery(sql);
            var list = new List<PhieuPhatDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new PhieuPhatDTO
                {
                    MaPhieuPhat = Convert.ToInt32(r["MaPhieuPhat"]),
                    NgayPhat = Convert.ToDateTime(r["NgayPhat"]),
                    TrangThai = Convert.ToInt32(r["TrangThai"]),
                    NgayTra = r["NgayTra"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayTra"]),
                    tienPhat = Convert.ToInt32(r["TienPhat"]),
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
                    pp.Ngaytra AS NgayTra,
                    SUM(ct.TienPhat) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                WHERE @TrangThai IS NULL OR pp.TrangThai = @TrangThai
                GROUP BY pp.MaPhieuPhat, pp.NgayPhat, pp.TrangThai, pp.Ngaytra, dg.TenDG, pp.MaDG
                ORDER BY pp.MaPhieuPhat DESC;";

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
                    NgayTra = r["NgayTra"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayTra"]),
                    tienPhat = Convert.ToInt32(r["TienPhat"]),
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
                    pp.Ngaytra AS NgayTra,
                    SUM(ct.TienPhat) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                WHERE pp.NgayPhat BETWEEN @Begin AND @End
                GROUP BY pp.MaPhieuPhat, pp.NgayPhat, pp.TrangThai, pp.Ngaytra, dg.TenDG, pp.MaDG
                ORDER BY pp.MaPhieuPhat DESC;";

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
                    NgayTra = r["NgayTra"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayTra"]),
                    tienPhat = Convert.ToInt32(r["TienPhat"]),
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
                    pp.Ngaytra AS NgayTra,
                    SUM(ct.TienPhat) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                WHERE dg.TenDG LIKE @kw OR pp.MaPhieuPhat = @Id
                GROUP BY pp.MaPhieuPhat, pp.NgayPhat, pp.TrangThai, pp.Ngaytra, dg.TenDG, pp.MaDG
                ORDER BY pp.MaPhieuPhat DESC;";

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
                    NgayTra = r["NgayTra"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayTra"]),
                    tienPhat = Convert.ToInt32(r["TienPhat"]),
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



        /// <summary>
        /// Lấy tất cả sách đã trả chưa có phiếu phạt
        /// Hiển thị cả số ngày trễ nếu trả muộn
        /// </summary>
        public List<PhieuTraViPhamDTO> GetDanhSachViPham()
        {
            const string sql = @"
        SELECT 
            pt.MaPhieuTra,
            pm.MaDocGia AS MaDG,
            dg.TenDG AS TenDocGia
        FROM phieu_tra pt
        JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
        JOIN doc_gia dg ON pm.MaDocGia = dg.MaDG
        WHERE 
            (
                -- Có ít nhất một chi tiết hỏng/mất
                EXISTS (
                    SELECT 1 
                    FROM ctphieu_tra ct
                    WHERE ct.MaPhieuTra = pt.MaPhieuTra
                      AND ct.TrangThai IN (2,3)
                )
                -- Hoặc phiếu trả bị trễ hạn
                OR pt.NgayTra > pm.NgayTraDuKien
            )
            -- Chưa có phiếu phạt cho phiếu trả này
            AND NOT EXISTS (
                SELECT 1 
                FROM phieu_phat pp 
                WHERE pp.MaPhieuTra = pt.MaPhieuTra
            )
        ORDER BY pt.NgayTra DESC;
    ";

            DataTable dt = DataProvider.ExecuteQuery(sql);
            var list = new List<PhieuTraViPhamDTO>();

            foreach (DataRow r in dt.Rows)
            {
                var item = new PhieuTraViPhamDTO
                {
                    MaPhieuTra = Convert.ToInt32(r["MaPhieuTra"]),
                    MaDG = Convert.ToInt32(r["MaDG"]),
                    TenDocGia = r["TenDocGia"]?.ToString(),
                };
                list.Add(item);
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
                                // 1. Lấy MaSach TỪ ctphieu_tra để đảm bảo tồn tại trong bảng sach
                                int maSach;
                                using (var cmdGet = conn.CreateCommand())
                                {
                                    cmdGet.Transaction = trans;
                                    cmdGet.CommandText = @"
                                SELECT ct.MaSach
                                FROM ctphieu_tra ct
                                WHERE ct.MaPhieuTra = @MaPhieuTra
                                LIMIT 1;";
                                    cmdGet.Parameters.AddWithValue("@MaPhieuTra", item.MaPhieuTra);

                                    object obj = cmdGet.ExecuteScalar();
                                    if (obj == null || obj == DBNull.Value)
                                        throw new Exception("Không tìm được MaSach tương ứng với MaPhieuTra = " + item.MaPhieuTra);

                                    maSach = Convert.ToInt32(obj);
                                }

                                // 2. INSERT phieu_phat - SET Ngaytra = ngày hiện tại (ngày đóng phiếu)
                                cmd.Parameters.Clear();
                                cmd.CommandText = @"
                            INSERT INTO phieu_phat 
                                (NgayPhat, TrangThai, MaPhieuTra, Ngaytra, MaDG) 
                            VALUES 
                                (@NgayPhat, @TrangThai, @MaPhieuTra, @NgayTra, @MaDG);";

                                DateTime ngayHienTai = DateTime.Now.Date;
                                
                                cmd.Parameters.AddWithValue("@NgayPhat", ngayHienTai);
                                cmd.Parameters.AddWithValue("@TrangThai", 1); // Trạng thái = 1 (Đã đóng)
                                cmd.Parameters.AddWithValue("@MaPhieuTra", item.MaPhieuTra);
                                cmd.Parameters.AddWithValue("@NgayTra", ngayHienTai); // SET ngày trả = ngày hiện tại
                                cmd.Parameters.AddWithValue("@MaDG", item.MaDG);

                                cmd.ExecuteNonQuery();
                                long newPhieuPhatId = cmd.LastInsertedId;

                                // 3. TÍNH TOÁN TIỀN PHẠT
                                int tienPhat = item.TienPhat;
                                if (tienPhat == 0)
                                {
                                    if (item.QuaHan) tienPhat += item.SoNgayTre * 5000;
                                    if (item.TrangThai == 2) tienPhat += 50000;
                                    if (item.TrangThai == 3)
                                    {
                                        using (MySqlCommand cmdPrice = conn.CreateCommand())
                                        {
                                            cmdPrice.Transaction = trans;
                                            cmdPrice.CommandText = @"
                                        SELECT ds.Gia 
                                        FROM sach s 
                                        JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach 
                                        WHERE s.MaSach = @MaSach 
                                        LIMIT 1";
                                            cmdPrice.Parameters.AddWithValue("@MaSach", maSach);
                                            object obj = cmdPrice.ExecuteScalar();
                                            if (obj != null && obj != DBNull.Value)
                                            {
                                                int.TryParse(obj.ToString(), out int gia);
                                                tienPhat += gia;
                                            }
                                        }
                                    }
                                }

                                // 4. INSERT ctphieu_phat – dùng maSach lấy được ở bước 1
                                cmd.Parameters.Clear();
                                cmd.CommandText = @"
                            INSERT INTO ctphieu_phat 
                                (TienPhat, MaSach, MaPhieuPhat, TrangThai) 
                            VALUES 
                                (@TienPhat, @MaSach, @MaPhieuPhat, @TrangThaiSach);";

                                cmd.Parameters.AddWithValue("@TienPhat", tienPhat);
                                cmd.Parameters.AddWithValue("@MaSach", maSach);
                                cmd.Parameters.AddWithValue("@MaPhieuPhat", newPhieuPhatId);
                                cmd.Parameters.AddWithValue("@TrangThaiSach", item.TrangThai);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { trans.Rollback(); } catch { }
                        System.Windows.Forms.MessageBox.Show("Lỗi SQL khi lưu: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool Add(PhieuPhatDTO phieuPhat)
        {
            const string sql = @"
        INSERT INTO phieu_phat (NgayPhat, TrangThai, MaPhieuTra, Ngaytra, MaDG)
        VALUES (@NgayPhat, @TrangThai, @MaPhieuTra, @NgayTra, @MaDG);";

            // Nếu NgayTra chưa được set, tự động set = ngày hiện tại
            DateTime ngayTra = phieuPhat.NgayTra;
            if (ngayTra == DateTime.MinValue)
            {
                ngayTra = DateTime.Now.Date;
            }

            var parameters = new Dictionary<string, object>
            {
                { "@NgayPhat", phieuPhat.NgayPhat },
                { "@TrangThai", phieuPhat.TrangThai },
                { "@MaPhieuTra", phieuPhat.MaPhieuTra },
                { "@NgayTra", ngayTra },
                { "@MaDG", phieuPhat.MaDG }
            };

            return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
        }

        // Add this method inside the PhieuPhatDAO class
        public DataTable GetChiTietPhieuPhat(int maPhieuTra)
        {
            // Cú pháp SQL dành cho MySQL (DATEDIFF chỉ 2 tham số)
            string query = @"
                SELECT 
                    pt.MaPhieuTra,
                    ds.TenDauSach,
                    pt.NgayTra,
                    pm.NgayTraDuKien,
                    
                    -- 1. Số ngày trễ: MySQL dùng DATEDIFF(Date1, Date2) -> Date1 - Date2
                    GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) AS SoNgayTre,

                    -- 2. Tình trạng sách
                    CASE 
                        WHEN ctpt.TrangThai = 1 THEN 'Bình thường'
                        WHEN ctpt.TrangThai = 2 THEN 'Hỏng'
                        WHEN ctpt.TrangThai = 3 THEN 'Mất'
                        ELSE 'Khác'
                    END AS TinhTrangSach,

                    -- 3. Tính Tiền Phạt
                    ROUND(
                        CASE 
                            -- MẤT (3): Phạt 100% giá, KHÔNG tính ngày trễ
                            WHEN ctpt.TrangThai = 3 THEN ds.Gia
                            
                            -- HỎNG (2): Phạt 50% giá + Tiền ngày trễ (nếu có)
                            WHEN ctpt.TrangThai = 2 THEN 
                                (ds.Gia * 0.5) + 
                                (GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * ds.Gia * 0.02)
                            
                            -- BÌNH THƯỜNG (1): Chỉ phạt Tiền ngày trễ (nếu có)
                            ELSE 
                                (GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * ds.Gia * 0.02)
                        END
                    ) AS TongTienPhat

                FROM ctphieu_tra ctpt
                JOIN phieu_tra pt ON ctpt.MaPhieuTra = pt.MaPhieuTra
                JOIN sach s ON ctpt.MaSach = s.MaSach
                JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon

                WHERE 
                    pt.MaPhieuTra = @MaPhieuTra 
                    AND (ctpt.TrangThai IN (2, 3) OR pt.NgayTra > pm.NgayTraDuKien)";

            // Tạo danh sách tham số để truyền vào DataProvider
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@MaPhieuTra", maPhieuTra);

            // Gọi DataProvider để thực thi
            return DataProvider.ExecuteQuery(query, parameters);
        
    }
        public DataTable GetListChiTietDaLuu(int maPhieuPhat)
        {
            string query = @"
        SELECT 
            ctpp.MaCTPhieuPhat,
            ds.TenDauSach,
            pt.NgayTra,
            pm.NgayTraDuKien,
            GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) AS SoNgayTre,
            CASE 
                WHEN ctpp.TrangThai = 2 THEN 'Hỏng'
                WHEN ctpp.TrangThai = 3 THEN 'Mất'
                WHEN GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) > 0 THEN 'Quá hạn'
                ELSE 'Khác'
            END AS TinhTrangSach,
            ctpp.TienPhat AS TongTienPhat
        FROM ctphieu_phat ctpp
        JOIN phieu_phat pp ON ctpp.MaPhieuPhat = pp.MaPhieuPhat
        JOIN phieu_tra pt ON pp.MaPhieuTra = pt.MaPhieuTra
        JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
        -- Dùng LEFT JOIN để nếu sách bị xóa thì vẫn hiện dòng phạt (tên sách sẽ null)
        LEFT JOIN sach s ON ctpp.MaSach = s.MaSach
        LEFT JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
        WHERE ctpp.MaPhieuPhat = @MaPhieuPhat";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@MaPhieuPhat", maPhieuPhat);

            return DataProvider.ExecuteQuery(query, parameters);
        }

    }
}

