using Mysqlx.Crud;
using QuanLyThuVien.DAO;
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
    public partial class CTPhieuNhapGUI : UserControl
    {
        private CTPhieuNhapBUS bus = new CTPhieuNhapBUS();
        private int MaPhieuHienTai; 
        public CTPhieuNhapGUI()
        {
            InitializeComponent();
            this.Load += FormCTPhieuNhap_Load;
        }
        public CTPhieuNhapGUI(int maPhieuNhapDuocGuiQua)
        {
            InitializeComponent();
            this.MaPhieuHienTai = maPhieuNhapDuocGuiQua;
            this.Load += FormCTPhieuNhap_Load;
        }

        public void LoadChiTiet(int maPhieuChon)
        {
            this.MaPhieuHienTai = maPhieuChon;

            ResetInput();
            LoadSach();
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            dataGridView1.AutoGenerateColumns = false;
            colMaDauSach.DataPropertyName = "TenSach";
            colSoLuong.DataPropertyName = "SoLuong";
            colDonGia.DataPropertyName = "DonGia";

            try
            {
                var list = bus.GetByPhieuNhap(MaPhieuHienTai);
                dataGridView1.DataSource = list;

                double tongtien = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["colSoLuong"].Value != null && row.Cells["colDonGia"].Value != null)
                    {
                        int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        double donGia = Convert.ToDouble(row.Cells["colDonGia"].Value);
                        double thanhTien = soLuong * donGia;
                        row.Cells["colThanhTien"].Value = thanhTien;
                        tongtien += thanhTien;
                    }
                }

                lblTongTien.Text = tongtien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phiếu nhập: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSach()
        {
            string query = "SELECT MaDauSach, TenDauSach FROM dau_sach";
            DataTable dt = DataProvider.ExecuteQuery(query);

            dt.Columns.Add("MASACH", typeof(string), "MaDauSach + ' - ' + TenDauSach");

            cbTenSach.DataSource = dt;
            cbTenSach.DisplayMember = "MASACH";
            cbTenSach.ValueMember = "MaDauSach";
        }

        private void CTPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    CTPhieuNhapDTO ct = dataGridView1.Rows[e.RowIndex].DataBoundItem as CTPhieuNhapDTO;

                    if (ct != null)
                    {
                        cbTenSach.SelectedValue = ct.MaDauSach;

                        txtSoLuong.Text = ct.SoLuong.ToString();
                        txtDonGia.Text = ct.DonGia.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormCTPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            dataGridView1.CellClick += CTPhieuNhap_CellClick;
            LoadSach();
            btnThem.Click += new EventHandler(them);
            btnXoa.Click += new EventHandler(xoa);
            btnSua.Click += new EventHandler(sua);
            btnHuy.Click += new EventHandler(Cancel);

        }
        private void ResetInput()
        {
            cbTenSach.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
        }

        private void them(object sender, EventArgs e)
        {
            int maSach = (int)cbTenSach.SelectedValue;
            string soLuongText = txtSoLuong.Text;
            string donGiaText = txtDonGia.Text;
            int soLuong;
            if (!int.TryParse(soLuongText, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là một con số lớn hơn 0.", "Lỗi");
                txtSoLuong.Focus();
                return;
            }

            double donGia;
            if (!double.TryParse(donGiaText, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là một con số hợp lệ.", "Lỗi");
                txtDonGia.Focus();
                return;
            }
            try
            {
                CTPhieuNhapDTO ct = new CTPhieuNhapDTO();
                ct.MaPhieuNhap = MaPhieuHienTai;
                ct.MaDauSach = maSach;
                ct.SoLuong = soLuong;
                ct.DonGia = donGia;
                bool kq = bus.Insert(ct);
                if (kq)
                {
                    MessageBox.Show("Thêm sách thành công!");
                    LoadDanhSach();

                    cbTenSach.SelectedIndex = 0;
                    txtSoLuong.Clear();
                    txtDonGia.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào CSDL: " + ex.Message);
            }

        }

        private void xoa(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CTPhieuNhapDTO sachCanXoa = dataGridView1.CurrentRow.DataBoundItem as CTPhieuNhapDTO;
            if (sachCanXoa == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu của dòng đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maPhieuNhap = MaPhieuHienTai;
            int maDauSach = sachCanXoa.MaDauSach;
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sách '{sachCanXoa.TenSach}' khỏi phiếu nhập này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool rs = bus.DeletePhieuNhap(maPhieuNhap, maDauSach);
                    if (rs)
                    {
                        MessageBox.Show("Xóa sách thành công!");
                        LoadDanhSach();
                        cbTenSach.SelectedIndex = -1;
                        txtSoLuong.Clear();
                        txtDonGia.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sua(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maSach = (int)cbTenSach.SelectedValue;
                int maPhieu = MaPhieuHienTai;
                int soluong = int.Parse(txtSoLuong.Text);
                double donGia = double.Parse(txtDonGia.Text);
                CTPhieuNhapDTO ct = new CTPhieuNhapDTO();
                ct.MaPhieuNhap = maPhieu;
                ct.MaDauSach = maSach;
                ct.SoLuong = soluong;
                ct.DonGia = donGia;
                bool rs = bus.Update(ct);
                if (rs)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDanhSach();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tensach = txtSearch.Text.Trim();
            var result = bus.Search(MaPhieuHienTai,tensach);
            if (result == null || result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập nào phù hợp với từ khóa",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                dataGridView1.DataSource = null;
                ResetInput();
                return;
            }
            dataGridView1.DataSource = result;
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void CTPhieuNhapGUI_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            btnSearch_Click(this, EventArgs.Empty);
        }
    }
}
