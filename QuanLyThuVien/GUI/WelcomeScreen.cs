using QuanLyThuVien.DAO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class WelcomeScreen : BaseModuleUC
    {
        private Timer animationTimer;
        private int animationProgress = 0;

        public WelcomeScreen()
        {
            InitializeComponent();
            LoadStatistics();
            StartAnimation();
        }

        private void StartAnimation()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 20;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (animationProgress < 100)
            {
                animationProgress += 2;
                this.Invalidate();
            }
            else
            {
                animationTimer.Stop();
            }
        }

        private void LoadStatistics()
        {
            try
            {
                string querySach = "SELECT COUNT(*) FROM sach WHERE trangthai = 1";
                object resultSach = DataProvider.ExecuteScalar(querySach);
                int tongSach = resultSach != null ? Convert.ToInt32(resultSach) : 0;
                lblTongSach.Text = tongSach.ToString();

                string queryDauSach = "SELECT COUNT(*) FROM dau_sach WHERE TrangThai = 1";
                object resultDauSach = DataProvider.ExecuteScalar(queryDauSach);
                int tongDauSach = resultDauSach != null ? Convert.ToInt32(resultDauSach) : 0;
                lblTongDauSach.Text = tongDauSach.ToString();

                string queryDocGia = "SELECT COUNT(*) FROM doc_gia WHERE TrangThai = 1";
                object resultDocGia = DataProvider.ExecuteScalar(queryDocGia);
                int tongDocGia = resultDocGia != null ? Convert.ToInt32(resultDocGia) : 0;
                lblTongDocGia.Text = tongDocGia.ToString();

                string querySachMuon = @"
                    SELECT COUNT(DISTINCT pm.MaPhieuMuon) 
                    FROM phieu_muon pm 
                    WHERE pm.TrangThai = 1";
                object resultSachMuon = DataProvider.ExecuteScalar(querySachMuon);
                int sachDangMuon = resultSachMuon != null ? Convert.ToInt32(resultSachMuon) : 0;
                lblSachDangMuon.Text = sachDangMuon.ToString();

                LoadRecentActivities();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thống kê: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActivities()
        {
            try
            {
                string query = @"
                    (SELECT 
                        pm.NgayMuon as NgayThucHien,
                        dg.TENDG as NguoiThucHien,
                        ds.TenDauSach as NoiDung,
                        'Mượn sách' as LoaiHoatDong
                    FROM phieu_muon pm
                    JOIN doc_gia dg ON pm.MaDocGia = dg.MADG
                    JOIN ctphieu_muon ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
                    JOIN sach s ON ct.MaSach = s.MaSach
                    JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                    WHERE pm.trangthai = 1
                    ORDER BY pm.NgayMuon DESC
                    LIMIT 3)

                    UNION ALL

                    (SELECT 
                        pt.NgayTra as NgayThucHien,
                        dg.TENDG as NguoiThucHien,
                        ds.TenDauSach as NoiDung,
                        'Trả sách' as LoaiHoatDong
                    FROM phieu_tra pt
                    JOIN doc_gia dg ON pt.MaDG = dg.MADG
                    JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                    JOIN ctphieu_muon ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
                    JOIN sach s ON ct.MaSach = s.MaSach
                    JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                    ORDER BY pt.NgayTra DESC
                    LIMIT 2)

                    UNION ALL

                    (SELECT 
                        pp.NgayPhat as NgayThucHien,
                        dg.TENDG as NguoiThucHien,
                        CONCAT('Phạt ', FORMAT(ct.TienPhat, 0), ' VNĐ') as NoiDung,
                        'Phạt' as LoaiHoatDong
                    FROM phieu_phat pp
                    JOIN ctphieu_phat ct ON pp.MaPhieuPhat = ct.MaPhieuPhat
                    JOIN doc_gia dg ON pp.MaDG = dg.MADG
                    ORDER BY pp.NgayPhat DESC
                    LIMIT 2)

                    UNION ALL

                    (SELECT 
                        pn.ThoiGian as NgayThucHien,
                        nv.TENNV as NguoiThucHien,
                        CONCAT('Nhập từ ', ncc.TENCC) as NoiDung,
                        'Nhập sách' as LoaiHoatDong
                    FROM phieu_nhap pn
                    JOIN nhan_vien nv ON pn.MaNV = nv.MANV
                    JOIN nha_cung_cap ncc ON pn.MaNCC = ncc.MANCC
                    ORDER BY pn.ThoiGian DESC
                    LIMIT 2)

                    UNION ALL

                    (SELECT 
                        NOW() as NgayThucHien,
                        dg.TENDG as NguoiThucHien,
                        'Đăng ký thành viên' as NoiDung,
                        'Đăng ký' as LoaiHoatDong
                    FROM doc_gia dg
                    WHERE dg.TRANGTHAI = 1
                    ORDER BY dg.MADG DESC
                    LIMIT 1)

                    ORDER BY NgayThucHien DESC
                    LIMIT 10";

                DataTable dt = DataProvider.ExecuteQuery(query);
                dgvRecentActivity.DataSource = dt;

                // Tùy chỉnh hiển thị
                if (dgvRecentActivity.Columns.Contains("NgayThucHien"))
                {
                    dgvRecentActivity.Columns["NgayThucHien"].HeaderText = "Ngày";
                    dgvRecentActivity.Columns["NgayThucHien"].Width = 120;
                    dgvRecentActivity.Columns["NgayThucHien"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvRecentActivity.Columns.Contains("NguoiThucHien"))
                {
                    dgvRecentActivity.Columns["NguoiThucHien"].HeaderText = "Người thực hiện";
                    dgvRecentActivity.Columns["NguoiThucHien"].Width = 150;
                }
                if (dgvRecentActivity.Columns.Contains("NoiDung"))
                {
                    dgvRecentActivity.Columns["NoiDung"].HeaderText = "Nội dung";
                    dgvRecentActivity.Columns["NoiDung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvRecentActivity.Columns.Contains("LoaiHoatDong"))
                {
                    dgvRecentActivity.Columns["LoaiHoatDong"].HeaderText = "Loại";
                    dgvRecentActivity.Columns["LoaiHoatDong"].Width = 100;
                }

                // Tô màu theo loại hoạt động
                ColorizeActivityRows();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tải hoạt động: {ex.Message}");
            }
        }

        private void ColorizeActivityRows()
        {
            foreach (DataGridViewRow row in dgvRecentActivity.Rows)
            {
                if (row.Cells["LoaiHoatDong"].Value == null) continue;

                string loaiHoatDong = row.Cells["LoaiHoatDong"].Value.ToString();

                switch (loaiHoatDong)
                {
                    case "Mượn sách":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253); // Light Blue
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 71, 161);
                        break;
                    case "Trả sách":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201); // Light Green
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(27, 94, 32);
                        break;
                    case "Phạt":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210); // Light Red
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(183, 28, 28);
                        break;
                    case "Nhập sách":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 178); // Light Orange
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(230, 81, 0);
                        break;
                    case "Đăng ký":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(225, 190, 231); // Light Purple
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(74, 20, 140);
                        break;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        public override void OnAdd() { }
        public override void OnEdit() { }
        public override void OnDelete() { }
        public override void OnDetails() { }
        public override void LoadData() { LoadStatistics(); }
    }
}
