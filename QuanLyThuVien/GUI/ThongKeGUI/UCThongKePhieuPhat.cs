using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class UCThongKePhieuPhat : UserControl
    {
        private List<PhieuPhatDTO> _all; // cache nguyên bản để lọc
        private List<PhieuPhatDTO> _view; // danh sách đang hiển thị

        public UCThongKePhieuPhat()
        {
            InitializeComponent();
            InitFilters();
            LoadData();
        }

        /// <summary>
        /// Loads or refreshes the data for the statistics view.
        /// </summary>
        public void LoadData()
        {
            try
            {
                _all = PhieuPhatBUS.Instance.GetAllPhieuPhat() ?? new List<PhieuPhatDTO>();
                // Áp dụng filter hiện tại để tạo _view
                ApplyFiltersAndBind();
                // Tính KPI
                var tongPhieu = _view.Count;
                var tongPhiPhat = _view.Sum(x => x.tienPhat);
                var daThu = _view.Where(x => x.TrangThai == 1).Sum(x => x.tienPhat);
                var chuaThu = _view.Where(x => x.TrangThai == 0).Sum(x => x.tienPhat);

                lblTongPhieu.Text = tongPhieu.ToString("N0");
                lblTongPhiPhat.Text = tongPhiPhat.ToString("N0");
                lblDaThu.Text = daThu.ToString("N0");
                lblChuaThu.Text = chuaThu.ToString("N0");

                // Fill panels: lý do (dựa theo TrangThai sách trả/hỏng/mất nếu có), tạm thời thống kê theo TrangThai phiếu phạt
                FillLyDoPanel();
                FillTopDocGiaPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê phiếu phạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initializes filter controls for the statistics view.
        /// </summary>
        private void InitFilters()
        {
            // Combo trạng thái: Tất cả, Chưa đóng(0), Đã đóng(1)
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Chưa đóng");
            cboTrangThai.Items.Add("Đã đóng");
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.SelectedIndexChanged += (s, e) => ApplyFiltersAndBind();

            // Enter để tìm kiếm
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnSearch.PerformClick(); } };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndBind();
        }

        private void ApplyFiltersAndBind()
        {
            if (_all == null) _all = new List<PhieuPhatDTO>();

            // Lọc theo trạng thái
            int? tt = null;
            if (cboTrangThai.SelectedIndex == 1) tt = 0; // Chưa đóng
            else if (cboTrangThai.SelectedIndex == 2) tt = 1; // Đã đóng

            IEnumerable<PhieuPhatDTO> query = _all;
            if (tt.HasValue)
            {
                query = query.Where(x => x.TrangThai == tt.Value);
            }

            // Lọc theo keyword
            var kw = (txtSearch.Text ?? string.Empty).Trim().ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(kw))
            {
                int id;
                bool isId = int.TryParse(kw, out id);
                query = query.Where(p =>
                    (p.TenSach != null && p.TenSach.ToLowerInvariant().Contains(kw)) ||
                    (p.TenDG != null && p.TenDG.ToLowerInvariant().Contains(kw)) ||
                    (isId && p.MaPhieuPhat == id)
                );
            }

            _view = query.ToList();
            BindGrid(_view);
        }

        private void BindGrid(List<PhieuPhatDTO> list)
        {
            dgvChiTiet.Rows.Clear();
            foreach (var x in list)
            {
                int i = dgvChiTiet.Rows.Add();
                var row = dgvChiTiet.Rows[i];
                row.Cells["colMaPhieu"].Value = x.MaPhieuPhat;
                row.Cells["colDocGia"].Value = x.TenDG;
                // Lý do: hiển thị đơn giản theo trạng thái phiếu phạt
                row.Cells["colLyDo"].Value = GetLyDoFromDTO(x);
                row.Cells["colGiaTri"].Value = x.tienPhat.ToString("N0");
                row.Cells["colTrangThai"].Value = x.TrangThaiText;
                row.Cells["colNgayLap"].Value = x.NgayPhat.ToString("dd/MM/yyyy");
                row.Cells["colNgayThanhToan"].Value = (x.NgayTra == DateTime.MinValue ? "" : x.NgayTra.ToString("dd/MM/yyyy"));
            }
        }

        private string GetLyDoFromDTO(PhieuPhatDTO dto)
        {
            // Không có chi tiết trạng thái sách từ DTO ở đây, hiển thị cơ bản
            // Có thể mở rộng nếu có dữ liệu lý do ở nơi khác.
            if (dto.TrangThai == 0) return "Chưa đóng";
            if (dto.TrangThai == 1) return "Đã đóng";
            return "";
        }

        private void FillLyDoPanel()
        {
            flpLyDo.Controls.Clear();
            // Thống kê số lượng theo trạng thái phiếu phạt (cơ bản)
            int chua = _view.Count(x => x.TrangThai == 0);
            int da = _view.Count(x => x.TrangThai == 1);
            flpLyDo.Controls.Add(CreateBulletLabel($"Chưa đóng: {chua:N0}", Color.FromArgb(255, 152, 0)));
            flpLyDo.Controls.Add(CreateBulletLabel($"Đã đóng: {da:N0}", Color.FromArgb(76, 175, 80)));
        }

        private void FillTopDocGiaPanel()
        {
            flpTopDocGia.Controls.Clear();
            var top = _view
                .GroupBy(x => new { x.MaDG, x.TenDG })
                .Select(g => new { g.Key.TenDG, TongPhat = g.Sum(x => x.tienPhat) })
                .OrderByDescending(x => x.TongPhat)
                .Take(5)
                .ToList();

            foreach (var t in top)
            {
                flpTopDocGia.Controls.Add(CreateBulletLabel($"{t.TenDG}: {t.TongPhat:N0} đ", Color.FromArgb(33, 150, 243)));
            }
        }

        private Label CreateBulletLabel(string text, Color color)
        {
            return new Label
            {
                Text = "● " + text,
                AutoSize = true,
                ForeColor = Color.FromArgb(66, 66, 66),
                Font = new Font("Segoe UI", 10F),
                Margin = new Padding(6)
            };
        }
    }
}
