namespace QuanLyThuVien.GUI
{
    partial class ThemDocGiaDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Label lblTenDG;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtTenDG;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;

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
            this.components = new System.ComponentModel.Container();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenDG = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtTenDG = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblMain.Padding = new System.Windows.Forms.Padding(10);
            this.tblMain.Size = new System.Drawing.Size(488, 150);
            // 
            // Labels
            // 
            this.lblTenDG.Text = "Tên độc giả";
            this.lblSDT.Text = "Số điện thoại";
            this.lblDiaChi.Text = "Địa chỉ";
            this.lblTenDG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSDT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // TextBoxes
            // 
            this.txtTenDG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // Add controls to table
            // 
            this.tblMain.Controls.Add(this.lblTenDG, 0, 0);
            this.tblMain.Controls.Add(this.txtTenDG, 1, 0);
            this.tblMain.Controls.Add(this.lblSDT, 0, 1);
            this.tblMain.Controls.Add(this.txtSDT, 1, 1);
            this.tblMain.Controls.Add(this.lblDiaChi, 0, 2);
            this.tblMain.Controls.Add(this.txtDiaChi, 1, 2);
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 50;
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10);
            // 
            // btnThem
            // 
            this.btnThem.Text = "Thêm";
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnThem.Location = new System.Drawing.Point(306, 10);
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            // 
            // btnHuy
            // 
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHuy.Location = new System.Drawing.Point(392, 10);
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            // 
            // Add buttons to panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnThem);
            this.panelBottom.Controls.Add(this.btnHuy);
            // 
            // ThemDocGiaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 329);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.tblMain);
            this.Name = "ThemDocGiaDialog";
            this.Text = "Thêm độc giả";
            this.ResumeLayout(false);

        }

        #endregion
    }
}