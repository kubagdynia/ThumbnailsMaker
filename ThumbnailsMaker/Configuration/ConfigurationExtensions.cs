using SixLabors.Fonts;
using SixLabors.ImageSharp;

namespace ThumbnailsMaker
{
    public static class ConfigExtensions
    {
        public static Color ToColor(this int[] values)
            => values.Length switch
            {
                3 => Color.FromRgb((byte) values[0], (byte) values[1], (byte) values[2]),
                4 => Color.FromRgba((byte) values[0], (byte) values[1], (byte) values[2], (byte) values[3]),
                _ => Color.White
            };

        public static string ToLowerFirst(this string str)
        {
            if (string.IsNullOrWhiteSpace(str) || char.IsLower(str, 0))
            {
                return str;
            }

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public static string ToFileExtension(this ImageFormat imageFormat)
            => imageFormat.ToString().ToLower();

        public static HorizontalAlignment ToHorizontalAlignment(this TextAlignment textAlignment)
            => textAlignment switch
            {
                TextAlignment.Center => HorizontalAlignment.Center,
                TextAlignment.Left => HorizontalAlignment.Left,
                TextAlignment.Right => HorizontalAlignment.Right,
                _ => HorizontalAlignment.Center
            };
    }
}