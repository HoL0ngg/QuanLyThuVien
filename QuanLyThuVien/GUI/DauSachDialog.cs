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

            dgvTacGiaChon.AutoGenerateColumns = false;
            dgvTacGiaChon.Columns.Clear();

            // Thiết lập cột cho DataGridView
            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.Name = "MaTacGia";
            colMa.HeaderText = "Mã";
            colMa.DataPropertyName = "maTacGia";
            colMa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colMa.Width = 50;

            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.Name = "TenTacGia";
            colTen.HeaderText = "Tên Tác Giả";
            colTen.DataPropertyName = "tenTacGia";
            colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvTacGiaChon.Columns.Add(colMa);
            dgvTacGiaChon.Columns.Add(colTen);

            // Áp dụng chế độ DETAILS
            if (mode == "DETAILS")
            {
                ApplyDetailsMode();
            }
        }

        /// <summary>
        /// Áp dụng chế độ xem chi tiết - vô hiệu hóa tất cả controls
        /// </summary>
        private void ApplyDetailsMode()
        {
            // Đặt tất cả TextBox thành ReadOnly
            SetControlsReadOnly(this);
            
            // Vô hiệu hóa các nút
            button1.Enabled = false; // Nút chọn ảnh
            button2.Enabled = false; // Nút Lưu
            button4.Enabled = false; // Nút Thêm tác giả
            button5.Enabled = false; // Nút Xóa tác giả
            
            // Đổi text nút Hủy thành Đóng
            button3.Text = "Đóng";
            
            // Cập nhật tiêu đề form
            this.Text = "Chi tiết đầu sách";
        }

        /// <summary>
        /// Duyệt đệ quy và đặt ReadOnly cho tất cả controls
        /// </summary>
        private void SetControlsReadOnly(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // TextBox -> ReadOnly
                if (ctrl is TextBox textBox)
                {
                    textBox.ReadOnly = true;
                    textBox.BackColor = Color.FromArgb(245, 245, 245);
                }
                // ComboBox -> Disabled
                else if (ctrl is ComboBox comboBox)
                {
                    comboBox.Enabled = false;
                }
                // DateTimePicker -> Disabled
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Enabled = false;
                }
                // NumericUpDown -> ReadOnly
                else if (ctrl is NumericUpDown numeric)
                {
                    numeric.ReadOnly = true;
                }
                // DataGridView -> ReadOnly
                else if (ctrl is DataGridView dgv)
                {
                    dgv.ReadOnly = true;
                }
                
                // Đệ quy vào các container con (Panel, GroupBox, TabControl, ...)
                if (ctrl.HasChildren)
                {
                    SetControlsReadOnly(ctrl);
                }
            }
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
                    
                    // Load hình ảnh
                    if (!string.IsNullOrEmpty(dauSach.HinhAnh))
                    {
                        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string projectRoot = Path.GetFullPath(Path.Combine(appDirectory, @"..\.."));
                        string imagePath = Path.Combine(projectRoot, dauSach.HinhAnh);
                        
                        if (File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath);
                            this.newImagePath = dauSach.HinhAnh;
                        }
                    }
                    
                    // Load danh sách tác giả
                    List<TacGiaDTO> tacGiaList = DauSachBUS.Instance.GetTacGiaByDauSachID(dauSachID);
                    danhSachTacGiaChon = tacGiaList;
                    RefreshTacGiaGrid();
                }
            }
            
            // Cập nhật tiêu đề theo mode
            switch (mode)
            {
                case "ADD":
                    this.Text = "Thêm đầu sách mới";
                    break;
                case "EDIT":
                    this.Text = "Sửa đầu sách";
                    break;
                case "DETAILS":
                    this.Text = "Chi tiết đầu sách";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == "DETAILS")
            {
                MessageBox.Show("Chế độ xem chi tiết, không thể thay đổi ảnh bìa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            OpenFileDialog openFile = new OpenFileDialog();
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
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshTacGiaGrid()
        {
            dgvTacGiaChon.DataSource = null;
            dgvTacGiaChon.DataSource = danhSachTacGiaChon;

            if (dgvTacGiaChon.Columns.Contains("maTacGia"))
            {
                dgvTacGiaChon.Columns["maTacGia"].HeaderText = "Mã";
                dgvTacGiaChon.Columns["maTacGia"].Width = 50;
            }
            if (dgvTacGiaChon.Columns.Contains("tenTacGia"))
            {
                dgvTacGiaChon.Columns["tenTacGia"].HeaderText = "Tên Tác Giả";
                dgvTacGiaChon.Columns["tenTacGia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            
            // Ẩn các cột không cần thiết
            if (dgvTacGiaChon.Columns.Contains("namSinh"))
                dgvTacGiaChon.Columns["namSinh"].Visible = false;
            if (dgvTacGiaChon.Columns.Contains("quocTich"))
                dgvTacGiaChon.Columns["quocTich"].Visible = false;
        }

        private void LoadComboBoxes()
        {
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
            // Lấy dữ liệu từ form
            string tenSach = txtTenDauSach.Text.Trim();
            int maNXB = Convert.ToInt32(cmbNXB.SelectedValue);
            string namXuatBan = txtNamXuatBan.Text.Trim();
            string ngonNgu = txtNgonNgu.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Vui lòng nhập tên đầu sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDauSach.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.newImagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh bìa cho đầu sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (danhSachTacGiaChon.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một tác giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // LINQ: Lấy danh sách mã tác giả
            List<int> maTacGiaList = danhSachTacGiaChon
                .Select(tg => tg.maTacGia)
                .ToList();

            try
            {
                bool result = false;
                
                if (mode == "ADD")
                {
                    // TODO: replace 1 with a UI input (NumericUpDown) when you add quantity control
                    int soLuong = 1;
                    result = DauSachBUS.Instance.AddDauSach(
                        tenSach, maNXB, this.newImagePath, namXuatBan, ngonNgu, maTacGiaList, soLuong);
                    
                    if (result)
                    {
                        MessageBox.Show("Thêm đầu sách thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm đầu sách thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (mode == "EDIT")
                {
                    result = DauSachBUS.Instance.UpdateDauSach(dauSachID, tenSach, maNXB, this.newImagePath, namXuatBan, ngonNgu, maTacGiaList);
                    
                    if (result)
                    {
                        MessageBox.Show("Cập nhật đầu sách thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đầu sách thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mode == "DETAILS")
            {
                MessageBox.Show("Chế độ xem chi tiết, không thể thêm tác giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            using (ChonTacGiaDialog dialog = new ChonTacGiaDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    List<TacGiaDTO> authorsFromDialog = dialog.SelectedAuthors;

                    // LINQ: Thêm tác giả mới, tránh trùng lặp
                    foreach (var author in authorsFromDialog)
                    {
                        if (!danhSachTacGiaChon.Any(a => a.maTacGia == author.maTacGia))
                        {
                            danhSachTacGiaChon.Add(author);
                        }
                    }
                    
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
                MessageBox.Show("Chế độ xem chi tiết, không thể xóa tác giả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (dgvTacGiaChon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tác giả để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedMaTacGia = Convert.ToInt32(dgvTacGiaChon.SelectedRows[0].Cells["MaTacGia"].Value);
            
            // LINQ: Tìm và xóa tác giả
            var authorToRemove = danhSachTacGiaChon
                .FirstOrDefault(a => a.maTacGia == selectedMaTacGia);

            if (authorToRemove != null)
            {
                danhSachTacGiaChon.Remove(authorToRemove);
                RefreshTacGiaGrid();
            }
        }
    }
}
