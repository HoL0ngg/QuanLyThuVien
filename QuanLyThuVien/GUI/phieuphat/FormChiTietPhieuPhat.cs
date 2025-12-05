using System;
using System.Windows.Forms;
using QuanLyThuVien.DTO;

namespace QuanLyThuVien.GUI
{
    public partial class FormChiTietPhieuPhat : Form
    {
        private PhieuPhatDTO _phieuPhat;

        public FormChiTietPhieuPhat(PhieuPhatDTO phieuPhat)
        {
            InitializeComponent();
            _phieuPhat = phieuPhat;
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            txtMaPhieu.Text = _phieuPhat.MaPhieuPhat.ToString();
            txtNgayPhat.Text = _phieuPhat.NgayPhat.ToString("dd/MM/yyyy");
            txtTrangThai.Text = _phieuPhat.TrangThaiText;
            txtMaCTPhieuPhat.Text = _phieuPhat.MaCTPhieuPhat.ToString();
            txtNgayTra.Text = _phieuPhat.NgayTra == DateTime.MinValue ? "" : _phieuPhat.NgayTra.ToString("dd/MM/yyyy");
            txtTienPhat.Text = _phieuPhat.tienPhat.ToString("N0") + " VNĐ";
            txtTenSach.Text = _phieuPhat.TenSach;
            txtTenDG.Text = _phieuPhat.TenDG;
            txtMaDG.Text = _phieuPhat.MaDG.ToString();
            txtMaCTPhieuTra.Text = _phieuPhat.MaCTPhieuTra.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}