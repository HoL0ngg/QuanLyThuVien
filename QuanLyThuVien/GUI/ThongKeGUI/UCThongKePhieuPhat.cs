using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class UCThongKePhieuPhat : UserControl
    {
        private List<PhieuPhatDTO> _all;
        private List<PhieuPhatDTO> _view;

        private bool _isLoaded = false;
        private bool _isLoading = false;
        private BackgroundWorker _dataLoader;

        public UCThongKePhieuPhat()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.AllPaintingInWmPaint, true);
            
            InitializeComponent();
            InitFilters();
            InitBackgroundWorker();
        }

        private void InitBackgroundWorker()
        {
            _dataLoader = new BackgroundWorker();
            _dataLoader.DoWork += DataLoader_DoWork;
            _dataLoader.RunWorkerCompleted += DataLoader_RunWorkerCompleted;
        }

        private void DataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            _all = PhieuPhatBUS.Instance.GetAllPhieuPhat() ?? new List<PhieuPhatDTO>();
        }

        private void DataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Lỗi khi tải thống kê phiếu phạt: " + e.Error.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isLoading = false;
                return;
            }

            try
            {
                ApplyFiltersAndBind();
                ComputeKPIs();
                FillLyDoChart();
                FillTopDocGiaChart();
            }
            finally
            {
                this.ResumeLayout(true);
                _isLoading = false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!_isLoaded)
            {
                _isLoaded = true;
                LoadData();
            }
        }

        public void LoadData()
        {
            if (_isLoading) return;
            if (!_isLoaded && !this.IsHandleCreated) return;

            _isLoading = true;
            this.SuspendLayout();
            
            if (!_dataLoader.IsBusy)
            {
                _dataLoader.RunWorkerAsync();
            }
        }

        private void ComputeKPIs()
        {
            var tongPhieu = _view.Count;
            var tongPhiPhat = _view.Sum(x => x.tienPhat);
            var daThu = _view.Where(x => x.TrangThai == 1).Sum(x => x.tienPhat);
            var chuaThu = _view.Where(x => x.TrangThai == 0).Sum(x => x.tienPhat);

            lblTongPhieu.Text = tongPhieu.ToString("N0");
            lblTongPhiPhat.Text = tongPhiPhat.ToString("N0") + " đ";
            lblDaThu.Text = daThu.ToString("N0") + " đ";
            lblChuaThu.Text = chuaThu.ToString("N0") + " đ";
        }

        private void InitFilters()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Tất cả", "Chưa đóng", "Đã đóng" });
            cboTrangThai.SelectedIndex = 0;
            
            cboTrangThai.SelectedIndexChanged += OnFilterChanged;
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnSearch.PerformClick(); } };
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            if (_isLoading || !_isLoaded) return;
            
            _isLoading = true;
            try
            {
                ApplyFiltersAndBind();
                ComputeKPIs();
                FillLyDoChart();
                FillTopDocGiaChart();
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_isLoading) return;
            OnFilterChanged(sender, e);
        }

        private void ApplyFiltersAndBind()
        {
            if (_all == null) _all = new List<PhieuPhatDTO>();

            int? tt = null;
            if (cboTrangThai.SelectedIndex == 1) tt = 0;
            else if (cboTrangThai.SelectedIndex == 2) tt = 1;

            IEnumerable<PhieuPhatDTO> query = _all;
            if (tt.HasValue)
                query = query.Where(x => x.TrangThai == tt.Value);

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
            dgvChiTiet.SuspendLayout();
            try
            {
                dgvChiTiet.Rows.Clear();
                
                // Limit rows to prevent UI freeze, show only first 1000 rows
                var displayList = list.Take(1000).ToList();
                
                foreach (var x in displayList)
                {
                    dgvChiTiet.Rows.Add(
                        x.MaPhieuPhat,
                        x.TenDG,
                        x.TrangThai == 0 ? "Chưa đóng" : "Đã đóng",
                        x.tienPhat.ToString("N0"),
                        x.TrangThaiText,
                        x.NgayPhat.ToString("dd/MM/yyyy"),
                        x.NgayTra == DateTime.MinValue ? "" : x.NgayTra.ToString("dd/MM/yyyy")
                    );
                }
                
                // Show message if there are more rows
                if (list.Count > 1000)
                {
                    dgvChiTiet.Rows.Add("", "", "", "", "Hiển thị 1000/ " + list.Count + " bản ghi", "", "");
                }
            }
            finally
            {
                dgvChiTiet.ResumeLayout(true);
            }
        }

        private void FillLyDoChart()
        {
            flpLyDo.SuspendLayout();
            flpLyDo.Controls.Clear();

            int chua = _view.Count(x => x.TrangThai == 0);
            int da = _view.Count(x => x.TrangThai == 1);
            int total = chua + da;

            var items = new List<(string Label, int Value, Color BarColor)>
            {
                ("Chưa đóng", chua, Color.FromArgb(255, 152, 0)),
                ("Đã đóng", da, Color.FromArgb(76, 175, 80))
            };

            int maxValue = items.Max(x => x.Value);
            if (maxValue == 0) maxValue = 1;

            foreach (var item in items)
            {
                var card = CreateBarCard(item.Label, item.Value, maxValue, item.BarColor, "phiếu");
                flpLyDo.Controls.Add(card);
            }

            flpLyDo.ResumeLayout(true);
        }

        private void FillTopDocGiaChart()
        {
            flpTopDocGia.SuspendLayout();
            flpTopDocGia.Controls.Clear();

            // Optimize grouping by using Dictionary for better performance
            var topDict = new Dictionary<string, decimal>();
            foreach (var item in _view)
            {
                string key = item.TenDG ?? $"Độc giả #{item.MaDG}";
                if (!topDict.ContainsKey(key))
                    topDict[key] = 0;
                topDict[key] += item.tienPhat;
            }

            var top = topDict.OrderByDescending(x => x.Value).Take(5).ToList();

            if (top.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "Không có dữ liệu",
                    AutoSize = false,
                    Size = new Size(flpTopDocGia.Width - 20, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray
                };
                flpTopDocGia.Controls.Add(lbl);
                flpTopDocGia.ResumeLayout(true);
                return;
            }

            decimal maxValue = top[0].Value;
            if (maxValue == 0) maxValue = 1;

            int rank = 1;
            foreach (var t in top)
            {
                Color color;
                switch (rank)
                {
                    case 1: color = Color.FromArgb(244, 67, 54); break;
                    case 2: color = Color.FromArgb(255, 152, 0); break;
                    case 3: color = Color.FromArgb(255, 193, 7); break;
                    default: color = Color.FromArgb(33, 150, 243); break;
                }

                var card = CreateBarCard(t.Key, (int)t.Value, (int)maxValue, color, "đ");
                flpTopDocGia.Controls.Add(card);
                rank++;
            }

            flpTopDocGia.ResumeLayout(true);
        }

        private Panel CreateBarCard(string label, int value, int maxValue, Color barColor, string unit)
        {
            int panelWidth = flpLyDo.Width - 30;
            if (panelWidth < 200) panelWidth = 400;

            var card = new Panel
            {
                Size = new Size(panelWidth, 32),
                Margin = new Padding(2),
                BackColor = Color.Transparent
            };

            int labelWidth = 120;
            int valueWidth = 100;
            int barStartX = labelWidth + 5;
            int barMaxWidth = panelWidth - labelWidth - valueWidth - 15;

            var lblName = new Label
            {
                Text = label,
                Location = new Point(0, 6),
                Size = new Size(labelWidth, 20),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(33, 33, 33),
                TextAlign = ContentAlignment.MiddleLeft
            };

            double percent = maxValue > 0 ? (double)value / maxValue : 0;
            int barWidth = (int)(barMaxWidth * percent);
            if (barWidth < 2 && value > 0) barWidth = 2;

            var pnlBarBg = new Panel
            {
                Location = new Point(barStartX, 8),
                Size = new Size(barMaxWidth, 16),
                BackColor = Color.FromArgb(230, 230, 230)
            };

            var pnlBar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(barWidth, 16),
                BackColor = barColor
            };
            pnlBarBg.Controls.Add(pnlBar);

            var lblValue = new Label
            {
                Text = value.ToString("N0") + " " + unit,
                Location = new Point(barStartX + barMaxWidth + 5, 6),
                Size = new Size(valueWidth, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = barColor,
                TextAlign = ContentAlignment.MiddleLeft
            };

            card.Controls.Add(lblName);
            card.Controls.Add(pnlBarBg);
            card.Controls.Add(lblValue);

            return card;
        }

        private void lblTongPhieu_Click(object sender, EventArgs e)
        {

        }

        private void UCThongKePhieuPhat_Load(object sender, EventArgs e)
        {

        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
