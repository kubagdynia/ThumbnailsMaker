using SixLabors.ImageSharp;

namespace ThumbnailsMaker.ImageOperations
{
    public interface IFilters
    {
        void ApplyFilters(Image img);
    }
}