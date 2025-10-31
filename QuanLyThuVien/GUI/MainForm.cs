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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPhieuMuon_Click(Object sender, EventArgs e)
        {
            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.Dock = DockStyle.Fill;
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(phieuMuon);
        }

        private void panelDauSach_Click(Object sender, EventArgs e)
        {
            DauSach dauSach = new DauSach();
            dauSach.Dock = DockStyle.Fill;
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(dauSach);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelPhieuPhat_Click(object sender, EventArgs e)
        {
           
            var uc = new PhieuPhat();
            uc.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(uc);
            uc.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPhieuPhat_DoubleClick(object sender, EventArgs e)
        {
            PhieuPhat phieuphat = new PhieuPhat();
            phieuphat.Dock = DockStyle.Fill;
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(phieuphat);
        }

        private void panelPhieuPhat_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
