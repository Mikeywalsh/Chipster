using System;
using OpenTK.Input;

namespace Chipster
{
    sealed class InputHandler : IInputHandler
    {
        /// <summary>
        /// An array of mappings between keys and their corresponding index on the hexidecimal input
        /// </summary>
        private static Key[] InputKeys = new Key[] { Key.KeypadPeriod, Key.Keypad7, Key.Keypad8, Key.Keypad9, Key.Keypad4, Key.Keypad5, Key.Keypad6, Key.Keypad1, Key.Keypad2, Key.Keypad3, Key.Keypad0, Key.KeypadEnter, Key.KeypadMinus, Key.KeypadAdd, Key.KeypadDivide, Key.KeypadMultiply };

        /// <summary>
        /// Refresh each flag in the input keys array
        /// </summary>
        /// <param name="keys">An array of 16 length, each element is set to true if its corresponding key is pressed down, false if not</param>
        public void RefreshInput(bool[] keys)
        {
            //Check that the input keys array is of 16 length
            if (keys.Length != 16)
                throw new ArgumentException("Need to specify 16 keys");

            //Get the current state of the keyboard
            KeyboardState currentState = Keyboard.GetState();

            //Assign a true or false value to each element of the keys array
            for (int i = 0; i < 16; i++)
            {
                keys[i] = currentState[InputKeys[i]];
            }
        }
    }
}
