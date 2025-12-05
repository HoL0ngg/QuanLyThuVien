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
            string username = textBox1.Text;
            string password = textBox2.Text;

            TaiKhoanDTO tk = tkBUS.DangNhap(username, password);
            Console.WriteLine(tk);

            if (tk != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainForm = new MainForm(tk);
                this.Hide();
                DialogResult result = mainForm.ShowDialog();
                
                // Khi MainForm đóng, hiện lại LoginForm
                this.Show();
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
