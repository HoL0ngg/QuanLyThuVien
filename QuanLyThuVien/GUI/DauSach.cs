using QuanLyThuVien.BUS;
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
    public partial class DauSach : BaseModuleUC
    {
        public DauSach()
        {
            InitializeComponent();
        }

        // Ghi đè (override) lại các hành vi của lớp cha
        public override void OnAdd()
        {
            // Mở form_ThemPhieuMuon
            DauSachDialog dialog = new DauSachDialog("ADD", 0);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Thêm đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại dữ liệu sau khi thêm
            }
        }

        public override void OnEdit()
        {
            // Lấy ID của phiếu mượn đang chọn trên DataGridView
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đầu sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["Mã đầu sách"].Value);
            DauSachDialog dialog = new DauSachDialog("EDIT", selectedDauSachID);
            
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Sửa đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại dữ liệu sau khi thêm
            }
        }

        public override void OnDelete()
        {
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đầu sách để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["Mã đầu sách"].Value);
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa đầu sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                bool success = DauSachBUS.Instance.DeleteDauSach(selectedDauSachID);
                if (success)
                {
                    MessageBox.Show("Xóa đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa đầu sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadData(); // Tải lại
        }

        public override void OnDetails()
        {
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đầu sách để xem chi tiết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["Mã đầu sách"].Value);
            DauSachDialog dialog = new DauSachDialog("DETAILS", selectedDauSachID);
            dialog.ShowDialog();
        }

        public override void LoadData()
        {
            string searchTerm = txtSearch.Text.Trim();
            DataTable data;

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Ô tìm kiếm rỗng -> Lấy tất cả
                data = DauSachBUS.Instance.GetAllDauSach();
            }
            else
            {
                // Ô tìm kiếm có chữ -> Lọc theo chữ
                data = DauSachBUS.Instance.SearchDauSach(searchTerm);
            }

            // Bind dữ liệu lên DataGridView
            dgvDauSach.DataSource = data;
        }

        private void DauSach_Load_1(object sender, EventArgs e)
        {
            Console.WriteLine("DauSach Loaded");
            // Tải dữ liệu lần đầu
            LoadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
