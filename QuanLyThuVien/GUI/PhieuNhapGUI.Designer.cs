﻿using QuanLyThuVien.BUS;
using System;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    partial class PhieuNhapGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //private PhieuNhapBUS bus = new PhieuNhapBUS();

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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colMaPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formThemPhieuNhap2 = new QuanLyThuVien.GUI.FormThemPhieuNhap();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.cbMaNCC = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.formThemPhieuNhap2);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(3, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1030, 725);
            this.panel3.TabIndex = 9;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cbMaNCC);
            this.panel9.Controls.Add(this.cbMaNV);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Controls.Add(this.dtpDate);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Location = new System.Drawing.Point(0, 528);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1024, 197);
            this.panel9.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(741, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 23);
            this.label11.TabIndex = 4;
            this.label11.Text = "Mã nhà cung cấp";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(417, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "Mã nhân viên";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(15, 97);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(246, 22);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(11, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Ngày nhập phiếu";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaPhieuNhap,
            this.colDate,
            this.colMaNV,
            this.colMaNCC});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1024, 528);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colMaPhieuNhap
            // 
            this.colMaPhieuNhap.HeaderText = "Mã phiếu nhập";
            this.colMaPhieuNhap.MinimumWidth = 6;
            this.colMaPhieuNhap.Name = "colMaPhieuNhap";
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Ngày lập phiếu nhập";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            // 
            // colMaNV
            // 
            this.colMaNV.HeaderText = "Mã nhân viên";
            this.colMaNV.MinimumWidth = 6;
            this.colMaNV.Name = "colMaNV";
            // 
            // colMaNCC
            // 
            this.colMaNCC.HeaderText = "Mã nhà cung cấp";
            this.colMaNCC.MinimumWidth = 6;
            this.colMaNCC.Name = "colMaNCC";
            // 
            // formThemPhieuNhap2
            // 
            this.formThemPhieuNhap2.Location = new System.Drawing.Point(210, 56);
            this.formThemPhieuNhap2.Name = "formThemPhieuNhap2";
            this.formThemPhieuNhap2.Size = new System.Drawing.Size(575, 448);
            this.formThemPhieuNhap2.TabIndex = 2;
            this.formThemPhieuNhap2.Visible = false;
            this.formThemPhieuNhap2.Load += new System.EventHandler(this.formThemPhieuNhap2_Load);
            // 
            // cbMaNV
            // 
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(421, 99);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(195, 24);
            this.cbMaNV.TabIndex = 5;
            // 
            // cbMaNCC
            // 
            this.cbMaNCC.FormattingEnabled = true;
            this.cbMaNCC.Location = new System.Drawing.Point(745, 99);
            this.cbMaNCC.Name = "cbMaNCC";
            this.cbMaNCC.Size = new System.Drawing.Size(195, 24);
            this.cbMaNCC.TabIndex = 6;
            // 
            // PhieuNhapGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel3);
            this.Name = "PhieuNhapGUI";
            this.Size = new System.Drawing.Size(1036, 740);
            this.Load += new System.EventHandler(this.PhieuNhapGUI_Load);
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNCC;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private FormThemPhieuNhap formThemPhieuNhap2;
        private ComboBox cbMaNCC;
        private ComboBox cbMaNV;
    }
}