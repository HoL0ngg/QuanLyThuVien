using MySqlX.XDevAPI.Common;
using QuanLyThuVien.DAO;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
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
    public partial class FormThemPhieuNhap : UserControl
    {
        private PhieuNhapBUS bus = new PhieuNhapBUS();
        public event Action OnPhieuNhapAdded;
        public FormThemPhieuNhap()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormThemPhieuNhap_Load);
        }

        private void FormThemPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadNhacungCap();
            btnLuu.Click += new EventHandler(btnThem);
            btnHuy.Click += new EventHandler(btnCancel);
            dtpDate.Value = DateTime.Now;
            
        }

        private void LoadNhanVien()
        {
            string query = "SELECT MANV, TENNV FROM nhan_vien";
            DataTable dt = DataProvider.ExecuteQuery(query);

            dt.Columns.Add("MATEN", typeof(string), "MANV + ' - ' + TENNV");

            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MATEN";
            cbMaNV.ValueMember = "MANV";
        }

        private void LoadNhacungCap()
        {
            string query = "SELECT MANCC, TENNCC FROM nha_cung_cap";
            DataTable dt = DataProvider.ExecuteQuery(query);
            dt.Columns.Add("MATEN", typeof(string), "MANCC + ' - ' + TENNCC");
            cbMaNCC.DataSource = dt;
            cbMaNCC.DisplayMember = "MATEN";
            cbMaNCC.ValueMember = "MANCC";
        }

        private void btnThem(object sender, EventArgs e)
        {
            try
            {
                PhieuNhapDTO pn = new PhieuNhapDTO
                {
                    ThoiGian = dtpDate.Value,
                    MaNV = int.Parse(cbMaNV.SelectedValue.ToString()),
                    MaNCC = int.Parse(cbMaNCC.SelectedValue.ToString())
                };
                bool rs = bus.Insert(pn);
                if (rs)
                {
                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnPhieuNhapAdded?.Invoke();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null){
                    errorMessage += "\n\nCHI TIẾT: " + ex.InnerException.Message;
                }

                MessageBox.Show("Lỗi khi thêm phiếu nhập: " + errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormThemPhieuNhap_Load_1(object sender, EventArgs e)
        {

        }
    }
}
