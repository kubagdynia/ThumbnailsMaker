using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class TextLineSize
    {
        [JsonPropertyName("height")]
        public int Height { get; set; } = 10;
        
        [JsonPropertyName("width")]
        public int Width { get; set; } = 100;
    }
}