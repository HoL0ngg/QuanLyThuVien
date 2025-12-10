using QuanLyThuVien.BUS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class UCThongKeSach : UserControl
    {
        private bool _isLoaded = false;

        public UCThongKeSach()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.AllPaintingInWmPaint, true);
            
            InitializeComponent();
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
            if (!_isLoaded && !this.IsHandleCreated)
                return;

            this.SuspendLayout();
            try
            {
                LoadKPIs();
                LoadTheLoai();
                LoadNamXuatBan();
                LoadChiTietSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }

        private void LoadKPIs()
        {
            ThongKeBUS bUS = ThongKeBUS.Instance;
            lblTongDauSach.Text = bUS.GetTongDauSach().ToString("N0");
            lblTongBanSach.Text = bUS.GetTongBanSach().ToString("N0");
            lblSachCoSan.Text = bUS.GetSachSanSangChoMuon().ToString("N0");
            lblSachBaoTri.Text = bUS.GetSoSachHongMat().ToString("N0");
        }

        private void LoadTheLoai()
        {
            flpTheLoai.SuspendLayout();
            flpTheLoai.Controls.Clear();
            ThongKeBUS bus = ThongKeBUS.Instance;
            
            var items = new List<(string Label, int Value, Color BarColor)>
            {
                (bus.GetSoLuongSachTheoTheLoai()[0].TheLoai, bus.GetSoLuongSachTheoTheLoai()[0].TongSoBan, Color.FromArgb(33, 150, 243)),
                (bus.GetSoLuongSachTheoTheLoai()[1].TheLoai, bus.GetSoLuongSachTheoTheLoai()[1].TongSoBan, Color.FromArgb(33, 150, 243)),
                (bus.GetSoLuongSachTheoTheLoai()[2].TheLoai, bus.GetSoLuongSachTheoTheLoai()[2].TongSoBan, Color.FromArgb(33, 150, 243)),
                (bus.GetSoLuongSachTheoTheLoai()[3].TheLoai, bus.GetSoLuongSachTheoTheLoai()[3].TongSoBan, Color.FromArgb(33, 150, 243)),
                (bus.GetSoLuongSachTheoTheLoai()[4].TheLoai, bus.GetSoLuongSachTheoTheLoai()[4].TongSoBan, Color.FromArgb(33, 150, 243)),
                (bus.GetSoLuongSachTheoTheLoai()[5].TheLoai, bus.GetSoLuongSachTheoTheLoai()[5].TongSoBan, Color.FromArgb(33, 150, 243)),
                (bus.GetSoLuongSachTheoTheLoai()[6].TheLoai, bus.GetSoLuongSachTheoTheLoai()[6].TongSoBan, Color.FromArgb(33, 150, 243)),
                (bus.GetSoLuongSachTheoTheLoai()[7].TheLoai, bus.GetSoLuongSachTheoTheLoai()[7].TongSoBan, Color.FromArgb(33, 150, 243)),
                
           
            };

            int maxValue = 45;
            foreach (var item in items)
            {
                var card = CreateBarCard(item.Label, item.Value, maxValue, item.BarColor, "đầu sách", flpTheLoai.Width);
                flpTheLoai.Controls.Add(card);
            }

            flpTheLoai.ResumeLayout(true);
        }

        private void LoadNamXuatBan()
        {
            flpNamXB.SuspendLayout();
            flpNamXB.Controls.Clear();

            ThongKeBUS bus = ThongKeBUS.Instance;
            var data = bus.GetSoLuongSachTheoNam(); // giả sử trả về List<SachTheoNamDTO>

            // Tạo list items từ dữ liệu
            var items = new List<(string Label, int Value, Color BarColor)>();
            foreach (var item in data)
            {
                items.Add((
                    $"Năm {item.NamXuatBan}",
                    item.TongSoBan,
                    Color.FromArgb(76, 175, 80)
                ));
            }

            // Tìm giá trị lớn nhất để chuẩn hóa chiều dài bar
            int maxValue = items.Count > 0 ? items.Max(x => x.Value) : 0;

            // Tạo card cho từng item
            foreach (var item in items)
            {
                var card = CreateBarCard(item.Label, item.Value, maxValue, item.BarColor, "đầu sách", flpNamXB.Width);
                flpNamXB.Controls.Add(card);
            }

            flpNamXB.ResumeLayout(true);
        }

        private Panel CreateBarCard(string label, int value, int maxValue, Color barColor, string unit, int containerWidth)
        {
            int panelWidth = containerWidth - 30;
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

        private void LoadChiTietSach()
        {
            dgvChiTiet.SuspendLayout();
            try
            {
                dgvChiTiet.Rows.Clear();

                // gọi BUS để lấy dữ liệu
                var data = ThongKeBUS.Instance.GetChiTietSach();

                int stt = 1; // biến số thứ tự

                foreach (var item in data)
                {
                    dgvChiTiet.Rows.Add(
                        stt, // thêm số thứ tự vào cột đầu tiên
                        item.TenSach,
                        item.TheLoai,
                        item.TongSoBan,
                        item.SachHong,
                        item.TinhTrang,
                        item.GiaTriUocTinh.ToString("N0") + " đ"
                    );

                    stt++; // tăng số thứ tự
                }

                ApplyRowStyles();
            }
            finally
            {
                dgvChiTiet.ResumeLayout(true);
            }
        }

        private void ApplyRowStyles()
        {
            var redColor = Color.FromArgb(244, 67, 54);
            var greenColor = Color.FromArgb(76, 175, 80);
            var orangeColor = Color.FromArgb(255, 152, 0);
            var boldFont = new Font("Segoe UI", 9F, FontStyle.Bold);

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                var cell = row.Cells["colTrangThai"];
                if (cell.Value != null)
                {
                    string tt = cell.Value.ToString();
                    if (tt.Contains("Còn sử dụng"))
                        cell.Style.ForeColor = greenColor;
                    else if (tt.Contains("Đã thanh lý"))
                        cell.Style.ForeColor = redColor;
                    else
                        cell.Style.ForeColor = orangeColor;
                }
                
                var hongCell = row.Cells["colSoBanHong"];
                if (hongCell.Value != null && Convert.ToInt32(hongCell.Value) > 0)
                {
                    hongCell.Style.ForeColor = redColor;
                    hongCell.Style.Font = boldFont;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadChiTietSach();
                return;
            }

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                bool visible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(keyword))
                    {
                        visible = true;
                        break;
                    }
                }
                row.Visible = visible;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }

        private void lblKpi4Title_Click(object sender, EventArgs e)
        {

        }
    }
}
