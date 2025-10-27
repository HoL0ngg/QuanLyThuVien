﻿using QuanLyThuVien.BUS;
using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI
{
    public partial class DauSachDialog : Form
    {
        private string newImagePath = null;
        private List<TacGiaDTO> danhSachTacGiaChon = new List<TacGiaDTO>();
        public DauSachDialog()
        {
            InitializeComponent();
        }

        private void DauSachDialog_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            // Lọc chỉ file ảnh
            openFile.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFile.FileName;

                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string projectRoot = Path.GetFullPath(Path.Combine(appDirectory, @"..\.."));

                string assetsImgFolder = Path.Combine(projectRoot, "assets", "img");


                if (!Directory.Exists(assetsImgFolder))
                {
                    Directory.CreateDirectory(assetsImgFolder);
                }

                string fileExtension = Path.GetExtension(sourceFilePath);
                string newFileName = Guid.NewGuid().ToString() + fileExtension;
                string destinationFilePath = Path.Combine(assetsImgFolder, newFileName);

                try
                {
                    File.Copy(sourceFilePath, destinationFilePath);

                    pictureBox1.Image = Image.FromFile(destinationFilePath);

                    this.newImagePath = Path.Combine("assets", "img", newFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm helper để làm mới lưới dgvTacGiaChon
        private void RefreshTacGiaGrid()
        {
            dgvTacGiaChon.DataSource = null; // Phải reset
            dgvTacGiaChon.DataSource = danhSachTacGiaChon; // Bind vào List DTO

            // Cấu hình cột sau khi bind
            if (dgvTacGiaChon.Columns.Count > 0)
            {
                dgvTacGiaChon.Columns["MaTacGia"].HeaderText = "Mã";
                dgvTacGiaChon.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
                dgvTacGiaChon.Columns["TenTacGia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadComboBoxes()
        {
            // Load nhà xuất bản
            var nxbData = BUS.NxbBUS.Instance.getAllNxb();
            cmbNXB.DataSource = nxbData;
            cmbNXB.DisplayMember = "TenNXB";
            cmbNXB.ValueMember = "MaNXB";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ form
            string tenSach = txtTenDauSach.Text.Trim();
            //int maTacGia = (int)cmbTacGia.SelectedValue;
            int maNXB = (int)cmbNXB.SelectedValue;
            string namXuatBan = txtNamXuatBan.Text.Trim();
            string ngonNgu = txtNgonNgu.Text.Trim();
            Console.WriteLine(tenSach, maNXB, namXuatBan, ngonNgu);
            // 2. Validate
            if (string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Vui lòng nhập tên đầu sách!");
                return;
            }

            // (Quan trọng) Kiểm tra xem người dùng đã chọn ảnh chưa
            if (string.IsNullOrEmpty(this.newImagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh bìa cho đầu sách!");
                return;
            }

            if (danhSachTacGiaChon.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một tác giả!");
                return;
            }

            List<int> maTacGiaList = danhSachTacGiaChon.Select(tacgia => tacgia.maTacGia).ToList();

            // 3. Gọi BUS để thêm
            bool result = DauSachBUS.Instance.AddDauSach(tenSach, maNXB, this.newImagePath, namXuatBan, ngonNgu, maTacGiaList);
            try
            {

                if (result)
                {
                    MessageBox.Show("Thêm đầu sách thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm đầu sách thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ChonTacGiaDialog dialog = new ChonTacGiaDialog())
            {
                // Mở dialog
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy danh sách tác giả đã chọn từ dialog
                    List<TacGiaDTO> authorsFromDialog = dialog.SelectedAuthors;

                    // Thêm vào danh sách chính (tránh trùng lặp)
                    foreach (var author in authorsFromDialog)
                    {
                        // Dùng LINQ để kiểm tra xem tác giả đã tồn tại chưa
                        if (!danhSachTacGiaChon.Any(a => a.maTacGia == author.maTacGia))
                        {
                            danhSachTacGiaChon.Add(author);
                        }
                    }

                    // Cập nhật lại DataGridView
                    RefreshTacGiaGrid();
                }
            }
        }
    }
}
