using SixLabors.ImageSharp;

namespace ThumbnailsMaker.Components
{
    public interface IBarComponent
    {
        void DrawBar(Image image, BarPosition barPosition);
    }
}