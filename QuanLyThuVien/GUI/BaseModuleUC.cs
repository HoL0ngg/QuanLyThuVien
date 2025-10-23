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
    public partial class BaseModuleUC : UserControl
    {
        public BaseModuleUC()
        {
            InitializeComponent();
        }

        public virtual void OnAdd()
        {
            // Mặc định không làm gì
        }

        public virtual void OnEdit()
        {
            // Mặc định không làm gì
        }

        public virtual void OnDelete()
        {
            // Mặc định không làm gì
        }

        public virtual void OnDetails()
        {
            // Mặc định không làm gì
        }

        // Bạn cũng có thể thêm các hàm chung khác như Tải dữ liệu, Tìm kiếm...
        public virtual void LoadData()
        {
            // Mặc định không làm gì
        }
    }
}
