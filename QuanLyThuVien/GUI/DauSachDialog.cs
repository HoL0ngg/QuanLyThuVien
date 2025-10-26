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
    public partial class DauSachDialog : Form
    {
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
                // Hiển thị ảnh lên PictureBox
                pictureBox1.ImageLocation = openFile.FileName;

                // Bạn cũng nên lưu đường dẫn 'openFile.FileName' này
                // để copy file vào thư mục của ứng dụng hoặc lưu đường dẫn vào CSDL
            }
        }

        private void LoadComboBoxes()
        {
            // Load nhà xuất bản
            var nxbData = BUS.NxbBUS.Instance.getAllNxb();
            comboBox1.DataSource = nxbData;
            comboBox1.DisplayMember = "TenNCC";
            comboBox1.ValueMember = "MaNCC";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
