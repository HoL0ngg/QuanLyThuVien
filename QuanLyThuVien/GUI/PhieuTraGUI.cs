using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.Components;
using QuanLyThuVien.GUI.phieutra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class PhieuTraGUI : BaseModuleUC
    {
        private List<PhieuTraDTO> danhSachTatCaPhieuTra; 
        private ThemPhieuTra ucThemPhieuTra;
        private int maNhanVien;

        public PhieuTraGUI()
        {
            InitializeComponent();
            SetupComponents();
            InitializeActionButtons();
        }

        //public PhieuTraGUI(TaiKhoanDTO user) : this()
        //{
        //    this.CurrentUser = user;
        //    if (user != null)
        //    {
        //        maNhanVien = user.MaNV;
        //    }
        //}

        /// <summary>
        /// Khởi tạo ActionButtonsUC
        /// </summary>
        private void InitializeActionButtons()
        {
            Panel panelActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(10, 5, 10, 5)
            };
            
            this.Controls.Add(panelActions);
            panelActions.BringToFront();
            
            CreateActionButtons(panelActions, DockStyle.Left);
        }

        private void SetupComponents()
        {
            LoadDanhSachPhieuTra();

            ucThemPhieuTra = new ThemPhieuTra
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(ucThemPhieuTra);
            ucThemPhieuTra.CloseRequested += UcThemPhieuTra_CloseRequested;

            searchButton.Click += searchButton_Click;
            textBox1.KeyDown += textBox1_KeyDown;
        }

        private void LoadDanhSachPhieuTra()
        {
            try
            {
                danhSachTatCaPhieuTra = PhieuTraBUS.Instance.GetAllPhieuTra();

                dataGridView1.DataSource = danhSachTatCaPhieuTra;

                dataGridView1.Columns["MaPhieuTra"].HeaderText = "Mã PT";
                dataGridView1.Columns["MaPhieuTra"].Width = 70;

                dataGridView1.Columns["NgayMuon"].HeaderText = "Ngay Muon";
                dataGridView1.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["NgayMuon"].Width = 100;

                dataGridView1.Columns["NgayTraDuKien"].HeaderText = "Han Tra";
                dataGridView1.Columns["NgayTraDuKien"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["NgayTraDuKien"].Width = 100;

                dataGridView1.Columns["NgayTra"].HeaderText = "Ngay Tra";
                dataGridView1.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["NgayTra"].Width = 100;

                dataGridView1.Columns["MaPhieuMuon"].HeaderText = "Ma PM";
                dataGridView1.Columns["MaPhieuMuon"].Width = 70;

                dataGridView1.Columns["TENNV"].HeaderText = "Nhan Vien";
                dataGridView1.Columns["TENNV"].Width = 150;

                dataGridView1.Columns["MADG"].HeaderText = "Mã ĐG";
                dataGridView1.Columns["MADG"].Width = 70;

                dataGridView1.Columns["TENDG"].HeaderText = "Độc Giả";
                dataGridView1.Columns["TENDG"].Width = 180;

                // Ẩn cột không cần thiết (nếu có)
                if (dataGridView1.Columns.Contains("MaNV"))
                    dataGridView1.Columns["MaNV"].Visible = false;

                // Cấu hình grid chung
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi tai danh sach phieu tra: " + ex.Message, "Loi",
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
                {
                    dataGridView2.Columns["MaSach"].HeaderText = "Mã Sách";
                    dataGridView2.Columns["MaSach"].Width = 80;
                }
                if (dataGridView2.Columns.Contains("TenSach"))
                {
                    dataGridView2.Columns["TenSach"].HeaderText = "Tên Sách";
                    dataGridView2.Columns["TenSach"].Width = 280;
                }
                if (dataGridView2.Columns.Contains("TenTacGia"))
                {
                    dataGridView2.Columns["TenTacGia"].HeaderText = "Tác Giả";
                    dataGridView2.Columns["TenTacGia"].Width = 150;
                }

                if (chiTietList == null || chiTietList.Count == 0)
                {
                    dataGridView2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi tai chi tiet phieu tra: " + ex.Message, "Loi",
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
            else
            {
                dataGridView2.DataSource = null; 
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LocTheoMaDocGia();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocTheoMaDocGia();
                e.SuppressKeyPress = true; 
            }
        }

        private void LocTheoMaDocGia()
        {
            string input = textBox1.Text.Trim();

            List<PhieuTraDTO> ketQua;

            if (string.IsNullOrEmpty(input))
            {
                ketQua = danhSachTatCaPhieuTra;
                label1.Text = "Mã độc giả:";
            }
            else if (int.TryParse(input, out int maDG))
            {
                ketQua = danhSachTatCaPhieuTra
                         .Where(pt => pt.MADG == maDG)
                         .ToList();

                if (ketQua.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy phiếu trả nào của độc giả có mã {maDG}",
                                    "Không có kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                label1.Text = $"Mã độc giả: {maDG} ({ketQua.Count} phiếu)";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã độc giả là số nguyên!", "Sai định dạng",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.DataSource = ketQua;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
        }

        public override void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Ban khong co quyen them phieu tra!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ToggleView(true);
        }

        private void ToggleView(bool showThem)
        {
            groupBox1.Visible = !showThem;
            groupBox2.Visible = !showThem;
            groupBox3.Visible = !showThem;
            ucThemPhieuTra.Visible = showThem;

            if (showThem)
                ucThemPhieuTra.BringToFront();
            else
                ucThemPhieuTra.SendToBack();
        }

        private void UcThemPhieuTra_CloseRequested()
        {
            ToggleView(false);
            LoadDanhSachPhieuTra(); 
        }

        public void LoadData()
        {
            LoadDanhSachPhieuTra();
        }
    }
}