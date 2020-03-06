using System.Text.Json.Serialization;

namespace ThumbnailsMaker
{
    public class ImageFilters : IImageFilters
    {
        [JsonPropertyName("sepia")]
        public ImageFilterPropertySepia PropertySepia { get; set; } = new ImageFilterPropertySepia();
        
        [JsonPropertyName("blackWhite")]
        public ImageFilterPropertyBlackWhite PropertyBlackWhite { get; set; } = new ImageFilterPropertyBlackWhite();
        
        [JsonPropertyName("invert")]
        public ImageFilterPropertyInvert PropertyInvert { get; set; } = new ImageFilterPropertyInvert();
        
        [JsonPropertyName("polaroid")]
        public ImageFilterPropertyPolaroid PropertyPolaroid { get; set; } = new ImageFilterPropertyPolaroid();
        
        [JsonPropertyName("grayscale")]
        public ImageFilterPropertyGrayscale PropertyGrayscale { get; set; } = new ImageFilterPropertyGrayscale();
        
        [JsonPropertyName("kodachrome")]
        public ImageFilterPropertyKodachrome PropertyKodachrome { get; set; } = new ImageFilterPropertyKodachrome();
        
        [JsonPropertyName("contrast")]
        public ImageFilterPropertyContrast PropertyContrast { get; set; } = new ImageFilterPropertyContrast();
        
        [JsonPropertyName("lomograph")]
        public ImageFilterPropertyLomograph PropertyLomograph { get; set; } = new ImageFilterPropertyLomograph();
        
        [JsonPropertyName("saturate")]
        public ImageFilterPropertySaturate PropertySaturate { get; set; } = new ImageFilterPropertySaturate();
        
        [JsonPropertyName("gaussianBlur")]
        public ImageFilterPropertyGaussianBlur PropertyGaussianBlur { get; set; } = new ImageFilterPropertyGaussianBlur();
        
        [JsonPropertyName("pixelate")]
        public ImageFilterPropertyPixelate PropertyPixelate { get; set; } = new ImageFilterPropertyPixelate();

        [JsonPropertyName("brightness")]
        public ImageFilterPropertyBrightness PropertyBrightness { get; set; } = new ImageFilterPropertyBrightness();
    }
}