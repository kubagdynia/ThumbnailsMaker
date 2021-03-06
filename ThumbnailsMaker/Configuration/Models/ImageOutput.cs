using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    public class ImageOutput
    {
        [JsonPropertyName("directory")]
        public string Directory { get; set; } = "./output";

        [JsonPropertyName("imageFormat")]
        public ImageFormat ImageFormat { get; set; } = ImageFormat.Png;

        [JsonPropertyName("jpegQuality")]
        public int JpegQuality { get; set; } = 75;
    }
}