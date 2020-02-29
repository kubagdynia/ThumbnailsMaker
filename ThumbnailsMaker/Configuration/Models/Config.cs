using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class Config
    {
        [JsonPropertyName("output")]
        public ImageOutput ImageOutput { get; set; } = new ImageOutput();
        
        [JsonPropertyName("fitToBackgroundImageSize")]
        public bool FitToBackgroundImageSize { get; set; } = false;
        
        [JsonPropertyName("imageWidth")]
        public int ImageWidth { get; set; }
        
        [JsonPropertyName("imageHeight")]
        public int ImageHeight { get; set; }

        [JsonPropertyName("bars")]
        public List<Bar> Bars { get; set; }
        
        [JsonPropertyName("background")]
        public Background Background { get; set; }
    }
}