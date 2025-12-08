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
        public TraForm(PhieuMuonDTO dto)
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
        }

        public void setUpTable()
        {
            var listLoai = new List<object>()
            {   new { MaLoai = 1, TenLoai = "Trả đúng hạn" },
                new { MaLoai = 2, TenLoai = "Trả muộn" },
                new { MaLoai = 3, TenLoai = "Làm hỏng" },
                new { MaLoai = 4, TenLoai = "Làm mất" }
            };

            StatusColumn.DataSource = listLoai;
            StatusColumn.DisplayMember = "TenLoai";
            StatusColumn.ValueMember = "MaLoai";
            IdColumn.DataPropertyName = "MaSach";

            MdsCoulum.DataPropertyName = "MaDauSach";
            NameColumn.DataPropertyName = "TenDauSach";

            dataGridView1.AutoGenerateColumns = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            PhieuTraDTO pt = new PhieuTraDTO();
            pt.MaPhieuMuon = phieuMuonDTO.MaPhieuMuon;
            pt.MaNV = 1;
            pt.NgayTra = DateTime.Today;
            pt.NgayTraDuKien = phieuMuonDTO.NgayTraDuKien;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var maSach = Convert.ToInt32(row.Cells["IdColumn"].Value);
                var ctpm = phieuMuonDTO.CTPM.FirstOrDefault(x => x.MaSach == maSach);

                if (ctpm == null) continue;

                var statusCell = row.Cells["StatusColumn"] as DataGridViewComboBoxCell;
                int trangThai = Convert.ToInt32(statusCell?.Value ?? 1); 

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
                MessageBox.Show("Trả sách thất bại");
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
