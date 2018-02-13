namespace Chipster
{
    /// <summary>
    /// Interface used for classes wishing to implement a display
    /// </summary>
    interface IDisplay
    {
        int PixelWidth { get; }
        int PixelHeight { get; }
        void Init();
        void Draw();
    }
}
