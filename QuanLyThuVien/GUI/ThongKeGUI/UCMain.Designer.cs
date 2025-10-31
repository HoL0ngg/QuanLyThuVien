namespace QuanLyThuVien.GUI.ThongKeGUI
{
    partial class UCMain
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
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControlTK = new System.Windows.Forms.TabControl();
            this.btn_tongquan = new System.Windows.Forms.TabPage();
            this.btn_sach = new System.Windows.Forms.TabPage();
            this.btn_phieuphat = new System.Windows.Forms.TabPage();
            this.btn_docgia = new System.Windows.Forms.TabPage();
            this.btn_phieumuon = new System.Windows.Forms.TabPage();
            this.tabControlTK.SuspendLayout();
            this.SuspendLayout();
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // tabControlTK
            // 
            this.tabControlTK.Controls.Add(this.btn_tongquan);
            this.tabControlTK.Controls.Add(this.btn_sach);
            this.tabControlTK.Controls.Add(this.btn_phieuphat);
            this.tabControlTK.Controls.Add(this.btn_docgia);
            this.tabControlTK.Controls.Add(this.btn_phieumuon);
            this.tabControlTK.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlTK.Location = new System.Drawing.Point(0, 0);
            this.tabControlTK.Name = "tabControlTK";
            this.tabControlTK.SelectedIndex = 0;
            this.tabControlTK.Size = new System.Drawing.Size(1101, 660);
            this.tabControlTK.TabIndex = 0;
            // 
            // btn_tongquan
            // 
            this.btn_tongquan.Location = new System.Drawing.Point(4, 25);
            this.btn_tongquan.Name = "btn_tongquan";
            this.btn_tongquan.Padding = new System.Windows.Forms.Padding(3);
            this.btn_tongquan.Size = new System.Drawing.Size(1093, 631);
            this.btn_tongquan.TabIndex = 0;
            this.btn_tongquan.Text = "Tổng Quan";
            this.btn_tongquan.UseVisualStyleBackColor = true;
            this.btn_tongquan.Click += new System.EventHandler(this.tabPageTK_Click);
            // 
            // btn_sach
            // 
            this.btn_sach.Location = new System.Drawing.Point(4, 25);
            this.btn_sach.Name = "btn_sach";
            this.btn_sach.Padding = new System.Windows.Forms.Padding(3);
            this.btn_sach.Size = new System.Drawing.Size(422, 302);
            this.btn_sach.TabIndex = 1;
            this.btn_sach.Text = "Sách";
            this.btn_sach.UseVisualStyleBackColor = true;
            // 
            // btn_phieuphat
            // 
            this.btn_phieuphat.Location = new System.Drawing.Point(4, 25);
            this.btn_phieuphat.Name = "btn_phieuphat";
            this.btn_phieuphat.Padding = new System.Windows.Forms.Padding(3);
            this.btn_phieuphat.Size = new System.Drawing.Size(422, 302);
            this.btn_phieuphat.TabIndex = 2;
            this.btn_phieuphat.Text = "Phiếu Phạt";
            this.btn_phieuphat.UseVisualStyleBackColor = true;
            // 
            // btn_docgia
            // 
            this.btn_docgia.Location = new System.Drawing.Point(4, 25);
            this.btn_docgia.Name = "btn_docgia";
            this.btn_docgia.Padding = new System.Windows.Forms.Padding(3);
            this.btn_docgia.Size = new System.Drawing.Size(422, 302);
            this.btn_docgia.TabIndex = 3;
            this.btn_docgia.Text = "Độc Giả";
            this.btn_docgia.UseVisualStyleBackColor = true;
            // 
            // btn_phieumuon
            // 
            this.btn_phieumuon.Location = new System.Drawing.Point(4, 25);
            this.btn_phieumuon.Name = "btn_phieumuon";
            this.btn_phieumuon.Padding = new System.Windows.Forms.Padding(3);
            this.btn_phieumuon.Size = new System.Drawing.Size(422, 302);
            this.btn_phieumuon.TabIndex = 4;
            this.btn_phieumuon.Text = "Phiếu Mượn";
            this.btn_phieumuon.UseVisualStyleBackColor = true;
            // 
            // UCMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlTK);
            this.Name = "UCMain";
            this.Size = new System.Drawing.Size(1101, 732);
            this.Load += new System.EventHandler(this.UCMain_Load);
            this.tabControlTK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControlTK;
        private System.Windows.Forms.TabPage btn_tongquan;
        private System.Windows.Forms.TabPage btn_sach;
        private System.Windows.Forms.TabPage btn_phieuphat;
        private System.Windows.Forms.TabPage btn_docgia;
        private System.Windows.Forms.TabPage btn_phieumuon;
    }
}
