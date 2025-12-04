using System;
using System.Windows.Forms;
using Org.BouncyCastle.Math.Field;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.GUI
{
    public partial class SuaDocGiaDialog : Form
    {
        private readonly DocGiaBUS dgBUS = new DocGiaBUS();
        private readonly DocGiaDTO current;

        public string TenDocGia => txtTenDG.Text.Trim();
        public string SoDienThoai => txtSDT.Text.Trim();
        public string DiaChi => txtDiaChi.Text.Trim();

        public SuaDocGiaDialog()
        {
            InitializeComponent();
        }

        public SuaDocGiaDialog(DocGiaDTO docGia) : this()
        {
            current = docGia ?? new DocGiaDTO();
            txtTenDG.Text = current.TenDG;
            txtSDT.Text = current.SDT;
            txtDiaChi.Text = current.DiaChi;
            this.btnLuu.Click += btnLuu_Click;
            this.btnHuy.Click += btnHuy_Click;
        }

        private void FocusAndSelect(TextBox tb)
        {
            if (tb == null) return;
            tb.Focus();
            tb.SelectAll();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TenDocGia))
                {
                    MessageBox.Show("Vui lòng nhập tên độc giả.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FocusAndSelect(txtTenDG);
                    return;
                }
                if (string.IsNullOrWhiteSpace(SoDienThoai))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FocusAndSelect(txtSDT);
                    return;
                }
                if (string.IsNullOrWhiteSpace(DiaChi))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FocusAndSelect(txtDiaChi);
                    return;
                }
                var existed = dgBUS.GetByPhone(SoDienThoai);
                if (existed != null)
                    if (existed.MaDG != current.MaDG)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FocusAndSelect(txtSDT);
                        return;
                    }

                var dg = new DocGiaDTO
                {
                    MaDG = current.MaDG,
                    TenDG = TenDocGia,
                    SDT = SoDienThoai,
                    DiaChi = DiaChi,
                    TrangThai = 1
                };
                if (dgBUS.Update(dg))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
