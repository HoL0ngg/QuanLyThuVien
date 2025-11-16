using System;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormThemPhieuMuon : UserControl
    {
        // Sự kiện yêu cầu đóng form (quay về trang phiếu mượn)
        public event Action CloseRequested;

        public FormThemPhieuMuon()
        {
            InitializeComponent();
            this.Load += FormThemPhieuMuon_Load;
            btnThem.Click += BtnThem_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        private void FormThemPhieuMuon_Load(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            txtNgayMuon.Text = today.ToString("dd/MM/yyyy");
            dtpNgayTraDuKien.Value = today.AddDays(7);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Chưa thêm logic lưu DB theo yêu cầu. Chỉ yêu cầu quay lại trang trước.
            CloseRequested?.Invoke();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke();
        }
    }
}
