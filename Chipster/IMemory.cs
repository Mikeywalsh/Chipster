using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
