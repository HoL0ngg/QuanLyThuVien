using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System.Drawing; // thêm để dùng Color

namespace QuanLyThuVien.GUI
{
    public partial class FormThemPhieuMuon : UserControl
    {
        // Sự kiện yêu cầu đóng form (quay về trang phiếu mượn)
        public event Action CloseRequested;
        private BindingList<CTPhieuMuonDTO> ctList = new BindingList<CTPhieuMuonDTO>();
        private const string AddColumnName = "colAdd";
        private const string DeleteColumnName = "colDelete";

        public FormThemPhieuMuon()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            this.Load += FormThemPhieuMuon_Load;
            btnThem.Click += BtnThem_Click;
            btnHuy.Click += BtnHuy_Click;
            btnTimSach.Click += BtnTimSach_Click;
            txtTuKhoaSach.KeyDown += TxtTuKhoaSach_KeyDown; // Enter để tìm
            dgvKetQuaSach.CellContentClick += DgvKetQuaSach_CellContentClick;
            dgvCT.CellContentClick += DgvCT_CellContentClick;
        }

        private void FormThemPhieuMuon_Load(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            txtNgayMuon.Text = today.ToString("dd/MM/yyyy");
            dtpNgayTraDuKien.Value = today.AddDays(7);
            SetupCTGrid();
        }

        private void SetupCTGrid()
        {
            dgvCT.AutoGenerateColumns = true;
            dgvCT.DataSource = ctList;
            EnsureDeleteColumnChiTiet();
            ApplyCommonGridStyle(dgvCT, DeleteColumnName);
        }

        // Hàm áp dụng style chung giống bảng phiếu mượn
        private void ApplyCommonGridStyle(DataGridView grid, string specialColumnName)
        {
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false; // tránh hàng rỗng khi không có dữ liệu
            foreach (DataGridViewColumn c in grid.Columns)
            {
                if (c.Name == specialColumnName)
                {
                    c.FillWeight = 30;
                    var style = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                        ForeColor = c.Name == DeleteColumnName ? Color.Red : Color.DarkGreen,
                        SelectionForeColor = c.Name == DeleteColumnName ? Color.Red : Color.DarkGreen
                    };
                    c.DefaultCellStyle = style;
                }
                else
                {
                    c.FillWeight = 100;
                }
            }
        }

        private void ConfigureKetQuaGrid()
        {
            // dùng hàm chung thay vì riêng lẻ
            ApplyCommonGridStyle(dgvKetQuaSach, AddColumnName);
        }

        private void EnsureAddColumnKetQua()
        {
            if (dgvKetQuaSach.Columns[AddColumnName] == null)
            {
                var btnCol = new DataGridViewButtonColumn
                {
                    Name = AddColumnName,
                    HeaderText = "Thêm",
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgvKetQuaSach.Columns.Add(btnCol);
            }
            dgvKetQuaSach.Columns[AddColumnName].DisplayIndex = dgvKetQuaSach.Columns.Count - 1;
        }

        private void EnsureDeleteColumnChiTiet()
        {
            if (dgvCT.Columns[DeleteColumnName] == null)
            {
                var btnCol = new DataGridViewButtonColumn
                {
                    Name = DeleteColumnName,
                    HeaderText = "Xóa",
                    Text = "X",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dgvCT.Columns.Add(btnCol);
            }
            dgvCT.Columns[DeleteColumnName].DisplayIndex = dgvCT.Columns.Count - 1;
        }

        private void BtnTimSach_Click(object sender, EventArgs e)
        {
            string keyword = txtTuKhoaSach.Text.Trim();
            DataTable dt = string.IsNullOrEmpty(keyword)
                ? DauSachBUS.Instance.GetAllDauSach()
                : DauSachBUS.Instance.SearchDauSach(keyword);

            if (dt == null || dt.Rows.Count == 0)
            {
                dgvKetQuaSach.DataSource = null; // không hiển thị hàng rỗng
                EnsureAddColumnKetQua();
                ConfigureKetQuaGrid();
                MessageBox.Show("Không tìm thấy sách phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvKetQuaSach.AutoGenerateColumns = true;
            dgvKetQuaSach.DataSource = dt;
            EnsureAddColumnKetQua();
            ConfigureKetQuaGrid();
        }

        private void TxtTuKhoaSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnTimSach_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private int? ExtractMaDauSach(DataGridViewRow row)
        {
            // Kiểm tra theo tên cột tồn tại trong DataGridView
            if (dgvKetQuaSach.Columns.Contains("MaDauSach") && row.Cells["MaDauSach"].Value != null)
            {
                if (int.TryParse(row.Cells["MaDauSach"].Value.ToString(), out var id)) return id;
            }
            if (dgvKetQuaSach.Columns.Contains("Mã đầu sách") && row.Cells["Mã đầu sách"].Value != null)
            {
                if (int.TryParse(row.Cells["Mã đầu sách"].Value.ToString(), out var id)) return id;
            }
            return null;
        }

        private void DgvKetQuaSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKetQuaSach.Columns[e.ColumnIndex].Name != AddColumnName) return;
            var row = dgvKetQuaSach.Rows[e.RowIndex];
            var maDauSach = ExtractMaDauSach(row);
            if (!maDauSach.HasValue) return;
            if (ctList.Any(c => c.MaSach == maDauSach.Value)) return; // tránh trùng
            ctList.Add(new CTPhieuMuonDTO { MaPhieuMuon = 0, MaSach = maDauSach.Value });
        }

        private void DgvCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCT.Columns[e.ColumnIndex].Name != DeleteColumnName) return;
            var item = dgvCT.Rows[e.RowIndex].DataBoundItem as CTPhieuMuonDTO;
            if (item == null) return;
            var confirm = MessageBox.Show($"Xóa sách mã {item.MaSach} khỏi danh sách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                ctList.Remove(item);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Chưa lưu DB theo yêu cầu - chỉ đóng form
            CloseRequested?.Invoke();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke();
        }

        private void btnTimSach_Click_1(object sender, EventArgs e) { }
    }
}
