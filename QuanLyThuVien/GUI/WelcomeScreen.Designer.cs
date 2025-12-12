namespace QuanLyThuVien.GUI
{
    partial class WelcomeScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.FlowLayoutPanel();
            this.cardTongSach = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTongSach = new System.Windows.Forms.Label();
            this.lblTongSachTitle = new System.Windows.Forms.Label();
            this.cardTongDauSach = new System.Windows.Forms.Panel();
            this.iconTongDauSach = new System.Windows.Forms.Label();
            this.lblTongDauSach = new System.Windows.Forms.Label();
            this.lblTongDauSachTitle = new System.Windows.Forms.Label();
            this.cardTongDocGia = new System.Windows.Forms.Panel();
            this.iconTongDocGia = new System.Windows.Forms.Label();
            this.lblTongDocGia = new System.Windows.Forms.Label();
            this.lblTongDocGiaTitle = new System.Windows.Forms.Label();
            this.cardSachDangMuon = new System.Windows.Forms.Panel();
            this.iconSachDangMuon = new System.Windows.Forms.Label();
            this.lblSachDangMuon = new System.Windows.Forms.Label();
            this.lblSachDangMuonTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelActivity = new System.Windows.Forms.Panel();
            this.lblActivityTitle = new System.Windows.Forms.Label();
            this.dgvRecentActivity = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.cardTongSach.SuspendLayout();
            this.cardTongDauSach.SuspendLayout();
            this.cardTongDocGia.SuspendLayout();
            this.cardSachDangMuon.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelHeader.Size = new System.Drawing.Size(1650, 90);
            this.panelHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblWelcome.Location = new System.Drawing.Point(20, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(380, 46);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng đến Thư viện";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblSubtitle.Location = new System.Drawing.Point(25, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(310, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Hệ thống quản lý thư viện hiện đại và tiện lợi";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.Transparent;
            this.panelStats.Controls.Add(this.cardTongSach);
            this.panelStats.Controls.Add(this.cardTongDauSach);
            this.panelStats.Controls.Add(this.cardTongDocGia);
            this.panelStats.Controls.Add(this.cardSachDangMuon);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 90);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelStats.Size = new System.Drawing.Size(1650, 130);
            this.panelStats.TabIndex = 1;
            // 
            // cardTongSach
            // 
            this.cardTongSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.cardTongSach.Controls.Add(this.label1);
            this.cardTongSach.Controls.Add(this.lblTongSach);
            this.cardTongSach.Controls.Add(this.lblTongSachTitle);
            this.cardTongSach.Location = new System.Drawing.Point(15, 15);
            this.cardTongSach.Margin = new System.Windows.Forms.Padding(0, 5, 15, 5);
            this.cardTongSach.Name = "cardTongSach";
            this.cardTongSach.Size = new System.Drawing.Size(220, 100);
            this.cardTongSach.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "📚";
            // 
            // lblTongSach
            // 
            this.lblTongSach.AutoSize = true;
            this.lblTongSach.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTongSach.ForeColor = System.Drawing.Color.White;
            this.lblTongSach.Location = new System.Drawing.Point(100, 12);
            this.lblTongSach.Name = "lblTongSach";
            this.lblTongSach.Size = new System.Drawing.Size(42, 50);
            this.lblTongSach.TabIndex = 1;
            this.lblTongSach.Text = "0";
            // 
            // lblTongSachTitle
            // 
            this.lblTongSachTitle.AutoSize = true;
            this.lblTongSachTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongSachTitle.ForeColor = System.Drawing.Color.White;
            this.lblTongSachTitle.Location = new System.Drawing.Point(15, 70);
            this.lblTongSachTitle.Name = "lblTongSachTitle";
            this.lblTongSachTitle.Size = new System.Drawing.Size(82, 23);
            this.lblTongSachTitle.TabIndex = 2;
            this.lblTongSachTitle.Text = "Tổng sách";
            // 
            // cardTongDauSach
            // 
            this.cardTongDauSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.cardTongDauSach.Controls.Add(this.iconTongDauSach);
            this.cardTongDauSach.Controls.Add(this.lblTongDauSach);
            this.cardTongDauSach.Controls.Add(this.lblTongDauSachTitle);
            this.cardTongDauSach.Location = new System.Drawing.Point(250, 15);
            this.cardTongDauSach.Margin = new System.Windows.Forms.Padding(0, 5, 15, 5);
            this.cardTongDauSach.Name = "cardTongDauSach";
            this.cardTongDauSach.Size = new System.Drawing.Size(220, 100);
            this.cardTongDauSach.TabIndex = 1;
            // 
            // iconTongDauSach
            // 
            this.iconTongDauSach.AutoSize = true;
            this.iconTongDauSach.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.iconTongDauSach.ForeColor = System.Drawing.Color.White;
            this.iconTongDauSach.Location = new System.Drawing.Point(12, 12);
            this.iconTongDauSach.Name = "iconTongDauSach";
            this.iconTongDauSach.Size = new System.Drawing.Size(44, 54);
            this.iconTongDauSach.TabIndex = 0;
            this.iconTongDauSach.Text = "📖";
            // 
            // lblTongDauSach
            // 
            this.lblTongDauSach.AutoSize = true;
            this.lblTongDauSach.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTongDauSach.ForeColor = System.Drawing.Color.White;
            this.lblTongDauSach.Location = new System.Drawing.Point(100, 12);
            this.lblTongDauSach.Name = "lblTongDauSach";
            this.lblTongDauSach.Size = new System.Drawing.Size(42, 50);
            this.lblTongDauSach.TabIndex = 1;
            this.lblTongDauSach.Text = "0";
            // 
            // lblTongDauSachTitle
            // 
            this.lblTongDauSachTitle.AutoSize = true;
            this.lblTongDauSachTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongDauSachTitle.ForeColor = System.Drawing.Color.White;
            this.lblTongDauSachTitle.Location = new System.Drawing.Point(15, 70);
            this.lblTongDauSachTitle.Name = "lblTongDauSachTitle";
            this.lblTongDauSachTitle.Size = new System.Drawing.Size(109, 23);
            this.lblTongDauSachTitle.TabIndex = 2;
            this.lblTongDauSachTitle.Text = "Tổng đầu sách";
            // 
            // cardTongDocGia
            // 
            this.cardTongDocGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.cardTongDocGia.Controls.Add(this.iconTongDocGia);
            this.cardTongDocGia.Controls.Add(this.lblTongDocGia);
            this.cardTongDocGia.Controls.Add(this.lblTongDocGiaTitle);
            this.cardTongDocGia.Location = new System.Drawing.Point(485, 15);
            this.cardTongDocGia.Margin = new System.Windows.Forms.Padding(0, 5, 15, 5);
            this.cardTongDocGia.Name = "cardTongDocGia";
            this.cardTongDocGia.Size = new System.Drawing.Size(220, 100);
            this.cardTongDocGia.TabIndex = 2;
            // 
            // iconTongDocGia
            // 
            this.iconTongDocGia.AutoSize = true;
            this.iconTongDocGia.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.iconTongDocGia.ForeColor = System.Drawing.Color.White;
            this.iconTongDocGia.Location = new System.Drawing.Point(12, 12);
            this.iconTongDocGia.Name = "iconTongDocGia";
            this.iconTongDocGia.Size = new System.Drawing.Size(44, 54);
            this.iconTongDocGia.TabIndex = 0;
            this.iconTongDocGia.Text = "👤";
            // 
            // lblTongDocGia
            // 
            this.lblTongDocGia.AutoSize = true;
            this.lblTongDocGia.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTongDocGia.ForeColor = System.Drawing.Color.White;
            this.lblTongDocGia.Location = new System.Drawing.Point(100, 12);
            this.lblTongDocGia.Name = "lblTongDocGia";
            this.lblTongDocGia.Size = new System.Drawing.Size(42, 50);
            this.lblTongDocGia.TabIndex = 1;
            this.lblTongDocGia.Text = "0";
            // 
            // lblTongDocGiaTitle
            // 
            this.lblTongDocGiaTitle.AutoSize = true;
            this.lblTongDocGiaTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongDocGiaTitle.ForeColor = System.Drawing.Color.White;
            this.lblTongDocGiaTitle.Location = new System.Drawing.Point(15, 70);
            this.lblTongDocGiaTitle.Name = "lblTongDocGiaTitle";
            this.lblTongDocGiaTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTongDocGiaTitle.TabIndex = 2;
            this.lblTongDocGiaTitle.Text = "Tổng độc giả";
            // 
            // cardSachDangMuon
            // 
            this.cardSachDangMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.cardSachDangMuon.Controls.Add(this.iconSachDangMuon);
            this.cardSachDangMuon.Controls.Add(this.lblSachDangMuon);
            this.cardSachDangMuon.Controls.Add(this.lblSachDangMuonTitle);
            this.cardSachDangMuon.Location = new System.Drawing.Point(720, 15);
            this.cardSachDangMuon.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.cardSachDangMuon.Name = "cardSachDangMuon";
            this.cardSachDangMuon.Size = new System.Drawing.Size(220, 100);
            this.cardSachDangMuon.TabIndex = 3;
            // 
            // iconSachDangMuon
            // 
            this.iconSachDangMuon.AutoSize = true;
            this.iconSachDangMuon.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.iconSachDangMuon.ForeColor = System.Drawing.Color.White;
            this.iconSachDangMuon.Location = new System.Drawing.Point(12, 12);
            this.iconSachDangMuon.Name = "iconSachDangMuon";
            this.iconSachDangMuon.Size = new System.Drawing.Size(44, 54);
            this.iconSachDangMuon.TabIndex = 0;
            this.iconSachDangMuon.Text = "📋";
            // 
            // lblSachDangMuon
            // 
            this.lblSachDangMuon.AutoSize = true;
            this.lblSachDangMuon.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSachDangMuon.ForeColor = System.Drawing.Color.White;
            this.lblSachDangMuon.Location = new System.Drawing.Point(100, 12);
            this.lblSachDangMuon.Name = "lblSachDangMuon";
            this.lblSachDangMuon.Size = new System.Drawing.Size(42, 50);
            this.lblSachDangMuon.TabIndex = 1;
            this.lblSachDangMuon.Text = "0";
            // 
            // lblSachDangMuonTitle
            // 
            this.lblSachDangMuonTitle.AutoSize = true;
            this.lblSachDangMuonTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSachDangMuonTitle.ForeColor = System.Drawing.Color.White;
            this.lblSachDangMuonTitle.Location = new System.Drawing.Point(15, 70);
            this.lblSachDangMuonTitle.Name = "lblSachDangMuonTitle";
            this.lblSachDangMuonTitle.Size = new System.Drawing.Size(119, 23);
            this.lblSachDangMuonTitle.TabIndex = 2;
            this.lblSachDangMuonTitle.Text = "Sách đang mượn";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.Controls.Add(this.panelActivity);
            this.panelContent.Controls.Add(this.panelInfo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 220);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelContent.Size = new System.Drawing.Size(1650, 780);
            this.panelContent.TabIndex = 4;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Controls.Add(this.lblInfoTitle);
            this.panelInfo.Controls.Add(this.lblInfo1);
            this.panelInfo.Controls.Add(this.lblInfo2);
            this.panelInfo.Controls.Add(this.lblInfo3);
            this.panelInfo.Controls.Add(this.lblInfo4);
            this.panelInfo.Controls.Add(this.btnRefresh);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInfo.Location = new System.Drawing.Point(15, 10);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(20);
            this.panelInfo.Size = new System.Drawing.Size(450, 760);
            this.panelInfo.TabIndex = 2;
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(20, 20);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(204, 32);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "Giới thiệu Thư viện";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblInfo1.Location = new System.Drawing.Point(20, 70);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(410, 70);
            this.lblInfo1.TabIndex = 1;
            this.lblInfo1.Text = "Thư viện của chúng tôi cung cấp hơn 10,000 đầu sách đa dạng từ văn học, khoa học," +
    " công nghệ đến nghệ thuật và nhiều lĩnh vực khác.";
            // 
            // lblInfo2
            // 
            this.lblInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblInfo2.Location = new System.Drawing.Point(20, 150);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(410, 50);
            this.lblInfo2.TabIndex = 2;
            this.lblInfo2.Text = "Hệ thống quản lý hiện đại, dễ sử dụng, giúp việc mượn trả sách trở nên nhanh chón" +
    "g và thuận tiện.";
            // 
            // lblInfo3
            // 
            this.lblInfo3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblInfo3.Location = new System.Drawing.Point(20, 210);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(410, 50);
            this.lblInfo3.TabIndex = 3;
            this.lblInfo3.Text = "Giờ mở cửa: Thứ 2 - Thứ 6: 8:00 - 20:00 | Thứ 7 - CN: 9:00 - 17:00";
            // 
            // lblInfo4
            // 
            this.lblInfo4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblInfo4.Location = new System.Drawing.Point(20, 270);
            this.lblInfo4.Name = "lblInfo4";
            this.lblInfo4.Size = new System.Drawing.Size(410, 30);
            this.lblInfo4.TabIndex = 4;
            this.lblInfo4.Text = "Liên hệ: hohoanglong2508@gmail.com | Hotline: 0937211264";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 320);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 40);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "🔄 Làm mới dữ liệu";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelActivity
            // 
            this.panelActivity.BackColor = System.Drawing.Color.White;
            this.panelActivity.Controls.Add(this.lblActivityTitle);
            this.panelActivity.Controls.Add(this.dgvRecentActivity);
            this.panelActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActivity.Location = new System.Drawing.Point(465, 10);
            this.panelActivity.Name = "panelActivity";
            this.panelActivity.Padding = new System.Windows.Forms.Padding(20);
            this.panelActivity.Size = new System.Drawing.Size(1170, 760);
            this.panelActivity.TabIndex = 3;
            // 
            // lblActivityTitle
            // 
            this.lblActivityTitle.AutoSize = true;
            this.lblActivityTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblActivityTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblActivityTitle.Location = new System.Drawing.Point(20, 20);
            this.lblActivityTitle.Name = "lblActivityTitle";
            this.lblActivityTitle.Size = new System.Drawing.Size(210, 32);
            this.lblActivityTitle.TabIndex = 0;
            this.lblActivityTitle.Text = "Hoạt động gần đây";
            // 
            // dgvRecentActivity
            // 
            this.dgvRecentActivity.AllowUserToAddRows = false;
            this.dgvRecentActivity.AllowUserToDeleteRows = false;
            this.dgvRecentActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentActivity.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentActivity.ColumnHeadersHeight = 40;
            this.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentActivity.EnableHeadersVisualStyles = false;
            this.dgvRecentActivity.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRecentActivity.Location = new System.Drawing.Point(20, 65);
            this.dgvRecentActivity.Name = "dgvRecentActivity";
            this.dgvRecentActivity.ReadOnly = true;
            this.dgvRecentActivity.RowHeadersVisible = false;
            this.dgvRecentActivity.RowHeadersWidth = 51;
            this.dgvRecentActivity.RowTemplate.Height = 35;
            this.dgvRecentActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentActivity.Size = new System.Drawing.Size(1130, 675);
            this.dgvRecentActivity.TabIndex = 1;
            // 
            // WelcomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Name = "WelcomeScreen";
            this.Size = new System.Drawing.Size(1650, 1000);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.cardTongSach.ResumeLayout(false);
            this.cardTongSach.PerformLayout();
            this.cardTongDauSach.ResumeLayout(false);
            this.cardTongDauSach.PerformLayout();
            this.cardTongDocGia.ResumeLayout(false);
            this.cardTongDocGia.PerformLayout();
            this.cardSachDangMuon.ResumeLayout(false);
            this.cardSachDangMuon.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelActivity.ResumeLayout(false);
            this.panelActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel panelStats;
        private System.Windows.Forms.Panel cardTongSach;
        private System.Windows.Forms.Label lblTongSach;
        private System.Windows.Forms.Label lblTongSachTitle;
        private System.Windows.Forms.Panel cardTongDauSach;
        private System.Windows.Forms.Label iconTongDauSach;
        private System.Windows.Forms.Label lblTongDauSach;
        private System.Windows.Forms.Label lblTongDauSachTitle;
        private System.Windows.Forms.Panel cardTongDocGia;
        private System.Windows.Forms.Label iconTongDocGia;
        private System.Windows.Forms.Label lblTongDocGia;
        private System.Windows.Forms.Label lblTongDocGiaTitle;
        private System.Windows.Forms.Panel cardSachDangMuon;
        private System.Windows.Forms.Label iconSachDangMuon;
        private System.Windows.Forms.Label lblSachDangMuon;
        private System.Windows.Forms.Label lblSachDangMuonTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelActivity;
        private System.Windows.Forms.Label lblActivityTitle;
        private System.Windows.Forms.DataGridView dgvRecentActivity;
        private System.Windows.Forms.Label label1;
    }
}
