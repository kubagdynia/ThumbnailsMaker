using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TextHorizontalAlignment
    {
        Left,
        Right,
        Center
    }
}