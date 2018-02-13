using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;

namespace Chipster
{
    /// <summary>
    /// A class used to display the GFX array of a CPU instance in OpenTK
    /// </summary>
    class Display : IDisplay
    {
        public int PixelWidth { get; private set; }
        public int PixelHeight { get; private set; }

        private IntPtr screenTexPtr;
        private int screenWidth;
        private int screenHeight;
        private CPU chip;

        public Display(CPU cpu, IntPtr screenTexPtr, int sWidth, int sHeight, int pixelWidth, int pixelHeight)
        {
            chip = cpu;
            this.screenTexPtr = screenTexPtr;
            screenWidth = sWidth;
            screenHeight = sHeight;
            PixelWidth = pixelWidth;
            PixelHeight = pixelHeight;
        }

        public void Init()
        {
            //Initialise the viewport and enable required flags
            GL.Viewport(0, 0, screenWidth, screenHeight);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Color4.MediumPurple);

            //Set the model matrix
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0, screenWidth, 0, screenHeight, -1, 1);

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
            Marshal.Copy(chip.GFX, 0, screenTexPtr, chip.GFX.Length);

            //Set the current texture to be equal to the GFX byte array
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, PixelWidth, PixelHeight, 0, PixelFormat.Luminance, PixelType.UnsignedByte, screenTexPtr);

            //Draw the 'screen' quad and apply the texture to it
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0, screenHeight, 0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(screenWidth, 0, 0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(screenWidth, screenHeight, 0);
            GL.End();
        }
    }
}
