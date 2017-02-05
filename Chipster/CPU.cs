using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipster
{
    [Serializable]
    sealed class CPU
    {
        private IMemory memory;
        public byte[] Registers { get; private set; }
        public ushort Index { get; private set; }
        public ushort PC { get; private set; }
        public ushort Opcode { get; private set; }
        public byte[] GFX { get; private set; }
        public byte DelayTimer { get; private set; }
        public byte SoundTimer { get; private set; }
        public bool Beep { get; private set; }
        public bool UnknownOpcode { get; private set; }
        private Stack<ushort> stack;
        private bool[] key;
        public bool DrawFlag { get;  private set;}

        private Random rand = new Random();

        /// <summary>
        /// Initialise the chip8 system
        /// </summary>
        /// <param name="mem">The starting memory</param>
        public CPU(IMemory mem)
        {
            memory = mem;
            GFX = new byte[64 * 32];
            key = new bool[16];
            Reset();
        }

        /// <summary>
        /// Reset the chip8 back to its base values
        /// </summary>
        public void Reset()
        {
            PC = 512;
            Opcode = 0;
            Index = 0;
            SetKeys();

            //Clear Display
            for (int i = 0; i < GFX.Length; i++)
            { 
                GFX[i] = 0;
            }

            //Clear Stack
            stack = new Stack<ushort>(16);

            //Clear registers
            Registers = new byte[16];

            //Clear memory
            memory.Clear();

            //Set fontset
            memory.Write(FontSet, 0);

            //Reset timers
            DelayTimer = 0;
            SoundTimer = 0;
        }

        /// <summary>
        /// Load ROM from a file on the users PC into memory
        /// </summary>
        /// <param name="filePath">Path that the ROM is located at</param>
        public void LoadROM(string filePath)
        {
            byte[] fileContents = File.ReadAllBytes(filePath);
            memory.Write(fileContents, 512);
        }

        /// <summary>
        /// Emulate a single cycle of the chip8 system
        /// </summary>
        public void EmulateCycle()
        {
            DrawFlag = false;

            //Fetch Opcode
            byte byte1 = memory.Read(PC);
            byte byte2 = memory.Read(PC + 1);
            Opcode = (ushort)(byte1 << 8 | byte2);

            switch (Opcode & 0xF000)
            {
                //Two different Opcodes beginning with 0
                case 0x0000:
                    switch (byte2)
                    {
                        //00E0 - Clear the screen
                        case 0xE0:
                            for (int i = 0; i < GFX.Length; i++)
                            {
                                GFX[i] = 0;
                            }
                            PC += 2;
                            break;
                        //OOEE - Returns from a subroutine
                        case 0xEE:
                            PC = stack.Pop();
                            PC += 2;
                            break;
                        default:
                            UnknownOpcode = true;
                            break;
                    }
                    break;
                //1NNN - Jump to address NNN
                case 0x1000:
                    PC = (ushort)(Opcode & 0x0FFF);
                    break;
                ////2NNN - Calls subroutine at NNN
                case 0x2000:
                    stack.Push(PC);
                    PC = (ushort)(Opcode & 0x0FFF);
                    break;
                //3XNN - Skip the next instruction if RX equals NN
                case 0x3000:
                    if (Registers[byte1 & 0x0F] == byte2)
                    {
                        PC += 2;
                    }
                    PC += 2;
                    break;
                //4XNN - Skip the next instruction if RX doesn't equal NN
                case 0x4000:
                    if (Registers[byte1 & 0x0F] != byte2)
                    {
                        PC += 2;
                    }
                    PC += 2;
                    break;
                //5XY0 - Skips the next instruction if RX equals RY
                case 0x5000:
                    if (Registers[byte1 & 0x0F] == Registers[byte2 >> 4])
                    {
                        PC += 2;
                    }
                    PC += 2;
                    break;
                //6XNN - Sets register X to the value of NN
                case 0x6000:
                    Registers[byte1 & 0x0F] = byte2;
                    PC += 2;
                    break;
                //7XNN - Adds NN to the value stored at RX
                case 0x7000:
                    Registers[byte1 & 0x0F] += byte2;
                    PC += 2;
                    break;
                //Series of Opcodes beginning with 8 that perform various register arithmatic
                case 0x8000:
                    switch(byte2 & 0x0F)
                    {
                        //8XY0 - Set RX to the value of RY
                        case 0x00:
                            Registers[byte1 & 0x0F] = Registers[byte2 >> 4];
                            PC += 2;
                            break;
                        //8XY1 - Sets RX to RX or RY
                        case 0x01:
                            Registers[byte1 & 0x0F] |= Registers[byte2 >> 4];
                            PC += 2;
                            break;
                        //8XY2 - Sets RX to RX and RY
                        case 0x02:
                            Registers[byte1 & 0x0F] &= Registers[byte2 >> 4];
                            PC += 2;
                            break;
                        //8XY3 - Sets RX to RX xor RY
                        case 0x03:
                            Registers[byte1 & 0x0F] ^= Registers[byte2 >> 4];
                            PC += 2;
                            break;
                        //8XY4 - Adds RY to RX, RF is set to 1 if carry, 0 if not.
                        case 0x04:
                            ushort sum = (ushort)(Registers[byte2 >> 4] + Registers[byte1 & 0x0F]);
                            if (sum > 255)
                            {
                                Registers[0xF] = 1;
                                sum -= 256;
                            }
                            else
                                Registers[0xF] = 0;
                            Registers[byte1 & 0x0F] = (byte)(sum);
                            PC += 2;
                            break;
                        //8XY5 - RX = RX - RY, RF is set to NOT borrow - MAY NOT WORK
                        case 0x05:
                            Registers[0xF] = (Registers[byte1 & 0x0F] > Registers[(byte2 & 0xF0) >> 4] ? (byte)1 : (byte)0);
                            if (Registers[byte1 & 0x0F] - Registers[(byte2 & 0xF0) >> 4] < 0)
                            {
                                Registers[byte1 & 0x0F] = (byte)((Registers[byte1 & 0x0F] - Registers[(byte2 & 0xF0) >> 4]) + 256);
                            }
                            else
                            {
                                Registers[byte1 & 0x0F] = (byte)(Registers[byte1 & 0x0F] - Registers[(byte2 & 0xF0) >> 4]);
                            }
                            PC += 2;
                            break;
                        //8XY6 - Shift RX right by 1
                        case 0x06:
                            Registers[0xF] = (byte)((Registers[byte1 & 0x0F] & 0x1));
                            Registers[byte1 & 0x0f] >>= 1;
                            PC += 2;
                            break;
                        //8XY7 - RX = RY - RX, RF is set to NOT borrow - MAY NOT WORK
                        case 0x07:
                            Registers[0xF] = (Registers[(byte2 & 0xF0) >> 4] > Registers[byte1 & 0x0F] ? (byte)1 : (byte)0);
                            if (Registers[(byte2 & 0xF0) >> 4] - Registers[byte1 & 0x0F] < 0)
                            {
                                Registers[byte1 & 0x0F] = (byte)((Registers[(byte2 & 0xF0) >> 4] - Registers[byte1 & 0x0F]) + 256);
                            }
                            else
                            {
                                Registers[byte1 & 0x0F] = (byte)(Registers[(byte2 & 0xF0) >> 4] - Registers[byte1 & 0x0F]);
                            }
                            PC += 2;
                            break;
                        //8XYE - Shift RX left by 1
                        case 0x0E:
                            Registers[0xF] = (byte)((Registers[byte1 & 0x0F] & 0x1));
                            ushort temp = Registers[byte1 & 0x0f] >>= 1;
                            if (temp > 255)
                                temp -= 256;

                            Registers[byte1 & 0x0F] = (byte)temp;
                            PC += 2;
                            break;
                        default:
                            UnknownOpcode = true;
                            break;
                    }
                    break;
                //9XY0 - Skips the next instruction if RX doesn't equal RY
                case 0x9000:
                    if (Registers[byte1 & 0x0F] != Registers[byte2 >> 4])
                    {
                        PC += 2;
                    }
                    PC += 2;
                    break;
                //ANNN - Set the Index register to the value of NNN
                case 0xA000:
                    Index = (ushort)(Opcode & 0x0FFF);
                    PC += 2;
                    break;
                //CXNN - Set RX to the result of an and operation on a random number and NN
                case 0xC000:
                    Registers[byte1 & 0x0F] = (byte)(byte2 & (byte)(rand.Next(256)));
                    PC += 2;
                    break;
                //DXYN - Draw sprite starting in Index at location (RX, RY) with N height
                case 0xD000:
                    byte xPos = Registers[byte1 & 0x0F];

                    if (xPos < 0)
                        xPos += 64;
                    else if (xPos >= 64)
                        xPos -= 64;

                    byte yPos = Registers[byte2 >> 4];

                    if (yPos < 0)
                        yPos += 32;
                    else if (yPos >= 32)
                        yPos -= 32;

                    byte height = (byte)(byte2 & 0x0F);
                    byte pixel;
                    DrawFlag = true;

                    Registers[0xF] = 0;

                    for (int y = 0; y < height && yPos + y < 32; y++)
                    {
                        pixel = memory.Read(Index + y);
                        for(int x = 0; x < 8 && xPos + x < 64; x++)
                        {
                            if ((pixel & (0x80 >> x)) != 0)
                            {
                                if (GFX[xPos + x + ((yPos + y) * 64)] == 255)
                                {
                                    Registers[0xF] = 1;
                                    GFX[xPos + x + ((yPos + y) * 64)] = 0;
                                    continue;
                                }
                                GFX[xPos + x + ((yPos + y) * 64)] = 255;
                            }
                        }
                    }
                    PC += 2;
                    break;
                //Opcodes to do with key presses
                case 0xE000:
                    switch(byte2)
                    {
                        //EX9E - Skip next instruction if key at x is pressed
                        case 0x9E:
                            if (key[(byte1 & 0x0F)])
                            {
                                PC += 2;
                            }
                            PC += 2;
                            break;
                        //EXA1 - Skip next instruction if key at x is NOT pressed
                        case 0xA1:
                            if (!key[(byte1 & 0x0F)])
                            {
                                PC += 2;
                            }
                            PC += 2;
                            break;
                        default:
                            UnknownOpcode = true;
                            break;
                    }
                    break;
                ///Series of Opcodes beginning with F that perform various functions
                case 0xF000:
                    switch(byte2)
                    {
                        //FX07 - Set RX to the value of the delay timer
                        case 0x07:
                            Registers[byte1 & 0x0F] = DelayTimer;
                            PC += 2;
                            break;
                        //FX0A - Await key press then store result in RX
                        case 0x0A:
                            //Temp, just set RX to first key value immediately
                            Registers[byte1 & 0x0F] = 0;
                            PC += 2;
                            break;
                        //FX15 - Set the value of the delay timer to be equal to RX
                        case 0x15:
                            DelayTimer = Registers[byte1 & 0x0F];
                            PC += 2;
                            break;
                        //FX15 - Set the value of the sound timer to be equal to RX
                        case 0x18:
                            SoundTimer = Registers[byte1 & 0x0F];
                            PC += 2;
                            break;
                        //FX1E - Adds RX to I and sets RF to 1 if range overflow, 0 if not
                        case 0x1E:
                            ushort sum = (ushort)(Index + Registers[byte1 & 0x0F]);
                            if (sum > 4095)
                                Registers[0xF] = 1;
                            else
                                Registers[0xF] = 0;
                            Index = (ushort)(sum & 0x0FFF);
                            PC += 2;
                            break;
                        //FX29 - Sets I to the location of the sprite for the character in RX
                        case 0x29:
                            Index = memory.Read(Registers[byte1 & 0x0F] + 80);
                            PC += 2;
                            break;
                        //FX33 - Stores the BCD representation of RX
                        case 0x33:
                            string numString = Registers[(byte)(byte1 & 0x0F)].ToString("000");
                            for (int i = 0; i < 3; i++)
                            {
                                memory.Write(byte.Parse(numString[i].ToString()), Index + i);
                            }
                            PC += 2;
                            break;
                        //FX55 - Stores R0 to RX(inclusive) in memory starting at the address in Index
                        case 0x55:
                            for(int i = 0; i < ((byte1 & 0x0F) + 1); i++)
                            {
                                memory.Write(Registers[i], Index + i);
                            }
                            PC += 2;
                            break;
                        //FX65 - Fills R0 to RX(inclusive) from memory values starting at the address in Index
                        case 0x65:
                            for (int i = 0; i < ((byte1 & 0x0F) + 1); i++)
                            {
                               Registers[i] = memory.Read(Index + i);
                            }
                            PC += 2;
                            break;
                        default:
                            UnknownOpcode = true;
                            break;
                    }
                    break;
                //If ROM data doesnt match any known Opcodes, then inform the user
                default:
                    UnknownOpcode = true;
                    break;
            }

            if (DelayTimer > 0)
                DelayTimer--;

            if(SoundTimer > 0)
            {
                SoundTimer--;
                Beep = true;
            }
            else
            {
                Beep = false;
            }
        }

        /// <summary>
        /// Set the current key states
        /// </summary>
        public void SetKeys()
        {
            for(int i = 0; i < key.Length; i++)
            {
                key[i] = false;
            }
        }

        //The base fontset, representing hex values from 0-F, which all CPU instances contain
        public static byte[] FontSet
        {
            get
            {
                return new byte[80]
                {
                    0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
                    0x20, 0x60, 0x20, 0x20, 0x70, // 1
                    0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
                    0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
                    0x90, 0x90, 0xF0, 0x10, 0x10, // 4
                    0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
                    0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
                    0xF0, 0x10, 0x20, 0x40, 0x40, // 7
                    0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
                    0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
                    0xF0, 0x90, 0xF0, 0x90, 0x90, // A
                    0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
                    0xF0, 0x80, 0x80, 0x80, 0xF0, // C
                    0xE0, 0x90, 0x90, 0x90, 0xE0, // D
                    0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
                    0xF0, 0x80, 0xF0, 0x80, 0x80  // F
                };
            }
        }
    }
}
