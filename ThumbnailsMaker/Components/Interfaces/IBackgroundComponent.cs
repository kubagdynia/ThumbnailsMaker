using SixLabors.ImageSharp;

namespace ThumbnailsMaker.Components
{
    public interface IBackgroundComponent
    {
        void DrawBackground(Image image);
    }
}