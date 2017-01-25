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
//using SDL2;

namespace Chipster
{
    public partial class frmMain : Form
    {
        Chip8 myChip = new Chip8();
        Bitmap screen = new Bitmap(64, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        TextBox[] registerDisplays = new TextBox[16];
        bool showHex;
        bool romLoaded;
        bool stopped;

        public frmMain()
        {
            InitializeComponent();
            Application.Idle += HandleApplicationIdle;
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

            if (myChip.DrawFlag)
                DrawGFX();

            myChip.SetKeys();

            if(myChip.UnknownOpcode)
                stopped = true;
        }

        /// <summary>
        /// Update the screen display each frame
        /// </summary>
        public void DrawGFX()
        {
            for (int y = 0; y < screen.Height; y++)
            {
                for (int x = 0; x < screen.Width; x++)
                {
                    screen.SetPixel(x, y, myChip.GFX[x + (y * 64)]? Color.FromArgb(33,85,107) : Color.FromArgb(70,165,206));
                    picDisplay.Image = screen;
                }
            }
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
            //IntPtr win = SDL.SDL_CreateWindow("Jesus FUCKING CHRIST", 100, 100, 640,320, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            //IntPtr ren = SDL.SDL_CreateRenderer(win, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
            //SDL.SDL_RenderDrawLine(ren, 5, 5, 55, 55);

            //if(win == null || ren == null)
            //{
            //    SDL.SDL_Quit();
            //}

            registerDisplays = new TextBox[16] { txtR0, txtR1, txtR2, txtR3, txtR4, txtR5, txtR6, txtR7, txtR8, txtR9, txtRA, txtRB, txtRC, txtRD, txtRE, txtRF };
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
                myChip.Initialize();
                myChip.LoadGame(openFileDialog.FileName);
            }

            romLoaded = true;
        }

        private void mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
