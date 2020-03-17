using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class NullableText
    {
        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }
        
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        
        [JsonPropertyName("antialias")]
        public bool? Antialias { get; set; }
        
        [JsonPropertyName("horizontalAlignment")]
        public TextHorizontalAlignment? TextHorizontalAlignment { get; set; }

        [JsonPropertyName("wrapTextWidth")]
        public float? WrapTextWidth { get; set; }

        [JsonPropertyName("font")]
        public NullableTextFont? TextFont {get; set; }
        
        [JsonPropertyName("shadow")]
        public NullableTextShadow? TextShadow {get; set; }
        
        [JsonPropertyName("position")]
        public NullableTextPosition? Position { get; set; }
        
        [JsonPropertyName("line")]
        public NullableTextLine? TextLine { get; set; }
        
        [JsonPropertyName("childText")]
        public List<NullableText>? ChildTexts { get; set; }
    }
}