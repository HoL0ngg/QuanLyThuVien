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
    public partial class PhieuTraGUI : BaseModuleUC
    {
        private List<CTPhieuTraDTO> danhSachChiTiet = new List<CTPhieuTraDTO>();
        private int maNhanVien = 1; // Lấy từ session/login

        public PhieuTraGUI()
        {
            InitializeComponent();
        }

        private void PhieuTraGUI_Load(object sender, EventArgs e)
        {
            LoadPhieuTra();
            LoadPhieuMuonChuaTra();
            dtpNgayTra.Value = DateTime.Now;
        }

        private void LoadPhieuTra()
        {
            try
            {
                List<PhieuTraDTO> list = PhieuTraBUS.Instance.GetAllPhieuTra();
                dgvPhieuTra.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phiếu trả: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhieuMuonChuaTra()
        {
            try
            {
                DataTable dt = PhieuTraBUS.Instance.GetPhieuMuonChuaTra();
                
                cboPhieuMuon.DataSource = dt;
                cboPhieuMuon.DisplayMember = "TenDocGia";
                cboPhieuMuon.ValueMember = "MaPhieuMuon";
                
                if (dt.Rows.Count > 0)
                {
                    cboPhieuMuon.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phiếu mượn: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            if (cboPhieuMuon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cboPhieuMuon.SelectedValue.ToString(), out int maPhieuMuon))
            {
                MessageBox.Show("Mã phiếu mượn không hợp lệ", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                danhSachChiTiet = PhieuTraBUS.Instance.GetSachDangMuonByPhieuMuon(maPhieuMuon);
                dgvChiTiet.DataSource = null;
                dgvChiTiet.DataSource = danhSachChiTiet;
                
                decimal tongTienPhat = PhieuTraBUS.Instance.TinhTongTienPhat(danhSachChiTiet);
                lblTongTienPhat.Text = $"Tổng tiền phạt: {tongTienPhat:#,##0} VNĐ";

                if (danhSachChiTiet.Count == 0)
                {
                    MessageBox.Show("Phiếu mượn này không có sách nào", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm sách đang mượn: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboPhieuMuon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cboPhieuMuon.SelectedValue.ToString(), out int maPhieuMuon))
            {
                MessageBox.Show("Mã phiếu mượn không hợp lệ", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
            {
                MessageBox.Show("Vui lòng tìm sách cần trả trước", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PhieuTraDTO pt = new PhieuTraDTO
                {
                    NgayTra = dtpNgayTra.Value,
                    MaDG = maPhieuMuon,
                    MaNV = maNhanVien,
                    list = danhSachChiTiet
                };

                if (PhieuTraBUS.Instance.ThemPhieuTra(pt))
                {
                    MessageBox.Show("Thêm phiếu trả thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuTra();
                    LoadPhieuMuonChuaTra();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu trả thất bại!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm phiếu trả: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieuTra.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu trả cần xóa", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieuTra = Convert.ToInt32(dgvPhieuTra.CurrentRow.Cells["colMaPhieuTra"].Value);
            
            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phiếu trả {maPhieuTra}?", 
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (PhieuTraBUS.Instance.XoaPhieuTra(maPhieuTra))
                    {
                        MessageBox.Show("Xóa phiếu trả thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPhieuTra();
                        LoadPhieuMuonChuaTra();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu trả thất bại!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phiếu trả: " + ex.Message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPhieuTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maPhieuTra = Convert.ToInt32(dgvPhieuTra.Rows[e.RowIndex].Cells["colMaPhieuTra"].Value);
                LoadChiTietPhieuTra(maPhieuTra);
            }
        }

        private void LoadChiTietPhieuTra(int maPhieuTra)
        {
            try
            {
                List<CTPhieuTraDTO> chiTiet = PhieuTraBUS.Instance.GetChiTietPhieuTra(maPhieuTra);
                dgvChiTiet.DataSource = null;
                dgvChiTiet.DataSource = chiTiet;
                
                decimal tongTienPhat = PhieuTraBUS.Instance.TinhTongTienPhat(chiTiet);
                lblTongTienPhat.Text = $"Tổng tiền phạt: {tongTienPhat:#,##0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhieuTra();
            LoadPhieuMuonChuaTra();
            ClearForm();
        }

        private void ClearForm()
        {
            cboPhieuMuon.SelectedIndex = -1;
            dtpNgayTra.Value = DateTime.Now;
            danhSachChiTiet = new List<CTPhieuTraDTO>();
            dgvChiTiet.DataSource = null;
            lblTongTienPhat.Text = "Tổng tiền phạt: 0 VNĐ";
        }
    }
}
