using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            this.tabControlTK.SelectedIndexChanged += TabControlTK_SelectedIndexChanged;
            this.tabControlTK.Selecting += TabControlTK_Selecting;
            this.btn_sach.Enter += Btn_sach_Enter;
            this.btn_phieuphat.Enter += Btn_phieuphat_Enter;
            if (this.btn_phieumuon != null)
                this.btn_phieumuon.Enter += Btn_phieumuon_Enter;
            if (this.btn_docgia != null)
                this.btn_docgia.Enter += Btn_docgia_Enter;
        }

        private void Btn_docgia_Enter(object sender, EventArgs e)
        {
            EnsureThongKeDocGiaLoaded();
        }

        private void Btn_phieumuon_Enter(object sender, EventArgs e)
        {
            EnsureThongKePhieuMuonLoaded();
        }

        private void Btn_phieuphat_Enter(object sender, EventArgs e)
        {
            EnsureThongKePhieuPhatLoaded();
        }

        private void Btn_sach_Enter(object sender, EventArgs e)
        {
            EnsureThongKeSachLoaded();
        }

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
            else
            {
                ucThongKeSach.LoadData();
            }
        }

        private void EnsureThongKePhieuPhatLoaded()
        {
            if (ucThongKePhieuPhat == null || ucThongKePhieuPhat.IsDisposed)
            {
                btn_phieuphat.Controls.Clear();
                ucThongKePhieuPhat = new UCThongKePhieuPhat { Dock = DockStyle.Fill };
                btn_phieuphat.Controls.Add(ucThongKePhieuPhat);
            }
            else
            {
                ucThongKePhieuPhat.LoadData();
            }
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
            else
            {
                ucThongKePhieuMuon.LoadData();
            }
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
            else
            {
                ucThongKeDocGia.LoadData();
            }
        }

        private void SetupUI()
        {
            if (this.btn_tongquan == null) return;
            if (this.dtpTo != null) this.dtpTo.Value = DateTime.Now.Date;
            if (this.dtpFrom != null) this.dtpFrom.Value = DateTime.Now.Date.AddDays(-7);
            SetupChartPanel(panelTrend, "XU HƯỚNG MƯỢN/TRẢ");
            SetupChartPanel(panelTop5, "TOP 5 SÁCH VÀ ĐỘC GIẢ");
            SetupChartPanel(panelCategory, "CƠ CẤU THỂ LOẠI");
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
                ForeColor = Color.FromArgb(117, 117, 117),
            };
            var contentPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(0, 5, 0, 0)
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
                var overview = ThongKeBUS.Instance.GetOverview(from, to);
                if (overview != null)
                {
                    if (kpiBorrow != null) kpiBorrow.Text = overview.TongLuotMuon.ToString("N0");
                    if (kpiBooks != null) kpiBooks.Text = overview.TongSachTrongKho.ToString("N0");
                    if (kpiOverdue != null) kpiOverdue.Text = overview.SachQuaHan.ToString("N0");
                    if (kpiPenalty != null) kpiPenalty.Text = overview.TongThuPhiPhat.ToString("N0") + " đ";
                    if (lblTotalCount != null) lblTotalCount.Text = $"Số phiếu: {overview.SoPhieuMuon + overview.SoPhieuTra:N0}";
                    if (lblTotalAmount != null) lblTotalAmount.Text = $"Tổng thu: {overview.TongThuPhiPhat:N0} đ";
                    if (lblOutstanding != null) lblOutstanding.Text = "Chưa thu: 0 đ";
                    if (lblUniqueReaders != null) lblUniqueReaders.Text = $"Độc giả liên quan: {overview.SoDocGiaLienQuan:N0}";
                }
                FillTrendPanel();
                FillTop5Panel();
                FillCategoryPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillTrendPanel()
        {
            if (panelTrend == null) return;
            var content = panelTrend.Controls.Find("content_panelTrend", false).FirstOrDefault() as FlowLayoutPanel;
            if (content == null) return;
            content.Controls.Clear();
            var data = new[] { "Tháng 1: 45 mượn / 40 trả", "Tháng 2: 52 mượn / 48 trả", "Tháng 3: 38 mượn / 35 trả" };
            foreach (var item in data) content.Controls.Add(CreateDataLabel(item, Color.FromArgb(33, 150, 243)));
        }

        private void FillTop5Panel()
        {
            if (panelTop5 == null) return;
            var content = panelTop5.Controls.Find("content_panelTop5", false).FirstOrDefault() as FlowLayoutPanel;
            if (content == null) return;
            content.Controls.Clear();
            var books = new[] { ("Harry Potter", 25), ("Doraemon", 20), ("Tuổi Thơ Dữ Dội", 18), ("Nhà Giả Kim", 15), ("Đắc Nhân Tâm", 12) };
            foreach (var b in books) content.Controls.Add(CreateDataLabel($"{b.Item1}: {b.Item2} lượt", Color.FromArgb(76, 175, 80)));
        }

        private void FillCategoryPanel()
        {
            if (panelCategory == null) return;
            var content = panelCategory.Controls.Find("content_panelCategory", false).FirstOrDefault() as FlowLayoutPanel;
            if (content == null) return;
            content.Controls.Clear();
            var cats = new[] { ("Văn học", 30), ("Thiếu nhi", 25), ("Khoa học", 20), ("Lịch sử", 15), ("Khác", 10) };
            foreach (var c in cats) content.Controls.Add(CreateDataLabel($"{c.Item1}: {c.Item2}%", Color.FromArgb(255, 152, 0)));
        }

        private Label CreateDataLabel(string text, Color bulletColor)
        {
            return new Label
            {
                Text = "● " + text,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(66, 66, 66),
                Margin = new Padding(0, 4, 0, 4)
            };
        }

        private void UCMain_Load(object sender, EventArgs e)
        {
            if (tabControlTK.SelectedTab == btn_sach) EnsureThongKeSachLoaded();
            else if (tabControlTK.SelectedTab == btn_phieuphat) EnsureThongKePhieuPhatLoaded();
            else if (this.btn_phieumuon != null && tabControlTK.SelectedTab == btn_phieumuon) EnsureThongKePhieuMuonLoaded();
        }

        public override void LoadData()
        {
            BtnGenerate_Click(this, EventArgs.Empty);
        }

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
    }
}
