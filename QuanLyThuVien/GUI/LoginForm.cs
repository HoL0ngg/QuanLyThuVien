using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class LoginForm : Form
    {
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            // Validate
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            TaiKhoanDTO tk = tkBUS.DangNhap(username, password);

            if (tk != null)
            {
                // Kiểm tra nhân viên đã nghỉ việc chưa
                if (!tk.DangLamViec)
                {
                    MessageBox.Show(
                        "Tài khoản này đã bị vô hiệu hóa do nhân viên đã nghỉ việc!\nVui lòng liên hệ quản trị viên.",
                        "Không thể đăng nhập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                    return;
                }

                // Kiểm tra mật khẩu mặc định
                if (tk.MatKhau == "123456")
                {
                    MessageBox.Show(
                        "Bạn đang sử dụng mật khẩu mặc định!\nVui lòng đổi mật khẩu để tiếp tục.",
                        "Yêu cầu đổi mật khẩu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // Hiện form đổi mật khẩu
                    FormDoiMatKhau formDoiMK = new FormDoiMatKhau(tk.MaNV, true);
                    DialogResult result = formDoiMK.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show(
                            "Đổi mật khẩu thành công!\nVui lòng đăng nhập lại với mật khẩu mới.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        // Người dùng hủy đổi mật khẩu -> không cho đăng nhập
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                    return;
                }

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                MainForm mainForm = new MainForm(tk);
                this.Hide();
                DialogResult mainResult = mainForm.ShowDialog();
                
                // Khi MainForm đóng, hiện lại LoginForm
                this.Show();
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}
