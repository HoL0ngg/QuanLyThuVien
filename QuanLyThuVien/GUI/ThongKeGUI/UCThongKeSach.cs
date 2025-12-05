using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class UCThongKeSach : UserControl
    {
        public UCThongKeSach()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                // Load KPI - dữ liệu mẫu
                lblTongDauSach.Text = "150";
                lblTongBanSach.Text = "755";
                lblSachCoSan.Text = "620";
                lblSachBaoTri.Text = "12";

                // Load Thể loại
                LoadTheLoai();

                // Load Năm xuất bản
                LoadNamXuatBan();

                // Load bảng chi tiết
                LoadChiTietSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTheLoai()
        {
            flpTheLoai.Controls.Clear();
            
            // Dữ liệu mẫu - Top 10 thể loại
            var data = new List<(string ten, int soLuong, int max)>
            {
                ("Văn học", 45, 45),
                ("Truyện tranh", 38, 45),
                ("Khoa học", 32, 45),
                ("Lịch sử", 28, 45),
                ("Kỹ năng sống", 25, 45),
                ("Tiểu thuyết", 22, 45),
                ("Triết học", 18, 45),
                ("Kinh tế", 15, 45),
                ("Công nghệ", 12, 45),
                ("Nghệ thuật", 10, 45)
            };

            foreach (var item in data)
            {
                var card = CreateBarCard(item.ten, item.soLuong, item.max, Color.FromArgb(33, 150, 243));
                flpTheLoai.Controls.Add(card);
            }
        }

        private void LoadNamXuatBan()
        {
            flpNamXB.Controls.Clear();

            // Dữ liệu mẫu - 5 năm gần nhất
            var currentYear = DateTime.Now.Year;
            var data = new List<(int nam, int soLuong, int max)>
            {
                (currentYear, 65, 65),
                (currentYear - 1, 58, 65),
                (currentYear - 2, 42, 65),
                (currentYear - 3, 35, 65),
                (currentYear - 4, 28, 65)
            };

            foreach (var item in data)
            {
                var card = CreateBarCard($"Năm {item.nam}", item.soLuong, item.max, Color.FromArgb(76, 175, 80));
                flpNamXB.Controls.Add(card);
            }
        }

        private Panel CreateBarCard(string label, int value, int maxValue, Color barColor)
        {
            var panel = new Panel
            {
                Width = flpTheLoai.Width - 30,
                Height = 50,
                Margin = new Padding(5, 3, 5, 3),
                BackColor = Color.White
            };

            var lblName = new Label
            {
                Text = label,
                Location = new Point(8, 8),
                Width = 150,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33)
            };

            var lblValue = new Label
            {
                Text = value.ToString("N0") + " đầu sách",
                Location = new Point(8, 28),
                Width = 150,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(117, 117, 117)
            };

            // Progress bar background
            int barMaxWidth = panel.Width - 180;
            int barWidth = maxValue > 0 ? (int)((double)value / maxValue * barMaxWidth) : 0;
            
            var progressBg = new Panel
            {
                Location = new Point(170, 15),
                Width = barMaxWidth,
                Height = 20,
                BackColor = Color.FromArgb(230, 230, 230)
            };
            
            var progressBar = new Panel
            {
                Location = new Point(0, 0),
                Width = barWidth,
                Height = 20,
                BackColor = barColor
            };
            
            progressBg.Controls.Add(progressBar);
            panel.Controls.AddRange(new Control[] { lblName, lblValue, progressBg });
            
            return panel;
        }

        private void LoadChiTietSach()
        {
            // Dữ liệu mẫu cho bảng
            var data = new List<object[]>
            {
                new object[] { 1, "Harry Potter và Hòn đá Phù thủy", "Văn học", 10, 0, "Còn sử dụng", "5,000,000 đ" },
                new object[] { 2, "Doraemon tập 1", "Truyện tranh", 15, 2, "Đã thanh lý 2 bản", "3,500,000 đ" },
                new object[] { 3, "Đắc Nhân Tâm", "Kỹ năng sống", 8, 0, "Còn sử dụng", "2,400,000 đ" },
                new object[] { 4, "Nhà Giả Kim", "Văn học", 5, 1, "Chờ thanh lý 1 bản", "1,800,000 đ" },
                new object[] { 5, "Sapiens", "Khoa học", 6, 0, "Còn sử dụng", "3,000,000 đ" },
                new object[] { 6, "Lập Trình C#", "Công nghệ", 4, 2, "Chờ thanh lý 2 bản", "1,200,000 đ" },
                new object[] { 7, "Tuổi Thơ Dữ Dội", "Văn học", 7, 0, "Còn sử dụng", "2,100,000 đ" },
                new object[] { 8, "One Piece tập 100", "Truyện tranh", 12, 3, "Đã thanh lý 3 bản", "2,700,000 đ" }
            };

            dgvChiTiet.Rows.Clear();
            foreach (var row in data)
            {
                dgvChiTiet.Rows.Add(row);
            }

            // Tô màu cột trạng thái
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                var cell = row.Cells["colTrangThai"];
                if (cell.Value != null)
                {
                    string tt = cell.Value.ToString();
                    if (tt.Contains("Còn sử dụng"))
                        cell.Style.ForeColor = Color.FromArgb(76, 175, 80);
                    else if (tt.Contains("Đã thanh lý"))
                        cell.Style.ForeColor = Color.FromArgb(244, 67, 54);
                    else
                        cell.Style.ForeColor = Color.FromArgb(255, 152, 0);
                }
                
                // Highlight số bản hỏng
                var hongCell = row.Cells["colSoBanHong"];
                if (hongCell.Value != null && Convert.ToInt32(hongCell.Value) > 0)
                {
                    hongCell.Style.ForeColor = Color.FromArgb(244, 67, 54);
                    hongCell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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

            // Lọc theo keyword
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
    }
}
