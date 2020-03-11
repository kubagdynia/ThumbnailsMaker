using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class TextLine
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = false;
        
        [JsonPropertyName("size")]
        public TextLineSize Size { get; set; } = new TextLineSize();

        [JsonPropertyName("position")]
        public ItemPosition Position { get; set; } = ItemPosition.Bottom;
        
        [JsonPropertyName("color")]
        public int[] Color { get; set; } = {255, 255, 255, 255};
        
        [JsonPropertyName("shadow")]
        public TextShadow Shadow {get; set; } = TextShadow.Default;

        [JsonPropertyName("type")]
        public LineType Type { get; set; } = LineType.Single;
        
        [JsonPropertyName("horizontalAlignment")]
        public TextHorizontalAlignment HorizontalAlignment { get; set; } = TextHorizontalAlignment.Center;
    }
}