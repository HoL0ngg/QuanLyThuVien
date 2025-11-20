namespace QuanLyThuVien.GUI
{
    partial class PhieuPhat
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
            this.btn_search = new System.Windows.Forms.Button();
            this.DTP_end = new System.Windows.Forms.DateTimePicker();
            this.lb_dateEnd = new System.Windows.Forms.Label();
            this.DTP_begin = new System.Windows.Forms.DateTimePicker();
            this.lb_datebegin = new System.Windows.Forms.Label();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbPhieuPhat = new System.Windows.Forms.ComboBox();
            this.btn_resest = new System.Windows.Forms.Button();
            this.panelContentPhieuPhat = new System.Windows.Forms.Panel();
            this.dgvPhieuPhat = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseModuleUC1 = new QuanLyThuVien.GUI.BaseModuleUC();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelContentPhieuPhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(15, 67);
            this.btn_search.Margin = new System.Windows.Forms.Padding(0, 15, 0, 10);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Tìm Kiếm";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // DTP_end
            // 
            this.DTP_end.Location = new System.Drawing.Point(667, 23);
            this.DTP_end.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.DTP_end.Name = "DTP_end";
            this.DTP_end.Size = new System.Drawing.Size(200, 22);
            this.DTP_end.TabIndex = 3;
            // 
            // lb_dateEnd
            // 
            this.lb_dateEnd.AutoSize = true;
            this.lb_dateEnd.Location = new System.Drawing.Point(611, 26);
            this.lb_dateEnd.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.lb_dateEnd.Name = "lb_dateEnd";
            this.lb_dateEnd.Size = new System.Drawing.Size(59, 16);
            this.lb_dateEnd.TabIndex = 5;
            this.lb_dateEnd.Text = "Kết Thúc";
            this.lb_dateEnd.Click += new System.EventHandler(this.lb_dateEnd_Click);
            // 
            // DTP_begin
            // 
            this.DTP_begin.Location = new System.Drawing.Point(398, 21);
            this.DTP_begin.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.DTP_begin.Name = "DTP_begin";
            this.DTP_begin.Size = new System.Drawing.Size(200, 22);
            this.DTP_begin.TabIndex = 2;
            this.DTP_begin.ValueChanged += new System.EventHandler(this.DTP_begin_ValueChanged);
            // 
            // lb_datebegin
            // 
            this.lb_datebegin.AutoSize = true;
            this.lb_datebegin.Location = new System.Drawing.Point(339, 23);
            this.lb_datebegin.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.lb_datebegin.Name = "lb_datebegin";
            this.lb_datebegin.Size = new System.Drawing.Size(54, 16);
            this.lb_datebegin.TabIndex = 4;
            this.lb_datebegin.Text = "Bắt Đầu";
            // 
            // tb_search
            // 
            this.tb_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_search.Location = new System.Drawing.Point(100, 20);
            this.tb_search.Margin = new System.Windows.Forms.Padding(15);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(290, 22);
            this.tb_search.TabIndex = 0;
            this.tb_search.Click += new System.EventHandler(this.btn);
            this.tb_search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbPhieuPhat);
            this.panel1.Controls.Add(this.tb_search);
            this.panel1.Controls.Add(this.DTP_begin);
            this.panel1.Controls.Add(this.btn_resest);
            this.panel1.Controls.Add(this.lb_datebegin);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.DTP_end);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lb_dateEnd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 93);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cbbPhieuPhat
            // 
            this.cbbPhieuPhat.FormattingEnabled = true;
            this.cbbPhieuPhat.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa đóng",
            "Đã đóng"});
            this.cbbPhieuPhat.Location = new System.Drawing.Point(888, 20);
            this.cbbPhieuPhat.Name = "cbbPhieuPhat";
            this.cbbPhieuPhat.Size = new System.Drawing.Size(121, 24);
            this.cbbPhieuPhat.TabIndex = 6;
            this.cbbPhieuPhat.Text = "Tất cả";
            this.cbbPhieuPhat.SelectedIndexChanged += new System.EventHandler(this.cbbPhieuPhat_SelectedIndexChanged);
            // 
            // btn_resest
            // 
            this.btn_resest.Location = new System.Drawing.Point(102, 68);
            this.btn_resest.Margin = new System.Windows.Forms.Padding(0, 15, 0, 10);
            this.btn_resest.Name = "btn_resest";
            this.btn_resest.Size = new System.Drawing.Size(75, 23);
            this.btn_resest.TabIndex = 1;
            this.btn_resest.Text = "Làm Mới";
            this.btn_resest.UseVisualStyleBackColor = true;
            this.btn_resest.Click += new System.EventHandler(this.btn_resest_Click);
            // 
            // panelContentPhieuPhat
            // 
            this.panelContentPhieuPhat.Controls.Add(this.dgvPhieuPhat);
            this.panelContentPhieuPhat.Location = new System.Drawing.Point(0, 99);
            this.panelContentPhieuPhat.Name = "panelContentPhieuPhat";
            this.panelContentPhieuPhat.Size = new System.Drawing.Size(1139, 626);
            this.panelContentPhieuPhat.TabIndex = 3;
            // 
            // dgvPhieuPhat
            // 
            this.dgvPhieuPhat.AllowUserToAddRows = false;
            this.dgvPhieuPhat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuPhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTen,
            this.colTien,
            this.colNgayPhat,
            this.colDG,
            this.colTrangThai});
            this.dgvPhieuPhat.Location = new System.Drawing.Point(26, 7);
            this.dgvPhieuPhat.Name = "dgvPhieuPhat";
            this.dgvPhieuPhat.ReadOnly = true;
            this.dgvPhieuPhat.RowHeadersWidth = 51;
            this.dgvPhieuPhat.RowTemplate.Height = 24;
            this.dgvPhieuPhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuPhat.Size = new System.Drawing.Size(1096, 591);
            this.dgvPhieuPhat.TabIndex = 0;
            this.dgvPhieuPhat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuPhat_CellContentClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "Mã";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colTen
            // 
            this.colTen.HeaderText = "Tên";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            // 
            // colTien
            // 
            this.colTien.HeaderText = "Tiền Phạt";
            this.colTien.MinimumWidth = 6;
            this.colTien.Name = "colTien";
            this.colTien.ReadOnly = true;
            // 
            // colNgayPhat
            // 
            this.colNgayPhat.HeaderText = "Ngày Phạt";
            this.colNgayPhat.MinimumWidth = 6;
            this.colNgayPhat.Name = "colNgayPhat";
            this.colNgayPhat.ReadOnly = true;
            // 
            // colDG
            // 
            this.colDG.HeaderText = "Độc Giả";
            this.colDG.MinimumWidth = 6;
            this.colDG.Name = "colDG";
            this.colDG.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng Thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // baseModuleUC1
            // 
            this.baseModuleUC1.Location = new System.Drawing.Point(0, 0);
            this.baseModuleUC1.Name = "baseModuleUC1";
            this.baseModuleUC1.Size = new System.Drawing.Size(150, 150);
            this.baseModuleUC1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tìm Kiếm";
            this.label1.Click += new System.EventHandler(this.lb_dateEnd_Click);
            // 
            // PhieuPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContentPhieuPhat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.baseModuleUC1);
            this.Name = "PhieuPhat";
            this.Size = new System.Drawing.Size(1142, 725);
            this.Load += new System.EventHandler(this.PhieuPhat_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelContentPhieuPhat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuPhat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseModuleUC baseModuleUC1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker DTP_end;
        private System.Windows.Forms.Label lb_dateEnd;
        private System.Windows.Forms.DateTimePicker DTP_begin;
        private System.Windows.Forms.Label lb_datebegin;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelContentPhieuPhat;
        private System.Windows.Forms.DataGridView dgvPhieuPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.Button btn_resest;
        private System.Windows.Forms.ComboBox cbbPhieuPhat;
        private System.Windows.Forms.Label label1;
    }
}
