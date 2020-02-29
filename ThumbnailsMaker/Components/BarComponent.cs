using System;
using System.Linq;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace ThumbnailsMaker.Components
{
    public class BarComponent : IBarComponent
    {
        private readonly AppConfiguration _config;

        public BarComponent(AppConfiguration config)
        {
            _config = config;
        }
        
        public void DrawBar(Image image, BarPosition barPosition)
        {
            if (image is null || _config.Config?.Bars is null)
            {
                return;
            }

            var bar = _config.Config.Bars.SingleOrDefault(b => b.Position == barPosition && b.Enabled);

            if (bar is default(Bar))
            {
                return;
            }
            
            var fonts = new FontCollection().Install(bar.TextFont.Path);
            var font = new Font(fonts, bar.TextFont.Size);

            var text = bar.PrintCurrentDateTime ? DateTime.Now.ToString(bar.DateTimeFormat) : bar.Text;
            
            SizeF size = TextMeasurer.Measure(text, new RendererOptions(font));

            var txtImageWidth =
                barPosition == BarPosition.Top || barPosition == BarPosition.Bottom
                ? _config.Config.ImageWidth
                : _config.Config.ImageHeight;
            
            using var txtImage = new Image<Rgba32>(Configuration.Default, txtImageWidth, bar.Height, bar.BackgroundColor.ToColor());
            
            var txtLocation = bar.TextAlignment switch
            {
                TextAlignment.Left => new Point(0 + bar.TextPaddingLeftRight, GetTextYLocation()),
                TextAlignment.Right => new Point(txtImageWidth - (int) size.Width - bar.TextPaddingLeftRight, GetTextYLocation()),
                TextAlignment.Center => new Point(txtImageWidth / 2 - (int) size.Width / 2, GetTextYLocation()),
                _ => throw new ArgumentException()
            };

            int GetTextYLocation() => (int) ((bar.Height - size.Height) / 2) + bar.TextFont.PositionCorrection;

            TextGraphicsOptions options = new TextGraphicsOptions
            {
                Antialias = bar.Antialias,
                VerticalAlignment = VerticalAlignment.Top
            };
            
            txtImage.Mutate(x => x.DrawText
                (
                    options,
                    text,
                    font,
                    bar.TextFont.Color.ToColor(),
                    txtLocation
                )
            );

            switch (barPosition)
            {
                case BarPosition.Left:
                    txtImage.Mutate(x => x.Rotate(90f));
                    break;
                case BarPosition.Right:
                    txtImage.Mutate(x => x.Rotate(90f));
                    break;
            }

            var txtImageLocation = barPosition switch
            {
                BarPosition.Left => new Point(0, 0),
                BarPosition.Right => new Point(image.Width - txtImage.Width, 0),
                BarPosition.Top => new Point(0, 0),
                BarPosition.Bottom => new Point(0, image.Height - txtImage.Height),
                _ => throw new ArgumentException()
            };
            
            image.Mutate(x => x.DrawImage(txtImage, txtImageLocation, opacity: 0.95f));
        }
    }
}