using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
using QuanLyThuVien.DAO;
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
    public partial class ChonTacGiaDialog : Form
    {
        // Thuộc tính để Form cha (DauSachDialog) lấy kết quả
        public List<TacGiaDTO> SelectedAuthors { get; private set; }
        public ChonTacGiaDialog()
        {
            InitializeComponent();
            SelectedAuthors = new List<TacGiaDTO>();
        }

        private void ChonTacGiaDialog_Load(object sender, EventArgs e)
        {
            // Find top panel
            Panel topPanel = null;
            if (this.Controls.ContainsKey("panelTop"))
                topPanel = this.Controls.Find("panelTop", true).FirstOrDefault() as Panel;

            // Ensure Add button exists and is added to panelTop
            Button addBtn = null;
            if (this.Controls.ContainsKey("btnTacGiaMoi"))
            {
                addBtn = this.Controls.Find("btnTacGiaMoi", true).FirstOrDefault() as Button;
            }

            if (addBtn == null)
            {
                addBtn = new Button();
                addBtn.Name = "btnTacGiaMoi";
                addBtn.Text = "Tác giả mới";
                addBtn.Size = new Size(100, 28);
                addBtn.TabIndex = 2;
                addBtn.Click += btnTacGiaMoi_Click;

                if (topPanel != null)
                {
                    topPanel.Controls.Add(addBtn);
                }
                else
                {
                    this.Controls.Add(addBtn);
                }
            }

            // Position function
            Action reposition = () =>
            {
                if (topPanel != null)
                {
                    int padding = 10;
                    // place add button at right inside panel
                    addBtn.Location = new Point(Math.Max(padding, topPanel.ClientSize.Width - addBtn.Width - padding), (topPanel.ClientSize.Height - addBtn.Height) / 2);

                    // position label and search textbox
                    if (topPanel.Controls.ContainsKey("label1"))
                    {
                        var lbl = topPanel.Controls.Find("label1", true).FirstOrDefault() as Label;
                        if (lbl != null && txtTimKiemTacGia != null)
                        {
                            int txtLeft = lbl.Right + 8;
                            int txtRight = addBtn.Left - 8;
                            if (txtRight - txtLeft < 100) // ensure minimum width
                                txtRight = txtLeft + 100;
                            txtTimKiemTacGia.Location = new Point(txtLeft, (topPanel.ClientSize.Height - txtTimKiemTacGia.Height) / 2);
                            txtTimKiemTacGia.Width = Math.Max(100, txtRight - txtLeft);
                        }
                    }
                    else if (txtTimKiemTacGia != null)
                    {
                        txtTimKiemTacGia.Location = new Point(10, (topPanel.ClientSize.Height - txtTimKiemTacGia.Height) / 2);
                        txtTimKiemTacGia.Width = Math.Max(100, topPanel.ClientSize.Width - addBtn.Width - 30);
                    }
                }
                else
                {
                    // fallback: ensure btn visible on form
                    addBtn.Location = new Point(Math.Max(10, this.ClientSize.Width - addBtn.Width - 20), 12);
                    if (txtTimKiemTacGia != null)
                    {
                        txtTimKiemTacGia.Location = new Point(90, 15);
                        txtTimKiemTacGia.Width = Math.Max(100, this.ClientSize.Width - addBtn.Width - 140);
                    }
                }

                addBtn.BringToFront();
            };

            // initial position
            reposition();

            // handle resize
            if (topPanel != null)
            {
                topPanel.Resize += (s, ev) => reposition();
            }
            else
            {
                this.Resize += (s, ev) => reposition();
            }

            LoadAllAuthors();
        }

        private void LoadAllAuthors()
        {
            // Tải tất cả tác giả từ BUS (bạn đã có)
            DataTable dt = TacGiaBUS.Instance.GetAllTacGia();
            dgvTatCaTacGia.DataSource = dt;

            // Cấu hình cột
            if (dgvTatCaTacGia.Columns.Contains("MaTacGia"))
                dgvTatCaTacGia.Columns["MaTacGia"].HeaderText = "Mã";
            if (dgvTatCaTacGia.Columns.Contains("TenTacGia"))
            {
                dgvTatCaTacGia.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
                dgvTatCaTacGia.Columns["TenTacGia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void txtTimKiemTacGia_TextChanged(object sender, EventArgs e)
        {
            // Lọc DataGridView dựa trên DataTable
            (dgvTatCaTacGia.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("TenTacGia LIKE '%{0}%'", txtTimKiemTacGia.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvTatCaTacGia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một tác giả.");
                return;
            }

            // Lặp qua tất cả các hàng đang được chọn
            foreach (DataGridViewRow row in dgvTatCaTacGia.SelectedRows)
            {
                DataRowView drv = row.DataBoundItem as DataRowView;

                TacGiaDTO author = new TacGiaDTO
                {
                    maTacGia = Convert.ToInt32(drv["MaTacGia"]),
                    tenTacGia = drv["TenTacGia"].ToString()
                };

                SelectedAuthors.Add(author);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTacGiaMoi_Click(object sender, EventArgs e)
        {
            // Open the dedicated Add Author form instead of running SQL here
            using (var form = new FormThemTacGia())
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        LoadAllAuthors();

                        // If the add form exposes the created name, try to select it
                        string created = form.CreatedTenTacGia;
                        if (!string.IsNullOrWhiteSpace(created))
                        {
                            DataTable dt = dgvTatCaTacGia.DataSource as DataTable;
                            if (dt != null)
                            {
                                var foundRows = dt.Select($"TenTacGia = '{created.Replace("'", "''")}'");
                                if (foundRows.Length > 0)
                                {
                                    int index = dt.Rows.IndexOf(foundRows[0]);
                                    if (index >= 0 && index < dgvTatCaTacGia.Rows.Count)
                                    {
                                        dgvTatCaTacGia.ClearSelection();
                                        dgvTatCaTacGia.Rows[index].Selected = true;
                                        dgvTatCaTacGia.FirstDisplayedScrollingRowIndex = index;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải lại danh sách tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string ShowInputDialog(string text, string caption)
        {
            using (Form prompt = new Form())
            {
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.Width = 420;
                prompt.Height = 150;
                prompt.Text = caption;
                prompt.MinimizeBox = false;
                prompt.MaximizeBox = false;

                Label textLabel = new Label() { Left = 10, Top = 10, Text = text, AutoSize = true };
                TextBox inputBox = new TextBox() { Left = 10, Top = 35, Width = 380 };
                Button confirmation = new Button() { Text = "OK", Left = 220, Width = 75, Top = 70, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Hủy", Left = 305, Width = 75, Top = 70, DialogResult = DialogResult.Cancel };

                confirmation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = confirmation;
                prompt.CancelButton = cancel;

                if (prompt.ShowDialog(this) == DialogResult.OK)
                {
                    return inputBox.Text;
                }
                return null;
            }
        }
    }
}
