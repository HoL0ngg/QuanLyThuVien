namespace QuanLyThuVien.GUI.phieutra
{
    partial class TraForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MdsCoulum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maphieuLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ngaymuonLb = new System.Windows.Forms.Label();
            this.ngaytraLb = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.docgiaLb = new System.Windows.Forms.Label();
            this.nhanvienLb = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.MdsCoulum,
            this.NameColumn,
            this.StatusColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 233);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "Mã";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // MdsCoulum
            // 
            this.MdsCoulum.HeaderText = "Mã đầu sách";
            this.MdsCoulum.Name = "MdsCoulum";
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Tên";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 200;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Trạng Thái";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.Width = 200;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(713, 415);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Hủy";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(617, 415);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "Xác nhận";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã phiếu:";
            // 
            // maphieuLb
            // 
            this.maphieuLb.AutoSize = true;
            this.maphieuLb.Location = new System.Drawing.Point(103, 12);
            this.maphieuLb.Name = "maphieuLb";
            this.maphieuLb.Size = new System.Drawing.Size(35, 13);
            this.maphieuLb.TabIndex = 4;
            this.maphieuLb.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày trả dự kiến:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày mượn:";
            // 
            // ngaymuonLb
            // 
            this.ngaymuonLb.AutoSize = true;
            this.ngaymuonLb.Location = new System.Drawing.Point(103, 56);
            this.ngaymuonLb.Name = "ngaymuonLb";
            this.ngaymuonLb.Size = new System.Drawing.Size(35, 13);
            this.ngaymuonLb.TabIndex = 7;
            this.ngaymuonLb.Text = "label5";
            // 
            // ngaytraLb
            // 
            this.ngaytraLb.AutoSize = true;
            this.ngaytraLb.Location = new System.Drawing.Point(103, 106);
            this.ngaytraLb.Name = "ngaytraLb";
            this.ngaytraLb.Size = new System.Drawing.Size(35, 13);
            this.ngaytraLb.TabIndex = 8;
            this.ngaytraLb.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Độc giả:";
            // 
            // docgiaLb
            // 
            this.docgiaLb.AutoSize = true;
            this.docgiaLb.Location = new System.Drawing.Point(357, 12);
            this.docgiaLb.Name = "docgiaLb";
            this.docgiaLb.Size = new System.Drawing.Size(35, 13);
            this.docgiaLb.TabIndex = 10;
            this.docgiaLb.Text = "label8";
            // 
            // nhanvienLb
            // 
            this.nhanvienLb.AutoSize = true;
            this.nhanvienLb.Location = new System.Drawing.Point(357, 56);
            this.nhanvienLb.Name = "nhanvienLb";
            this.nhanvienLb.Size = new System.Drawing.Size(35, 13);
            this.nhanvienLb.TabIndex = 11;
            this.nhanvienLb.Text = "label9";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(292, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Nhân viên:";
            // 
            // TraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nhanvienLb);
            this.Controls.Add(this.docgiaLb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ngaytraLb);
            this.Controls.Add(this.ngaymuonLb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maphieuLb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TraForm";
            this.Text = "TraForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MdsCoulum;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatusColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label maphieuLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ngaymuonLb;
        private System.Windows.Forms.Label ngaytraLb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label docgiaLb;
        private System.Windows.Forms.Label nhanvienLb;
        private System.Windows.Forms.Label label11;
    }
}