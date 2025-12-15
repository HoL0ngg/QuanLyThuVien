using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.Components;
using QuanLyThuVien.GUI.phieutra;

namespace QuanLyThuVien.GUI
{
    public partial class PhieuTraGUI : BaseModuleUC
    {
        private List<PhieuTraDTO> danhSachTatCaPhieuTra; 
        private ThemPhieuTra ucThemPhieuTra;
        private int maNhanVien;

        public PhieuTraGUI(TaiKhoanDTO user)
        {
            this.CurrentUser = user;
            if (user != null)
            {
                maNhanVien = user.MaNV;
            }
            InitializeComponent();
            SetupComponents();
        }

        private void SetupComponents()
        {
            LoadDanhSachPhieuTra();

            ucThemPhieuTra = new ThemPhieuTra(maNhanVien)
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
            var danhSachTatCaPhieuTra = PhieuTraBUS.Instance.GetAllPhieuTra();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "MaPhieuTra", HeaderText = "Mã Phiếu Trả", DataPropertyName = "MaPhieuTra", Width = 70 },
                new DataGridViewTextBoxColumn { Name = "NgayMuon", HeaderText = "Ngày Mượn", DataPropertyName = "NgayMuon", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }, Width = 100 },
                new DataGridViewTextBoxColumn { Name = "NgayTraDuKien", HeaderText = "Hạn Trả", DataPropertyName = "NgayTraDuKien", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }, Width = 100 },
                new DataGridViewTextBoxColumn { Name = "NgayTra", HeaderText = "Ngày Trả", DataPropertyName = "NgayTra", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }, Width = 100 },
                new DataGridViewTextBoxColumn { Name = "MaPhieuMuon", HeaderText = "Mã Phiếu Mượn", DataPropertyName = "MaPhieuMuon", Width = 70 },
                new DataGridViewTextBoxColumn { Name = "TENNV", HeaderText = "Nhân Viên", DataPropertyName = "TENNV", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "MADG", HeaderText = "Mã Độc Giả", DataPropertyName = "MADG", Width = 70 },
                new DataGridViewTextBoxColumn { Name = "TENDG", HeaderText = "Tên Độc Giả", DataPropertyName = "TENDG", Width = 180 }
            });

            // Bind data
            dataGridView1.DataSource = danhSachTatCaPhieuTra;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void LoadChiTietPhieuTra(int maPhieuTra)
        {
            var chiTietList = PhieuTraBUS.Instance.GetCTPhieuTraById(maPhieuTra);
            dataGridView2.Columns.Clear();

            dataGridView2.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "MaSach", HeaderText = "Mã Sách", DataPropertyName = "MaSach" },
                new DataGridViewTextBoxColumn { Name = "TenSach", HeaderText = "Tên Sách", DataPropertyName = "TenSach" },
                new DataGridViewTextBoxColumn { Name = "TenTacGia", HeaderText = "Tác Giả", DataPropertyName = "TenTacGia" },
                new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai" }
            });

            dataGridView2.DataSource = chiTietList;

            if (chiTietList == null || chiTietList.Count == 0)
            {
                dataGridView2.DataSource = null;
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
                label1.Text = "Ma doc gia:";
            }
            else if (int.TryParse(input, out int maDG))
            {
                ketQua = danhSachTatCaPhieuTra
                         .Where(pt => pt.MADG == maDG)
                         .ToList();

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Khong tim thay phieu tra nao cua doc gia co ma " + maDG,
                                    "Khong co ket qua", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                label1.Text = "Ma doc gia: " + maDG + " (" + ketQua.Count + " phieu)";
            }
            else
            {
                MessageBox.Show("Vui long nhap ma doc gia la so nguyen!", "Sai dinh dang",
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

        public override void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Ban khong co quyen xoa phieu tra!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot phieu tra de xoa.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var idCell = dataGridView1.CurrentRow.Cells["MaPhieuTra"];
            if (idCell?.Value == null || !int.TryParse(idCell.Value.ToString(), out int id)) return;

            var confirm = MessageBox.Show("Ban co chac muon xoa phieu tra co ID " + id + " khong?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                if (PhieuTraBUS.Instance.Delete(id)) LoadData();
                else MessageBox.Show("Xoa khong thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi xoa: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string MapTrangThai(object value)
        {
            if (value == null || !int.TryParse(value.ToString(), out int v)) return string.Empty;
            switch (v)
            {
                case 1: return "Tra dung han";
                case 2: return "Tra muon";
                case 3: return "Lam hong";
                case 4: return "Lam mat";
                default: return v.ToString();
            }
        }

        private void BangPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView2.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                e.Value = MapTrangThai(e.Value);
                e.FormattingApplied = true;
            }
        }

        private void ToggleView(bool showThem)
        {
            // With the new layout: show/hide the top search group and the split container list/detail
            groupBoxInfo.Visible = !showThem;
            splitContainerMain.Visible = !showThem;

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
            LoadDanhSachPhieuTra(); 
        }

        public override void LoadData()
        {
            LoadDanhSachPhieuTra();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}