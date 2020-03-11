using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class Line
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; } = 100;
        
        [JsonPropertyName("height")]
        public int Height { get; set; } = 10;
        
        [JsonPropertyName("color")]
        public int[] Color { get; set; } = {255, 255, 255, 255};
        
        [JsonPropertyName("position")]
        public TextPosition Position { get; set; } = TextPosition.Zero;
    }
}