using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormAddPhieuPhat : Form
    {
        private List<PhieuTraViPhamDTO> allItems = new List<PhieuTraViPhamDTO>();
        private List<PhieuTraViPhamDTO> selectedItems = new List<PhieuTraViPhamDTO>();
        private bool editMode = false;
        private List<PhieuPhatDTO> editList = null;
        private BindingSource bs;
        private CheckBox headerCheckBox = null;

        public FormAddPhieuPhat()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            this.Load += FormAddPhieuPhat_Load;
        }

        public FormAddPhieuPhat(List<PhieuPhatDTO> phieuPhatToEdit)
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            this.Load += FormAddPhieuPhat_Load;
            editMode = true;
            editList = phieuPhatToEdit ?? new List<PhieuPhatDTO>();
        }

        private void FormAddPhieuPhat_Load(object sender, EventArgs e)
        {
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            SetupDataGridView();
            if (editMode)
                LoadExistingPhieuPhat();
            else
                LoadPhieuTraCanPhat();
            
            UpdateTongTien();
        }

        private void SetupDataGridView()
        {
            bs = new BindingSource();

            dgvChonPP.AutoGenerateColumns = false;
            dgvChonPP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChonPP.MultiSelect = true;
            dgvChonPP.AllowUserToAddRows = false;
            dgvChonPP.Dock = DockStyle.Fill;
            dgvChonPP.ScrollBars = ScrollBars.Both;
            dgvChonPP.EnableHeadersVisualStyles = false;
            dgvChonPP.RowTemplate.Height = 32;
            dgvChonPP.AllowUserToResizeRows = false;
            dgvChonPP.AllowUserToResizeColumns = true;
            dgvChonPP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChonPP.BackgroundColor = Color.White;
            dgvChonPP.BorderStyle = BorderStyle.None;

            dgvChonPP.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255);
            dgvChonPP.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChonPP.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvChonPP.ColumnHeadersHeight = 38;
            dgvChonPP.RowHeadersVisible = false;

            dgvChonPP.RowsDefaultCellStyle.BackColor = Color.White;
            dgvChonPP.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);

            dgvChonPP.Columns.Clear();

            // Checkbox column - để chọn phạt
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "colCheck",
                HeaderText = "Phạt",
                Width = 50,
                ReadOnly = false,
                FillWeight = 6
            };
            dgvChonPP.Columns.Add(checkColumn);

            if (!this.DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                AddHeaderCheckBox();
            }

            // Mã chi tiết
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaCT",
                HeaderText = "Mã",
                DataPropertyName = "MaCTPhieuTra",
                ReadOnly = true,
                FillWeight = 6,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Tên sách
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenSach",
                HeaderText = "Tên Sách",
                DataPropertyName = "TenSach",
                ReadOnly = true,
                FillWeight = 20,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            });

            // Độc giả
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenDG",
                HeaderText = "Độc Giả",
                DataPropertyName = "TenDocGia",
                ReadOnly = true,
                FillWeight = 14
            });

            // Ngày dự kiến
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayTraDuKien",
                HeaderText = "Hạn Trả",
                DataPropertyName = "NgayTraDuKien",
                ReadOnly = true,
                FillWeight = 10,
                DefaultCellStyle = { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Ngày thực tế
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayTra",
                HeaderText = "Ngày Trả",
                DataPropertyName = "NgayTra",
                ReadOnly = true,
                FillWeight = 10,
                DefaultCellStyle = { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Số ngày trễ
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoNgayTre",
                HeaderText = "Ngày Trễ",
                DataPropertyName = "SoNgayTre",
                ReadOnly = true,
                FillWeight = 8,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Trạng thái sách - text hiển thị (đã lưu trong DB)
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrangThaiSach",
                HeaderText = "Tình Trạng",
                ReadOnly = true,
                FillWeight = 10,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Tiền phạt
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTienPhat",
                HeaderText = "Tiền Phạt",
                DataPropertyName = "TienPhat",
                ReadOnly = true,
                FillWeight = 10,
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, 
                    ForeColor = Color.FromArgb(211, 47, 47), Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            });

            // Lý do
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLyDo",
                HeaderText = "Lý Do Phạt",
                DataPropertyName = "LyDo",
                ReadOnly = true,
                FillWeight = 16
            });

            dgvChonPP.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
            dgvChonPP.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvChonPP.Columns["colCheck"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvChonPP.CurrentCellDirtyStateChanged += DgvChonPP_CurrentCellDirtyStateChanged;
            dgvChonPP.CellValueChanged += DgvChonPP_CellValueChanged;
            dgvChonPP.CellFormatting += DgvChonPP_CellFormatting;
        }

        private void DgvChonPP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChonPP.Rows[e.RowIndex];
            var item = row.DataBoundItem as PhieuTraViPhamDTO;
            if (item == null) return;

            // Highlight dòng có vi phạm
            if (item.QuaHan || item.TrangThai == 2 || item.TrangThai == 3)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224);
            }

            // Màu cho cột số ngày trễ
            if (dgvChonPP.Columns[e.ColumnIndex].Name == "colSoNgayTre" && item.SoNgayTre > 0)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            // Màu cho cột tình trạng
            if (dgvChonPP.Columns[e.ColumnIndex].Name == "colTrangThaiSach")
            {
                if (item.TrangThai == 2)
                {
                    e.CellStyle.ForeColor = Color.Orange;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (item.TrangThai == 3)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void DgvChonPP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvChonPP.Columns[e.ColumnIndex].Name == "colCheck")
            {
                UpdateTongTien();
            }
        }

        private void DgvChonPP_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChonPP.IsCurrentCellDirty)
            {
                dgvChonPP.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void LoadPhieuTraCanPhat()
        {
            try
            {
                allItems = PhieuPhatBUS.Instance.GetDanhSachViPham();

                foreach (var item in allItems)
                {
                    item.LyDo = GenerateLyDoAuto(item);
                    item.TienPhat = CalculateFinePreview(item);
                }

                ApplyFilter();

                if (allItems.Count == 0)
                {
                    MessageBox.Show("Không có phiếu trả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            List<PhieuTraViPhamDTO> filteredList;

            if (chkChiHienViPham.Checked)
            {
                filteredList = allItems.Where(x => x.QuaHan || x.TrangThai == 2 || x.TrangThai == 3).ToList();
            }
            else
            {
                filteredList = allItems.ToList();
            }

            bs.DataSource = filteredList;
            dgvChonPP.DataSource = bs;

            foreach (DataGridViewRow row in dgvChonPP.Rows)
            {
                var item = row.DataBoundItem as PhieuTraViPhamDTO;
                if (item != null)
                {
                    row.Cells["colTrangThaiSach"].Value = GetTrangThaiText(item.TrangThai);
                    
                    // Tự động tick nếu có vi phạm
                    if (item.QuaHan || item.TrangThai == 2 || item.TrangThai == 3)
                    {
                        row.Cells["colCheck"].Value = true;
                    }
                }
            }

            UpdateTongTien();
        }

        private void chkChiHienViPham_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private string GenerateLyDoAuto(PhieuTraViPhamDTO item)
        {
            List<string> lyDo = new List<string>();

            if (item.QuaHan && item.SoNgayTre > 0)
            {
                lyDo.Add($"Trả trễ {item.SoNgayTre} ngày");
            }

            if (item.TrangThai == 2)
            {
                lyDo.Add("Sách hỏng");
            }
            else if (item.TrangThai == 3)
            {
                lyDo.Add("Làm mất sách");
            }

            return string.Join(", ", lyDo);
        }

        private int CalculateFinePreview(PhieuTraViPhamDTO item)
        {
            int tien = 0;
            
            // Phạt trễ: 5000đ/ngày
            if (item.QuaHan && item.SoNgayTre > 0)
            {
                tien += item.SoNgayTre * 5000;
            }
            
            // Phạt hỏng: 50000đ
            if (item.TrangThai == 2)
            {
                tien += 50000;
            }
            
            // Phạt mất: giá sách hoặc 100000đ mặc định
            if (item.TrangThai == 3)
            {
                tien += item.GiaSach > 0 ? item.GiaSach : 100000;
            }
            
            return tien;
        }

        private void UpdateTongTien()
        {
            int tongTien = 0;
            int soLuongChon = 0;

            foreach (DataGridViewRow row in dgvChonPP.Rows)
            {
                bool isChecked = row.Cells["colCheck"].Value != null && Convert.ToBoolean(row.Cells["colCheck"].Value);

                if (isChecked)
                {
                    soLuongChon++;
                    var item = row.DataBoundItem as PhieuTraViPhamDTO;
                    if (item != null)
                    {
                        tongTien += item.TienPhat;
                    }
                }
            }

            lblTongTienValue.Text = tongTien.ToString("N0") + " đ";
            lblSoLuongChon.Text = $"Đã chọn: {soLuongChon} sách";

            if (tongTien > 0)
            {
                lblTongTienValue.ForeColor = Color.FromArgb(211, 47, 47);
                panelTongTien.BackColor = Color.FromArgb(255, 235, 238);
            }
            else
            {
                lblTongTienValue.ForeColor = Color.FromArgb(76, 175, 80);
                panelTongTien.BackColor = Color.FromArgb(232, 245, 233);
            }
        }

        private void LoadExistingPhieuPhat()
        {
            dgvChonPP.Rows.Clear();
            foreach (var item in editList)
            {
                int rowIndex = dgvChonPP.Rows.Add();
                dgvChonPP.Rows[rowIndex].Cells["colCheck"].Value = false;
                dgvChonPP.Rows[rowIndex].Cells["colMaCT"].Value = item.MaCTPhieuPhat;
                dgvChonPP.Rows[rowIndex].Cells["colTenSach"].Value = item.TenSach;
                dgvChonPP.Rows[rowIndex].Cells["colTenDG"].Value = item.TenDG;
                dgvChonPP.Rows[rowIndex].Cells["colNgayTraDuKien"].Value = item.NgayPhat;
                dgvChonPP.Rows[rowIndex].Cells["colNgayTra"].Value = item.NgayTra == DateTime.MinValue ? (object)"" : item.NgayTra;
                dgvChonPP.Rows[rowIndex].Cells["colSoNgayTre"].Value = 0;
                dgvChonPP.Rows[rowIndex].Cells["colTrangThaiSach"].Value = "Bình thường";
                dgvChonPP.Rows[rowIndex].Cells["colTienPhat"].Value = item.tienPhat;
                dgvChonPP.Rows[rowIndex].Cells["colLyDo"].Value = item.LydoPhat ?? "";
                dgvChonPP.Rows[rowIndex].Tag = item;
            }

            if (editList.Count == 0)
            {
                MessageBox.Show("Không có phiếu phạt trạng thái 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetTrangThaiText(int trangThai)
        {
            switch (trangThai)
            {
                case 2: return "Hỏng";
                case 3: return "Mất";
                default: return "Bình thường";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLuuCPP_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                selectedItems.Clear();

                foreach (DataGridViewRow row in dgvChonPP.Rows)
                {
                    bool isChecked = row.Cells["colCheck"].Value != null && Convert.ToBoolean(row.Cells["colCheck"].Value);

                    if (isChecked)
                    {
                        var item = row.DataBoundItem as PhieuTraViPhamDTO;
                        if (item != null)
                        {
                            if (item.MaDG == 0)
                            {
                                MessageBox.Show("Lỗi: Dữ liệu bị thiếu MaDG!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (item.QuaHan || item.TrangThai == 2 || item.TrangThai == 3 || item.TienPhat > 0)
                            {
                                selectedItems.Add(item);
                            }
                        }
                    }
                }

                if (selectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sách có vi phạm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int tongTien = selectedItems.Sum(x => x.TienPhat);
                var confirmResult = MessageBox.Show(
                    $"Xác nhận tạo {selectedItems.Count} phiếu phạt với tổng tiền {tongTien:N0} đ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes) return;

                try
                {
                    bool ok = PhieuPhatBUS.Instance.CreatePhieuPhatFromViolations(selectedItems);
                    if (ok)
                    {
                        MessageBox.Show($"Đã lưu {selectedItems.Count} phiếu phạt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lưu phiếu phạt thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Edit mode - đóng phiếu phạt
                var toUpdate = new List<int>();
                foreach (DataGridViewRow row in dgvChonPP.Rows)
                {
                    bool isChecked = row.Cells["colCheck"].Value != null && Convert.ToBoolean(row.Cells["colCheck"].Value);

                    if (isChecked)
                    {
                        var dto = (row.Tag ?? row.DataBoundItem) as PhieuPhatDTO;
                        if (dto != null)
                            toUpdate.Add(dto.MaPhieuPhat);
                    }
                }

                if (toUpdate.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một phiếu để đóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool allOk = toUpdate.All(id => PhieuPhatBUS.Instance.DongPhieuPhat(id));

                if (allOk)
                {
                    MessageBox.Show("Đã cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddHeaderCheckBox()
        {
            headerCheckBox = new CheckBox
            {
                Size = new Size(15, 15),
                BackColor = Color.Transparent
            };
            dgvChonPP.Controls.Add(headerCheckBox);
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
            dgvChonPP.Paint += DgvChonPP_Paint;
        }

        private void DgvChonPP_Paint(object sender, PaintEventArgs e)
        {
            if (headerCheckBox == null) return;
            Rectangle rect = dgvChonPP.GetCellDisplayRectangle(0, -1, true);
            headerCheckBox.Location = new Point(
                rect.Location.X + (rect.Width - headerCheckBox.Width) / 2,
                rect.Location.Y + (rect.Height - headerCheckBox.Height) / 2
            );
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvChonPP.Rows)
            {
                row.Cells["colCheck"].Value = headerCheckBox.Checked;
            }
            UpdateTongTien();
        }
    }
}
