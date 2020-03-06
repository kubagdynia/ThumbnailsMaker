using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ThumbnailsMaker.ImageOperations
{
    public class Filters : IFilters
    {
        private readonly Dictionary<IImageFilterProperty, Action<IImageFilterProperty, Image>> _filters;

        public Filters(IImageFilters imageFilters)
        {
            _filters = new Dictionary<IImageFilterProperty, Action<IImageFilterProperty, Image>>
            {
                {
                    imageFilters.PropertySepia, (filter, image) =>
                        image.Mutate(x => x.Sepia(filter.Amount))
                },
                {
                    imageFilters.PropertyBlackWhite, (filter, image) =>
                        image.Mutate(x => x.BlackWhite())
                },
                {
                    imageFilters.PropertyInvert, (filter, image) =>
                        image.Mutate(x => x.Invert())
                },
                {
                    imageFilters.PropertyPolaroid, (filter, image) =>

                        image.Mutate(x => x.Polaroid())
                },
                {
                    imageFilters.PropertyGrayscale, (filter, image) =>

                        image.Mutate(x => x.Grayscale(filter.Amount))
                },
                {
                    imageFilters.PropertyKodachrome, (filter, image) => 
                        image.Mutate(x => x.Kodachrome())
                },
                {
                    imageFilters.PropertyContrast, (filter, image) => 
                        image.Mutate(x => x.Contrast(filter.Amount))
                },
                {
                    imageFilters.PropertyLomograph, (filter, image) => 
                        image.Mutate(x => x.Lomograph())
                },
                {
                    imageFilters.PropertySaturate, (filter, image) => 
                        image.Mutate(x => x.Saturate(filter.Amount))
                },
                {
                    imageFilters.PropertyGaussianBlur, (filter, image) => 
                        image.Mutate(x => x.GaussianBlur(filter.Amount))
                },
                {
                    imageFilters.PropertyPixelate, (filter, image) => 
                        image.Mutate(x => x.Pixelate(filter.Size))
                },
                {
                    imageFilters.PropertyBrightness, (filter, image) => 
                        image.Mutate(x => x.Brightness(filter.Amount))
                }
            };
        }
        
        public void ApplyFilters(Image img)
        {
            var filters =
                _filters.Where(f => f.Key.Enabled)
                .OrderBy(x => x.Key.Order);
            
            foreach (var filter in filters)
            {
                filter.Value.Invoke(filter.Key, img);
            }
        }
    }
}