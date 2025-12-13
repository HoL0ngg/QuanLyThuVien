using System;
using System.Windows.Forms;
using QuanLyThuVien.DTO;
using QuanLyThuVien.BUS;

namespace QuanLyThuVien.GUI
{
    public partial class FormThemTacGia : Form
    {
        public string CreatedTenTacGia { get; private set; }

        public FormThemTacGia()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenTacGia.Text.Trim();
                string quocTich = txtQuocTich.Text.Trim();
                string namSinh = null;
                if (dtpNamSinh.Checked)
                {
                    namSinh = dtpNamSinh.Value.ToString("yyyy-MM-dd");
                }

                if (string.IsNullOrWhiteSpace(ten))
                {
                    MessageBox.Show("Vui lòng nhập tên tác giả.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTacGia.Focus();
                    return;
                }

                var tg = new TacGiaDTO
                {
                    tenTacGia = ten,
                    namSinh = namSinh,
                    quocTich = quocTich
                };

                bool ok = TacGiaBUS.Instance.Create(tg);
                if (ok)
                {
                    // expose created name for parent dialogs
                    CreatedTenTacGia = ten;

                    MessageBox.Show("Thêm tác giả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm tác giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
