namespace QuanLyThuVien.GUI.ThongKeGUI
{
    partial class UCHeaderThongKe
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
            this.btn_nhanvien = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_phieuphat = new System.Windows.Forms.Button();
            this.btn_docgia = new System.Windows.Forms.Button();
            this.btn_sach = new System.Windows.Forms.Button();
            this.btn_tongquan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_nhanvien
            // 
            this.btn_nhanvien.Location = new System.Drawing.Point(648, 16);
            this.btn_nhanvien.Name = "btn_nhanvien";
            this.btn_nhanvien.Size = new System.Drawing.Size(120, 54);
            this.btn_nhanvien.TabIndex = 2;
            this.btn_nhanvien.Text = "Nhân Viên";
            this.btn_nhanvien.UseVisualStyleBackColor = true;
            this.btn_nhanvien.Click += new System.EventHandler(this.btn_nhanvien_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(522, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 54);
            this.button2.TabIndex = 4;
            this.button2.Text = "Doanh ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_phieuphat
            // 
            this.btn_phieuphat.Location = new System.Drawing.Point(396, 16);
            this.btn_phieuphat.Name = "btn_phieuphat";
            this.btn_phieuphat.Size = new System.Drawing.Size(120, 54);
            this.btn_phieuphat.TabIndex = 5;
            this.btn_phieuphat.Text = "Phiếu Phạt";
            this.btn_phieuphat.UseVisualStyleBackColor = true;
            // 
            // btn_docgia
            // 
            this.btn_docgia.Location = new System.Drawing.Point(270, 16);
            this.btn_docgia.Name = "btn_docgia";
            this.btn_docgia.Size = new System.Drawing.Size(120, 54);
            this.btn_docgia.TabIndex = 6;
            this.btn_docgia.Text = "Độc Giả";
            this.btn_docgia.UseVisualStyleBackColor = true;
            // 
            // btn_sach
            // 
            this.btn_sach.Location = new System.Drawing.Point(144, 16);
            this.btn_sach.Name = "btn_sach";
            this.btn_sach.Size = new System.Drawing.Size(120, 54);
            this.btn_sach.TabIndex = 7;
            this.btn_sach.Text = "Sách";
            this.btn_sach.UseVisualStyleBackColor = true;
            // 
            // btn_tongquan
            // 
            this.btn_tongquan.Location = new System.Drawing.Point(11, 16);
            this.btn_tongquan.Name = "btn_tongquan";
            this.btn_tongquan.Size = new System.Drawing.Size(127, 54);
            this.btn_tongquan.TabIndex = 3;
            this.btn_tongquan.Text = "Tổng Quan";
            this.btn_tongquan.UseVisualStyleBackColor = true;
            // 
            // UCHeaderThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_phieuphat);
            this.Controls.Add(this.btn_docgia);
            this.Controls.Add(this.btn_sach);
            this.Controls.Add(this.btn_tongquan);
            this.Controls.Add(this.btn_nhanvien);
            this.Name = "UCHeaderThongKe";
            this.Size = new System.Drawing.Size(792, 90);
            this.Load += new System.EventHandler(this.UCHeaderThongKe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_nhanvien;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_phieuphat;
        private System.Windows.Forms.Button btn_docgia;
        private System.Windows.Forms.Button btn_sach;
        private System.Windows.Forms.Button btn_tongquan;
    }
}
