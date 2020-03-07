using SixLabors.Primitives;

namespace ThumbnailsMaker.Extensions
{
    public static class RectangleExtensions
    {
        public static Rectangle Add(this Rectangle rectangle, int x, int y)
            => new Rectangle(new Point(rectangle.X + x, rectangle.Y + y), rectangle.Size);

        public static Rectangle Add(this Rectangle rectangle, Point point)
            => Add(rectangle, point.X, point.Y);
    }
}