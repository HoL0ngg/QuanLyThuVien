using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLyThuVien.BUS
{
    public class DauSachBUS
    {
        // Singleton Pattern
        private static DauSachBUS _instance;
        public static DauSachBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DauSachBUS();
                return _instance;
            }
            private set { _instance = value; }
        }
        private DauSachBUS() { }

        #region Lấy dữ liệu cơ bản

        /// <summary>
        /// Lấy tất cả đầu sách (DataTable)
        /// </summary>
        public DataTable GetAllDauSach()
        {
            return DauSachDAO.Instance.GetAllDauSach();
        }

        /// <summary>
        /// Lấy tất cả đầu sách (List DTO)
        /// </summary>
        public List<DauSachDTO> GetAllDauSachList()
        {
            return DauSachDAO.Instance.GetAllDauSachList();
        }

        /// <summary>
        /// Lấy đầu sách theo ID
        /// </summary>
        public DauSachDTO GetDauSachByID(int dauSachID)
        {
            if (dauSachID <= 0)
                return null;
            return DauSachDAO.Instance.GetDauSachByID(dauSachID);
        }

        /// <summary>
        /// Lấy danh sách tác giả của đầu sách
        /// </summary>
        public List<TacGiaDTO> GetTacGiaByDauSachID(int dauSachID)
        {
            if (dauSachID <= 0)
                return new List<TacGiaDTO>();
            return DauSachDAO.Instance.GetTacGiaByDauSachID(dauSachID);
        }
        public bool CapNhatSoLuongTon(int maDauSach, int soLuong)
        {
            if (maDauSach <= 0)
                throw new ArgumentException("Mã đầu sách không hợp lệ.");

            if (soLuong < 0)
            {
                DauSachDTO currentBook = GetDauSachByID(maDauSach);

                if (currentBook == null)
                {
                    throw new Exception("Không tìm thấy Đầu sách để cập nhật tồn kho.");
                }

                if (currentBook.SoLuong + soLuong < 0)
                {
                    throw new Exception($"Không thể giảm tồn kho cho Đầu sách ID {maDauSach} vì số lượng hiện tại ({currentBook.SoLuong}) không đủ.");
                }
            }

            return DauSachDAO.Instance.UpdateSoLuongTonKho(maDauSach, soLuong);
        }
        public bool CapNhatDonGia(int maDauSach, double donGia)
        {
            if (maDauSach <= 0 || donGia <= 0)
                throw new ArgumentException("Thông tin Mã Đầu Sách hoặc Đơn Giá không hợp lệ.");
            return DauSachDAO.Instance.UpdateGiaDauSach(maDauSach, donGia);
        }
        #endregion

        #region Tìm kiếm với LINQ

        /// <summary>
        /// Tìm kiếm đầu sách theo từ khóa (Database)
        /// </summary>
        public DataTable SearchDauSach(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllDauSach();
                
            return DauSachDAO.Instance.SearchDauSach(keyword.Trim());
        }

        /// <summary>
        /// Tìm kiếm đầu sách nâng cao với LINQ (trên List)
        /// </summary>
        public List<DauSachDTO> SearchDauSachAdvanced(string keyword)
        {
            var allDauSach = GetAllDauSachList();
            
            if (string.IsNullOrWhiteSpace(keyword))
                return allDauSach;

            string searchTerm = keyword.ToLower().Trim();

            // LINQ: Tìm kiếm theo nhiều trường
            return allDauSach
                .Where(ds => 
                    ds.TenDauSach.ToLower().Contains(searchTerm) ||
                    ds.NgonNgu.ToLower().Contains(searchTerm) ||
                    ds.NamXuatBan.ToString().Contains(searchTerm))
                .OrderBy(ds => ds.TenDauSach)
                .ToList();
        }

        /// <summary>
        /// Lọc đầu sách theo năm xuất bản
        /// </summary>
        public List<DauSachDTO> FilterByNamXuatBan(int namXuatBan)
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lọc theo năm
            return allDauSach
                .Where(ds => ds.NamXuatBan == namXuatBan)
                .OrderByDescending(ds => ds.SoLuong)
                .ToList();
        }

        /// <summary>
        /// Lọc đầu sách theo khoảng năm xuất bản
        /// </summary>
        public List<DauSachDTO> FilterByNamXuatBanRange(int tuNam, int denNam)
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lọc theo khoảng năm
            return allDauSach
                .Where(ds => ds.NamXuatBan >= tuNam && ds.NamXuatBan <= denNam)
                .OrderBy(ds => ds.NamXuatBan)
                .ThenBy(ds => ds.TenDauSach)
                .ToList();
        }

        /// <summary>
        /// Lọc đầu sách theo ngôn ngữ
        /// </summary>
        public List<DauSachDTO> FilterByNgonNgu(string ngonNgu)
        {
            var allDauSach = GetAllDauSachList();
            
            if (string.IsNullOrWhiteSpace(ngonNgu))
                return allDauSach;

            // LINQ: Lọc theo ngôn ngữ
            return allDauSach
                .Where(ds => ds.NgonNgu.Equals(ngonNgu, StringComparison.OrdinalIgnoreCase))
                .OrderBy(ds => ds.TenDauSach)
                .ToList();
        }

        /// <summary>
        /// Lọc đầu sách còn trong kho (số lượng > 0)
        /// </summary>
        public List<DauSachDTO> GetDauSachConTrongKho()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lọc sách còn trong kho
            return allDauSach
                .Where(ds => ds.SoLuong > 0)
                .OrderByDescending(ds => ds.SoLuong)
                .ToList();
        }

        /// <summary>
        /// Lọc đầu sách hết trong kho
        /// </summary>
        public List<DauSachDTO> GetDauSachHetTrongKho()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lọc sách hết trong kho
            return allDauSach
                .Where(ds => ds.SoLuong == 0)
                .OrderBy(ds => ds.TenDauSach)
                .ToList();
        }

        #endregion

        #region Thống kê với LINQ

        /// <summary>
        /// Đếm tổng số đầu sách
        /// </summary>
        public int DemTongDauSach()
        {
            var allDauSach = GetAllDauSachList();
            return allDauSach.Count();
        }

        /// <summary>
        /// Đếm tổng số lượng sách
        /// </summary>
        public int DemTongSoLuongSach()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Tính tổng số lượng
            return allDauSach.Sum(ds => ds.SoLuong);
        }

        /// <summary>
        /// Lấy danh sách ngôn ngữ có trong thư viện
        /// </summary>
        public List<string> GetDanhSachNgonNgu()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lấy danh sách ngôn ngữ duy nhất
            return allDauSach
                .Select(ds => ds.NgonNgu)
                .Distinct()
                .OrderBy(nn => nn)
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách năm xuất bản có trong thư viện
        /// </summary>
        public List<int> GetDanhSachNamXuatBan()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lấy danh sách năm duy nhất
            return allDauSach
                .Select(ds => ds.NamXuatBan)
                .Distinct()
                .OrderByDescending(nam => nam)
                .ToList();
        }

        /// <summary>
        /// Thống kê số đầu sách theo ngôn ngữ
        /// </summary>
        public Dictionary<string, int> ThongKeTheoNgonNgu()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Group by ngôn ngữ và đếm
            return allDauSach
                .GroupBy(ds => ds.NgonNgu)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()
                );
        }

        /// <summary>
        /// Thống kê số lượng sách theo ngôn ngữ
        /// </summary>
        public Dictionary<string, int> ThongKeSoLuongTheoNgonNgu()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Group by ngôn ngữ và tính tổng số lượng
            return allDauSach
                .GroupBy(ds => ds.NgonNgu)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(ds => ds.SoLuong)
                );
        }

        /// <summary>
        /// Thống kê số đầu sách theo năm xuất bản
        /// </summary>
        public Dictionary<int, int> ThongKeTheoNamXuatBan()
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Group by năm và đếm
            return allDauSach
                .GroupBy(ds => ds.NamXuatBan)
                .OrderByDescending(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()
                );
        }

        /// <summary>
        /// Lấy Top N đầu sách có số lượng nhiều nhất
        /// </summary>
        public List<DauSachDTO> GetTopDauSachNhieuNhat(int top = 10)
        {
            var allDauSach = GetAllDauSachList();
            
            // LINQ: Lấy top N theo số lượng
            return allDauSach
                .OrderByDescending(ds => ds.SoLuong)
                .Take(top)
                .ToList();
        }

        #endregion

        #region CRUD Operations

        /// <summary>
        /// Thêm đầu sách mới
        /// </summary>
        public bool AddDauSach(string tenDauSach, int maNXB, string hinhAnhPath, string namXuatBan, string ngonNgu, List<int> maTacGiaList)
        {
            // Validation với LINQ
            if (string.IsNullOrWhiteSpace(tenDauSach))
                throw new ArgumentException("Tên đầu sách không được để trống!");

            if (maNXB <= 0)
                throw new ArgumentException("Vui lòng chọn nhà xuất bản!");

            if (maTacGiaList == null || !maTacGiaList.Any())
                throw new ArgumentException("Sách phải có ít nhất 1 tác giả!");

            // LINQ: Loại bỏ mã tác giả trùng lặp
            var uniqueTacGiaList = maTacGiaList.Distinct().ToList();

            return DauSachDAO.Instance.AddDauSach(
                tenDauSach.Trim(), 
                maNXB, 
                hinhAnhPath, 
                namXuatBan, 
                ngonNgu, 
                uniqueTacGiaList
            );
        }

        /// <summary>
        /// Cập nhật đầu sách
        /// </summary>
        public bool UpdateDauSach(int dauSachID, string tenDauSach, int maNXB, string hinhAnhPath, string namXuatBan, string ngonNgu, List<int> maTacGiaList)
        {
            // Validation
            if (dauSachID <= 0)
                throw new ArgumentException("Mã đầu sách không hợp lệ!");

            if (string.IsNullOrWhiteSpace(tenDauSach))
                throw new ArgumentException("Tên đầu sách không được để trống!");

            if (maNXB <= 0)
                throw new ArgumentException("Vui lòng chọn nhà xuất bản!");

            if (maTacGiaList == null || !maTacGiaList.Any())
                throw new ArgumentException("Sách phải có ít nhất 1 tác giả!");

            // LINQ: Loại bỏ mã tác giả trùng lặp
            var uniqueTacGiaList = maTacGiaList.Distinct().ToList();

            return DauSachDAO.Instance.UpdateDauSach(
                dauSachID,
                tenDauSach.Trim(), 
                maNXB, 
                hinhAnhPath, 
                namXuatBan, 
                ngonNgu, 
                uniqueTacGiaList
            );
        }

        /// <summary>
        /// Xóa đầu sách
        /// </summary>
        public bool DeleteDauSach(int dauSachID)
        {
            if (dauSachID <= 0)
                throw new ArgumentException("Mã đầu sách không hợp lệ!");

            return DauSachDAO.Instance.DeleteDauSach(dauSachID);
        }

        #endregion
    }
}