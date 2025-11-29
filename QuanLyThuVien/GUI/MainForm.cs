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
        private BaseModuleUC currentModule;

        private Panel activeMenuPanel = null;
        private Color defaultColor = System.Drawing.Color.LightSteelBlue; // Màu gốc
        private Color activeColor = System.Drawing.Color.DodgerBlue;      // Màu khi click
        private Color hoverColor = System.Drawing.Color.LightSkyBlue;     // Màu khi hover
        public MainForm(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            this.currentUser = taiKhoan;
        }

        private void LoadModule(BaseModuleUC module)
        {
            // Nếu có module cũ thì xóa đi
            if (this.currentModule != null)
            {
                this.panel3.Controls.Remove(this.currentModule);
                this.currentModule.Dispose();
            }

            // Gán module mới
            this.currentModule = module;
            this.currentModule.Dock = DockStyle.Fill;

            // Thêm vào panel
            this.panel3.Controls.Add(this.currentModule);
            this.currentModule.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return; // Nếu đang ở chế độ Design, không làm gì cả
            }
            //label1.Text = currentUser.TenDangNhap;
            //label2.Text = currentUser.ChucVu;
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
        private void panelMenu_MouseEnter(object sender, EventArgs e)
        {
            Panel hoveredPanel = sender as Panel;

            // Chỉ đổi màu hover nếu nó KHÔNG PHẢI là panel đang active
            if (hoveredPanel != activeMenuPanel)
            {
                hoveredPanel.BackColor = hoverColor;
            }
        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            Panel hoveredPanel = sender as Panel;

            // Chỉ trả lại màu cũ nếu nó KHÔNG PHẢI là panel đang active
            if (hoveredPanel != activeMenuPanel)
            {
                hoveredPanel.BackColor = defaultColor;
            }
        }

        private void panelMenu_Click(object sender, EventArgs e)
        {
            // Lấy panel vừa được click
            Panel clickedPanel = sender as Panel;

            // Nếu click vào panel đang active rồi thì không làm gì cả
            if (clickedPanel == activeMenuPanel)
            {
                return;
            }

            // 1. Tắt sáng panel CŨ (nếu có)
            if (activeMenuPanel != null)
            {
                activeMenuPanel.BackColor = defaultColor;
            }

            // 2. Làm sáng panel MỚI
            clickedPanel.BackColor = activeColor;
            activeMenuPanel = clickedPanel; // "Nhớ" panel mới này

            // 3. Tải User Control tương ứng (Quan trọng!)
            // (Hãy đảm bảo tên panel của bạn khớp, ví dụ: panelDauSach, panelPhieuMuon)
            if (clickedPanel.Name == "panelPhieuNhap")
            {
                 LoadModule(new PhieuNhapGUI());
            }
            else if (clickedPanel.Name == "panelPhieuMuon")
            {
                LoadModule(new PhieuMuon(currentUser));
            }
            // else if (clickedPanel.Name == "panelPhieuTra")
            // {
            //     // LoadModule(new PhieuTra());
            // }
            // else if (clickedPanel.Name == "panelPhieuPhat")
            // {
            //     // LoadModule(new PhieuPhat());
            // }
            else if (clickedPanel.Name == "panelDauSach")
            {
                LoadModule(new DauSach());
            }
            else if (clickedPanel.Name == "panelDocGia")
            {
                LoadModule(new DocGia());
            }
            // ... Thêm các else if cho các nút khác ...
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có module nào đang chạy không
            if (currentModule != null)
            {
                // 2. Ra lệnh cho module đó thực hiện hành vi "OnAdd"
                currentModule.OnAdd();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentModule != null)
            {
                currentModule.OnEdit();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentModule != null)
            {
                currentModule.OnDelete();
            }
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (currentModule != null)
            {
                currentModule.OnDetails();
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
