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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiemTacGia = new System.Windows.Forms.TextBox();
            this.dgvTatCaTacGia = new System.Windows.Forms.DataGridView();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTatCaTacGia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            // 
            // txtTimKiemTacGia
            // 
            this.txtTimKiemTacGia.Location = new System.Drawing.Point(279, 21);
            this.txtTimKiemTacGia.Name = "txtTimKiemTacGia";
            this.txtTimKiemTacGia.Size = new System.Drawing.Size(100, 22);
            this.txtTimKiemTacGia.TabIndex = 1;
            this.txtTimKiemTacGia.TextChanged += new System.EventHandler(this.txtTimKiemTacGia_TextChanged);
            // 
            // dgvTatCaTacGia
            // 
            this.dgvTatCaTacGia.AllowUserToAddRows = false;
            this.dgvTatCaTacGia.AllowUserToDeleteRows = false;
            this.dgvTatCaTacGia.AllowUserToResizeColumns = false;
            this.dgvTatCaTacGia.AllowUserToResizeRows = false;
            this.dgvTatCaTacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTatCaTacGia.Location = new System.Drawing.Point(64, 60);
            this.dgvTatCaTacGia.Name = "dgvTatCaTacGia";
            this.dgvTatCaTacGia.ReadOnly = true;
            this.dgvTatCaTacGia.RowHeadersWidth = 51;
            this.dgvTatCaTacGia.RowTemplate.Height = 24;
            this.dgvTatCaTacGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTatCaTacGia.Size = new System.Drawing.Size(516, 309);
            this.dgvTatCaTacGia.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(409, 390);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(505, 390);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
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
            this.ClientSize = new System.Drawing.Size(658, 425);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.dgvTatCaTacGia);
            this.Controls.Add(this.txtTimKiemTacGia);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChonTacGiaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn tác giả";
            this.Load += new System.EventHandler(this.ChonTacGiaDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTatCaTacGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiemTacGia;
        private System.Windows.Forms.DataGridView dgvTatCaTacGia;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOK;
    }
}