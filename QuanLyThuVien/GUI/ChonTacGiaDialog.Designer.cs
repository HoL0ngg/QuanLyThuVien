namespace QuanLyThuVien.GUI
{
    partial class ChonTacGiaDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiemTacGia = new System.Windows.Forms.TextBox();
            this.btnTacGiaMoi = new System.Windows.Forms.Button();
            this.dgvTatCaTacGia = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTatCaTacGia)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.txtTimKiemTacGia);
            this.panelTop.Controls.Add(this.btnTacGiaMoi);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 56;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            // 
            // txtTimKiemTacGia
            // 
            // Reduce width and anchor to prevent overlap with the button
            this.txtTimKiemTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimKiemTacGia.Location = new System.Drawing.Point(90, 15);
            this.txtTimKiemTacGia.Name = "txtTimKiemTacGia";
            this.txtTimKiemTacGia.Size = new System.Drawing.Size(300, 22);
            this.txtTimKiemTacGia.TabIndex = 1;
            this.txtTimKiemTacGia.TextChanged += new System.EventHandler(this.txtTimKiemTacGia_TextChanged);
            // 
            // btnTacGiaMoi
            // 
            this.btnTacGiaMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTacGiaMoi.Location = new System.Drawing.Point(410, 12);
            this.btnTacGiaMoi.Name = "btnTacGiaMoi";
            this.btnTacGiaMoi.Size = new System.Drawing.Size(100, 28);
            this.btnTacGiaMoi.TabIndex = 2;
            this.btnTacGiaMoi.Text = "Tác giả mới";
            this.btnTacGiaMoi.UseVisualStyleBackColor = true;
            this.btnTacGiaMoi.Click += new System.EventHandler(this.btnTacGiaMoi_Click);
            // 
            // dgvTatCaTacGia
            // 
            this.dgvTatCaTacGia.AllowUserToAddRows = false;
            this.dgvTatCaTacGia.AllowUserToDeleteRows = false;
            this.dgvTatCaTacGia.AllowUserToResizeColumns = true;
            this.dgvTatCaTacGia.AllowUserToResizeRows = false;
            this.dgvTatCaTacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTatCaTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTatCaTacGia.Location = new System.Drawing.Point(0, 56);
            this.dgvTatCaTacGia.MultiSelect = true;
            this.dgvTatCaTacGia.Name = "dgvTatCaTacGia";
            this.dgvTatCaTacGia.ReadOnly = true;
            this.dgvTatCaTacGia.RowHeadersVisible = false;
            this.dgvTatCaTacGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTatCaTacGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTatCaTacGia.RowTemplate.Height = 24;
            this.dgvTatCaTacGia.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnHuy);
            this.panelBottom.Controls.Add(this.btnOK);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 56;
            this.panelBottom.Location = new System.Drawing.Point(0, 394);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10);
            this.panelBottom.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(380, 14);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 28);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(480, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Hoàn tất";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ChonTacGiaDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.dgvTatCaTacGia);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChonTacGiaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn tác giả";
            this.Load += new System.EventHandler(this.ChonTacGiaDialog_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTatCaTacGia)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiemTacGia;
        private System.Windows.Forms.Button btnTacGiaMoi;
        private System.Windows.Forms.DataGridView dgvTatCaTacGia;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOK;
    }
}