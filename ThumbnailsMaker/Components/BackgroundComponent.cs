using Autofac.Features.Indexed;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using ThumbnailsMaker.ImageOperations;

namespace ThumbnailsMaker.Components
{
    public class BackgroundComponent : IBackgroundComponent
    {
        private readonly Config _config;
        private readonly IFilters _backgroundFilters;

        public BackgroundComponent(AppConfiguration config, IIndex<object, IFilters> filters)
        {
            _config = config.Config;
            _backgroundFilters = filters[typeof(Background)];
        }
        
        public void DrawBackground(Image image)
        {
            _backgroundFilters.ApplyFilters(image);
            CalculateImageSize(image);
            
            foreach (Text text in _config.Background.Texts)
            {
                FontFamily fontFamily = new FontCollection().Install(text.TextFont.Path);
                
                TextGraphicsOptions textGraphicsOptions = CreateTextGraphicsOptions(text);
                
                AddShadow(image, text, textGraphicsOptions, fontFamily);
                
                AddText(image, text, textGraphicsOptions, fontFamily);
            }

            foreach (Line line in _config.Background.Lines)
            {
                AddLine(image, line);
            }
        }

        private void AddLine(Image image, Line line)
        {
            if (!line.Enabled) return;
            
            var rectange = new Rectangle(line.Position.X, line.Position.Y, line.Width, line.Height);
            image.Mutate(i => i.Fill(line.Color.ToColor(), rectange));
        }

        private void CalculateImageSize(Image image)
        {
            if (_config.FitToBackgroundImageSize)
            {
                _config.ImageWidth = image.Width;
                _config.ImageHeight = image.Height;
            }
            else if (image.Width != _config.ImageWidth || image.Height != _config.ImageHeight)
            {
                image.Mutate(x => x.Resize(new Size(_config.ImageWidth, _config.ImageHeight)));
            }
        }

        private void AddText(Image image, Text text, TextGraphicsOptions textGraphicsOptions, FontFamily fontFamily)
        {
            if (!text.Enabled) return;
            
            var font = new Font(fontFamily, text.TextFont.Size);
            
            image.Mutate(x => x.DrawText
                (
                    textGraphicsOptions,
                    text.Message,
                    font,
                    text.TextFont.Color.ToColor(),
                    new Point(text.Position.X, text.Position.Y)
                )
            );
        }

        private void AddShadow(Image image, Text text, TextGraphicsOptions textGraphicsOptions, FontFamily fontFamily)
        {
            if (!text.Enabled || !text.TextShadow.Enabled) return;

            var font = new Font(fontFamily,
                text.TextFont.Size + text.TextShadow.SizeShift);

            image.Mutate(x =>
            {
                x.DrawText(
                    textGraphicsOptions,
                    text.Message,
                    font,
                    text.TextShadow.Color.ToColor(),
                    GetLocation());
            });

            Point GetLocation()
                => new Point(text.Position.X + text.TextShadow.ShiftRight,
                    text.Position.Y + text.TextShadow.ShiftDown);
        }
        
        private TextGraphicsOptions CreateTextGraphicsOptions(Text text)
            => new TextGraphicsOptions
            {
                Antialias = text.Antialias,
                WrapTextWidth = text.WrapTextWidth,
                HorizontalAlignment = text.TextHorizontalAlignment.ToHorizontalAlignment()
            };
    }
}