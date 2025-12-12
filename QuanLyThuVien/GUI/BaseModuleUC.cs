using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI.Components;
using System;
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

        // ActionButtons UserControl (optional)
        protected ActionButtonsUC ActionButtons { get; private set; }

        public BaseModuleUC()
        {
            InitializeComponent();
            // Ensure every module fills its parent container by default
            this.Dock = DockStyle.Fill;
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

            // *** QUAN TRỌNG: Admin (MaNhomQuyen <= 1) có tất cả quyền, không cần kiểm tra ***
            if (user.MaNhomQuyen <= 1)
            {
                CoQuyenXem = true;
                CoQuyenThem = true;
                CoQuyenSua = true;
                CoQuyenXoa = true;
            }
            else
            {
                // Kiểm tra từng quyền cho các nhóm quyền khác
                CoQuyenXem = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "XEM");
                CoQuyenThem = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "THEM");
                CoQuyenSua = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "SUA");
                CoQuyenXoa = NhomQuyenBUS.Instance.KiemTraQuyen(user.MaNhomQuyen, tenChucNang, "XOA");
            }

            // Cập nhật quyền cho ActionButtons nếu có
            UpdateActionButtonsPermission();
        }

        /// <summary>
        /// Tạo và thêm ActionButtonsUC vào module
        /// </summary>
        /// <param name="parent">Panel/Control chứa ActionButtons</param>
        /// <param name="dock">Dock style (mặc định Top)</param>
        protected void CreateActionButtons(Control parent, DockStyle dock = DockStyle.Top)
        {
            if (ActionButtons != null)
            {
                parent.Controls.Remove(ActionButtons);
                ActionButtons.Dispose();
            }

            ActionButtons = new ActionButtonsUC
            {
                Dock = dock,
                Height = 55
            };

            // Gán sự kiện
            ActionButtons.OnAddClick += (s, e) => OnAdd();
            ActionButtons.OnEditClick += (s, e) => OnEdit();
            ActionButtons.OnDeleteClick += (s, e) => OnDelete();
            ActionButtons.OnDetailClick += (s, e) => OnDetails();

            parent.Controls.Add(ActionButtons);
            ActionButtons.BringToFront();

            // Cập nhật quyền
            UpdateActionButtonsPermission();
        }

        /// <summary>
        /// Cập nhật trạng thái enable/disable của ActionButtons dựa trên quyền
        /// </summary>
        protected void UpdateActionButtonsPermission()
        {
            if (ActionButtons == null) return;

            ActionButtons.SetPermissions(
                canAdd: CoQuyenThem,
                canEdit: CoQuyenSua,
                canDelete: CoQuyenXoa,
                canView: CoQuyenXem
            );
        }

        /// <summary>
        /// Kiểm tra có ít nhất 1 quyền không (để hiển thị menu)
        /// </summary>
        public bool CoItNhatMotQuyen()
        {
            return CoQuyenXem || CoQuyenThem || CoQuyenSua || CoQuyenXoa;
        }

        /// <summary>
        /// Kiểm tra có phải Admin không
        /// </summary>
        protected bool IsAdmin()
        {
            return CurrentUser != null && CurrentUser.MaNhomQuyen <= 1;
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

        public virtual void LoadData()
        {
            // Mặc định không làm gì
        }

        private void BaseModuleUC_Load(object sender, EventArgs e)
        {
        }
    }
}
