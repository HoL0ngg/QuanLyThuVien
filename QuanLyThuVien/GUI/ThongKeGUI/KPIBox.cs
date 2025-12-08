using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.ThongKeGUI
{
    public partial class KPIBox : UserControl
    {
        // Properties
        public string Title { get; set; }
        public string Value { get; set; }
        public Color ValueColor { get; set; }
        public Font ValueFont { get; set; }
        public Font TitleFont { get; set; }

        // Cache để tránh cập nhật không cần thiết
        private string _lastTitle;
        private string _lastValue;
        private Color _lastColor;

        public KPIBox()
        {
            // Tắt double buffering để tăng tốc
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint, true);
            
            InitializeComponent();
            
            Title = "KPI TITLE";
            Value = "0";
            ValueColor = ColorBlue;
            
            // Khởi tạo cache với giá trị null để lần gọi SetKPI đầu tiên luôn cập nhật UI
            _lastTitle = null;
            _lastValue = null;
            _lastColor = Color.Empty;
            
            // Cập nhật UI lần đầu
            UpdateUIFast();
        }

        /// <summary>
        /// Phương thức thiết lập giá trị KPI đầy đủ - TỐI ƯU
        /// </summary>
        public void SetKPI(string title, object value, Color color, string format = null)
        {
            // Tính toán value trước
            string newValue = FormatValue(value, format);
            
            // Kiểm tra có thay đổi không để tránh cập nhật UI không cần thiết
            bool needUpdate = false;
            
            if (_lastTitle != title)
            {
                Title = title;
                _lastTitle = title;
                needUpdate = true;
            }
            
            if (_lastValue != newValue)
            {
                Value = newValue;
                _lastValue = newValue;
                needUpdate = true;
            }
            
            if (_lastColor != color)
            {
                ValueColor = color;
                _lastColor = color;
                needUpdate = true;
            }

            // Chỉ cập nhật UI khi có thay đổi
            if (needUpdate)
            {
                UpdateUIFast();
            }
        }

        /// <summary>
        /// Format giá trị theo kiểu dữ liệu
        /// </summary>
        private string FormatValue(object value, string format)
        {
            if (value == null) return "0";
            
            if (value is string s) return s;
            if (value is int i) return format != null ? i.ToString(format) : i.ToString();
            if (value is decimal d) return format != null ? d.ToString(format) : d.ToString();
            if (value is double db) return format != null ? db.ToString(format) : db.ToString();
            if (value is long l) return format != null ? l.ToString(format) : l.ToString();
            
            return value.ToString();
        }

        /// <summary>
        /// Cập nhật UI nhanh - không dùng SuspendLayout vì chỉ có 2 label
        /// </summary>
        private void UpdateUIFast()
        {
            if (labelTitle != null)
                labelTitle.Text = Title ?? "KPI TITLE";

            if (labelValue != null)
            {
                labelValue.Text = Value ?? "0";
                labelValue.ForeColor = ValueColor;
                
                if (ValueFont != null)
                    labelValue.Font = ValueFont;
            }

            if (TitleFont != null && labelTitle != null)
                labelTitle.Font = TitleFont;
        }

        // Color definitions - dùng readonly để tránh tạo lại
        public static readonly Color ColorBlue = Color.FromArgb(33, 150, 243);
        public static readonly Color ColorGreen = Color.FromArgb(76, 175, 80);
        public static readonly Color ColorRed = Color.FromArgb(244, 67, 54);
        public static readonly Color ColorOrange = Color.FromArgb(255, 152, 0);
        public static readonly Color ColorPurple = Color.FromArgb(156, 39, 176);
        public static readonly Color ColorGray = Color.FromArgb(117, 117, 117);
    }
}
