using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ThumbnailsMaker
{
    public class AppConfiguration
    {
        public Config Config { get; }

        public AppConfiguration(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            Config = JsonSerializer.Deserialize<Config>(jsonString, new JsonSerializerOptions
            {
                IgnoreNullValues = false
            });

            CompleteChildTextsData(Config.Background.Texts);
        }

        private void CompleteChildTextsData(List<Text> texts)
        {
            if (texts is null || !texts.Any()) return;
            
            foreach (var text in texts)
            {
                CompleteChildTextsData(text.ChildTexts, text);
            }
        }

        private void CompleteChildTextsData(List<Text> texts, Text parentText)
        {
            if (texts is null || !texts.Any()) return;
            
            foreach (var text in texts)
            {
                if (parentText is {})
                {
                    Text newText = parentText.DeepClone();
                    CompleteChildTextsData(text.ChildTexts, text);
                }
            }
        }
    }
}