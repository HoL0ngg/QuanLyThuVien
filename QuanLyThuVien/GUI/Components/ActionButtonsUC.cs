using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.Components
{
    /// <summary>
    /// UserControl ch?a các nút ch?c n?ng: Thêm, S?a, Xóa, Chi ti?t
    /// Có th? tái s? d?ng trong các module khác nhau
    /// </summary>
    public partial class ActionButtonsUC : UserControl
    {
        #region Events
        
        /// <summary>Event khi nh?n nút Thêm</summary>
        public event EventHandler OnAddClick;
        
        /// <summary>Event khi nh?n nút S?a</summary>
        public event EventHandler OnEditClick;
        
        /// <summary>Event khi nh?n nút Xóa</summary>
        public event EventHandler OnDeleteClick;
        
        /// <summary>Event khi nh?n nút Chi ti?t</summary>
        public event EventHandler OnDetailClick;
        
        #endregion

        #region Properties
        
        /// <summary>Hi?n th?/?n nút Thêm</summary>
        public bool ShowAddButton
        {
            get => panelAdd.Visible;
            set => panelAdd.Visible = value;
        }
        
        /// <summary>Hi?n th?/?n nút S?a</summary>
        public bool ShowEditButton
        {
            get => panelEdit.Visible;
            set => panelEdit.Visible = value;
        }
        
        /// <summary>Hi?n th?/?n nút Xóa</summary>
        public bool ShowDeleteButton
        {
            get => panelDelete.Visible;
            set => panelDelete.Visible = value;
        }
        
        /// <summary>Hi?n th?/?n nút Chi ti?t</summary>
        public bool ShowDetailButton
        {
            get => panelDetail.Visible;
            set => panelDetail.Visible = value;
        }

        /// <summary>Enable/Disable nút Thêm</summary>
        public bool EnableAddButton
        {
            get => panelAdd.Enabled;
            set => SetButtonEnabled(panelAdd, value);
        }

        /// <summary>Enable/Disable nút S?a</summary>
        public bool EnableEditButton
        {
            get => panelEdit.Enabled;
            set => SetButtonEnabled(panelEdit, value);
        }

        /// <summary>Enable/Disable nút Xóa</summary>
        public bool EnableDeleteButton
        {
            get => panelDelete.Enabled;
            set => SetButtonEnabled(panelDelete, value);
        }

        /// <summary>Enable/Disable nút Chi ti?t</summary>
        public bool EnableDetailButton
        {
            get => panelDetail.Enabled;
            set => SetButtonEnabled(panelDetail, value);
        }

        #endregion

        #region Private Fields
        
        private Panel panelAdd;
        private Panel panelEdit;
        private Panel panelDelete;
        private Panel panelDetail;
        
        // Màu s?c
        private readonly Color addColor = Color.FromArgb(76, 175, 80);      // Green
        private readonly Color editColor = Color.FromArgb(33, 150, 243);    // Blue
        private readonly Color deleteColor = Color.FromArgb(244, 67, 54);   // Red
        private readonly Color detailColor = Color.FromArgb(156, 39, 176);  // Purple
        private readonly Color disabledColor = Color.FromArgb(189, 189, 189); // Gray
        
        #endregion

        public ActionButtonsUC()
        {
            InitializeComponent();
            SetupButtons();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            this.Name = "ActionButtonsUC";
            this.Size = new Size(600, 55);
            this.ResumeLayout(false);
        }

        private void SetupButtons()
        {
            // FlowLayoutPanel ?? ch?a các button
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = false,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // T?o các button
            panelAdd = CreateActionButton("THÊM", addColor, Properties.Resources.addIcon);
            panelEdit = CreateActionButton("S?A", editColor, Properties.Resources.editIcon);
            panelDelete = CreateActionButton("XÓA", deleteColor, Properties.Resources.removeIcon);
            panelDetail = CreateActionButton("CHI TI?T", detailColor, Properties.Resources.detailIcon);

            // Gán s? ki?n click
            SetupButtonEvents(panelAdd, () => OnAddClick?.Invoke(this, EventArgs.Empty));
            SetupButtonEvents(panelEdit, () => OnEditClick?.Invoke(this, EventArgs.Empty));
            SetupButtonEvents(panelDelete, () => OnDeleteClick?.Invoke(this, EventArgs.Empty));
            SetupButtonEvents(panelDetail, () => OnDetailClick?.Invoke(this, EventArgs.Empty));

            // Thêm vào flow panel
            flowPanel.Controls.Add(panelAdd);
            flowPanel.Controls.Add(panelEdit);
            flowPanel.Controls.Add(panelDelete);
            flowPanel.Controls.Add(panelDetail);

            this.Controls.Add(flowPanel);
        }

        private Panel CreateActionButton(string text, Color bgColor, Image icon)
        {
            Panel panel = new Panel
            {
                Size = new Size(130, 45),
                BackColor = bgColor,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 5, 12, 5),
                Tag = bgColor // L?u màu g?c ?? restore khi hover
            };

            // Icon
            PictureBox picIcon = new PictureBox
            {
                Image = icon,
                Size = new Size(28, 28),
                Location = new Point(12, 8),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };

            // Label
            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(48, 12),
                BackColor = Color.Transparent
            };

            panel.Controls.Add(picIcon);
            panel.Controls.Add(lbl);

            // Paint event ?? v? bo góc
            panel.Paint += (s, e) => DrawRoundedPanel(panel, e);

            return panel;
        }

        private void SetupButtonEvents(Panel panel, Action clickAction)
        {
            // Click event cho panel và t?t c? controls con
            panel.Click += (s, e) => clickAction();
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (s, e) => clickAction();
            }

            // Hover effects
            Color originalColor = (Color)panel.Tag;
            
            panel.MouseEnter += (s, e) => 
            {
                if (panel.Enabled)
                    panel.BackColor = LightenColor(originalColor, 20);
            };
            
            panel.MouseLeave += (s, e) => 
            {
                if (panel.Enabled)
                    panel.BackColor = originalColor;
            };

            panel.MouseDown += (s, e) =>
            {
                if (panel.Enabled)
                    panel.BackColor = DarkenColor(originalColor, 20);
            };

            panel.MouseUp += (s, e) =>
            {
                if (panel.Enabled)
                    panel.BackColor = LightenColor(originalColor, 20);
            };

            // Propagate hover events t? child controls
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.MouseEnter += (s, e) =>
                {
                    if (panel.Enabled)
                        panel.BackColor = LightenColor(originalColor, 20);
                };
                ctrl.MouseLeave += (s, e) =>
                {
                    if (panel.Enabled)
                        panel.BackColor = originalColor;
                };
            }
        }

        private void SetButtonEnabled(Panel panel, bool enabled)
        {
            panel.Enabled = enabled;
            Color originalColor = (Color)panel.Tag;
            panel.BackColor = enabled ? originalColor : disabledColor;
            panel.Cursor = enabled ? Cursors.Hand : Cursors.Default;
        }

        private void DrawRoundedPanel(Panel panel, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            int radius = 6;
            
            using (GraphicsPath path = GetRoundedRectPath(rect, radius))
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }

        private Color LightenColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Min(color.R + amount, 255),
                Math.Min(color.G + amount, 255),
                Math.Min(color.B + amount, 255)
            );
        }

        private Color DarkenColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Max(color.R - amount, 0),
                Math.Max(color.G - amount, 0),
                Math.Max(color.B - amount, 0)
            );
        }

        #region Public Methods

        /// <summary>
        /// Thi?t l?p quy?n cho các nút d?a trên quy?n c?a user
        /// </summary>
        public void SetPermissions(bool canAdd, bool canEdit, bool canDelete, bool canView)
        {
            EnableAddButton = canAdd;
            EnableEditButton = canEdit;
            EnableDeleteButton = canDelete;
            EnableDetailButton = canView;
        }

        /// <summary>
        /// ?n t?t c? các nút
        /// </summary>
        public void HideAllButtons()
        {
            ShowAddButton = false;
            ShowEditButton = false;
            ShowDeleteButton = false;
            ShowDetailButton = false;
        }

        /// <summary>
        /// Hi?n t?t c? các nút
        /// </summary>
        public void ShowAllButtons()
        {
            ShowAddButton = true;
            ShowEditButton = true;
            ShowDeleteButton = true;
            ShowDetailButton = true;
        }

        #endregion
    }
}
