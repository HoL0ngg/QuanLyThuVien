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
    public partial class PhieuNhapGUI : UserControl
    {
        PhieuNhapBUS bus = new PhieuNhapBUS();
        public PhieuNhapGUI()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormPhieuNhap_Load);
        }
        
        private void LoadDanhSach()
        {
            dataGridView1.AutoGenerateColumns = false;
            colMaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            colDate.DataPropertyName = "ThoiGian";
            colMaNV.DataPropertyName = "MaNV";
            colMaNCC.DataPropertyName = "MaNCC";
            dataGridView1.DataSource = bus.GetALL();
        }

        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            dataGridView1.CellClick += PhieuNhap_CellClick;
            btnThem.Click += them;
            btnChiTiet.Click += chitiet;
            btnXoa.Click += xoa;
            btnSua.Click += sua;
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
                        txtMaNV.Text = row.Cells["colMaNV"].Value.ToString();

                    if (row.Cells["colMaNCC"].Value != null)
                        txtMaNCC.Text = row.Cells["colMaNCC"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void them(object sender, EventArgs e)
        {
            FormThemPhieuNhap f =  new FormThemPhieuNhap();
            f.ShowDialog();
            LoadDanhSach();
        }
        private void chitiet(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int maPhieuChon = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value);
                CTPhieuNhapGUI gui = new CTPhieuNhapGUI(maPhieuChon);
                gui.ShowDialog();
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
                
            int maPhieuCanXoa = int.Parse(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString());
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
            int maPhieuCanSua = int.Parse(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString());
            DateTime NewDay = dtpDate.Value;
            int NewMaNV = int.Parse(txtMaNV.Text);
            int NewMaNNCC = int.Parse(txtMaNCC.Text);
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

        }
    }
}
