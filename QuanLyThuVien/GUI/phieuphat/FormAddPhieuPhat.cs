using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class FormAddPhieuPhat : Form
    {
        private List<PhieuTraViPhamDTO> selectedItems = new List<PhieuTraViPhamDTO>();
        private bool editMode = false;
        private List<PhieuPhatDTO> editList = null;
        // File: FormAddPhieuPhat.cs
        // Thêm vào phần field của class FormAddPhieuPhat
        private BindingSource bs; // khởi tạo ở runtime để tránh Designer cố serialize
        private CheckBox headerCheckBox = null; // checkbox ở header để chọn tất cả
        public FormAddPhieuPhat()
        {
            InitializeComponent();
            // Tránh chạy code runtime trong Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Ensure setup runs when form is created
            this.Load += FormAddPhieuPhat_Load;
        }

        // New constructor for edit mode: pass list of PhieuPhatDTO trạng thái = 0
        public FormAddPhieuPhat(List<PhieuPhatDTO> phieuPhatToEdit)
        {
            InitializeComponent();
            // Tránh chạy code runtime trong Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            this.Load += FormAddPhieuPhat_Load;
            editMode = true;
            editList = phieuPhatToEdit ?? new List<PhieuPhatDTO>();
        }

        private void FormAddPhieuPhat_Load(object sender, EventArgs e)
        {
            // Không chạy các thiết lập runtime khi đang ở chế độ thiết kế trong Visual Studio
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            SetupDataGridView();
            if (editMode)
                LoadExistingPhieuPhat();
            else
                LoadPhieuTraCanPhat();
        }

        private void SetupDataGridView()
        {
            // Tạo BindingSource ở runtime
            bs = new BindingSource();

            // Cấu hình cơ bản
            dgvChonPP.AutoGenerateColumns = false;
            dgvChonPP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChonPP.MultiSelect = true;
            dgvChonPP.AllowUserToAddRows = false;
            dgvChonPP.Dock = DockStyle.Fill;
            dgvChonPP.ScrollBars = ScrollBars.Vertical;
            dgvChonPP.EnableHeadersVisualStyles = false;
            dgvChonPP.RowTemplate.Height = 28;
            dgvChonPP.AllowUserToResizeRows = false;
            dgvChonPP.AllowUserToResizeColumns = true;
            dgvChonPP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChonPP.BackgroundColor = Color.White;
            dgvChonPP.BorderStyle = BorderStyle.None;

            // Style header
            dgvChonPP.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255);
            dgvChonPP.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChonPP.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvChonPP.ColumnHeadersHeight = 36;
            dgvChonPP.RowHeadersVisible = false;

            // Alternating row color
            dgvChonPP.RowsDefaultCellStyle.BackColor = Color.White;
            dgvChonPP.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);

            dgvChonPP.Columns.Clear();

            // Checkbox column (cột 0)
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "colCheck",
                HeaderText = "",
                Width = 40,
                ReadOnly = false,
                FillWeight = 10
            };
            dgvChonPP.Columns.Add(checkColumn);
            // Chỉ thêm header checkbox khi runtime (không phải ở thiết kế)
            if (!this.DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                AddHeaderCheckBox(); // thêm checkbox ở header
            }

            // Mã chi tiết
            DataGridViewTextBoxColumn colMaCT = new DataGridViewTextBoxColumn
            {
                Name = "colMaCT",
                HeaderText = "Mã CT",
                DataPropertyName = "MaCTPhieuTra",
                ReadOnly = true,
                FillWeight = 12,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvChonPP.Columns.Add(colMaCT);

            // Tên sách
            DataGridViewTextBoxColumn colTenSach = new DataGridViewTextBoxColumn
            {
                Name = "colTenSach",
                HeaderText = "Tên Sách",
                DataPropertyName = "TenSach",
                ReadOnly = true,
                FillWeight = 30,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };
            dgvChonPP.Columns.Add(colTenSach);

            // Độc giả
            DataGridViewTextBoxColumn colTenDG = new DataGridViewTextBoxColumn
            {
                Name = "colTenDG",
                HeaderText = "Độc Giả",
                DataPropertyName = "TenDocGia",
                ReadOnly = true,
                FillWeight = 20
            };
            dgvChonPP.Columns.Add(colTenDG);

            // Ngày dự kiến
            DataGridViewTextBoxColumn colNgayTraDuKien = new DataGridViewTextBoxColumn
            {
                Name = "colNgayTraDuKien",
                HeaderText = "Ngày Dự Kiến",
                DataPropertyName = "NgayTraDuKien",
                ReadOnly = true,
                FillWeight = 18,
                DefaultCellStyle = { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvChonPP.Columns.Add(colNgayTraDuKien);

            // Ngày thực tế
            DataGridViewTextBoxColumn colNgayTra = new DataGridViewTextBoxColumn
            {
                Name = "colNgayTra",
                HeaderText = "Ngày Thực Tế",
                DataPropertyName = "NgayTra",
                ReadOnly = true,
                FillWeight = 18,
                DefaultCellStyle = { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvChonPP.Columns.Add(colNgayTra);

            // Trạng thái
            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn
            {
                Name = "colTrangThai",
                HeaderText = "Trạng Thái",
                DataPropertyName = "TrangThai",
                ReadOnly = true,
                FillWeight = 14,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvChonPP.Columns.Add(colTrangThai);

            // Tiền phạt
            DataGridViewTextBoxColumn colTienPhat = new DataGridViewTextBoxColumn
            {
                Name = "colTienPhat",
                HeaderText = "Tiền phạt",
                DataPropertyName = "TienPhat",
                ReadOnly = false,
                FillWeight = 18,
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dgvChonPP.Columns.Add(colTienPhat);

            // Lý do
            DataGridViewTextBoxColumn colLyDo = new DataGridViewTextBoxColumn
            {
                Name = "colLyDo",
                HeaderText = "Lý Do Phạt",
                DataPropertyName = "LyDo",
                ReadOnly = false,
                FillWeight = 28,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };
            dgvChonPP.Columns.Add(colLyDo);

            // Selection color
            dgvChonPP.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 229, 255);
            dgvChonPP.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Disable sorting cho checkbox và cột wrap text nếu muốn
            dgvChonPP.Columns["colCheck"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvChonPP.Columns["colLyDo"].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Khi click ô checkbox, commit ngay để giá trị cập nhật
            dgvChonPP.CellContentClick += dataGridView1_CellContentClick;
            dgvChonPP.CurrentCellDirtyStateChanged += DgvChonPP_CurrentCellDirtyStateChanged;
        }

        private void DgvChonPP_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChonPP.IsCurrentCellDirty && dgvChonPP.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvChonPP.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        //private void LoadPhieuTraCanPhat()
        //{
        //    try
        //    {
        //        List<PhieuTraViPhamDTO> list = PhieuPhatBUS.Instance.GetDanhSachViPham();

        //        dgvChonPP.Rows.Clear();
        //        foreach (var item in list)
        //        {
        //            int rowIndex = dgvChonPP.Rows.Add();
        //            dgvChonPP.Rows[rowIndex].Cells["colCheck"].Value = false;
        //            dgvChonPP.Rows[rowIndex].Cells["colMaCT"].Value = item.MaCTPhieuTra;
        //            dgvChonPP.Rows[rowIndex].Cells["colTenSach"].Value = item.TenSach;
        //            dgvChonPP.Rows[rowIndex].Cells["colTenDG"].Value = item.TenDocGia;
        //            dgvChonPP.Rows[rowIndex].Cells["colNgayTraDuKien"].Value = item.NgayTraDuKien;
        //            dgvChonPP.Rows[rowIndex].Cells["colNgayTra"].Value = item.NgayTra;
        //            dgvChonPP.Rows[rowIndex].Cells["colTrangThai"].Value = GetTrangThaiText(item.TrangThai);
        //            int tienPhatTam = CalculateFinePreview(item);
        //            dgvChonPP.Rows[rowIndex].Cells["colTienPhat"].Value = tienPhatTam;
        //            dgvChonPP.Rows[rowIndex].Cells["colLyDo"].Value = GetLyDoPhạt(item);
        //            dgvChonPP.Rows[rowIndex].Tag = item;
        //        }

        //        if (list.Count == 0)
        //        {
        //            MessageBox.Show("Không có phiếu trả nào cần phạt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        // File: FormAddPhieuPhat.cs
        // Hàm mẫu để bind dữ liệu vào DataGridView, gọi từ FormAddPhieuPhat_Load
        private void LoadPhieuTraCanPhat()
        {
            // TODO: thay bằng gọi service/DB thực tế trả về List<PhieuTraViPhamDTO>
            var list = new List<PhieuTraViPhamDTO>(); // lấy dữ liệu từ DB
            bs.DataSource = list;
            dgvChonPP.DataSource = bs;
        }
        //}

        // New: load existing phieu phat (trạng thái = 0) for editing (đóng -> 1)
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
                // show textual status: 0 => "chưa đóng", 1 => "đã đóng"
                dgvChonPP.Rows[rowIndex].Cells["colTrangThai"].Value = GetTrangThaiPhieuPhatText(item.TrangThai);
                dgvChonPP.Rows[rowIndex].Cells["colTienPhat"].Value = item.tienPhat;
                dgvChonPP.Rows[rowIndex].Cells["colLyDo"].Value = ""; // nếu cần, có thể tính lý do
                dgvChonPP.Rows[rowIndex].Tag = item;
            }

            if (editList.Count == 0)
            {
                MessageBox.Show("Không có phiếu phạt trạng thái 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int CalculateFinePreview(PhieuTraViPhamDTO item)
        {
            int tien = 0;
            if (item.QuaHan)
            {
                tien += item.SoNgayTre * 5000;
            }
            if (item.TrangThai == 2)
            {
                tien += 50000;
            }
            if (item.TrangThai == 3)
            {
                try
                {
                    string q = "SELECT ds.Gia FROM sach s JOIN dau_sach ds ON s.MaDauSach = ds.MaDauSach WHERE s.MaSach = @MaSach LIMIT 1";
                    var param = new Dictionary<string, object> { { "@MaSach", item.MaSach } };
                    var dt = QuanLyThuVien.DAO.DataProvider.ExecuteQuery(q, param);
                    if (dt.Rows.Count > 0 && dt.Rows[0]["Gia"] != DBNull.Value)
                    {
                        int gia = 0;
                        int.TryParse(dt.Rows[0]["Gia"].ToString(), out gia);
                        tien += gia;
                    }
                }
                catch { }
            }
            return tien;
        }

        private string GetTrangThaiText(int trangThai)
        {
            switch (trangThai)
            {
                case 1: return "Bình thường";
                case 2: return "Hỏng";
                case 3: return "Mất";
                default: return "Không xác định";
            }
        }

        // Added: map PhieuPhat.TrangThai (0/1) -> text
        private string GetTrangThaiPhieuPhatText(int trangThai)
        {
            switch (trangThai)
            {
                case 0: return "chưa đóng";
                case 1: return "đã đóng";
                default: return trangThai.ToString();
            }
        }

        private string GetLyDoPhạt(PhieuTraViPhamDTO item)
        {
            List<string> lyDo = new List<string>();

            if (item.TrangThai == 2)
                lyDo.Add("Sách hỏng");
            else if (item.TrangThai == 3)
                lyDo.Add("Sách mất");

            if (item.QuaHan)
            {
                TimeSpan diff = item.NgayTra - item.NgayTraDuKien;
                lyDo.Add($"Quá hạn {diff.Days} ngày");
            }

            return string.Join(", ", lyDo);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Khi click vào ô checkbox, commit thay đổi (được đăng ký trong SetupDataGridView)
            if (e.ColumnIndex == dgvChonPP.Columns["colCheck"].Index && e.RowIndex >= 0)
            {
                // giá trị đã được committed bởi DgvChonPP_CurrentCellDirtyStateChanged
                // nhưng nếu cần xử lý thêm (ví dụ cập nhật selectedItems realtime) có thể làm ở đây
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                // Thêm phiếu phạt mới (nguyên trạng)
                selectedItems.Clear();

                foreach (DataGridViewRow row in dgvChonPP.Rows)
                {
                    bool isChecked = false;
                    if (row.Cells["colCheck"].Value != null)
                        isChecked = Convert.ToBoolean(row.Cells["colCheck"].Value);

                    if (isChecked)
                    {
                        // Lấy DTO: ưu tiên Tag (nếu được set thủ công), nếu không thì lấy DataBoundItem
                        object source = row.Tag ?? row.DataBoundItem;
                        if (source is PhieuTraViPhamDTO item)
                        {
                            if (item.MaDG == 0)
                            {
                                MessageBox.Show("Lỗi: Dữ liệu tải lên bị thiếu MaDG (MaDG = 0). Hãy kiểm tra lại DAO!");
                                return;
                            }
                            selectedItems.Add(item);
                        }
                        else
                        {
                            // Nếu không phải kiểu mong đợi, báo lỗi nhẹ
                            MessageBox.Show("Không thể đọc dữ liệu từ một hàng được chọn. Hãy đảm bảo dữ liệu đã được nạp đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                if (selectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một mục để phạt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    bool ok = PhieuPhatBUS.Instance.CreatePhieuPhatFromViolations(selectedItems);
                    if (ok)
                    {
                        MessageBox.Show($"Đã lưu {selectedItems.Count} phiếu phạt vào cơ sở dữ liệu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Lỗi khi thêm phiếu phạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Edit mode: set TrangThai = 1 cho các phiếu phạt được chọn
                var toUpdate = new List<int>();
                foreach (DataGridViewRow row in dgvChonPP.Rows)
                {
                    bool isChecked = false;
                    if (row.Cells["colCheck"].Value != null)
                        isChecked = Convert.ToBoolean(row.Cells["colCheck"].Value);

                    if (isChecked)
                    {
                        object source = row.Tag ?? row.DataBoundItem;
                        var dto = source as PhieuPhatDTO;
                        if (dto != null)
                            toUpdate.Add(dto.MaPhieuPhat);
                    }
                }

                if (toUpdate.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một phiếu để đóng (chuyển trạng thái về 1).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool allOk = true;
                foreach (var id in toUpdate)
                {
                    bool ok = PhieuPhatBUS.Instance.DongPhieuPhat(id);
                    if (!ok) allOk = false;
                }

                if (allOk)
                {
                    MessageBox.Show("Đã cập nhật trạng thái thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật một hoặc nhiều phiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Thêm vào cuối class FormAddPhieuPhat.cs

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
    bool checkAll = headerCheckBox.Checked;
    foreach (DataGridViewRow row in dgvChonPP.Rows)
    {
        row.Cells["colCheck"].Value = checkAll;
    }
}
        internal List<PhieuTraViPhamDTO> GetSelectedItems()
        {
            return selectedItems;
        }
    }
}
