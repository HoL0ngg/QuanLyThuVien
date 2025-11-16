using QuanLyThuVien.BUS;
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
        private string mode;
        private int dauSachID;
        public DauSachDialog(string mode, int dauSachID)
        {
            InitializeComponent();
            this.mode = mode;
            this.dauSachID = dauSachID;

            dgvTacGiaChon.AutoGenerateColumns = false; // Tắt tự động tạo cột
            dgvTacGiaChon.Columns.Clear();

            if (mode == "DETAILS")
            {
                // Vô hiệu hóa tất cả các điều khiển nhập liệu
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox || ctrl is ComboBox || ctrl is Button)
                    {
                        ctrl.Enabled = false;
                    }
                }
                button1.Enabled = false; // Vô hiệu hóa nút chọn ảnh
                button2.Enabled = false; // Vô hiệu hóa nút Lưu
                button4.Enabled = false; // Vô hiệu hóa nút Thêm tác giả
                button5.Enabled = false; // Vô hiệu hóa nút Xóa tác giả
            }

            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.Name = "MaTacGia";           // Tên nội bộ
            colMa.HeaderText = "Mã";            // Chữ hiển thị
            colMa.DataPropertyName = "MaTacGia"; // Map với thuộc tính MaTacGia của DTO
            colMa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Tắt tự động size
            colMa.Width = 50;                   // Đặt độ rộng cố định

            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.Name = "TenTacGia";
            colTen.HeaderText = "Tên Tác Giả";
            colTen.DataPropertyName = "TenTacGia"; // Map với thuộc tính TenTacGia của DTO
            colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Tự lấp đầy

            dgvTacGiaChon.Columns.Add(colMa);
            dgvTacGiaChon.Columns.Add(colTen);
        }

        private void DauSachDialog_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            if (dauSachID != 0)
            {
                var dauSach = DauSachBUS.Instance.GetDauSachByID(dauSachID);
                if (dauSach != null)
                {
                    txtTenDauSach.Text = dauSach.TenDauSach;
                    cmbNXB.SelectedValue = dauSach.NhaXuatBan;
                    txtNamXuatBan.Text = dauSach.NamXuatBan.ToString();
                    txtNgonNgu.Text = dauSach.NgonNgu;
                    if (!string.IsNullOrEmpty(dauSach.HinhAnh))
                    {
                        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string projectRoot = Path.GetFullPath(Path.Combine(appDirectory, @"..\.."));
                        string imagePath = Path.Combine(projectRoot, dauSach.HinhAnh);
                        if (File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath);
                            this.newImagePath = dauSach.HinhAnh; // Giữ nguyên đường dẫn ảnh hiện tại
                        }
                    }
                    List<TacGiaDTO> tacGiaListhihi = DauSachBUS.Instance.GetTacGiaByDauSachID(dauSachID);
                    danhSachTacGiaChon = tacGiaListhihi;
                    RefreshTacGiaGrid();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == "DETAILS")
            {
                MessageBox.Show("Chế độ xem chi tiết, không thể thay đổi ảnh bìa!");
                return;
            }
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

            //Cấu hình cột sau khi bind
            if (dgvTacGiaChon.Columns.Count > 0)
            {
                dgvTacGiaChon.Columns["MaTacGia"].HeaderText = "Mã";
                dgvTacGiaChon.Columns["MaTacGia"].Width = 50;
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
            if (mode == "ADD")
            {

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
            else if (mode == "EDIT")
            {
                bool result = DauSachBUS.Instance.UpdateDauSach(dauSachID, tenSach, maNXB, this.newImagePath, namXuatBan, ngonNgu, maTacGiaList);
                try
                {
                    if (result)
                    {
                        MessageBox.Show("Cập nhật đầu sách thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đầu sách thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mode == "DETAILS")
            {
                MessageBox.Show("Chế độ xem chi tiết, không thể thêm tác giả!");
                return;
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mode == "DETAILS")
            {
                MessageBox.Show("Chế độ xem chi tiết, không thể xóa tác giả!");
                return;
            }
            if (dgvTacGiaChon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tác giả để xóa!");
                return;
            }

            int selectedMaTacGia = Convert.ToInt32(dgvTacGiaChon.SelectedRows[0].Cells["MaTacGia"].Value);
            var authorToRemove = danhSachTacGiaChon.FirstOrDefault(a => a.maTacGia == selectedMaTacGia);

            if (authorToRemove != null)
            {
                danhSachTacGiaChon.Remove(authorToRemove);
                RefreshTacGiaGrid();
            }
        }
    }
}
