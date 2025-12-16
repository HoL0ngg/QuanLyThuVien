using MySqlX.XDevAPI.Common;
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
    public partial class FormThemPhieuNhap : UserControl
    {
        private PhieuNhapBUS bus = new PhieuNhapBUS();
        private List<CTPhieuNhapDTO> listChiTiet = new List<CTPhieuNhapDTO>();
        private int maNhanVienDangNhap = 1;
        public event Action OnPhieuNhapAdded;
        public event EventHandler OnChiTietClosed;
        public FormThemPhieuNhap()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormThemPhieuNhap_Load);
            SetupDataGridView();
        }

        private void FormThemPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadNhacungCap();
            LoadSach();
            btnAdd.Click += new EventHandler(btnThemChiTiet_Click);
            btnLuu.Click += new EventHandler(btnThem);
            btnHuy.Click += new EventHandler(btnCancel);
            dtpDate.Value = DateTime.Now;
            
        }

        private void LoadNhanVien()
        {
            //string query = "SELECT MANV, TENNV FROM nhan_vien";
            //DataTable dt = DataProvider.ExecuteQuery(query);

            //dt.Columns.Add("MATEN", typeof(string), "MANV + ' - ' + TENNV");

            //cbMaNV.DataSource = dt;
            //cbMaNV.DisplayMember = "MATEN";
            //cbMaNV.ValueMember = "MANV";
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

        private void btnThem(object sender, EventArgs e)
        {
            try
            {
                if (cbMaNCC.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Nhà cung cấp.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (listChiTiet.Count == 0)
                {
                    MessageBox.Show("Phiếu nhập phải có ít nhất một chi tiết sách!", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PhieuNhapDTO pn = new PhieuNhapDTO
                {
                    ThoiGian = dtpDate.Value,
                    MaNV = maNhanVienDangNhap,
                    MaNCC = int.Parse(cbMaNCC.SelectedValue.ToString()),
                    TrangThai = "Đang chờ xử lý",
                    ct = listChiTiet
                };

                int maPhieuNhapMoi = bus.Insert(pn);

                if (maPhieuNhapMoi > 0)
                {
                    MessageBox.Show($"Thêm phiếu nhập thành công! Mã PN: {maPhieuNhapMoi}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetForm();

                    // Thông báo cho form cha/form quản lý để cập nhật lưới
                    OnPhieuNhapAdded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Không thể thêm phiếu nhập! Vui lòng kiểm tra log và CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            listChiTiet.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listChiTiet;

            dtpDate.Value = DateTime.Now;

            cbMaNCC.SelectedIndex = 0;
            cbTenSach.SelectedIndex = 0;

            txtSoLuong.Clear();
            txtDonGia.Clear();
        }
        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            ColMaSach.DataPropertyName = "MaDauSach";
            colTenSach.DataPropertyName = "TenSach";
            colSoLuong.DataPropertyName = "SoLuong";
            colDonGia.DataPropertyName = "DonGia";
            colThanhTien.DataPropertyName = "ThanhTien";

            dataGridView1.DataSource = listChiTiet;
        }
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Lỗi nhập liệu");
                return;
            }
            if (!double.TryParse(txtDonGia.Text, out double donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi nhập liệu");
                return;
            }
            if (cbTenSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một Đầu sách hợp lệ.", "Lỗi nhập liệu");
                return;
            }

            int maDauSach;
            if (!int.TryParse(cbTenSach.SelectedValue.ToString(), out maDauSach))
            {
                MessageBox.Show("Không lấy được Mã Đầu Sách. Vui lòng kiểm tra lại ComboBox.", "Lỗi dữ liệu");
                return;
            }

            string tenDauSachHienThi = cbTenSach.Text;
                
            string tenSach = tenDauSachHienThi.Contains(" - ") ?
                             tenDauSachHienThi.Substring(tenDauSachHienThi.IndexOf(" - ") + 3) :
                             tenDauSachHienThi;

            CTPhieuNhapDTO ct = new CTPhieuNhapDTO
            {
                MaDauSach = maDauSach,
                TenSach = tenSach,
                SoLuong = soLuong,
                DonGia = donGia
            };

            listChiTiet.Add(ct);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listChiTiet;

            txtSoLuong.Clear();
            txtDonGia.Clear();
            cbTenSach.Focus();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            TinhThanhTienVaTongTien();
        }

        private void TinhThanhTienVaTongTien()
        {
            double tongtien = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["colSoLuong"].Value != null && row.Cells["colDonGia"].Value != null)
                {
                    try
                    {
                        int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        double donGia = Convert.ToDouble(row.Cells["colDonGia"].Value);
                        double thanhTien = soLuong * donGia;
                        row.Cells["colThanhTien"].Value = thanhTien;

                        tongtien += thanhTien;
                    }
                    catch (Exception)
                    {

                    }
                }
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
        private void btnCancel(object sender, EventArgs e)
        {
            OnChiTietClosed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormThemPhieuNhap_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
