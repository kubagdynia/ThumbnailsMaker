using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TextHorizontalAlignment
    {
        Left,
        Right,
        Center
    }
}