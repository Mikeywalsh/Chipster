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
            FileStream reader = new FileStream(romPath, FileMode.Open);
            StreamWriter writer = new StreamWriter(codePath);

            //ROMs are copied into memory starting at location 512 (0x200)
            int currentLine = 512;

            //A buffer used to store the current instruction, which is always 2 bytes long
            byte[] currentInstructionBuffer = new byte[2];

            //A string representation of the current instruction
            string currentInstruction;

            while (reader.Read(currentInstructionBuffer, currentLine - 512, 2) != 0)
            {
                
            }
        }
    }
}
