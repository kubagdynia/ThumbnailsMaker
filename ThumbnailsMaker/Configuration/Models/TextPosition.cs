using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class TextPosition
    {
        [JsonPropertyName("x")]
        public int X { get; set; }
        
        [JsonPropertyName("y")]
        public int Y { get; set; }
        
        public static TextPosition Zero => new TextPosition();
    }
}