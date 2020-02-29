using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class Background
    {
        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; }
        
        [JsonPropertyName("text")]
        public Text Text { get; set; } = new Text();

        [JsonPropertyName("filters")]
        public ImageFilters Filters { get; set; } = new ImageFilters();
    }
}