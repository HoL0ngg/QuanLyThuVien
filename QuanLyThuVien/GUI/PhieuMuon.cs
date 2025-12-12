using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
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
            this.CurrentUser = taikhoan;
            
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
            bangPhieuMuon.Columns.Clear();

            bangPhieuMuon.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "MaPhieuMuon", HeaderText = "Ma", DataPropertyName = "MaPhieuMuon", FillWeight = 40 },
                new DataGridViewTextBoxColumn { Name = "NgayMuon", HeaderText = "Ngay muon", DataPropertyName = "NgayMuon", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } },
                new DataGridViewTextBoxColumn { Name = "NgayTraDuKien", HeaderText = "Tra du kien", DataPropertyName = "NgayTraDuKien", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } },
                new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trang thai", DataPropertyName = "TrangThai" },
                new DataGridViewTextBoxColumn { Name = "MaDocGia", HeaderText = "Ma doc gia", DataPropertyName = "MaDocGia" },
                new DataGridViewTextBoxColumn { Name = "TenDocGia", HeaderText = "Ten doc gia", DataPropertyName = "TenDocGia" },
                new DataGridViewTextBoxColumn { Name = "TenNhanVien", HeaderText = "Ten nhan vien", DataPropertyName = "TenNhanVien" }
            });
        }

        private void InitializeChiTietGrid()
        {
            bangCTPhieuMuon.Columns.Clear();

            bangCTPhieuMuon.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "MaSach", HeaderText = "Ma sach", DataPropertyName = "MaSach" },
                new DataGridViewTextBoxColumn { Name = "MaDauSach", HeaderText = "Ma dau sach", DataPropertyName = "MaDauSach" },
                new DataGridViewTextBoxColumn { Name = "TenDauSach", HeaderText = "Ten dau sach", DataPropertyName = "TenDauSach" },
                new DataGridViewTextBoxColumn { Name = "TenNXB", HeaderText = "Nha xuat ban", DataPropertyName = "NhaXuatBan" },
                new DataGridViewTextBoxColumn { Name = "NamXuatBan", HeaderText = "Nam xuat ban", DataPropertyName = "NamXuatBan" },
                new DataGridViewTextBoxColumn { Name = "NgonNgu", HeaderText = "Ngon ngu", DataPropertyName = "NgonNgu" }
            });
        }

        private static string MapTrangThai(object value)
        {
            if (value == null || !int.TryParse(value.ToString(), out int v)) return string.Empty;
            switch (v)
            {
                case 1: return "Chua Tra";
                case 2: return "Da Tra";
                case 3: return "Tra Muon";
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
            ToggleView(false);
            LoadData();
        }

        // Mở form thêm phiếu mượn
        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Ban khong co quyen them phieu muon!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ToggleView(true);
        }
        public override void OnEdit()
        {
            //if (!CoQuyenSua)
            //{
            //    MessageBox.Show("Ban khong co quyen sua phieu muon!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (bangPhieuMuon.CurrentRow == null)
            //{
            //    MessageBox.Show("Vui long chon mot phieu muon de cap nhat.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //var idCell = bangPhieuMuon.CurrentRow.Cells["MaPhieuMuon"];
            //if (idCell?.Value == null || !int.TryParse(idCell.Value.ToString(), out int id)) return;

            //DateTime ngayTraDuKien = DateTime.MinValue;
            //var ngayTraCell = bangPhieuMuon.CurrentRow.Cells["NgayTraDuKien"];
            //if (ngayTraCell?.Value != null)
            //    DateTime.TryParse(ngayTraCell.Value.ToString(), out ngayTraDuKien);

            //int currentStatus = 0;
            //var trangThaiCell = bangPhieuMuon.CurrentRow.Cells["TrangThai"];
            //if (trangThaiCell?.Value != null)
            //    int.TryParse(trangThaiCell.Value.ToString(), out currentStatus);

            //if (currentStatus == 2 || currentStatus == 3)
            //{
            //    MessageBox.Show("Phieu muon nay da duoc tra.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //var confirm = MessageBox.Show("Ban co muon cap nhat trang thai tra khong?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (confirm != DialogResult.Yes) return;

            //try
            //{
            //    var today = DateTime.Today;
            //    int newStatus = today > ngayTraDuKien.Date ? 3 : 2;
            //    var pm = new PhieuMuonDTO { MaPhieuMuon = id, TrangThai = newStatus };
            //    if (bus.Update(pm)) LoadData();
            //    else MessageBox.Show("Cap nhat trang thai khong thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Loi khi cap nhat trang thai: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            MessageBox.Show("Không thể sửa phiếu mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Ban khong co quyen xoa phieu muon!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (bangPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot phieu muon de xoa.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var idCell = bangPhieuMuon.CurrentRow.Cells["MaPhieuMuon"];
            if (idCell?.Value == null || !int.TryParse(idCell.Value.ToString(), out int id)) return;

            var confirm = MessageBox.Show("Ban co chac muon xoa phieu muon co ID " + id + " khong?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                if (bus.Delete(id)) LoadData();
                else MessageBox.Show("Xoa khong thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi xoa: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void OnDetails() 
        {
            MessageBox.Show("Nhấn vào phiếu mượn bên dưới để xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void LoadData()
        {
            try
            {
                InitializePhieuMuonGrid();
                bangPhieuMuon.DataSource = bus.GetAll();
                InitializeChiTietGrid();
                bangCTPhieuMuon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi tai du lieu phieu muon: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleView(bool showThem)
        {
            groupBoxInfo.Visible = !showThem;
            addPhieuMuon.Visible = !showThem;
            splitContainerMain.Visible = !showThem;

            ucThemPhieu.Visible = showThem;
            if (showThem) ucThemPhieu.BringToFront();
            else ucThemPhieu.SendToBack();
        }

        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            if (cmbTrangThai != null && cmbTrangThai.Items.Count > 0)
                cmbTrangThai.SelectedIndex = 0;
            dtpNgayMuon.Value = NgayMuonMacDinh;
            dtpNgayTraDuKien.Value = DateTime.Today;
            LoadData();
        }

        private void Button1_Click(object sender, EventArgs e) => OnAdd();
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
                MessageBox.Show("Loi hien thi chi tiet: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtMaPhieuMuon.Text = string.Empty;
            dtpNgayMuon.Value = NgayMuonMacDinh;
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
            if (ngayFrom > ngayTo) { var temp = ngayTo; ngayTo = ngayFrom; ngayFrom = temp; }
            
            int? trangThai = null;
            if (cmbTrangThai.SelectedItem != null && cmbTrangThai.SelectedItem.ToString() != "Tat ca")
            {
                switch (cmbTrangThai.SelectedItem.ToString())
                {
                    case "Chua tra": trangThai = 1; break;
                    case "Da tra": trangThai = 2; break;
                    case "Tra muon": trangThai = 3; break;
                }
            }
            int? maDocGia = null; if (int.TryParse(txtMaDocGia.Text.Trim(), out var mdg)) maDocGia = mdg;
            int? maNhanVien = null; if (int.TryParse(txtMaNhanVien.Text.Trim(), out var mnv)) maNhanVien = mnv;
            
            try
            {
                InitializePhieuMuonGrid();
                bangPhieuMuon.DataSource = bus.Search(maPhieu, ngayFrom, ngayTo, trangThai, maDocGia, maNhanVien);
                InitializeChiTietGrid();
                bangCTPhieuMuon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tim kiem: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
