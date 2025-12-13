namespace QuanLyThuVien.GUI
{
    partial class PhieuMuon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.bangPhieuMuon = new QuanLyThuVien.GUI.CustomDataGridView();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.bangCTPhieuMuon = new QuanLyThuVien.GUI.CustomDataGridView();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.btnClearFilters = new QuanLyThuVien.GUI.Components.CustomButton("Xóa tất cả bộ lọc", "red");
            this.btnTimKiem = new QuanLyThuVien.GUI.Components.CustomButton("Tìm kiếm", "blue");
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayTraDuKien = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaDocGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.addPhieuMuon = new QuanLyThuVien.GUI.Components.CustomButton(" Thêm Phiếu Mượn", "green");
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bangPhieuMuon)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bangCTPhieuMuon)).BeginInit();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(6, 157);
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
            this.splitContainerMain.Size = new System.Drawing.Size(1196, 590);
            this.splitContainerMain.SplitterDistance = 286;
            this.splitContainerMain.TabIndex = 2;
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.bangPhieuMuon);
            this.groupBoxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(1196, 286);
            this.groupBoxList.TabIndex = 0;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Danh sách phiếu mượn";
            // 
            // bangPhieuMuon
            // 
            this.bangPhieuMuon.AllowUserToAddRows = false;
            this.bangPhieuMuon.AllowUserToDeleteRows = false;
            this.bangPhieuMuon.AllowUserToResizeColumns = false;
            this.bangPhieuMuon.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.bangPhieuMuon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bangPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bangPhieuMuon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bangPhieuMuon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bangPhieuMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bangPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bangPhieuMuon.DefaultCellStyle = dataGridViewCellStyle3;
            this.bangPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bangPhieuMuon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.bangPhieuMuon.EnableHeadersVisualStyles = false;
            this.bangPhieuMuon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bangPhieuMuon.Location = new System.Drawing.Point(3, 16);
            this.bangPhieuMuon.MultiSelect = false;
            this.bangPhieuMuon.Name = "bangPhieuMuon";
            this.bangPhieuMuon.ReadOnly = true;
            this.bangPhieuMuon.RowHeadersVisible = false;
            this.bangPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bangPhieuMuon.Size = new System.Drawing.Size(1190, 267);
            this.bangPhieuMuon.TabIndex = 0;
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.bangCTPhieuMuon);
            this.groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(1196, 300);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Chi tiết phiếu mượn";
            // 
            // bangCTPhieuMuon
            // 
            this.bangCTPhieuMuon.AllowUserToAddRows = false;
            this.bangCTPhieuMuon.AllowUserToDeleteRows = false;
            this.bangCTPhieuMuon.AllowUserToResizeColumns = false;
            this.bangCTPhieuMuon.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.bangCTPhieuMuon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bangCTPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bangCTPhieuMuon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bangCTPhieuMuon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bangCTPhieuMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.bangCTPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bangCTPhieuMuon.DefaultCellStyle = dataGridViewCellStyle6;
            this.bangCTPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bangCTPhieuMuon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.bangCTPhieuMuon.EnableHeadersVisualStyles = false;
            this.bangCTPhieuMuon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bangCTPhieuMuon.Location = new System.Drawing.Point(3, 16);
            this.bangCTPhieuMuon.MultiSelect = false;
            this.bangCTPhieuMuon.Name = "bangCTPhieuMuon";
            this.bangCTPhieuMuon.ReadOnly = true;
            this.bangCTPhieuMuon.RowHeadersVisible = false;
            this.bangCTPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bangCTPhieuMuon.Size = new System.Drawing.Size(1190, 281);
            this.bangCTPhieuMuon.TabIndex = 0;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBoxInfo.Location = new System.Drawing.Point(6, 6);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(1196, 99);
            this.groupBoxInfo.TabIndex = 1;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Tìm kiếm phiếu mượn";
            this.groupBoxInfo.Enter += new System.EventHandler(this.GroupBoxInfo_Enter);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(1011, 22);
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
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1011, 58);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 25);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.BtnTimKiem_Click);
            // 
            // addPhieuMuon
            // 
            this.addPhieuMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.addPhieuMuon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addPhieuMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.addPhieuMuon.ForeColor = System.Drawing.Color.White;
            this.addPhieuMuon.Location = new System.Drawing.Point(6, 157);
            this.addPhieuMuon.Name = "addPhieuMuon";
            this.addPhieuMuon.Size = new System.Drawing.Size(130, 25);
            this.addPhieuMuon.TabIndex = 3;
            this.addPhieuMuon.Text = " Thêm Phiếu Mượn";
            this.addPhieuMuon.UseVisualStyleBackColor = true;
            this.addPhieuMuon.Click += new System.EventHandler(this.Button1_Click);
            // 
            // PhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.addPhieuMuon);
            this.Name = "PhieuMuon";
            this.Size = new System.Drawing.Size(1208, 750);
            this.Load += new System.EventHandler(this.PhieuMuon_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bangPhieuMuon)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bangCTPhieuMuon)).EndInit();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPhieuMuon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayTraDuKien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaDocGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private CustomDataGridView bangPhieuMuon;
        private CustomDataGridView bangCTPhieuMuon;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button addPhieuMuon;
    }
}
