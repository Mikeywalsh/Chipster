using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipster
{
    sealed class Memory
    {
        public int Size { get; private set; }

        private byte[] _contents;

        public Memory(int size)
        {
            Size = size;
            _contents = new byte[size];
        }

        public void Write(byte data, ushort address)
        {
            _contents[address] = data;
        }

        public void Write(byte[] data, ushort address)
        {
            for(int i = 0; i < data.Length; i++)
            {
                _contents[address + i] = data[i];
            }
        }

        public byte Read(ushort address)
        {
            return _contents[address];
        }
    }
}
