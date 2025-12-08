using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormNhanVien : Form
    {
        private NhanVienDTO nhanVien;
        private bool isViewOnly;
        private List<NhomQuyenDTO> danhSachNhomQuyen;

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
            // Thiết lập combobox giới tính
            cboGioiTinh.Items.AddRange(new[] { "Nam", "Nữ" });

            // Load danh sách nhóm quyền (loại bỏ Admin)
            LoadNhomQuyen();

            if (nhanVien.MaNV == 0)
            {
                // THÊM MỚI
                cboGioiTinh.SelectedIndex = 0;
                dtpNgaySinh.Value = new DateTime(1990, 1, 1);
                
                // Mặc định chọn nhóm quyền đầu tiên (thường là Thủ thư)
                if (cboNhomQuyen.Items.Count > 0)
                    cboNhomQuyen.SelectedIndex = 0;
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

        /// <summary>
        /// Load danh sách nhóm quyền vào ComboBox (loại bỏ Admin)
        /// </summary>
        private void LoadNhomQuyen()
        {
            try
            {
                var allNhomQuyen = NhomQuyenBUS.Instance.GetAllNhomQuyen();
                
                // LINQ: Lọc bỏ nhóm Admin (MaNhomQuyen <= 1)
                danhSachNhomQuyen = allNhomQuyen
                    .Where(nq => nq.MaNhomQuyen > 1)
                    .ToList();

                cboNhomQuyen.DataSource = null;
                cboNhomQuyen.DataSource = danhSachNhomQuyen;
                cboNhomQuyen.DisplayMember = "TenNhomQuyen";
                cboNhomQuyen.ValueMember = "MaNhomQuyen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhóm quyền: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Chọn nhóm quyền theo MaNhomQuyen của nhân viên
            if (nhanVien.MaNhomQuyen > 0)
            {
                cboNhomQuyen.SelectedValue = nhanVien.MaNhomQuyen;
            }
        }

        private void SetReadOnly()
        {
            txtTenNV.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtSDT.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cboNhomQuyen.Enabled = false;

            btnLuu.Visible = false;
            btnHuy.Text = "Đóng";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtTenNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNV.Focus();
                    return;
                }

                if (cboNhomQuyen.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhóm quyền!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNhomQuyen.Focus();
                    return;
                }

                // Gán dữ liệu
                nhanVien.TenNV = txtTenNV.Text.Trim();
                nhanVien.NgaySinh = dtpNgaySinh.Value;
                nhanVien.GioiTinh = cboGioiTinh.Text;
                nhanVien.SDT = txtSDT.Text.Trim();
                nhanVien.Email = txtEmail.Text.Trim();
                nhanVien.MaNhomQuyen = Convert.ToInt32(cboNhomQuyen.SelectedValue);
                nhanVien.TrangThai = 1; // Mặc định: Đang làm việc

                // Nếu thêm mới
                if (nhanVien.MaNV == 0)
                {
                    nhanVien.TenDangNhap = ConvertToUsername(nhanVien.TenNV);
                    nhanVien.MatKhau = "123456"; // Mật khẩu mặc định
                }

                // Lưu
                bool result = nhanVien.MaNV == 0
                    ? NhanVienBUS.Instance.ThemNhanVien(nhanVien)
                    : NhanVienBUS.Instance.SuaNhanVien(nhanVien);

                if (result)
                {
                    string msg = nhanVien.MaNV == 0 
                        ? $"Thêm nhân viên thành công!\n\nTên đăng nhập: {nhanVien.TenDangNhap}\nMật khẩu mặc định: 123456"
                        : "Cập nhật nhân viên thành công!";
                    MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲỆ",
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
