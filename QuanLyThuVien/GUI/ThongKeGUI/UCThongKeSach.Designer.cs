namespace QuanLyThuVien.GUI.ThongKeGUI
{
    partial class UCThongKeSach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelKPI = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpi1 = new System.Windows.Forms.Panel();
            this.lblTongDauSach = new System.Windows.Forms.Label();
            this.lblKpi1Title = new System.Windows.Forms.Label();
            this.pnlKpi2 = new System.Windows.Forms.Panel();
            this.lblTongBanSach = new System.Windows.Forms.Label();
            this.lblKpi2Title = new System.Windows.Forms.Label();
            this.pnlKpi3 = new System.Windows.Forms.Panel();
            this.lblSachCoSan = new System.Windows.Forms.Label();
            this.lblKpi3Title = new System.Windows.Forms.Label();
            this.pnlKpi4 = new System.Windows.Forms.Panel();
            this.lblSachBaoTri = new System.Windows.Forms.Label();
            this.lblKpi4Title = new System.Windows.Forms.Label();
            this.panelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.panelTheLoai = new System.Windows.Forms.Panel();
            this.flpTheLoai = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTheLoaiTitle = new System.Windows.Forms.Label();
            this.panelNamXB = new System.Windows.Forms.Panel();
            this.flpNamXB = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNamXBTitle = new System.Windows.Forms.Label();
            this.panelTable = new System.Windows.Forms.Panel();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoBanHong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelKPI.SuspendLayout();
            this.pnlKpi1.SuspendLayout();
            this.pnlKpi2.SuspendLayout();
            this.pnlKpi3.SuspendLayout();
            this.pnlKpi4.SuspendLayout();
            this.panelCharts.SuspendLayout();
            this.panelTheLoai.SuspendLayout();
            this.panelNamXB.SuspendLayout();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelKPI
            // 
            this.panelKPI.ColumnCount = 4;
            this.panelKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelKPI.Controls.Add(this.pnlKpi1, 0, 0);
            this.panelKPI.Controls.Add(this.pnlKpi2, 1, 0);
            this.panelKPI.Controls.Add(this.pnlKpi3, 2, 0);
            this.panelKPI.Controls.Add(this.pnlKpi4, 3, 0);
            this.panelKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPI.Location = new System.Drawing.Point(10, 10);
            this.panelKPI.Name = "panelKPI";
            this.panelKPI.Padding = new System.Windows.Forms.Padding(5);
            this.panelKPI.RowCount = 1;
            this.panelKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelKPI.Size = new System.Drawing.Size(1798, 130);
            this.panelKPI.TabIndex = 3;
            // 
            // pnlKpi1
            // 
            this.pnlKpi1.BackColor = System.Drawing.Color.White;
            this.pnlKpi1.Controls.Add(this.lblTongDauSach);
            this.pnlKpi1.Controls.Add(this.lblKpi1Title);
            this.pnlKpi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi1.Location = new System.Drawing.Point(13, 13);
            this.pnlKpi1.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.Padding = new System.Windows.Forms.Padding(12);
            this.pnlKpi1.Size = new System.Drawing.Size(431, 104);
            this.pnlKpi1.TabIndex = 0;
            // 
            // lblTongDauSach
            // 
            this.lblTongDauSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongDauSach.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTongDauSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblTongDauSach.Location = new System.Drawing.Point(12, 37);
            this.lblTongDauSach.Name = "lblTongDauSach";
            this.lblTongDauSach.Size = new System.Drawing.Size(407, 55);
            this.lblTongDauSach.TabIndex = 0;
            this.lblTongDauSach.Text = "0";
            this.lblTongDauSach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpi1Title
            // 
            this.lblKpi1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi1Title.Location = new System.Drawing.Point(12, 12);
            this.lblKpi1Title.Name = "lblKpi1Title";
            this.lblKpi1Title.Size = new System.Drawing.Size(407, 25);
            this.lblKpi1Title.TabIndex = 1;
            this.lblKpi1Title.Text = "TỔNG ĐẦU SÁCH";
            // 
            // pnlKpi2
            // 
            this.pnlKpi2.BackColor = System.Drawing.Color.White;
            this.pnlKpi2.Controls.Add(this.lblTongBanSach);
            this.pnlKpi2.Controls.Add(this.lblKpi2Title);
            this.pnlKpi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi2.Location = new System.Drawing.Point(460, 13);
            this.pnlKpi2.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.Padding = new System.Windows.Forms.Padding(12);
            this.pnlKpi2.Size = new System.Drawing.Size(431, 104);
            this.pnlKpi2.TabIndex = 1;
            // 
            // lblTongBanSach
            // 
            this.lblTongBanSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongBanSach.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTongBanSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.lblTongBanSach.Location = new System.Drawing.Point(12, 37);
            this.lblTongBanSach.Name = "lblTongBanSach";
            this.lblTongBanSach.Size = new System.Drawing.Size(407, 55);
            this.lblTongBanSach.TabIndex = 0;
            this.lblTongBanSach.Text = "0";
            this.lblTongBanSach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpi2Title
            // 
            this.lblKpi2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi2Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi2Title.Location = new System.Drawing.Point(12, 12);
            this.lblKpi2Title.Name = "lblKpi2Title";
            this.lblKpi2Title.Size = new System.Drawing.Size(407, 25);
            this.lblKpi2Title.TabIndex = 1;
            this.lblKpi2Title.Text = "TỔNG SỐ BẢN";
            // 
            // pnlKpi3
            // 
            this.pnlKpi3.BackColor = System.Drawing.Color.White;
            this.pnlKpi3.Controls.Add(this.lblSachCoSan);
            this.pnlKpi3.Controls.Add(this.lblKpi3Title);
            this.pnlKpi3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi3.Location = new System.Drawing.Point(907, 13);
            this.pnlKpi3.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.Padding = new System.Windows.Forms.Padding(12);
            this.pnlKpi3.Size = new System.Drawing.Size(431, 104);
            this.pnlKpi3.TabIndex = 2;
            // 
            // lblSachCoSan
            // 
            this.lblSachCoSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSachCoSan.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSachCoSan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblSachCoSan.Location = new System.Drawing.Point(12, 37);
            this.lblSachCoSan.Name = "lblSachCoSan";
            this.lblSachCoSan.Size = new System.Drawing.Size(407, 55);
            this.lblSachCoSan.TabIndex = 0;
            this.lblSachCoSan.Text = "0";
            this.lblSachCoSan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpi3Title
            // 
            this.lblKpi3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi3Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi3Title.Location = new System.Drawing.Point(12, 12);
            this.lblKpi3Title.Name = "lblKpi3Title";
            this.lblKpi3Title.Size = new System.Drawing.Size(407, 25);
            this.lblKpi3Title.TabIndex = 1;
            this.lblKpi3Title.Text = "SÁCH CÓ SẴN";
            // 
            // pnlKpi4
            // 
            this.pnlKpi4.BackColor = System.Drawing.Color.White;
            this.pnlKpi4.Controls.Add(this.lblSachBaoTri);
            this.pnlKpi4.Controls.Add(this.lblKpi4Title);
            this.pnlKpi4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi4.Location = new System.Drawing.Point(1354, 13);
            this.pnlKpi4.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi4.Name = "pnlKpi4";
            this.pnlKpi4.Padding = new System.Windows.Forms.Padding(12);
            this.pnlKpi4.Size = new System.Drawing.Size(431, 104);
            this.pnlKpi4.TabIndex = 3;
            // 
            // lblSachBaoTri
            // 
            this.lblSachBaoTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSachBaoTri.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSachBaoTri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblSachBaoTri.Location = new System.Drawing.Point(12, 37);
            this.lblSachBaoTri.Name = "lblSachBaoTri";
            this.lblSachBaoTri.Size = new System.Drawing.Size(407, 55);
            this.lblSachBaoTri.TabIndex = 0;
            this.lblSachBaoTri.Text = "0";
            this.lblSachBaoTri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpi4Title
            // 
            this.lblKpi4Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi4Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi4Title.Location = new System.Drawing.Point(12, 12);
            this.lblKpi4Title.Name = "lblKpi4Title";
            this.lblKpi4Title.Size = new System.Drawing.Size(407, 25);
            this.lblKpi4Title.TabIndex = 1;
            this.lblKpi4Title.Text = "SÁCH MẤT/HỎNG";
            this.lblKpi4Title.Click += new System.EventHandler(this.lblKpi4Title_Click);
            // 
            // panelCharts
            // 
            this.panelCharts.ColumnCount = 2;
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCharts.Controls.Add(this.panelTheLoai, 0, 0);
            this.panelCharts.Controls.Add(this.panelNamXB, 1, 0);
            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCharts.Location = new System.Drawing.Point(10, 140);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Padding = new System.Windows.Forms.Padding(5);
            this.panelCharts.RowCount = 1;
            this.panelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelCharts.Size = new System.Drawing.Size(1798, 280);
            this.panelCharts.TabIndex = 2;
            // 
            // panelTheLoai
            // 
            this.panelTheLoai.BackColor = System.Drawing.Color.White;
            this.panelTheLoai.Controls.Add(this.flpTheLoai);
            this.panelTheLoai.Controls.Add(this.lblTheLoaiTitle);
            this.panelTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTheLoai.Location = new System.Drawing.Point(13, 13);
            this.panelTheLoai.Margin = new System.Windows.Forms.Padding(8);
            this.panelTheLoai.Name = "panelTheLoai";
            this.panelTheLoai.Padding = new System.Windows.Forms.Padding(12);
            this.panelTheLoai.Size = new System.Drawing.Size(878, 254);
            this.panelTheLoai.TabIndex = 0;
            // 
            // flpTheLoai
            // 
            this.flpTheLoai.AutoScroll = true;
            this.flpTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flpTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTheLoai.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTheLoai.Location = new System.Drawing.Point(12, 42);
            this.flpTheLoai.Name = "flpTheLoai";
            this.flpTheLoai.Padding = new System.Windows.Forms.Padding(5);
            this.flpTheLoai.Size = new System.Drawing.Size(854, 200);
            this.flpTheLoai.TabIndex = 0;
            this.flpTheLoai.WrapContents = false;
            // 
            // lblTheLoaiTitle
            // 
            this.lblTheLoaiTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTheLoaiTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTheLoaiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblTheLoaiTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTheLoaiTitle.Name = "lblTheLoaiTitle";
            this.lblTheLoaiTitle.Size = new System.Drawing.Size(854, 30);
            this.lblTheLoaiTitle.TabIndex = 1;
            this.lblTheLoaiTitle.Text = "📚 CƠ CẤU SÁCH THEO THỂ LOẠI";
            // 
            // panelNamXB
            // 
            this.panelNamXB.BackColor = System.Drawing.Color.White;
            this.panelNamXB.Controls.Add(this.flpNamXB);
            this.panelNamXB.Controls.Add(this.lblNamXBTitle);
            this.panelNamXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNamXB.Location = new System.Drawing.Point(907, 13);
            this.panelNamXB.Margin = new System.Windows.Forms.Padding(8);
            this.panelNamXB.Name = "panelNamXB";
            this.panelNamXB.Padding = new System.Windows.Forms.Padding(12);
            this.panelNamXB.Size = new System.Drawing.Size(878, 254);
            this.panelNamXB.TabIndex = 1;
            // 
            // flpNamXB
            // 
            this.flpNamXB.AutoScroll = true;
            this.flpNamXB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flpNamXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNamXB.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNamXB.Location = new System.Drawing.Point(12, 42);
            this.flpNamXB.Name = "flpNamXB";
            this.flpNamXB.Padding = new System.Windows.Forms.Padding(5);
            this.flpNamXB.Size = new System.Drawing.Size(854, 200);
            this.flpNamXB.TabIndex = 0;
            this.flpNamXB.WrapContents = false;
            // 
            // lblNamXBTitle
            // 
            this.lblNamXBTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNamXBTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNamXBTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblNamXBTitle.Location = new System.Drawing.Point(12, 12);
            this.lblNamXBTitle.Name = "lblNamXBTitle";
            this.lblNamXBTitle.Size = new System.Drawing.Size(854, 30);
            this.lblNamXBTitle.TabIndex = 1;
            this.lblNamXBTitle.Text = "📅 PHÂN BỐ THEO NĂM XUẤT BẢN";
            // 
            // panelTable
            // 
            this.panelTable.BackColor = System.Drawing.Color.White;
            this.panelTable.Controls.Add(this.dgvChiTiet);
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTable.Location = new System.Drawing.Point(10, 470);
            this.panelTable.Name = "panelTable";
            this.panelTable.Padding = new System.Windows.Forms.Padding(10);
            this.panelTable.Size = new System.Drawing.Size(1798, 420);
            this.panelTable.TabIndex = 0;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChiTiet.ColumnHeadersHeight = 40;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colTenSach,
            this.colTheLoai,
            this.colTongBan,
            this.colSoBanHong,
            this.colTrangThai,
            this.colGiaTri});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 10);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 35;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1778, 400);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // colMa
            // 
            this.colMa.HeaderText = "Mã";
            this.colMa.MinimumWidth = 6;
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;
            this.colMa.Width = 60;
            // 
            // colTenSach
            // 
            this.colTenSach.HeaderText = "Tên Sách";
            this.colTenSach.MinimumWidth = 6;
            this.colTenSach.Name = "colTenSach";
            this.colTenSach.ReadOnly = true;
            this.colTenSach.Width = 250;
            // 
            // colTheLoai
            // 
            this.colTheLoai.HeaderText = "Thể Loại";
            this.colTheLoai.MinimumWidth = 6;
            this.colTheLoai.Name = "colTheLoai";
            this.colTheLoai.ReadOnly = true;
            this.colTheLoai.Width = 120;
            // 
            // colTongBan
            // 
            this.colTongBan.HeaderText = "Tổng Bản";
            this.colTongBan.MinimumWidth = 6;
            this.colTongBan.Name = "colTongBan";
            this.colTongBan.ReadOnly = true;
            this.colTongBan.Width = 80;
            // 
            // colSoBanHong
            // 
            this.colSoBanHong.HeaderText = "Hỏng/Mất";
            this.colSoBanHong.MinimumWidth = 6;
            this.colSoBanHong.Name = "colSoBanHong";
            this.colSoBanHong.ReadOnly = true;
            this.colSoBanHong.Width = 80;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng Thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 120;
            // 
            // colGiaTri
            // 
            this.colGiaTri.HeaderText = "Giá Trị Ước Tính";
            this.colGiaTri.MinimumWidth = 6;
            this.colGiaTri.Name = "colGiaTri";
            this.colGiaTri.ReadOnly = true;
            this.colGiaTri.Width = 120;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.lblTableTitle);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnRefresh);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(10, 420);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(10);
            this.panelSearch.Size = new System.Drawing.Size(1798, 50);
            this.panelSearch.TabIndex = 1;
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.AutoSize = true;
            this.lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblTableTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(267, 23);
            this.lblTableTitle.TabIndex = 0;
            this.lblTableTitle.Text = "📋 CHI TIẾT TÌNH TRẠNG SÁCH";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(280, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 29);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(510, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(620, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UCThongKeSach
            // 
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panelTable);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelCharts);
            this.Controls.Add(this.panelKPI);
            this.Name = "UCThongKeSach";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1818, 821);
            this.panelKPI.ResumeLayout(false);
            this.pnlKpi1.ResumeLayout(false);
            this.pnlKpi2.ResumeLayout(false);
            this.pnlKpi3.ResumeLayout(false);
            this.pnlKpi4.ResumeLayout(false);
            this.panelCharts.ResumeLayout(false);
            this.panelTheLoai.ResumeLayout(false);
            this.panelNamXB.ResumeLayout(false);
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel panelKPI;
        private System.Windows.Forms.Panel pnlKpi1;
        private System.Windows.Forms.Label lblTongDauSach;
        private System.Windows.Forms.Label lblKpi1Title;
        private System.Windows.Forms.Panel pnlKpi2;
        private System.Windows.Forms.Label lblTongBanSach;
        private System.Windows.Forms.Label lblKpi2Title;
        private System.Windows.Forms.Panel pnlKpi3;
        private System.Windows.Forms.Label lblSachCoSan;
        private System.Windows.Forms.Label lblKpi3Title;
        private System.Windows.Forms.Panel pnlKpi4;
        private System.Windows.Forms.Label lblSachBaoTri;
        private System.Windows.Forms.Label lblKpi4Title;
        private System.Windows.Forms.TableLayoutPanel panelCharts;
        private System.Windows.Forms.Panel panelTheLoai;
        private System.Windows.Forms.FlowLayoutPanel flpTheLoai;
        private System.Windows.Forms.Label lblTheLoaiTitle;
        private System.Windows.Forms.Panel panelNamXB;
        private System.Windows.Forms.FlowLayoutPanel flpNamXB;
        private System.Windows.Forms.Label lblNamXBTitle;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoBanHong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTri;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblTableTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
    }
}
