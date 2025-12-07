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
                    MessageBox.Show("Vui lòng nh?p tên nhóm quy?n!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhomQuyen.Focus();
                    return;
                }

                int maNhomQuyen = NhomQuyenBUS.Instance.ThemNhomQuyen(txtTenNhomQuyen.Text.Trim());

                if (maNhomQuyen > 0)
                {
                    MessageBox.Show("Thêm nhóm quy?n thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhóm quy?n th?t b?i!", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i",
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
