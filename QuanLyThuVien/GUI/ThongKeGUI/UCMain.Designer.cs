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
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControlTK = new System.Windows.Forms.TabControl();
            this.btn_tongquan = new System.Windows.Forms.TabPage();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblOutstanding = new System.Windows.Forms.Label();
            this.lblUniqueReaders = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btn_sach = new System.Windows.Forms.TabPage();
            this.btn_phieuphat = new System.Windows.Forms.TabPage();
            this.btn_docgia = new System.Windows.Forms.TabPage();
            this.btn_phieumuon = new System.Windows.Forms.TabPage();
            this.tabControlTK.SuspendLayout();
            this.btn_tongquan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // tabControlTK
            // 
            this.tabControlTK.Controls.Add(this.btn_tongquan);
            this.tabControlTK.Controls.Add(this.btn_sach);
            this.tabControlTK.Controls.Add(this.btn_phieuphat);
            this.tabControlTK.Controls.Add(this.btn_docgia);
            this.tabControlTK.Controls.Add(this.btn_phieumuon);
            this.tabControlTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTK.Location = new System.Drawing.Point(0, 0);
            this.tabControlTK.Name = "tabControlTK";
            this.tabControlTK.SelectedIndex = 0;
            this.tabControlTK.Size = new System.Drawing.Size(1101, 732);
            this.tabControlTK.TabIndex = 0;
            // 
            // btn_tongquan
            // 
            this.btn_tongquan.Controls.Add(this.dgvStats);
            this.btn_tongquan.Controls.Add(this.panelSummary);
            this.btn_tongquan.Controls.Add(this.panelTop);
            this.btn_tongquan.Location = new System.Drawing.Point(4, 25);
            this.btn_tongquan.Name = "btn_tongquan";
            this.btn_tongquan.Padding = new System.Windows.Forms.Padding(3);
            this.btn_tongquan.Size = new System.Drawing.Size(1093, 703);
            this.btn_tongquan.TabIndex = 0;
            this.btn_tongquan.Text = "Tổng Quan";
            this.btn_tongquan.UseVisualStyleBackColor = true;
            this.btn_tongquan.Click += new System.EventHandler(this.tabPageTK_Click);
            // 
            // dgvStats
            // 
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStats.ColumnHeadersHeight = 29;
            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStats.Location = new System.Drawing.Point(3, 73);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.RowHeadersVisible = false;
            this.dgvStats.RowHeadersWidth = 51;
            this.dgvStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStats.Size = new System.Drawing.Size(1087, 547);
            this.dgvStats.TabIndex = 0;
            // 
            // panelSummary
            // 
            this.panelSummary.Controls.Add(this.lblTotalCount);
            this.panelSummary.Controls.Add(this.lblTotalAmount);
            this.panelSummary.Controls.Add(this.lblOutstanding);
            this.panelSummary.Controls.Add(this.lblUniqueReaders);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSummary.Location = new System.Drawing.Point(3, 620);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Padding = new System.Windows.Forms.Padding(8);
            this.panelSummary.Size = new System.Drawing.Size(1087, 80);
            this.panelSummary.TabIndex = 1;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(8, 12);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 16);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "Số phiếu: 0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(8, 36);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(83, 16);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "Tổng thu: 0 đ";
            // 
            // lblOutstanding
            // 
            this.lblOutstanding.AutoSize = true;
            this.lblOutstanding.Location = new System.Drawing.Point(220, 36);
            this.lblOutstanding.Name = "lblOutstanding";
            this.lblOutstanding.Size = new System.Drawing.Size(82, 16);
            this.lblOutstanding.TabIndex = 2;
            this.lblOutstanding.Text = "Chưa thu: 0 đ";
            // 
            // lblUniqueReaders
            // 
            this.lblUniqueReaders.AutoSize = true;
            this.lblUniqueReaders.Location = new System.Drawing.Point(400, 12);
            this.lblUniqueReaders.Name = "lblUniqueReaders";
            this.lblUniqueReaders.Size = new System.Drawing.Size(123, 16);
            this.lblUniqueReaders.TabIndex = 3;
            this.lblUniqueReaders.Text = "Độc giả liên quan: 0";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.dtpFrom);
            this.panelTop.Controls.Add(this.dtpTo);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(8);
            this.panelTop.Size = new System.Drawing.Size(1087, 70);
            this.panelTop.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(40, 18);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(110, 22);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(196, 18);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(110, 22);
            this.dtpTo.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(743, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 22);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(981, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 27);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btn_sach
            // 
            this.btn_sach.Location = new System.Drawing.Point(4, 25);
            this.btn_sach.Name = "btn_sach";
            this.btn_sach.Padding = new System.Windows.Forms.Padding(3);
            this.btn_sach.Size = new System.Drawing.Size(1093, 703);
            this.btn_sach.TabIndex = 1;
            this.btn_sach.Text = "Sách";
            this.btn_sach.UseVisualStyleBackColor = true;
            // 
            // btn_phieuphat
            // 
            this.btn_phieuphat.Location = new System.Drawing.Point(4, 25);
            this.btn_phieuphat.Name = "btn_phieuphat";
            this.btn_phieuphat.Padding = new System.Windows.Forms.Padding(3);
            this.btn_phieuphat.Size = new System.Drawing.Size(1093, 703);
            this.btn_phieuphat.TabIndex = 2;
            this.btn_phieuphat.Text = "Phiếu Phạt";
            this.btn_phieuphat.UseVisualStyleBackColor = true;
            // 
            // btn_docgia
            // 
            this.btn_docgia.Location = new System.Drawing.Point(4, 25);
            this.btn_docgia.Name = "btn_docgia";
            this.btn_docgia.Padding = new System.Windows.Forms.Padding(3);
            this.btn_docgia.Size = new System.Drawing.Size(1093, 703);
            this.btn_docgia.TabIndex = 3;
            this.btn_docgia.Text = "Độc Giả";
            this.btn_docgia.UseVisualStyleBackColor = true;
            // 
            // btn_phieumuon
            // 
            this.btn_phieumuon.Location = new System.Drawing.Point(4, 25);
            this.btn_phieumuon.Name = "btn_phieumuon";
            this.btn_phieumuon.Padding = new System.Windows.Forms.Padding(3);
            this.btn_phieumuon.Size = new System.Drawing.Size(1093, 703);
            this.btn_phieumuon.TabIndex = 4;
            this.btn_phieumuon.Text = "Phiếu Mượn";
            this.btn_phieumuon.UseVisualStyleBackColor = true;
            // 
            // UCMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlTK);
            this.Name = "UCMain";
            this.Size = new System.Drawing.Size(1101, 732);
            this.Load += new System.EventHandler(this.UCMain_Load);
            this.tabControlTK.ResumeLayout(false);
            this.btn_tongquan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControlTK;
        private System.Windows.Forms.TabPage btn_tongquan;
        private System.Windows.Forms.TabPage btn_sach;
        private System.Windows.Forms.TabPage btn_phieuphat;
        private System.Windows.Forms.TabPage btn_docgia;
        private System.Windows.Forms.TabPage btn_phieumuon;

        // Designer controls for overview
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblOutstanding;
        private System.Windows.Forms.Label lblUniqueReaders;
    }
}
