using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;

namespace Chipster
{
    class Display
    {
        public IntPtr ScreenTexPtr { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        private CPU Chip;

        public Display(CPU c, IntPtr s, int w, int h)
        {
            Chip = c;
            ScreenTexPtr = s;
            Width = w;
            Height = h;
        }

        public void Init()
        {
            //Initialise the viewport and enable required flags
            GL.Viewport(0, 0, Width, Height);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Color4.MediumPurple);

            //Set the model matrix
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0, Width, 0, Height, -1, 1);

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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Marshal.Copy(Chip.GFX, 0, ScreenTexPtr, Chip.GFX.Length);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, 64, 32, 0, PixelFormat.Luminance, PixelType.UnsignedByte, ScreenTexPtr);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(00, Height, 0.0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(00, 00, 0.0);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(100, 00, 0.0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(100, Height, 0.0);
            GL.End();
        }
    }
}
