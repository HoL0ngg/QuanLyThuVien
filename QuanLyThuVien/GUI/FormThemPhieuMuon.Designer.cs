namespace QuanLyThuVien.GUI
{
    partial class FormThemPhieuMuon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.txtNgayMuon = new System.Windows.Forms.TextBox();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.dtpNgayTraDuKien = new System.Windows.Forms.DateTimePicker();
            this.groupTimSach = new System.Windows.Forms.GroupBox();
            this.dgvKetQuaSach = new System.Windows.Forms.DataGridView();
            this.btnTimSach = new System.Windows.Forms.Button();
            this.txtTuKhoaSach = new System.Windows.Forms.TextBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.groupChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupThongTin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupTimSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaSach)).BeginInit();
            this.groupChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupThongTin
            // 
            this.groupThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupThongTin.Controls.Add(this.tableLayoutPanel1);
            this.groupThongTin.Location = new System.Drawing.Point(3, 3);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(776, 70);
            this.groupThongTin.TabIndex = 0;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin phiếu mượn";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblNgayMuon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNgayMuon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNgayTra, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpNgayTraDuKien, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 45);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.AutoSize = true;
            this.lblNgayMuon.Location = new System.Drawing.Point(3, 0);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(61, 13);
            this.lblNgayMuon.TabIndex = 0;
            this.lblNgayMuon.Text = "Ngày mượn";
            // 
            // txtNgayMuon
            // 
            this.txtNgayMuon.Location = new System.Drawing.Point(93, 3);
            this.txtNgayMuon.Name = "txtNgayMuon";
            this.txtNgayMuon.ReadOnly = true;
            this.txtNgayMuon.Size = new System.Drawing.Size(283, 20);
            this.txtNgayMuon.TabIndex = 1;
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Location = new System.Drawing.Point(383, 0);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(65, 26);
            this.lblNgayTra.TabIndex = 2;
            this.lblNgayTra.Text = "Ngày trả dự kiến";
            // 
            // dtpNgayTraDuKien
            // 
            this.dtpNgayTraDuKien.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTraDuKien.Location = new System.Drawing.Point(473, 3);
            this.dtpNgayTraDuKien.Name = "dtpNgayTraDuKien";
            this.dtpNgayTraDuKien.Size = new System.Drawing.Size(285, 20);
            this.dtpNgayTraDuKien.TabIndex = 3;
            // 
            // groupTimSach
            // 
            this.groupTimSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTimSach.Controls.Add(this.dgvKetQuaSach);
            this.groupTimSach.Controls.Add(this.btnTimSach);
            this.groupTimSach.Controls.Add(this.txtTuKhoaSach);
            this.groupTimSach.Controls.Add(this.lblTuKhoa);
            this.groupTimSach.Location = new System.Drawing.Point(3, 79);
            this.groupTimSach.Name = "groupTimSach";
            this.groupTimSach.Size = new System.Drawing.Size(776, 180);
            this.groupTimSach.TabIndex = 1;
            this.groupTimSach.TabStop = false;
            this.groupTimSach.Text = "Tìm kiếm sách";
            // 
            // dgvKetQuaSach
            // 
            this.dgvKetQuaSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQuaSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQuaSach.Location = new System.Drawing.Point(9, 52);
            this.dgvKetQuaSach.Name = "dgvKetQuaSach";
            this.dgvKetQuaSach.Size = new System.Drawing.Size(758, 120);
            this.dgvKetQuaSach.TabIndex = 3;
            // 
            // btnTimSach
            // 
            this.btnTimSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimSach.Location = new System.Drawing.Point(692, 19);
            this.btnTimSach.Name = "btnTimSach";
            this.btnTimSach.Size = new System.Drawing.Size(75, 23);
            this.btnTimSach.TabIndex = 2;
            this.btnTimSach.Text = "Tìm";
            this.btnTimSach.UseVisualStyleBackColor = true;
            this.btnTimSach.Click += new System.EventHandler(this.btnTimSach_Click_1);
            // 
            // txtTuKhoaSach
            // 
            this.txtTuKhoaSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTuKhoaSach.Location = new System.Drawing.Point(74, 21);
            this.txtTuKhoaSach.Name = "txtTuKhoaSach";
            this.txtTuKhoaSach.Size = new System.Drawing.Size(612, 20);
            this.txtTuKhoaSach.TabIndex = 1;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(6, 24);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(47, 13);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Từ khóa";
            // 
            // groupChiTiet
            // 
            this.groupChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupChiTiet.Controls.Add(this.dgvCT);
            this.groupChiTiet.Location = new System.Drawing.Point(3, 265);
            this.groupChiTiet.Name = "groupChiTiet";
            this.groupChiTiet.Size = new System.Drawing.Size(776, 257);
            this.groupChiTiet.TabIndex = 2;
            this.groupChiTiet.TabStop = false;
            this.groupChiTiet.Text = "Chi tiết sách mượn";
            // 
            // dgvCT
            // 
            this.dgvCT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCT.Location = new System.Drawing.Point(6, 19);
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.Size = new System.Drawing.Size(764, 232);
            this.dgvCT.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Controls.Add(this.btnHuy);
            this.panelBottom.Controls.Add(this.btnThem);
            this.panelBottom.Location = new System.Drawing.Point(3, 528);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(776, 40);
            this.panelBottom.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Location = new System.Drawing.Point(691, 8);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 25);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(610, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // FormThemPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.groupChiTiet);
            this.Controls.Add(this.groupTimSach);
            this.Controls.Add(this.groupThongTin);
            this.Name = "FormThemPhieuMuon";
            this.Size = new System.Drawing.Size(782, 571);
            this.groupThongTin.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupTimSach.ResumeLayout(false);
            this.groupTimSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaSach)).EndInit();
            this.groupChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.TextBox txtNgayMuon;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.DateTimePicker dtpNgayTraDuKien;
        private System.Windows.Forms.GroupBox groupTimSach;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoaSach;
        private System.Windows.Forms.Button btnTimSach;
        private System.Windows.Forms.DataGridView dgvKetQuaSach;
        private System.Windows.Forms.GroupBox groupChiTiet;
        private System.Windows.Forms.DataGridView dgvCT;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
    }
}
