using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chipster
{
    sealed class InputHandler : IInputHandler
    {
        private Dictionary<Keys, byte> keyCodes;

        public InputHandler(Keys[] k)
        {
            if (k.Length != 16)
                throw new ArgumentException("Need to specify 16 keys");

            Dictionary<Keys, byte> kc = new Dictionary<Keys, byte>();

            for(byte i = 0; i < 16; i++)
            {
                kc[k[i]] = i;
            }
        }

        public byte? GetKeyCode(Keys k)
        {
            if (!keyCodes.Keys.Contains(k))
                return null;
            else
                return keyCodes[k];
        }
    }
}
