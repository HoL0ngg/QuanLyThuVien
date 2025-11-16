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
        private CTPhieuMuonDAO ctDao = new CTPhieuMuonDAO();
        private FormThemPhieuMuon ucThemPhieu;

        public PhieuMuon()
        {
            InitializeComponent();
            bangPhieuMuon.CellClick += BangPhieuMuon_CellClick;
            btnClearFilters.Click += BtnClearFilters_Click;

            // Khởi tạo sẵn UC thêm phiếu mượn và thêm vào control tree
            ucThemPhieu = new FormThemPhieuMuon();
            ucThemPhieu.Dock = DockStyle.Fill;
            ucThemPhieu.Visible = false;
            ucThemPhieu.CloseRequested += UcThemPhieu_CloseRequested;
            this.Controls.Add(ucThemPhieu);
            ucThemPhieu.BringToFront();
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
                cmbTrangThai.SelectedIndex = 0; // "Tất cả"
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
                var ctList = ctDao.GetByPhieuMuon(ma);
                bangCTPhieuMuon.AutoGenerateColumns = true;
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
            dtpNgayMuon.Value = DateTime.Today;
            dtpNgayTraDuKien.Value = DateTime.Today;
            cmbTrangThai.SelectedIndex = 0;
            txtMaDocGia.Text = string.Empty;
            txtMaNhanVien.Text = string.Empty;
        }

        private void BangPhieuMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
