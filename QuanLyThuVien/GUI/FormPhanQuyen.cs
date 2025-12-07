using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                danhSachNhomQuyen = NhomQuyenBUS.Instance.GetAllNhomQuyen();
                cboNhomQuyen.DataSource = null;
                cboNhomQuyen.DataSource = danhSachNhomQuyen;
                cboNhomQuyen.DisplayMember = "TenNhomQuyen";
                cboNhomQuyen.ValueMember = "MaNhomQuyen";

                if (cboNhomQuyen.Items.Count > 0)
                {
                    cboNhomQuyen.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i danh sách nhóm quy?n: " + ex.Message, "L?i",
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

            // C?t Mã ch?c n?ng (?n)
            dgvQuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaCN",
                HeaderText = "Mã",
                DataPropertyName = "MaChucNang",
                Width = 40,
                ReadOnly = true,
                Visible = false
            });

            // C?t Tên ch?c n?ng - Fill ?? chi?m h?t không gian còn l?i
            var colTenCN = new DataGridViewTextBoxColumn
            {
                Name = "colTenCN",
                HeaderText = "Ch?c n?ng",
                DataPropertyName = "TenChucNang",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 150
            };
            colTenCN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colTenCN.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvQuyen.Columns.Add(colTenCN);

            // C?t Quy?n Xem
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenXem",
                HeaderText = "Xem",
                DataPropertyName = "QuyenXem",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // C?t Quy?n Thêm
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenThem",
                HeaderText = "Thêm",
                DataPropertyName = "QuyenThem",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // C?t Quy?n S?a
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenSua",
                HeaderText = "S?a",
                DataPropertyName = "QuyenSua",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // C?t Quy?n Xóa
            dgvQuyen.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colQuyenXoa",
                HeaderText = "Xóa",
                DataPropertyName = "QuyenXoa",
                Width = 60,
                TrueValue = true,
                FalseValue = false
            });

            // Event khi thay ??i giá tr? checkbox
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

            // C?p nh?t giá tr? t? DataGridView vào DTO
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
                MessageBox.Show("L?i t?i quy?n: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (selectedMaNhomQuyen < 0 || danhSachQuyen == null)
            {
                MessageBox.Show("Vui lòng ch?n nhóm quy?n!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho s?a quy?n Admin (mã = 0 ho?c 1)
            if (selectedMaNhomQuyen <= 1)
            {
                MessageBox.Show("Không th? thay ??i quy?n c?a nhóm Admin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int successCount = 0;
                int failCount = 0;

                foreach (var quyen in danhSachQuyen)
                {
                    if (NhomQuyenBUS.Instance.UpdateQuyenChucNang(quyen))
                        successCount++;
                    else
                        failCount++;
                }

                if (failCount == 0)
                {
                    MessageBox.Show("?ã l?u thành công quy?n cho " + successCount + " ch?c n?ng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thành công: " + successCount + ", Th?t b?i: " + failCount, "K?t qu?",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i",
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
                MessageBox.Show("Vui lòng ch?n nhóm quy?n c?n xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaNhomQuyen <= 1)
            {
                MessageBox.Show("Không th? xóa nhóm quy?n Admin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedNhomQuyen = cboNhomQuyen.SelectedItem as NhomQuyenDTO;
            string tenNQ = selectedNhomQuyen?.TenNhomQuyen ?? "";

            var result = MessageBox.Show("B?n có ch?c mu?n xóa nhóm quy?n '" + tenNQ + "'?",
                "Xác nh?n xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (NhomQuyenBUS.Instance.XoaNhomQuyen(selectedMaNhomQuyen))
                    {
                        MessageBox.Show("Xóa nhóm quy?n thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhomQuyen();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i: " + ex.Message, "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
