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
    public partial class PhieuPhat : UserControl
    {
        private bool isUserInput = true;
        private const string PLACEHOLDER_TEXT = "Tìm kiếm...";
        public PhieuPhat()
        {

            InitializeComponent();
            this.Load += PhieuPhat_Load;
            // 2. THIẾT LẬP BAN ĐẦU CHO TEXTBOX TÌM KIẾM (textBox1)
            //SetupPlaceholder();

            //// 3. Gán sự kiện (Hoặc bạn có thể gán bên giao diện Design cũng được)
            //tb_search.Enter += TextBox1_Enter; // Sự kiện khi bấm chuột vào ô
            //tb_search.Leave += TextBox1_Leave; // Sự kiện khi bấm chuột ra ngoài
                
            // 2. THIẾT LẬP BAN ĐẦU CHO TEXTBOX TÌM KIẾM (textBox1)



            // gõ   Enter trong textbox sẽ trigger tìm kiếm
            //this.btn_search.KeyDown += btn_search_KeyDown;

            //// đặt placeholder ban đầu nếu cần
            //if (string.IsNullOrWhiteSpace(this.btn_search.Text))
            //    this.btn_search.Text = PlaceholderText;
            //this.btn_search.GotFocus += (s, e) =>
            //{
            //    if (this.btn_search.Text == PlaceholderText) this.btn_search.Text = "";
            //};
            //this.btn_search.LostFocus += (s, e) =>
            //{
            //    if (string.IsNullOrWhiteSpace(this.btn_search.Text)) this.btn_search.Text = PlaceholderText;
            //};
        }
        //private void SetupPlaceholder()
        //{
        //    tb_search.Text = PLACEHOLDER_TEXT;
        //    tb_search.ForeColor = Color.Silver; // Màu chữ xám nhạt cho giống gợi ý
        //}

        //// Sự kiện: Khi người dùng bấm vào ô text
        //private void TextBox1_Enter(object sender, EventArgs e)
        //{
        //    // Nếu chữ đang là "Tìm kiếm..." thì xóa đi để người dùng nhập
        //    if (tb_search.Text == PLACEHOLDER_TEXT)
        //    {
        //        tb_search.Text = "";
        //        tb_search.ForeColor = Color.Black; // Đổi lại màu đen để nhập liệu
        //    }
        //}

        //// Sự kiện: Khi người dùng bấm ra chỗ khác (hoặc lười không nhập gì)
        //private void TextBox1_Leave(object sender, EventArgs e)
        //{
        //    // Nếu người dùng không nhập gì (trống trơn)
        //    if (string.IsNullOrWhiteSpace(tb_search.Text))
        //    {
        //        // Hiện lại chữ "Tìm kiếm..."
        //        tb_search.Text = PLACEHOLDER_TEXT;
        //        tb_search.ForeColor = Color.Silver; // Đổi lại màu xám
        //    }
        //}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            // Prevent textBox1_TextChanged handler from interfering while we update the grid.
            isUserInput = false;
            try
            {
                DateTime begin = DTP_begin.Value;
                DateTime end = DTP_end.Value.Date.AddDays(1);
                if (begin > end)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get records in date range first
                List<PhieuPhatDTO> list = PhieuPhatBUS.Instance.GetByDateRange(begin, end);

                // If there's a keyword, further filter the already retrieved list (client-side)
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

                dgvPhieuPhat.DataSource = list;
            }
            finally
            {
                // Always re-enable the text changed handler flag
                isUserInput = true;
            }
        }
        //private void btn_search_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        e.SuppressKeyPress = true;
        //        btn_search_Click(btn_search, EventArgs.Empty);
        //    }
        //}


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPhieuPhat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //private void dgvPhieuPhat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    // Kiểm tra cột TrangThai
        //    if (dgvPhieuPhat.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
        //    {
        //        int trangThai = Convert.ToInt32(e.Value);
        //        e.Value = (trangThai == 1) ? "Đã trả" : "Chưa trả";
        //        e.FormattingApplied = true;
        //    }
        //}
        private void LoadPhieuPhat(int? trangThaiLoc = null)
        {
            Console.WriteLine("Loading PhieuPhat");
            dgvPhieuPhat.AutoGenerateColumns = false;
            //cbbPhieuPhat.SelectedIndex = 0;
            colID.DataPropertyName = "MaPhieuPhat";
            colNgayPhat.DataPropertyName = "NgayPhat";
            colTrangThai.DataPropertyName = "TrangThai";
            colDG.DataPropertyName = "TenDG";
            colTien.DataPropertyName = "tienPhat";
            colTen.DataPropertyName = "TenSach";

            List<PhieuPhatDTO> list;
            if (trangThaiLoc.HasValue)
            {
                // Tham số được truyền vào (0 hoặc 1), thực hiện lọc
                // Bạn cần đảm bảo PhieuPhatBUS.Instance.GetPhieuPhatByTrangThai(int trangThai) tồn tại!
                list = PhieuPhatBUS.Instance.GetTrangThaiPhieuPhat(trangThaiLoc.Value);
            }
            else
            {
                // Tham số là null (Tất cả), tải toàn bộ
                list = PhieuPhatBUS.Instance.GetAllPhieuPhat();

            }
            dgvPhieuPhat.DataSource = list;



            //dgvPhieuPhat.Refresh();
            //this.dgvPhieuPhat.CellFormatting += dgvPhieuPhat_CellFormatting;


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
            int? trangThai = null;
            if (cbbPhieuPhat.SelectedIndex == 1) trangThai = 0; // Chưa đóng
            else if (cbbPhieuPhat.SelectedIndex == 2) trangThai = 1; // Đã đóng

            LoadPhieuPhat(trangThai);
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
    }
}