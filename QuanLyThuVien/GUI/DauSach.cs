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
            //form_ThemPhieuMuon frm = new form_ThemPhieuMuon();
            //frm.ShowDialog();
            LoadData(); // Tải lại dữ liệu sau khi thêm
        }

        public override void OnEdit()
        {
            // Lấy ID của phiếu mượn đang chọn trên DataGridView
            // Mở form_SuaPhieuMuon với ID đó
            // ...
            LoadData(); // Tải lại
        }

        public override void OnDelete()
        {
            // Lấy ID, hỏi xác nhận xóa
            // ...
            LoadData(); // Tải lại
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
