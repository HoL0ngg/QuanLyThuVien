using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.Components;
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
        private List<DauSachDTO> _allDauSach;
        private DataTable _currentDataTable;

        public DauSach()
        {
            InitializeComponent();
            CustomizeDataGridView();
            InitializeActionButtons();
        }

        public DauSach(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        /// <summary>
        /// Khởi tạo ActionButtonsUC
        /// </summary>
        private void InitializeActionButtons()
        {
            // Tạo panel chứa ActionButtons ở phía trên
            Panel panelTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(10, 5, 10, 5)
            };
            
            this.Controls.Add(panelTop);
            panelTop.BringToFront();
            
            // Tạo ActionButtons
            CreateActionButtons(panelTop, DockStyle.Left);
        }

        private void CustomizeDataGridView()
        {
            dgvDauSach.EnableHeadersVisualStyles = false;
            dgvDauSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvDauSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDauSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDauSach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDauSach.ColumnHeadersHeight = 40;
            
            dgvDauSach.RowTemplate.Height = 35;
            dgvDauSach.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDauSach.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
            dgvDauSach.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDauSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            
            dgvDauSach.BorderStyle = BorderStyle.None;
            dgvDauSach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDauSach.GridColor = Color.FromArgb(224, 224, 224);
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
                _currentDataTable = DauSachBUS.Instance.GetAllDauSach();
            }
            else
            {
                _currentDataTable = DauSachBUS.Instance.SearchDauSach(searchTerm);
            }

            dgvDauSach.DataSource = _currentDataTable;
            CustomizeColumns();
            UpdateStatistics();
        }

        #endregion

        #region Private Methods

        private void CustomizeColumns()
        {
            var colMa = new DataGridViewTextBoxColumn { Name = "MaDauSach", HeaderText = "Mã đầu sách", DataPropertyName = "MaDauSach" };
            var colTenDauSach = new DataGridViewTextBoxColumn { Name = "TenDauSach", HeaderText = "Tên đầu sách", DataPropertyName = "TenDauSach" };
            var colNhaXuatBan = new DataGridViewTextBoxColumn { Name = "NhaXuatBan", HeaderText = "Nhà xuất bản", DataPropertyName = "NhaXuatBan" };
            var colNamXuatBan = new DataGridViewTextBoxColumn { Name = "NamXuatBan", HeaderText = "Năm xuất bản", DataPropertyName = "NamXuatBan" };
            var colNgonNgu = new DataGridViewTextBoxColumn { Name = "NgonNgu", HeaderText = "Ngôn ngữ", DataPropertyName = "NgonNgu" };
            var colSoLuong = new DataGridViewTextBoxColumn { Name = "SoLuong", HeaderText = "Số lượng", DataPropertyName = "SoLuong" };

            dgvDauSach.Columns.AddRange(new DataGridViewColumn[] { colMa, colTenDauSach, colNhaXuatBan, colNamXuatBan, colNgonNgu, colSoLuong });
            // LINQ: Thêm tooltip cho từng dòng
            foreach (DataGridViewRow row in dgvDauSach.Rows)
            {
                if (row.Cells["TenDauSach"].Value != null)
                {
                    row.Cells["TenDauSach"].ToolTipText = "Nhấn đúp để xem danh sách sách";
                }
            }
        }

        private void UpdateStatistics()
        {
            if (_currentDataTable == null || _currentDataTable.Rows.Count == 0)
                return;

            int tongDauSach = _currentDataTable.Rows.Count;
            
            int tongSoLuong = _currentDataTable.AsEnumerable()
                .Sum(row => row.Field<int>("SoLuong"));

            int hetHang = _currentDataTable.AsEnumerable()
                .Count(row => row.Field<int>("SoLuong") == 0);

            var ngonNguList = _currentDataTable.AsEnumerable()
                .Select(row => row.Field<string>("NgonNgu"))
                .Distinct()
                .ToList();

            Console.WriteLine($"Tổng đầu sách: {tongDauSach}, Tổng số lượng: {tongSoLuong}, Hết hàng: {hetHang}");
        }

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

            var filteredRows = _currentDataTable.AsEnumerable()
                .Where(row =>
                    row.Field<string>("TenDauSach")?.ToLower().Contains(searchTerm) == true ||
                    row.Field<string>("NhaXuatBan")?.ToLower().Contains(searchTerm) == true ||
                    row.Field<string>("NgonNgu")?.ToLower().Contains(searchTerm) == true ||
                    row.Field<int>("NamXuatBan").ToString().Contains(searchTerm));

            if (filteredRows.Any())
            {
                DataTable filteredTable = filteredRows.CopyToDataTable();
                dgvDauSach.DataSource = filteredTable;
            }
            else
            {
                dgvDauSach.DataSource = _currentDataTable.Clone();
            }

            CustomizeColumns();
        }

        private List<int> GetSelectedDauSachIDs()
        {
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
