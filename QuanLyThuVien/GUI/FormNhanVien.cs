using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormNhanVien : Form
    {
        private NhanVienDTO nhanVien;
        private bool isViewOnly;

        public FormNhanVien()
        {
            InitializeComponent();
            this.nhanVien = new NhanVienDTO();
            this.isViewOnly = false;
            this.Text = "Thêm nhân viên mới";
        }

        public FormNhanVien(NhanVienDTO nv, bool viewOnly = false)
        {
            InitializeComponent();
            this.nhanVien = nv;
            this.isViewOnly = viewOnly;
            this.Text = viewOnly ? "Chi tiết nhân viên" : "Cập nhật nhân viên";
            LoadData();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Setup combobox
            cboGioiTinh.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
            cboTrangThai.Items.AddRange(new[] { "Đang làm việc", "Nghỉ việc" });

            if (nhanVien.MaNV == 0)
            {
                dtpNgaySinh.Value = new DateTime(1990, 1, 1);
                cboGioiTinh.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;
            }

            if (isViewOnly)
            {
                SetReadOnly();
            }
        }

        private void LoadData()
        {
            if (nhanVien == null) return;

            txtTenNV.Text = nhanVien.TenNV;
            dtpNgaySinh.Value = nhanVien.NgaySinh;
            cboGioiTinh.Text = nhanVien.GioiTinh;
            txtSDT.Text = nhanVien.SDT;
            txtEmail.Text = nhanVien.Email;
            cboTrangThai.SelectedIndex = nhanVien.TrangThai;
        }

        private void SetReadOnly()
        {
            txtTenNV.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtSDT.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cboTrangThai.Enabled = false;
            btnLuu.Visible = false;
            btnHuy.Text = "Đóng";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                nhanVien.TenNV = txtTenNV.Text.Trim();
                nhanVien.NgaySinh = dtpNgaySinh.Value;
                nhanVien.GioiTinh = cboGioiTinh.Text;
                nhanVien.SDT = txtSDT.Text.Trim();
                nhanVien.Email = txtEmail.Text.Trim();
                nhanVien.TrangThai = (cboTrangThai.SelectedIndex + 1) % 2;

                // Nếu là thêm mới, tạo TenDangNhap tự động từ tên
                if (nhanVien.MaNV == 0)
                {
                    // Tạo username từ tên: Nguyễn Văn A -> nguyenvana
                    string tenDangNhap = ConvertToUsername(nhanVien.TenNV);
                    nhanVien.TenDangNhap = tenDangNhap;
                    nhanVien.MatKhau = "123456"; // Mật khẩu mặc định
                    nhanVien.MaNhomQuyen = 2; // Nhóm quyền mặc định (Thủ thư)
                }

                bool result = nhanVien.MaNV == 0
                    ? NhanVienBUS.Instance.ThemNhanVien(nhanVien)
                    : NhanVienBUS.Instance.SuaNhanVien(nhanVien);

                if (result)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ConvertToUsername(string tenNV)
        {
            if (string.IsNullOrWhiteSpace(tenNV))
                return "";

            // Loại bỏ dấu tiếng Việt
            string result = RemoveVietnameseTone(tenNV);
            
            // Chuyển về chữ thường, loại bỏ khoảng trắng
            result = result.ToLower().Replace(" ", "");

            // Thêm ngày sinh để đảm bảo unique
            result += dtpNgaySinh.Value.ToString("ddMMyy");

            return result;
        }

        private string RemoveVietnameseTone(string text)
        {
            string[] vietnameseChars = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úù ụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < vietnameseChars.Length; i++)
            {
                for (int j = 0; j < vietnameseChars[i].Length; j++)
                {
                    text = text.Replace(vietnameseChars[i][j], vietnameseChars[0][i - 1]);
                }
            }

            return text;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}