namespace QuanLyThuVien.GUI
{
    partial class DocGia
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDocGia;
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
            this.dgvDocGia = new QuanLyThuVien.GUI.CustomDataGridView();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblMaDGSearch = new System.Windows.Forms.Label();
            this.txtMaDGSearch = new System.Windows.Forms.TextBox();
            this.lblTenDGSearch = new System.Windows.Forms.Label();
            this.txtTenDGSearch = new System.Windows.Forms.TextBox();
            this.lblSDTSearch = new System.Windows.Forms.Label();
            this.txtSDTSearch = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.grpThongTinDocGia = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.grpTimKiem.SuspendLayout();
            this.grpThongTinDocGia.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocGia.Location = new System.Drawing.Point(3, 16);
            this.dgvDocGia.Name = "dgvDocGia";
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
    }
}
