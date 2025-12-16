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
                    -- Tính tiền phạt dựa trên cấu hình phat p
                    SUM(
                        CASE
                            WHEN ct.TrangThai = 3 THEN IFNULL(p.Mat,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            WHEN ct.TrangThai = 2 THEN IFNULL(p.Hong,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            ELSE GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                        END
                    ) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN phieu_tra pt ON pp.MaPhieuTra = pt.MaPhieuTra
                JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                LEFT JOIN phat p ON 1=1
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
                    tienPhat = r["TienPhat"] == DBNull.Value ? 0 : Convert.ToInt32(r["TienPhat"]),
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
                    SUM(
                        CASE
                            WHEN ct.TrangThai = 3 THEN IFNULL(p.Mat,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            WHEN ct.TrangThai = 2 THEN IFNULL(p.Hong,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            ELSE GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                        END
                    ) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN phieu_tra pt ON pp.MaPhieuTra = pt.MaPhieuTra
                JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                LEFT JOIN phat p ON 1=1
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
                    tienPhat = r["TienPhat"] == DBNull.Value ? 0 : Convert.ToInt32(r["TienPhat"]),
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
                    SUM(
                        CASE
                            WHEN ct.TrangThai = 3 THEN IFNULL(p.Mat,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            WHEN ct.TrangThai = 2 THEN IFNULL(p.Hong,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            ELSE GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                        END
                    ) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN phieu_tra pt ON pp.MaPhieuTra = pt.MaPhieuTra
                JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                LEFT JOIN phat p ON 1=1
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
                    tienPhat = r["TienPhat"] == DBNull.Value ? 0 : Convert.ToInt32(r["TienPhat"]),
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
                    SUM(
                        CASE
                            WHEN ct.TrangThai = 3 THEN IFNULL(p.Mat,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            WHEN ct.TrangThai = 2 THEN IFNULL(p.Hong,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                            ELSE GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0)
                        END
                    ) AS TienPhat,
                    dg.TenDG,
                    pp.MaDG
                FROM phieu_phat pp
                JOIN ctphieu_phat ct ON ct.MaPhieuPhat = pp.MaPhieuPhat
                JOIN phieu_tra pt ON pp.MaPhieuTra = pt.MaPhieuTra
                JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                JOIN doc_gia dg ON pp.MaDG = dg.MaDG
                LEFT JOIN phat p ON 1=1
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
                    tienPhat = r["TienPhat"] == DBNull.Value ? 0 : Convert.ToInt32(r["TienPhat"]),
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

                            // Đọc cấu hình mức phạt từ bảng phat
                            int phatTre = 0, phatHong = 0, phatMat = 0;
                            using (var cmdGetPhat = conn.CreateCommand())
                            {
                                cmdGetPhat.Transaction = trans;
                                cmdGetPhat.CommandText = "SELECT Tre, Hong, Mat FROM phat LIMIT 1;";
                                using (var r = cmdGetPhat.ExecuteReader())
                                {
                                    if (r.Read())
                                    {
                                        phatTre = r["Tre"] != DBNull.Value ? Convert.ToInt32(r["Tre"]) : 0;
                                        phatHong = r["Hong"] != DBNull.Value ? Convert.ToInt32(r["Hong"]) : 0;
                                        phatMat = r["Mat"] != DBNull.Value ? Convert.ToInt32(r["Mat"]) : 0;
                                    }
                                }
                            }

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

                                // 3. TÍNH TOÁN TIỀN PHẠT dựa trên cấu hình trong bảng phat
                                int tienPhat = item.TienPhat;
                                if (tienPhat == 0)
                                {
                                    // Nếu quá hạn
                                    if (item.QuaHan)
                                    {
                                        tienPhat += item.SoNgayTre * phatTre;
                                    }

                                    // Tình trạng sách: 2 = Hỏng, 3 = Mất
                                    if (item.TrangThai == 2)
                                    {
                                        tienPhat += phatHong;
                                    }
                                    else if (item.TrangThai == 3)
                                    {
                                        tienPhat += phatMat;
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
            // Sử dụng giá trị mức phạt từ bảng `phat`
            string query = @"
                SELECT 
                    pt.MaPhieuTra,
                    ds.TenDauSach,
                    pt.NgayTra,
                    pm.NgayTraDuKien,
                    GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) AS SoNgayTre,
                    CASE 
                        WHEN ctpt.TrangThai = 1 THEN 'Bình thường'
                        WHEN ctpt.TrangThai = 2 THEN 'Hỏng'
                        WHEN ctpt.TrangThai = 3 THEN 'Mất'
                        ELSE 'Khác'
                    END AS TinhTrangSach,
                    -- Lấy mức phạt từ bảng phat (assume một dòng cấu hình)
                    p.Tre AS MucTre,
                    p.Hong AS MucHong,
                    p.Mat AS MucMat,
                    -- Tính tiền phạt theo cấu hình: 
                    -- Quá hạn: SoNgayTre * p.Tre
                    -- Hỏng: p.Hong + SoNgayTre * p.Tre
                    -- Mất: p.Mat + SoNgayTre * p.Tre
                    (
                        CASE 
                            WHEN ctpt.TrangThai = 3 THEN (IFNULL(p.Mat,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0))
                            WHEN ctpt.TrangThai = 2 THEN (IFNULL(p.Hong,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0))
                            ELSE (GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0))
                        END
                    ) AS TongTienPhat
                FROM ctphieu_tra ctpt
                JOIN phieu_tra pt ON ctpt.MaPhieuTra = pt.MaPhieuTra
                JOIN sach s ON ctpt.MaSach = s.MaSach
                JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                -- Lấy cấu hình mức phạt (một dòng) bằng cross join
                LEFT JOIN phat p ON 1=1
                WHERE 
                    pt.MaPhieuTra = @MaPhieuTra 
                    AND (ctpt.TrangThai IN (2, 3) OR pt.NgayTra > pm.NgayTraDuKien)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@MaPhieuTra", maPhieuTra);

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
            -- Lấy mức phạt từ bảng phat
            p.Tre AS MucTre,
            p.Hong AS MucHong,
            p.Mat AS MucMat,
            -- Tính tiền phạt giống như chế độ xem trước
            (
                CASE 
                    WHEN ctpp.TrangThai = 3 THEN (IFNULL(p.Mat,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0))
                    WHEN ctpp.TrangThai = 2 THEN (IFNULL(p.Hong,0) + GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0))
                    ELSE (GREATEST(DATEDIFF(pt.NgayTra, pm.NgayTraDuKien), 0) * IFNULL(p.Tre,0))
                END
            ) AS TongTienPhat
        FROM ctphieu_phat ctpp
        JOIN phieu_phat pp ON ctpp.MaPhieuPhat = pp.MaPhieuPhat
        JOIN phieu_tra pt ON pp.MaPhieuTra = pt.MaPhieuTra
        JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
        -- Dùng LEFT JOIN để nếu sách bị xóa thì vẫn hiện dòng phạt (tên sách sẽ null)
        LEFT JOIN sach s ON ctpp.MaSach = s.MaSach
        LEFT JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
        -- Lấy cấu hình mức phạt
        LEFT JOIN phat p ON 1=1
        WHERE ctpp.MaPhieuPhat = @MaPhieuPhat";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@MaPhieuPhat", maPhieuPhat);

            return DataProvider.ExecuteQuery(query, parameters);
        }

        // New: đọc mức phạt từ bảng `phat` (trả MucPhatDTO)
        public MucPhatDTO GetMucPhat()
        {
            string sql = "SELECT Tre, Hong, Mat FROM phat LIMIT 1";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new MucPhatDTO
            {
                Tre = r["Tre"] == DBNull.Value ? 0 : Convert.ToInt32(r["Tre"]),
                Hong = r["Hong"] == DBNull.Value ? 0 : Convert.ToInt32(r["Hong"]),
                Mat = r["Mat"] == DBNull.Value ? 0 : Convert.ToInt32(r["Mat"])
            };
        }

        // New: Lưu mức phạt vào bảng `phat` (insert hoặc update)
        public bool SaveMucPhat(MucPhatDTO dto)
        {
            if (dto == null) return false;
            // Kiểm tra xem đã có bản ghi trong bảng phat hay chưa
            string sqlCount = "SELECT COUNT(*) AS cnt FROM phat";
            DataTable dt = DataProvider.ExecuteQuery(sqlCount);
            int count = 0;
            if (dt.Rows.Count > 0)
                count = Convert.ToInt32(dt.Rows[0]["cnt"]);

            var parameters = new Dictionary<string, object>
            {
                { "@Tre", dto.Tre },
                { "@Hong", dto.Hong },
                { "@Mat", dto.Mat }
            };

            if (count > 0)
            {
                string sql = "UPDATE phat SET Tre = @Tre, Hong = @Hong, Mat = @Mat";
                return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
            }
            else
            {
                string sql = "INSERT INTO phat (Tre, Hong, Mat) VALUES (@Tre, @Hong, @Mat)";
                return DataProvider.ExecuteNonQuery(sql, parameters) > 0;
            }
        }

    }
}

