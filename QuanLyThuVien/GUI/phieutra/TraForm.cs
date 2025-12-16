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

namespace QuanLyThuVien.GUI.phieutra
{
    public partial class TraForm : Form
    {   
        private PhieuMuonDTO phieuMuonDTO;
        private int maNhanVien;
        public TraForm(PhieuMuonDTO dto, int maNV)
        {
            InitializeComponent();
            setUpTable();
            this.phieuMuonDTO = dto;
            dataGridView1.DataSource = phieuMuonDTO.CTPM;
            maphieuLb.Text = phieuMuonDTO.MaPhieuMuon.ToString();
            ngaymuonLb.Text = phieuMuonDTO.NgayMuon.ToShortDateString();
            ngaytraLb.Text = phieuMuonDTO.NgayTraDuKien.ToShortDateString();
            nhanvienLb.Text = phieuMuonDTO.TenNhanVien;
            docgiaLb.Text = phieuMuonDTO.TenDocGia;
            this.maNhanVien = maNV;
        }

        public void setUpTable()
        {
            // Map combo values to CTPhieuTra.TrangThai semantics:
            // 1 = Bình thường (bao gồm trả đúng hạn và trả muộn), 2 = Hỏng, 3 = Mất
            var listLoai = new List<object>() { 
            //{   new { MaLoai = 1, TenLoai = "Trả đúng hạn" },
                new { MaLoai = 1, TenLoai = "Bình Thường" },
                new { MaLoai = 2, TenLoai = "Làm hỏng" },
                new { MaLoai = 3, TenLoai = "Làm mất" }
            };

            StatusColumn.DataSource = listLoai;
            StatusColumn.DisplayMember = "TenLoai";
            StatusColumn.ValueMember = "MaLoai";
            IdColumn.DataPropertyName = "MaSach";

            MdsCoulum.DataPropertyName = "MaDauSach";
            NameColumn.DataPropertyName = "TenDauSach";

            dataGridView1.AutoGenerateColumns = false;
        }

        private static int NormalizeTrangThai(object rawValue)
        {
            if (rawValue == null) return 1;
            int v;
            if (!int.TryParse(rawValue.ToString(), out v)) return 1;

            // Legacy mapping from old UI values to stored semantics
            // Old: 1=Trả đúng hạn, 2=Trả muộn, 3=Làm hỏng, 4=Làm mất
            // Desired storage: 1=Bình thường, 2=Hỏng, 3=Mất
            switch (v)
            {
                case 1: return 1; // trả đúng hạn -> bình thường
                case 2: return 2; // trả muộn -> bình thường
                case 3: return 3; // làm hỏng -> hỏng
                 // làm mất -> mất
                default: return v; // unknown -> keep
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            PhieuTraDTO pt = new PhieuTraDTO();
            pt.MaPhieuMuon = phieuMuonDTO.MaPhieuMuon;
            pt.MaNV = maNhanVien;
            pt.NgayTra = DateTime.Today;
            pt.NgayTraDuKien = phieuMuonDTO.NgayTraDuKien;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var maSach = Convert.ToInt32(row.Cells["IdColumn"].Value);
                var ctpm = phieuMuonDTO.CTPM.FirstOrDefault(x => x.MaSach == maSach);

                if (ctpm == null) continue;

                var statusCell = row.Cells["StatusColumn"] as DataGridViewComboBoxCell;
                int rawTrangThai = statusCell?.Value != null ? Convert.ToInt32(statusCell.Value) : 1;

                int trangThai = NormalizeTrangThai(rawTrangThai);

                var ctpt = new CTPhieuTraDTO
                {
                    MaSach = ctpm.MaSach,
                    TrangThai = trangThai 
                                              
                };

                pt.list.Add(ctpt);
            }

            var rs = PhieuTraBUS.Instance.InSertPhieuTra(pt);

            if (rs)
            {
                MessageBox.Show("Trả sách thành công");
            }
            else
            {
                MessageBox.Show("Trả sách thất bại" + maNhanVien);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}
