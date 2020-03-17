using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class NullableTextLine
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }
        
        [JsonPropertyName("size")]
        public NullableTextLineSize? Size { get; set; }

        [JsonPropertyName("position")]
        public ItemPosition? Position { get; set; }
        
        [JsonPropertyName("color")]
        public int[]? Color { get; set; }
        
        [JsonPropertyName("shadow")]
        public NullableTextShadow? Shadow {get; set; }

        [JsonPropertyName("type")]
        public LineType? Type { get; set; }
        
        [JsonPropertyName("horizontalAlignment")]
        public TextHorizontalAlignment? HorizontalAlignment { get; set; }
    }
}