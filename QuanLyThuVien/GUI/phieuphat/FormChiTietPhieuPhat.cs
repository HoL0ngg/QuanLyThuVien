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
            // Đảm bảo Grid tự động tạo cột nếu chưa có cấu hình
            dgv.AutoGenerateColumns = true;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable dt;
                if (_isHistory)
                {
                    // Lấy phiếu phạt đã lưu
                    dt = PhieuPhatBUS.Instance.GetChiTietPhieuPhatDaLuu(_id);
                }
                else
                {
                    // Xem trước phiếu phạt (từ phiếu trả)
                    dt = PhieuPhatBUS.Instance.GetChiTietPhieuPhat(_id);
                }

                // Kiểm tra xem có dữ liệu không
                if (dt == null || dt.Rows.Count == 0)
                {
                    // Nếu không có lỗi vi phạm nào, thông báo và không làm gì thêm
                    if (!_isHistory) MessageBox.Show("Phiếu trả này không có lỗi vi phạm nào cần phạt.", "Thông báo");
                    dgv.DataSource = null;
                    return;
                }

                dgv.DataSource = dt;
                FormatGrid(dt); // Format lại tên cột cho đẹp
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void FormatGrid(DataTable dt)
        {
            // Cấu hình giao diện bảng
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Giãn đều cột
            dgv.ColumnHeadersHeight = 40;

            // 1. Ẩn các cột ID hệ thống (Nếu cột đó tồn tại)
            string[] hiddenCols = { "MaPhieuTra", "MaPhieuPhat", "MaCTPhieuPhat", "MaSach" };
            foreach (string col in hiddenCols)
            {
                if (dgv.Columns.Contains(col)) dgv.Columns[col].Visible = false;
            }

            // 2. Đặt tên tiếng Việt có dấu cho cột (Kiểm tra cột tồn tại trước khi gán)
            if (dgv.Columns.Contains("TenDauSach"))
            {
                dgv.Columns["TenDauSach"].HeaderText = "Tên sách";
                dgv.Columns["TenDauSach"].FillWeight = 200; // Cột tên sách rộng hơn
            }

            if (dgv.Columns.Contains("NgayTra"))
            {
                dgv.Columns["NgayTra"].HeaderText = "Ngày trả";
                dgv.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgv.Columns.Contains("NgayTraDuKien"))
            {
                dgv.Columns["NgayTraDuKien"].HeaderText = "Hạn trả";
                dgv.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgv.Columns.Contains("SoNgayTre"))
            {
                dgv.Columns["SoNgayTre"].HeaderText = "Trễ (ngày)";
                dgv.Columns["SoNgayTre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgv.Columns.Contains("TinhTrangSach"))
            {
                dgv.Columns["TinhTrangSach"].HeaderText = "Tình trạng";
                dgv.Columns["TinhTrangSach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgv.Columns.Contains("TongTienPhat"))
            {
                dgv.Columns["TongTienPhat"].HeaderText = "Tiền phạt";
                dgv.Columns["TongTienPhat"].DefaultCellStyle.Format = "N0"; // Định dạng số tiền
                dgv.Columns["TongTienPhat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Nếu có cột MucTre, MucHong, MucMat (do query mới trả về), ẩn hoặc đổi tên hiện rõ nếu muốn
            if (dgv.Columns.Contains("MucTre")) dgv.Columns["MucTre"].HeaderText = "Mức trễ/ngày";
            if (dgv.Columns.Contains("MucHong")) dgv.Columns["MucHong"].HeaderText = "Phạt hỏng (cố định)";
            if (dgv.Columns.Contains("MucMat")) dgv.Columns["MucMat"].HeaderText = "Phạt mất (cố định)";

            // 3. Tính tổng tiền hiển thị lên Label
            long tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("TongTienPhat") && row["TongTienPhat"] != DBNull.Value)
                    tongTien += Convert.ToInt64(row["TongTienPhat"]);
                else if (row.Table.Columns.Contains("TienPhat") && row["TienPhat"] != DBNull.Value)
                    tongTien += Convert.ToInt64(row["TienPhat"]);
            }
            if (lblTongTien != null) lblTongTien.Text = $"Tổng cộng: {tongTien:N0} VNĐ";

            // Visual tweaks
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
        }
    }
}