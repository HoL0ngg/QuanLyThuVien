using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.Components
{
    public class CustomButton : Button
    {
        private Color baseColor;
        private Color hoverColor;
        private Color downColor;

        public CustomButton(string text, string colorName)
        {
            // Base visual
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.ForeColor = Color.White;
            this.Size = new Size(120, 35);
            this.Text = text;
            this.UseVisualStyleBackColor = false;
            this.Cursor = Cursors.Hand;
            this.FlatAppearance.BorderSize = 0;

            // Resolve base color from input via switch-case
            switch ((colorName ?? string.Empty).ToLowerInvariant())
            {
                case "blue":
                    baseColor = Color.FromArgb(33, 150, 243);
                    hoverColor = Color.FromArgb(66, 165, 245);
                    downColor = Color.FromArgb(25, 118, 210);
                    break;
                case "green":
                    baseColor = Color.FromArgb(76, 175, 80);
                    hoverColor = Color.FromArgb(102, 187, 106);
                    downColor = Color.FromArgb(56, 142, 60);
                    break;
                case "red":
                    baseColor = Color.FromArgb(244, 67, 54);
                    hoverColor = Color.FromArgb(229, 57, 53);
                    downColor = Color.FromArgb(211, 47, 47);
                    break;
                default:
                    baseColor = Color.White;
                    hoverColor = Color.Gainsboro;
                    downColor = Color.Silver;
                    this.ForeColor = Color.Black; // better contrast on white
                    break;
            }

            this.BackColor = baseColor;
            this.FlatAppearance.MouseOverBackColor = hoverColor;
            this.FlatAppearance.MouseDownBackColor = downColor;
        }
    }
}
