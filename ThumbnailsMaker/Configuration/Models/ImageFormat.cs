using System;
using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    [Serializable]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ImageFormat
    {
        Png,
        Jpeg,
        Gif
    }
}