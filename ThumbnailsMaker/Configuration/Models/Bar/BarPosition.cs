using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BarPosition
    {
        Left,
        Right,
        Top,
        Bottom
    }
}