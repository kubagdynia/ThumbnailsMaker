using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class Text
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; } = String.Empty;
        
        [JsonPropertyName("antialias")]
        public bool Antialias { get; set; } = true;
        
        [JsonPropertyName("horizontalAlignment")]
        public TextHorizontalAlignment TextHorizontalAlignment { get; set; } = TextHorizontalAlignment.Center;

        [JsonPropertyName("wrapTextWidth")]
        public float WrapTextWidth { get; set; } = 900f;

        [JsonPropertyName("font")]
        public TextFont TextFont {get; set; } = TextFont.Default;
        
        [JsonPropertyName("shadow")]
        public TextShadow TextShadow {get; set; } = TextShadow.Default;
        
        [JsonPropertyName("position")]
        public TextPosition Position { get; set; } = TextPosition.Zero;
        
        [JsonPropertyName("line")]
        public TextLine TextLine { get; set; } = new TextLine(); 
    }
}