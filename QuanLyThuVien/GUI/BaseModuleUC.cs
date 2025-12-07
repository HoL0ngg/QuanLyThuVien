using QuanLyThuVien.BUS;
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
    public partial class BaseModuleUC : UserControl
    {
        // Thông tin người dùng hiện tại
        protected TaiKhoanDTO CurrentUser { get; set; }
        
        // Tên chức năng để kiểm tra quyền (VD: "Nhan Vien", "Phieu Muon", ...)
        protected string TenChucNang { get; set; }
        
        // Các quyền
        protected bool CoQuyenXem { get; set; } = true;
        protected bool CoQuyenThem { get; set; } = true;
        protected bool CoQuyenSua { get; set; } = true;
        protected bool CoQuyenXoa { get; set; } = true;

        public BaseModuleUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Thiết lập người dùng và tên chức năng, sau đó kiểm tra quyền
        /// </summary>
        public virtual void SetupPermission(TaiKhoanDTO user, string tenChucNang)
        {
            this.CurrentUser = user;
            this.TenChucNang = tenChucNang;
            
            if (user == null || string.IsNullOrEmpty(tenChucNang))
            {
                // Mặc định có tất cả quyền nếu không có thông tin
                return;
            }

            // Kiểm tra từng quyền
            CoQuyenXem = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "XEM");
            CoQuyenThem = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "THEM");
            CoQuyenSua = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "SUA");
            CoQuyenXoa = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "XOA");
        }

        /// <summary>
        /// Kiểm tra có ít nhất 1 quyền không (để hiển thị menu)
        /// </summary>
        public bool CoItNhatMotQuyen()
        {
            return CoQuyenXem || CoQuyenThem || CoQuyenSua || CoQuyenXoa;
        }

        public virtual void OnAdd()
        {
            if (!CoQuyenThem)
            {
                MessageBox.Show("Bạn không có quyền thêm mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mặc định không làm gì - để lớp con override
        }

        public virtual void OnEdit()
        {
            if (!CoQuyenSua)
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mặc định không làm gì - để lớp con override
        }

        public virtual void OnDelete()
        {
            if (!CoQuyenXoa)
            {
                MessageBox.Show("Bạn không có quyền xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mặc định không làm gì - để lớp con override
        }

        public virtual void OnDetails()
        {
            if (!CoQuyenXem)
            {
                MessageBox.Show("Bạn không có quyền xem chi tiết!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mặc định không làm gì - để lớp con override
        }

        // Bạn cũng có thể thêm các hàm chung khác như Tải dữ liệu, Tìm kiếm...
        public virtual void LoadData()
        {
            // Mặc định không làm gì
        }

        private void BaseModuleUC_Load(object sender, EventArgs e)
        {

        }
    }
}
