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
            this.components = new System.ComponentModel.Container();
            this.dgvChonPP = new System.Windows.Forms.DataGridView();
            this.btnLuuCPP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonPP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChonPP
            // 
            this.dgvChonPP.Name = "dgvChonPP";
            this.dgvChonPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChonPP.AllowUserToAddRows = false;
            this.dgvChonPP.RowHeadersVisible = false;
            this.dgvChonPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChonPP.Location = new System.Drawing.Point(12, 12);
            this.dgvChonPP.RowHeadersWidth = 51;
            this.dgvChonPP.RowTemplate.Height = 24;
            this.dgvChonPP.Size = new System.Drawing.Size(776, 392);
            this.dgvChonPP.TabIndex = 0;
            // Note: CellContentClick handler is attached at runtime in SetupDataGridView to avoid designer issues.
            // 
            // btnLuuCPP
            // 
            this.btnLuuCPP.Location = new System.Drawing.Point(700, 415);
            this.btnLuuCPP.Name = "btnLuuCPP";
            this.btnLuuCPP.Size = new System.Drawing.Size(75, 23);
            this.btnLuuCPP.TabIndex = 1;
            this.btnLuuCPP.Text = "Lưu";
            this.btnLuuCPP.UseVisualStyleBackColor = true;
            this.btnLuuCPP.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAddPhieuPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLuuCPP);
            this.Controls.Add(this.dgvChonPP);
            this.Name = "FormAddPhieuPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn phiếu phạt";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChonPP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChonPP;
        private System.Windows.Forms.Button btnLuuCPP;
    }
}