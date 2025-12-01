using System;
using System.Drawing;

namespace QuanLyThuVien.Helpers
{
    /// <summary>
    /// Qu?n lý fonts cho ?ng d?ng v?i fallback an toàn
    /// </summary>
    public static class FontManager
    {
        /// <summary>
        /// Kh?i t?o fonts (gi? l?i ?? backward compatible)
        /// </summary>
        public static void Initialize()
        {
            // Không c?n làm gì, gi? l?i ?? code c? không b? l?i
        }

        /// <summary>
        /// L?y font v?i fallback an toàn
        /// ?u tiên: Segoe UI ? Microsoft Sans Serif ? GenericSansSerif
        /// </summary>
        public static Font GetRobotoFont(float size, FontStyle style = FontStyle.Regular)
        {
            // Không dùng Roboto n?a, tr? v? Segoe UI
            return GetSafeFont("Segoe UI", size, style);
        }

        /// <summary>
        /// L?y font an toàn v?i fallback hierarchy
        /// </summary>
        /// <param name="preferredFont">Font ?u tiên (ví d?: "Segoe UI")</param>
        /// <param name="size">Kích th??c font</param>
        /// <param name="style">Ki?u font (Regular, Bold, Italic...)</param>
        /// <returns>Font object v?i fallback an toàn</returns>
        public static Font GetSafeFont(string preferredFont, float size, FontStyle style)
        {
            try
            {
                // Th? t?o font theo yêu c?u
                using (Font testFont = new Font(preferredFont, size, style))
                {
                    return new Font(preferredFont, size, style);
                }
            }
            catch
            {
                // N?u l?i, th? Segoe UI
                try
                {
                    using (Font testFont = new Font("Segoe UI", size, style))
                    {
                        return new Font("Segoe UI", size, style);
                    }
                }
                catch
                {
                    // N?u v?n l?i, th? Microsoft Sans Serif
                    try
                    {
                        return new Font("Microsoft Sans Serif", size, style);
                    }
                    catch
                    {
                        // Cu?i cùng dùng font m?c ??nh c?a h? th?ng
                        return new Font(FontFamily.GenericSansSerif, size, style);
                    }
                }
            }
        }

        /// <summary>
        /// Gi?i phóng resources (gi? l?i ?? backward compatible)
        /// </summary>
        public static void Dispose()
        {
            // Không c?n làm gì
        }
    }
}
