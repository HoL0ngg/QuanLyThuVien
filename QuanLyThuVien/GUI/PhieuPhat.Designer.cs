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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbPhieuPhat = new System.Windows.Forms.ComboBox();
            this.panelContentPhieuPhat = new System.Windows.Forms.Panel();
            this.dgvPhieuPhat = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseModuleUC1 = new QuanLyThuVien.GUI.BaseModuleUC();
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
            this.DTP_end.Location = new System.Drawing.Point(671, 23);
            this.DTP_end.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.DTP_end.Name = "DTP_end";
            this.DTP_end.Size = new System.Drawing.Size(200, 22);
            this.DTP_end.TabIndex = 3;
            // 
            // lb_dateEnd
            // 
            this.lb_dateEnd.AutoSize = true;
            this.lb_dateEnd.Location = new System.Drawing.Point(602, 26);
            this.lb_dateEnd.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.lb_dateEnd.Name = "lb_dateEnd";
            this.lb_dateEnd.Size = new System.Drawing.Size(59, 16);
            this.lb_dateEnd.TabIndex = 5;
            this.lb_dateEnd.Text = "ThúcKết ";
            // 
            // DTP_begin
            // 
            this.DTP_begin.Location = new System.Drawing.Point(392, 21);
            this.DTP_begin.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.DTP_begin.Name = "DTP_begin";
            this.DTP_begin.Size = new System.Drawing.Size(200, 22);
            this.DTP_begin.TabIndex = 2;
            // 
            // lb_datebegin
            // 
            this.lb_datebegin.AutoSize = true;
            this.lb_datebegin.Location = new System.Drawing.Point(328, 23);
            this.lb_datebegin.Margin = new System.Windows.Forms.Padding(10, 15, 0, 10);
            this.lb_datebegin.Name = "lb_datebegin";
            this.lb_datebegin.Size = new System.Drawing.Size(54, 16);
            this.lb_datebegin.TabIndex = 4;
            this.lb_datebegin.Text = "Bắt Đầu";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(15, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Tìm Kiếm..";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbPhieuPhat);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.DTP_begin);
            this.panel1.Controls.Add(this.lb_datebegin);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.DTP_end);
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
            this.cbbPhieuPhat.Location = new System.Drawing.Point(914, 20);
            this.cbbPhieuPhat.Name = "cbbPhieuPhat";
            this.cbbPhieuPhat.Size = new System.Drawing.Size(121, 24);
            this.cbbPhieuPhat.TabIndex = 6;
            this.cbbPhieuPhat.Text = "Tất cả";
            this.cbbPhieuPhat.SelectedIndexChanged += new System.EventHandler(this.cbbPhieuPhat_SelectedIndexChanged);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbbPhieuPhat;
        private System.Windows.Forms.Panel panelContentPhieuPhat;
        private System.Windows.Forms.DataGridView dgvPhieuPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}
