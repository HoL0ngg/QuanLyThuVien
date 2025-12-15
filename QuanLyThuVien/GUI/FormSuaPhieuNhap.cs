using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq; // Cần dùng cho các thao tác List

namespace QuanLyThuVien.GUI
{
    public partial class FormSuaPhieuNhap : UserControl
    {
        // Khai báo biến
        private int MaPhieuNhapDangChinhSua { get; set; }
        private PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        private CTPhieuNhapBUS ct = new CTPhieuNhapBUS();
        public event EventHandler OnChiTietClosed;
        private List<CTPhieuNhapDTO> listChiTiet { get; set; } = new List<CTPhieuNhapDTO>();

        // Cần sự kiện này để Form Quản lý chính (PhieuNhapGUI) biết khi nào cần Load lại danh sách
        public event Action OnPhieuNhapUpdated;

        // 1. Constructor MẶC ĐỊNH (Cần thiết vì PhieuNhapGUI.SetupComponents gọi nó)
        public FormSuaPhieuNhap()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormSuaPhieuNhap_Load);
            SetupDataGridView();

        }
        private void FormSuaPhieuNhap_Load(object sender, EventArgs e)
        {
            //LoadTrangThai();
            LoadNhacungCap();
            LoadSach();
            dataGridView1.CellClick += CellClick;
            btnLuu.Click += new EventHandler(btnLuu_Click);
            btnHuy.Click += new EventHandler(btnThoat_Click);
            btnThem.Click += new EventHandler(btnThemChiTiet_Click);
            btnXoa.Click += new EventHandler(btnXoaChiTiet_Click);
            dtpDate.Value = DateTime.Now;

        }

        //private void LoadTrangThai()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Value", typeof(string));
        //    dt.Columns.Add("Text");
        //    dt.Rows.Add("DRAFT", "Đang chờ xử lý");
        //    dt.Rows.Add("COMPLETED", "Đã xử lý");
        //    dt.Rows.Add("CANCELLED", "Đã hủy");

        //    cbTrangThai.DataSource = dt;
        //    cbTrangThai.DisplayMember = "Text";
        //    cbTrangThai.ValueMember = "Value";
        //}
        public void LoadPhieuNhapData(int maPhieuNhap)
        {
            this.MaPhieuNhapDangChinhSua = maPhieuNhap;

            // Gán Mã Phiếu và khóa
            txtMaPhieu.Text = maPhieuNhap.ToString();
            txtMaPhieu.Enabled = false;

            // 1. Tải Phiếu Nhập chính
            PhieuNhapDTO pnDTO = pnBUS.GetById(maPhieuNhap);

            if (pnDTO == null)
            {
                MessageBox.Show("Không tìm thấy Phiếu Nhập này.", "Lỗi tải dữ liệu");
                // Thông báo cho Form Quản lý để ẩn Form sửa này và hiện lại lưới quản lý
                this.Visible = false;
                return;
            }
            dtpDate.Value = pnDTO.ThoiGian;
            cbMaNCC.SelectedValue = pnDTO.MaNCC;
            cbTrangThai.Text = pnDTO.TrangThai;

            // 3. Tải và Gán Chi tiết Phiếu Nhập
            listChiTiet = ct.GetByPhieuNhap(maPhieuNhap);

            // 4. Load lên DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listChiTiet;

            TinhTongTien();
            string trangThaiHienTai = pnDTO.TrangThai.Trim();

            // Chỉ cho phép chỉnh sửa nếu là "Đang chờ xử lý"
            bool choPhepChinhSua = trangThaiHienTai == "Đang chờ xử lý";

            // Vô hiệu hóa/Kích hoạt các control chính
            dtpDate.Enabled = choPhepChinhSua;
            cbMaNCC.Enabled = choPhepChinhSua;

            // ComboBox Trạng thái
            cbTrangThai.Enabled = choPhepChinhSua;

            // Vô hiệu hóa các nút Chi tiết
            btnThem.Enabled = choPhepChinhSua;
            // btnSua.Enabled = choPhepChinhSua; // Nếu có nút Sửa chi tiết
            btnXoa.Enabled = choPhepChinhSua;

            // Nút Lưu (Chỉ cho phép Lưu nếu là Đang chờ xử lý)
            btnLuu.Enabled = choPhepChinhSua;
        }

        // 3. Setup GridView cho Chi tiết
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


        // 4. Logic tải ComboBox (Giữ nguyên code của bạn, chỉ đặt nó trong hàm)
        private void LoadNhacungCap()
        {
            string query = "SELECT MANCC, TENNCC FROM nha_cung_cap";
            DataTable dt = DataProvider.ExecuteQuery(query);
            dt.Columns.Add("MATEN", typeof(string), "MANCC + ' - ' + TENNCC");
            cbMaNCC.DataSource = dt;
            cbMaNCC.DisplayMember = "MATEN";
            cbMaNCC.ValueMember = "MANCC";
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

        // 5. Logic tính toán Tổng tiền
        private void TinhTongTien()
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

        // 6. Xử lý khi giá trị trên lưới thay đổi
        private void dataGridViewChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ cần tính toán lại nếu cột Số lượng hoặc Đơn giá bị sửa
            if (e.RowIndex >= 0)
            {
                // Giả định tên cột dữ liệu là "SoLuong" và "DonGia"
                string columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

                if (columnName == "SoLuong" || columnName == "DonGia")
                {
                    // Lấy đối tượng DTO từ dòng bị sửa
                    CTPhieuNhapDTO ctSua = listChiTiet[e.RowIndex];

                    // Cập nhật lại list Chi tiết và tính tổng tiền
                    // Cần xử lý Convert.ToDouble(dataGridViewChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    TinhTongTien();
                }
            }
        }
        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một chi tiết sách để sửa.", "Cảnh báo");
                return;
            }
            if (dataGridView1.CurrentRow.Cells["colMaSach"].Value == null) return;
            int maDauSachCu = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaSach"].Value);

            if (cbTenSach.SelectedValue == null || string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách mới.", "Cảnh báo");
                return;
            }

            int newMaDauSach = Convert.ToInt32(cbTenSach.SelectedValue);
            int newSoLuong;
            double newDonGia;

            if (!int.TryParse(txtSoLuong.Text, out newSoLuong) || newSoLuong <= 0 ||
                !double.TryParse(txtDonGia.Text.Replace(".", "").Replace(",", ""), out newDonGia) || newDonGia < 0)
            {
                MessageBox.Show("Số lượng hoặc Đơn giá không hợp lệ.", "Lỗi nhập liệu");
                return;
            }
            CTPhieuNhapDTO chiTietCanSua = listChiTiet.FirstOrDefault(ct => ct.MaDauSach == maDauSachCu);

            if (chiTietCanSua != null)
            {
                if (maDauSachCu != newMaDauSach)
                {
                    CTPhieuNhapDTO chiTietTrung = listChiTiet.FirstOrDefault(ct => ct.MaDauSach == newMaDauSach);
                    if (chiTietTrung != null)
                    {
                        chiTietTrung.SoLuong += newSoLuong;
                        listChiTiet.Remove(chiTietCanSua);
                    }
                    else
                    {
                        chiTietCanSua.MaDauSach = newMaDauSach;
                        chiTietCanSua.TenSach = cbTenSach.Text.Split('-')[1].Trim();
                        chiTietCanSua.SoLuong = newSoLuong;
                        chiTietCanSua.DonGia = newDonGia;
                    }
                }
                else
                {
                    chiTietCanSua.SoLuong = newSoLuong;
                    chiTietCanSua.DonGia = newDonGia;
                }

                MessageBox.Show($"Đã cập nhật Chi tiết trong danh sách tạm. Bấm LƯU để lưu vào CSDL.", "Thông báo");
                RefreshChiTietGridView();
            }
        }
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            // Lấy ID sách đã chọn từ ComboBox Tên sách
            if (cbTenSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Đầu sách cần thêm.", "Lỗi nhập liệu");
                return;
            }

            int maDauSachMoi = Convert.ToInt32(cbTenSach.SelectedValue);
            int soLuong;
            double donGia;

            // 1. Kiểm tra đầu vào (Số lượng và Đơn giá)
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi nhập liệu");
                return;
            }
            if (!double.TryParse(txtDonGia.Text, out donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số dương.", "Lỗi nhập liệu");
                return;
            }

            // 2. Kiểm tra trùng lặp
            // Nếu sách đã tồn tại trong listChiTiet, không cho thêm, mà yêu cầu sửa.
            if (listChiTiet.Any(ct => ct.MaDauSach == maDauSachMoi))
            {
                MessageBox.Show("Đầu sách này đã có trong phiếu. Vui lòng sử dụng nút 'Cập nhật Chi tiết' để sửa đổi.", "Lỗi nghiệp vụ");
                return;
            }
            string tenDauSachHienThi = cbTenSach.Text;

            string tenSach = tenDauSachHienThi.Contains(" - ") ?
                             tenDauSachHienThi.Substring(tenDauSachHienThi.IndexOf(" - ") + 3) :
                             tenDauSachHienThi;
            // 3. Tạo Chi tiết Phiếu Nhập mới
            CTPhieuNhapDTO ctMoi = new CTPhieuNhapDTO
            {
                MaPhieuNhap = MaPhieuNhapDangChinhSua, // Gán tạm mã PN để đồng bộ
                MaDauSach = maDauSachMoi,
                TenSach = tenSach, // Lấy tên hiển thị
                SoLuong = soLuong,
                DonGia = donGia
            };

            // 4. Thêm vào danh sách và Cập nhật DataGridView
            listChiTiet.Add(ctMoi);
            RefreshChiTietGridView(); // Cần tạo hàm này

            MessageBox.Show("Đã thêm sách mới vào Phiếu Nhập.", "Thông báo");
        }
        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào được chọn không
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng sách trong danh sách để xóa.", "Thông báo");
                return;
            }

            // Lấy Mã Đầu Sách của dòng đang được chọn
            int maDauSachCanXoa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaSach"].Value);
            string tenDauSach = dataGridView1.CurrentRow.Cells["colTenSach"].Value.ToString();

            // 2. Hỏi xác nhận người dùng
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sách '{tenDauSach}' (Mã {maDauSachCanXoa}) khỏi phiếu nhập này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // 3. Tìm và xóa Chi tiết khỏi danh sách tạm thời (RAM)
                CTPhieuNhapDTO ctCanXoa = listChiTiet.FirstOrDefault(ct => ct.MaDauSach == maDauSachCanXoa);

                if (ctCanXoa != null)
                {
                    listChiTiet.Remove(ctCanXoa);

                    // 4. Cập nhật lại DataGridView
                    RefreshChiTietGridView();

                    MessageBox.Show($"Đã xóa sách '{tenDauSach}' khỏi Phiếu Nhập. Nhấn [Lưu] để xác nhận thay đổi vào CSDL.", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy sách này trong danh sách tạm thời.", "Lỗi nội bộ");
                }
            }
        }

        private void RefreshChiTietGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listChiTiet;
            TinhTongTien();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (listChiTiet.Count == 0)
            {
                MessageBox.Show("Phiếu nhập phải có ít nhất một chi tiết sách!", "Lỗi nghiệp vụ");
                return;
            }

            // KHẮC PHỤC LỖI NULL REFERENCE và validation
            if (cbMaNCC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Mã nhà cung cấp.", "Lỗi nhập liệu");
                return;
            }
            if (cbTrangThai.SelectedItem == null || string.IsNullOrWhiteSpace(cbTrangThai.Text))
            {
                MessageBox.Show("Vui lòng chọn Trạng thái Phiếu Nhập.", "Lỗi nhập liệu");
                return;
            }
            PhieuNhapDTO pnCu = pnBUS.GetById(MaPhieuNhapDangChinhSua);
            string trangThaiCu = pnCu.TrangThai.Trim();
            string trangThaiMoi = cbTrangThai.Text.Trim();
            if (trangThaiCu == "Đã xử lý" || trangThaiCu == "Đã hủy")
            {
                MessageBox.Show($"Phiếu nhập ở trạng thái '{trangThaiCu}' không thể lưu thay đổi.", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Visible = false;
                return;
            }
            if (trangThaiCu == "Đang chờ xử lý" && trangThaiMoi == "Đã xử lý")
            {
                DialogResult confirmResult = MessageBox.Show(
                   "Bạn có chắc chắn muốn chuyển trạng thái sang 'Đã xử lý'? Hành động này sẽ cập nhật tồn kho và giá bán.",
                   "Xác nhận xử lý phiếu nhập",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

                if (confirmResult == DialogResult.No) return;
            }


            PhieuNhapDTO pnMoi = new PhieuNhapDTO
            {
                MaPhieuNhap = MaPhieuNhapDangChinhSua,
                ThoiGian = dtpDate.Value,
                MaNCC = int.Parse(cbMaNCC.SelectedValue.ToString()),
                MaNV = 1,
                TrangThai = trangThaiMoi,
                ct = listChiTiet
            };

            bool success = false;

            if (trangThaiCu == "Đang chờ xử lý" && trangThaiMoi == "Đã xử lý")
            {
                success = pnBUS.ProcessPhieuNhap(pnMoi);
            }
            else
            {
                success = pnBUS.UpdateFullPhieuNhap(pnMoi);
            }
            if (success)
            {
                MessageBox.Show("Cập nhật Phiếu Nhập thành công!");
                OnPhieuNhapUpdated?.Invoke();
            }
            else
            {
                MessageBox.Show("Cập nhật Phiếu Nhập thất bại. Vui lòng kiểm tra Log lỗi CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 8. Xử lý nút "Thoát"
        private void btnThoat_Click(object sender, EventArgs e)
        {
            OnChiTietClosed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
        private void CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void label6_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}