using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.DAO
{
    public class NhomQuyenDAO
    {
        private static NhomQuyenDAO instance;

        public static NhomQuyenDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomQuyenDAO();
                return instance;
            }
        }

        private NhomQuyenDAO() { }

        /// <summary>
        /// Lấy tất cả nhóm quyền
        /// </summary>
        public List<NhomQuyenDTO> GetAllNhomQuyen()
        {
            List<NhomQuyenDTO> list = new List<NhomQuyenDTO>();

            string query = "SELECT MANQ, TENNQ FROM nhom_quyen ORDER BY MANQ";
            DataTable dt = DataProvider.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhomQuyenDTO
                {
                    MaNhomQuyen = Convert.ToInt32(row["MANQ"]),
                    TenNhomQuyen = row["TENNQ"].ToString()
                });
            }

            return list;
        }

        /// <summary>
        /// Lấy tất cả chức năng
        /// </summary>
        public List<ChucNangDTO> GetAllChucNang()
        {
            List<ChucNangDTO> list = new List<ChucNangDTO>();

            string query = "SELECT MACN, TENCN FROM chuc_nang ORDER BY MACN";
            DataTable dt = DataProvider.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChucNangDTO
                {
                    MaChucNang = Convert.ToInt32(row["MACN"]),
                    TenChucNang = row["TENCN"].ToString()
                });
            }

            return list;
        }

        /// <summary>
        /// Lấy quyền của một nhóm quyền trên tất cả chức năng
        /// </summary>
        public List<QuyenChucNangDTO> GetQuyenByNhomQuyen(int maNhomQuyen)
        {
            List<QuyenChucNangDTO> list = new List<QuyenChucNangDTO>();

            var danhSachChucNang = GetAllChucNang();

            foreach (var cn in danhSachChucNang)
            {
                var quyen = new QuyenChucNangDTO
                {
                    MaNhomQuyen = maNhomQuyen,
                    MaChucNang = cn.MaChucNang,
                    TenChucNang = cn.TenChucNang,
                    QuyenXem = false,
                    QuyenThem = false,
                    QuyenSua = false,
                    QuyenXoa = false
                };

                string queryCheck = @"SELECT HanhDong FROM chucnang_nhomquyen 
                                      WHERE MaNhomQuyen = @MaNQ AND MaChucNang = @MaCN";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNQ", maNhomQuyen },
                    { "@MaCN", cn.MaChucNang }
                };

                DataTable dt = DataProvider.ExecuteQuery(queryCheck, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    string hanhDong = row["HanhDong"].ToString().ToUpper();
                    switch (hanhDong)
                    {
                        case "XEM": quyen.QuyenXem = true; break;
                        case "THEM": quyen.QuyenThem = true; break;
                        case "SUA": quyen.QuyenSua = true; break;
                        case "XOA": quyen.QuyenXoa = true; break;
                    }
                }

                list.Add(quyen);
            }

            return list;
        }

        /// <summary>
        /// Cập nhật quyền cho một nhóm quyền trên một chức năng
        /// </summary>
        public bool UpdateQuyen(int maNhomQuyen, int maChucNang, string hanhDong, bool coQuyen)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@MaNQ", maNhomQuyen },
                { "@MaCN", maChucNang },
                { "@HanhDong", hanhDong.ToUpper() }
            };

            if (coQuyen)
            {
                string checkQuery = @"SELECT COUNT(*) FROM chucnang_nhomquyen 
                                      WHERE MaNhomQuyen = @MaNQ AND MaChucNang = @MaCN AND HanhDong = @HanhDong";
                int count = Convert.ToInt32(DataProvider.ExecuteScalar(checkQuery, parameters));

                if (count == 0)
                {
                    string insertQuery = @"INSERT INTO chucnang_nhomquyen (MaNhomQuyen, MaChucNang, HanhDong) 
                                           VALUES (@MaNQ, @MaCN, @HanhDong)";
                    return DataProvider.ExecuteNonQuery(insertQuery, parameters) > 0;
                }
                return true;
            }
            else
            {
                string deleteQuery = @"DELETE FROM chucnang_nhomquyen 
                                       WHERE MaNhomQuyen = @MaNQ AND MaChucNang = @MaCN AND HanhDong = @HanhDong";
                DataProvider.ExecuteNonQuery(deleteQuery, parameters);
                return true;
            }
        }

        /// <summary>
        /// Cập nhật tất cả quyền cho một nhóm quyền trên một chức năng
        /// </summary>
        public bool UpdateQuyenChucNang(QuyenChucNangDTO quyen)
        {
            try
            {
                UpdateQuyen(quyen.MaNhomQuyen, quyen.MaChucNang, "XEM", quyen.QuyenXem);
                UpdateQuyen(quyen.MaNhomQuyen, quyen.MaChucNang, "THEM", quyen.QuyenThem);
                UpdateQuyen(quyen.MaNhomQuyen, quyen.MaChucNang, "SUA", quyen.QuyenSua);
                UpdateQuyen(quyen.MaNhomQuyen, quyen.MaChucNang, "XOA", quyen.QuyenXoa);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Thêm nhóm quyền mới
        /// </summary>
        public int InsertNhomQuyen(string tenNhomQuyen)
        {
            string query = "INSERT INTO nhom_quyen (TENNQ) VALUES (@TenNQ)";
            var parameters = new Dictionary<string, object>
            {
                { "@TenNQ", tenNhomQuyen }
            };

            int result = DataProvider.ExecuteNonQuery(query, parameters);
            
            if (result > 0)
            {
                object lastId = DataProvider.ExecuteScalar("SELECT LAST_INSERT_ID()", null);
                return Convert.ToInt32(lastId);
            }

            return -1;
        }

        /// <summary>
        /// Xóa nhóm quyền và tất cả quyền liên quan
        /// </summary>
        public bool DeleteNhomQuyen(int maNhomQuyen)
        {
            try
            {
                string deleteQuyen = "DELETE FROM chucnang_nhomquyen WHERE MaNhomQuyen = @MaNQ";
                var param1 = new Dictionary<string, object> { { "@MaNQ", maNhomQuyen } };
                DataProvider.ExecuteNonQuery(deleteQuyen, param1);

                string deleteNhom = "DELETE FROM nhom_quyen WHERE MANQ = @MaNQ";
                return DataProvider.ExecuteNonQuery(deleteNhom, param1) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy nhóm quyền theo mã
        /// </summary>
        public NhomQuyenDTO GetNhomQuyenById(int maNhomQuyen)
        {
            string query = "SELECT MANQ, TENNQ FROM nhom_quyen WHERE MANQ = @MaNQ";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNQ", maNhomQuyen }
            };

            DataTable dt = DataProvider.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var nhomQuyen = new NhomQuyenDTO
                {
                    MaNhomQuyen = Convert.ToInt32(row["MANQ"]),
                    TenNhomQuyen = row["TENNQ"].ToString()
                };

                nhomQuyen.DanhSachQuyen = GetQuyenByNhomQuyen(maNhomQuyen);

                return nhomQuyen;
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra quyền của một nhóm quyền trên một chức năng
        /// Hỗ trợ tìm kiếm linh hoạt (LIKE) để tránh lỗi do tên không khớp chính xác
        /// </summary>
        public bool KiemTraQuyen(int maNhomQuyen, string tenChucNang, string hanhDong)
        {
            // Chuẩn hóa tên chức năng: bỏ dấu cách, chuyển thường
            string tenCNPattern = "%" + tenChucNang.Replace(" ", "%") + "%";
            
            string query = @"SELECT COUNT(*) FROM chucnang_nhomquyen cnq
                             JOIN chuc_nang cn ON cnq.MaChucNang = cn.MACN
                             WHERE cnq.MaNhomQuyen = @MaNQ 
                             AND (cn.TENCN = @TenCN OR cn.TENCN LIKE @TenCNPattern)
                             AND cnq.HanhDong = @HanhDong";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNQ", maNhomQuyen },
                { "@TenCN", tenChucNang },
                { "@TenCNPattern", tenCNPattern },
                { "@HanhDong", hanhDong.ToUpper() }
            };

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(query, parameters));
            return count > 0;
        }

        /// <summary>
        /// Kiểm tra có ít nhất 1 quyền trên chức năng không
        /// Hỗ trợ tìm kiếm linh hoạt (LIKE) để tránh lỗi do tên không khớp chính xác
        /// </summary>
        public bool CoItNhatMotQuyen(int maNhomQuyen, string tenChucNang)
        {
            // Chuẩn hóa tên chức năng: bỏ dấu cách, chuyển thường
            string tenCNPattern = "%" + tenChucNang.Replace(" ", "%") + "%";
            
            string query = @"SELECT COUNT(*) FROM chucnang_nhomquyen cnq
                             JOIN chuc_nang cn ON cnq.MaChucNang = cn.MACN
                             WHERE cnq.MaNhomQuyen = @MaNQ 
                             AND (cn.TENCN = @TenCN OR cn.TENCN LIKE @TenCNPattern)";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNQ", maNhomQuyen },
                { "@TenCN", tenChucNang },
                { "@TenCNPattern", tenCNPattern }
            };

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(query, parameters));
            return count > 0;
        }
    }
}
