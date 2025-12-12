using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.Components;
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
            InitializeActionButtons();
            LoadData();
        }

        /// <summary>
        /// Khởi tạo ActionButtonsUC
        /// </summary>
        private void InitializeActionButtons()
        {
            Panel panelActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(10, 5, 10, 5)
            };
            
            this.Controls.Add(panelActions);
            panelActions.BringToFront();
            
            CreateActionButtons(panelActions, DockStyle.Left);
        }

        private void SetupButtonPhanQuyen()
        {
            // Tạo nút Phân quyền
            btnPhanQuyen = new Button();
            btnPhanQuyen.Text = "🔐 Phân quyền";
            btnPhanQuyen.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnPhanQuyen.BackColor = Color.FromArgb(156, 39, 176); // Màu tím
            btnPhanQuyen.ForeColor = Color.White;
            btnPhanQuyen.FlatStyle = FlatStyle.Flat;
            btnPhanQuyen.FlatAppearance.BorderSize = 0;
            btnPhanQuyen.Cursor = Cursors.Hand;
            btnPhanQuyen.Size = new Size(140, 34);
            btnPhanQuyen.Location = new Point(btnLamMoi.Location.X + 125, btnLamMoi.Location.Y);
            btnPhanQuyen.Click += BtnPhanQuyen_Click;

            // Kiểm tra quyền admin - chỉ admin mới thấy nút này
            bool isAdmin = false;
            if (CurrentUser != null)
            {
                // Admin có MaNhomQuyen = 0 hoặc 1
                isAdmin = CurrentUser.MaNhomQuyen <= 1;
            }

            btnPhanQuyen.Visible = isAdmin;

            // Thêm nút vào panelTop
            panelTop.Controls.Add(btnPhanQuyen);
        }

        private void BtnPhanQuyen_Click(object sender, EventArgs e)
        {
            // Mở form phân quyền theo nhóm quyền
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

            // Styling
            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhanVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(229, 242, 253);
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 150, 243);
            dgvNhanVien.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dgvNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tất cả cells

            dgvNhanVien.Columns.Clear();

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNV",
                HeaderText = "Mã NV",
                Name = "colMaNV",
                Width = 50
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNV",
                HeaderText = "Họ và tên",
                Name = "colTenNV",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày sinh",
                Name = "colNgaySinh",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioiTinh",
                HeaderText = "Giới tính",
                Name = "colGioiTinh",
                Width = 60
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SDT",
                HeaderText = "Số điện thoại",
                Name = "colSDT",
                Width = 100
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "colEmail",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên ĐN",
                Name = "colTenDangNhap",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ChucVu",
                HeaderText = "Chức vụ",
                Name = "colChucVu",
                Width = 100
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "colTrangThai",
                Width = 140
            });
        }

        public override void LoadData()
        {
            try
            {
                DataTable dt = NhanVienBUS.Instance.GetAllNhanVien();
                dgvNhanVien.DataSource = dt;
                lblTongSo.Text = $"Tổng số: {dt.Rows.Count} nhân viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void OnAdd()
        {
            // Kiểm tra quyền trước
            if (!CoQuyenThem)
            {
                MessageBox.Show("Bạn không có quyền thêm nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormNhanVien frm = new FormNhanVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void OnEdit()
        {
            // Kiểm tra quyền trước
            if (!CoQuyenSua)
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNV <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NhanVienDTO nv = NhanVienBUS.Instance.GetNhanVienById(selectedMaNV);
                if (nv == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormNhanVien frm = new FormNhanVien(nv);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void OnDelete()
        {
            // Kiểm tra quyền trước
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Bạn không có quyền xóa nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNV <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (NhanVienBUS.Instance.XoaNhanVien(selectedMaNV))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        selectedMaNV = -1;
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void OnDetails()
        {
            // Kiểm tra quyền trước
            if (!CoQuyenXem)
            {
                MessageBox.Show("Bạn không có quyền xem chi tiết nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNV <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xem chi tiết!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NhanVienDTO nv = NhanVienBUS.Instance.GetNhanVienById(selectedMaNV);
                if (nv == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormNhanVien frm = new FormNhanVien(nv, true);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblTongSo.Text = $"Tìm thấy: {dt.Rows.Count} nhân viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}