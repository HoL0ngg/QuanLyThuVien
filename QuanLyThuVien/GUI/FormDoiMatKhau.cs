using QuanLyThuVien.BUS;
using System;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormDoiMatKhau : Form
    {
        private int maNV;
        private bool isFirstLogin;

        public FormDoiMatKhau(int maNhanVien, bool firstLogin = false)
        {
            InitializeComponent();
            this.maNV = maNhanVien;
            this.isFirstLogin = firstLogin;
            
            if (firstLogin)
            {
                this.Text = "Đổi mật khẩu lần đầu";
                lblThongBao.Text = "Bạn đang sử dụng mật khẩu mặc định.\nVui lòng đổi mật khẩu mới!";
                lblThongBao.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauCu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauMoi.Focus();
                    return;
                }

                if (txtMatKhauMoi.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauMoi.Focus();
                    return;
                }

                if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtXacNhanMatKhau.Focus();
                    return;
                }

                if (txtMatKhauCu.Text == txtMatKhauMoi.Text)
                {
                    MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauMoi.Focus();
                    return;
                }

                // ??i m?t kh?u
                if (NhanVienBUS.Instance.DoiMatKhau(maNV, txtMatKhauCu.Text, txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhauCu.Focus();
                    txtMatKhauCu.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (isFirstLogin)
            {
                var result = MessageBox.Show(
                    "Bạn chưa đổi mật khẩu mặc định!\nBạn có chắc muốn đăng xuất?",
                    "Cảnh báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtMatKhauMoi.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtXacNhanMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
    }
}
