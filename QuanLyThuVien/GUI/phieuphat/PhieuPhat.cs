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
        private const string PLACEHOLDER_TEXT = "Tìm kiếm...";
        public PhieuPhat()
        {

            InitializeComponent();
            this.Load += PhieuPhat_Load;


        }
        private List<PhieuPhatDTO> _currentResult = new List<PhieuPhatDTO>();
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
                DateTime end = DTP_end.Value.Date.AddDays(1); // tới hết ngày

                if (begin > end)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Lưu lại kết quả hiện tại
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
            //cbbPhieuPhat.SelectedIndex = 0;
            colID.DataPropertyName = "MaPhieuPhat";
            colNgayPhat.DataPropertyName = "NgayPhat";
            colTrangThai.DataPropertyName = "TrangThaiText";
            colDG.DataPropertyName = "TenDG";
            colTien.DataPropertyName = "tienPhat";
            colTen.DataPropertyName = "TenSach";
            colLyDo.DataPropertyName = "LydoPhat";

            List<PhieuPhatDTO> list = trangThaiLoc.HasValue
                ? PhieuPhatBUS.Instance.GetTrangThaiPhieuPhat(trangThaiLoc.Value)
                : PhieuPhatBUS.Instance.GetAllPhieuPhat();

            // debug: show which IDs were returned
            var ids = string.Join(",", list.Select(p => p.MaPhieuPhat).Distinct());
            // or show messagebox once for debugging:
            // MessageBox.Show("Loaded IDs: " + ids);

            dgvPhieuPhat.DataSource = list;


        }
        private void PhieuPhat_Load(object sender, EventArgs e)
        {
            LoadPhieuPhat(null);
        }

        private void PhieuPhat_Load_1(object sender, EventArgs e)
        {

        }

        //private void cbbPhieuPhat_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int? trangThai = null;
        //    if (cbbPhieuPhat.SelectedIndex == 1) trangThai = 0; // Chưa đóng
        //    else if (cbbPhieuPhat.SelectedIndex == 2) trangThai = 1; // Đã đóng

        //    LoadPhieuPhat(trangThai);
        //}
        private void cbbPhieuPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chưa có kết quả hiện tại (chưa bấm tìm), fallback sang lấy toàn bộ
            var baseList = _currentResult != null && _currentResult.Count > 0
                ? _currentResult
                : PhieuPhatBUS.Instance.GetAllPhieuPhat();

            int? trangThai = null;
            if (cbbPhieuPhat.SelectedIndex == 1) trangThai = 0; // Chưa đóng
            else if (cbbPhieuPhat.SelectedIndex == 2) trangThai = 1; // Đã đóng

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
                int ind = cbbPhieuPhat.FindStringExact("Tất cả");
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
            if (!isUserInput) return; // Bỏ qua nếu không phải user input

            string keyword = tb_search.Text;
            List<PhieuPhatDTO> list = PhieuPhatBUS.Instance.GetByKeyword(keyword);
            dgvPhieuPhat.DataSource = list;
        }

        private void btn(object sender, EventArgs e)
        {

        }
        // Trong file PhieuPhat.cs

        // Trong file PhieuPhat.cs
        public override void OnAdd()
        {
            using (var dlg = new FormAddPhieuPhat())
            {
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // If you later expose selected items from the dialog, process them here.
                    // For now just refresh the grid to reflect potential changes.
                    LoadPhieuPhat(null);
                }
            }
        }
        public override void OnDelete()
        {
            // 1. Kiểm tra đã chọn dòng chưa
            if (dgvPhieuPhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy Mã phiếu phạt (ID) từ dòng đang chọn
            // LƯU Ý: "colID" là tên (Name) cột Mã trong Design DataGridView của bạn. 
            // Nếu bạn đặt tên khác (ví dụ MaPhieuPhat) thì sửa lại chuỗi string bên dưới cho khớp.
            var cellValue = dgvPhieuPhat.SelectedRows[0].Cells["colID"].Value;

            if (cellValue == null) return;
            int maPhieuPhat = Convert.ToInt32(cellValue);

            // 3. Hỏi xác nhận (Quan trọng)
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa (ẩn) phiếu phạt số {maPhieuPhat} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 4. Gọi BUS để chuyển trạng thái sang 0 (Soft Delete)
                bool isSuccess = PhieuPhatBUS.Instance.XoaPhieuPhat(maPhieuPhat);

                if (isSuccess)
                {
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Tải lại dữ liệu để dòng đó biến mất (hoặc ẩn đi tùy bộ lọc của bạn)
                    LoadPhieuPhat(null);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Thêm override OnEdit vào class PhieuPhat
        public override void OnEdit()
        {
            // Lấy tất cả phiếu phạt có trạng thái = 0 (chưa đóng)
            var list = PhieuPhatBUS.Instance.GetTrangThaiPhieuPhat(0);
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Không có phiếu phạt có trạng thái 0 để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new FormAddPhieuPhat(list))
            {
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Tải lại dữ liệu sau khi cập nhật
                    LoadPhieuPhat(null);
                }
            }
        }
        public override void OnDetails()
        {
            // 1. Kiểm tra đã chọn dòng chưa
            if (dgvPhieuPhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt cần xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy đối tượng PhieuPhatDTO từ dòng đang chọn
            var phieu = dgvPhieuPhat.SelectedRows[0].DataBoundItem as PhieuPhatDTO;
            if (phieu == null) return;

            // 3. Mở form chi tiết
            using (var dlg = new FormChiTietPhieuPhat(phieu))
            {
                dlg.ShowDialog();
            }
        }
        private void dgvPhieuPhat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuPhat.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                int value = Convert.ToInt32(e.Value);
                e.Value = value == 1 ? "Đã đóng" : "Chưa đóng";
                e.FormattingApplied = true;
            }
        }


    }
}
