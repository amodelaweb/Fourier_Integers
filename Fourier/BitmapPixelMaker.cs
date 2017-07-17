using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fourier
{
  
    public class BitmapPixelMaker
    {
       
        private int Width, Height;
        
        private byte[] Pixels;
        
        private int Stride;

        public BitmapPixelMaker(int width, int height)
        {
          
            Width = width;
            Height = height;

           
            Pixels = new byte[width * height * 4];
            
            Stride = width * 4;
        }

        
        public void GetPixel(int x, int y, out byte red, out byte green, out byte blue, out byte alpha)
        {
            int index = y * Stride + x * 4;
            blue = Pixels[index++];
            green = Pixels[index++];
            red = Pixels[index++];
            alpha = Pixels[index];
        }
        public byte GetBlue(int x, int y)
        {
            return Pixels[y * Stride + x * 4];
        }
        public byte GetGreen(int x, int y)
        {
            return Pixels[y * Stride + x * 4 + 1];
        }
        public byte GetRed(int x, int y)
        {
            return Pixels[y * Stride + x * 4 + 2];
        }
        public byte GetAlpha(int x, int y)
        {
            return Pixels[y * Stride + x * 4 + 3];
        }

        public void SetPixel(int x, int y, byte red, byte green, byte blue, byte alpha)
        {
            int index = y * Stride + x * 4;
            Pixels[index++] = blue;
            Pixels[index++] = green;
            Pixels[index++] = red;
            Pixels[index++] = alpha;
        }
        public void SetBlue(int x, int y, byte blue)
        {
            Pixels[y * Stride + x * 4] = blue;
        }
        public void SetGreen(int x, int y, byte green)
        {
            Pixels[y * Stride + x * 4 + 1] = green;
        }
        public void SetRed(int x, int y, byte red)
        {
            Pixels[y * Stride + x * 4 + 2] = red;
        }
        public void SetAlpha(int x, int y, byte alpha)
        {
            Pixels[y * Stride + x * 4 + 3] = alpha;
        }


        public void SetColor(byte red, byte green, byte blue, byte alpha)
        {
            int num_bytes = Width * Height * 4;
            int index = 0;
            while (index < num_bytes)
            {
                Pixels[index++] = blue;
                Pixels[index++] = green;
                Pixels[index++] = red;
                Pixels[index++] = alpha;
            }
        }


        public void SetColor(byte red, byte green, byte blue)
        {
            SetColor(red, green, blue, 255);
        }
        public WriteableBitmap MakeBitmap(double dpiX, double dpiY)
        {

            WriteableBitmap wbitmap = new WriteableBitmap(
                Width, Height, dpiX, dpiY,
                PixelFormats.Bgra32, null);
            Int32Rect rect = new Int32Rect(0, 0, Width, Height);
            wbitmap.WritePixels(rect, Pixels, Stride, 0);
            return wbitmap;
        }
    }
}
