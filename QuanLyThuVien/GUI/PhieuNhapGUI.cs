using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
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
    public partial class PhieuNhapGUI : BaseModuleUC
    {
        PhieuNhapBUS bus = new PhieuNhapBUS();
        private FormThemPhieuNhap formThemPhieuNhap1;
        private CTPhieuNhapGUI ctPhieuNhapGUI1;
        public PhieuNhapGUI()
        {
            InitializeComponent();
            formThemPhieuNhap1 = new FormThemPhieuNhap();
            formThemPhieuNhap1.Dock = DockStyle.Fill;
            formThemPhieuNhap1.Visible = false;
            this.Controls.Add(formThemPhieuNhap1);

            ctPhieuNhapGUI1 = new CTPhieuNhapGUI();
            ctPhieuNhapGUI1.Dock = DockStyle.Fill;
            ctPhieuNhapGUI1.Visible = false;
            this.Controls.Add(ctPhieuNhapGUI1);
            formThemPhieuNhap2.OnPhieuNhapAdded += () => LoadDanhSach();
        }
        
        public void LoadDanhSach()
        {
            dataGridView1.AutoGenerateColumns = false;
            colMaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            colDate.DataPropertyName = "ThoiGian";
            colMaNV.DataPropertyName = "MaNV";
            colMaNCC.DataPropertyName = "MaNCC";
            colTenNhanVien.DataPropertyName = "TENNV";
            colTenNCC.DataPropertyName = "TENNCC";
            dataGridView1.DataSource = bus.GetALL();
        }

        private void PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    if (row.Cells["colDate"].Value != null && row.Cells["colDate"].Value != DBNull.Value)
                        dtpDate.Value = Convert.ToDateTime(row.Cells["colDate"].Value);
                    else
                        dtpDate.Value = DateTime.Now;
                    
                    if (row.Cells["colMaNV"].Value != null)
                        cbMaNV.SelectedValue = row.Cells["colMaNV"].Value;

                    if (row.Cells["colMaNCC"].Value != null)
                        cbMaNCC.SelectedValue = row.Cells["colMaNCC"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void them(object sender, EventArgs e)
        {
            formThemPhieuNhap2.Visible = true;
            formThemPhieuNhap2.BringToFront();
        }
        private void chitiet(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int maPhieuChon = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value);
                ctPhieuNhapGUI1.LoadChiTiet(maPhieuChon);
                ctPhieuNhapGUI1.Visible = true;
                ctPhieuNhapGUI1.BringToFront();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xem chi tiết!");
            }
        }

        private void xoa(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null) {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            int maPhieuCanXoa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString());
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập " + maPhieuCanXoa + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool xoaThanhCong = bus.Delete(maPhieuCanXoa);
                if (xoaThanhCong)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadDanhSach();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sua(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maPhieuCanSua = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString());
            DateTime NewDay = dtpDate.Value;
            int NewMaNV = Convert.ToInt32(cbMaNV.SelectedValue);
            int NewMaNNCC = Convert.ToInt32(cbMaNCC.SelectedValue);
            PhieuNhapDTO NewPhieu = new PhieuNhapDTO();
            NewPhieu.MaPhieuNhap = maPhieuCanSua;
            NewPhieu.ThoiGian = NewDay;
            NewPhieu.MaNV = NewMaNV;
            NewPhieu.MaNCC = NewMaNNCC;
            bool SuaThanhCong = bus.Update(NewPhieu);
            if(SuaThanhCong)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadDanhSach();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var result = bus.Search(keyword);
            if (result == null || result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập nào phù hợp với từ khóa",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = result;
        }
        private void LoadNhanVien()
        {
            string query = "SELECT MANV, TENNV FROM nhan_vien";
            DataTable dt = DataProvider.ExecuteQuery(query);

            dt.Columns.Add("MATEN", typeof(string), "MANV + ' - ' + TENNV");

            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MATEN";
            cbMaNV.ValueMember = "MANV";
        }

        private void LoadNhacungCap()
        {
            string query = "SELECT MANCC, TENNCC FROM nha_cung_cap";
            DataTable dt = DataProvider.ExecuteQuery(query);
            dt.Columns.Add("MATEN", typeof(string), "MANCC + ' - ' + TENNCC");
            cbMaNCC.DataSource = dt;
            cbMaNCC.DisplayMember = "MATEN";
            cbMaNCC.ValueMember = "MANCC";
        }

        public override void OnAdd()
        {
            them(this,EventArgs.Empty);
        }
        public override void OnEdit()
        {
            sua(this, EventArgs.Empty);
        }
        public override void OnDelete()
        {
            xoa(this, EventArgs.Empty);
        }

        public override void OnDetails()
        {
            chitiet(this, EventArgs.Empty);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PhieuNhapGUI_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            LoadNhanVien();
            LoadNhacungCap();
            dataGridView1.CellClick += PhieuNhap_CellClick;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formThemPhieuNhap2_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            btnSearch_Click(this, EventArgs.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
