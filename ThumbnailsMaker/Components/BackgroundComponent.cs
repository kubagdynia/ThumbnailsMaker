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
            FontFamily fontFamily = new FontCollection().Install(_config.Background.Text.TextFont.Path);

            _backgroundFilters.ApplyFilters(image);
            
            CalculateImageSize(image);

            TextGraphicsOptions textGraphicsOptions = CreateTextGraphicsOptions();

            AddShadow(image, textGraphicsOptions, fontFamily);
            
            AddText(image, textGraphicsOptions, fontFamily);
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

        private void AddText(Image image, TextGraphicsOptions textGraphicsOptions, FontFamily fontFamily)
        {
            if (!_config.Background.Text.Enabled) return;
            
            var font = new Font(fontFamily, _config.Background.Text.TextFont.Size);
            
            image.Mutate(x => x.DrawText
                (
                    textGraphicsOptions,
                    _config.Background.Text.Message,
                    font,
                    _config.Background.Text.TextFont.Color.ToColor(),
                    new Point(_config.Background.Text.Position.X, _config.Background.Text.Position.Y)
                )
            );
        }

        private void AddShadow(Image image, TextGraphicsOptions textGraphicsOptions, FontFamily fontFamily)
        {
            if (!_config.Background.Text.Enabled || !_config.Background.Text.TextShadow.Enabled) return;

            var font = new Font(fontFamily,
                _config.Background.Text.TextFont.Size + _config.Background.Text.TextShadow.SizeShift);

            image.Mutate(x =>
            {
                x.DrawText(
                    textGraphicsOptions,
                    _config.Background.Text.Message,
                    font,
                    _config.Background.Text.TextShadow.Color.ToColor(),
                    GetLocation());
            });

            Point GetLocation()
                => new Point(_config.Background.Text.Position.X + _config.Background.Text.TextShadow.ShiftRight,
                    _config.Background.Text.Position.Y + _config.Background.Text.TextShadow.ShiftDown);
        }
        
        private TextGraphicsOptions CreateTextGraphicsOptions()
            => new TextGraphicsOptions
            {
                Antialias = _config.Background.Text.Antialias,
                WrapTextWidth = _config.Background.Text.WrapTextWidth,
                HorizontalAlignment = _config.Background.Text.TextAlignment.ToHorizontalAlignment()
            };
    }
}