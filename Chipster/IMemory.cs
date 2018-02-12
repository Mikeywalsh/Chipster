namespace Chipster
{
    /// <summary>
    /// Interface used for classes wishing to implement memory
    /// </summary>
    interface IMemory
    {
        void Write(byte data, int address);
        void Write(byte[] data, int address);
        byte Read(int address);
        void Clear();
    }
}
