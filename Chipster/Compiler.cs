using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipster
{
    static class Compiler
    {
        public static void Compile(string codePath, string romPath)
        {

        }

        public static void Decompile(string romPath, string codePath)
        {
            using (FileStream reader = new FileStream(romPath, FileMode.Open))
            {
                using (StreamWriter writer = new StreamWriter(codePath))
                {
                    //ROMs are copied into memory starting at location 512 (0x200)
                    int currentLine = 512;

                    //A buffer used to store the current instruction, which is always 2 bytes long
                    byte[] currentInstruction = new byte[2];

                    //A string representing the current instruction
                    string instructionText;

                    while (reader.Read(currentInstruction, 0, 2) != 0)
                    {
                        instructionText = HexHelper.ByteToHex(currentInstruction);
                        writer.WriteLine(instructionText + "    -Line " + currentLine.ToString("0000"));
                        currentLine++;
                    }
                }
            }
        }
    }
}
