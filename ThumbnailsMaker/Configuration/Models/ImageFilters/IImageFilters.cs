namespace ThumbnailsMaker
{
    public interface IImageFilters
    {
        ImageFilterPropertySepia PropertySepia { get; set; }
        ImageFilterPropertyBlackWhite PropertyBlackWhite { get; set; }
        ImageFilterPropertyInvert PropertyInvert { get; set; }
        ImageFilterPropertyPolaroid PropertyPolaroid { get; set; }
        ImageFilterPropertyGrayscale PropertyGrayscale { get; set; }
        ImageFilterPropertyKodachrome PropertyKodachrome { get; set; }
        ImageFilterPropertyContrast PropertyContrast { get; set; }
        ImageFilterPropertyLomograph PropertyLomograph { get; set; }
        ImageFilterPropertySaturate PropertySaturate { get; set; }
        ImageFilterPropertyGaussianBlur PropertyGaussianBlur { get; set; }
        ImageFilterPropertyPixelate PropertyPixelate { get; set; }
    }
}