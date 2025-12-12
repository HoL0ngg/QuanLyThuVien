using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThuVien.GUI
{
    public partial class PhieuPhat : BaseModuleUC
    {
        private bool isUserInput = true;
        private const string PLACEHOLDER_TEXT = "Tim kiem...";
        private List<PhieuPhatDTO> _currentResult = new List<PhieuPhatDTO>();

        public PhieuPhat()
        {
            InitializeComponent();
            this.Load += PhieuPhat_Load;
        }

        public PhieuPhat(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //private void btn_search_Click(object sender, EventArgs e)
        //{
        //    // Prevent textBox1_TextChanged handler from interfering while we update the grid.
        //    isUserInput = false;
        //    try
        //    {DVG
        //        DateTime begin = DTP_begin.Value;
        //        DateTime end = DTP_end.Value.Date.AddDays(1);
        //        if (begin > end)
        //        {
        //            MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        // Get records in date range first
        //        List<PhieuPhatDTO> list = PhieuPhatBUS.Instance.GetByDateRange(begin, end);

        //        // If there's a keyword, further filter the already retrieved list (client-side)
        //        string keyword = tb_search.Text?.Trim();
        //        if (!string.IsNullOrWhiteSpace(keyword))
        //        {
        //            int id;
        //            bool isId = int.TryParse(keyword, out id);
        //            string kwLower = keyword.ToLowerInvariant();

        //            list = list.Where(p =>
        //                (p.TenSach != null && p.TenSach.ToLowerInvariant().Contains(kwLower)) ||
        //                (p.TenDG != null && p.TenDG.ToLowerInvariant().Contains(kwLower)) ||
        //                (isId && p.MaPhieuPhat == id)
        //            ).ToList();
        //        }

        //        dgvPhieuPhat.DataSource = list;
        //    }
        //    finally
        //    {
        //        // Always re-enable the text changed handler flag
        //        isUserInput = true;
        //    }
        //}

        private void btn_search_Click(object sender, EventArgs e)
        {
            isUserInput = false;
            try
            {
                DateTime begin = DTP_begin.Value.Date;
                DateTime end = DTP_end.Value.Date.AddDays(1); // toi het ngay

                if (begin > end)
                {
                    MessageBox.Show("Ngay bat dau phai truoc ngay ket thuc.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var list = PhieuPhatBUS.Instance.GetByDateRange(begin, end);

                // keyword filter (client-side)
                string keyword = tb_search.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    int id;
                    bool isId = int.TryParse(keyword, out id);
                    string kwLower = keyword.ToLowerInvariant();

                    list = list.Where(p =>
                        (p.TenSach != null && p.TenSach.ToLowerInvariant().Contains(kwLower)) ||
                        (p.TenDG != null && p.TenDG.ToLowerInvariant().Contains(kwLower)) ||
                        (isId && p.MaPhieuPhat == id)
                    ).ToList();
                }

                // Luu lai ket qua hien tai
                _currentResult = list;

                dgvPhieuPhat.DataSource = _currentResult;
            }
            finally
            {
                isUserInput = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPhieuPhat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void LoadPhieuPhat(int? trangThaiLoc = null)
        {
            Console.WriteLine("Loading PhieuPhat");
            dgvPhieuPhat.AutoGenerateColumns = false;
            colID.DataPropertyName = "MaPhieuPhat";
            colNgayPhat.DataPropertyName = "NgayPhat";
            colTrangThai.DataPropertyName = "TrangThaiText";
            colTien.DataPropertyName = "tienPhat";
            colTen.DataPropertyName = "TenDG";
            

            List<PhieuPhatDTO> list = trangThaiLoc.HasValue
                ? PhieuPhatBUS.Instance.GetTrangThaiPhieuPhat(trangThaiLoc.Value)
                : PhieuPhatBUS.Instance.GetAllPhieuPhat();

            dgvPhieuPhat.DataSource = list;
        }

        private void PhieuPhat_Load(object sender, EventArgs e)
        {
            LoadPhieuPhat(null);
        }

        private void PhieuPhat_Load_1(object sender, EventArgs e)
        {

        }

        private void cbbPhieuPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Neu chua co ket qua hien tai (chua bam tim), fallback sang lay toan bo
            var baseList = _currentResult != null && _currentResult.Count > 0
                ? _currentResult
                : PhieuPhatBUS.Instance.GetAllPhieuPhat();

            int? trangThai = null;
            if (cbbPhieuPhat.SelectedIndex == 1) trangThai = 0; // Chua dong
            else if (cbbPhieuPhat.SelectedIndex == 2) trangThai = 1; // Da dong

            var filtered = trangThai.HasValue
                ? baseList.Where(p => p.TrangThai == trangThai.Value).ToList()
                : baseList;

            dgvPhieuPhat.DataSource = filtered;
        }

        private void lb_dateEnd_Click(object sender, EventArgs e)
        {

        }

        private void btn_resest_Click(object sender, EventArgs e)
        {
            ResetFiltersToDefaults();
            LoadPhieuPhat(null);
        }

        private void ResetFiltersToDefaults()
        {
            DTP_begin.Value = DateTime.Now;
            DTP_end.Value = DateTime.Now;
            if (cbbPhieuPhat.Items.Count > 0)
            {
                cbbPhieuPhat.SelectedIndex = 0;
                int ind = cbbPhieuPhat.FindStringExact("Tat ca");
                if (ind >= 0)
                {
                    cbbPhieuPhat.SelectedIndex = ind;
                }
            }
        }

        private void DTP_begin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isUserInput) return; // Bo qua neu khong phai user input

            string keyword = tb_search.Text;
            List<PhieuPhatDTO> list = PhieuPhatBUS.Instance.GetByKeyword(keyword);
            dgvPhieuPhat.DataSource = list;
        }

        private void btn(object sender, EventArgs e)
        {

        }

        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Ban khong co quyen them phieu phat!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var dlg = new FormAddPhieuPhat())
            {
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadPhieuPhat(null);
                }
            }
        }

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Ban khong co quyen xoa phieu phat!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 1. Kiem tra da chon dong chua
            if (dgvPhieuPhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon phieu phat can xoa.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lay Ma phieu phat (ID) tu dong dang chon
            var cellValue = dgvPhieuPhat.SelectedRows[0].Cells["colID"].Value;

            if (cellValue == null) return;
            int maPhieuPhat = Convert.ToInt32(cellValue);

            // 3. Hoi xac nhan
            var result = MessageBox.Show(
                "Ban co chac chan muon xoa (an) phieu phat so " + maPhieuPhat + " khong?",
                "Xac nhan xoa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 4. Goi BUS de chuyen trang thai sang 0 (Soft Delete)
                bool isSuccess = PhieuPhatBUS.Instance.XoaPhieuPhat(maPhieuPhat);

                if (isSuccess)
                {
                    MessageBox.Show("Da xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Tai lai du lieu
                    LoadPhieuPhat(null);
                }
                else
                {
                    MessageBox.Show("Co loi xay ra, khong the xoa.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void OnEdit()
        {
            if (!CoQuyenSua)
            {
                MessageBox.Show("Bạn không có quyền sửa phiếu phạt!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Kiểm tra đã chọn dòng chưa
            if (dgvPhieuPhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt cần thay đổi trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy phiếu phạt từ dòng đang chọn
            var phieu = dgvPhieuPhat.SelectedRows[0].DataBoundItem as PhieuPhatDTO;
            if (phieu == null) return;

            // 3. Xác định trạng thái hiện tại và trạng thái mới
            int trangThaiHienTai = phieu.TrangThai;
            int trangThaiMoi = trangThaiHienTai == 0 ? 1 : 0; // Toggle: 0->1 hoặc 1->0
            
            string trangThaiCu = trangThaiHienTai == 0 ? "Chưa đóng" : "Đã đóng";
            string trangThaiNew = trangThaiMoi == 0 ? "Chưa đóng" : "Đã đóng";

            // 4. Hỏi xác nhận
            var result = MessageBox.Show(
                $"Bạn có muốn chuyển phiếu phạt #{phieu.MaPhieuPhat}\nTừ trạng thái '{trangThaiCu}' sang '{trangThaiNew}' không?",
                "Xác nhận thay đổi trạng thái",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 5. Gọi BUS để cập nhật trạng thái
                bool isSuccess = PhieuPhatBUS.Instance.SetTrangThai(phieu.MaPhieuPhat, trangThaiMoi);

                if (isSuccess)
                {
                    MessageBox.Show($"Đã chuyển sang trạng thái '{trangThaiNew}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 6. Tải lại dữ liệu
                    LoadPhieuPhat(null);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, không thể cập nhật trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void OnDetails()
        {
            // 1. Kiểm tra quyền hạn
            if (!CoQuyenXem)
            {
                MessageBox.Show("Bạn không có quyền xem chi tiết phiếu phạt!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra đã chọn dòng chưa
            if (dgvPhieuPhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt cần xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Lấy đối tượng PhieuPhatDTO từ dòng đang chọn
            var phieu = dgvPhieuPhat.SelectedRows[0].DataBoundItem as PhieuPhatDTO;

            if (phieu == null) return;

            // 4. Mở form chi tiết (Luôn là chế độ Lịch sử)
            try
            {
                // Truyền MaPhieuPhat và true (isHistory = true)
                using (var dlg = new FormChiTietPhieuPhat(phieu.MaPhieuPhat, true))
                {
                    dlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở chi tiết: " + ex.Message);
            }
        }

        private void dgvPhieuPhat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuPhat.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                int value = Convert.ToInt32(e.Value);
                e.Value = value == 1 ? "Da dong" : "Chua dong";
                e.FormattingApplied = true;
            }
        }
    }
}
