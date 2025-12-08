using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class DauSach : BaseModuleUC
    {
        // Cache dữ liệu để sử dụng với LINQ
        private List<DauSachDTO> _allDauSach;
        private DataTable _currentDataTable;

        public DauSach()
        {
            InitializeComponent();
            CustomizeDataGridView();
        }

        public DauSach(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        private void CustomizeDataGridView()
        {
            // Tùy chỉnh header
            dgvDauSach.EnableHeadersVisualStyles = false;
            dgvDauSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvDauSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDauSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDauSach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDauSach.ColumnHeadersHeight = 40;
            
            // Tùy chỉnh rows
            dgvDauSach.RowTemplate.Height = 35;
            dgvDauSach.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDauSach.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
            dgvDauSach.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDauSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            
            // Border
            dgvDauSach.BorderStyle = BorderStyle.None;
            dgvDauSach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDauSach.GridColor = Color.FromArgb(224, 224, 224);
            
            // Thêm tooltip
            dgvDauSach.ShowCellToolTips = true;
        }

        #region Override Methods

        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Bạn không có quyền thêm đầu sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DauSachDialog dialog = new DauSachDialog("ADD", 0);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Thêm đầu sách thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        public override void OnEdit()
        {
            if (!CoQuyenSua)
            {
                MessageBox.Show("Bạn không có quyền sửa đầu sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đầu sách để sửa!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
            DauSachDialog dialog = new DauSachDialog("EDIT", selectedDauSachID);
            
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Sửa đầu sách thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Bạn không có quyền xóa đầu sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đầu sách để xóa!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // LINQ: Lấy thông tin đầu sách được chọn
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
            string tenDauSach = dgvDauSach.SelectedRows[0].Cells["TenDauSach"].Value?.ToString() ?? "";
            
            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa đầu sách:\n\"{tenDauSach}\"?", 
                "Xác nhận xóa", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
                
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    bool success = DauSachBUS.Instance.DeleteDauSach(selectedDauSachID);
                    if (success)
                    {
                        MessageBox.Show("Xóa đầu sách thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đầu sách thất bại!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void OnDetails()
        {
            if (!CoQuyenXem)
            {
                MessageBox.Show("Bạn không có quyền xem chi tiết đầu sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đầu sách để xem chi tiết!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
            DauSachDialog dialog = new DauSachDialog("DETAILS", selectedDauSachID);
            dialog.ShowDialog();
        }

        public override void LoadData()
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Tải tất cả dữ liệu
                _currentDataTable = DauSachBUS.Instance.GetAllDauSach();
            }
            else
            {
                // Tìm kiếm theo từ khóa
                _currentDataTable = DauSachBUS.Instance.SearchDauSach(searchTerm);
            }

            // Bind dữ liệu lên DataGridView
            dgvDauSach.DataSource = _currentDataTable;
            
            // Đổi tên cột hiển thị
            CustomizeColumns();
            
            // Cập nhật thông tin thống kê
            UpdateStatistics();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Tùy chỉnh cột hiển thị
        /// </summary>
        private void CustomizeColumns()
        {
            if (dgvDauSach.Columns.Contains("MaDauSach"))
            {
                dgvDauSach.Columns["MaDauSach"].HeaderText = "Mã đầu sách";
                dgvDauSach.Columns["MaDauSach"].Width = 100;
            }
            if (dgvDauSach.Columns.Contains("TenDauSach"))
            {
                dgvDauSach.Columns["TenDauSach"].HeaderText = "Tên đầu sách";
                dgvDauSach.Columns["TenDauSach"].Width = 250;
            }
            if (dgvDauSach.Columns.Contains("NhaXuatBan"))
            {
                dgvDauSach.Columns["NhaXuatBan"].HeaderText = "Nhà xuất bản";
                dgvDauSach.Columns["NhaXuatBan"].Width = 200;
            }
            if (dgvDauSach.Columns.Contains("NamXuatBan"))
            {
                dgvDauSach.Columns["NamXuatBan"].HeaderText = "Năm XB";
                dgvDauSach.Columns["NamXuatBan"].Width = 80;
            }
            if (dgvDauSach.Columns.Contains("NgonNgu"))
            {
                dgvDauSach.Columns["NgonNgu"].HeaderText = "Ngôn ngữ";
                dgvDauSach.Columns["NgonNgu"].Width = 120;
            }
            if (dgvDauSach.Columns.Contains("SoLuong"))
            {
                dgvDauSach.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvDauSach.Columns["SoLuong"].Width = 90;
            }
            
            // Ẩn cột không cần thiết
            if (dgvDauSach.Columns.Contains("HinhAnh"))
                dgvDauSach.Columns["HinhAnh"].Visible = false;
            if (dgvDauSach.Columns.Contains("TenTacGia"))
                dgvDauSach.Columns["TenTacGia"].Visible = false;

            // LINQ: Thêm tooltip cho từng dòng
            foreach (DataGridViewRow row in dgvDauSach.Rows)
            {
                if (row.Cells["TenDauSach"].Value != null)
                {
                    row.Cells["TenDauSach"].ToolTipText = "Nhấn đúp để xem danh sách sách";
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin thống kê - sử dụng LINQ
        /// </summary>
        private void UpdateStatistics()
        {
            if (_currentDataTable == null || _currentDataTable.Rows.Count == 0)
                return;

            // LINQ: Thống kê từ DataTable
            int tongDauSach = _currentDataTable.Rows.Count;
            
            int tongSoLuong = _currentDataTable.AsEnumerable()
                .Sum(row => row.Field<int>("SoLuong"));

            // LINQ: Đếm số đầu sách hết trong kho
            int hetHang = _currentDataTable.AsEnumerable()
                .Count(row => row.Field<int>("SoLuong") == 0);

            // LINQ: Lấy danh sách ngôn ngữ duy nhất
            var ngonNguList = _currentDataTable.AsEnumerable()
                .Select(row => row.Field<string>("NgonNgu"))
                .Distinct()
                .ToList();

            Console.WriteLine($"Tổng đầu sách: {tongDauSach}, Tổng số lượng: {tongSoLuong}, Hết hàng: {hetHang}");
            Console.WriteLine($"Ngôn ngữ: {string.Join(", ", ngonNguList)}");
        }

        /// <summary>
        /// Lọc dữ liệu trên UI với LINQ (không gọi lại database)
        /// </summary>
        private void FilterDataOnUI(string keyword)
        {
            if (_currentDataTable == null)
                return;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvDauSach.DataSource = _currentDataTable;
                return;
            }

            string searchTerm = keyword.ToLower();

            // LINQ: Lọc DataTable
            var filteredRows = _currentDataTable.AsEnumerable()
                .Where(row =>
                    row.Field<string>("TenDauSach")?.ToLower().Contains(searchTerm) == true ||
                    row.Field<string>("NhaXuatBan")?.ToLower().Contains(searchTerm) == true ||
                    row.Field<string>("NgonNgu")?.ToLower().Contains(searchTerm) == true ||
                    row.Field<int>("NamXuatBan").ToString().Contains(searchTerm));

            // LINQ: Tạo DataTable mới từ kết quả lọc
            if (filteredRows.Any())
            {
                DataTable filteredTable = filteredRows.CopyToDataTable();
                dgvDauSach.DataSource = filteredTable;
            }
            else
            {
                dgvDauSach.DataSource = _currentDataTable.Clone(); // Empty table
            }

            CustomizeColumns();
        }

        /// <summary>
        /// Sắp xếp dữ liệu với LINQ
        /// </summary>
        private void SortData(string columnName, bool ascending)
        {
            if (_currentDataTable == null)
                return;

            // LINQ: Sắp xếp DataTable
            IEnumerable<DataRow> sortedRows;
            
            if (ascending)
            {
                sortedRows = _currentDataTable.AsEnumerable()
                    .OrderBy(row => row[columnName]);
            }
            else
            {
                sortedRows = _currentDataTable.AsEnumerable()
                    .OrderByDescending(row => row[columnName]);
            }

            if (sortedRows.Any())
            {
                DataTable sortedTable = sortedRows.CopyToDataTable();
                dgvDauSach.DataSource = sortedTable;
                CustomizeColumns();
            }
        }

        /// <summary>
        /// Lấy danh sách mã đầu sách được chọn - sử dụng LINQ
        /// </summary>
        private List<int> GetSelectedDauSachIDs()
        {
            // LINQ: Lấy danh sách mã từ các dòng được chọn
            return dgvDauSach.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => Convert.ToInt32(row.Cells["MaDauSach"].Value))
                .ToList();
        }

        #endregion

        #region Event Handlers

        private void DauSach_Load_1(object sender, EventArgs e)
        {
            Console.WriteLine("DauSach Loaded");
            LoadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.SuppressKeyPress = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
        
        private void dgvDauSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int maDauSach = Convert.ToInt32(dgvDauSach.Rows[e.RowIndex].Cells["MaDauSach"].Value);
                    string tenDauSach = dgvDauSach.Rows[e.RowIndex].Cells["TenDauSach"].Value.ToString();
                    
                    DanhSachSachDialog dialog = new DanhSachSachDialog(maDauSach, tenDauSach);
                    dialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
