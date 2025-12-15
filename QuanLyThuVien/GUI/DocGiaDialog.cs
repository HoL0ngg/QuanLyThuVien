using QuanLyThuVien.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class DocGiaDialog : Form
    {
        public int SelectedMaDG { get; private set; }

        public DocGiaDialog()
        {
            InitializeComponent();
            btnClose.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        public void SetDocGia(DocGiaDTO docGia)
        {
            if (docGia == null) return;
            SelectedMaDG = docGia.MaDG;
            txtMaDG.Text = docGia.MaDG.ToString();
            txtTenDG.Text = docGia.TenDG;
            txtSDT.Text = docGia.SDT;
            txtDiaChi.Text = docGia.DiaChi;
            txtTrangThai.Text = docGia.TrangThai == 1 ? "Hoạt động" : "Không hoạt động";
        }
    }
}
