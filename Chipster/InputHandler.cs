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

            keyCodes = new Dictionary<Keys, byte>();

            for (byte i = 0; i < 16; i++)
            {
                keyCodes[k[i]] = i;
            }
        }

        public void GetKeyCode(Keys k, out byte? b)
        {
            if (!keyCodes.Keys.Contains(k))
                b = null;
            else
                b = keyCodes[k];

            return;
        }
    }
}