using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.Components
{
    public partial class ActionButtonsUC : UserControl
    {
        #region Events
        public event EventHandler OnAddClick;
        public event EventHandler OnEditClick;
        public event EventHandler OnDeleteClick;
        public event EventHandler OnDetailClick;
        #endregion

        #region Properties
        public bool ShowAddButton
        {
            get => panelAdd != null && panelAdd.Visible;
            set { if (panelAdd != null) panelAdd.Visible = value; }
        }
        
        public bool ShowEditButton
        {
            get => panelEdit != null && panelEdit.Visible;
            set { if (panelEdit != null) panelEdit.Visible = value; }
        }
        
        public bool ShowDeleteButton
        {
            get => panelDelete != null && panelDelete.Visible;
            set { if (panelDelete != null) panelDelete.Visible = value; }
        }
        
        public bool ShowDetailButton
        {
            get => panelDetail != null && panelDetail.Visible;
            set { if (panelDetail != null) panelDetail.Visible = value; }
        }

        public bool EnableAddButton
        {
            get => panelAdd != null && panelAdd.Enabled;
            set { if (panelAdd != null) SetButtonEnabled(panelAdd, value, addColor); }
        }

        public bool EnableEditButton
        {
            get => panelEdit != null && panelEdit.Enabled;
            set { if (panelEdit != null) SetButtonEnabled(panelEdit, value, editColor); }
        }

        public bool EnableDeleteButton
        {
            get => panelDelete != null && panelDelete.Enabled;
            set { if (panelDelete != null) SetButtonEnabled(panelDelete, value, deleteColor); }
        }

        public bool EnableDetailButton
        {
            get => panelDetail != null && panelDetail.Enabled;
            set { if (panelDetail != null) SetButtonEnabled(panelDetail, value, detailColor); }
        }
        #endregion

        #region Private Fields
        private Panel panelAdd;
        private Panel panelEdit;
        private Panel panelDelete;
        private Panel panelDetail;
        private FlowLayoutPanel flowPanel;
        
        private readonly Color addColor = Color.FromArgb(76, 175, 80);
        private readonly Color editColor = Color.FromArgb(33, 150, 243);
        private readonly Color deleteColor = Color.FromArgb(244, 67, 54);
        private readonly Color detailColor = Color.FromArgb(156, 39, 176);
        private readonly Color disabledColor = Color.FromArgb(189, 189, 189);
        #endregion

        public ActionButtonsUC()
        {
            InitializeComponent();
            SetupButtons();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ActionButtonsUC
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "ActionButtonsUC";
            this.Size = new System.Drawing.Size(680, 55);
            this.ResumeLayout(false);

        }

        private void SetupButtons()
        {
            flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = false,
                Padding = new Padding(5, 0, 0, 0),
                Margin = new Padding(0),
                BackColor = Color.Transparent
            };

            panelAdd = CreateActionButton("THÊM", addColor);
            panelEdit = CreateActionButton("SỬA", editColor);
            panelDelete = CreateActionButton("XÓA", deleteColor);
            panelDetail = CreateActionButton("CHI TIẾT", detailColor);

            SetupButtonEvents(panelAdd, addColor, () => OnAddClick?.Invoke(this, EventArgs.Empty));
            SetupButtonEvents(panelEdit, editColor, () => OnEditClick?.Invoke(this, EventArgs.Empty));
            SetupButtonEvents(panelDelete, deleteColor, () => OnDeleteClick?.Invoke(this, EventArgs.Empty));
            SetupButtonEvents(panelDetail, detailColor, () => OnDetailClick?.Invoke(this, EventArgs.Empty));

            flowPanel.Controls.Add(panelAdd);
            flowPanel.Controls.Add(panelEdit);
            flowPanel.Controls.Add(panelDelete);
            flowPanel.Controls.Add(panelDetail);

            this.Controls.Add(flowPanel);
        }

        private Panel CreateActionButton(string text, Color bgColor)
        {
            Panel panel = new Panel
            {
                Size = new Size(160, 42),  // Tăng từ 140 lên 160
                BackColor = bgColor,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 5, 10, 5)
            };

            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(160, 42),  // Tăng từ 140 lên 160
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            panel.Controls.Add(lbl);
            return panel;
        }

        private void SetupButtonEvents(Panel panel, Color originalColor, Action clickAction)
        {
            panel.Click += (s, e) => { if (panel.Enabled) clickAction(); };
            
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.Click += (s, e) => { if (panel.Enabled) clickAction(); };
            }

            panel.MouseEnter += (s, e) =>
            {
                if (panel.Enabled)
                    panel.BackColor = LightenColor(originalColor, 30);
            };

            panel.MouseLeave += (s, e) =>
            {
                if (panel.Enabled)
                    panel.BackColor = originalColor;
            };

            foreach (Control ctrl in panel.Controls)
            {
                ctrl.MouseEnter += (s, e) =>
                {
                    if (panel.Enabled)
                        panel.BackColor = LightenColor(originalColor, 30);
                };
                ctrl.MouseLeave += (s, e) =>
                {
                    if (panel.Enabled)
                        panel.BackColor = originalColor;
                };
            }
        }

        private void SetButtonEnabled(Panel panel, bool enabled, Color originalColor)
        {
            panel.Enabled = enabled;
            panel.BackColor = enabled ? originalColor : disabledColor;
            panel.Cursor = enabled ? Cursors.Hand : Cursors.Default;
            
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = enabled ? Color.White : Color.FromArgb(150, 150, 150);
                }
            }
        }

        private Color LightenColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Min(color.R + amount, 255),
                Math.Min(color.G + amount, 255),
                Math.Min(color.B + amount, 255)
            );
        }

        #region Public Methods
        public void SetPermissions(bool canAdd, bool canEdit, bool canDelete, bool canView)
        {
            EnableAddButton = canAdd;
            EnableEditButton = canEdit;
            EnableDeleteButton = canDelete;
            EnableDetailButton = canView;
        }

        public void HideAllButtons()
        {
            ShowAddButton = false;
            ShowEditButton = false;
            ShowDeleteButton = false;
            ShowDetailButton = false;
        }

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
