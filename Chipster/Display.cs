using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;

namespace Chipster
{
    /// <summary>
    /// A class used to display the GFX array of a CPU instance in OpenTK
    /// </summary>
    class Display
    {
        public IntPtr ScreenTexPtr { get; private set; }
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }
        public int PixelWidth { get; private set; }
        public int PixelHeight { get; private set; }
        private CPU Chip;

        public Display(CPU cpu, IntPtr screenTexPtr, int screenWidth, int screenHeight, int pixelWidth, int pixelHeight)
        {
            Chip = cpu;
            ScreenTexPtr = screenTexPtr;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            PixelWidth = pixelWidth;
            PixelHeight = pixelHeight;
        }

        public void Init()
        {
            //Initialise the viewport and enable required flags
            GL.Viewport(0, 0, ScreenWidth, ScreenHeight);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Color4.MediumPurple);

            //Set the model matrix
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0, ScreenWidth, 0, ScreenHeight, -1, 1);

            //Get an ID to store the screen texture and swap to it
            int texHandle = GL.GenTexture();
            Console.WriteLine(texHandle.ToString());
            GL.BindTexture(TextureTarget.Texture2D, texHandle);

            //Set the texture settings for the current texture(Screen Texture)
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (int)TextureEnvMode.Decal);

        }

        public void Draw()
        {
            //Clear the screen at the start of each frame
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Copy the current chip GFX array into the assigned space for it in unmanaged memory
            Marshal.Copy(Chip.GFX, 0, ScreenTexPtr, Chip.GFX.Length);

            //Set the current texture to be equal to the GFX byte array
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, PixelWidth, PixelHeight, 0, PixelFormat.Luminance, PixelType.UnsignedByte, ScreenTexPtr);

            //Draw the 'screen' quad and apply the texture to it
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0, ScreenHeight, 0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(ScreenWidth, 0, 0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(ScreenWidth, ScreenHeight, 0);
            GL.End();
        }
    }
}
