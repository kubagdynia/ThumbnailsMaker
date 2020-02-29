using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public abstract class ImageFilterProperty : IImageFilterProperty
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = false;

        [JsonPropertyName("order")]
        public int Order { get; set; } = 1;
        
        [JsonPropertyName("amount")]
        public float Amount { get; set; } = 1f;

        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}