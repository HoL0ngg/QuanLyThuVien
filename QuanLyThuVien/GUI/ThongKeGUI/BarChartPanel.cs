using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    /// <summary>
    /// UserControl tái s? d?ng ð? hi?n th? bi?u ð? d?ng thanh ngang (horizontal bar chart)
    /// T?I ÝU: S? d?ng custom drawing thay v? t?o nhi?u controls
    /// </summary>
    public partial class BarChartPanel : UserControl
    {
        // Properties
        public string ChartTitle { get; set; }
        public string ValueUnit { get; set; } = "";

        // Lýu tr? d? li?u
        private List<BarChartItem> _currentItems = new List<BarChartItem>();
        
        // Cache ð? tránh resize liên t?c
        private int _lastWidth = 0;
        private Timer _resizeTimer;
        private bool _isLoaded = false;

        // Fonts cache
        private static readonly Font LabelFont = new Font("Segoe UI", 9F);
        private static readonly Font ValueFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        private static readonly Color BgColor = Color.FromArgb(230, 230, 230);
        private static readonly Color TextColor = Color.FromArgb(33, 33, 33);

        public BarChartPanel()
        {
            // Enable double buffering cho smooth rendering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw, true);
            
            InitializeComponent();
            
            ChartTitle = "CHART TITLE";
            lblTitle.Text = ChartTitle;

            // Timer ð? debounce resize events
            _resizeTimer = new Timer { Interval = 100 };
            _resizeTimer.Tick += ResizeTimer_Tick;

            this.Resize += BarChartPanel_Resize;
            this.Load += BarChartPanel_Load;
        }

        private void BarChartPanel_Load(object sender, EventArgs e)
        {
            _isLoaded = true;
            if (_currentItems != null && _currentItems.Count > 0)
            {
                RefreshChartOptimized();
            }
        }

        private void BarChartPanel_Resize(object sender, EventArgs e)
        {
            // Debounce resize - ch? refresh sau khi ng?ng resize 100ms
            if (_isLoaded && _currentItems.Count > 0)
            {
                _resizeTimer.Stop();
                _resizeTimer.Start();
            }
        }

        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            _resizeTimer.Stop();
            
            // Ch? refresh n?u width thay ð?i ðáng k? (>10px)
            if (Math.Abs(flowPanel.Width - _lastWidth) > 10)
            {
                _lastWidth = flowPanel.Width;
                RefreshChartOptimized();
            }
        }

        public void SetTitle(string title)
        {
            ChartTitle = title;
            if (lblTitle != null)
                lblTitle.Text = title;
        }

        public void ClearData()
        {
            _currentItems.Clear();
            if (flowPanel != null)
                flowPanel.Controls.Clear();
        }

        /// <summary>
        /// Load d? li?u - T?I ÝU
        /// </summary>
        public void LoadData(List<BarChartItem> items)
        {
            _currentItems = items != null ? new List<BarChartItem>(items) : new List<BarChartItem>();
            _lastWidth = flowPanel?.Width ?? 0;

            if (!_isLoaded)
                return; // Ch? Load event

            RefreshChartOptimized();
        }

        /// <summary>
        /// Refresh bi?u ð? - T?I ÝU v?i batch update
        /// </summary>
        private void RefreshChartOptimized()
        {
            if (flowPanel == null)
                return;

            flowPanel.SuspendLayout();
            
            try
            {
                // Xóa controls c? hi?u qu?
                while (flowPanel.Controls.Count > 0)
                {
                    var ctrl = flowPanel.Controls[0];
                    flowPanel.Controls.RemoveAt(0);
                    ctrl.Dispose();
                }

                if (_currentItems == null || _currentItems.Count == 0)
                {
                    ShowNoDataMessage();
                    return;
                }

                // T?m max value m?t l?n
                int maxValue = 0;
                for (int i = 0; i < _currentItems.Count; i++)
                {
                    if (_currentItems[i].Value > maxValue)
                        maxValue = _currentItems[i].Value;
                }

                // Tính toán kích thý?c m?t l?n
                int panelWidth = Math.Max(200, flowPanel.Width - 30);
                int labelWidth = Math.Max(80, panelWidth / 4);
                int valueWidth = 85;
                int barStartX = labelWidth + 10;
                int barMaxWidth = Math.Max(30, panelWidth - barStartX - valueWidth - 10);

                // T?o t?t c? bars cùng lúc
                var controls = new Control[_currentItems.Count];
                for (int i = 0; i < _currentItems.Count; i++)
                {
                    controls[i] = CreateBarCardFast(
                        _currentItems[i], 
                        maxValue, 
                        panelWidth, 
                        labelWidth, 
                        barStartX, 
                        barMaxWidth, 
                        valueWidth);
                }

                flowPanel.Controls.AddRange(controls);
            }
            finally
            {
                flowPanel.ResumeLayout(true);
            }
        }

        /// <summary>
        /// T?o bar card - T?I ÝU: ít controls hõn
        /// </summary>
        private Panel CreateBarCardFast(BarChartItem item, int maxValue, 
            int panelWidth, int labelWidth, int barStartX, int barMaxWidth, int valueWidth)
        {
            int barWidth = maxValue > 0 ? (int)((double)item.Value / maxValue * barMaxWidth) : 0;
            if (barWidth < 3 && item.Value > 0) barWidth = 3;

            // Panel chính - s? d?ng custom paint ð? v? bar thay v? t?o thêm panels
            var panel = new BarItemPanel(
                item.Label, 
                item.Value, 
                item.Color, 
                barWidth, 
                barMaxWidth, 
                labelWidth, 
                barStartX, 
                valueWidth,
                ValueUnit)
            {
                Width = panelWidth,
                Height = 32,
                Margin = new Padding(3, 1, 3, 1),
                BackColor = Color.White
            };

            return panel;
        }

        private void ShowNoDataMessage()
        {
            var lblNoData = new Label
            {
                Text = "Chýa có d? li?u",
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(117, 117, 117),
                Margin = new Padding(10)
            };
            flowPanel.Controls.Add(lblNoData);
        }

        /// <summary>
        /// D?n d?p tài nguyên khi c?n
        /// </summary>
        private void CleanupResources()
        {
            _resizeTimer?.Stop();
            _resizeTimer?.Dispose();
            _resizeTimer = null;
        }
    }

    /// <summary>
    /// Custom Panel cho m?i bar item - s? d?ng custom paint thay v? nhi?u controls
    /// </summary>
    internal class BarItemPanel : Panel
    {
        private readonly string _label;
        private readonly int _value;
        private readonly Color _barColor;
        private readonly int _barWidth;
        private readonly int _barMaxWidth;
        private readonly int _labelWidth;
        private readonly int _barStartX;
        private readonly int _valueWidth;
        private readonly string _unit;

        private static readonly Font LabelFont = new Font("Segoe UI", 9F);
        private static readonly Font ValueFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        private static readonly Color BgColor = Color.FromArgb(230, 230, 230);
        private static readonly Color TextColor = Color.FromArgb(33, 33, 33);
        private static readonly StringFormat LeftFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };
        private static readonly StringFormat RightFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

        public BarItemPanel(string label, int value, Color barColor, 
            int barWidth, int barMaxWidth, int labelWidth, int barStartX, int valueWidth, string unit)
        {
            _label = label;
            _value = value;
            _barColor = barColor;
            _barWidth = barWidth;
            _barMaxWidth = barMaxWidth;
            _labelWidth = labelWidth;
            _barStartX = barStartX;
            _valueWidth = valueWidth;
            _unit = unit;

            // Enable double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int y = (Height - 16) / 2;

            // V? label
            var labelRect = new RectangleF(6, 0, _labelWidth, Height);
            using (var brush = new SolidBrush(TextColor))
            {
                g.DrawString(_label, LabelFont, brush, labelRect, LeftFormat);
            }

            // V? bar background
            using (var brush = new SolidBrush(BgColor))
            {
                g.FillRectangle(brush, _barStartX, y, _barMaxWidth, 16);
            }

            // V? bar
            if (_barWidth > 0)
            {
                using (var brush = new SolidBrush(_barColor))
                {
                    g.FillRectangle(brush, _barStartX, y, _barWidth, 16);
                }
            }

            // V? value
            string valueText = _value.ToString("N0");
            if (!string.IsNullOrEmpty(_unit))
                valueText += " " + _unit;

            var valueRect = new RectangleF(Width - _valueWidth - 5, 0, _valueWidth, Height);
            using (var brush = new SolidBrush(_barColor))
            {
                g.DrawString(valueText, ValueFont, brush, valueRect, RightFormat);
            }
        }
    }

    /// <summary>
    /// Class ð?i di?n cho m?t m?c trong bi?u ð?
    /// </summary>
    public class BarChartItem
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public Color Color { get; set; }

        public BarChartItem(string label, int value, Color color)
        {
            Label = label;
            Value = value;
            Color = color;
        }
    }
}
