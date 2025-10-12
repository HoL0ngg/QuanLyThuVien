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
    public partial class MainForm : Form
    {
        private TaiKhoanDTO currentUser;
        public MainForm(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            this.currentUser = taiKhoan;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Text = currentUser.TenDangNhap;
            label2.Text = currentUser.ChucVu;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
