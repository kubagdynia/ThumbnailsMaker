using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class TextShadow
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("shiftRight")]
        public int ShiftRight { get; set; } = 0;
        
        [JsonPropertyName("shiftDown")]
        public int ShiftDown { get; set; } = 0;
        
        [JsonPropertyName("sizeShift")]
        public int SizeShift { get; set; } = 0;
        
        [JsonPropertyName("color")]
        public int[] Color { get; set; } = {255, 255, 255, 255};
        
        public static TextShadow Default => new TextShadow();
    }
}