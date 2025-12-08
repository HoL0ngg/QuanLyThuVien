using QuanLyThuVien.BUS;
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
    public partial class UCThongKeDocGia : UserControl
    {
        public UCThongKeDocGia()
        {
            InitializeComponent();
            SetupComboBox();
            SetupEvents();
            LoadData();
        }

        private void SetupComboBox()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Tất cả", "Đang mượn", "Quá hạn", "Có nợ phạt", "Không nợ" });
            cboTrangThai.SelectedIndex = 0;
        }

        private void SetupEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            btnRefresh.Click += BtnRefresh_Click;
            cboTrangThai.SelectedIndexChanged += CboTrangThai_SelectedIndexChanged;
            txtSearch.KeyDown += TxtSearch_KeyDown;
        }

        /// <summary>
        /// Loads or refreshes the data for the DocGia statistics user control.
        /// </summary>
        public void LoadData()
        {
            try
            {
                LoadKPIs();
                LoadCoCauHoatDong();
                LoadTop5DocGia();
                LoadChiTietDocGia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKPIs()
        {
            DataRow kpis = ThongKeBUS.Instance.GetDocGiaKPIs();
            if (kpis != null)
            {
                lblTongDocGia.Text = Convert.ToInt32(kpis["TongDocGia"]).ToString("N0");
                lblDocGiaMoi.Text = Convert.ToInt32(kpis["DocGiaMoi"]).ToString("N0");
                lblDocGiaHoatDong.Text = Convert.ToInt32(kpis["DocGiaHoatDong"]).ToString("N0");
                lblDocGiaNoTien.Text = Convert.ToInt32(kpis["DocGiaNoTien"]).ToString("N0");
            }
        }

        private void LoadCoCauHoatDong()
        {
            flpPhanBo.Controls.Clear();

            DataTable dt = ThongKeBUS.Instance.GetCoCauHoatDongDocGia();
            if (dt == null || dt.Rows.Count == 0) return;

            int maxValue = 0;
            foreach (DataRow row in dt.Rows)
            {
                int val = Convert.ToInt32(row["SoLuong"]);
                if (val > maxValue) maxValue = val;
            }

            Color[] colors = new Color[]
            {
                Color.FromArgb(33, 150, 243),   // Đang mượn - Blue
                Color.FromArgb(76, 175, 80),    // Đã trả - Green
                Color.FromArgb(244, 67, 54),    // Quá hạn - Red
                Color.FromArgb(158, 158, 158)   // Chưa mượn - Gray
            };

            int colorIndex = 0;
            foreach (DataRow row in dt.Rows)
            {
                string trangThai = row["TrangThai"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                Color color = colors[colorIndex % colors.Length];

                var card = CreateBarCard(trangThai, soLuong, maxValue, color);
                flpPhanBo.Controls.Add(card);
                colorIndex++;
            }
        }

        private void LoadTop5DocGia()
        {
            flpTop5.Controls.Clear();

            DataTable dt = ThongKeBUS.Instance.GetTop5DocGiaMuonNhieu();
            if (dt == null || dt.Rows.Count == 0)
            {
                flpTop5.Controls.Add(new Label
                {
                    Text = "Chưa có dữ liệu",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(117, 117, 117),
                    Margin = new Padding(10)
                });
                return;
            }

            int maxValue = Convert.ToInt32(dt.Rows[0]["TongLuotMuon"]);

            int rank = 1;
            foreach (DataRow row in dt.Rows)
            {
                string tenDocGia = row["TenDocGia"].ToString();
                int tongLuot = Convert.ToInt32(row["TongLuotMuon"]);

                Color color = GetRankColor(rank);
                var card = CreateBarCard($"#{rank} {tenDocGia}", tongLuot, maxValue, color, "lượt mượn");
                flpTop5.Controls.Add(card);
                rank++;
            }
        }

        private Color GetRankColor(int rank)
        {
            switch (rank)
            {
                case 1: return Color.FromArgb(255, 193, 7);   // Gold
                case 2: return Color.FromArgb(158, 158, 158); // Silver
                case 3: return Color.FromArgb(205, 127, 50);  // Bronze
                default: return Color.FromArgb(33, 150, 243); // Blue
            }
        }

        private void LoadChiTietDocGia()
        {
            string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            string keyword = txtSearch.Text.Trim();

            DataTable dt = ThongKeBUS.Instance.GetChiTietDocGia(trangThai, keyword);
            
            dgvChiTiet.Rows.Clear();
            if (dt == null) return;

            // Limit rows to prevent UI freeze
            int maxRows = 1000;
            int totalRows = dt.Rows.Count;
            int displayRows = Math.Min(maxRows, totalRows);

            for (int i = 0; i < displayRows; i++)
            {
                DataRow row = dt.Rows[i];
                int maDocGia = Convert.ToInt32(row["MaDocGia"]);
                string tenDocGia = row["TenDocGia"].ToString();
                string sdt = row["SDT"].ToString();
                int tongLuotMuon = Convert.ToInt32(row["TongLuotMuon"]);
                int sachDangGiu = Convert.ToInt32(row["SachDangGiu"]);
                int sachQuaHan = Convert.ToInt32(row["SachQuaHan"]);
                decimal tongPhiNo = Convert.ToDecimal(row["TongPhiNo"]);

                int rowIndex = dgvChiTiet.Rows.Add(
                    maDocGia,
                    tenDocGia,
                    sdt,
                    tongLuotMuon.ToString("N0"),
                    sachDangGiu.ToString("N0"),
                    sachQuaHan.ToString("N0"),
                    tongPhiNo.ToString("N0") + " đ"
                );

                // Highlight các ô đặc biệt
                DataGridViewRow dgvRow = dgvChiTiet.Rows[rowIndex];

                // Sách quá hạn > 0 -> đỏ
                if (sachQuaHan > 0)
                {
                    dgvRow.Cells["colSachQuaHan"].Style.ForeColor = Color.FromArgb(244, 67, 54);
                    dgvRow.Cells["colSachQuaHan"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }

                // Tổng phí nợ > 0 -> đỏ đậm
                if (tongPhiNo > 0)
                {
                    dgvRow.Cells["colTongPhiNo"].Style.ForeColor = Color.FromArgb(183, 28, 28);
                    dgvRow.Cells["colTongPhiNo"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }

                // Đang giữ sách > 0 -> xanh dương
                if (sachDangGiu > 0)
                {
                    dgvRow.Cells["colSachDangGiu"].Style.ForeColor = Color.FromArgb(33, 150, 243);
                }
            }
            
            // Show message if there are more rows
            if (totalRows > maxRows)
            {
                int rowIndex = dgvChiTiet.Rows.Add("", "", "", "", "", "", "Hiển thị " + maxRows + "/" + totalRows + " bản ghi");
                DataGridViewRow dgvRow = dgvChiTiet.Rows[rowIndex];
                dgvRow.DefaultCellStyle.ForeColor = Color.Gray;
                dgvRow.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            }
        }

        private Panel CreateBarCard(string label, int value, int maxValue, Color barColor, string unit = "độc giả")
        {
            var panel = new Panel
            {
                Width = flpPhanBo.Width - 30,
                Height = 35,
                Margin = new Padding(5, 2, 5, 2),
                BackColor = Color.White
            };

            var lblName = new Label
            {
                Text = label,
                Location = new Point(8, 8),
                Width = 160,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(33, 33, 33)
            };

            // Progress bar background
            int barMaxWidth = panel.Width - 280;
            int barWidth = maxValue > 0 ? (int)((double)value / maxValue * barMaxWidth) : 0;
            if (barWidth < 5 && value > 0) barWidth = 5;

            var progressBg = new Panel
            {
                Location = new Point(175, 8),
                Width = barMaxWidth,
                Height = 18,
                BackColor = Color.FromArgb(230, 230, 230)
            };

            var progressBar = new Panel
            {
                Location = new Point(0, 0),
                Width = barWidth,
                Height = 18,
                BackColor = barColor
            };

            var lblValue = new Label
            {
                Text = value.ToString("N0") + " " + unit,
                Location = new Point(panel.Width - 100, 8),
                Width = 95,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = barColor,
                TextAlign = ContentAlignment.MiddleRight
            };

            progressBg.Controls.Add(progressBar);
            panel.Controls.AddRange(new Control[] { lblName, progressBg, lblValue });

            return panel;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadChiTietDocGia();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboTrangThai.SelectedIndex = 0;
            LoadData();
        }

        private void CboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChiTietDocGia();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadChiTietDocGia();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
