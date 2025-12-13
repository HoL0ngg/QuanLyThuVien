using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormAddPhieuPhat : Form
    {   private int _id;        // Lưu Mã Phiếu Trả (nếu chưa lưu) HOẶC Mã Phiếu Phạt (nếu đã lưu)
    private bool _isHistory;
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
                HeaderText = "",
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
                Name = "colMaPT",
                HeaderText = "Mã Phiếu Trả",
                DataPropertyName = "MaPhieuTra",
                ReadOnly = true,
                FillWeight = 15,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Tên sách
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaDG",
                HeaderText = "Mã Độc Giả",
                DataPropertyName = "MaDG",
                ReadOnly = true,
                FillWeight = 10,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            });

            // Độc giả
            dgvChonPP.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenDG",
                HeaderText = "Độc Giả",
                DataPropertyName = "TenDocGia",
                ReadOnly = true,
                FillWeight = 15
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

            // Highlight dòng có vi phạm (dùng dữ liệu DTO chứ không truy vấn cột cụ thể)
            if (item.QuaHan || item.TrangThai == 2 || item.TrangThai == 3)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224);
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
                    // 1. Tạo lý do tự động (Giữ nguyên)
                    item.LyDo = GenerateLyDoAuto(item);

                    // 2. THAY ĐỔI Ở ĐÂY: Không dùng CalculateFinePreview nữa
                    // Gọi hàm lấy chi tiết chúng ta đã viết để tính tổng tiền chính xác
                    item.TienPhat = GetExactTotalFine(item.MaPhieuTra);
                }

                ApplyFilter();

                if (allItems.Count == 0)
                {
                    MessageBox.Show("Không có phiếu trả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private int GetExactTotalFine(int maPhieuTra)
        {
            int tongTien = 0;
            try
            {
                // Gọi lại hàm GetChiTietPhieuPhat từ BUS mà bạn đã viết ở bước trước
                DataTable dt = PhieuPhatBUS.Instance.GetChiTietPhieuPhat(maPhieuTra);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Duyệt qua DataTable để cộng dồn cột "TongTienPhat"
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TongTienPhat"] != DBNull.Value)
                        {
                            tongTien += Convert.ToInt32(row["TongTienPhat"]);
                        }
                    }
                }
            }
            catch
            {
                // Nếu lỗi thì trả về 0 hoặc xử lý tùy ý
                tongTien = 0;
            }
            return tongTien;
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

            // Không gán vào cột không tồn tại. Nếu muốn hiển thị text trạng thái, thêm 1 column bindable hoặc xử lý qua template.
            foreach (DataGridViewRow row in dgvChonPP.Rows)
            {
                var item = row.DataBoundItem as PhieuTraViPhamDTO;
                if (item != null)
                {
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

                // Map tới các cột thực sự có trong SetupDataGridView()
                dgvChonPP.Rows[rowIndex].Cells["colMaPT"].Value = item.MaPhieuPhat;
                dgvChonPP.Rows[rowIndex].Cells["colMaDG"].Value = item.MaDG;
                dgvChonPP.Rows[rowIndex].Cells["colTenDG"].Value = item.TenDG;
                dgvChonPP.Rows[rowIndex].Cells["colTienPhat"].Value = item.tienPhat;
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
        private void btnDetail_Click(object sender, EventArgs e)
        {
            // 1. Lấy dòng đang chọn (Ưu tiên SelectedRows, sau đó đến CurrentRow)
            DataGridViewRow row = null;
            if (dgvChonPP.SelectedRows != null && dgvChonPP.SelectedRows.Count > 0)
                row = dgvChonPP.SelectedRows[0];
            else if (dgvChonPP.CurrentRow != null)
                row = dgvChonPP.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Xác định ID và Chế độ (Xem trước hay Xem đã lưu)
            int id = 0;
            bool isHistory = false; // Mặc định là xem trước (chưa lưu)

            // Kiểm tra xem dòng đó chứa dữ liệu gì
            var dataItem = row.DataBoundItem ?? row.Tag;

            if (dataItem is PhieuTraViPhamDTO phieuTra)
            {
                // Trường hợp: Dữ liệu lấy từ bảng Phiếu Trả (Chưa lưu thành phạt)
                id = phieuTra.MaPhieuTra;
                isHistory = false; // -> Mode False: Tính toán xem trước
            }
            else if (dataItem is PhieuPhatDTO phieuPhat)
            {
                // Trường hợp: Dữ liệu là Phiếu Phạt đã tồn tại (Chế độ sửa)
                id = phieuPhat.MaPhieuPhat;
                isHistory = true;  // -> Mode True: Lấy từ DB
            }

            // 3. Kiểm tra ID hợp lệ
            if (id <= 0)
            {
                MessageBox.Show("Không tìm được mã phiếu hợp lệ để xem chi tiết.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Mở FormChiTietPhieuPhat với tham số đúng
            try
            {
                // Truyền ID và biến cờ isHistory vào Constructor
                using (var f = new FormChiTietPhieuPhat(id, isHistory))
                {
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            // Commit any active edit so the first row's checkbox isn't left in edit state
            if (dgvChonPP.IsCurrentCellInEditMode)
            {
                try { dgvChonPP.EndEdit(); } catch { }
            }

            bool isChecked = headerCheckBox.Checked;

            dgvChonPP.SuspendLayout();
            foreach (DataGridViewRow row in dgvChonPP.Rows)
            {
                if (row.IsNewRow) continue; // skip new row if allowed
                row.Cells["colCheck"].Value = isChecked;
            }
            dgvChonPP.ResumeLayout();
            dgvChonPP.Refresh();

            UpdateTongTien();
        }
    }
}
