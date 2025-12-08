using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormPhanQuyen : Form
    {
        private List<NhomQuyenDTO> danhSachNhomQuyen;
        private List<QuyenChucNangDTO> danhSachQuyen;
        private int selectedMaNhomQuyen = -1;

        public FormPhanQuyen()
        {
            InitializeComponent();
            this.Load += FormPhanQuyen_Load;
        }

        private void FormPhanQuyen_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadNhomQuyen();
        }

        private void LoadNhomQuyen()
        {
            try
            {
                var allNhomQuyen = NhomQuyenBUS.Instance.GetAllNhomQuyen();
                
                // LINQ: Lọc bỏ nhóm Admin (MaNhomQuyen = 1) khỏi danh sách
                danhSachNhomQuyen = allNhomQuyen
                    .Where(nq => nq.MaNhomQuyen > 1)
                    .ToList();
                
                cboNhomQuyen.DataSource = null;
                cboNhomQuyen.DataSource = danhSachNhomQuyen;
                cboNhomQuyen.DisplayMember = "TenNhomQuyen";
                cboNhomQuyen.ValueMember = "MaNhomQuyen";

                if (cboNhomQuyen.Items.Count > 0)
                {
                    cboNhomQuyen.SelectedIndex = 0;
                }
                else
                {
                    // Không có nhóm quyền nào (ngoài Admin)
                    dgvQuyen.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhóm quyền: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvQuyen.AutoGenerateColumns = false;
            dgvQuyen.AllowUserToAddRows = false;
            dgvQuyen.AllowUserToDeleteRows = false;
            dgvQuyen.AllowUserToResizeColumns = false;
            dgvQuyen.AllowUserToResizeRows = false;
            dgvQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuyen.MultiSelect = false;
            dgvQuyen.BackgroundColor = Color.White;
            dgvQuyen.BorderStyle = BorderStyle.None;
            dgvQuyen.RowHeadersVisible = false;
            dgvQuyen.ColumnHeadersHeight = 40;
            dgvQuyen.RowTemplate.Height = 35;
            dgvQuyen.ScrollBars = ScrollBars.Vertical;

            // Styling header
            dgvQuyen.EnableHeadersVisualStyles = false;
            dgvQuyen.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176);
            dgvQuyen.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvQuyen.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvQuyen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvQuyen.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 190, 240);
            dgvQuyen.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvQuyen.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            dgvQuyen.Columns.Clear();

            // Cột Mã chức năng (ẩn)
            dgvQuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaCN",
                HeaderText = "Mã",
                DataPropertyName = "MaChucNang",
                Width = 40,
                ReadOnly = true,
                Visible = false
            });

            // Cột Tên chức năng - Fill để chiếm hết không gian còn lại
            var colTenCN = new DataGridViewTextBoxColumn
            {
                Name = "colTenCN",
                HeaderText = "Chức năng",
                DataPropertyName = "TenChucNang",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 150
            };
            colTenCN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colTenCN.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvQuyen.Columns.Add(colTenCN);

            // Cột Quyền Xem
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenXem",
                HeaderText = "Xem",
                DataPropertyName = "QuyenXem",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // Cột Quyền Thêm
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenThem",
                HeaderText = "Thêm",
                DataPropertyName = "QuyenThem",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // Cột Quyền Sửa
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenSua",
                HeaderText = "Sửa",
                DataPropertyName = "QuyenSua",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // Cột Quyền Xóa
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenXoa",
                HeaderText = "Xóa",
                DataPropertyName = "QuyenXoa",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // Event khi thay đổi giá trị checkbox
            dgvQuyen.CellValueChanged += DgvQuyen_CellValueChanged;
            dgvQuyen.CurrentCellDirtyStateChanged += DgvQuyen_CurrentCellDirtyStateChanged;
        }

        private void DgvQuyen_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvQuyen.IsCurrentCellDirty)
            {
                dgvQuyen.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvQuyen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || danhSachQuyen == null) return;

            // Cập nhật giá trị từ DataGridView vào DTO
            var row = dgvQuyen.Rows[e.RowIndex];
            var quyen = danhSachQuyen[e.RowIndex];
            
            quyen.QuyenXem = Convert.ToBoolean(row.Cells["colQuyenXem"].Value ?? false);
            quyen.QuyenThem = Convert.ToBoolean(row.Cells["colQuyenThem"].Value ?? false);
            quyen.QuyenSua = Convert.ToBoolean(row.Cells["colQuyenSua"].Value ?? false);
            quyen.QuyenXoa = Convert.ToBoolean(row.Cells["colQuyenXoa"].Value ?? false);
        }

        private void cboNhomQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhomQuyen.SelectedValue == null) return;

            try
            {
                selectedMaNhomQuyen = Convert.ToInt32(cboNhomQuyen.SelectedValue);
                LoadQuyenByNhomQuyen(selectedMaNhomQuyen);
            }
            catch { }
        }

        private void LoadQuyenByNhomQuyen(int maNhomQuyen)
        {
            try
            {
                danhSachQuyen = NhomQuyenBUS.Instance.GetQuyenByNhomQuyen(maNhomQuyen);
                dgvQuyen.DataSource = null;
                dgvQuyen.DataSource = danhSachQuyen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải quyền: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (selectedMaNhomQuyen < 0 || danhSachQuyen == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho sửa quyền Admin (mã <= 1)
            if (selectedMaNhomQuyen <= 1)
            {
                MessageBox.Show("Không thể thay đổi quyền của nhóm Admin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // LINQ: Đếm số lượng thành công/thất bại
                int successCount = danhSachQuyen
                    .Count(quyen => NhomQuyenBUS.Instance.UpdateQuyenChucNang(quyen));
                int failCount = danhSachQuyen.Count - successCount;

                if (failCount == 0)
                {
                    MessageBox.Show($"Đã lưu thành công quyền cho {successCount} chức năng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Thành công: {successCount}, Thất bại: {failCount}", "Kết quả",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnThemNhomQuyen_Click(object sender, EventArgs e)
        {
            using (var frm = new FormThemNhomQuyen())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadNhomQuyen();
                }
            }
        }

        private void btnXoaNhomQuyen_Click(object sender, EventArgs e)
        {
            if (selectedMaNhomQuyen < 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNhomQuyen <= 1)
            {
                MessageBox.Show("Không thể xóa nhóm quyền Admin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedNhomQuyen = cboNhomQuyen.SelectedItem as NhomQuyenDTO;
            string tenNQ = selectedNhomQuyen?.TenNhomQuyen ?? "";

            var result = MessageBox.Show($"Bạn có chắc muốn xóa nhóm quyền '{tenNQ}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (NhomQuyenBUS.Instance.XoaNhomQuyen(selectedMaNhomQuyen))
                    {
                        MessageBox.Show("Xóa nhóm quyền thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhomQuyen();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
