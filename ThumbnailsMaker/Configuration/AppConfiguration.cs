using System.IO;
using System.Text.Json;

namespace ThumbnailsMaker
{
    public class AppConfiguration
    {
        public Config Config { get; }

        public AppConfiguration(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            Config = JsonSerializer.Deserialize<Config>(jsonString);
        }
    }
}