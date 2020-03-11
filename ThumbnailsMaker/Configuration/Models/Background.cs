using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class Background
    {
        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; } = String.Empty;
        
        [JsonPropertyName("texts")]
        public List<Text> Texts { get; set; } = new List<Text>();
        
        [JsonPropertyName("lines")]
        public List<Line> Lines { get; set; } = new List<Line>();

        [JsonPropertyName("filters")]
        public ImageFilters Filters { get; set; } = new ImageFilters();
    }
}