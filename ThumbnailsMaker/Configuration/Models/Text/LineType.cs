using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LineType
    {
        Single,
        Double
    }
}