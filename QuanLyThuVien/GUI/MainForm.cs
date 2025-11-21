using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        
        // Màu sắc hiện đại và bắt mắt hơn
        private Color defaultColor = Color.FromArgb(52, 73, 94);        // Xám xanh đậm
        private Color activeColor = Color.FromArgb(41, 128, 185);       // Xanh dương sáng
        private Color hoverColor = Color.FromArgb(52, 152, 219);         // Xanh dương hover
        private Color menuBgColor = Color.FromArgb(44, 62, 80);         // Nền menu tối
        private Color topBarColor = Color.FromArgb(41, 128, 185);       // Thanh trên xanh
        
        public MainForm(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            this.currentUser = taiKhoan;
            this.DoubleBuffered = true;
            ApplyModernStyling();
        }

        private void ApplyModernStyling()
        {
            // Cải thiện panel top (header)
            panel1.BackColor = topBarColor;
            panel1.Paint += Panel1_Paint;
            
            // Cải thiện flowLayoutPanel2 (menu)
            flowLayoutPanel2.BackColor = menuBgColor;
            
            // Styling cho tất cả menu panels
            foreach (Control ctrl in flowLayoutPanel2.Controls)
            {
                if (ctrl is Panel panel)
                {
                    panel.BackColor = defaultColor;
                    panel.Paint += MenuPanel_Paint;
                    panel.MouseEnter += MenuPanel_MouseEnter;
                    panel.MouseLeave += MenuPanel_MouseLeave;
                    
                    // Styling cho labels trong menu
                    foreach (Control labelCtrl in panel.Controls)
                    {
                        if (labelCtrl is Label lbl)
                        {
                            lbl.ForeColor = Color.White;
                            lbl.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                        }
                    }
                }
            }
            
            // Styling cho action buttons
            panel9.BackColor = Color.FromArgb(46, 204, 113);  // Thêm - Xanh lá
            panel10.BackColor = Color.FromArgb(52, 152, 219); // Sửa - Xanh dương
            panel12.BackColor = Color.FromArgb(231, 76, 60);  // Xóa - Đỏ
            panel11.BackColor = Color.FromArgb(155, 89, 182); // Chi tiết - Tím
            
            foreach (Panel actionPanel in new[] { panel9, panel10, panel11, panel12 })
            {
                actionPanel.Paint += ActionPanel_Paint;
                actionPanel.MouseEnter += ActionPanel_MouseEnter;
                actionPanel.MouseLeave += ActionPanel_MouseLeave;
                
                foreach (Control labelCtrl in actionPanel.Controls)
                {
                    if (labelCtrl is Label lbl)
                    {
                        lbl.ForeColor = Color.White;
                        lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    }
                }
            }
            
            // Styling cho labels trong panel1
            label1.ForeColor = Color.White;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(236, 240, 241);
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        }
        
        // Vẽ bo góc và đổ bóng cho panel header
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
            
            using (GraphicsPath path = GetRoundedRectanglePath(rect, 20))
            {
                // Gradient background
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(52, 152, 219),
                    Color.FromArgb(41, 128, 185),
                    LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillPath(brush, path);
                }
                
                // Border sáng
                using (Pen pen = new Pen(Color.FromArgb(100, 255, 255, 255), 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
        
        // Vẽ bo góc cho menu panels
        private void MenuPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            
            using (GraphicsPath path = GetRoundedRectanglePath(rect, 15))
            {
                // Fill với màu hiện tại
                using (SolidBrush brush = new SolidBrush(panel.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
                
                // Border nhẹ
                Color borderColor = panel == activeMenuPanel 
                    ? Color.FromArgb(150, 255, 255, 255) 
                    : Color.FromArgb(80, 255, 255, 255);
                    
                using (Pen pen = new Pen(borderColor, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
                
                // Hiệu ứng sáng bên trái khi active
                if (panel == activeMenuPanel)
                {
                    using (Pen highlightPen = new Pen(Color.FromArgb(52, 152, 219), 4))
                    {
                        e.Graphics.DrawLine(highlightPen, 0, 5, 0, panel.Height - 5);
                    }
                }
            }
        }
        
        // Vẽ bo góc và gradient cho action panels
        private void ActionPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            
            using (GraphicsPath path = GetRoundedRectanglePath(rect, 15))
            {
                // Gradient background
                Color color1 = panel.BackColor;
                Color color2 = ControlPaint.Dark(panel.BackColor, 0.15f);
                
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect, color1, color2, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillPath(brush, path);
                }
                
                // Border sáng
                using (Pen pen = new Pen(Color.FromArgb(150, 255, 255, 255), 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
                
                // Hiệu ứng sáng phía trên
                Rectangle glowRect = new Rectangle(rect.X + 5, rect.Y + 2, rect.Width - 10, rect.Height / 3);
                using (LinearGradientBrush glowBrush = new LinearGradientBrush(
                    glowRect,
                    Color.FromArgb(60, 255, 255, 255),
                    Color.FromArgb(0, 255, 255, 255),
                    LinearGradientMode.Vertical))
                {
                    using (GraphicsPath glowPath = GetRoundedRectanglePath(glowRect, 10))
                    {
                        e.Graphics.FillPath(glowBrush, glowPath);
                    }
                }
            }
        }
        
        // Hiệu ứng hover cho menu panel
        private void MenuPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != activeMenuPanel)
            {
                panel.BackColor = hoverColor;
                panel.Cursor = Cursors.Hand;
            }
        }
        
        private void MenuPanel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != activeMenuPanel)
            {
                panel.BackColor = defaultColor;
            }
        }
        
        // Hiệu ứng hover cho action panel
        private void ActionPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Cursor = Cursors.Hand;
            // Làm sáng lên một chút
            Color brightColor = ControlPaint.Light(panel.BackColor, 0.1f);
            panel.BackColor = brightColor;
        }
        
        private void ActionPanel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            // Trả về màu gốc
            if (panel == panel9)
                panel.BackColor = Color.FromArgb(46, 204, 113);
            else if (panel == panel10)
                panel.BackColor = Color.FromArgb(52, 152, 219);
            else if (panel == panel12)
                panel.BackColor = Color.FromArgb(231, 76, 60);
            else if (panel == panel11)
                panel.BackColor = Color.FromArgb(155, 89, 182);
        }
        
        // Hàm tạo path bo góc
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            
            // Đảm bảo radius không quá lớn
            if (diameter > rect.Height)
                diameter = rect.Height;
            if (diameter > rect.Width)
                diameter = rect.Width;
            
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));
            
            // Top left
            path.AddArc(arc, 180, 90);
            
            // Top right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            
            // Bottom right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            
            // Bottom left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            
            path.CloseFigure();
            return path;
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
                hoveredPanel.Cursor = Cursors.Hand;
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
                LoadModule(new PhieuMuon());
            }
            else if (clickedPanel.Name == "panelPhieuTra")
            {
                 LoadModule(new PhieuTraGUI());
            }
            // else if (clickedPanel.Name == "panelPhieuPhat")
            // {
            //     // LoadModule(new PhieuPhat());
            // }
            else if (clickedPanel.Name == "panelDauSach")
            {
                LoadModule(new DauSach());
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
