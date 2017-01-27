using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipster
{
    /// <summary>
    /// A class used to write to and read from memory for the chip8 emulated system
    /// </summary>
    sealed class Memory : IMemory
    {
        public int Size { get; private set; }

        private byte[] _contents;

        public Memory(int size)
        {
            Size = size;
            _contents = new byte[size];
        }

        public void Write(byte data, int address)
        {
            _contents[address] = data;
        }

        public void Write(byte[] data, int address)
        {
            for(int i = 0; i < data.Length; i++)
            {
                _contents[address + i] = data[i];
            }
        }

        public byte Read(int address)
        {
            return _contents[address];
        }

        public void Clear()
        {
            for(int i = 0; i < Size; i++)
            {
                _contents[i] = 0;
            }
        }
    }
}
