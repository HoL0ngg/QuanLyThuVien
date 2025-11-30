using System;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.GUI
{
    public partial class ThemDocGiaDialog : Form
    {
        private readonly DocGiaBUS dgBUS = new DocGiaBUS();
        public string TenDocGia => txtTenDG.Text.Trim();
        public string SoDienThoai => txtSDT.Text.Trim();
        public string DiaChi => txtDiaChi.Text.Trim();

        public ThemDocGiaDialog()
        {
            InitializeComponent();
            btnThem.Click += BtnThem_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TenDocGia))
                {
                    MessageBox.Show("Vui lòng nhập tên độc giả.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(SoDienThoai))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var dg = new DocGiaDTO
                {
                    TenDG = TenDocGia,
                    SDT = SoDienThoai,
                    DiaChi = DiaChi,
                    TrangThai = 1
                };
                if (dgBUS.Create(dg))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
