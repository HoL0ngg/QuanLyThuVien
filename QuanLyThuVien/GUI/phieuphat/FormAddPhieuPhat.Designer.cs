namespace QuanLyThuVien.GUI
{
    partial class FormAddPhieuPhat
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.chkChiHienViPham = new System.Windows.Forms.CheckBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvChonPP = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuuCPP = new System.Windows.Forms.Button();
            this.panelTongTien = new System.Windows.Forms.Panel();
            this.lblSoLuongChon = new System.Windows.Forms.Label();
            this.lblTongTienValue = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonPP)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelTongTien.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(950, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblTieuDe.Size = new System.Drawing.Size(950, 50);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÊM PHIẾU PHẠT";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panelFilter.Controls.Add(this.chkChiHienViPham);
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 50);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelFilter.Size = new System.Drawing.Size(950, 40);
            this.panelFilter.TabIndex = 1;
            // 
            // chkChiHienViPham
            // 
            this.chkChiHienViPham.AutoSize = true;
            this.chkChiHienViPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkChiHienViPham.Location = new System.Drawing.Point(180, 10);
            this.chkChiHienViPham.Name = "chkChiHienViPham";
            this.chkChiHienViPham.Size = new System.Drawing.Size(298, 24);
            this.chkChiHienViPham.TabIndex = 1;
            this.chkChiHienViPham.Text = "Chỉ hiện sách có vi phạm (trễ/hỏng/mất)";
            this.chkChiHienViPham.UseVisualStyleBackColor = true;
            this.chkChiHienViPham.CheckedChanged += new System.EventHandler(this.chkChiHienViPham_CheckedChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblFilter.Location = new System.Drawing.Point(15, 11);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(165, 20);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Danh sách sách đã trả:";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dgvChonPP);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 90);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.panelGrid.Size = new System.Drawing.Size(950, 380);
            this.panelGrid.TabIndex = 2;
            // 
            // dgvChonPP
            // 
            this.dgvChonPP.AllowUserToAddRows = false;
            this.dgvChonPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChonPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChonPP.Location = new System.Drawing.Point(15, 5);
            this.dgvChonPP.Name = "dgvChonPP";
            this.dgvChonPP.RowHeadersVisible = false;
            this.dgvChonPP.RowHeadersWidth = 51;
            this.dgvChonPP.RowTemplate.Height = 28;
            this.dgvChonPP.Size = new System.Drawing.Size(920, 370);
            this.dgvChonPP.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.panelButtons);
            this.panelBottom.Controls.Add(this.panelTongTien);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 470);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(950, 110);
            this.panelBottom.TabIndex = 3;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnDetail);
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnLuuCPP);
            this.panelButtons.Location = new System.Drawing.Point(514, 15);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(421, 80);
            this.panelButtons.TabIndex = 1;
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnDetail.FlatAppearance.BorderSize = 0;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDetail.ForeColor = System.Drawing.Color.White;
            this.btnDetail.Location = new System.Drawing.Point(3, 20);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(110, 40);
            this.btnDetail.TabIndex = 0;
            this.btnDetail.Text = "Chi Tiết";
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(136, 20);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuuCPP
            // 
            this.btnLuuCPP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnLuuCPP.FlatAppearance.BorderSize = 0;
            this.btnLuuCPP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCPP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuCPP.ForeColor = System.Drawing.Color.White;
            this.btnLuuCPP.Location = new System.Drawing.Point(261, 20);
            this.btnLuuCPP.Name = "btnLuuCPP";
            this.btnLuuCPP.Size = new System.Drawing.Size(140, 40);
            this.btnLuuCPP.TabIndex = 1;
            this.btnLuuCPP.Text = "Lưu phiếu phạt";
            this.btnLuuCPP.UseVisualStyleBackColor = false;
            this.btnLuuCPP.Click += new System.EventHandler(this.btnLuuCPP_Click);
            // 
            // panelTongTien
            // 
            this.panelTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.panelTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTongTien.Controls.Add(this.lblSoLuongChon);
            this.panelTongTien.Controls.Add(this.lblTongTienValue);
            this.panelTongTien.Controls.Add(this.lblTongTien);
            this.panelTongTien.Location = new System.Drawing.Point(15, 15);
            this.panelTongTien.Name = "panelTongTien";
            this.panelTongTien.Size = new System.Drawing.Size(400, 80);
            this.panelTongTien.TabIndex = 0;
            // 
            // lblSoLuongChon
            // 
            this.lblSoLuongChon.AutoSize = true;
            this.lblSoLuongChon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuongChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblSoLuongChon.Location = new System.Drawing.Point(12, 52);
            this.lblSoLuongChon.Name = "lblSoLuongChon";
            this.lblSoLuongChon.Size = new System.Drawing.Size(112, 20);
            this.lblSoLuongChon.TabIndex = 2;
            this.lblSoLuongChon.Text = "Đã chọn: 0 sách";
            // 
            // lblTongTienValue
            // 
            this.lblTongTienValue.AutoSize = true;
            this.lblTongTienValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongTienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTongTienValue.Location = new System.Drawing.Point(140, 8);
            this.lblTongTienValue.Name = "lblTongTienValue";
            this.lblTongTienValue.Size = new System.Drawing.Size(71, 46);
            this.lblTongTienValue.TabIndex = 1;
            this.lblTongTienValue.Text = "0 đ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblTongTien.Location = new System.Drawing.Point(12, 16);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(125, 28);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "TỔNG TIỀN:";
            // 
            // FormAddPhieuPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 580);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddPhieuPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm phiếu phạt";
            this.panelTop.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonPP)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelTongTien.ResumeLayout(false);
            this.panelTongTien.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.CheckBox chkChiHienViPham;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvChonPP;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTongTien;
        private System.Windows.Forms.Label lblSoLuongChon;
        private System.Windows.Forms.Label lblTongTienValue;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnLuuCPP;
    }
}