using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class NullableTextPosition
    {
        [JsonPropertyName("x")]
        public int? X { get; set; }

        [JsonPropertyName("y")]
        public int? Y { get; set; }
        
        [JsonPropertyName("horizontalAlignment")]
        public TextHorizontalAlignment? TextHorizontalAlignment { get; set; }

        [JsonPropertyName("useHorizontalAlignment")]
        public bool? UseHorizontalAlignment { get; set; }
    }
}