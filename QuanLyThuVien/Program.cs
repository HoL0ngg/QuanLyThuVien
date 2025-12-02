using QuanLyThuVien.GUI;
using QuanLyThuVien.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Khởi tạo custom fonts (Roboto)
            FontManager.Initialize();
            
            Application.Run(new LoginForm());
            
            // Cleanup fonts khi thoát
            FontManager.Dispose();
        }
    }
}
