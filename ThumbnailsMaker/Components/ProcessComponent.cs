using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ThumbnailsMaker.Components
{
    public class ProcessComponent : IProcessComponent
    {
        private readonly AppConfiguration _config;
        private readonly IBackgroundComponent _backgroundComponent;
        private readonly IBarComponent _barComponent;

        public ProcessComponent(AppConfiguration config, IBackgroundComponent backgroundComponent,  IBarComponent barComponent)
        {
            _config = config;
            _backgroundComponent = backgroundComponent;
            _barComponent = barComponent;
        }

        public void DoProcess()
        {
            var outputDirectory = Directory.CreateDirectory(_config.Config.ImageOutput.Directory);
            
            using var thumbnail =
                Image.Load(_config.Config?.Background?.ImagePath ??
                           throw new ArgumentException(
                               $"background file path '{_config.Config?.Background?.ImagePath}' not found"));
            
            _backgroundComponent.DrawBackground(thumbnail);
            
            _barComponent.DrawBar(thumbnail, BarPosition.Left);
            _barComponent.DrawBar(thumbnail, BarPosition.Right);
            _barComponent.DrawBar(thumbnail, BarPosition.Top);
            _barComponent.DrawBar(thumbnail, BarPosition.Bottom);
            
            var output =
                Path.ChangeExtension(Path.Combine(outputDirectory.FullName, Path.GetFileName(_config.Config?.Background?.ImagePath)),
                    _config.Config.ImageOutput.ImageFormat.ToFileExtension());
            
            if (_config.Config.ImageOutput.ImageFormat == ImageFormat.Jpeg)
            {
                Configuration.Default.ImageFormatsManager.SetEncoder(JpegFormat.Instance, new JpegEncoder()
                {
                    Quality = _config.Config.ImageOutput.JpegQuality
                });
            }

            thumbnail.Save(output);
        }
    }
}