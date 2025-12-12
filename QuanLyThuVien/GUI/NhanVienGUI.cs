using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class NhanVienGUI : BaseModuleUC
    {
        private int selectedMaNV = -1;
        private Button btnPhanQuyen;

        public NhanVienGUI()
        {
            InitializeComponent();
            this.Load += NhanVienGUI_Load;
        }

        public NhanVienGUI(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            SetupButtonPhanQuyen();
            LoadData();
        }

        private void SetupButtonPhanQuyen()
        {
            btnPhanQuyen = new Button();
            btnPhanQuyen.Text = "Phân quyền";
            btnPhanQuyen.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnPhanQuyen.BackColor = Color.FromArgb(156, 39, 176);
            btnPhanQuyen.ForeColor = Color.White;
            btnPhanQuyen.FlatStyle = FlatStyle.Flat;
            btnPhanQuyen.FlatAppearance.BorderSize = 0;
            btnPhanQuyen.Cursor = Cursors.Hand;
            btnPhanQuyen.Size = new Size(140, 34);
            btnPhanQuyen.Location = new Point(btnLamMoi.Location.X + 125, btnLamMoi.Location.Y);
            btnPhanQuyen.Click += BtnPhanQuyen_Click;

            bool isAdmin = CurrentUser != null && CurrentUser.MaNhomQuyen <= 1;
            btnPhanQuyen.Visible = isAdmin;

            panelTop.Controls.Add(btnPhanQuyen);
        }

        private void BtnPhanQuyen_Click(object sender, EventArgs e)
        {
            using (var frm = new FormPhanQuyen())
            {
                frm.ShowDialog();
            }
        }

        private void SetupDataGridView()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.BorderStyle = BorderStyle.None;
            dgvNhanVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNhanVien.ColumnHeadersHeight = 40;
            dgvNhanVien.RowTemplate.Height = 35;

            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhanVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 242, 253);
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 150, 243);
            dgvNhanVien.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dgvNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhanVien.Columns.Clear();

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNV", HeaderText = "Ma NV", Name = "colMaNV", Width = 50 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNV", HeaderText = "Ho va ten", Name = "colTenNV", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft } });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgaySinh", HeaderText = "Ngay sinh", Name = "colNgaySinh", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GioiTinh", HeaderText = "Gioi tinh", Name = "colGioiTinh", Width = 60 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SDT", HeaderText = "So dien thoai", Name = "colSDT", Width = 100 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "colEmail", Width = 160, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft } });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDangNhap", HeaderText = "Ten DN", Name = "colTenDangNhap", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft } });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ChucVu", HeaderText = "Chuc vu", Name = "colChucVu", Width = 100 });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trang thai", Name = "colTrangThai", Width = 140 });
        }

        public override void LoadData()
        {
            try
            {
                DataTable dt = NhanVienBUS.Instance.GetAllNhanVien();
                dgvNhanVien.DataSource = dt;
                lblTongSo.Text = "Tong so: " + dt.Rows.Count + " nhan vien";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai du lieu: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Ban khong co quyen them nhan vien!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormNhanVien frm = new FormNhanVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Them nhan vien thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void OnEdit()
        {
            if (!CoQuyenSua)
            {
                MessageBox.Show("Ban khong co quyen chinh sua nhan vien!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNV <= 0)
            {
                MessageBox.Show("Vui long chon nhan vien can sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NhanVienDTO nv = NhanVienBUS.Instance.GetNhanVienById(selectedMaNV);
                if (nv == null)
                {
                    MessageBox.Show("Khong tim thay nhan vien!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormNhanVien frm = new FormNhanVien(nv);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Cap nhat nhan vien thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Ban khong co quyen xoa nhan vien!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNV <= 0)
            {
                MessageBox.Show("Vui long chon nhan vien can xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Ban co chac muon xoa nhan vien nay?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (NhanVienBUS.Instance.XoaNhanVien(selectedMaNV))
                    {
                        MessageBox.Show("Xoa nhan vien thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        selectedMaNV = -1;
                    }
                    else
                    {
                        MessageBox.Show("Xoa nhan vien that bai!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void OnDetails()
        {
            if (!CoQuyenXem)
            {
                MessageBox.Show("Ban khong co quyen xem chi tiet nhan vien!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNV <= 0)
            {
                MessageBox.Show("Vui long chon nhan vien de xem chi tiet!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NhanVienDTO nv = NhanVienBUS.Instance.GetNhanVienById(selectedMaNV);
                if (nv == null)
                {
                    MessageBox.Show("Khong tim thay nhan vien!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormNhanVien frm = new FormNhanVien(nv, true);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedMaNV = Convert.ToInt32(dgvNhanVien.Rows[e.RowIndex].Cells["colMaNV"].Value);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
            selectedMaNV = -1;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                DataTable dt = NhanVienBUS.Instance.TimKiemNhanVien(keyword);
                dgvNhanVien.DataSource = dt;
                lblTongSo.Text = "Tim thay: " + dt.Rows.Count + " nhan vien";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tim kiem: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}