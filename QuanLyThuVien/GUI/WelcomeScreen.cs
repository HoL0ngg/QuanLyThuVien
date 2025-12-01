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
                // Th?ng kê t?ng s? sách
                string querySach = "SELECT COUNT(*) FROM sach WHERE trangthai = 1";
                object resultSach = DataProvider.ExecuteScalar(querySach);
                int tongSach = resultSach != null ? Convert.ToInt32(resultSach) : 0;
                lblTongSach.Text = tongSach.ToString();

                // Th?ng kê t?ng ??u sách
                string queryDauSach = "SELECT COUNT(*) FROM dau_sach WHERE TrangThai = 1";
                object resultDauSach = DataProvider.ExecuteScalar(queryDauSach);
                int tongDauSach = resultDauSach != null ? Convert.ToInt32(resultDauSach) : 0;
                lblTongDauSach.Text = tongDauSach.ToString();

                // Th?ng kê ??c gi?
                string queryDocGia = "SELECT COUNT(*) FROM doc_gia WHERE TrangThai = 1";
                object resultDocGia = DataProvider.ExecuteScalar(queryDocGia);
                int tongDocGia = resultDocGia != null ? Convert.ToInt32(resultDocGia) : 0;
                lblTongDocGia.Text = tongDocGia.ToString();

                // Th?ng kê sách ?ang m??n
                string querySachMuon = @"
                    SELECT COUNT(DISTINCT pm.MaPhieuMuon) 
                    FROM phieu_muon pm 
                    WHERE pm.TrangThai = 1";
                object resultSachMuon = DataProvider.ExecuteScalar(querySachMuon);
                int sachDangMuon = resultSachMuon != null ? Convert.ToInt32(resultSachMuon) : 0;
                lblSachDangMuon.Text = sachDangMuon.ToString();

                // Load ho?t ??ng g?n ?ây
                LoadRecentActivities();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i t?i th?ng kê: {ex.Message}", "L?i", 
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
                        dg.TenDocGia as NguoiThucHien,
                        ds.TenDauSach as NoiDung,
                        'M??n sách' as LoaiHoatDong
                    FROM phieu_muon pm
                    JOIN doc_gia dg ON pm.MaDocGia = dg.MaDocGia
                    JOIN chi_tiet_phieu_muon ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
                    JOIN sach s ON ct.MaSach = s.MaSach
                    JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                    WHERE pm.TrangThai = 1
                    ORDER BY pm.NgayMuon DESC
                    LIMIT 3)

                    UNION ALL

                    (SELECT 
                        pt.NgayTra as NgayThucHien,
                        dg.TenDocGia as NguoiThucHien,
                        ds.TenDauSach as NoiDung,
                        'Tr? sách' as LoaiHoatDong
                    FROM phieu_tra pt
                    JOIN phieu_muon pm ON pt.MaPhieuMuon = pm.MaPhieuMuon
                    JOIN doc_gia dg ON pm.MaDocGia = dg.MaDocGia
                    JOIN chi_tiet_phieu_muon ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
                    JOIN sach s ON ct.MaSach = s.MaSach
                    JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach
                    ORDER BY pt.NgayTra DESC
                    LIMIT 2)

                    UNION ALL

                    (SELECT 
                        pp.NgayLap as NgayThucHien,
                        dg.TenDocGia as NguoiThucHien,
                        CONCAT('Ph?t ', FORMAT(pp.TienPhat, 0), ' VN?') as NoiDung,
                        'Ph?t' as LoaiHoatDong
                    FROM phieu_phat pp
                    JOIN doc_gia dg ON pp.MaDocGia = dg.MaDocGia
                    ORDER BY pp.NgayLap DESC
                    LIMIT 2)

                    UNION ALL

                    (SELECT 
                        pn.ThoiGian as NgayThucHien,
                        nv.TENNV as NguoiThucHien,
                        CONCAT('Nh?p t? ', ncc.TENNCC) as NoiDung,
                        'Nh?p sách' as LoaiHoatDong
                    FROM phieu_nhap pn
                    JOIN nhan_vien nv ON pn.MaNV = nv.MANV
                    JOIN nha_cung_cap ncc ON pn.MaNCC = ncc.MANCC
                    ORDER BY pn.ThoiGian DESC
                    LIMIT 2)

                    UNION ALL

                    (SELECT 
                        dg.NgayLapThe as NgayThucHien,
                        dg.TenDocGia as NguoiThucHien,
                        '??ng ký thành viên' as NoiDung,
                        '??ng ký' as LoaiHoatDong
                    FROM doc_gia dg
                    WHERE dg.TrangThai = 1
                    ORDER BY dg.NgayLapThe DESC
                    LIMIT 1)

                    ORDER BY NgayThucHien DESC
                    LIMIT 10";

                DataTable dt = DataProvider.ExecuteQuery(query);
                dgvRecentActivity.DataSource = dt;

                // Tùy ch?nh hi?n th?
                if (dgvRecentActivity.Columns.Contains("NgayThucHien"))
                {
                    dgvRecentActivity.Columns["NgayThucHien"].HeaderText = "Ngày";
                    dgvRecentActivity.Columns["NgayThucHien"].Width = 120;
                    dgvRecentActivity.Columns["NgayThucHien"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvRecentActivity.Columns.Contains("NguoiThucHien"))
                {
                    dgvRecentActivity.Columns["NguoiThucHien"].HeaderText = "Ng??i th?c hi?n";
                    dgvRecentActivity.Columns["NguoiThucHien"].Width = 150;
                }
                if (dgvRecentActivity.Columns.Contains("NoiDung"))
                {
                    dgvRecentActivity.Columns["NoiDung"].HeaderText = "N?i dung";
                    dgvRecentActivity.Columns["NoiDung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvRecentActivity.Columns.Contains("LoaiHoatDong"))
                {
                    dgvRecentActivity.Columns["LoaiHoatDong"].HeaderText = "Lo?i";
                    dgvRecentActivity.Columns["LoaiHoatDong"].Width = 100;
                }

                // Tô màu theo lo?i ho?t ??ng
                ColorizeActivityRows();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i t?i ho?t ??ng: {ex.Message}");
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
                    case "M??n sách":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253); // Light Blue
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 71, 161);
                        break;
                    case "Tr? sách":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201); // Light Green
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(27, 94, 32);
                        break;
                    case "Ph?t":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210); // Light Red
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(183, 28, 28);
                        break;
                    case "Nh?p sách":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 178); // Light Orange
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(230, 81, 0);
                        break;
                    case "??ng ký":
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

        // Override methods (không c?n thi?t cho Welcome Screen nh?ng ph?i có vì k? th?a BaseModuleUC)
        public override void OnAdd() { }
        public override void OnEdit() { }
        public override void OnDelete() { }
        public override void OnDetails() { }
        public override void LoadData() { LoadStatistics(); }
    }
}
