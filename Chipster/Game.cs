using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Chipster
{
    class Game : GameWindow
    {
        private float xPos = 0;
        IntPtr screenPixelsPtr;
        byte[] screenPixels;

        public Game()
            : base(256, 128, GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            screenPixels = new byte[2 * 2 * 3] { 255, 0, 0, 0, 255, 0, 0, 0, 255, 255, 0, 0 };

            screenPixelsPtr = Marshal.AllocHGlobal(screenPixels.Length);
            Marshal.Copy(screenPixels, 0, screenPixelsPtr, screenPixels.Length);

            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, 64, 32);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (screenPixels[0] > 0)
                screenPixels[0]--;
            else
                screenPixels[0] = 255;

            screenPixelsPtr = Marshal.AllocHGlobal(screenPixels.Length);
            Marshal.Copy(screenPixels, 0, screenPixelsPtr, screenPixels.Length);

            if (Keyboard[Key.Escape])
                Exit();
            else if (Keyboard[Key.D])
                xPos += 0.01f;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadIdentity();

            GL.Ortho(0, 256, 0, 128, -1, 1);
            GL.Viewport(0, 0, 256, 128);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadIdentity();

            GL.ClearColor(Color4.CornflowerBlue);

            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (int)TextureEnvMode.Decal);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, 2, 2, 0, PixelFormat.Rgb, PixelType.UnsignedByte, screenPixelsPtr);
            //GL.frame
            //GL.Begin(PrimitiveType.Points);
            //GL.DrawPixels(256, 128, PixelFormat.Rgb, PixelType.Byte, screenPixelsPtr);
            //GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(-1.0f + xPos, -1.0f, 4.0f);
            //GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex3(1.0f + xPos, -1.0f, 4.0f);
            //GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(0.0f + xPos, 1.0f, 4.0f);

            //GL.BindTexture(TextureTarget.Texture2D, 0);


            //GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(0.0, 128, 0.0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(0, 0, 0.0);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(256, 0, 0.0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(256, 128, 0.0);

            GL.End();

            SwapBuffers();
        }
    }
}
