using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BarPosition
    {
        Left,
        Right,
        Top,
        Bottom
    }
}