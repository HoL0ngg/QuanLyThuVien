using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormThemNhomQuyen : Form
    {
        public FormThemNhomQuyen()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNhomQuyen.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhóm quyền!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhomQuyen.Focus();
                    return;
                }

                int maNhomQuyen = NhomQuyenBUS.Instance.ThemNhomQuyen(txtTenNhomQuyen.Text.Trim());

                if (maNhomQuyen > 0)
                {
                    MessageBox.Show("Thêm nhóm quyền thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhóm quyền thất bại!", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
