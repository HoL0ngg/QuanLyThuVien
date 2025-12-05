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
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Thiết lập combobox
            cboGioiTinh.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
            cboTrangThai.Items.AddRange(new[] { "Đang làm việc", "Nghỉ việc" });

            if (nhanVien.MaNV == 0)
            {
                // THÊM MỚI
                cboGioiTinh.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;
                dtpNgaySinh.Value = new DateTime(1990, 1, 1);
            }
            else
            {
                LoadData();
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

            // Giới tính an toàn
            int gioiTinhIndex = cboGioiTinh.Items.IndexOf(nhanVien.GioiTinh);
            cboGioiTinh.SelectedIndex = gioiTinhIndex >= 0 ? gioiTinhIndex : 0;

            txtSDT.Text = nhanVien.SDT;
            txtEmail.Text = nhanVien.Email;

            // Trạng thái an toàn
            cboTrangThai.SelectedIndex =
                nhanVien.TrangThai >= 0 && nhanVien.TrangThai <= 1
                ? nhanVien.TrangThai
                : 0;
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
                // Gán dữ liệu
                nhanVien.TenNV = txtTenNV.Text.Trim();
                nhanVien.NgaySinh = dtpNgaySinh.Value;
                nhanVien.GioiTinh = cboGioiTinh.Text;
                nhanVien.SDT = txtSDT.Text.Trim();
                nhanVien.Email = txtEmail.Text.Trim();
                nhanVien.TrangThai = cboTrangThai.SelectedIndex;   // <-- FIX

                // Nếu thêm mới
                if (nhanVien.MaNV == 0)
                {
                    nhanVien.TenDangNhap = ConvertToUsername(nhanVien.TenNV);
                    nhanVien.MatKhau = "123456";        // mặc định
                    nhanVien.MaNhomQuyen = 2;           // mặc định: Thủ thư
                }

                // Lưu
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

            string result = RemoveVietnameseTone(tenNV);
            result = result.ToLower().Replace(" ", "");
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
                "úùụủũưứừựửữ",
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
