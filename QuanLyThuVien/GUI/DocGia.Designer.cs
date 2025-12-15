namespace QuanLyThuVien.GUI
{
    partial class DocGia
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblMaDGSearch;
        private System.Windows.Forms.TextBox txtMaDGSearch;
        private System.Windows.Forms.Label lblTenDGSearch;
        private System.Windows.Forms.TextBox txtTenDGSearch;
        private System.Windows.Forms.Label lblSDTSearch;
        private System.Windows.Forms.TextBox txtSDTSearch;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.GroupBox grpThongTinDocGia; // mới: thay cho label

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDocGia = new QuanLyThuVien.GUI.CustomDataGridView();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.btnClearFilters = new QuanLyThuVien.GUI.Components.CustomButton("Xóa lọc", "red");
            this.lblMaDGSearch = new System.Windows.Forms.Label();
            this.txtMaDGSearch = new System.Windows.Forms.TextBox();
            this.lblTenDGSearch = new System.Windows.Forms.Label();
            this.txtTenDGSearch = new System.Windows.Forms.TextBox();
            this.lblSDTSearch = new System.Windows.Forms.Label();
            this.txtSDTSearch = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new QuanLyThuVien.GUI.Components.CustomButton("Tìm kiếm", "blue");
            this.grpThongTinDocGia = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.grpTimKiem.SuspendLayout();
            this.grpThongTinDocGia.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.AllowUserToAddRows = false;
            this.dgvDocGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvDocGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocGia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocGia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDocGia.EnableHeadersVisualStyles = false;
            this.dgvDocGia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDocGia.Location = new System.Drawing.Point(3, 16);
            this.dgvDocGia.MultiSelect = false;
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.ReadOnly = true;
            this.dgvDocGia.RowHeadersVisible = false;
            this.dgvDocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocGia.Size = new System.Drawing.Size(788, 387);
            this.dgvDocGia.TabIndex = 0;
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTimKiem.Controls.Add(this.btnClearFilters);
            this.grpTimKiem.Controls.Add(this.lblMaDGSearch);
            this.grpTimKiem.Controls.Add(this.txtMaDGSearch);
            this.grpTimKiem.Controls.Add(this.lblTenDGSearch);
            this.grpTimKiem.Controls.Add(this.txtTenDGSearch);
            this.grpTimKiem.Controls.Add(this.lblSDTSearch);
            this.grpTimKiem.Controls.Add(this.txtSDTSearch);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Location = new System.Drawing.Point(3, 3);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(794, 55);
            this.grpTimKiem.TabIndex = 0;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm độc giả";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.Location = new System.Drawing.Point(716, 19);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(70, 23);
            this.btnClearFilters.TabIndex = 7;
            this.btnClearFilters.Text = "Xóa lọc";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // lblMaDGSearch
            // 
            this.lblMaDGSearch.AutoSize = true;
            this.lblMaDGSearch.Location = new System.Drawing.Point(15, 24);
            this.lblMaDGSearch.Name = "lblMaDGSearch";
            this.lblMaDGSearch.Size = new System.Drawing.Size(41, 13);
            this.lblMaDGSearch.TabIndex = 0;
            this.lblMaDGSearch.Text = "Mã DG";
            // 
            // txtMaDGSearch
            // 
            this.txtMaDGSearch.Location = new System.Drawing.Point(60, 21);
            this.txtMaDGSearch.Name = "txtMaDGSearch";
            this.txtMaDGSearch.Size = new System.Drawing.Size(70, 20);
            this.txtMaDGSearch.TabIndex = 1;
            // 
            // lblTenDGSearch
            // 
            this.lblTenDGSearch.AutoSize = true;
            this.lblTenDGSearch.Location = new System.Drawing.Point(140, 24);
            this.lblTenDGSearch.Name = "lblTenDGSearch";
            this.lblTenDGSearch.Size = new System.Drawing.Size(45, 13);
            this.lblTenDGSearch.TabIndex = 2;
            this.lblTenDGSearch.Text = "Tên DG";
            // 
            // txtTenDGSearch
            // 
            this.txtTenDGSearch.Location = new System.Drawing.Point(185, 21);
            this.txtTenDGSearch.Name = "txtTenDGSearch";
            this.txtTenDGSearch.Size = new System.Drawing.Size(165, 20);
            this.txtTenDGSearch.TabIndex = 3;
            // 
            // lblSDTSearch
            // 
            this.lblSDTSearch.AutoSize = true;
            this.lblSDTSearch.Location = new System.Drawing.Point(360, 24);
            this.lblSDTSearch.Name = "lblSDTSearch";
            this.lblSDTSearch.Size = new System.Drawing.Size(29, 13);
            this.lblSDTSearch.TabIndex = 4;
            this.lblSDTSearch.Text = "SĐT";
            // 
            // txtSDTSearch
            // 
            this.txtSDTSearch.Location = new System.Drawing.Point(395, 21);
            this.txtSDTSearch.Name = "txtSDTSearch";
            this.txtSDTSearch.Size = new System.Drawing.Size(110, 20);
            this.txtSDTSearch.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Location = new System.Drawing.Point(640, 19);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(70, 23);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // grpThongTinDocGia
            // 
            this.grpThongTinDocGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongTinDocGia.Controls.Add(this.dgvDocGia);
            this.grpThongTinDocGia.Location = new System.Drawing.Point(3, 64);
            this.grpThongTinDocGia.Name = "grpThongTinDocGia";
            this.grpThongTinDocGia.Size = new System.Drawing.Size(794, 406);
            this.grpThongTinDocGia.TabIndex = 1;
            this.grpThongTinDocGia.TabStop = false;
            this.grpThongTinDocGia.Text = "Thông tin độc giả";
            // 
            // DocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpThongTinDocGia);
            this.Controls.Add(this.grpTimKiem);
            this.Name = "DocGia";
            this.Size = new System.Drawing.Size(800, 473);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpThongTinDocGia.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private CustomDataGridView dgvDocGia;
    }
}
