using Autofac.Features.Indexed;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using ThumbnailsMaker.Extensions;
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
                
                AddTextLineShadow(image, text, textGraphicsOptions, fontFamily);
                AddTextLine(image, text, textGraphicsOptions, fontFamily);
            }

            foreach (Line line in _config.Background.Lines)
            {
                AddLine(image, line);
            }
        }

        private void AddLine(Image image, Line line)
        {
            if (!line.Enabled) return;
            
            var rectangle = new Rectangle(line.Position.X, line.Position.Y, line.Width, line.Height);
            image.Mutate(i => i.Fill(line.Color.ToColor(), rectangle));
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
        
        private void AddTextLineShadow(Image image, Text text, TextGraphicsOptions textGraphicsOptions, FontFamily fontFamily)
        {
            if (!text.TextLine.Enabled || !text.TextLine.Shadow.Enabled) return;
            
            var font = new Font(fontFamily, text.TextFont.Size);
            
            var textSize = GetTextSize(text, textGraphicsOptions, font);

            var rectanglePosition = text.TextLine.Position switch
            {
                ItemPosition.Top => new Point(
                    GetTextCenter() - text.TextLine.Size.Width / 2 + text.TextLine.Shadow.ShiftRight,
                    text.Position.Y - 20 + text.TextLine.Shadow.ShiftDown
                ),
                ItemPosition.Bottom => new Point(
                    GetTextCenter() - text.TextLine.Size.Width / 2 + text.TextLine.Shadow.ShiftRight,
                    text.Position.Y + (int) textSize.Height + text.TextLine.Shadow.ShiftDown
                ),
                _ => new Point(
                    GetTextCenter() - text.TextLine.Size.Width / 2 + text.TextLine.Shadow.ShiftRight,
                    text.Position.Y + (int) textSize.Height + text.TextLine.Shadow.ShiftDown
                )
            };

            var rectangleSize = new Size(
                text.TextLine.Size.Width + text.TextLine.Shadow.SizeShift,
                text.TextLine.Size.Height + text.TextLine.Shadow.SizeShift);

            var rectangle = new Rectangle(rectanglePosition, rectangleSize);
            
            image.Mutate(i => i.Fill(text.TextLine.Shadow.Color.ToColor(), rectangle));
            
            if (text.TextLine.Type == LineType.Double)
            {
                image.Mutate(i =>
                    i.Fill(text.TextLine.Shadow.Color.ToColor(), rectangle.Add(0, text.TextLine.Size.Height + 10)));
            }
            
            int GetTextCenter() => text.Position.X + (int) textGraphicsOptions.WrapTextWidth / 2;
        }
        
        private void AddTextLine(Image image, Text text, TextGraphicsOptions textGraphicsOptions, FontFamily fontFamily)
        {
            if (!text.TextLine.Enabled) return;
            
            var font = new Font(fontFamily, text.TextFont.Size);

            var textSize = GetTextSize(text, textGraphicsOptions, font);

            var rectanglePosition = text.TextLine.Position switch
            {
                ItemPosition.Top => new Point(
                    GetTextCenter() - text.TextLine.Size.Width / 2,
                    text.Position.Y - 20
                ),
                ItemPosition.Bottom => new Point(
                    GetTextCenter() - text.TextLine.Size.Width / 2,
                    text.Position.Y + (int) textSize.Height
                ),
                _ => new Point(
                    GetTextCenter() - text.TextLine.Size.Width / 2,
                    text.Position.Y + (int) textSize.Height
                )
            };

            var rectangleSize = new Size(text.TextLine.Size.Width, text.TextLine.Size.Height);
            
            var rectangle = new Rectangle(rectanglePosition, rectangleSize);

            image.Mutate(i => i.Fill(text.TextLine.Color.ToColor(), rectangle));
            
            if (text.TextLine.Type == LineType.Double)
            {
                image.Mutate(i =>
                    i.Fill(text.TextLine.Color.ToColor(), rectangle.Add(0, text.TextLine.Size.Height + 10)));
            }

            int GetTextCenter() => text.Position.X + (int) textGraphicsOptions.WrapTextWidth / 2;
        }

        private SizeF GetTextSize(Text text, TextGraphicsOptions textGraphicsOptions, Font font)
            => TextMeasurer.Measure(text.Message,
                new RendererOptions(font)
                {
                    WrappingWidth = textGraphicsOptions.WrapTextWidth,
                    HorizontalAlignment = textGraphicsOptions.HorizontalAlignment
                });

        private TextGraphicsOptions CreateTextGraphicsOptions(Text text)
            => new TextGraphicsOptions
            {
                Antialias = text.Antialias,
                WrapTextWidth = text.WrapTextWidth,
                HorizontalAlignment = text.TextHorizontalAlignment.ToHorizontalAlignment(),
                VerticalAlignment = VerticalAlignment.Top
            };
    }
}