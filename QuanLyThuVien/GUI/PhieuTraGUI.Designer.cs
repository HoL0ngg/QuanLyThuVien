namespace QuanLyThuVien.GUI
{
    partial class PhieuTraGUI
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dgvPhieuTra = new System.Windows.Forms.DataGridView();
            this.colMaPhieuTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaPhieuMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxForm = new System.Windows.Forms.GroupBox();
            this.lblTongTienPhat = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colMaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoNgayTre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelForm = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTimSach = new System.Windows.Forms.Button();
            this.cboPhieuMuon = new System.Windows.Forms.ComboBox();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.lblPhieuMuon = new System.Windows.Forms.Label();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTra)).BeginInit();
            this.groupBoxForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1043, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ PHIẾU TRẢ";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxList);
            this.panelMain.Controls.Add(this.groupBoxForm);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(1043, 668);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dgvPhieuTra);
            this.groupBoxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxList.Location = new System.Drawing.Point(10, 10);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(1023, 288);
            this.groupBoxList.TabIndex = 0;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Danh sách phiếu trả";
            // 
            // dgvPhieuTra
            // 
            this.dgvPhieuTra.AllowUserToAddRows = false;
            this.dgvPhieuTra.AllowUserToDeleteRows = false;
            this.dgvPhieuTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaPhieuTra,
            this.colNgayTra,
            this.colMaPhieuMuon,
            this.colTenNV,
            this.colTenDG});
            this.dgvPhieuTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuTra.Location = new System.Drawing.Point(3, 22);
            this.dgvPhieuTra.Name = "dgvPhieuTra";
            this.dgvPhieuTra.ReadOnly = true;
            this.dgvPhieuTra.RowHeadersWidth = 51;
            this.dgvPhieuTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuTra.Size = new System.Drawing.Size(1017, 263);
            this.dgvPhieuTra.TabIndex = 0;
            this.dgvPhieuTra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuTra_CellClick);
            // 
            // colMaPhieuTra
            // 
            this.colMaPhieuTra.DataPropertyName = "MaPhieuTra";
            this.colMaPhieuTra.HeaderText = "Mã phiếu trả";
            this.colMaPhieuTra.Name = "colMaPhieuTra";
            this.colMaPhieuTra.ReadOnly = true;
            // 
            // colNgayTra
            // 
            this.colNgayTra.DataPropertyName = "NgayTra";
            this.colNgayTra.HeaderText = "Ngày trả";
            this.colNgayTra.Name = "colNgayTra";
            this.colNgayTra.ReadOnly = true;
            // 
            // colMaPhieuMuon
            // 
            this.colMaPhieuMuon.DataPropertyName = "MaDG";
            this.colMaPhieuMuon.HeaderText = "Mã phiếu mượn";
            this.colMaPhieuMuon.Name = "colMaPhieuMuon";
            this.colMaPhieuMuon.ReadOnly = true;
            // 
            // colTenNV
            // 
            this.colTenNV.HeaderText = "Nhân viên";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.ReadOnly = true;
            // 
            // colTenDG
            // 
            this.colTenDG.HeaderText = "Độc giả";
            this.colTenDG.Name = "colTenDG";
            this.colTenDG.ReadOnly = true;
            // 
            // groupBoxForm
            // 
            this.groupBoxForm.Controls.Add(this.lblTongTienPhat);
            this.groupBoxForm.Controls.Add(this.dgvChiTiet);
            this.groupBoxForm.Controls.Add(this.panelForm);
            this.groupBoxForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxForm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxForm.Location = new System.Drawing.Point(10, 298);
            this.groupBoxForm.Name = "groupBoxForm";
            this.groupBoxForm.Size = new System.Drawing.Size(1023, 360);
            this.groupBoxForm.TabIndex = 1;
            this.groupBoxForm.TabStop = false;
            this.groupBoxForm.Text = "Thông tin phiếu trả";
            // 
            // lblTongTienPhat
            // 
            this.lblTongTienPhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienPhat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTienPhat.ForeColor = System.Drawing.Color.Red;
            this.lblTongTienPhat.Location = new System.Drawing.Point(720, 320);
            this.lblTongTienPhat.Name = "lblTongTienPhat";
            this.lblTongTienPhat.Size = new System.Drawing.Size(297, 30);
            this.lblTongTienPhat.TabIndex = 2;
            this.lblTongTienPhat.Text = "Tổng tiền phạt: 0 VNĐ";
            this.lblTongTienPhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSach,
            this.colTenSach,
            this.colNgayMuon,
            this.colSoNgayTre,
            this.colTienPhat});
            this.dgvChiTiet.Location = new System.Drawing.Point(3, 125);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1014, 185);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // colMaSach
            // 
            this.colMaSach.DataPropertyName = "MaSach";
            this.colMaSach.HeaderText = "Mã sách";
            this.colMaSach.Name = "colMaSach";
            this.colMaSach.ReadOnly = true;
            // 
            // colTenSach
            // 
            this.colTenSach.DataPropertyName = "TenSach";
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.Name = "colTenSach";
            this.colTenSach.ReadOnly = true;
            // 
            // colNgayMuon
            // 
            this.colNgayMuon.DataPropertyName = "NgayMuon";
            this.colNgayMuon.HeaderText = "Ngày mượn";
            this.colNgayMuon.Name = "colNgayMuon";
            this.colNgayMuon.ReadOnly = true;
            // 
            // colSoNgayTre
            // 
            this.colSoNgayTre.DataPropertyName = "SoNgayTre";
            this.colSoNgayTre.HeaderText = "Số ngày trễ";
            this.colSoNgayTre.Name = "colSoNgayTre";
            this.colSoNgayTre.ReadOnly = true;
            // 
            // colTienPhat
            // 
            this.colTienPhat.DataPropertyName = "TienPhat";
            this.colTienPhat.HeaderText = "Tiền phạt";
            this.colTienPhat.Name = "colTienPhat";
            this.colTienPhat.ReadOnly = true;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.btnLamMoi);
            this.panelForm.Controls.Add(this.btnXoa);
            this.panelForm.Controls.Add(this.btnThem);
            this.panelForm.Controls.Add(this.btnTimSach);
            this.panelForm.Controls.Add(this.cboPhieuMuon);
            this.panelForm.Controls.Add(this.dtpNgayTra);
            this.panelForm.Controls.Add(this.lblPhieuMuon);
            this.panelForm.Controls.Add(this.lblNgayTra);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(3, 22);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1017, 100);
            this.panelForm.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(560, 55);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(454, 55);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(348, 55);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTimSach
            // 
            this.btnTimSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnTimSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimSach.ForeColor = System.Drawing.Color.White;
            this.btnTimSach.Location = new System.Drawing.Point(560, 10);
            this.btnTimSach.Name = "btnTimSach";
            this.btnTimSach.Size = new System.Drawing.Size(100, 32);
            this.btnTimSach.TabIndex = 4;
            this.btnTimSach.Text = "Tìm sách";
            this.btnTimSach.UseVisualStyleBackColor = false;
            this.btnTimSach.Click += new System.EventHandler(this.btnTimSach_Click);
            // 
            // cboPhieuMuon
            // 
            this.cboPhieuMuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhieuMuon.FormattingEnabled = true;
            this.cboPhieuMuon.Location = new System.Drawing.Point(135, 11);
            this.cboPhieuMuon.Name = "cboPhieuMuon";
            this.cboPhieuMuon.Size = new System.Drawing.Size(400, 25);
            this.cboPhieuMuon.TabIndex = 3;
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTra.Location = new System.Drawing.Point(810, 11);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(180, 25);
            this.dtpNgayTra.TabIndex = 2;
            // 
            // lblPhieuMuon
            // 
            this.lblPhieuMuon.AutoSize = true;
            this.lblPhieuMuon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhieuMuon.Location = new System.Drawing.Point(20, 14);
            this.lblPhieuMuon.Name = "lblPhieuMuon";
            this.lblPhieuMuon.Size = new System.Drawing.Size(93, 19);
            this.lblPhieuMuon.TabIndex = 1;
            this.lblPhieuMuon.Text = "Phiếu mượn:";
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayTra.Location = new System.Drawing.Point(730, 14);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(68, 19);
            this.lblNgayTra.TabIndex = 0;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // PhieuTraGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Name = "PhieuTraGUI";
            this.Size = new System.Drawing.Size(1043, 728);
            this.Load += new System.EventHandler(this.PhieuTraGUI_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTra)).EndInit();
            this.groupBoxForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvPhieuTra;
        private System.Windows.Forms.GroupBox groupBoxForm;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblPhieuMuon;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.ComboBox cboPhieuMuon;
        private System.Windows.Forms.Button btnTimSach;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTongTienPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPhieuTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPhieuMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoNgayTre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienPhat;
    }
}
