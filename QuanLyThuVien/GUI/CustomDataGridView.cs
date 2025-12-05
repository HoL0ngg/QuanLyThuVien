using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    // A reusable custom DataGridView with predefined styles
    public class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            InitializeStyles();
        }

        private void InitializeStyles()
        {
            // Header styles
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersHeight = 40;

            // Row styles
            this.RowTemplate.Height = 35;
            this.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
            this.DefaultCellStyle.SelectionForeColor = Color.White;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            // Borders
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridColor = Color.FromArgb(224, 224, 224);

            // Misc
            this.ShowCellToolTips = true;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.RowHeadersVisible = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
