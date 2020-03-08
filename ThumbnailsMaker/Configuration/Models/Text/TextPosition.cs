using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class TextPosition
    {
        [JsonPropertyName("x")]
        public int X { get; set; } = 0;

        [JsonPropertyName("y")]
        public int Y { get; set; } = 0;
        
        [JsonPropertyName("horizontalAlignment")]
        public TextHorizontalAlignment TextHorizontalAlignment { get; set; } = TextHorizontalAlignment.Center;

        [JsonPropertyName("useHorizontalAlignment")]
        public bool UseHorizontalAlignment { get; set; } = false;
        
        public static TextPosition Zero => new TextPosition();
    }
}