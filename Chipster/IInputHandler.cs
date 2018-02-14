namespace Chipster
{   /// <summary>
    /// Interface used for classes wishing to implement input
    /// </summary>
    interface IInputHandler
    {
        void RefreshInput(bool[] keys);
    }
}
