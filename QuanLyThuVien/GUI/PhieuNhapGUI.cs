using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
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
    public partial class PhieuNhapGUI : BaseModuleUC
    {
        PhieuNhapBUS bus = new PhieuNhapBUS();
        private FormThemPhieuNhap formThemPhieuNhap1;
        private CTPhieuNhapGUI ctPhieuNhapGUI1;

        public PhieuNhapGUI()
        {
            InitializeComponent();
            SetupComponents();
        }

        public PhieuNhapGUI(TaiKhoanDTO user) : this()
        {
            this.CurrentUser = user;
        }

        private void SetupComponents()
        {
            formThemPhieuNhap1 = new FormThemPhieuNhap();
            formThemPhieuNhap1.Dock = DockStyle.Fill;
            formThemPhieuNhap1.Visible = false;
            this.Controls.Add(formThemPhieuNhap1);

            ctPhieuNhapGUI1 = new CTPhieuNhapGUI();
            ctPhieuNhapGUI1.Dock = DockStyle.Fill;
            ctPhieuNhapGUI1.Visible = false;
            this.Controls.Add(ctPhieuNhapGUI1);
            formThemPhieuNhap2.OnPhieuNhapAdded += () => LoadDanhSach();
        }
        
        public void LoadDanhSach()
        {
            dataGridView1.AutoGenerateColumns = false;
            colMaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            colDate.DataPropertyName = "ThoiGian";
            colMaNV.DataPropertyName = "MaNV";
            colMaNCC.DataPropertyName = "MaNCC";
            colTenNhanVien.DataPropertyName = "TENNV";
            colTenNCC.DataPropertyName = "TENNCC";
            dataGridView1.DataSource = bus.GetALL();
        }

        private void PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    if (row.Cells["colDate"].Value != null && row.Cells["colDate"].Value != DBNull.Value)
                        dtpDate.Value = Convert.ToDateTime(row.Cells["colDate"].Value);
                    else
                        dtpDate.Value = DateTime.Now;
                    
                    if (row.Cells["colMaNV"].Value != null)
                        cbMaNV.SelectedValue = row.Cells["colMaNV"].Value;

                    if (row.Cells["colMaNCC"].Value != null)
                        cbMaNCC.SelectedValue = row.Cells["colMaNCC"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi chon phieu nhap: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void them(object sender, EventArgs e)
        {
            formThemPhieuNhap2.Visible = true;
            formThemPhieuNhap2.BringToFront();
        }
        private void chitiet(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int maPhieuChon = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value);
                ctPhieuNhapGUI1.LoadChiTiet(maPhieuChon);
                ctPhieuNhapGUI1.Visible = true;
                ctPhieuNhapGUI1.BringToFront();
            }
            else
            {
                MessageBox.Show("Vui long chon mot phieu nhap de xem chi tiet!");
            }
        }

        private void xoa(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null) {
                MessageBox.Show("Vui long chon mot phieu nhap de xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            int maPhieuCanXoa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString());
            DialogResult result = MessageBox.Show("Ban co chac chan muon xoa phieu nhap " + maPhieuCanXoa + "?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool xoaThanhCong = bus.Delete(maPhieuCanXoa);
                if (xoaThanhCong)
                {
                    MessageBox.Show("Xoa thanh cong");
                    LoadDanhSach();
                }
                else
                {
                    MessageBox.Show("Xoa that bai. Vui long thu lai.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sua(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot phieu nhap de sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maPhieuCanSua = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString());
            DateTime NewDay = dtpDate.Value;
            int NewMaNV = Convert.ToInt32(cbMaNV.SelectedValue);
            int NewMaNNCC = Convert.ToInt32(cbMaNCC.SelectedValue);
            PhieuNhapDTO NewPhieu = new PhieuNhapDTO();
            NewPhieu.MaPhieuNhap = maPhieuCanSua;
            NewPhieu.ThoiGian = NewDay;
            NewPhieu.MaNV = NewMaNV;
            NewPhieu.MaNCC = NewMaNNCC;
            bool SuaThanhCong = bus.Update(NewPhieu);
            if(SuaThanhCong)
            {
                MessageBox.Show("Cap nhat thanh cong!");
                LoadDanhSach();
            }
            else
            {
                MessageBox.Show("Cap nhat that bai. Vui long thu lai.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var result = bus.Search(keyword);
            if (result == null || result.Count == 0)
            {
                MessageBox.Show("Khong tim thay phieu nhap nao phu hop voi tu khoa",
                                "Thong bao",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = result;
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

        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Ban khong co quyen them phieu nhap!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            them(this, EventArgs.Empty);
        }

        public override void OnEdit()
        {
            if (!CoQuyenSua)
            {
                MessageBox.Show("Ban khong co quyen sua phieu nhap!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sua(this, EventArgs.Empty);
        }

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Ban khong co quyen xoa phieu nhap!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            xoa(this, EventArgs.Empty);
        }

        public override void OnDetails()
        {
            if (!CoQuyenXem)
            {
                MessageBox.Show("Ban khong co quyen xem chi tiet phieu nhap!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            chitiet(this, EventArgs.Empty);
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dtpDate_ValueChanged(object sender, EventArgs e) { }

        private void PhieuNhapGUI_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            LoadNhanVien();
            LoadNhacungCap();
            dataGridView1.CellClick += PhieuNhap_CellClick;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void formThemPhieuNhap2_Load(object sender, EventArgs e) { }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            btnSearch_Click(this, EventArgs.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { }
    }
}
