using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class PhieuMuon : BaseModuleUC
    {
        private PhieuMuonBUS bus = new PhieuMuonBUS();
        private TaiKhoanDTO tk = new TaiKhoanDTO();
        private CTPhieuMuonDAO ctDAO = new CTPhieuMuonDAO();
        private FormThemPhieuMuon ucThemPhieu;
        private static readonly DateTime NgayMuonMacDinh = new DateTime(2000, 1, 1);

        public PhieuMuon(TaiKhoanDTO taikhoan)
        {
            InitializeComponent();
            bangPhieuMuon.CellClick += BangPhieuMuon_CellClick;
            bangPhieuMuon.CellFormatting += BangPhieuMuon_CellFormatting; 
            btnClearFilters.Click += BtnClearFilters_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            tk = taikhoan;
            ucThemPhieu = new FormThemPhieuMuon(tk)
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            ucThemPhieu.CloseRequested += UcThemPhieu_CloseRequested;
            this.Controls.Add(ucThemPhieu);
            ucThemPhieu.BringToFront();
        }

        private void InitializePhieuMuonGrid()
        {
            bangPhieuMuon.AutoGenerateColumns = false;
            bangPhieuMuon.Columns.Clear();

            var colMa = new DataGridViewTextBoxColumn { Name = "MaPhieuMuon", HeaderText = "Mã", DataPropertyName = "MaPhieuMuon", FillWeight = 70 };
            var colNgayMuon = new DataGridViewTextBoxColumn { Name = "NgayMuon", HeaderText = "Ngày mượn", DataPropertyName = "NgayMuon", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } };
            var colNgayTra = new DataGridViewTextBoxColumn { Name = "NgayTraDuKien", HeaderText = "Trả dự kiến", DataPropertyName = "NgayTraDuKien", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } };
            var colTrangThai = new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai" };
            var colMaDocGia = new DataGridViewTextBoxColumn { Name = "MaDocGia", HeaderText = "Mã độc giả", DataPropertyName = "MaDocGia", FillWeight = 60 };
            var colTenDocGia = new DataGridViewTextBoxColumn { Name = "TenDocGia", HeaderText = "Tên độc giả", DataPropertyName = "TenDocGia" };
            var colTenNhanVien = new DataGridViewTextBoxColumn { Name = "TenNhanVien", HeaderText = "Tên nhân viên", DataPropertyName = "TenNhanVien" };

            bangPhieuMuon.Columns.AddRange(new DataGridViewColumn[] { colMa, colNgayMuon, colNgayTra, colTrangThai, colMaDocGia, colTenDocGia, colTenNhanVien });
            bangPhieuMuon.ReadOnly = true;
            bangPhieuMuon.EditMode = DataGridViewEditMode.EditProgrammatically;
            bangPhieuMuon.AllowUserToAddRows = false;
            bangPhieuMuon.AllowUserToDeleteRows = false;
        }

        private void InitializeChiTietGrid()
        {
            bangCTPhieuMuon.AutoGenerateColumns = false;
            bangCTPhieuMuon.Columns.Clear();

            var colMaSach = new DataGridViewTextBoxColumn { Name = "MaSach", HeaderText = "Mã sách", DataPropertyName = "MaSach", FillWeight = 40 };
            var colMaDauSach = new DataGridViewTextBoxColumn { Name = "MaDauSach", HeaderText = "Mã đầu sách", DataPropertyName = "MaDauSach", FillWeight = 50 };
            var colTenDauSach = new DataGridViewTextBoxColumn { Name = "TenDauSach", HeaderText = "Tên đầu sách", DataPropertyName = "TenDauSach" };
            var colNXB = new DataGridViewTextBoxColumn { Name = "TenNXB", HeaderText = "Nhà xuất bản", DataPropertyName = "NhaXuatBan", FillWeight = 80 };
            var colNamXB = new DataGridViewTextBoxColumn { Name = "NamXuatBan", HeaderText = "Năm xuất bản", DataPropertyName = "NamXuatBan", FillWeight = 60 };
            var colNgonNgu = new DataGridViewTextBoxColumn { Name = "NgonNgu", HeaderText = "Ngôn ngữ", DataPropertyName = "NgonNgu", FillWeight = 60 };

            bangCTPhieuMuon.Columns.AddRange(new DataGridViewColumn[] { colMaSach, colMaDauSach, colTenDauSach, colNXB, colNamXB, colNgonNgu });

            // Style và khóa sửa
            bangCTPhieuMuon.RowHeadersVisible = false;
            bangCTPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bangCTPhieuMuon.ReadOnly = true;
            bangCTPhieuMuon.EditMode = DataGridViewEditMode.EditProgrammatically;
            bangCTPhieuMuon.AllowUserToAddRows = false;
            bangCTPhieuMuon.AllowUserToDeleteRows = false;
        }

        private void ConfigureGrid()
        {
            bangPhieuMuon.RowHeadersVisible = false;
            bangPhieuMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bangPhieuMuon.MultiSelect = false;
            bangPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn c in bangPhieuMuon.Columns)
            {
                if (c.FillWeight == 0) c.FillWeight = 100;
            }
        }

        private static string MapTrangThai(object value)
        {
            if (value == null || !int.TryParse(value.ToString(), out int v)) return string.Empty;
            switch (v)
            {
                case 1: return "Chưa Trả";
                case 2: return "Đã Trả";
                case 3: return "Trả Muộn";
                default: return v.ToString();
            }
        }

        private void BangPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (bangPhieuMuon.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                e.Value = MapTrangThai(e.Value);
                e.FormattingApplied = true;
            }
        }

        private void UcThemPhieu_CloseRequested()
        {
            // Quay trở lại giao diện danh sách
            ToggleView(false);
            LoadData();
        }

        // Mở form thêm phiếu mượn
        public override void OnAdd()
        {
            // Ẩn giao diện danh sách, hiển thị UC thêm
            ToggleView(true);
        }
        public override void OnEdit() { }

        public override void OnDelete()
        {
            if (bangPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var idCell = bangPhieuMuon.CurrentRow.Cells["MaPhieuMuon"];
            if (idCell?.Value == null) return;
            if (!int.TryParse(idCell.Value.ToString(), out int id)) return;

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa phiếu mượn có ID {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                if (bus.Delete(id))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void OnDetails() { }

        public override void LoadData()
        {
            try
            {
                InitializePhieuMuonGrid();
                bangPhieuMuon.DataSource = bus.GetAll();
                ConfigureGrid();

                InitializeChiTietGrid();
                bangCTPhieuMuon.DataSource = null; // clear chi tiết khi reload
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleView(bool showThem)
        {
            groupBoxInfo.Visible = !showThem;
            addPhieuMuon.Visible = !showThem;
            splitContainerMain.Visible = !showThem;

            ucThemPhieu.Visible = showThem;
            if (showThem)
            {
                ucThemPhieu.BringToFront();
            }
            else
            {
                ucThemPhieu.SendToBack();
            }
        }

        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            if (cmbTrangThai != null && cmbTrangThai.Items.Count > 0)
                cmbTrangThai.SelectedIndex = 0; 
            dtpNgayMuon.Value = NgayMuonMacDinh; 
            dtpNgayTraDuKien.Value = DateTime.Today; 
            LoadData();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OnAdd();
        }

        private void GroupBoxInfo_Enter(object sender, EventArgs e) { }

        private void BangPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = bangPhieuMuon.Rows[e.RowIndex];
                if (row.Cells["MaPhieuMuon"].Value == null) return;
                int ma = Convert.ToInt32(row.Cells["MaPhieuMuon"].Value);
                var ctList = ctDAO.GetByMaPhieuMuon(ma);
                InitializeChiTietGrid();
                bangCTPhieuMuon.DataSource = ctList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtMaPhieuMuon.Text = string.Empty;
            dtpNgayMuon.Value = NgayMuonMacDinh; // reset về 01/01/2000
            dtpNgayTraDuKien.Value = DateTime.Today;
            cmbTrangThai.SelectedIndex = 0;
            txtMaDocGia.Text = string.Empty;
            txtMaNhanVien.Text = string.Empty;
            LoadData();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            int? maPhieu = null; if (int.TryParse(txtMaPhieuMuon.Text.Trim(), out var mp)) maPhieu = mp;
            DateTime? ngayFrom = dtpNgayMuon.Value.Date;
            DateTime? ngayTo = dtpNgayTraDuKien.Value.Date;
            if (ngayFrom > ngayTo) {
                (ngayTo, ngayFrom) = (ngayFrom, ngayTo);
            }
            int? trangThai = null;
            if (cmbTrangThai.SelectedItem != null && cmbTrangThai.SelectedItem.ToString() != "Tất cả")
            {
                switch (cmbTrangThai.SelectedItem.ToString())
                {
                    case "Chưa trả": trangThai = 1; break;
                    case "Đã trả": trangThai = 2; break;
                    case "Trả muộn": trangThai = 3; break;
                }
            }
            int? maDocGia = null; if (int.TryParse(txtMaDocGia.Text.Trim(), out var mdg)) maDocGia = mdg;
            int? maNhanVien = null; if (int.TryParse(txtMaNhanVien.Text.Trim(), out var mnv)) maNhanVien = mnv;
            try
            {
                InitializePhieuMuonGrid();
                var data = bus.Search(maPhieu, ngayFrom, ngayTo, trangThai, maDocGia, maNhanVien);
                bangPhieuMuon.DataSource = data;
                ConfigureGrid();
                InitializeChiTietGrid();
                bangCTPhieuMuon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
