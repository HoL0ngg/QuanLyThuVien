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
    public partial class DauSach : BaseModuleUC
    {
        public DauSach()
        {
            InitializeComponent();
            CustomizeDataGridView();
        }

        public DauSach(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        private void CustomizeDataGridView()
        {
            // Tuy chinh header
            dgvDauSach.EnableHeadersVisualStyles = false;
            dgvDauSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvDauSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDauSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDauSach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDauSach.ColumnHeadersHeight = 40;
            
            // Tuy chinh rows
            dgvDauSach.RowTemplate.Height = 35;
            dgvDauSach.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvDauSach.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);
            dgvDauSach.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDauSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            
            // Border
            dgvDauSach.BorderStyle = BorderStyle.None;
            dgvDauSach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDauSach.GridColor = Color.FromArgb(224, 224, 224);
            
            // Them tooltip
            dgvDauSach.ShowCellToolTips = true;
        }

        // Ghi de (override) lai cac hanh vi cua lop cha
        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Ban khong co quyen them dau sach!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mo form_ThemPhieuMuon
            DauSachDialog dialog = new DauSachDialog("ADD", 0);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Them dau sach thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tai lai du lieu sau khi them
            }
        }

        public override void OnEdit()
        {
            if (!CoQuyenSua)
            {
                MessageBox.Show("Ban khong co quyen sua dau sach!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lay ID cua phieu muon dang chon tren DataGridView
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon dau sach de sua!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
            DauSachDialog dialog = new DauSachDialog("EDIT", selectedDauSachID);
            
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Sua dau sach thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tai lai du lieu sau khi sua
            }
        }

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Ban khong co quyen xoa dau sach!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon dau sach de xoa!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedDauSachID = Convert.ToInt32(dgvDauSach.SelectedRows[0].Cells["MaDauSach"].Value);
            var confirmResult = MessageBox.Show("Ban co chac chan muon xoa dau sach nay?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                bool success = DauSachBUS.Instance.DeleteDauSach(selectedDauSachID);
                if (success)
                {
                    MessageBox.Show("Xoa dau sach thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xoa dau sach that bai!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadData(); // Tai lai
        }

        public override void OnDetails()
        {
            if (!CoQuyenXem)
            {
                MessageBox.Show("Ban khong co quyen xem chi tiet dau sach!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvDauSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon dau sach de xem chi tiet!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // O tim kiem rong -> Lay tat ca
                data = DauSachBUS.Instance.GetAllDauSach();
            }
            else
            {
                // O tim kiem co chu -> Loc theo chu
                data = DauSachBUS.Instance.SearchDauSach(searchTerm);
            }

            // Bind du lieu len DataGridView
            dgvDauSach.DataSource = data;
            
            // Doi ten cot hien thi cho dep (neu muon)
            if (dgvDauSach.Columns.Contains("MaDauSach"))
            {
                dgvDauSach.Columns["MaDauSach"].HeaderText = "Ma dau sach";
                dgvDauSach.Columns["MaDauSach"].Width = 100;
            }
            if (dgvDauSach.Columns.Contains("TenDauSach"))
            {
                dgvDauSach.Columns["TenDauSach"].HeaderText = "Ten dau sach";
                dgvDauSach.Columns["TenDauSach"].Width = 250;
            }
            if (dgvDauSach.Columns.Contains("NhaXuatBan"))
            {
                dgvDauSach.Columns["NhaXuatBan"].HeaderText = "Nha xuat ban";
                dgvDauSach.Columns["NhaXuatBan"].Width = 200;
            }
            if (dgvDauSach.Columns.Contains("NamXuatBan"))
            {
                dgvDauSach.Columns["NamXuatBan"].HeaderText = "Nam XB";
                dgvDauSach.Columns["NamXuatBan"].Width = 80;
            }
            if (dgvDauSach.Columns.Contains("NgonNgu"))
            {
                dgvDauSach.Columns["NgonNgu"].HeaderText = "Ngon ngu";
                dgvDauSach.Columns["NgonNgu"].Width = 120;
            }
            if (dgvDauSach.Columns.Contains("SoLuong"))
            {
                dgvDauSach.Columns["SoLuong"].HeaderText = "So luong";
                dgvDauSach.Columns["SoLuong"].Width = 90;
            }
            
            // Tuy chinh tooltip cho moi cell
            foreach (DataGridViewRow row in dgvDauSach.Rows)
            {
                if (row.Cells["TenDauSach"] != null)
                {
                    row.Cells["TenDauSach"].ToolTipText = "Nhan dup de xem danh sach sach";
                }
            }
        }

        private void DauSach_Load_1(object sender, EventArgs e)
        {
            Console.WriteLine("DauSach Loaded");
            // Tai du lieu lan dau
            LoadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.SuppressKeyPress = true; // Ngan tieng beep
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
                    MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
