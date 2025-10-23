using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class PhieuMuon : BaseModuleUC
    {
        public PhieuMuon()
        {
            InitializeComponent();
        }

        // Ghi đè (override) lại các hành vi của lớp cha
        public override void OnAdd()
        {
            // Mở form_ThemPhieuMuon
            //form_ThemPhieuMuon frm = new form_ThemPhieuMuon();
            //frm.ShowDialog();
            LoadData(); // Tải lại dữ liệu sau khi thêm
        }

        public override void OnEdit()
        {
            // Lấy ID của phiếu mượn đang chọn trên DataGridView
            // Mở form_SuaPhieuMuon với ID đó
            // ...
            LoadData(); // Tải lại
        }

        public override void OnDelete()
        {
            // Lấy ID, hỏi xác nhận xóa
            // ...
            LoadData(); // Tải lại
        }

        public override void LoadData()
        {
            // Code tải dữ liệu từ CSDL lên DataGridView của bạn
        }

        private void PhieuMuon_Load(object sender, EventArgs e)
        {

        }

    }
}
