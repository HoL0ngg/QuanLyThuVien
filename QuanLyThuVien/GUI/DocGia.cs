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
            this.Load += DocGia_Load;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
        }

        private void DocGia_Load(object sender, EventArgs e)
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
    }
}
