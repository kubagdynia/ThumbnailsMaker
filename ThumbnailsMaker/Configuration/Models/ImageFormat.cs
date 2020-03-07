using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ImageFormat
    {
        Png,
        Jpeg,
        Gif
    }
}