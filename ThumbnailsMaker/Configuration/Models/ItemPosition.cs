using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemPosition
    {
        Left,
        Right,
        Top,
        Bottom
    }
}