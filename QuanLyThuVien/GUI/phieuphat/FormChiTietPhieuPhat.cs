using QuanLyThuVien.BUS;
using System;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormChiTietPhieuPhat : Form
    {
        private readonly int _maPhieuPhat;
        private int _id;        // Lưu Mã Phiếu Trả (nếu chưa lưu) HOẶC Mã Phiếu Phạt (nếu đã lưu)
        private bool _isHistory;
        // Add this line to declare lblTongTien
        private Label lblTongTien;

        public FormChiTietPhieuPhat(int id, bool isHistory)
        {
            InitializeComponent();

            // Correctly assign incoming id to the instance fields
            _maPhieuPhat = id;
            _id = id;
            _isHistory = isHistory;

            // Đặt tiêu đề Form cho dễ phân biệt
            this.Text = _isHistory ? $"Chi tiết phiếu phạt #{_id}" : $"Xem trước phạt (Phiếu trả #{_id})";

            // Đăng ký sự kiện Load
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += FormChiTietPhieuPhat_Load;
            }

            // Initialize lblTongTien if not done in designer
            lblTongTien = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(10, 10), // Adjust location as needed
                Name = "lblTongTien"
            };
            this.Controls.Add(lblTongTien);

            // tránh Designer chạy logic
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        }

        //private void FormChiTietPhieuPhat_Load(object sender, EventArgs e)
        //{
        //    LoadDetails();
        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormChiTietPhieuPhat_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                DataTable dt;

                if (_isHistory)
                {
                    // TRƯỜNG HỢP 1: ĐÃ LƯU -> Gọi BUS lấy từ bảng ctphieu_phat
                    dt = PhieuPhatBUS.Instance.GetChiTietPhieuPhatDaLuu(_id);
                }
                else
                {
                    // TRƯỜNG HỢP 2: CHƯA LƯU -> Gọi BUS tính toán từ phieu_tra
                    dt = PhieuPhatBUS.Instance.GetChiTietPhieuPhat(_id);
                }

                dgv.DataSource = dt;
                FormatGrid(dt); // Gọi hàm format giao diện (code hàm này ở dưới)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void FormatGrid(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.ColumnHeadersHeight = 40;

            // Ẩn các cột ID hệ thống
            string[] hiddenCols = { "MaPhieuTra", "MaPhieuPhat", "MaCTPhieuPhat" };
            foreach (string col in hiddenCols)
            {
                if (dgv.Columns.Contains(col)) dgv.Columns[col].Visible = false;
            }

            // Đặt tên cột hiển thị
            if (dgv.Columns.Contains("TenDauSach")) dgv.Columns["TenDauSach"].HeaderText = "Tên Sách";
            if (dgv.Columns.Contains("NgayTra")) dgv.Columns["NgayTra"].HeaderText = "Ngày Trả";
            if (dgv.Columns.Contains("NgayTraDuKien")) dgv.Columns["NgayTraDuKien"].HeaderText = "Hạn Trả";
            if (dgv.Columns.Contains("SoNgayTre")) dgv.Columns["SoNgayTre"].HeaderText = "Trễ (Ngày)";
            if (dgv.Columns.Contains("TinhTrangSach")) dgv.Columns["TinhTrangSach"].HeaderText = "Lỗi Vi Phạm";
            if (dgv.Columns.Contains("TongTienPhat")) dgv.Columns["TongTienPhat"].HeaderText = "Tiền Phạt";

            // Căn chỉnh độ rộng
            if (dgv.Columns.Contains("TenDauSach")) dgv.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (dgv.Columns.Contains("TongTienPhat"))
            {
                dgv.Columns["TongTienPhat"].DefaultCellStyle.Format = "N0";
                dgv.Columns["TongTienPhat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Tính tổng tiền hiển thị lên Label
            long tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["TongTienPhat"] != DBNull.Value)
                    tongTien += Convert.ToInt64(row["TongTienPhat"]);
            }
            if (lblTongTien != null) lblTongTien.Text = $"Tổng cộng: {tongTien:N0} VNĐ";
        }


        private void LoadDetails()
        {
            try
            {
                DataTable dt = PhieuPhatBUS.Instance.GetChiTietPhieuPhat(_maPhieuPhat);
                dgv.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    // --- 1. CẤU HÌNH CƠ BẢN CHO GRID ---
                    // Tắt tự động giãn toàn bộ để tránh bị vỡ giao diện như trong hình
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    // Chỉnh chiều cao tiêu đề cột cho thoáng
                    dgv.ColumnHeadersHeight = 40;
                    dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                    // --- 2. ĐẶT TÊN CỘT TIẾNG VIỆT ---
                    dgv.Columns["MaPhieuTra"].HeaderText = "Mã PT";
                    dgv.Columns["TenDauSach"].HeaderText = "Tên Sách";
                    dgv.Columns["NgayTra"].HeaderText = "Ngày Trả";
                    dgv.Columns["NgayTraDuKien"].HeaderText = "Hạn Trả";
                    dgv.Columns["SoNgayTre"].HeaderText = "Trễ (Ngày)";
                    dgv.Columns["TinhTrangSach"].HeaderText = "Tình Trạng";
                    dgv.Columns["TongTienPhat"].HeaderText = "Tiền Phạt";

                    // --- 3. ẨN CỘT KHÔNG CẦN THIẾT ---
                    dgv.Columns["MaPhieuTra"].Visible = false;

                    // --- 4. SET ĐỘ RỘNG (WIDTH) CỐ ĐỊNH CHO CÁC CỘT NHỎ ---
                    dgv.Columns["NgayTra"].Width = 100;
                    dgv.Columns["NgayTraDuKien"].Width = 100;
                    dgv.Columns["SoNgayTre"].Width = 90;
                    dgv.Columns["TinhTrangSach"].Width = 100;
                    dgv.Columns["TongTienPhat"].Width = 130;

                    // --- 5. QUAN TRỌNG: CHO CỘT TÊN SÁCH GIÃN HẾT PHẦN CÒN LẠI ---
                    // Phải đặt dòng này SAU khi đã set width cho các cột kia
                    dgv.Columns["TenDauSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    // --- 6. ĐỊNH DẠNG DỮ LIỆU (FORMAT) ---
                    dgv.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgv.Columns["NgayTra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgv.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgv.Columns["NgayTraDuKien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgv.Columns["SoNgayTre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns["TinhTrangSach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgv.Columns["TongTienPhat"].DefaultCellStyle.Format = "N0"; // 3,600
                    dgv.Columns["TongTienPhat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // --- 7. TÍNH TỔNG TIỀN ---
                    decimal tongTien = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TongTienPhat"] != DBNull.Value)
                        {
                            tongTien += Convert.ToDecimal(row["TongTienPhat"]);
                        }
                    }

                    // Cập nhật Label tổng tiền (nếu có)
                    if (lblTongTien != null)
                    {
                        lblTongTien.Text = $"Tổng cộng: {tongTien.ToString("N0")} VNĐ";
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}