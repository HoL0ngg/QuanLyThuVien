using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
namespace QuanLyThuVien.GUI
{
    public partial class PhieuPhat : UserControl
    {
        public PhieuPhat()
        {
            

            this.Load += PhieuPhat_Load;
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            }

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
        private void LoadPhieuPhat(int? trangThaiLoc = null )
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



            dgvPhieuPhat.Refresh();
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
    }
}
