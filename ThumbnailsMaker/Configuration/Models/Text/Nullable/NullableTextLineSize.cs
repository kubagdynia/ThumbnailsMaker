using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class NullableTextLineSize
    {
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        
        [JsonPropertyName("width")]
        public int? Width { get; set; }
    }
}