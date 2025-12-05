using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.phieutra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class PhieuTraGUI : BaseModuleUC
    {
        private List<CTPhieuTraDTO> danhSachChiTiet = new List<CTPhieuTraDTO>();
        private int maNhanVien = 1; // Lấy từ session/login
        private ThemPhieuTra ucThemPhieuTra;

        public PhieuTraGUI()
        {
            InitializeComponent();
            LoadDanhSachPhieuTra();
            ucThemPhieuTra = new ThemPhieuTra
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(ucThemPhieuTra);
            ucThemPhieuTra.CloseRequested += UcThemPhieuTra_CloseRequested;
            ucThemPhieuTra.BringToFront();
        }

        private void LoadDanhSachPhieuTra()
        {
            try
            {
                var danhSachPhieuTra = PhieuTraBUS.Instance.GetAllPhieuTra();

                dataGridView1.DataSource = danhSachPhieuTra;

            

                dataGridView1.Columns["MaPhieuTra"].HeaderText = "Mã PT";
                dataGridView1.Columns["MaPhieuTra"].Width = 70;

                dataGridView1.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                dataGridView1.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["NgayMuon"].Width = 100;

                dataGridView1.Columns["NgayTraDuKien"].HeaderText = "Hạn Trả";
                dataGridView1.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["NgayTraDuKien"].Width = 100;

                dataGridView1.Columns["NgayTra"].HeaderText = "Ngày Trả";
                dataGridView1.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["NgayTra"].Width = 100;

                dataGridView1.Columns["MaPhieuMuon"].HeaderText = "Mã PM";
                dataGridView1.Columns["MaPhieuMuon"].Width = 70;

                dataGridView1.Columns["TENNV"].HeaderText = "Nhân Viên";
                dataGridView1.Columns["TENNV"].Width = 150;

                dataGridView1.Columns["MADG"].HeaderText = "Mã DG";
                dataGridView1.Columns["MADG"].Width = 70;

                dataGridView1.Columns["TENDG"].HeaderText = "Độc Giả";
                dataGridView1.Columns["TENDG"].Width = 150;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
                dataGridView1.AutoGenerateColumns = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu trả: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadChiTietPhieuTra(int maPhieuTra)
        {
            try
            {
                var chiTietList = PhieuTraBUS.Instance.GetCTPhieuTraById(maPhieuTra);

                dataGridView2.DataSource = chiTietList;

                dataGridView2.RowHeadersVisible = false;
                dataGridView2.ReadOnly = true;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 252, 255);

                if (dataGridView2.Columns.Contains("MaCTPhieuTra"))
                    dataGridView2.Columns["MaCTPhieuTra"].Visible = false; 

                if (dataGridView2.Columns.Contains("MaPhieuTra"))
                    dataGridView2.Columns["MaPhieuTra"].Visible = false;

                if (dataGridView2.Columns.Contains("MaSach"))
                    dataGridView2.Columns["MaSach"].HeaderText = "Mã Sách";
                dataGridView2.Columns["MaSach"].Width = 80;

                dataGridView2.Columns["TenSach"].HeaderText = "Tên Sách";
                dataGridView2.Columns["TenSach"].Width = 280;

                dataGridView2.Columns["TenTacGia"].HeaderText = "Tác Giả";
                dataGridView2.Columns["TenTacGia"].Width = 150;

                if (dataGridView1.Columns.Contains("MaNV"))
                    dataGridView1.Columns["MaNV"].Visible = false;

                if (chiTietList.Count == 0)
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phiếu trả: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int maPhieuTra = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaPhieuTra"].Value);
                LoadChiTietPhieuTra(maPhieuTra);
            }
        }

        public override void OnAdd()
        {
            ToggleView(true);
        }

        private void ToggleView(bool showThem)
        {
            groupBox1.Visible = !showThem;
            groupBox2.Visible = !showThem;
            groupBox3.Visible = !showThem;


            ucThemPhieuTra.Visible = showThem;
            if (showThem)
            {
                ucThemPhieuTra.BringToFront();
            }
            else
            {
                ucThemPhieuTra.SendToBack();
            }
        }

        private void UcThemPhieuTra_CloseRequested()
        {
            ToggleView(false);
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
