namespace QuanLyThuVien.GUI
{
    partial class FormThemTacGia
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTenTacGia;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.DateTimePicker dtpNamSinh;
        private System.Windows.Forms.Label lblQuocTich;
        private System.Windows.Forms.TextBox txtQuocTich;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTenTacGia = new System.Windows.Forms.TextBox();
            this.lblNamSinh = new System.Windows.Forms.Label();
            this.dtpNamSinh = new System.Windows.Forms.DateTimePicker();
            this.lblQuocTich = new System.Windows.Forms.Label();
            this.txtQuocTich = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(24, 20);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(84, 16);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên tác giả:";
            // 
            // txtTenTacGia
            // 
            this.txtTenTacGia.Location = new System.Drawing.Point(120, 17);
            this.txtTenTacGia.Name = "txtTenTacGia";
            this.txtTenTacGia.Size = new System.Drawing.Size(250, 22);
            this.txtTenTacGia.TabIndex = 1;
            // 
            // lblNamSinh
            // 
            this.lblNamSinh.AutoSize = true;
            this.lblNamSinh.Location = new System.Drawing.Point(24, 58);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(66, 16);
            this.lblNamSinh.TabIndex = 2;
            this.lblNamSinh.Text = "Năm sinh:";
            // 
            // dtpNamSinh
            // 
            this.dtpNamSinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNamSinh.Location = new System.Drawing.Point(120, 53);
            this.dtpNamSinh.Name = "dtpNamSinh";
            this.dtpNamSinh.ShowCheckBox = true;
            this.dtpNamSinh.Size = new System.Drawing.Size(120, 22);
            this.dtpNamSinh.TabIndex = 3;
            // 
            // lblQuocTich
            // 
            this.lblQuocTich.AutoSize = true;
            this.lblQuocTich.Location = new System.Drawing.Point(24, 98);
            this.lblQuocTich.Name = "lblQuocTich";
            this.lblQuocTich.Size = new System.Drawing.Size(68, 16);
            this.lblQuocTich.TabIndex = 4;
            this.lblQuocTich.Text = "Quốc tịch:";
            // 
            // txtQuocTich
            // 
            this.txtQuocTich.Location = new System.Drawing.Point(120, 95);
            this.txtQuocTich.Name = "txtQuocTich";
            this.txtQuocTich.Size = new System.Drawing.Size(250, 22);
            this.txtQuocTich.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(214, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Lưu";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(295, 140);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 27);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormThemTacGia
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 190);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtQuocTich);
            this.Controls.Add(this.lblQuocTich);
            this.Controls.Add(this.dtpNamSinh);
            this.Controls.Add(this.lblNamSinh);
            this.Controls.Add(this.txtTenTacGia);
            this.Controls.Add(this.lblTen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThemTacGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm tác giả";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}