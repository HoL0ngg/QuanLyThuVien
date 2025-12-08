using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class UCMain : BaseModuleUC
    {
        private UCThongKeSach ucThongKeSach;
        private UCThongKePhieuPhat ucThongKePhieuPhat;
        private UCThongKePhieuMuon ucThongKePhieuMuon;
        private UCThongKeDocGia ucThongKeDocGia;
        
        public UCMain()
        {
            InitializeComponent();
            SetupUI();
            InitializeActionButtons();

            this.tabControlTK.SelectedIndexChanged += TabControlTK_SelectedIndexChanged;
            this.tabControlTK.Selecting += TabControlTK_Selecting;
            this.btn_sach.Enter += Btn_sach_Enter;
            this.btn_phieuphat.Enter += Btn_phieuphat_Enter;
            if (this.btn_phieumuon != null)
                this.btn_phieumuon.Enter += Btn_phieumuon_Enter;
            if (this.btn_docgia != null)
                this.btn_docgia.Enter += Btn_docgia_Enter;
        }

        public UCMain(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        /// <summary>
        /// Khởi tạo ActionButtonsUC - Ẩn tất cả các nút vì Thống kê không cần CRUD
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
            
            // Ẩn tất cả nút vì Thống kê không cần CRUD
            if (ActionButtons != null)
            {
                ActionButtons.HideAllButtons();
            }
        }

        private void Btn_docgia_Enter(object sender, EventArgs e) => EnsureThongKeDocGiaLoaded();
        private void Btn_phieumuon_Enter(object sender, EventArgs e) => EnsureThongKePhieuMuonLoaded();
        private void Btn_phieuphat_Enter(object sender, EventArgs e) => EnsureThongKePhieuPhatLoaded();
        private void Btn_sach_Enter(object sender, EventArgs e) => EnsureThongKeSachLoaded();

        private void TabControlTK_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == btn_sach) EnsureThongKeSachLoaded();
            else if (e.TabPage == btn_phieuphat) EnsureThongKePhieuPhatLoaded();
            else if (this.btn_phieumuon != null && e.TabPage == btn_phieumuon) EnsureThongKePhieuMuonLoaded();
            else if (this.btn_docgia != null && e.TabPage == btn_docgia) EnsureThongKeDocGiaLoaded();
        }

        private void TabControlTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlTK.SelectedTab == btn_sach) EnsureThongKeSachLoaded();
            else if (tabControlTK.SelectedTab == btn_phieuphat) EnsureThongKePhieuPhatLoaded();
            else if (this.btn_phieumuon != null && tabControlTK.SelectedTab == btn_phieumuon) EnsureThongKePhieuMuonLoaded();
            else if (this.btn_docgia != null && tabControlTK.SelectedTab == btn_docgia) EnsureThongKeDocGiaLoaded();
        }

        private void EnsureThongKeSachLoaded()
        {
            if (ucThongKeSach == null || ucThongKeSach.IsDisposed)
            {
                btn_sach.Controls.Clear();
                ucThongKeSach = new UCThongKeSach { Dock = DockStyle.Fill };
                btn_sach.Controls.Add(ucThongKeSach);
            }
            else ucThongKeSach.LoadData();
        }

        private void EnsureThongKePhieuPhatLoaded()
        {
            if (ucThongKePhieuPhat == null || ucThongKePhieuPhat.IsDisposed)
            {
                btn_phieuphat.Controls.Clear();
                ucThongKePhieuPhat = new UCThongKePhieuPhat { Dock = DockStyle.Fill };
                btn_phieuphat.Controls.Add(ucThongKePhieuPhat);
            }
            else ucThongKePhieuPhat.LoadData();
        }

        private void EnsureThongKePhieuMuonLoaded()
        {
            if (ucThongKePhieuMuon == null || ucThongKePhieuMuon.IsDisposed)
            {
                if (this.btn_phieumuon == null) return;
                btn_phieumuon.Controls.Clear();
                ucThongKePhieuMuon = new UCThongKePhieuMuon { Dock = DockStyle.Fill };
                btn_phieumuon.Controls.Add(ucThongKePhieuMuon);
            }
            else ucThongKePhieuMuon.LoadData();
        }

        private void EnsureThongKeDocGiaLoaded()
        {
            if (ucThongKeDocGia == null || ucThongKeDocGia.IsDisposed)
            {
                if (this.btn_docgia == null) return;
                btn_docgia.Controls.Clear();
                ucThongKeDocGia = new UCThongKeDocGia { Dock = DockStyle.Fill };
                btn_docgia.Controls.Add(ucThongKeDocGia);
            }
            else ucThongKeDocGia.LoadData();
        }

        private void SetupUI()
        {
            if (this.btn_tongquan == null) return;
            if (this.dtpTo != null) this.dtpTo.Value = DateTime.Now.Date;
            if (this.dtpFrom != null) this.dtpFrom.Value = DateTime.Now.Date.AddDays(-7);
            SetupChartPanel(panelTrend, "📊 XU HƯỚNG MƯỢN/TRẢ");
            SetupChartPanel(panelTop5, "🏆 TOP 5 SÁCH MƯỢN NHIỀU");
            SetupChartPanel(panelCategory, "📚 CƠ CẤU THỂ LOẠI");
            BtnGenerate_Click(this, EventArgs.Empty);
        }

        private void SetupChartPanel(Panel p, string title)
        {
            if (p == null) return;
            p.Controls.Clear();
            var lblTitle = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(66, 66, 66),
            };
            var contentPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(5),
                BackColor = Color.FromArgb(250, 250, 250)
            };
            contentPanel.Name = "content_" + p.Name;
            p.Controls.Add(contentPanel);
            p.Controls.Add(lblTitle);
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = (this.dtpFrom != null) ? this.dtpFrom.Value.Date : DateTime.Now.Date.AddMonths(-1);
                DateTime to = (this.dtpTo != null) ? this.dtpTo.Value.Date : DateTime.Now.Date;
                
                var overview = ThongKeBUS.Instance.GetOverviewOptimized(from, to);
                if (overview != null)
                {
                    if (kpiBorrow != null) kpiBorrow.Text = overview.TongLuotMuon.ToString("N0");
                    if (kpiBooks != null) kpiBooks.Text = overview.TongSachTrongKho.ToString("N0");
                    if (kpiOverdue != null) kpiOverdue.Text = overview.SachMatHong.ToString("N0");
                    if (kpiPenalty != null) kpiPenalty.Text = overview.TongThuPhiPhat.ToString("N0") + " đ";
                }
                
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        FillTrendPanel();
                        FillTop5Panel();
                        FillCategoryPanel();
                    }));
                }
                else
                {
                    FillTrendPanel();
                    FillTop5Panel();
                    FillCategoryPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi thong ke: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillTrendPanel()
        {
            if (panelTrend == null) return;
            var content = panelTrend.Controls.Find("content_panelTrend", false).FirstOrDefault() as FlowLayoutPanel;
            if (content == null) return;
            content.Controls.Clear();

            List<ThongKeOverviewDTO> trendData = ThongKeBUS.Instance.GetTrendAll12Months();
            
            var items = new List<(string Label, int Muon, int Tra)>();
            for (int i = 0; i < 12; i++)
            {
                items.Add(("Tháng " + (i + 1), trendData[i].TongMuon, trendData[i].TongTra));
            }

            int maxValue = items.Max(x => Math.Max(x.Muon, x.Tra));
            if (maxValue == 0) maxValue = 1;

            int containerWidth = panelTrend.Width - panelTrend.Padding.Horizontal - 10;
            if (containerWidth < 200) containerWidth = 280;

            foreach (var item in items)
            {
                var card = CreateTrendBarCard(item.Label, item.Muon, item.Tra, maxValue, containerWidth);
                content.Controls.Add(card);
            }
        }

        private Panel CreateTrendBarCard(string label, int muon, int tra, int maxValue, int containerWidth)
        {
            int panelWidth = containerWidth - 30;
            if (panelWidth < 200) panelWidth = 400;

            var card = new Panel { Size = new Size(panelWidth, 50), Margin = new Padding(2), BackColor = Color.Transparent };

            int labelWidth = 80, valueWidth = 80;
            int barStartX = labelWidth + 5;
            int barMaxWidth = (panelWidth - labelWidth - valueWidth - 20) / 2;

            var lblName = new Label { Text = label, Location = new Point(0, 15), Size = new Size(labelWidth, 20), Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(33, 33, 33), TextAlign = ContentAlignment.MiddleLeft };

            double percentMuon = maxValue > 0 ? (double)muon / maxValue : 0;
            int barWidthMuon = (int)(barMaxWidth * percentMuon);
            if (barWidthMuon < 2 && muon > 0) barWidthMuon = 2;

            var pnlBarBgMuon = new Panel { Location = new Point(barStartX, 5), Size = new Size(barMaxWidth, 16), BackColor = Color.FromArgb(230, 230, 230) };
            var pnlBarMuon = new Panel { Location = new Point(0, 0), Size = new Size(barWidthMuon, 16), BackColor = Color.FromArgb(33, 150, 243) };
            pnlBarBgMuon.Controls.Add(pnlBarMuon);

            var lblMuon = new Label { Text = muon.ToString("N0") + " mượn", Location = new Point(barStartX + barMaxWidth + 5, 5), Size = new Size(valueWidth, 16), Font = new Font("Segoe UI", 8F, FontStyle.Bold), ForeColor = Color.FromArgb(33, 150, 243), TextAlign = ContentAlignment.MiddleLeft };

            double percentTra = maxValue > 0 ? (double)tra / maxValue : 0;
            int barWidthTra = (int)(barMaxWidth * percentTra);
            if (barWidthTra < 2 && tra > 0) barWidthTra = 2;

            var pnlBarBgTra = new Panel { Location = new Point(barStartX, 28), Size = new Size(barMaxWidth, 16), BackColor = Color.FromArgb(230, 230, 230) };
            var pnlBarTra = new Panel { Location = new Point(0, 0), Size = new Size(barWidthTra, 16), BackColor = Color.FromArgb(76, 175, 80) };
            pnlBarBgTra.Controls.Add(pnlBarTra);

            var lblTra = new Label { Text = tra.ToString("N0") + " trả", Location = new Point(barStartX + barMaxWidth + 5, 28), Size = new Size(valueWidth, 16), Font = new Font("Segoe UI", 8F, FontStyle.Bold), ForeColor = Color.FromArgb(76, 175, 80), TextAlign = ContentAlignment.MiddleLeft };

            card.Controls.AddRange(new Control[] { lblName, pnlBarBgMuon, lblMuon, pnlBarBgTra, lblTra });
            return card;
        }

        private void FillTop5Panel()
        {
            if (panelTop5 == null) return;
            var content = panelTop5.Controls.Find("content_panelTop5", false).FirstOrDefault() as FlowLayoutPanel;
            if (content == null) return;
            content.Controls.Clear();
            List<ThongKeOverviewDTO> bus = ThongKeBUS.Instance.GetTop5SachMuon();
            var items = new List<(string Label, int Value, Color BarColor)>
            {
                (bus[0].TenDauSach, bus[0].SoLanMuon, Color.FromArgb(255, 193, 7)),
                (bus[1].TenDauSach, bus[1].SoLanMuon, Color.FromArgb(158, 158, 158)),
                (bus[2].TenDauSach, bus[2].SoLanMuon, Color.FromArgb(205, 127, 50)),
                (bus[3].TenDauSach, bus[3].SoLanMuon, Color.FromArgb(33, 150, 243)),
                (bus[4].TenDauSach, bus[4].SoLanMuon, Color.FromArgb(33, 150, 243))
            };

            int maxValue = items.Max(x => x.Value);
            if (maxValue == 0) maxValue = 1;

            int containerWidth = panelTop5.Width - panelTop5.Padding.Horizontal - 10;
            if (containerWidth < 200) containerWidth = 280;

            foreach (var item in items)
            {
                var card = CreateBarCard(item.Label, item.Value, maxValue, item.BarColor, "lượt mượn", containerWidth);
                content.Controls.Add(card);
            }
        }

        private void FillCategoryPanel()
        {
            if (panelCategory == null) return;
            var content = panelCategory.Controls.Find("content_panelCategory", false).FirstOrDefault() as FlowLayoutPanel;
            if (content == null) return;
            content.Controls.Clear();
            List<ThongKeOverviewDTO> bus = ThongKeBUS.Instance.GetTop5TheLoai();
            var items = new List<(string Label, int Value, Color BarColor)>
            {
                (bus[0].TenTheLoai, bus[0].SoLanMuon, Color.FromArgb(33, 150, 243)),
                (bus[1].TenTheLoai, bus[1].SoLanMuon, Color.FromArgb(156, 39, 176)),
                (bus[2].TenTheLoai, bus[2].SoLanMuon, Color.FromArgb(76, 175, 80)),
                (bus[3].TenTheLoai, bus[3].SoLanMuon, Color.FromArgb(255, 152, 0)),
                (bus[4].TenTheLoai, bus[4].SoLanMuon, Color.FromArgb(158, 158, 158))
            };

            int maxValue = items.Max(x => x.Value);
            if (maxValue == 0) maxValue = 1;

            int containerWidth = panelCategory.Width - panelCategory.Padding.Horizontal - 10;
            if (containerWidth < 200) containerWidth = 280;

            foreach (var item in items)
            {
                var card = CreateBarCard(item.Label, item.Value, maxValue, item.BarColor, "Lượt Mượn", containerWidth);
                content.Controls.Add(card);
            }
        }

        private Panel CreateBarCard(string label, int value, int maxValue, Color barColor, string unit, int containerWidth)
        {
            int panelWidth = containerWidth - 30;
            if (panelWidth < 200) panelWidth = 300;

            var card = new Panel { Size = new Size(panelWidth, 32), Margin = new Padding(2), BackColor = Color.Transparent };

            int labelWidth = 100, valueWidth = 90;
            int barStartX = labelWidth + 5;
            int barMaxWidth = panelWidth - labelWidth - valueWidth - 20;
            if (barMaxWidth < 50) barMaxWidth = 80;

            var lblName = new Label { Text = label, Location = new Point(0, 6), Size = new Size(labelWidth, 20), Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(33, 33, 33), TextAlign = ContentAlignment.MiddleLeft };

            double percent = maxValue > 0 ? (double)value / maxValue : 0;
            int barWidth = (int)(barMaxWidth * percent);
            if (barWidth < 2 && value > 0) barWidth = 2;

            var pnlBarBg = new Panel { Location = new Point(barStartX, 8), Size = new Size(barMaxWidth, 16), BackColor = Color.FromArgb(230, 230, 230) };
            var pnlBar = new Panel { Location = new Point(0, 0), Size = new Size(barWidth, 16), BackColor = barColor };
            pnlBarBg.Controls.Add(pnlBar);

            var lblValue = new Label { Text = value.ToString("N0") + " " + unit, Location = new Point(barStartX + barMaxWidth + 5, 6), Size = new Size(valueWidth, 20), Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = barColor, TextAlign = ContentAlignment.MiddleLeft };

            card.Controls.AddRange(new Control[] { lblName, pnlBarBg, lblValue });
            return card;
        }

        private void UCMain_Load(object sender, EventArgs e)
        {
            if (tabControlTK.SelectedTab == btn_sach) EnsureThongKeSachLoaded();
            else if (tabControlTK.SelectedTab == btn_phieuphat) EnsureThongKePhieuPhatLoaded();
            else if (this.btn_phieumuon != null && tabControlTK.SelectedTab == btn_phieumuon) EnsureThongKePhieuMuonLoaded();
        }

        public override void LoadData() => BtnGenerate_Click(this, EventArgs.Empty);

        private void BtnToday_Click(object sender, EventArgs e)
        {
            if (dtpFrom == null || dtpTo == null) return;
            dtpFrom.Value = DateTime.Now.Date;
            dtpTo.Value = DateTime.Now.Date;
            BtnGenerate_Click(this, EventArgs.Empty);
        }

        private void Btn7Days_Click(object sender, EventArgs e)
        {
            if (dtpFrom == null || dtpTo == null) return;
            dtpTo.Value = DateTime.Now.Date;
            dtpFrom.Value = DateTime.Now.Date.AddDays(-6);
            BtnGenerate_Click(this, EventArgs.Empty);
        }

        private void BtnThisMonth_Click(object sender, EventArgs e)
        {
            if (dtpFrom == null || dtpTo == null) return;
            var now = DateTime.Now;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1);
            dtpTo.Value = dtpFrom.Value.AddMonths(1).AddDays(-1);
            BtnGenerate_Click(this, EventArgs.Empty);
        }

        private void BtnThisYear_Click(object sender, EventArgs e)
        {
            if (dtpFrom == null || dtpTo == null) return;
            var now = DateTime.Now;
            dtpFrom.Value = new DateTime(now.Year, 1, 1);
            dtpTo.Value = new DateTime(now.Year, 12, 31);
            BtnGenerate_Click(this, EventArgs.Empty);
        }

        private void lblKpi1Title_Click(object sender, EventArgs e) { }
        private void kpiBorrow_Click(object sender, EventArgs e) { }
        private void kpiBooks_Click(object sender, EventArgs e) { }
        private void dtpFrom_ValueChanged(object sender, EventArgs e) { }
    }
}
