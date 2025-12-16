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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btn_resest = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btnMucPhat = new System.Windows.Forms.Button();
            this.cbbPhieuPhat = new System.Windows.Forms.ComboBox();
            this.DTP_end = new System.Windows.Forms.DateTimePicker();
            this.lb_dateEnd = new System.Windows.Forms.Label();
            this.DTP_begin = new System.Windows.Forms.DateTimePicker();
            this.lb_datebegin = new System.Windows.Forms.Label();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContentPhieuPhat = new System.Windows.Forms.Panel();
            this.dgvPhieuPhat = new QuanLyThuVien.GUI.CustomDataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.panelContentPhieuPhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btn_resest);
            this.panelTop.Controls.Add(this.btn_search);
            this.panelTop.Controls.Add(this.btnMucPhat);
            this.panelTop.Controls.Add(this.cbbPhieuPhat);
            this.panelTop.Controls.Add(this.DTP_end);
            this.panelTop.Controls.Add(this.lb_dateEnd);
            this.panelTop.Controls.Add(this.DTP_begin);
            this.panelTop.Controls.Add(this.lb_datebegin);
            this.panelTop.Controls.Add(this.tb_search);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelTop.Size = new System.Drawing.Size(1587, 100);
            this.panelTop.TabIndex = 0;
            // 
            // btn_resest
            // 
            this.btn_resest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btn_resest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_resest.ForeColor = System.Drawing.Color.White;
            this.btn_resest.Location = new System.Drawing.Point(215, 55);
            this.btn_resest.Name = "btn_resest";
            this.btn_resest.Size = new System.Drawing.Size(120, 35);
            this.btn_resest.TabIndex = 8;
            this.btn_resest.Text = "Làm mới";
            this.btn_resest.UseVisualStyleBackColor = false;
            this.btn_resest.Click += new System.EventHandler(this.btn_resest_Click);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(85, 55);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(120, 35);
            this.btn_search.TabIndex = 7;
            this.btn_search.Text = "Tìm kiếm";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btnMucPhat
            // 
            this.btnMucPhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnMucPhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMucPhat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMucPhat.ForeColor = System.Drawing.Color.White;
            this.btnMucPhat.Location = new System.Drawing.Point(1180, 12);
            this.btnMucPhat.Name = "btnMucPhat";
            this.btnMucPhat.Size = new System.Drawing.Size(120, 35);
            this.btnMucPhat.TabIndex = 9;
            this.btnMucPhat.Text = "Mức phạt";
            this.btnMucPhat.UseVisualStyleBackColor = false;
            this.btnMucPhat.Click += new System.EventHandler(this.btnMucPhat_Click);
            // 
            // cbbPhieuPhat
            // 
            this.cbbPhieuPhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPhieuPhat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbbPhieuPhat.FormattingEnabled = true;
            this.cbbPhieuPhat.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa đóng",
            "Đã đóng"});
            this.cbbPhieuPhat.Location = new System.Drawing.Point(850, 12);
            this.cbbPhieuPhat.Name = "cbbPhieuPhat";
            this.cbbPhieuPhat.Size = new System.Drawing.Size(150, 28);
            this.cbbPhieuPhat.TabIndex = 6;
            this.cbbPhieuPhat.SelectedIndexChanged += new System.EventHandler(this.cbbPhieuPhat_SelectedIndexChanged);
            // 
            // DTP_end
            // 
            this.DTP_end.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTP_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_end.Location = new System.Drawing.Point(680, 12);
            this.DTP_end.Name = "DTP_end";
            this.DTP_end.Size = new System.Drawing.Size(150, 27);
            this.DTP_end.TabIndex = 5;
            // 
            // lb_dateEnd
            // 
            this.lb_dateEnd.AutoSize = true;
            this.lb_dateEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lb_dateEnd.Location = new System.Drawing.Point(600, 15);
            this.lb_dateEnd.Name = "lb_dateEnd";
            this.lb_dateEnd.Size = new System.Drawing.Size(75, 20);
            this.lb_dateEnd.TabIndex = 4;
            this.lb_dateEnd.Text = "Đến ngày:";
            this.lb_dateEnd.Click += new System.EventHandler(this.lb_dateEnd_Click);
            // 
            // DTP_begin
            // 
            this.DTP_begin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTP_begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_begin.Location = new System.Drawing.Point(430, 12);
            this.DTP_begin.Name = "DTP_begin";
            this.DTP_begin.Size = new System.Drawing.Size(150, 27);
            this.DTP_begin.TabIndex = 3;
            this.DTP_begin.ValueChanged += new System.EventHandler(this.DTP_begin_ValueChanged);
            // 
            // lb_datebegin
            // 
            this.lb_datebegin.AutoSize = true;
            this.lb_datebegin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lb_datebegin.Location = new System.Drawing.Point(360, 15);
            this.lb_datebegin.Name = "lb_datebegin";
            this.lb_datebegin.Size = new System.Drawing.Size(65, 20);
            this.lb_datebegin.TabIndex = 2;
            this.lb_datebegin.Text = "Từ ngày:";
            // 
            // tb_search
            // 
            this.tb_search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_search.Location = new System.Drawing.Point(85, 12);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(250, 27);
            this.tb_search.TabIndex = 1;
            this.tb_search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm:";
            // 
            // panelContentPhieuPhat
            // 
            this.panelContentPhieuPhat.Controls.Add(this.dgvPhieuPhat);
            this.panelContentPhieuPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentPhieuPhat.Location = new System.Drawing.Point(0, 100);
            this.panelContentPhieuPhat.Name = "panelContentPhieuPhat";
            this.panelContentPhieuPhat.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.panelContentPhieuPhat.Size = new System.Drawing.Size(1587, 557);
            this.panelContentPhieuPhat.TabIndex = 1;
            // 
            // dgvPhieuPhat
            // 
            this.dgvPhieuPhat.AllowUserToAddRows = false;
            this.dgvPhieuPhat.AllowUserToDeleteRows = false;
            this.dgvPhieuPhat.AllowUserToResizeColumns = false;
            this.dgvPhieuPhat.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvPhieuPhat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhieuPhat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuPhat.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuPhat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhieuPhat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuPhat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhieuPhat.ColumnHeadersHeight = 40;
            this.dgvPhieuPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPhieuPhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTen,
            this.colTien,
            this.colNgayPhat,
            this.colTrangThai});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuPhat.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhieuPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuPhat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPhieuPhat.EnableHeadersVisualStyles = false;
            this.dgvPhieuPhat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPhieuPhat.Location = new System.Drawing.Point(15, 10);
            this.dgvPhieuPhat.MultiSelect = false;
            this.dgvPhieuPhat.Name = "dgvPhieuPhat";
            this.dgvPhieuPhat.ReadOnly = true;
            this.dgvPhieuPhat.RowHeadersVisible = false;
            this.dgvPhieuPhat.RowHeadersWidth = 51;
            this.dgvPhieuPhat.RowTemplate.Height = 35;
            this.dgvPhieuPhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuPhat.Size = new System.Drawing.Size(1557, 532);
            this.dgvPhieuPhat.TabIndex = 0;
            this.dgvPhieuPhat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuPhat_CellContentClick);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "MaPhieuPhat";
            this.colID.FillWeight = 60F;
            this.colID.HeaderText = "Mã";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colTen
            // 
            this.colTen.DataPropertyName = "TenDG";
            this.colTen.FillWeight = 130F;
            this.colTen.HeaderText = "Độc Giả";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            // 
            // colTien
            // 
            this.colTien.DataPropertyName = "tienPhat";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colTien.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTien.FillWeight = 80F;
            this.colTien.HeaderText = "Tiền Phạt";
            this.colTien.MinimumWidth = 6;
            this.colTien.Name = "colTien";
            this.colTien.ReadOnly = true;
            // 
            // colNgayPhat
            // 
            this.colNgayPhat.DataPropertyName = "NgayPhat";
            this.colNgayPhat.HeaderText = "Ngày Phạt";
            this.colNgayPhat.MinimumWidth = 6;
            this.colNgayPhat.Name = "colNgayPhat";
            this.colNgayPhat.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThaiText";
            this.colTrangThai.FillWeight = 90F;
            this.colTrangThai.HeaderText = "Trạng Thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // PhieuPhat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panelContentPhieuPhat);
            this.Controls.Add(this.panelTop);
            this.Name = "PhieuPhat";
            this.Size = new System.Drawing.Size(1587, 657);
            this.Load += new System.EventHandler(this.PhieuPhat_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContentPhieuPhat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuPhat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btn_resest;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btnMucPhat;
        private System.Windows.Forms.ComboBox cbbPhieuPhat;
        private System.Windows.Forms.DateTimePicker DTP_end;
        private System.Windows.Forms.Label lb_dateEnd;
        private System.Windows.Forms.DateTimePicker DTP_begin;
        private System.Windows.Forms.Label lb_datebegin;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContentPhieuPhat;
        private CustomDataGridView dgvPhieuPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}
