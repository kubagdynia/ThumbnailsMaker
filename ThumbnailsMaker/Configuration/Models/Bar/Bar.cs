using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class Bar
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = false;

        [JsonPropertyName("height")]
        public int Height { get; set; } = 80;

        [JsonPropertyName("position")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BarPosition Position { get; set; } = BarPosition.Top;

        [JsonPropertyName("text")]
        public string Text { get; set; } = "Hello!";

        [JsonPropertyName("printCurrentDateTime")]
        public bool PrintCurrentDateTime { get; set; } = false;

        [JsonPropertyName("dateTimeFormat")]
        public string DateTimeFormat { get; set; } = string.Empty;

        [JsonPropertyName("textAlignment")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TextAlignment TextAlignment { get; set; } = TextAlignment.Center;
        
        [JsonPropertyName("textPaddingLeftRight")]
        public int TextPaddingLeftRight { get; set; } = 0;

        [JsonPropertyName("backgroundColor")]
        public int[] BackgroundColor { get; set; } = {176, 36, 255, 155};
        
        [JsonPropertyName("font")]
        public TextFont TextFont {get; set; } = TextFont.Default;

        [JsonPropertyName("antialias")]
        public bool Antialias { get; set; } = true;
    }
}