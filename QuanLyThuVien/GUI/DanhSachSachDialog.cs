using QuanLyThuVien.DAO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class DanhSachSachDialog : Form
    {
        private int maDauSach;
        private string tenDauSach;

        public DanhSachSachDialog(int maDauSach, string tenDauSach)
        {
            InitializeComponent();
            this.maDauSach = maDauSach;
            this.tenDauSach = tenDauSach;
            
            // Set font an toàn cho các control
            SetSafeFonts();
        }

        private void SetSafeFonts()
        {
            // Th? dùng Segoe UI, n?u không có thì dùng Microsoft Sans Serif
            Font titleFont = GetSafeFont("Segoe UI", 16F, FontStyle.Bold);
            Font normalFont = GetSafeFont("Segoe UI", 10F, FontStyle.Regular);
            Font buttonFont = GetSafeFont("Segoe UI", 10F, FontStyle.Bold);

            lblTitle.Font = titleFont;
            lblThongKe.Font = normalFont;
            btnClose.Font = buttonFont;
            
            // DataGridView
            if (dgvSach != null)
            {
                dgvSach.DefaultCellStyle.Font = GetSafeFont("Segoe UI", 9F, FontStyle.Regular);
                dgvSach.ColumnHeadersDefaultCellStyle.Font = GetSafeFont("Segoe UI", 10F, FontStyle.Bold);
            }
        }

        private Font GetSafeFont(string fontName, float size, FontStyle style)
        {
            try
            {
                using (Font testFont = new Font(fontName, size, style))
                {
                    // N?u font t?n t?i, t?o font m?i và return
                    return new Font(fontName, size, style);
                }
            }
            catch
            {
                // N?u font không t?n t?i, dùng font m?c ??nh
                return new Font(FontFamily.GenericSansSerif, size, style);
            }
        }

        private void DanhSachSachDialog_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"Danh sách sách: {tenDauSach}";
            LoadDanhSachSach();
        }

        private void LoadDanhSachSach()
        {
            try
            {
                string query = @"
                    SELECT 
                        s.MaSach AS 'MaSach',
                        ds.TenDauSach AS 'TenSach',
                        CASE 
                            WHEN s.trangthai = 1 THEN 'Bình th??ng'
                            WHEN s.trangthai = 0 THEN 'B? h?'
                            WHEN s.trangthai = -1 THEN 'B? m?t'
                            WHEN s.trangthai = -10 THEN '?ã h?y'
                            ELSE 'Không xác ??nh'
                        END AS 'TrangThai'
                    FROM sach s
                    JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                    WHERE s.MaDauSach = @MaDauSach
                    ORDER BY s.MaSach";

                var parameters = new System.Collections.Generic.Dictionary<string, object>
                {
                    { "@MaDauSach", maDauSach }
                };

                DataTable dt = DataProvider.ExecuteQuery(query, parameters);
                dgvSach.DataSource = dt;

                // ??i tên header
                if (dgvSach.Columns.Contains("MaSach"))
                    dgvSach.Columns["MaSach"].HeaderText = "Mã sách";
                if (dgvSach.Columns.Contains("TenSach"))
                    dgvSach.Columns["TenSach"].HeaderText = "Tên sách";
                if (dgvSach.Columns.Contains("TrangThai"))
                    dgvSach.Columns["TrangThai"].HeaderText = "Tr?ng thái";

                // ??m s? l??ng theo tr?ng thái
                int tongSo = dt.Rows.Count;
                int binhThuong = 0, biHu = 0, biMat = 0, daHuy = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string trangThai = row["TrangThai"].ToString();
                    switch (trangThai)
                    {
                        case "Bình th??ng": binhThuong++; break;
                        case "B? h?": biHu++; break;
                        case "B? m?t": biMat++; break;
                        case "?ã h?y": daHuy++; break;
                    }
                }

                lblThongKe.Text = $"T?ng: {tongSo} | Bình th??ng: {binhThuong} | B? h?: {biHu} | B? m?t: {biMat} | ?ã h?y: {daHuy}";

                // Tô màu theo tr?ng thái
                dgvSach.CellFormatting += DgvSach_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i t?i d? li?u: {ex.Message}", "L?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSach.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string trangThai = e.Value.ToString();
                switch (trangThai)
                {
                    case "Bình th??ng":
                        e.CellStyle.BackColor = Color.FromArgb(200, 230, 201); // Light Green
                        e.CellStyle.ForeColor = Color.FromArgb(27, 94, 32);
                        break;
                    case "B? h?":
                        e.CellStyle.BackColor = Color.FromArgb(255, 224, 178); // Light Orange
                        e.CellStyle.ForeColor = Color.FromArgb(230, 81, 0);
                        break;
                    case "B? m?t":
                        e.CellStyle.BackColor = Color.FromArgb(255, 205, 210); // Light Red
                        e.CellStyle.ForeColor = Color.FromArgb(183, 28, 28);
                        break;
                    case "?ã h?y":
                        e.CellStyle.BackColor = Color.FromArgb(224, 224, 224); // Light Gray
                        e.CellStyle.ForeColor = Color.FromArgb(97, 97, 97);
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
