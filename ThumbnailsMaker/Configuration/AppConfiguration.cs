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

            CompleteChildTextsWithParentsDetails(Config.Background.Texts);
        }

        private void CompleteChildTextsWithParentsDetails(List<Text> texts)
        {
            if (texts is null || !texts.Any()) return;
            
            foreach (var text in texts)
            {
                CompleteChildTextsData(text.NullableChildTexts, text);
            }
        }

        private void CompleteChildTextsData(List<NullableText>? childTexts, Text parentText)
        {
            if (childTexts is null || !childTexts.Any() || parentText is null) return;

            if (parentText.ChildTexts == null)
            {
                parentText.ChildTexts = new List<Text>();
            }
            
            foreach (var childText in childTexts)
            {
                var newChildText = parentText.DeepClone();
                childText.CloneNonNullValues(newChildText);
                parentText.ChildTexts.Add(newChildText);
            }
        }
    }
}