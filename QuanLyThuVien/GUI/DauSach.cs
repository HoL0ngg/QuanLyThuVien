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
            CustomizeDataGridView();
        }

        private void CustomizeDataGridView()
        {
            // Tùy chỉnh header
            dgvDauSach.EnableHeadersVisualStyles = false;
            dgvDauSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvDauSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDauSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDauSach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDauSach.ColumnHeadersHeight = 40;
            
            // Tùy chỉnh rows
            dgvDauSach.RowTemplate.Height = 35;
            dgvDauSach.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDauSach.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
            dgvDauSach.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDauSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            
            // Border
            dgvDauSach.BorderStyle = BorderStyle.None;
            dgvDauSach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDauSach.GridColor = Color.FromArgb(224, 224, 224);
            
            // Thêm tooltip
            dgvDauSach.ShowCellToolTips = true;
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
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
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
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
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
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
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
            
            // Đổi tên cột hiển thị cho đẹp (nếu muốn)
            if (dgvDauSach.Columns.Contains("MaDauSach"))
            {
                dgvDauSach.Columns["MaDauSach"].HeaderText = "Mã đầu sách";
                dgvDauSach.Columns["MaDauSach"].Width = 100;
            }
            if (dgvDauSach.Columns.Contains("TenDauSach"))
            {
                dgvDauSach.Columns["TenDauSach"].HeaderText = "Tên đầu sách";
                dgvDauSach.Columns["TenDauSach"].Width = 250;
            }
            if (dgvDauSach.Columns.Contains("NhaXuatBan"))
            {
                dgvDauSach.Columns["NhaXuatBan"].HeaderText = "Nhà xuất bản";
                dgvDauSach.Columns["NhaXuatBan"].Width = 200;
            }
            if (dgvDauSach.Columns.Contains("NamXuatBan"))
            {
                dgvDauSach.Columns["NamXuatBan"].HeaderText = "Năm XB";
                dgvDauSach.Columns["NamXuatBan"].Width = 80;
            }
            if (dgvDauSach.Columns.Contains("NgonNgu"))
            {
                dgvDauSach.Columns["NgonNgu"].HeaderText = "Ngôn ngữ";
                dgvDauSach.Columns["NgonNgu"].Width = 120;
            }
            if (dgvDauSach.Columns.Contains("SoLuong"))
            {
                dgvDauSach.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvDauSach.Columns["SoLuong"].Width = 90;
            }
            
            // Tùy chỉnh tooltip cho mỗi cell
            foreach (DataGridViewRow row in dgvDauSach.Rows)
            {
                if (row.Cells["TenDauSach"] != null)
                {
                    row.Cells["TenDauSach"].ToolTipText = "Nhấn đúp để xem danh sách sách";
                }
            }
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
                e.SuppressKeyPress = true; // Ngăn tiếng beep
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void dgvDauSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int maDauSach = Convert.ToInt32(dgvDauSach.Rows[e.RowIndex].Cells["MaDauSach"].Value);
                    string tenDauSach = dgvDauSach.Rows[e.RowIndex].Cells["TenDauSach"].Value.ToString();
                    
                    DanhSachSachDialog dialog = new DanhSachSachDialog(maDauSach, tenDauSach);
                    dialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
