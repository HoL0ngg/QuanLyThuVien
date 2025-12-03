using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormNhanVien : Form
    {
        private NhanVienDTO nhanVien;
        private bool isViewOnly;

        public FormNhanVien()
        {
            InitializeComponent();
            this.nhanVien = new NhanVienDTO();
            this.isViewOnly = false;
            this.Text = "Thêm nhân viên mới";
        }

        public FormNhanVien(NhanVienDTO nv, bool viewOnly = false)
        {
            InitializeComponent();
            this.nhanVien = nv;
            this.isViewOnly = viewOnly;
            this.Text = viewOnly ? "Chi tiết nhân viên" : "Cập nhật nhân viên";
            LoadData();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Setup combobox
            cboGioiTinh.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
            cboTrangThai.Items.AddRange(new[] { "Đang làm việc", "Nghỉ việc" });

            if (nhanVien.MaNV == 0)
            {
                dtpNgaySinh.Value = new DateTime(1990, 1, 1);
                cboGioiTinh.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;
            }

            if (isViewOnly)
            {
                SetReadOnly();
            }
        }

        private void LoadData()
        {
            if (nhanVien == null) return;

            txtTenNV.Text = nhanVien.TenNV;
            dtpNgaySinh.Value = nhanVien.NgaySinh;
            cboGioiTinh.Text = nhanVien.GioiTinh;
            txtDiaChi.Text = nhanVien.DiaChi;
            txtSDT.Text = nhanVien.SDT;
            txtEmail.Text = nhanVien.Email;
            cboTrangThai.SelectedIndex = nhanVien.TrangThai;
        }

        private void SetReadOnly()
        {
            txtTenNV.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cboTrangThai.Enabled = false;
            btnLuu.Visible = false;
            btnHuy.Text = "Đóng";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                nhanVien.TenNV = txtTenNV.Text.Trim();
                nhanVien.NgaySinh = dtpNgaySinh.Value;
                nhanVien.GioiTinh = cboGioiTinh.Text;
                nhanVien.DiaChi = txtDiaChi.Text.Trim();
                nhanVien.SDT = txtSDT.Text.Trim();
                nhanVien.Email = txtEmail.Text.Trim();
                nhanVien.TrangThai = cboTrangThai.SelectedIndex;

                bool result = nhanVien.MaNV == 0
                    ? NhanVienBUS.Instance.ThemNhanVien(nhanVien)
                    : NhanVienBUS.Instance.SuaNhanVien(nhanVien);

                if (result)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}