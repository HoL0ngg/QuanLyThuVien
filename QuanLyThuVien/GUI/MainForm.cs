using QuanLyThuVien.DTO;
using QuanLyThuVien.BUS;
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
using QuanLyThuVien.GUI.ThongKeGUI;

namespace QuanLyThuVien.GUI
{
    public partial class MainForm : Form
    {
        private TaiKhoanDTO currentUser;
        private BaseModuleUC currentModule;

        private Panel activeMenuPanel = null;
        
        // Lưu vị trí gốc của panel3
        private Point panel3OriginalLocation;
        private Size panel3OriginalSize;
        
        // Material Design Color Palette
        private Color primaryColor = Color.FromArgb(33, 150, 243);      // Blue 500
        private Color primaryDark = Color.FromArgb(25, 118, 210);       // Blue 700
        private Color primaryLight = Color.FromArgb(100, 181, 246);     // Blue 300
        private Color accentColor = Color.FromArgb(255, 64, 129);       // Pink A200
        
        private Color defaultColor = Color.FromArgb(66, 66, 66);        // Dark Grey
        private Color activeColor = Color.FromArgb(33, 150, 243);       // Blue 500
        private Color hoverColor = Color.FromArgb(97, 97, 97);          // Medium Grey
        private Color menuBgColor = Color.FromArgb(250, 250, 250);      // Light Grey
        private Color cardBgColor = Color.White;                        // White
        
        // Action button colors
        private Color successColor = Color.FromArgb(76, 175, 80);       // Green 500
        private Color infoColor = Color.FromArgb(33, 150, 243);         // Blue 500
        private Color dangerColor = Color.FromArgb(244, 67, 54);        // Red 500
        private Color warningColor = Color.FromArgb(156, 39, 176);      // Purple 500
        
        public MainForm(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            this.currentUser = taiKhoan;
            if (this.currentUser != null)
            {
                string tenHienThi = $"{this.currentUser.TenNhanVien.Trim()} - {this.currentUser.ChucVu.Trim()}";
                label1.Text = tenHienThi;
                label2.Text = "Đăng xuất";

                ApplyRolePermission();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng. Ứng dụng sẽ đóng.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();
                return;
            }
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                         ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint, true);
            
            // Lưu vị trí gốc
            panel3OriginalLocation = panel3.Location;
            panel3OriginalSize = panel3.Size;
			
			
            // Đóng form khi đóng
            this.FormClosing += MainForm_FormClosing;
            
            ApplyMaterialDesign();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            if (currentModule != null)
            {
                currentModule.Dispose();
            }
        }

        // Phương thức đăng xuất
        public void DangXuat()
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        
        private void ApplyMaterialDesign()
        {
            // Form background
            this.BackColor = Color.FromArgb(250, 250, 250);
            
            // Header panel với Material Design
            panel1.BackColor = primaryColor;
            panel1.Paint += Panel1_Paint;
            
            // Menu background
            flowLayoutPanel2.BackColor = menuBgColor;
            
            // Styling cho menu panels
            foreach (Control ctrl in flowLayoutPanel2.Controls)
            {
                if (ctrl is Panel panel)
                {
                    panel.BackColor = cardBgColor;
                    panel.Paint += MenuPanel_Paint;
                    panel.MouseEnter += MenuPanel_MouseEnter;
                    panel.MouseLeave += MenuPanel_MouseLeave;
                    panel.MouseDown += MenuPanel_MouseDown;
                    panel.MouseUp += MenuPanel_MouseUp;
                    
                    foreach (Control labelCtrl in panel.Controls)
                    {
                        if (labelCtrl is Label lbl)
                        {
                            lbl.ForeColor = Color.FromArgb(66, 66, 66);
                            lbl.Font = GetSafeFont("Segoe UI", 13F, FontStyle.Regular);
                        }
                    }
                }
            }
            
            // Action buttons với Material Design
            SetupActionButton(panel9, successColor, "Segoe UI", 11F);
            SetupActionButton(panel10, infoColor, "Segoe UI", 11F);
            SetupActionButton(panel12, dangerColor, "Segoe UI", 11F);
            SetupActionButton(panel11, warningColor, "Segoe UI", 11F);
            
            // Header labels
            label1.ForeColor = Color.White;
            label1.Font = GetSafeFont("Segoe UI", 18F, FontStyle.Bold);
            
            // Label2 làm nút đăng xuất
            label2.ForeColor = Color.FromArgb(230, 230, 230);
            label2.Font = GetSafeFont("Segoe UI", 11F, FontStyle.Bold);
            label2.Text = "Đăng xuất";
            label2.Cursor = Cursors.Hand;
            label2.Click -= label2_Click; // Xóa event cũ nếu có
            label2.Click += Label2_DangXuat_Click; // Thêm event mới
            
            // Thêm hover effect cho label2
            label2.MouseEnter += (s, e) => {
                label2.ForeColor = Color.White;
                label2.Font = GetSafeFont("Segoe UI", 11F, FontStyle.Bold | FontStyle.Underline);
            };
            label2.MouseLeave += (s, e) => {
                label2.ForeColor = Color.FromArgb(230, 230, 230);
                label2.Font = GetSafeFont("Segoe UI", 11F, FontStyle.Bold);
            };
        }
        
        private void Label2_DangXuat_Click(object sender, EventArgs e)
        {
            DangXuat();
        }
        
        private Font GetSafeFont(string fontName, float size, FontStyle style)
        {
            return Helpers.FontManager.GetSafeFont(fontName, size, style);
        }
        
        private void SetupActionButton(Panel panel, Color baseColor, string fontName, float fontSize)
        {
            panel.BackColor = baseColor;
            panel.Paint += ActionButton_Paint;
            panel.MouseEnter += ActionButton_MouseEnter;
            panel.MouseLeave += ActionButton_MouseLeave;
            panel.MouseDown += ActionButton_MouseDown;
            panel.MouseUp += ActionButton_MouseUp;
            panel.Tag = baseColor; // Store original color
            
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.White;
                    lbl.Font = GetSafeFont(fontName, fontSize, FontStyle.Bold);
                }
            }
        }
        
        // Vẽ Material shadow cho header
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = panel.ClientRectangle;
            
            // Draw shadow
            DrawShadow(e.Graphics, rect, 8);
            
            // Draw gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, primaryColor, primaryDark, LinearGradientMode.Horizontal))
            {
                using (GraphicsPath path = GetRoundedRectPath(rect, 0))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }
        
        // Vẽ Material card cho menu
        private void MenuPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            
            // Draw shadow
            DrawShadow(e.Graphics, rect, panel == activeMenuPanel ? 6 : 2);
            
            // Draw card
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                using (GraphicsPath path = GetRoundedRectPath(rect, 8))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
            
            // Draw active indicator
            if (panel == activeMenuPanel)
            {
                using (SolidBrush indicatorBrush = new SolidBrush(primaryColor))
                {
                    Rectangle indicator = new Rectangle(0, rect.Height / 2 - 20, 4, 40);
                    e.Graphics.FillRectangle(indicatorBrush, indicator);
                }
            }
        }
        
        // Vẽ Material button
        private void ActionButton_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            
            // Draw shadow
            DrawShadow(e.Graphics, rect, 4);
            
            // Draw button
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                using (GraphicsPath path = GetRoundedRectPath(rect, 8))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
            
            // Draw highlight
            Rectangle highlightRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height / 2);
            using (LinearGradientBrush highlightBrush = new LinearGradientBrush(
                highlightRect,
                Color.FromArgb(40, 255, 255, 255),
                Color.FromArgb(0, 255, 255, 255),
                LinearGradientMode.Vertical))
            {
                using (GraphicsPath highlightPath = GetRoundedRectPath(highlightRect, 6))
                {
                    e.Graphics.FillPath(highlightBrush, highlightPath);
                }
            }
        }
        
        // Material shadow drawing
        private void DrawShadow(Graphics g, Rectangle rect, int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                int alpha = 20 - (i * 2);
                if (alpha < 0) alpha = 0;
                
                Rectangle shadowRect = new Rectangle(
                    rect.X + i, 
                    rect.Y + i, 
                    rect.Width - (i * 2), 
                    rect.Height - (i * 2)
                );
                
                using (Pen shadowPen = new Pen(Color.FromArgb(alpha, 0, 0, 0)))
                {
                    using (GraphicsPath shadowPath = GetRoundedRectPath(shadowRect, 8))
                    {
                        g.DrawPath(shadowPen, shadowPath);
                    }
                }
            }
        }
        
        // Rounded rectangle path
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }
            
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));
            
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            
            return path;
        }
        
        // Menu panel hover effects
        private void MenuPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != activeMenuPanel)
            {
                panel.BackColor = Color.FromArgb(245, 245, 245);
                panel.Cursor = Cursors.Hand;
            }
        }
        
        private void MenuPanel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != activeMenuPanel)
            {
                panel.BackColor = cardBgColor;
            }
        }
        
        private void MenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.FromArgb(238, 238, 238);
        }
        
        private void MenuPanel_MouseUp(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == activeMenuPanel)
            {
                panel.BackColor = Color.FromArgb(227, 242, 253);
            }
            else
            {
                panel.BackColor = Color.FromArgb(245, 245, 245);
            }
        }
        
        // Action button hover effects
        private void ActionButton_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Cursor = Cursors.Hand;
            Color baseColor = (Color)panel.Tag;
            panel.BackColor = LightenColor(baseColor, 20);
        }
        
        private void ActionButton_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = (Color)panel.Tag;
        }
        
        private void ActionButton_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            Color baseColor = (Color)panel.Tag;
            panel.BackColor = DarkenColor(baseColor, 20);
        }
        
        private void ActionButton_MouseUp(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            Color baseColor = (Color)panel.Tag;
            panel.BackColor = LightenColor(baseColor, 20);
        }
        
        // Color helpers
        private Color LightenColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Min(color.R + amount, 255),
                Math.Min(color.G + amount, 255),
                Math.Min(color.B + amount, 255)
            );
        }
        
        private Color DarkenColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Max(color.R - amount, 0),
                Math.Max(color.G - amount, 0),
                Math.Max(color.B - amount, 0)
            );
        }

        private void LoadModule(BaseModuleUC module, string tenChucNang)
        {
            if (this.currentModule != null)
            {
                this.panel3.Controls.Remove(this.currentModule);
                this.currentModule.Dispose();
            }

            this.currentModule = module;
            
            // Thiết lập quyền cho module
            this.currentModule.SetupPermission(currentUser, tenChucNang);
            
            this.currentModule.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(this.currentModule);
            this.currentModule.BringToFront();
        }

        // Overload cho WelcomeScreen (không cần quyền)
        private void LoadModule(BaseModuleUC module)
        {
            if (this.currentModule != null)
            {
                this.panel3.Controls.Remove(this.currentModule);
                this.currentModule.Dispose();
            }

            this.currentModule = module;
            this.currentModule.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(this.currentModule);
            this.currentModule.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return; // Nếu đang ở chế độ Design, không làm gì cả
            }
            
            // Hiển thị màn hình chào mừng khi mới mở app
            LoadModule(new WelcomeScreen());
        }

        private void ApplyRolePermission()
        {
            if (currentUser == null)
            {
                MessageBox.Show("Không thể xác định vai trò người dùng.", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNhomQuyen = currentUser.MaNhomQuyen;

            // Admin (MaNhomQuyen = 0 hoặc 1) có tất cả quyền
            if (maNhomQuyen <= 1)
                return;

            // Kiểm tra quyền từng chức năng và ẩn/hiện menu tương ứng
            // Tên chức năng phải khớp với TENCN trong bảng chuc_nang
            
            // Phiếu Nhập
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Phiếu Nhập"))
                panelPhieuNhap.Visible = false;

            // Phiếu Mượn
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Phiếu Mượn"))
                panelPhieuMuon.Visible = false;

            // Phiếu Trả
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Phiếu Trả"))
                panelPhieuTra.Visible = false;

            // Phiếu Phạt
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Phiếu Phạt"))
                panelPhieuPhat.Visible = false;

            // Đầu Sách
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Đầu Sách"))
                panelDauSach.Visible = false;

            // Độc Giả
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Độc Giả"))
                panelDocGia.Visible = false;

            // Nhân Viên
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Nhân Viên"))
                panelNhanVien.Visible = false;

            // Thống Kê
            if (!NhomQuyenBUS.Instance.CoItNhatMotQuyen(maNhomQuyen, "Thống Kê"))
                panelThongKe.Visible = false;
        }

        private void DisablePanel(Panel p)
        {
            p.Enabled = false;
            foreach (Control ctrl in p.Controls)
                ctrl.Enabled = false;
        }

        private void EnablePanel(Panel p)
        {
            p.Enabled = true;
            foreach (Control ctrl in p.Controls)
                ctrl.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        
        private void panelMenu_MouseEnter(object sender, EventArgs e)
        {
            Panel hoveredPanel = sender as Panel;
            if (hoveredPanel != activeMenuPanel)
            {
                hoveredPanel.BackColor = Color.FromArgb(245, 245, 245);
                hoveredPanel.Cursor = Cursors.Hand;
            }
        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            Panel hoveredPanel = sender as Panel;
            if (hoveredPanel != activeMenuPanel)
            {
                hoveredPanel.BackColor = cardBgColor;
            }
        }

        private void panelMenu_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == activeMenuPanel) return;
            if (!clickedPanel.Enabled) return;

            if (activeMenuPanel != null)
            {
                activeMenuPanel.BackColor = cardBgColor;
                foreach (Control ctrl in activeMenuPanel.Controls)
                {
                    if (ctrl is Label lbl)
                        lbl.ForeColor = Color.FromArgb(66, 66, 66);
                }
            }

            clickedPanel.BackColor = Color.FromArgb(227, 242, 253);
            activeMenuPanel = clickedPanel;
            foreach (Control ctrl in clickedPanel.Controls)
            {
                if (ctrl is Label lbl)
                    lbl.ForeColor = primaryColor;
            }

            // Load module với thông tin quyền - truyền currentUser vào constructor
            if (clickedPanel.Name == "panelPhieuNhap")
            {
                var module = new PhieuNhapGUI(currentUser);
                LoadModule(module, "Phieu Nhap");
            }
            else if (clickedPanel.Name == "panelPhieuMuon")
            {
                var module = new PhieuMuon(currentUser);
                LoadModule(module, "Phieu Muon");
            }
            else if (clickedPanel.Name == "panelPhieuTra")
            {
                var module = new PhieuTraGUI(currentUser);
                LoadModule(module, "Phieu Tra");
            }
            else if (clickedPanel.Name == "panelDauSach")
            {
                var module = new DauSach(currentUser);
                LoadModule(module, "Dau Sach");
            }
            else if (clickedPanel.Name == "panelNhanVien")
            {
                var module = new NhanVienGUI(currentUser);
                LoadModule(module, "Nhan Vien");
            }
            else if (clickedPanel.Name == "panelDocGia")
            {
                var module = new DocGia(currentUser);
                LoadModule(module, "Doc Gia");
            }
            else if (clickedPanel.Name == "panelDangXuat")
                DangXuat();
            else if (clickedPanel.Name == "panelPhieuPhat")
            {
                var module = new PhieuPhat(currentUser);
                LoadModule(module, "Phieu Phat");
            }
            else if (clickedPanel.Name == "panelThongKe")
            {
                var module = new UCMain(currentUser);
                LoadModule(module, "Thong Ke");
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void pictureBox5_Click(object sender, EventArgs e) { }
        private void panel6_Paint_1(object sender, PaintEventArgs e) { }

        private void panelPhieuPhat_Click(object sender, EventArgs e)
        {
            // Delegate to the shared menu click handler so Designer event hookups work.
            panelMenu_Click(panelPhieuPhat, EventArgs.Empty);
        }

        // Mở Thống kê khi click label/picture bên trong panel
        private void panelThongKe_Click(object sender, EventArgs e)
        {
            panelMenu_Click(panelThongKe, EventArgs.Empty);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panelThongKe_Click(sender, e);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            panelThongKe_Click(sender, e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void panelPhieuPhat_DoubleClick(object sender, EventArgs e)
        {
            PhieuPhat phieuphat = new PhieuPhat(currentUser);
            phieuphat.SetupPermission(currentUser, "Phieu Phat");
            phieuphat.Dock = DockStyle.Fill;
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(phieuphat);
        }

        private void panelPhieuPhat_MouseDown(object sender, MouseEventArgs e) { }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (currentModule != null)
                currentModule.OnAdd();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentModule != null)
                currentModule.OnEdit();
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentModule != null)
                currentModule.OnDelete();
        }
        
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (currentModule != null)
                currentModule.OnDetails();
        }

        private void panel11_Paint(object sender, PaintEventArgs e) { }
    }
}
