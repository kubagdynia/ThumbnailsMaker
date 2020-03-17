using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class NullableTextFont
    {
        [JsonPropertyName("path")]
        public string? Path { get; set; }
        
        [JsonPropertyName("size")]
        public float? Size { get; set; }

        [JsonPropertyName("positionCorrection")]
        public int? PositionCorrection { get; set; }
        
        [JsonPropertyName("color")]
        public int[]? Color { get; set; }
    }
}