using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipster
{
    sealed class CPU
    {
        private ushort opcode;
        private IMemory memory = new Memory(4096);
        private byte[] registers = new byte[16];
        private ushort index;
        private ushort pc;
        private byte[] gfx = new byte[64 * 32];
        private byte delay_timer;
        private byte sound_timer;
        private bool beep;
        private Stack<ushort> stack;
        private bool[] key = new bool[16];
        private bool drawFlag = true;

        private bool unknownOpcode;
        Random rand = new Random();

        /// <summary>
        /// Initialise the chip8 system
        /// </summary>
        /// <param name="mem">The starting memory</param>
        public CPU(IMemory mem)
        {
            memory = mem;
            Reset();
        }

        /// <summary>
        /// Reset the chip8 back to its base values
        /// </summary>
        public void Reset()
        {
            pc = 512;
            opcode = 0;
            index = 0;
            SetKeys();

            //Clear Display
            gfx = new byte[64 * 32];

            //Clear Stack
            stack = new Stack<ushort>(16);

            //Clear registers
            registers = new byte[16];

            //Clear memory
            memory.Clear();

            //Set fontset
            memory.Write(FontSet, 0);

            //Reset timers
            delay_timer = 0;
            sound_timer = 0;
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
            drawFlag = false;

            //Fetch Opcode
            byte byte1 = memory.Read(pc);
            byte byte2 = memory.Read(pc + 1);
            opcode = (ushort)(byte1 << 8 | byte2);

            switch (opcode & 0xF000)
            {
                //Two different opcodes beginning with 0
                case 0x0000:
                    switch (byte2)
                    {
                        //00E0 - Clear the screen
                        case 0xE0:
                            gfx = new byte[64 * 32];
                            pc += 2;
                            break;
                        //OOEE - Returns from a subroutine
                        case 0xEE:
                            pc = stack.Pop();
                            pc += 2;
                            break;
                        default:
                            unknownOpcode = true;
                            break;
                    }
                    break;
                //1NNN - Jump to address NNN
                case 0x1000:
                    pc = (ushort)(opcode & 0x0FFF);
                    break;
                ////2NNN - Calls subroutine at NNN
                case 0x2000:
                    stack.Push(pc);
                    pc = (ushort)(opcode & 0x0FFF);
                    break;
                //3XNN - Skip the next instruction if RX equals NN
                case 0x3000:
                    if (registers[byte1 & 0x0F] == byte2)
                    {
                        pc += 2;
                    }
                    pc += 2;
                    break;
                //4XNN - Skip the next instruction if RX doesn't equal NN
                case 0x4000:
                    if (registers[byte1 & 0x0F] != byte2)
                    {
                        pc += 2;
                    }
                    pc += 2;
                    break;
                //5XY0 - Skips the next instruction if RX equals RY
                case 0x5000:
                    if (registers[byte1 & 0x0F] == registers[byte2 >> 4])
                    {
                        pc += 2;
                    }
                    pc += 2;
                    break;
                //6XNN - Sets register X to the value of NN
                case 0x6000:
                    registers[byte1 & 0x0F] = byte2;
                    pc += 2;
                    break;
                //7XNN - Adds NN to the value stored at RX
                case 0x7000:
                    registers[byte1 & 0x0F] += byte2;
                    pc += 2;
                    break;
                //Series of opcodes beginning with 8 that perform various register arithmatic
                case 0x8000:
                    switch(byte2 & 0x0F)
                    {
                        //8XY0 - Set RX to the value of RY
                        case 0x00:
                            registers[byte1 & 0x0F] = registers[byte2 >> 4];
                            pc += 2;
                            break;
                        //8XY1 - Sets RX to RX or RY
                        case 0x01:
                            registers[byte1 & 0x0F] |= registers[byte2 >> 4];
                            pc += 2;
                            break;
                        //8XY2 - Sets RX to RX and RY
                        case 0x02:
                            registers[byte1 & 0x0F] &= registers[byte2 >> 4];
                            pc += 2;
                            break;
                        //8XY3 - Sets RX to RX xor RY
                        case 0x03:
                            registers[byte1 & 0x0F] ^= registers[byte2 >> 4];
                            pc += 2;
                            break;
                        //8XY4 - Adds RY to RX, RF is set to 1 if carry, 0 if not.
                        case 0x04:
                            ushort sum = (ushort)(registers[byte2 >> 4] + registers[byte1 & 0x0F]);
                            if (sum > 255)
                            {
                                registers[0xF] = 1;
                                sum -= 256;
                            }
                            else
                                registers[0xF] = 0;
                            registers[byte1 & 0x0F] = (byte)(sum);
                            pc += 2;
                            break;
                        //8XY5 - RX = RX - RY, RF is set to NOT borrow - MAY NOT WORK
                        case 0x05:
                            registers[0xF] = (registers[byte1 & 0x0F] > registers[(byte2 & 0xF0) >> 4] ? (byte)1 : (byte)0);
                            if (registers[byte1 & 0x0F] - registers[(byte2 & 0xF0) >> 4] < 0)
                            {
                                registers[byte1 & 0x0F] = (byte)((registers[byte1 & 0x0F] - registers[(byte2 & 0xF0) >> 4]) + 256);
                            }
                            else
                            {
                                registers[byte1 & 0x0F] = (byte)(registers[byte1 & 0x0F] - registers[(byte2 & 0xF0) >> 4]);
                            }
                            pc += 2;
                            break;
                        //8XY6 - Shift vx right by 1
                        case 0x06:
                            registers[0xF] = (byte)((registers[byte1 & 0x0F] & 0x1));
                            registers[byte1 & 0x0f] >>= 1;
                            pc += 2;
                            break;
                        //8XYE - Shift vx left by 1
                        case 0x0E:
                            registers[0xF] = (byte)((registers[byte1 & 0x0F] & 0x1));
                            ushort temp = registers[byte1 & 0x0f] >>= 1;
                            if (temp > 255)
                                temp -= 256;

                            registers[byte1 & 0x0F] = (byte)temp;
                            pc += 2;
                            break;
                        default:
                            unknownOpcode = true;
                            break;
                    }
                    break;
                //9XY0 - Skips the next instruction if RX doesn't equal RY
                case 0x9000:
                    if (registers[byte1 & 0x0F] != registers[byte2 >> 4])
                    {
                        pc += 2;
                    }
                    pc += 2;
                    break;
                //ANNN - Set the index register to the value of NNN
                case 0xA000:
                    index = (ushort)(opcode & 0x0FFF);
                    pc += 2;
                    break;
                //CXNN - Set RX to the result of an and operation on a random number and NN
                case 0xC000:
                    registers[byte1 & 0x0F] = (byte)(byte2 & (byte)(rand.Next(256)));
                    pc += 2;
                    break;
                //DXYN - Draw sprite starting in index at location (RX, RY) with N height
                case 0xD000:
                    byte xPos = registers[byte1 & 0x0F];

                    if (xPos < 0)
                        xPos += 64;
                    else if (xPos >= 64)
                        xPos -= 64;

                    byte yPos = registers[byte2 >> 4];

                    if (yPos < 0)
                        yPos += 32;
                    else if (yPos >= 32)
                        yPos -= 32;

                    byte height = (byte)(byte2 & 0x0F);
                    byte pixel;
                    drawFlag = true;

                    registers[0xF] = 0;

                    for (int y = 0; y < height && yPos + y < 32; y++)
                    {
                        pixel = memory.Read(index + y);
                        for(int x = 0; x < 8 && xPos + x < 64; x++)
                        {
                            if ((pixel & (0x80 >> x)) != 0)
                            {
                                if (gfx[xPos + x + ((yPos + y) * 64)] == 255)
                                {
                                    registers[0xF] = 1;
                                    gfx[xPos + x + ((yPos + y) * 64)] = 0;
                                    continue;
                                }
                                gfx[xPos + x + ((yPos + y) * 64)] = 255;
                            }
                        }
                    }
                    pc += 2;
                    break;
                //Opcodes to do with key presses
                case 0xE000:
                    switch(byte2)
                    {
                        //Ex9E - Skip next instruction if key at x is pressed
                        case 0x9E:
                            if (key[(byte1 & 0x0F)])
                            {
                                pc += 2;
                            }
                            pc += 2;
                            break;
                        //ExA1 - Skip next instruction if key at x is NOT pressed
                        case 0xA1:
                            if (!key[(byte1 & 0x0F)])
                            {
                                pc += 2;
                            }
                            pc += 2;
                            break;
                    }
                    break;
                ///Series of opcodes beginning with F that perform various functions
                case 0xF000:
                    switch(byte2)
                    {
                        //FX07 - Set RX to the value of the delay timer
                        case 0x07:
                            registers[byte1 & 0x0F] = delay_timer;
                            pc += 2;
                            break;
                        //FX0A - Await key press then store result in RX
                        case 0x0A:
                            //Temp, just set RX to first key value immediately
                            registers[byte1 & 0x0F] = 0;
                            pc += 2;
                            break;
                        //FX15 - Set the value of the delay timer to be equal to RX
                        case 0x15:
                            delay_timer = registers[byte1 & 0x0F];
                            pc += 2;
                            break;
                        //FX15 - Set the value of the sound timer to be equal to RX
                        case 0x18:
                            sound_timer = registers[byte1 & 0x0F];
                            pc += 2;
                            break;
                        //FX1E - Adds VX to I and sets RF to 1 if range overflow, 0 if not
                        case 0x1E:
                            ushort sum = (ushort)(index + registers[byte1 & 0x0F]);
                            if (sum > 4095)
                                registers[0xF] = 1;
                            else
                                registers[0xF] = 0;
                            index = (ushort)(sum & 0x0FFF);
                            pc += 2;
                            break;
                        //FX29 - Sets I to the location of the sprite for the character in RX
                        case 0x29:
                            index = memory.Read(registers[byte1 & 0x0F] + 80);
                            pc += 2;
                            break;
                        //FX33 - Stores the BCD representation of RX
                        case 0x33:
                            string numString = registers[(byte)(byte1 & 0x0F)].ToString("000");
                            for (int i = 0; i < 3; i++)
                            {
                                memory.Write(byte.Parse(numString[i].ToString()), index + i);
                            }
                            pc += 2;
                            break;
                        //FX55 - Stores R0 to RX(inclusive) in memory starting at the address in index
                        case 0x55:
                            for(int i = 0; i < ((byte1 & 0x0F) + 1); i++)
                            {
                                memory.Write(registers[i], index + i);
                            }
                            pc += 2;
                            break;
                        //FX65 - Fills R0 to RX(inclusive) from memory values starting at the address in index
                        case 0x65:
                            for (int i = 0; i < ((byte1 & 0x0F) + 1); i++)
                            {
                               registers[i] = memory.Read(index + i);
                            }
                            pc += 2;
                            break;
                        default:
                            unknownOpcode = true;
                            break;
                    }
                    break;
                //If ROM data doesnt match any known opcodes, then inform the user
                default:
                    unknownOpcode = true;
                    break;
            }

            if (delay_timer > 0)
                delay_timer--;

            if(sound_timer > 0)
            {
                sound_timer--;
                beep = true;
            }
            else
            {
                beep = false;
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

        //Accessors
        public byte[] Registers
        {
            get { return registers; }
        }

        public ushort PC
        {
            get { return pc; }
        }

        public ushort Index
        {
            get { return index; }
        }

        public ushort Opcode
        {
            get { return opcode; }
        }

        public byte[] GFX
        {
            get { return gfx; }
        }

        public bool DrawFlag
        {
            get { return drawFlag; }
        }

        public bool Beep
        {
            get { return beep; }
        }

        public byte[] FontSet
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

        public bool UnknownOpcode
        {
            get { return unknownOpcode; }
        }
    }
}
