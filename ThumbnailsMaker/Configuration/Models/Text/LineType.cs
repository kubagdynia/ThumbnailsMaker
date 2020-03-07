using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LineType
    {
        Single,
        Double
    }
}