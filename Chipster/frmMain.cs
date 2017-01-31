using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Diagnostics;

namespace Chipster
{
    public partial class frmMain : Form
    {
        CPU myChip;
        Display myDisplay;

        TextBox[] registerDisplays = new TextBox[16];
        bool showHex;
        bool romLoaded;
        bool stopped;
        bool stepMode;

        Stopwatch timer;
        int cyclesThisSecond;
        int framesThisSecond;

        IntPtr screenPixelsPtr;

        public frmMain()
        {
            InitializeComponent();
            Application.Idle += HandleApplicationIdle;
            myChip = new CPU(new Memory(4096));
            screenPixelsPtr = Marshal.AllocHGlobal(myChip.GFX.Length);
            myDisplay = new Display(myChip, screenPixelsPtr, ClientSize.Width, ClientSize.Height);
            timer = new Stopwatch();
            showHex = false;
            romLoaded = false;                      
        }

        /// <summary>
        /// Main loop for chip8 instance
        /// </summary>
        public void mainLoop()
        {
            UpdateInfo();

            if (stopped)
                return;

            myChip.EmulateCycle();
            cyclesThisSecond++;

            if (myChip.DrawFlag)
                glDisplay.Invalidate();

            myChip.SetKeys();

            if(stepMode || myChip.UnknownOpcode)
                stopped = true;
        }

        /// <summary>
        /// Update debug info shown to the side of the screen, containing information about various registers.
        /// </summary>
        public void UpdateInfo()
        {
            txtProgramCounter.Text = showHex? HexHelper.UshortToHex(myChip.PC): myChip.PC.ToString();
            txtInstruction.Text = showHex? HexHelper.UshortToHex(myChip.Opcode): myChip.Opcode.ToString();
            txtAdress.Text = showHex? HexHelper.UshortToHex(myChip.Index): myChip.Index.ToString();
            txtMessage.Text = myChip.UnknownOpcode ? "Unknown Opcode" : "None";
            txtSound.Text = myChip.Beep ? "BEEP!" : "-";

            for(int i = 0; i < 16; i++)
            {
                registerDisplays[i].Text = showHex? HexHelper.ByteToHex(myChip.Registers[i]).ToString() : myChip.Registers[i].ToString();
            }

            if (timer.ElapsedMilliseconds >= 1000)
            {
                txtFPS.Text = framesThisSecond.ToString();
                txtIPS.Text = cyclesThisSecond.ToString();
                cyclesThisSecond = 0;
                framesThisSecond = 0;
                timer.Restart();
            }
        }

        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while(IsApplicationIdle() && romLoaded)
            {
                mainLoop();
            }
        }

        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
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

        /// <summary>
        /// Populate the register displays array with the register text boxes displayed on the form
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            glDisplay.Paint += new PaintEventHandler(glDisplay_Paint);
            registerDisplays = new TextBox[16] { txtR0, txtR1, txtR2, txtR3, txtR4, txtR5, txtR6, txtR7, txtR8, txtR9, txtRA, txtRB, txtRC, txtRD, txtRE, txtRF };
        }

        /// <summary>
        /// Draw the current gfx array to the screen
        /// </summary>
        void glDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (!romLoaded || !myChip.DrawFlag)
                return;

            myDisplay.Draw();
            glDisplay.SwapBuffers();

            framesThisSecond++;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chip-8 ROM (.ch8)|*.ch8";
            openFileDialog.FilterIndex = 1;

            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                myChip.Reset();
                myChip.LoadROM(openFileDialog.FileName);
            }

            timer.Start();
            romLoaded = true;
        }

        private void glDisplay_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);
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
    }
}
