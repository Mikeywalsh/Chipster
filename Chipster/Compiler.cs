using System;
using System.IO;
using System.Windows.Forms;

namespace Chipster
{
    static class Compiler
    {
        public static void Compile(string codePath, string romPath)
        {
            using (StreamReader reader = new StreamReader(codePath))
            using (FileStream writer = new FileStream(romPath, FileMode.Create))
            {
                string currentLine;
                byte[] currentInstruction = new byte[2];

                //Read throught the input code file one line at a time
                while ((currentLine = reader.ReadLine()) != null)
                {
                    try
                    {
                        //Get the current instruction from the current line
                        currentInstruction = HexHelper.StringToByteArray(currentLine.Substring(7, 4));

                        //Write the current instruction to the ROM file
                        writer.Write(currentInstruction, 0, 2);
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        //Alert the user that the input file is in an invalid format
                        MessageBox.Show("Could not compile file! Invalid format...");

                        //Dispose of the writer so that the incomplete ROM file can be deleted
                        writer.Dispose();

                        //Delete the incomplete ROM file and return
                        File.Delete(romPath);
                        return;
                    }
                }

                //If this line has been reached, then the compilation was a success. Inform the user
                MessageBox.Show("Compiled " + codePath + "\nStored results in " + romPath, "\nSuccessful Compilation");
            }
        }

        public static void Decompile(string romPath, string codePath)
        {
            using (FileStream reader = new FileStream(romPath, FileMode.Open))
            using (StreamWriter writer = new StreamWriter(codePath))
            {
                //ROMs are copied into memory starting at location 512 (0x200)
                ushort currentLine = 512;

                //A buffer used to store the current instruction, which is always 2 bytes long
                byte[] currentInstruction = new byte[2];
                
                //Flag used to signal if code is unreachable, for example if it appears after an unknown opcode
                bool unreachableCode = false;

                while (reader.Read(currentInstruction, 0, 2) != 0)
                {
                    //Helper variables used to contain information about the current instruction
                    byte byte1 = currentInstruction[0];
                    byte byte2 = currentInstruction[1];
                    ushort opcode = (ushort)(byte1 << 8 | byte2);
                    string instructionString = HexHelper.ByteToHex(currentInstruction);
                    bool unknownOpcode = false;
                    string currentLineText = "";

                    currentLineText += "0x" + HexHelper.UshortToHex(currentLine).Substring(1) + ": " + instructionString + "   -";

                    //Dont bother reading opcode if it is not reachable
                    if (!unreachableCode)
                    {
                        switch (opcode & 0xF000)
                        {
                            //Two different opcodes beginning with 0
                            case 0x0000:
                                switch (byte2)
                                {
                                    //00E0 - Clear the screen
                                    case 0xE0:
                                        currentLineText += "Clear the screen";
                                        break;
                                    //OOEE - Returns from a subroutine
                                    case 0xEE:
                                        currentLineText += "Return from current subroutine";
                                        break;
                                    default:
                                        unknownOpcode = true;
                                        break;
                                }
                                break;
                            //1NNN - Jump to address NNN
                            case 0x1000:
                                currentLineText += "Jump to address 0x" + instructionString.Substring(1);
                                break;
                            ////2NNN - Calls subroutine at NNN
                            case 0x2000:
                                currentLineText += "Call subroutine at 0x" + instructionString.Substring(1);
                                break;
                            //3XNN - Skip the next instruction if RX equals NN
                            case 0x3000:
                                currentLineText += "Skip the next instruction if the value at R" + instructionString[1] + " equals 0x" + instructionString.Substring(2);
                                break;
                            //4XNN - Skip the next instruction if RX doesn't equal NN
                            case 0x4000:
                                currentLineText += "Skip the next instruction if the value at R" + instructionString[1] + " does not equal " + instructionString.Substring(2);
                                break;
                            //5XY0 - Skips the next instruction if RX equals RY
                            case 0x5000:
                                currentLineText += "Skip the next instruction if the value at R" + instructionString[1] + " equals the value at R" + instructionString[2];
                                break;
                            //6XNN - Sets register X to the value of NN
                            case 0x6000:
                                currentLineText += "Set the value of R" + instructionString[1] + " to 0x" + instructionString.Substring(2);
                                break;
                            //7XNN - Adds NN to the value stored at RX
                            case 0x7000:
                                currentLineText += "Adds the value of 0x" + instructionString.Substring(2) + " to R" + instructionString[1];
                                break;
                            //Series of opcodes beginning with 8 that perform various register arithmatic
                            case 0x8000:
                                switch (byte2 & 0x0F)
                                {
                                    //8XY0 - Set RX to the value of RY
                                    case 0x00:
                                        currentLineText += "Sets the value of R" + instructionString[1] + "to the value of R" + instructionString[2];
                                        break;
                                    //8XY1 - Sets RX to RX or RY
                                    case 0x01:
                                        currentLineText += "Sets the value of R" + instructionString[1] + "to the value of R" + instructionString[1] + " OR R" + instructionString[2];
                                        break;
                                    //8XY2 - Sets RX to RX and RY
                                    case 0x02:
                                        currentLineText += "Sets the value of R" + instructionString[1] + "to the value of R" + instructionString[1] + " AND R" + instructionString[2];
                                        break;
                                    //8XY3 - Sets RX to RX xor RY
                                    case 0x03:
                                        currentLineText += "Sets the value of R" + instructionString[1] + "to the value of R" + instructionString[1] + " XOR R" + instructionString[2];
                                        break;
                                    //8XY4 - Adds RY to RX, RF is set to 1 if carry, 0 if not.
                                    case 0x04:
                                        currentLineText += "Adds the value of R" + instructionString[2] + "to R" + instructionString[1] + " RF is set to 1 if there is a carry, 0 if not";
                                        break;
                                    //8XY5 - RX = RX - RY, RF is set to NOT borrow
                                    case 0x05:
                                        currentLineText += "Subtracts the value of R" + instructionString[2] + " from R" + instructionString[1] + " RF is set to 0 if there is a borrow, 1 if not";
                                        break;
                                    //8XY6 - Shift RX right by 1
                                    case 0x06:
                                        currentLineText += "Shift R" + instructionString[1] + "right by one";
                                        break;
                                    //8XY7 - RX = RY - RX, RF is set to NOT borrow - MAY NOT WORK
                                    case 0x07:
                                        currentLineText += "Sets R" + instructionString[1] + "to the value of R" + instructionString[2] + " minus R" + instructionString[1] + " RF is set to 0 if there is a borrow, 1 if not";
                                        break;
                                    //8XYE - Shift RX left by 1
                                    case 0x0E:
                                        currentLineText += "Shift R" + instructionString[1] + "left by one";
                                        break;
                                    default:
                                        unknownOpcode = true;
                                        break;
                                }
                                break;
                            //9XY0 - Skips the next instruction if RX doesn't equal RY
                            case 0x9000:
                                currentLineText += "Skip the next instruction if R" + instructionString[1] + " does not equal R" + instructionString[2];
                                break;
                            //ANNN - Set the Index register to the value of NNN
                            case 0xA000:
                                currentLineText += "Set the Index register to the value of 0x" + instructionString.Substring(1);
                                break;
                            //CXNN - Set RX to the result of an and operation on a random number and NN
                            case 0xC000:
                                currentLineText += "Set R" + instructionString[1] + " to the result of an AND operation on a random number and 0x" + instructionString.Substring(2);
                                break;
                            //DXYN - Draw sprite starting in Index at location (RX, RY) with N height
                            case 0xD000:
                                currentLineText += "Draw sprite starting in index at location (R" + instructionString[1] + ", R" + instructionString[2] + ") with " + instructionString[3] + " height";
                                break;
                            //opcodes to do with key presses
                            case 0xE000:
                                switch (byte2)
                                {
                                    //EX9E - Skip next instruction if key at x is pressed
                                    case 0x9E:
                                        currentLineText += "Skip next instruction if key at " + instructionString[1] + " is pressed";
                                        break;
                                    //EXA1 - Skip next instruction if key at x is NOT pressed
                                    case 0xA1:
                                        currentLineText += "Skip next instruction if key at " + instructionString[1] + " is notpressed";
                                        break;
                                    default:
                                        unknownOpcode = true;
                                        break;
                                }
                                break;
                            ///Series of opcodes beginning with F that perform various functions
                            case 0xF000:
                                switch (byte2)
                                {
                                    //FX07 - Set RX to the value of the delay timer
                                    case 0x07:
                                        currentLineText += "Set R" + instructionString[1] + " to the value of the delay timer";
                                        break;
                                    //FX0A - Await key press then store result in RX
                                    case 0x0A:
                                        currentLineText += "Await key press, then store the result in R" + instructionString[1];
                                        break;
                                    //FX15 - Set the value of the delay timer to be equal to RX
                                    case 0x15:
                                        currentLineText += "Set the value of the delay timer to be equal to R" + instructionString[1];
                                        break;
                                    //FX15 - Set the value of the sound timer to be equal to RX
                                    case 0x18:
                                        currentLineText += "Set the value of the sound timer to be equal to R" + instructionString[1];
                                        break;
                                    //FX1E - Adds RX to I and sets RF to 1 if range overflow, 0 if not
                                    case 0x1E:
                                        currentLineText += "Add R" + instructionString[1] + " to Index and sets RF to 1 if there is an overflow, 0 if not";
                                        break;
                                    //FX29 - Sets I to the location of the sprite for the character in RX
                                    case 0x29:
                                        currentLineText += "Set Index to the location of the sprite for the character in R" + instructionString[1];
                                        break;
                                    //FX33 - Stores the BCD representation of RX
                                    case 0x33:
                                        currentLineText += "Store the BCD representation of R" + instructionString[1] + " in memory, starting at the address in Index";
                                        break;
                                    //FX55 - Stores R0 to RX(inclusive) in memory starting at the address in Index
                                    case 0x55:
                                        currentLineText += "Store R0 to R" + instructionString[1] + " to memory values starting at the address in Index";
                                        break;
                                    //FX65 - Fills R0 to RX(inclusive) from memory values starting at the address in Index
                                    case 0x65:
                                        currentLineText += "Fill R0 to R" + instructionString[1] + " from memory values starting at the address in Index";
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
                    }

                    if(unreachableCode)
                    {
                        currentLineText += "Unreachable opcode, possible sprite data";
                    }
                    else if (unknownOpcode)
                    {
                        currentLineText += "Unknown opcode, possible sprite data";
                        unreachableCode = true;
                    }

                    writer.WriteLine(currentLineText);
                    currentLine+= 2;
                }

                MessageBox.Show("Decompiled " + romPath + "\nStored results in " + codePath, "\nSuccessful Decompilation");
            }
        }
    }
}
