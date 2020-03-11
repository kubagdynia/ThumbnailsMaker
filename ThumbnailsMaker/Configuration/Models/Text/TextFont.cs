using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class TextFont
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = "./BebasNeue-Regular.ttf";
        
        [JsonPropertyName("size")]
        public float Size { get; set; } = 60f;

        [JsonPropertyName("positionCorrection")]
        public int PositionCorrection { get; set; } = 0;
        
        [JsonPropertyName("color")]
        public int[] Color { get; set; } = {255, 255, 255, 255};

        public static TextFont Default => new TextFont();
    }
}