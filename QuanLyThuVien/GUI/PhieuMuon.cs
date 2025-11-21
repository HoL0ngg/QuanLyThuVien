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
        private CTPhieuMuonDAO ctDAO = new CTPhieuMuonDAO();
        private FormThemPhieuMuon ucThemPhieu;
        private const string DeleteColumnName = "colDelete";
        private static readonly DateTime NgayMuonMacDinh = new DateTime(2000, 1, 1);

        public PhieuMuon()
        {
            InitializeComponent();
            bangPhieuMuon.CellClick += BangPhieuMuon_CellClick;
            btnClearFilters.Click += BtnClearFilters_Click;
            btnTimKiem.Click += BtnTimKiem_Click;

            ucThemPhieu = new FormThemPhieuMuon();
            ucThemPhieu.Dock = DockStyle.Fill;
            ucThemPhieu.Visible = false;
            ucThemPhieu.CloseRequested += UcThemPhieu_CloseRequested;
            this.Controls.Add(ucThemPhieu);
            ucThemPhieu.BringToFront();
        }

        private void ConfigureGrid()
        {
            bangPhieuMuon.RowHeadersVisible = false;
            bangPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn c in bangPhieuMuon.Columns)
            {
                if (c.Name == DeleteColumnName)
                {
                    c.FillWeight = 30; 
                }
                else
                {
                    c.FillWeight = 100;
                }
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
        public override void OnDelete() { }

        public override void LoadData()
        {
            try
            {
                bangPhieuMuon.AutoGenerateColumns = true;
                bangPhieuMuon.DataSource = bus.GetAll();
                EnsureDeleteColumn();
                ConfigureGrid();
                bangCTPhieuMuon.DataSource = null; // clear chi tiết khi reload
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureDeleteColumn()
        {
            if (bangPhieuMuon.Columns[DeleteColumnName] == null)
            {
                var btnCol = new DataGridViewButtonColumn();
                btnCol.Name = DeleteColumnName;
                btnCol.HeaderText = "Xóa";
                btnCol.Text = "X";
                btnCol.UseColumnTextForButtonValue = true;
                btnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                var style = new DataGridViewCellStyle();
                style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                style.ForeColor = Color.Red;
                style.SelectionForeColor = Color.Red;
                btnCol.DefaultCellStyle = style;
                bangPhieuMuon.Columns.Add(btnCol);
            }
            // Đặt cột Xóa ở ngoài cùng bên phải
            bangPhieuMuon.Columns[DeleteColumnName].DisplayIndex = bangPhieuMuon.Columns.Count - 1;
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
                var ctList = ctDAO.GetByPhieuMuon(ma);
                bangCTPhieuMuon.AutoGenerateColumns = true;
                bangCTPhieuMuon.DataSource = ctList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BangPhieuMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name != DeleteColumnName) return;

            var idCell = grid.Rows[e.RowIndex].Cells["MaPhieuMuon"];
            if (idCell == null || idCell.Value == null) return;
            int id;
            if (!int.TryParse(idCell.Value.ToString(), out id)) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa phiếu mượn có ID {id} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
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
            if (ngayFrom > ngayTo) { var tmp = ngayFrom; ngayFrom = ngayTo; ngayTo = tmp; }
            int? trangThai = null;
            if (cmbTrangThai.SelectedItem != null && cmbTrangThai.SelectedItem.ToString() != "Tất cả")
            {
                switch (cmbTrangThai.SelectedItem.ToString())
                {
                    case "Chưa trả": trangThai = 0; break;
                    case "Đã trả": trangThai = 1; break;
                    case "Trả muộn": trangThai = 2; break;
                }
            }
            int? maDocGia = null; if (int.TryParse(txtMaDocGia.Text.Trim(), out var mdg)) maDocGia = mdg;
            int? maNhanVien = null; if (int.TryParse(txtMaNhanVien.Text.Trim(), out var mnv)) maNhanVien = mnv;
            try
            {
                var data = bus.Search(maPhieu, ngayFrom, ngayTo, trangThai, maDocGia, maNhanVien);
                bangPhieuMuon.AutoGenerateColumns = true;
                bangPhieuMuon.DataSource = data;
                EnsureDeleteColumn();
                ConfigureGrid();
                bangCTPhieuMuon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
