using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class NullableTextShadow
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }

        [JsonPropertyName("shiftRight")]
        public int? ShiftRight { get; set; }
        
        [JsonPropertyName("shiftDown")]
        public int? ShiftDown { get; set; }
        
        [JsonPropertyName("sizeShift")]
        public int? SizeShift { get; set; }
        
        [JsonPropertyName("color")]
        public int[]? Color { get; set; }
    }
}