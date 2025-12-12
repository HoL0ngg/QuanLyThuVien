using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    partial class FormChiTietPhieuPhat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private QuanLyThuVien.GUI.CustomDataGridView dgv;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private Panel panelFooter;
        

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



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new QuanLyThuVien.GUI.CustomDataGridView();
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.panelFooter = new Panel();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();

            // panelHeader (chỉ còn tiêu đề)
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 48;
            this.panelHeader.BackColor = Color.LightGray;
            this.panelHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitle.Text = "Chi tiết phiếu phạt";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // panelFooter
            this.panelFooter.Dock = DockStyle.Bottom;
            this.panelFooter.Height = 48;
            this.panelFooter.BackColor = Color.LightGray;
            this.panelFooter.Padding = new Padding(8);
            this.panelFooter.Controls.Add(this.btnClose);

            // btnClose
            this.btnClose.Text = "Đóng";
            this.btnClose.AutoSize = true;
            this.btnClose.Dock = DockStyle.Right;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // dgv
            this.dgv.Dock = DockStyle.Fill;

            // FormChiTietPhieuPhat
            this.ClientSize = new Size(780, 460);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.StartPosition = FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }



    }
}