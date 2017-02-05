using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipster
{
    static class HexHelper
    {
        public static string ByteToHex(byte b)
        {
            string hex = BitConverter.ToString(new byte[1] { b });
            return hex.Replace("-", "");
        }

        public static string ByteToHex(byte[] b)
        {
            string hex = BitConverter.ToString(b);
            return hex.Replace("-", "");
        }

        public static string UshortToHex(ushort u)
        {
            return ByteToHex(new byte[] { (byte)(u >> 8), (byte)(u & 0x00FF)});
        }
        
        public static byte[] StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
