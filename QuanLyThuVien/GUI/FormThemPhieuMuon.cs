using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System.Drawing;
using QuanLyThuVien.DAO;

namespace QuanLyThuVien.GUI
{
    public partial class FormThemPhieuMuon : UserControl
    {
        public event Action CloseRequested;
        private BindingList<CTPhieuMuonDTO> ctList = new BindingList<CTPhieuMuonDTO>();
        private const string AddColumnName = "colAdd";
        private const string DeleteColumnName = "colDelete";

        // Cho phép truyền mã nhân viên hiện tại từ outside (nếu có)
        public int MaNhanVienHienTai { get; set; } = 0;

        public FormThemPhieuMuon()
        {
            InitializeComponent();
            InitializeTimSachGrid();
            InitializeChiTietGrid();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            this.Load += FormThemPhieuMuon_Load;
            btnThem.Click += BtnThem_Click;
            btnHuy.Click += BtnHuy_Click;
            btnTimSach.Click += BtnTimSach_Click;
            txtTuKhoaSach.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { BtnTimSach_Click(null, null); e.Handled = e.SuppressKeyPress = true; } };
            dgvKetQuaSach.CellContentClick += DgvKetQuaSach_CellContentClick;
            dgvCT.CellContentClick += DgvCT_CellContentClick;
        }

        private void FormThemPhieuMuon_Load(object sender, EventArgs e)
        {
            txtNgayMuon.Text = DateTime.Today.ToString("dd/MM/yyyy");
            dtpNgayTraDuKien.Value = DateTime.Today.AddDays(7);
            dgvCT.DataSource = ctList;
            AddButtonColumn(dgvCT, DeleteColumnName, "Xóa", "X", Color.Red);
        }

        private void BtnTimSach_Click(object sender, EventArgs e)
        {
            string keyword = txtTuKhoaSach.Text.Trim();
            DataTable dt = string.IsNullOrEmpty(keyword) ? DauSachBUS.Instance.GetAllDauSach() : DauSachBUS.Instance.SearchDauSach(keyword);
            
            if (dt == null || dt.Rows.Count == 0)
            {
                dgvKetQuaSach.DataSource = null;
                MessageBox.Show("Không tìm thấy sách phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvKetQuaSach.DataSource = dt;
            AddButtonColumn(dgvKetQuaSach, AddColumnName, "Thêm", "+", Color.DarkGreen);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // 1) Kiểm tra mã độc giả nhập hợp lệ
            if (txtMaDocGia == null || string.IsNullOrWhiteSpace(txtMaDocGia.Text))
            {
                MessageBox.Show("Vui lòng nhập mã độc giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGia?.Focus();
                return;
            }
            if (!int.TryParse(txtMaDocGia.Text.Trim(), out int maDocGia))
            {
                MessageBox.Show("Mã độc giả phải là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDocGia.Focus();
                return;
            }

            // 2) Kiểm tra tồn tại độc giả trong DB
            
            //if (!pmDAO.DocGiaExists(maDocGia))
            //{
            //    MessageBox.Show("Mã độc giả không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtMaDocGia.Focus();
            //    return;
            //}

            // 3) Kiểm tra danh sách sách mượn
            //if (ctList.Count == 0)
            //{
            //    MessageBox.Show("Vui lòng chọn ít nhất một sách để mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //try
            //{
            //    var phieu = new PhieuMuonDTO
            //    {
            //        NgayMuon = DateTime.Today,
            //        NgayTraDuKien = dtpNgayTraDuKien.Value,
            //        TrangThai = 1,
            //        MaDocGia = maDocGia,
            //        MaNhanVien = MaNhanVienHienTai,
            //        CTPM = ctList.ToList()
            //    };

            //    //int newId = pmDAO.CreateWithDetails(phieu);
            //    if (newId > 0)
            //    {
            //        MessageBox.Show($"Tạo phiếu mượn thành công (Mã: {newId}).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        CloseRequested?.Invoke();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không thể tạo phiếu mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi tạo phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            if (ctList.Count > 0)
            {
                var confirm = MessageBox.Show(
                    "Bạn có chắc muốn hủy? Tất cả sách đã chọn sẽ bị xóa.",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                
                if (confirm != DialogResult.Yes) return;
            }

            ctList.Clear();

            txtTuKhoaSach.Clear();
            txtNgayMuon.Text = DateTime.Today.ToString("dd/MM/yyyy");
            dtpNgayTraDuKien.Value = DateTime.Today.AddDays(7);

            CloseRequested?.Invoke();
        }

        private void InitializeTimSachGrid()
        {
            dgvKetQuaSach.AutoGenerateColumns = false;
            dgvKetQuaSach.Columns.Clear();

            var colMaDauSach = new DataGridViewTextBoxColumn { Name = "MaDauSach", HeaderText = "Mã đầu sách", DataPropertyName = "MaDauSach" };
            var colTenDauSach = new DataGridViewTextBoxColumn { Name = "TenDauSach", HeaderText = "Tên đầu sách ", DataPropertyName = "TenDauSach" };
            var colNhaXuatBan = new DataGridViewTextBoxColumn { Name = "NhaXuatBan", HeaderText = "Nhà xuất bản", DataPropertyName = "NhaXuatBan" };
            var colNamXuatBan = new DataGridViewTextBoxColumn { Name = "NamXuatBan", HeaderText = "Năm xuất bản", DataPropertyName = "NamXuatBan" };
            var colNgonNgu = new DataGridViewTextBoxColumn { Name = "NgonNgu", HeaderText = "Ngôn ngữ", DataPropertyName = "NgonNgu" };
            var colSoLuong = new DataGridViewTextBoxColumn { Name = "SoLuong", HeaderText = "Số lượng", DataPropertyName = "SoLuong" };

            dgvKetQuaSach.Columns.AddRange(new DataGridViewColumn[] { colMaDauSach, colTenDauSach, colNhaXuatBan, colNamXuatBan, colNgonNgu, colSoLuong });
            dgvKetQuaSach.ReadOnly = true;
            dgvKetQuaSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKetQuaSach.AllowUserToAddRows = false;
            dgvKetQuaSach.AllowUserToDeleteRows = false;
            ConfigureGrid(dgvCT);
        }

        private void InitializeChiTietGrid()
        {
            dgvCT.AutoGenerateColumns = false;
            dgvCT.Columns.Clear();

            var colMaDauSach = new DataGridViewTextBoxColumn { Name = "MaDauSach", HeaderText = "Mã đầu sách", DataPropertyName = "MaDauSach" };
            var colTenDauSach = new DataGridViewTextBoxColumn { Name = "TenDauSach", HeaderText = "Tên đầu sách ", DataPropertyName = "TenDauSach" };
            var colNhaXuatBan = new DataGridViewTextBoxColumn { Name = "NhaXuatBan", HeaderText = "Nhà xuất bản", DataPropertyName = "NhaXuatBan" };
            var colNamXuatBan = new DataGridViewTextBoxColumn { Name = "NamXuatBan", HeaderText = "Năm xuất bản", DataPropertyName = "NamXuatBan" };
            var colNgonNgu = new DataGridViewTextBoxColumn { Name = "NgonNgu", HeaderText = "Ngôn ngữ", DataPropertyName = "NgonNgu" };
         
            dgvCT.Columns.AddRange(new DataGridViewColumn[] { colMaDauSach, colTenDauSach, colNhaXuatBan, colNamXuatBan, colNgonNgu });
            dgvCT.ReadOnly = true;
            dgvCT.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCT.AllowUserToAddRows = false;
            dgvCT.AllowUserToDeleteRows = false;
            ConfigureGrid(dgvKetQuaSach);
        }

        private void DgvKetQuaSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvKetQuaSach.Columns[e.ColumnIndex].Name != AddColumnName) return;
            var row = dgvKetQuaSach.Rows[e.RowIndex];
            
            // Lấy mã đầu sách từ cột đã binding đúng
            int? maDauSach = null;
            if (row.Cells["MaDauSach"]?.Value != null && int.TryParse(row.Cells["MaDauSach"].Value.ToString(), out var id1)) 
                maDauSach = id1;
            
            if (!maDauSach.HasValue || ctList.Any(c => c.MaSach == maDauSach.Value)) return;
            
            ctList.Add(new CTPhieuMuonDTO
            {
                MaSach = maDauSach.Value,
                MaDauSach = maDauSach.Value,
                TenDauSach = row.Cells["TenDauSach"]?.Value?.ToString() ?? string.Empty,
                NhaXuatBan = row.Cells["NhaXuatBan"]?.Value?.ToString() ?? string.Empty,
                NamXuatBan = row.Cells["NamXuatBan"]?.Value != null && int.TryParse(row.Cells["NamXuatBan"].Value.ToString(), out var nam) ? nam : 0,
                NgonNgu = row.Cells["NgonNgu"]?.Value?.ToString() ?? string.Empty
            });
        }

        private void DgvCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCT.Columns[e.ColumnIndex].Name != DeleteColumnName) return;
            CTPhieuMuonDTO item = dgvCT.Rows[e.RowIndex].DataBoundItem as CTPhieuMuonDTO;
            if (item != null && MessageBox.Show($"Xóa sách mã {item.MaSach} khỏi danh sách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ctList.Remove(item);
        }

        private void AddButtonColumn(DataGridView grid, string name, string header, string text, Color color)
        {
            if (grid.Columns[name] != null) { grid.Columns[name].DisplayIndex = grid.Columns.Count - 1; return; }
            var col = new DataGridViewButtonColumn { Name = name, HeaderText = header, Text = text, UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells };
            grid.Columns.Add(col);
            col.DisplayIndex = grid.Columns.Count - 1;
        }

        private void ConfigureGrid(DataGridView grid)
        {
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            foreach (DataGridViewColumn c in grid.Columns)
            {
                if (c.Name == AddColumnName || c.Name == DeleteColumnName)
                {
                    c.FillWeight = 30;
                    c.DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, ForeColor = c.Name == DeleteColumnName ? Color.Red : Color.DarkGreen, SelectionForeColor = c.Name == DeleteColumnName ? Color.Red : Color.DarkGreen };
                }
                else c.FillWeight = 100;
            }
        }
    }
}
