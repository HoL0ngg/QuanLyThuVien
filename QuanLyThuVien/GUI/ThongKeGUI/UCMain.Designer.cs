namespace QuanLyThuVien.GUI.ThongKeGUI
{
    partial class UCMain
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
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlTK = new System.Windows.Forms.TabControl();
            this.btn_tongquan = new System.Windows.Forms.TabPage();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.panelTrend = new System.Windows.Forms.Panel();
            this.panelTop5 = new System.Windows.Forms.Panel();
            this.panelCategory = new System.Windows.Forms.Panel();
            this.panelKPI = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpi1 = new System.Windows.Forms.Panel();
            this.kpiBorrow = new System.Windows.Forms.Label();
            this.lblKpi1Title = new System.Windows.Forms.Label();
            this.pnlKpi2 = new System.Windows.Forms.Panel();
            this.kpiBooks = new System.Windows.Forms.Label();
            this.lblKpi2Title = new System.Windows.Forms.Label();
            this.pnlKpi3 = new System.Windows.Forms.Panel();
            this.kpiOverdue = new System.Windows.Forms.Label();
            this.lblKpi3Title = new System.Windows.Forms.Label();
            this.pnlKpi4 = new System.Windows.Forms.Panel();
            this.kpiPenalty = new System.Windows.Forms.Label();
            this.lblKpi4Title = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.btnToday = new System.Windows.Forms.Button();
            this.btn7Days = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.btnThisYear = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btn_sach = new System.Windows.Forms.TabPage();
            this.btn_phieuphat = new System.Windows.Forms.TabPage();
            this.btn_docgia = new System.Windows.Forms.TabPage();
            this.btn_phieumuon = new System.Windows.Forms.TabPage();
            this.tabControlTK.SuspendLayout();
            this.btn_tongquan.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCharts.SuspendLayout();
            this.panelKPI.SuspendLayout();
            this.pnlKpi1.SuspendLayout();
            this.pnlKpi2.SuspendLayout();
            this.pnlKpi3.SuspendLayout();
            this.pnlKpi4.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTK
            // 
            this.tabControlTK.Controls.Add(this.btn_tongquan);
            this.tabControlTK.Controls.Add(this.btn_sach);
            this.tabControlTK.Controls.Add(this.btn_phieuphat);
            this.tabControlTK.Controls.Add(this.btn_docgia);
            this.tabControlTK.Controls.Add(this.btn_phieumuon);
            this.tabControlTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlTK.Location = new System.Drawing.Point(0, 0);
            this.tabControlTK.Name = "tabControlTK";
            this.tabControlTK.SelectedIndex = 0;
            this.tabControlTK.Size = new System.Drawing.Size(1101, 732);
            this.tabControlTK.TabIndex = 0;
            // 
            // btn_tongquan
            // 
            this.btn_tongquan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn_tongquan.Controls.Add(this.panelMain);
            this.btn_tongquan.Controls.Add(this.panelTop);
            this.btn_tongquan.Location = new System.Drawing.Point(4, 32);
            this.btn_tongquan.Name = "btn_tongquan";
            this.btn_tongquan.Padding = new System.Windows.Forms.Padding(10);
            this.btn_tongquan.Size = new System.Drawing.Size(1093, 696);
            this.btn_tongquan.TabIndex = 0;
            this.btn_tongquan.Text = "Tổng Quan";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelCharts);
            this.panelMain.Controls.Add(this.panelKPI);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(10, 90);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(1073, 596);
            this.panelMain.TabIndex = 0;
            // 
            // panelCharts
            // 
            this.panelCharts.ColumnCount = 3;
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.panelCharts.Controls.Add(this.panelTrend, 0, 0);
            this.panelCharts.Controls.Add(this.panelTop5, 1, 0);
            this.panelCharts.Controls.Add(this.panelCategory, 2, 0);
            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharts.Location = new System.Drawing.Point(10, 140);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelCharts.RowCount = 1;
            this.panelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 426F));
            this.panelCharts.Size = new System.Drawing.Size(1053, 446);
            this.panelCharts.TabIndex = 0;
            // 
            // panelTrend
            // 
            this.panelTrend.BackColor = System.Drawing.Color.White;
            this.panelTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTrend.Location = new System.Drawing.Point(8, 18);
            this.panelTrend.Margin = new System.Windows.Forms.Padding(8);
            this.panelTrend.Name = "panelTrend";
            this.panelTrend.Padding = new System.Windows.Forms.Padding(16);
            this.panelTrend.Size = new System.Drawing.Size(331, 410);
            this.panelTrend.TabIndex = 0;
            // 
            // panelTop5
            // 
            this.panelTop5.BackColor = System.Drawing.Color.White;
            this.panelTop5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop5.Location = new System.Drawing.Point(355, 18);
            this.panelTop5.Margin = new System.Windows.Forms.Padding(8);
            this.panelTop5.Name = "panelTop5";
            this.panelTop5.Padding = new System.Windows.Forms.Padding(16);
            this.panelTop5.Size = new System.Drawing.Size(342, 410);
            this.panelTop5.TabIndex = 1;
            // 
            // panelCategory
            // 
            this.panelCategory.BackColor = System.Drawing.Color.White;
            this.panelCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCategory.Location = new System.Drawing.Point(713, 18);
            this.panelCategory.Margin = new System.Windows.Forms.Padding(8);
            this.panelCategory.Name = "panelCategory";
            this.panelCategory.Padding = new System.Windows.Forms.Padding(16);
            this.panelCategory.Size = new System.Drawing.Size(332, 410);
            this.panelCategory.TabIndex = 2;
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
            this.panelKPI.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panelKPI.RowCount = 1;
            this.panelKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.panelKPI.Size = new System.Drawing.Size(1053, 130);
            this.panelKPI.TabIndex = 2;
            // 
            // pnlKpi1
            // 
            this.pnlKpi1.BackColor = System.Drawing.Color.White;
            this.pnlKpi1.Controls.Add(this.kpiBorrow);
            this.pnlKpi1.Controls.Add(this.lblKpi1Title);
            this.pnlKpi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi1.Location = new System.Drawing.Point(8, 13);
            this.pnlKpi1.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlKpi1.Size = new System.Drawing.Size(247, 104);
            this.pnlKpi1.TabIndex = 0;
            // 
            // kpiBorrow
            // 
            this.kpiBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiBorrow.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.kpiBorrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.kpiBorrow.Location = new System.Drawing.Point(16, 36);
            this.kpiBorrow.Name = "kpiBorrow";
            this.kpiBorrow.Size = new System.Drawing.Size(215, 56);
            this.kpiBorrow.TabIndex = 0;
            this.kpiBorrow.Text = "0";
            this.kpiBorrow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kpiBorrow.Click += new System.EventHandler(this.kpiBorrow_Click);
            // 
            // lblKpi1Title
            // 
            this.lblKpi1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi1Title.Location = new System.Drawing.Point(16, 12);
            this.lblKpi1Title.Name = "lblKpi1Title";
            this.lblKpi1Title.Size = new System.Drawing.Size(215, 24);
            this.lblKpi1Title.TabIndex = 1;
            this.lblKpi1Title.Text = "LƯỢT MƯỢN";
            this.lblKpi1Title.Click += new System.EventHandler(this.lblKpi1Title_Click);
            // 
            // pnlKpi2
            // 
            this.pnlKpi2.BackColor = System.Drawing.Color.White;
            this.pnlKpi2.Controls.Add(this.kpiBooks);
            this.pnlKpi2.Controls.Add(this.lblKpi2Title);
            this.pnlKpi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi2.Location = new System.Drawing.Point(271, 13);
            this.pnlKpi2.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlKpi2.Size = new System.Drawing.Size(247, 104);
            this.pnlKpi2.TabIndex = 1;
            // 
            // kpiBooks
            // 
            this.kpiBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiBooks.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.kpiBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.kpiBooks.Location = new System.Drawing.Point(16, 36);
            this.kpiBooks.Name = "kpiBooks";
            this.kpiBooks.Size = new System.Drawing.Size(215, 56);
            this.kpiBooks.TabIndex = 0;
            this.kpiBooks.Text = "0";
            this.kpiBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kpiBooks.Click += new System.EventHandler(this.kpiBooks_Click);
            // 
            // lblKpi2Title
            // 
            this.lblKpi2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi2Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi2Title.Location = new System.Drawing.Point(16, 12);
            this.lblKpi2Title.Name = "lblKpi2Title";
            this.lblKpi2Title.Size = new System.Drawing.Size(215, 24);
            this.lblKpi2Title.TabIndex = 1;
            this.lblKpi2Title.Text = "SÁCH TRONG KHO";
            // 
            // pnlKpi3
            // 
            this.pnlKpi3.BackColor = System.Drawing.Color.White;
            this.pnlKpi3.Controls.Add(this.kpiOverdue);
            this.pnlKpi3.Controls.Add(this.lblKpi3Title);
            this.pnlKpi3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi3.Location = new System.Drawing.Point(534, 13);
            this.pnlKpi3.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlKpi3.Size = new System.Drawing.Size(247, 104);
            this.pnlKpi3.TabIndex = 2;
            // 
            // kpiOverdue
            // 
            this.kpiOverdue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiOverdue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.kpiOverdue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.kpiOverdue.Location = new System.Drawing.Point(16, 36);
            this.kpiOverdue.Name = "kpiOverdue";
            this.kpiOverdue.Size = new System.Drawing.Size(215, 56);
            this.kpiOverdue.TabIndex = 0;
            this.kpiOverdue.Text = "0";
            this.kpiOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpi3Title
            // 
            this.lblKpi3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi3Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi3Title.Location = new System.Drawing.Point(16, 12);
            this.lblKpi3Title.Name = "lblKpi3Title";
            this.lblKpi3Title.Size = new System.Drawing.Size(215, 24);
            this.lblKpi3Title.TabIndex = 1;
            this.lblKpi3Title.Text = "Sách Hỏng/Mất";
            // 
            // pnlKpi4
            // 
            this.pnlKpi4.BackColor = System.Drawing.Color.White;
            this.pnlKpi4.Controls.Add(this.kpiPenalty);
            this.pnlKpi4.Controls.Add(this.lblKpi4Title);
            this.pnlKpi4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi4.Location = new System.Drawing.Point(797, 13);
            this.pnlKpi4.Margin = new System.Windows.Forms.Padding(8);
            this.pnlKpi4.Name = "pnlKpi4";
            this.pnlKpi4.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlKpi4.Size = new System.Drawing.Size(248, 104);
            this.pnlKpi4.TabIndex = 3;
            // 
            // kpiPenalty
            // 
            this.kpiPenalty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiPenalty.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.kpiPenalty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.kpiPenalty.Location = new System.Drawing.Point(16, 36);
            this.kpiPenalty.Name = "kpiPenalty";
            this.kpiPenalty.Size = new System.Drawing.Size(216, 56);
            this.kpiPenalty.TabIndex = 0;
            this.kpiPenalty.Text = "0 đ";
            this.kpiPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpi4Title
            // 
            this.lblKpi4Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi4Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpi4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblKpi4Title.Location = new System.Drawing.Point(16, 12);
            this.lblKpi4Title.Name = "lblKpi4Title";
            this.lblKpi4Title.Size = new System.Drawing.Size(216, 24);
            this.lblKpi4Title.TabIndex = 1;
            this.lblKpi4Title.Text = "THU PHÍ PHẠT";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblFilterTitle);
            this.panelTop.Controls.Add(this.btnToday);
            this.panelTop.Controls.Add(this.btn7Days);
            this.panelTop.Controls.Add(this.btnThisMonth);
            this.panelTop.Controls.Add(this.btnThisYear);
            this.panelTop.Controls.Add(this.lblFrom);
            this.panelTop.Controls.Add(this.dtpFrom);
            this.panelTop.Controls.Add(this.lblTo);
            this.panelTop.Controls.Add(this.dtpTo);
            this.panelTop.Controls.Add(this.btnGenerate);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(10, 10);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.panelTop.Size = new System.Drawing.Size(1073, 80);
            this.panelTop.TabIndex = 1;
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblFilterTitle.Location = new System.Drawing.Point(16, 8);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(62, 20);
            this.lblFilterTitle.TabIndex = 0;
            this.lblFilterTitle.Text = "BỘ LỌC";
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(16, 32);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(75, 32);
            this.btnToday.TabIndex = 1;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.BtnToday_Click);
            // 
            // btn7Days
            // 
            this.btn7Days.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.btn7Days.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn7Days.FlatAppearance.BorderSize = 0;
            this.btn7Days.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7Days.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn7Days.ForeColor = System.Drawing.Color.White;
            this.btn7Days.Location = new System.Drawing.Point(96, 32);
            this.btn7Days.Name = "btn7Days";
            this.btn7Days.Size = new System.Drawing.Size(70, 32);
            this.btn7Days.TabIndex = 2;
            this.btn7Days.Text = "7 ngày";
            this.btn7Days.UseVisualStyleBackColor = false;
            this.btn7Days.Click += new System.EventHandler(this.Btn7Days_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.btnThisMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThisMonth.FlatAppearance.BorderSize = 0;
            this.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.Location = new System.Drawing.Point(171, 32);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(85, 32);
            this.btnThisMonth.TabIndex = 3;
            this.btnThisMonth.Text = "Tháng này";
            this.btnThisMonth.UseVisualStyleBackColor = false;
            this.btnThisMonth.Click += new System.EventHandler(this.BtnThisMonth_Click);
            // 
            // btnThisYear
            // 
            this.btnThisYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.btnThisYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThisYear.FlatAppearance.BorderSize = 0;
            this.btnThisYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThisYear.ForeColor = System.Drawing.Color.White;
            this.btnThisYear.Location = new System.Drawing.Point(261, 32);
            this.btnThisYear.Name = "btnThisYear";
            this.btnThisYear.Size = new System.Drawing.Size(75, 32);
            this.btnThisYear.TabIndex = 4;
            this.btnThisYear.Text = "Năm nay";
            this.btnThisYear.UseVisualStyleBackColor = false;
            this.btnThisYear.Click += new System.EventHandler(this.BtnThisYear_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrom.Location = new System.Drawing.Point(360, 38);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(29, 20);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "Từ:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(385, 34);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(110, 27);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTo.Location = new System.Drawing.Point(505, 38);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(39, 20);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "Đến:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(538, 34);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(110, 27);
            this.dtpTo.TabIndex = 8;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(660, 32);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(90, 32);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Thống kê";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btn_sach
            // 
            this.btn_sach.AutoScroll = true;
            this.btn_sach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn_sach.Location = new System.Drawing.Point(4, 32);
            this.btn_sach.Name = "btn_sach";
            this.btn_sach.Padding = new System.Windows.Forms.Padding(3);
            this.btn_sach.Size = new System.Drawing.Size(1093, 696);
            this.btn_sach.TabIndex = 1;
            this.btn_sach.Text = "Sách";
            // 
            // btn_phieuphat
            // 
            this.btn_phieuphat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn_phieuphat.Location = new System.Drawing.Point(4, 32);
            this.btn_phieuphat.Name = "btn_phieuphat";
            this.btn_phieuphat.Size = new System.Drawing.Size(1093, 696);
            this.btn_phieuphat.TabIndex = 2;
            this.btn_phieuphat.Text = "Phiếu Phạt";
            // 
            // btn_docgia
            // 
            this.btn_docgia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn_docgia.Location = new System.Drawing.Point(4, 32);
            this.btn_docgia.Name = "btn_docgia";
            this.btn_docgia.Size = new System.Drawing.Size(1093, 696);
            this.btn_docgia.TabIndex = 3;
            this.btn_docgia.Text = "Độc Giả";
            // 
            // btn_phieumuon
            // 
            this.btn_phieumuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn_phieumuon.Location = new System.Drawing.Point(4, 32);
            this.btn_phieumuon.Name = "btn_phieumuon";
            this.btn_phieumuon.Size = new System.Drawing.Size(1093, 696);
            this.btn_phieumuon.TabIndex = 4;
            this.btn_phieumuon.Text = "Phiếu Mượn";
            // 
            // UCMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.tabControlTK);
            this.Name = "UCMain";
            this.Size = new System.Drawing.Size(1101, 732);
            this.Load += new System.EventHandler(this.UCMain_Load);
            this.tabControlTK.ResumeLayout(false);
            this.btn_tongquan.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelCharts.ResumeLayout(false);
            this.panelKPI.ResumeLayout(false);
            this.pnlKpi1.ResumeLayout(false);
            this.pnlKpi2.ResumeLayout(false);
            this.pnlKpi3.ResumeLayout(false);
            this.pnlKpi4.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlTK;
        private System.Windows.Forms.TabPage btn_tongquan;
        private System.Windows.Forms.TabPage btn_sach;
        private System.Windows.Forms.TabPage btn_phieuphat;
        private System.Windows.Forms.TabPage btn_docgia;
        private System.Windows.Forms.TabPage btn_phieumuon;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btn7Days;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Button btnThisYear;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelKPI;
        private System.Windows.Forms.Panel pnlKpi1;
        private System.Windows.Forms.Label lblKpi1Title;
        private System.Windows.Forms.Label kpiBorrow;
        private System.Windows.Forms.Panel pnlKpi2;
        private System.Windows.Forms.Label lblKpi2Title;
        private System.Windows.Forms.Label kpiBooks;
        private System.Windows.Forms.Panel pnlKpi3;
        private System.Windows.Forms.Label lblKpi3Title;
        private System.Windows.Forms.Label kpiOverdue;
        private System.Windows.Forms.Panel pnlKpi4;
        private System.Windows.Forms.Label lblKpi4Title;
        private System.Windows.Forms.Label kpiPenalty;
        private System.Windows.Forms.TableLayoutPanel panelCharts;
        private System.Windows.Forms.Panel panelTrend;
        private System.Windows.Forms.Panel panelTop5;
        private System.Windows.Forms.Panel panelCategory;
    }
}
