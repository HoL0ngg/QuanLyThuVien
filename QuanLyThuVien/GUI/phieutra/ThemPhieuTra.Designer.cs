namespace QuanLyThuVien.GUI.phieutra
{
    partial class ThemPhieuTra
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
            this.addPhieuMuon = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.bangCTPhieuMuon = new System.Windows.Forms.DataGridView();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.bangPhieuMuon = new System.Windows.Forms.DataGridView();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayTraDuKien = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaDocGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bangCTPhieuMuon)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bangPhieuMuon)).BeginInit();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // addPhieuMuon
            // 
            this.addPhieuMuon.Location = new System.Drawing.Point(6, 156);
            this.addPhieuMuon.Name = "addPhieuMuon";
            this.addPhieuMuon.Size = new System.Drawing.Size(130, 25);
            this.addPhieuMuon.TabIndex = 6;
            this.addPhieuMuon.Text = " Thêm Phiếu Mượn";
            this.addPhieuMuon.UseVisualStyleBackColor = true;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.Location = new System.Drawing.Point(774, 22);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(110, 25);
            this.btnClearFilters.TabIndex = 13;
            this.btnClearFilters.Text = "Xóa tất cả bộ lọc";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu";
            // 
            // txtMaPhieuMuon
            // 
            this.txtMaPhieuMuon.Location = new System.Drawing.Point(110, 25);
            this.txtMaPhieuMuon.Name = "txtMaPhieuMuon";
            this.txtMaPhieuMuon.Size = new System.Drawing.Size(150, 20);
            this.txtMaPhieuMuon.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày mượn từ";
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayMuon.Location = new System.Drawing.Point(360, 25);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(130, 20);
            this.dtpNgayMuon.TabIndex = 3;
            // 
            // bangCTPhieuMuon
            // 
            this.bangCTPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bangCTPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bangCTPhieuMuon.Location = new System.Drawing.Point(3, 16);
            this.bangCTPhieuMuon.Name = "bangCTPhieuMuon";
            this.bangCTPhieuMuon.Size = new System.Drawing.Size(1212, 313);
            this.bangCTPhieuMuon.TabIndex = 0;
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.bangCTPhieuMuon);
            this.groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(1218, 332);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Chi tiết phiếu mượn";
            // 
            // bangPhieuMuon
            // 
            this.bangPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bangPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bangPhieuMuon.Location = new System.Drawing.Point(3, 16);
            this.bangPhieuMuon.Name = "bangPhieuMuon";
            this.bangPhieuMuon.Size = new System.Drawing.Size(1212, 229);
            this.bangPhieuMuon.TabIndex = 0;
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.bangPhieuMuon);
            this.groupBoxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(1218, 248);
            this.groupBoxList.TabIndex = 0;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Danh sách phiếu mượn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày mượn đến";
            // 
            // dtpNgayTraDuKien
            // 
            this.dtpNgayTraDuKien.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTraDuKien.Location = new System.Drawing.Point(610, 25);
            this.dtpNgayTraDuKien.Name = "dtpNgayTraDuKien";
            this.dtpNgayTraDuKien.Size = new System.Drawing.Size(130, 20);
            this.dtpNgayTraDuKien.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Trạng thái";
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa trả",
            "Đã trả",
            "Trả muộn"});
            this.cmbTrangThai.Location = new System.Drawing.Point(110, 61);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(150, 21);
            this.cmbTrangThai.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mã độc giả";
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.Location = new System.Drawing.Point(360, 61);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.Size = new System.Drawing.Size(130, 20);
            this.txtMaDocGia.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã nhân viên";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(610, 61);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(130, 20);
            this.txtMaNhanVien.TabIndex = 11;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Location = new System.Drawing.Point(914, 22);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 25);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(6, 156);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxList);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxDetails);
            this.splitContainerMain.Size = new System.Drawing.Size(1218, 584);
            this.splitContainerMain.SplitterDistance = 248;
            this.splitContainerMain.TabIndex = 5;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInfo.Controls.Add(this.button1);
            this.groupBoxInfo.Controls.Add(this.button2);
            this.groupBoxInfo.Controls.Add(this.btnClearFilters);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Controls.Add(this.txtMaPhieuMuon);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.dtpNgayMuon);
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.dtpNgayTraDuKien);
            this.groupBoxInfo.Controls.Add(this.label4);
            this.groupBoxInfo.Controls.Add(this.cmbTrangThai);
            this.groupBoxInfo.Controls.Add(this.label5);
            this.groupBoxInfo.Controls.Add(this.txtMaDocGia);
            this.groupBoxInfo.Controls.Add(this.label6);
            this.groupBoxInfo.Controls.Add(this.txtMaNhanVien);
            this.groupBoxInfo.Controls.Add(this.btnTimKiem);
            this.groupBoxInfo.Location = new System.Drawing.Point(6, 5);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(1218, 145);
            this.groupBoxInfo.TabIndex = 4;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Tìm kiếm phiếu mượn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1126, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Hủy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1045, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Trả sách";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ThemPhieuTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.addPhieuMuon);
            this.Controls.Add(this.groupBoxInfo);
            this.Name = "ThemPhieuTra";
            this.Size = new System.Drawing.Size(1230, 788);
            this.Load += new System.EventHandler(this.PhieuMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bangCTPhieuMuon)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bangPhieuMuon)).EndInit();
            this.groupBoxList.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addPhieuMuon;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPhieuMuon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.DataGridView bangCTPhieuMuon;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.DataGridView bangPhieuMuon;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayTraDuKien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaDocGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
