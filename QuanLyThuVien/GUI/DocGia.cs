using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using QuanLyThuVien.DTO;
using QuanLyThuVien.BUS;

namespace QuanLyThuVien.GUI
{
    public partial class DocGia : BaseModuleUC
    {
        private BindingList<DocGiaDTO> dgList = new BindingList<DocGiaDTO>();
        private DocGiaBUS dgBUS = new DocGiaBUS();

        public DocGia()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            LoadData();
            btnTimKiem.Click += BtnTimKiem_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
        }

        public override void LoadData()
        {
            dgList = new BindingList<DocGiaDTO>(dgBUS.GetAll());
            dgvDocGia.DataSource = dgList;
            InitializeDocGiaGrid();
        }

        private void InitializeDocGiaGrid()
        {
            dgvDocGia.AutoGenerateColumns = false;
            dgvDocGia.Columns.Clear();
            dgvDocGia.ReadOnly = true;
            dgvDocGia.AllowUserToAddRows = false;
            dgvDocGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocGia.MultiSelect = false;
            dgvDocGia.RowHeadersVisible = false; // Ẩn cột mũi tên đầu tiên

            var colMa = new DataGridViewTextBoxColumn { Name = "MaDG", HeaderText = "Mã độc giả", DataPropertyName = "MaDG", FillWeight = 70 };
            var colTenDG = new DataGridViewTextBoxColumn { Name = "TenDG", HeaderText = "Tên độc giả", DataPropertyName = "TenDG", FillWeight = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colSDT = new DataGridViewTextBoxColumn { Name = "SDT", HeaderText = "SĐT", DataPropertyName = "SDT", FillWeight = 70, Width = 100 };
            var colDiaChi = new DataGridViewTextBoxColumn { Name = "DiaChi", HeaderText = "Địa chỉ", DataPropertyName = "DiaChi", FillWeight = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };

            dgvDocGia.Columns.AddRange(new DataGridViewColumn[] { colMa, colTenDG, colSDT, colDiaChi });
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string maText = txtMaDGSearch.Text.Trim();
            string tenText = txtTenDGSearch.Text.Trim().ToLower();
            string sdtText = txtSDTSearch.Text.Trim();

            var filtered = dgList.Where(dg =>
                (string.IsNullOrEmpty(maText) || dg.MaDG.ToString() == maText) &&
                (string.IsNullOrEmpty(tenText) || (dg.TenDG != null && dg.TenDG.ToLower().Contains(tenText))) &&
                (string.IsNullOrEmpty(sdtText) || (dg.SDT != null && dg.SDT.Contains(sdtText)))
            ).ToList();

            dgvDocGia.DataSource = new BindingList<DocGiaDTO>(filtered);
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtMaDGSearch.Clear();
            txtTenDGSearch.Clear();
            txtSDTSearch.Clear();
            LoadData();
        }

        private void grpTimKiem_Enter(object sender, EventArgs e) { }

        public override void OnAdd()
        {
            ThemDocGiaDialog dialog = new ThemDocGiaDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); 
            }
        }

        public override void OnEdit()
        {
            if (dgvDocGia.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một độc giả để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DocGiaDTO selected = null;

            var idCell = dgvDocGia.CurrentRow.Cells["MaDG"];
            var tenCell = dgvDocGia.CurrentRow.Cells["TenDG"];
            var sdtCell = dgvDocGia.CurrentRow.Cells["SDT"];
            var dcCell = dgvDocGia.CurrentRow.Cells["DiaChi"];
            int id = 0; int.TryParse(idCell?.Value?.ToString(), out id);
            selected = new DocGiaDTO
            {
                MaDG = id,
                TenDG = tenCell?.Value?.ToString(),
                SDT = sdtCell?.Value?.ToString(),
                DiaChi = dcCell?.Value?.ToString(),
                TrangThai = 1
            };

            using (var dlg = new SuaDocGiaDialog(selected))
            {
                var result = dlg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Cập nhật độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        public override void OnDelete()
        {
            if (dgvDocGia.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một độc giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var idCell = dgvDocGia.CurrentRow.Cells["MaDG"];
            if (idCell?.Value == null || !int.TryParse(idCell.Value.ToString(), out int id)) return;

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa độc giả {id} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                if (dgBUS.Delete(id))
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
