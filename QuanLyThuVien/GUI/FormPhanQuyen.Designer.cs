namespace QuanLyThuVien.GUI
{
    partial class FormPhanQuyen
    {
        private System.ComponentModel.IContainer components = null;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.dgvQuyen = new System.Windows.Forms.DataGridView();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.cboNhomQuyen = new System.Windows.Forms.ComboBox();
            this.lblNhomQuyen = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnXoaNhomQuyen = new System.Windows.Forms.Button();
            this.btnThemNhomQuyen = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyen)).BeginInit();
            this.panelSelect.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(700, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Qu?n lý phân quy?n theo nhóm";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Controls.Add(this.dgvQuyen);
            this.panelBody.Controls.Add(this.panelSelect);
            this.panelBody.Controls.Add(this.panelInfo);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 70);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(20);
            this.panelBody.Size = new System.Drawing.Size(700, 480);
            this.panelBody.TabIndex = 1;
            // 
            // dgvQuyen
            // 
            this.dgvQuyen.AllowUserToAddRows = false;
            this.dgvQuyen.AllowUserToDeleteRows = false;
            this.dgvQuyen.AllowUserToResizeColumns = false;
            this.dgvQuyen.AllowUserToResizeRows = false;
            this.dgvQuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuyen.Location = new System.Drawing.Point(20, 120);
            this.dgvQuyen.MultiSelect = false;
            this.dgvQuyen.Name = "dgvQuyen";
            this.dgvQuyen.RowHeadersVisible = false;
            this.dgvQuyen.RowHeadersWidth = 51;
            this.dgvQuyen.RowTemplate.Height = 40;
            this.dgvQuyen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvQuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuyen.Size = new System.Drawing.Size(660, 340);
            this.dgvQuyen.TabIndex = 2;
            // 
            // panelSelect
            // 
            this.panelSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSelect.Controls.Add(this.cboNhomQuyen);
            this.panelSelect.Controls.Add(this.lblNhomQuyen);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelect.Location = new System.Drawing.Point(20, 65);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Padding = new System.Windows.Forms.Padding(10);
            this.panelSelect.Size = new System.Drawing.Size(660, 55);
            this.panelSelect.TabIndex = 1;
            // 
            // cboNhomQuyen
            // 
            this.cboNhomQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomQuyen.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboNhomQuyen.FormattingEnabled = true;
            this.cboNhomQuyen.Location = new System.Drawing.Point(140, 12);
            this.cboNhomQuyen.Name = "cboNhomQuyen";
            this.cboNhomQuyen.Size = new System.Drawing.Size(280, 33);
            this.cboNhomQuyen.TabIndex = 1;
            this.cboNhomQuyen.SelectedIndexChanged += new System.EventHandler(this.cboNhomQuyen_SelectedIndexChanged);
            // 
            // lblNhomQuyen
            // 
            this.lblNhomQuyen.AutoSize = true;
            this.lblNhomQuyen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNhomQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblNhomQuyen.Location = new System.Drawing.Point(15, 17);
            this.lblNhomQuyen.Name = "lblNhomQuyen";
            this.lblNhomQuyen.Size = new System.Drawing.Size(119, 25);
            this.lblNhomQuyen.TabIndex = 0;
            this.lblNhomQuyen.Text = "Nhóm quy?n:";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));

            this.panelInfo.Controls.Add(this.lblInfo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(20, 20);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(660, 45);
            this.panelInfo.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblInfo.Size = new System.Drawing.Size(660, 45);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Ch?n nhóm quy?n và tích ch?n các ô ?? c?p quy?n. Nhóm Admin không th? s?a.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));

            this.panelFooter.Controls.Add(this.btnXoaNhomQuyen);
            this.panelFooter.Controls.Add(this.btnThemNhomQuyen);
            this.panelFooter.Controls.Add(this.btnHuy);
            this.panelFooter.Controls.Add(this.btnLuu);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 550);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(700, 70);
            this.panelFooter.TabIndex = 2;
            // 
            // btnXoaNhomQuyen
            // 
            this.btnXoaNhomQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnXoaNhomQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNhomQuyen.FlatAppearance.BorderSize = 0;
            this.btnXoaNhomQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNhomQuyen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaNhomQuyen.ForeColor = System.Drawing.Color.White;
            this.btnXoaNhomQuyen.Location = new System.Drawing.Point(140, 15);
            this.btnXoaNhomQuyen.Name = "btnXoaNhomQuyen";
            this.btnXoaNhomQuyen.Size = new System.Drawing.Size(110, 40);
            this.btnXoaNhomQuyen.TabIndex = 3;
            this.btnXoaNhomQuyen.Text = "Xóa nhóm";
            this.btnXoaNhomQuyen.UseVisualStyleBackColor = false;
            this.btnXoaNhomQuyen.Click += new System.EventHandler(this.btnXoaNhomQuyen_Click);
            // 
            // btnThemNhomQuyen
            // 
            this.btnThemNhomQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnThemNhomQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhomQuyen.FlatAppearance.BorderSize = 0;
            this.btnThemNhomQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNhomQuyen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemNhomQuyen.ForeColor = System.Drawing.Color.White;
            this.btnThemNhomQuyen.Location = new System.Drawing.Point(20, 15);
            this.btnThemNhomQuyen.Name = "btnThemNhomQuyen";
            this.btnThemNhomQuyen.Size = new System.Drawing.Size(110, 40);
            this.btnThemNhomQuyen.TabIndex = 2;
            this.btnThemNhomQuyen.Text = "Thêm nhóm";
            this.btnThemNhomQuyen.UseVisualStyleBackColor = false;
            this.btnThemNhomQuyen.Click += new System.EventHandler(this.btnThemNhomQuyen_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(570, 15);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "?óng";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(440, 15);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "L?u quy?n";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FormPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 620);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPhanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Qu?n lý phân quy?n";
            this.panelHeader.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyen)).EndInit();
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.DataGridView dgvQuyen;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.ComboBox cboNhomQuyen;
        private System.Windows.Forms.Label lblNhomQuyen;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemNhomQuyen;
        private System.Windows.Forms.Button btnXoaNhomQuyen;
    }
}
