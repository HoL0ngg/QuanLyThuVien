using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class UCMain : BaseModuleUC
    {
        // Use controls declared in Designer; do not redeclare here.
        public UCMain()
        {
            InitializeComponent();
            // Configure designer controls
            CreateOverviewControls();
        }

        private void CreateOverviewControls()
        {
            // Ensure the tab page exists
            if (this.btn_tongquan == null) return;

            // Configure top controls (dtpFrom, dtpTo, btnGenerate, txtSearch, btnSearch)
            if (this.dtpFrom != null)
            {
                this.dtpFrom.Format = DateTimePickerFormat.Short;
            }
            if (this.dtpTo != null)
            {
                this.dtpTo.Format = DateTimePickerFormat.Short;
            }
            if (this.btnSearch != null)
            {
                this.btnSearch.Click -= BtnGenerate_Click;
                this.btnSearch.Click += BtnGenerate_Click;
            }

            // Configure DataGridView
            if (this.dgvStats != null)
            {
                this.dgvStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvStats.RowHeadersVisible = false;
                this.dgvStats.AllowUserToAddRows = false;
                this.dgvStats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            // Default dates
            if (this.dtpTo != null) this.dtpTo.Value = DateTime.Now.Date;
            if (this.dtpFrom != null) this.dtpFrom.Value = DateTime.Now.Date.AddMonths(-1);
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = (this.dtpFrom != null) ? this.dtpFrom.Value.Date : DateTime.Now.Date.AddMonths(-1);
                DateTime to = (this.dtpTo != null) ? this.dtpTo.Value.Date.AddDays(1).AddSeconds(-1) : DateTime.Now.Date.AddDays(1).AddSeconds(-1);

                var list = PhieuPhatBUS.Instance.GetByDateRange(from, to) ?? new List<PhieuPhatDTO>();

                string keyword = (this.txtSearch != null) ? this.txtSearch.Text.Trim() : string.Empty;
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    string kwLower = keyword.ToLower();
                    list = list.Where(p => (!string.IsNullOrEmpty(p.TenSach) && p.TenSach.ToLower().Contains(kwLower))
                                         || (!string.IsNullOrEmpty(p.TenDG) && p.TenDG.ToLower().Contains(kwLower))
                                         || p.MaPhieuPhat.ToString() == keyword).ToList();
                }

                // Compute overview totals
                int totalCount = list.Count;
                int totalRevenue = list.Where(p => p.TrangThai == 1).Sum(p => p.tienPhat);
                int totalOutstanding = list.Where(p => p.TrangThai != 1).Sum(p => p.tienPhat);
                int uniqueReaders = list.Select(p => p.MaDG).Distinct().Count();

                // Fill minimal table for reference
                var table = new DataTable();
                table.Columns.Add("Mã", typeof(int));
                table.Columns.Add("Ngày", typeof(DateTime));
                table.Columns.Add("Sách", typeof(string));
                table.Columns.Add("Độc giả", typeof(string));
                table.Columns.Add("Tiền phạt", typeof(int));

                foreach (var p in list)
                {
                    table.Rows.Add(p.MaPhieuPhat, p.NgayPhat, p.TenSach, p.TenDG, p.tienPhat);
                }

                if (this.dgvStats != null) this.dgvStats.DataSource = table;

                // update labels
                if (this.lblTotalCount != null) this.lblTotalCount.Text = $"Số phiếu: {totalCount}";
                if (this.lblTotalAmount != null) this.lblTotalAmount.Text = $"Tổng thu: {totalRevenue:N0} đ";
                // find others by name
                if (this.lblOutstanding != null) this.lblOutstanding.Text = $"Chưa thu: {totalOutstanding:N0} đ";
                if (this.lblUniqueReaders != null) this.lblUniqueReaders.Text = $"Độc giả liên quan: {uniqueReaders}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCMain_Load(object sender, EventArgs e)
        {
            // nothing
        }

        public override void LoadData()
        {
            // Khi module được tải, tự động chạy thống kê trong khoảng mặc định
            BtnGenerate_Click(this, EventArgs.Empty);
        }

        // Designer referenced handler - keep empty to satisfy designer
        private void tabPageTK_Click(object sender, EventArgs e)
        {
            // no-op
        }
    }
}
