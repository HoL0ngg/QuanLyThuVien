using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class UCThongKePhieuMuon : UserControl
    {
        private List<PhieuMuonDTO> _all = new List<PhieuMuonDTO>();
        private List<PhieuMuonDTO> _view = new List<PhieuMuonDTO>();

        public UCThongKePhieuMuon()
        {
            InitializeComponent();
            InitFilters();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                _all = ThongKeBUS.Instance.GetAllPhieuMuonWithDetails();
                ApplyFiltersAndBind();
                ComputeKPIs();
                FillTrendPanel();
                FillTyLeTraPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitFilters()
        {
            dtpFrom.Value = new DateTime(2025, 1, 1);
            dtpTo.Value = DateTime.Now.Date;
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Chưa trả");
            cboTrangThai.Items.Add("Đã trả");
            cboTrangThai.Items.Add("Trả muộn");
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.SelectedIndexChanged += (s, e) => { ApplyFiltersAndBind(); ComputeKPIs(); FillTrendPanel(); FillTyLeTraPanel(); };
            btnSearch.Click += (s, e) => { ApplyFiltersAndBind(); ComputeKPIs(); FillTrendPanel(); FillTyLeTraPanel(); };
            btnRefresh.Click += (s, e) => LoadData();
        }

        private void ApplyFiltersAndBind()
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date.AddDays(1);
            int? tt = null;
            switch (cboTrangThai.SelectedIndex)
            {
                case 1: tt = 1; break;
                case 2: tt = 2; break;
                case 3: tt = 3; break;
            }
            var query = _all.Where(pm => pm.NgayMuon >= from && pm.NgayMuon < to);
            if (tt.HasValue) query = query.Where(pm => pm.TrangThai == tt.Value);
            _view = query.ToList();
            BindGrid(_view);
        }

        private void BindGrid(List<PhieuMuonDTO> list)
        {
            dgvChiTiet.Rows.Clear();
            foreach (var pm in list)
            {
                int i = dgvChiTiet.Rows.Add();
                var row = dgvChiTiet.Rows[i];
                row.Cells["colMaPhieu"].Value = pm.MaPhieuMuon;
                row.Cells["colDocGia"].Value = pm.TenDocGia ?? pm.MaDocGia.ToString();
                row.Cells["colSoLuong"].Value = pm.CTPM?.Count ?? 0;
                row.Cells["colNgayMuon"].Value = pm.NgayMuon.ToString("dd/MM/yyyy");
                row.Cells["colNgayHanTra"].Value = pm.NgayTraDuKien.ToString("dd/MM/yyyy");
                row.Cells["colTrangThai"].Value = MapTrangThai(pm.TrangThai);
                row.Cells["colSachQuaHan"].Value = ComputeQuaHanCount(pm);
            }
        }

        private string MapTrangThai(int v)
        {
            switch (v)
            {
                case 1: return "Đang mở";
                case 2: return "Đã đóng";
                case 3: return "Quá hạn";
                default: return v.ToString();
            }
        }

        private int ComputeQuaHanCount(PhieuMuonDTO pm)
        {
            if (pm.TrangThai == 1 && pm.NgayTraDuKien < DateTime.Now.Date)
                return pm.CTPM?.Count ?? 0;
            if (pm.TrangThai == 3)
                return pm.CTPM?.Count ?? 0;
            return 0;
        }

        private void ComputeKPIs()
        {
            int tongPhieu = _view.Count;
            int tongLuotSach = _view.Sum(p => p.CTPM?.Count ?? 0);
            int daTraHoanTat = _view.Count(p => p.TrangThai == 2);
            int dangMoQuaHan = _view.Count(p => p.TrangThai == 1 || p.TrangThai == 3);

            lblTongPhieu.Text = tongPhieu.ToString("N0");
            lblTongLuotSach.Text = tongLuotSach.ToString("N0");
            lblDaTraHoanTat.Text = daTraHoanTat.ToString("N0");
            lblDangMoQuaHan.Text = dangMoQuaHan.ToString("N0");
        }

        private void FillTrendPanel()
        {
            flpTrend.Controls.Clear();
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            try
            {
                DataTable trendData = ThongKeBUS.Instance.GetPhieuMuonTrend(from, to);
                foreach (DataRow r in trendData.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(r["Ngay"]);
                    int soMuon = Convert.ToInt32(r["SoMuon"]);
                    int soTra = Convert.ToInt32(r["SoTra"]);
                    flpTrend.Controls.Add(CreateBulletLabel($"{ngay:dd/MM}: {soMuon} mượn / {soTra} trả", Color.FromArgb(33, 150, 243)));
                }
            }
            catch
            {
                var timeline = _view
                    .GroupBy(x => x.NgayMuon.Date)
                    .Select(g => new { Day = g.Key, Borrow = g.Count() })
                    .OrderBy(x => x.Day)
                    .ToList();
                foreach (var item in timeline)
                {
                    flpTrend.Controls.Add(CreateBulletLabel($"{item.Day:dd/MM}: {item.Borrow} phiếu mượn", Color.FromArgb(33, 150, 243)));
                }
            }
        }

        private void FillTyLeTraPanel()
        {
            flpTyLeTra.Controls.Clear();
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            try
            {
                DataTable tyLeData = ThongKeBUS.Instance.GetTyLeTra(from, to);
                int dungHan = 0, treHan = 0;
                foreach (DataRow r in tyLeData.Rows)
                {
                    string loai = r["LoaiTra"].ToString();
                    int soLuong = Convert.ToInt32(r["SoLuong"]);
                    if (loai == "DungHan") dungHan = soLuong;
                    else if (loai == "TreHan") treHan = soLuong;
                }
                int total = dungHan + treHan;
                flpTyLeTra.Controls.Add(CreateBulletLabel($"Đúng hạn: {(total == 0 ? 0 : (dungHan * 100 / total))}% ({dungHan} phiếu)", Color.FromArgb(76, 175, 80)));
                flpTyLeTra.Controls.Add(CreateBulletLabel($"Trễ hạn: {(total == 0 ? 0 : (treHan * 100 / total))}% ({treHan} phiếu)", Color.FromArgb(255, 152, 0)));
            }
            catch
            {
                int total = _view.Count;
                int dungHan = _view.Count(x => x.TrangThai == 2);
                int treHan = _view.Count(x => x.TrangThai == 3);
                flpTyLeTra.Controls.Add(CreateBulletLabel($"Đúng hạn: {(total == 0 ? 0 : (dungHan * 100 / total))}%", Color.FromArgb(76, 175, 80)));
                flpTyLeTra.Controls.Add(CreateBulletLabel($"Trễ hạn: {(total == 0 ? 0 : (treHan * 100 / total))}%", Color.FromArgb(255, 152, 0)));
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
