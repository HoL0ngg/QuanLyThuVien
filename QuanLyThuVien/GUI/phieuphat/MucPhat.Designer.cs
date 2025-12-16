namespace QuanLyThuVien.GUI.phieuphat
{
    partial class MucPhat
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudTre = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMat = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiền phạt mỗi ngày trễ:";
            // 
            // nudTre
            // 
            this.nudTre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudTre.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudTre.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudTre.Location = new System.Drawing.Point(220, 23);
            this.nudTre.Name = "nudTre";
            this.nudTre.Size = new System.Drawing.Size(150, 30);
            this.nudTre.TabIndex = 1;
            this.nudTre.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiền phạt sách hỏng:";
            // 
            // nudHong
            // 
            this.nudHong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudHong.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudHong.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudHong.Location = new System.Drawing.Point(220, 68);
            this.nudHong.Name = "nudHong";
            this.nudHong.Size = new System.Drawing.Size(150, 30);
            this.nudHong.TabIndex = 3;
            this.nudHong.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(25, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiền phạt sách mất:";
            // 
            // nudMat
            // 
            this.nudMat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudMat.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudMat.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudMat.Location = new System.Drawing.Point(220, 113);
            this.nudMat.Name = "nudMat";
            this.nudMat.Size = new System.Drawing.Size(150, 30);
            this.nudMat.TabIndex = 5;
            this.nudMat.ThousandsSeparator = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(220, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(320, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MucPhat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudMat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudHong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudTre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MucPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết lập mức phạt";
            this.Load += new System.EventHandler(this.MucPhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudHong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMat;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}