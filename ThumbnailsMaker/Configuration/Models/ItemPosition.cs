using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemPosition
    {
        Left,
        Right,
        Top,
        Bottom
    }
}