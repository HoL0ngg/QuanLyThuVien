using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class PhieuPhat : BaseModuleUC
    {
        private bool isUserInput = true;
        private const string PLACEHOLDER_TEXT = "Tim kiem...";
        private List<PhieuPhatDTO> _currentResult = new List<PhieuPhatDTO>();

        public PhieuPhat()
        {
            InitializeComponent();
            this.Load += PhieuPhat_Load;
            InitializeActionButtons();
        }

        public PhieuPhat(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        /// <summary>
        /// Khởi tạo ActionButtonsUC
        /// </summary>
        private void InitializeActionButtons()
        {
            Panel panelActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(10, 5, 10, 5)
            };
            
            this.Controls.Add(panelActions);
            panelActions.BringToFront();
            
            CreateActionButtons(panelActions, DockStyle.Left);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }

        //private void btn_search_Click(object sender, EventArgs e)
        //{
        //    // Prevent textBox1_TextChanged handler from interfering while we update the grid.
        //    isUserInput = false;
        //    try
        //    {DVG
        //        DateTime begin = DTP_begin.Value;
        //        DateTime end = DTP_end.Value.Date.AddDays(1);
        //        if (begin > end)
        //        {
        //            MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        // Get records in date range first
        //        List<PhieuPhatDTO> list = PhieuPhatBUS.Instance.GetByDateRange(begin, end);

        //        // If there's a keyword, further filter the already retrieved list (client-side)
        //        string keyword = tb_search.Text?.Trim();
        //        if (!string.IsNullOrWhiteSpace(keyword))
        //        {
        //            int id;
        //            bool isId = int.TryParse(keyword, out id);
        //            string kwLower = keyword.ToLowerInvariant();

        //            list = list.Where(p =>
        //                (p.TenSach != null && p.TenSach.ToLowerInvariant().Contains(kwLower)) ||
        //                (p.TenDG != null && p.TenDG.ToLowerInvariant().Contains(kwLower)) ||
        //                (isId && p.MaPhieuPhat == id)
        //            ).ToList();
        //        }

        //        dgvPhieuPhat.DataSource = list;
        //    }
        //    finally
        //    {
        //        // Always re-enable the text changed handler flag
        //        isUserInput = true;
        //    }
        //}

        private void btn_search_Click(object sender, EventArgs e)
        {
            isUserInput = false;
            try
            {
                DateTime begin = DTP_begin.Value.Date;
                DateTime end = DTP_end.Value.Date.AddDays(1); // toi het ngay

                if (begin > end)
                {
                    MessageBox.Show("Ngay bat dau phai truoc ngay ket thuc.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var list = PhieuPhatBUS.Instance.GetByDateRange(begin, end);

                // keyword filter (client-side)
                string keyword = tb_search.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    int id;
                    bool isId = int.TryParse(keyword, out id);
                    string kwLower = keyword.ToLowerInvariant();

                    list = list.Where(p =>
                        (p.TenSach != null && p.TenSach.ToLowerInvariant().Contains(kwLower)) ||
                        (p.TenDG != null && p.TenDG.ToLowerInvariant().Contains(kwLower)) ||
                        (isId && p.MaPhieuPhat == id)
                    ).ToList();
                }

                // Luu lai ket qua hien tai
                _currentResult = list;

                dgvPhieuPhat.DataSource = _currentResult;
            }
            finally
            {
                isUserInput = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void dgvPhieuPhat_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        
        private void LoadPhieuPhat(int? trangThaiLoc = null)
        {
            dgvPhieuPhat.AutoGenerateColumns = false;
            colID.DataPropertyName = "MaPhieuPhat";
            colNgayPhat.DataPropertyName = "NgayPhat";
            colTrangThai.DataPropertyName = "TrangThaiText";
            colDG.DataPropertyName = "TenDG";
            colTien.DataPropertyName = "tienPhat";
            colTen.DataPropertyName = "TenSach";
            colLyDo.DataPropertyName = "LydoPhat";

            List<PhieuPhatDTO> list = trangThaiLoc.HasValue
                ? PhieuPhatBUS.Instance.GetTrangThaiPhieuPhat(trangThaiLoc.Value)
                : PhieuPhatBUS.Instance.GetAllPhieuPhat();

            dgvPhieuPhat.DataSource = list;
        }

        private void PhieuPhat_Load(object sender, EventArgs e)
        {
            LoadPhieuPhat(null);
        }

        private void PhieuPhat_Load_1(object sender, EventArgs e) { }

        private void cbbPhieuPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var baseList = _currentResult != null && _currentResult.Count > 0
                ? _currentResult
                : PhieuPhatBUS.Instance.GetAllPhieuPhat();

            int? trangThai = null;
            if (cbbPhieuPhat.SelectedIndex == 1) trangThai = 0;
            else if (cbbPhieuPhat.SelectedIndex == 2) trangThai = 1;

            var filtered = trangThai.HasValue
                ? baseList.Where(p => p.TrangThai == trangThai.Value).ToList()
                : baseList;

            dgvPhieuPhat.DataSource = filtered;
        }

        private void lb_dateEnd_Click(object sender, EventArgs e) { }

        private void btn_resest_Click(object sender, EventArgs e)
        {
            ResetFiltersToDefaults();
            LoadPhieuPhat(null);
        }

        private void ResetFiltersToDefaults()
        {
            DTP_begin.Value = DateTime.Now;
            DTP_end.Value = DateTime.Now;
            if (cbbPhieuPhat.Items.Count > 0)
            {
                cbbPhieuPhat.SelectedIndex = 0;
                int ind = cbbPhieuPhat.FindStringExact("Tat ca");
                if (ind >= 0) cbbPhieuPhat.SelectedIndex = ind;
            }
        }

        private void DTP_begin_ValueChanged(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isUserInput) return;
            string keyword = tb_search.Text;
            List<PhieuPhatDTO> list = PhieuPhatBUS.Instance.GetByKeyword(keyword);
            dgvPhieuPhat.DataSource = list;
        }

        private void btn(object sender, EventArgs e) { }

        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Ban khong co quyen them phieu phat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var dlg = new FormAddPhieuPhat())
            {
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK) LoadPhieuPhat(null);
            }
        }

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Ban khong co quyen xoa phieu phat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvPhieuPhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon phieu phat can xoa.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cellValue = dgvPhieuPhat.SelectedRows[0].Cells["colID"].Value;
            if (cellValue == null) return;
            int maPhieuPhat = Convert.ToInt32(cellValue);

            var result = MessageBox.Show("Ban co chac chan muon xoa (an) phieu phat so " + maPhieuPhat + " khong?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool isSuccess = PhieuPhatBUS.Instance.XoaPhieuPhat(maPhieuPhat);
                if (isSuccess)
                {
                    MessageBox.Show("Da xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuPhat(null);
                }
                else
                {
                    MessageBox.Show("Co loi xay ra, khong the xoa.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void OnEdit()
        {
            if (!CoQuyenSua)
            {
                MessageBox.Show("Ban khong co quyen sua phieu phat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var list = PhieuPhatBUS.Instance.GetTrangThaiPhieuPhat(0);
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Khong co phieu phat co trang thai 0 de sua.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new FormAddPhieuPhat(list))
            {
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK) LoadPhieuPhat(null);
            }
        }

        public override void OnDetails()
        {
            if (!CoQuyenXem)
            {
                MessageBox.Show("Ban khong co quyen xem chi tiet phieu phat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvPhieuPhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon phieu phat can xem chi tiet.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieu = dgvPhieuPhat.SelectedRows[0].DataBoundItem as PhieuPhatDTO;
            if (phieu == null) return;

            using (var dlg = new FormChiTietPhieuPhat(phieu))
            {
                dlg.ShowDialog();
            }
        }

        private void dgvPhieuPhat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuPhat.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                int value = Convert.ToInt32(e.Value);
                e.Value = value == 1 ? "Da dong" : "Chua dong";
                e.FormattingApplied = true;
            }
        }
    }
}
