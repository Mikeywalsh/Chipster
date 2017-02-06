using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chipster
{
    public partial class frmMain : Form
    {
        //CPU and Display instances
        CPU myChip;
        Display myDisplay;

        //Debugger variables
        TextBox[] registerDisplays = new TextBox[16];
        bool initialised;
        bool showDebugger;
        bool showHex;
        bool romLoaded;
        bool stopped;
        bool stepMode;

        //Other GUI variables
        ToolStripMenuItem lastSpeedChecked;
        ToolStripMenuItem lastMultiplierChecked;

        //Variable for determining IPS and FPS, and controlling clock speed
        Stopwatch clockTimer;
        float clockSpeed;
        long lastInstructionTick = 0;
        int instructionsThisSecond;
        int framesThisSecond;

        public frmMain()
        {
            InitializeComponent();
            Application.Idle += HandleApplicationIdle;     

            //Stream stream = File.Open("test.chst8", FileMode.Create);
            //BinaryFormatter b = new BinaryFormatter();

            //b.Serialize(stream, myChip);
            //stream.Close();

            //myChip = null;

            ////Opens file "data.xml" and deserializes the object from it.
            //stream = File.Open("test.chst8", FileMode.Open);
            //b = new BinaryFormatter();

            ////formatter = new BinaryFormatter();

            //myChip = (CPU)b.Deserialize(stream);
            //stream.Close();
        }

        /// <summary>
        /// Main loop for chip8 instance
        /// </summary>
        private void mainLoop()
        {
            //Update the debug info, if it is enabled, still allow the user to swap between hex and decimal view even if stopped
            if (showDebugger)
                UpdateInfo();

            //If the stopped flag is set, halt further execution
            if (stopped)
                return;
            
            //Run a CPU cycle and update timer values
            myChip.EmulateCycle();
            instructionsThisSecond++;
            lastInstructionTick = clockTimer.ElapsedTicks;

            //If the draw flag in the CPU is enabled, then output the GFX array to screen
            if (myChip.DrawFlag)
                glDisplay.Invalidate();

            //Set the currently pressed keys in the CPU instance
            myChip.SetKeys();

            //Halt execution if the user has paused exectuion or an unknown opcode has been reached
            if(stepMode || myChip.UnknownOpcode)
                stopped = true;
        }

        /// <summary>
        /// Update debug info shown to the side of the screen, containing information about various registers.
        /// </summary>
        public void UpdateInfo()
        {
            //txtProgramCounter.Text = showHex ? HexHelper.UshortToHex(myChip.PC) : myChip.PC.ToString();
            //txtInstruction.Text = showHex ? HexHelper.UshortToHex(myChip.Opcode) : myChip.Opcode.ToString();
            //txtAdress.Text = showHex ? HexHelper.UshortToHex(myChip.Index) : myChip.Index.ToString();
            //txtMessage.Text = myChip.UnknownOpcode ? "Unknown Opcode" : "None";
            //txtSound.Text = myChip.Beep ? "BEEP!" : "-";

            //for (int i = 0; i < 16; i++)
            //{
            //    registerDisplays[i].Text = showHex ? HexHelper.ByteToHex(myChip.Registers[i]).ToString() : myChip.Registers[i].ToString();
            //}

            if (clockTimer.ElapsedMilliseconds >= 1000)
            {
                txtFPS.Text = framesThisSecond.ToString();
                txtIPS.Text = instructionsThisSecond.ToString();
                instructionsThisSecond = 0;
                framesThisSecond = 0;
                clockTimer.Restart();
            }
        }
                
        #region True application Idle Logic

        private bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, 0, 0, 0) == 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);
        #endregion

        /// <summary>
        /// Called every time the application is idle.
        /// </summary>
        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle() && romLoaded)
            {
                //Run the main loop at the desired clock speed
                if (clockSpeed == -1 || Stopwatch.Frequency / clockSpeed < clockTimer.ElapsedTicks - lastInstructionTick)
                    mainLoop();
            }
        }

        /// <summary>
        /// Populate the register displays array with the register text boxes displayed on the form, and set up initial variable values
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //This method was being called twice for some reason, a temporary fix has been applied, will have to find cause later
            if (initialised)
                return;

            //Assign initial data to form elements
            glDisplay.Paint += new PaintEventHandler(glDisplay_Paint);
            glDisplay.KeyDown += new KeyEventHandler(glDisplay_KeyDown);
            glDisplay.KeyUp += new KeyEventHandler(glDisplay_KeyUp);
            registerDisplays = new TextBox[16] { txtR0, txtR1, txtR2, txtR3, txtR4, txtR5, txtR6, txtR7, txtR8, txtR9, txtRA, txtRB, txtRC, txtRD, txtRE, txtRF };

            //Set initial clockspeed to default
            lastSpeedChecked = khz5ToolStripMenuItem;
            clockSpeed = 500;
            clockTimer = new Stopwatch();

            //Initialise CPU and Display variables
            myChip = new CPU(new Memory(4096));
            myDisplay = new Display(myChip, Marshal.AllocHGlobal(myChip.GFX.Length), glDisplay.ClientSize.Width, glDisplay.ClientSize.Height, 64, 32);
            showDebugger = true;
            showHex = false;
            romLoaded = false;
            initialised = true;
        }

        /// <summary>
        /// Draw the current GFX array to the screen
        /// </summary>
        void glDisplay_Paint(object sender, PaintEventArgs e)
        {
            //Don't bother drawing anything to the screen if a ROM hasn't been loaded or that draw flag in the CPU is not set
            if (!romLoaded || !myChip.DrawFlag)
                return;

            //Draw the current state of the GFX array to the screen
            myDisplay.Draw();
            glDisplay.SwapBuffers();

            framesThisSecond++;
        }

        private void glDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                Console.WriteLine("DOWN");
        }

        private void glDisplay_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                Console.WriteLine("UP");
        }

        /// <summary>
        /// Allow the user to check if they want debug results to be displayed to them in hex or base 10
        /// </summary>
        private void chkHex_CheckedChanged(object sender, EventArgs e)
        {
            showHex = chkHex.Checked;
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            stepMode = true;
            stopped = false;
        }

        private void loadROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Initialise a dialogue which allows the user to select a .ch8 ROM file to load into the CPU
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chip-8 ROM |*.ch8";
            openFileDialog.FilterIndex = 1;

            //Halt further execution until the user has selected a file, then store details about it in a DialogResult instance
            DialogResult result = openFileDialog.ShowDialog();

            //If the user selected a .ch8, reset the CPU to its default values and load the ROM into memory
            if(result == DialogResult.OK)
            {
                myChip.Reset();
                myChip.LoadROM(openFileDialog.FileName);
            }

            //Start the clockTimer that determines FPS and IPS and set the romLoaded flag to true
            clockTimer.Start();     
            romLoaded = true;
        }

        private void glDisplay_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);

            //Initialise the display
            myDisplay.Init();
        }

        private void btnUnstep_Click(object sender, EventArgs e)
        {
            if (stepMode)
            {
                stepMode = false;
                stopped = false;
            }
        }

        #region Debug Display toggle
        /// <summary>
        /// Allow the user to enable or disable the debugging feature
        /// </summary>
        private void debuggerToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debuggerToggleToolStripMenuItem.Checked = !debuggerToggleToolStripMenuItem.Checked;
            showDebugger = debuggerToggleToolStripMenuItem.Checked;

            if(showDebugger)
            {
                this.Size = new Size(833, 329);
            }
            else
            {
                this.Size = new Size(458, 329);
            }
        }
        #endregion

        #region Clock Speed Setters
        private void SetClockSpeed(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            clockSpeed = float.Parse(t.Tag.ToString());
            if (lastMultiplierChecked != null)
                clockSpeed *= int.Parse(lastMultiplierChecked.Tag.ToString());
            x10ToolStripMenuItem.Enabled = true;
            x100ToolStripMenuItem.Enabled = true;
            lastSpeedChecked.Checked = false;
            t.Checked = true;
            lastSpeedChecked = t;
        }

        private void MulClockSpeed(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            int mul = int.Parse(t.Tag.ToString());

            if (t.Checked)
            {
                clockSpeed /= mul;
            }
            else
            {
                if (lastMultiplierChecked != null)
                    clockSpeed /= int.Parse(lastMultiplierChecked.Tag.ToString());
                clockSpeed *= mul;
            }

            t.Checked = !t.Checked;
            lastMultiplierChecked = t;
        }

        private void UnlimitedClockSpeed(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;

            if(t.Checked)
            {
                clockSpeed = 500;
                lastSpeedChecked = khz5ToolStripMenuItem;
                khz5ToolStripMenuItem.Checked = true;
                x10ToolStripMenuItem.Enabled = true;
                x100ToolStripMenuItem.Enabled = true;
            }
            else
            {
                clockSpeed = -1;
                lastSpeedChecked.Checked = false;
                x10ToolStripMenuItem.Enabled = false;
                x100ToolStripMenuItem.Enabled = false;
                if (lastMultiplierChecked != null)
                {
                    lastMultiplierChecked.Checked = false;
                    lastMultiplierChecked = null;
                }
                lastSpeedChecked = t;
            }
            t.Checked = !t.Checked;
        }

        #endregion

        #region Compile/Decompile Logic
        private void decompileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Initialise a dialogue which allows the user to select a .ch8 ROM file to decompile
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chip-8 ROM (.ch8)|*.ch8";
            openFileDialog.FilterIndex = 1;

            //Halt further execution until the user has selected a file, then store details about it in a DialogResult instance
            DialogResult result = openFileDialog.ShowDialog();

            //If the user selected a .ch8 file, attempt to decompile it
            if (result == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog.FileName);
                Compiler.Decompile(openFileDialog.FileName, openFileDialog.FileName.Split('.')[0] + " code.txt");
            }
        }
        #endregion
    }
}
