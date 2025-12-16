using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.phieuphat
{
    public partial class MucPhat : Form
    {
        public MucPhat()
        {
            InitializeComponent();
        }

        private void MucPhat_Load(object sender, EventArgs e)
        {
            LoadMucPhatFromDb();
        }

        private void LoadMucPhatFromDb()
        {
            try
            {
                var dto = PhieuPhatBUS.Instance.GetMucPhat();
                if (dto != null)
                {
                    nudTre.Value = dto.Tre;
                    nudHong.Value = dto.Hong;
                    nudMat.Value = dto.Mat;
                }
                else
                {
                    nudTre.Value = 0;
                    nudHong.Value = 0;
                    nudMat.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc mức phạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new MucPhatDTO
                {
                    Tre = Convert.ToInt32(nudTre.Value),
                    Hong = Convert.ToInt32(nudHong.Value),
                    Mat = Convert.ToInt32(nudMat.Value)
                };

                bool ok = PhieuPhatBUS.Instance.SaveMucPhat(dto);
                if (ok)
                {
                    MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu mức phạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
