using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class ChonTacGiaDialog : Form
    {
        // Thuộc tính để Form cha (DauSachDialog) lấy kết quả
        public List<TacGiaDTO> SelectedAuthors { get; private set; }
        public ChonTacGiaDialog()
        {
            InitializeComponent();
            SelectedAuthors = new List<TacGiaDTO>();
        }

        private void ChonTacGiaDialog_Load(object sender, EventArgs e)
        {
            LoadAllAuthors();
        }

        private void LoadAllAuthors()
        {
            // Tải tất cả tác giả từ BUS (bạn đã có)
            DataTable dt = TacGiaBUS.Instance.GetAllTacGia();
            dgvTatCaTacGia.DataSource = dt;

            // Cấu hình cột
            dgvTatCaTacGia.Columns["MaTacGia"].HeaderText = "Mã";
            dgvTatCaTacGia.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
            dgvTatCaTacGia.Columns["TenTacGia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void txtTimKiemTacGia_TextChanged(object sender, EventArgs e)
        {
            // Lọc DataGridView dựa trên DataTable
            (dgvTatCaTacGia.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("TenTacGia LIKE '%{0}%'", txtTimKiemTacGia.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvTatCaTacGia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một tác giả.");
                return;
            }

            // Lặp qua tất cả các hàng đang được chọn
            foreach (DataGridViewRow row in dgvTatCaTacGia.SelectedRows)
            {
                DataRowView drv = row.DataBoundItem as DataRowView;

                TacGiaDTO author = new TacGiaDTO
                {
                    maTacGia = Convert.ToInt32(drv["MaTacGia"]),
                    tenTacGia = drv["TenTacGia"].ToString()
                };

                SelectedAuthors.Add(author);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
