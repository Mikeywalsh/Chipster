using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace Chipster
{
    sealed class InputHandler
    {
        private Key[] keys;

        public InputHandler(Key[] k)
        {
            if (k.Length != 16)
                throw new ArgumentException("Need to specify 16 keys");
            keys = k;
        }

        public byte? GetKey()
        {
            byte? pressedKeyValue = null;
            KeyboardState state = new KeyboardState();
            
            for(byte i = 0; i < keys.Length; i++)
            {
                if (state.IsKeyDown(keys[i]))
                    pressedKeyValue = i;
            }

            return pressedKeyValue;
        }
    }
}
