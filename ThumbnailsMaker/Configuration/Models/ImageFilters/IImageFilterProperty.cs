namespace ThumbnailsMaker
{
    public interface IImageFilterProperty
    {
        bool Enabled { get; set; }
        
        int Order { get; set; }
        
        float Amount { get; set; }
        
        int Size { get; set; }
    }
}