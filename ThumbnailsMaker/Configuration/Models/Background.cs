using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class Background
    {
        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; }
        
        [JsonPropertyName("texts")]
        public List<Text> Texts { get; set; } = new List<Text>();
        
        [JsonPropertyName("lines")]
        public List<Line> Lines { get; set; } = new List<Line>();

        [JsonPropertyName("filters")]
        public ImageFilters Filters { get; set; } = new ImageFilters();
    }
}