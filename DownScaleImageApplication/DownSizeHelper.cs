using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DownScaleImageApplication
{
    internal class DownSizeHelper
    {
        private static object lockToObject = new object();
        public static Bitmap downSize(Bitmap image, int resizeScale)
        {
            float originalWidth = image.Width;
            float originalHeight = image.Height;
            MyBitmap originData = LockBits(image);
            double resizeScalling = (double)resizeScale / 100;
            double nWidth = (int)(image.Width * resizeScalling);
            double nHeight = (int)(image.Height * resizeScalling);
            if (nHeight < nHeight)
            {
                double swap = nHeight;
                nHeight = nWidth;
                nWidth = swap;
            }
            Bitmap NNBitmap = new Bitmap((int)nWidth, (int)nHeight);
            MyBitmap NNBitmapData = LockBits(NNBitmap);
            float scaleX = (float)originalWidth / (float)nWidth;
            float scaleY = (float)originalHeight / (float)nHeight;
            for (int y = 0; y < nHeight; y++)
            {
                for (int x = 0; x < nWidth; x++)
                {
                    int sourceX = (int)(x * scaleX);
                    int sourceY = (int)(y * scaleY);
                    Color color = GetPixel(sourceX, sourceY, image, originData);
                    SetPixel(x, y, color, NNBitmap, NNBitmapData);
                }
            }
            UnlockBits(image, originData);
            UnlockBits(NNBitmap, NNBitmapData);
            return NNBitmap;
        }

        public static Bitmap downSizeParallel(Bitmap image, int scalingFactor)
        {
            float originalWidth = image.Width;
            float originalHeight = image.Height;
            MyBitmap orgImgData = LockBits(image);
            double scalling = (double)scalingFactor / 100;
            double nWidth = (int)(image.Width * scalling);
            double nHeight = (int)(image.Height * scalling);
            Bitmap NNBitmap = new Bitmap((int)nWidth, (int)nHeight);
            MyBitmap NNBitmapData = LockBits(NNBitmap);
            float scaleX = (float)originalWidth / (float)nWidth;
            float scaleY = (float)originalHeight / (float)nHeight;
            if (nHeight < nHeight)
            {
                double swap = nHeight;
                nHeight = nWidth;
                nWidth = swap;
            }
            Parallel.For(0, (int)nHeight, y =>
            {
                for (int x = 0; x < nWidth; x++)
                {
                    int sourceX = (int)(x * scaleX);
                    int sourceY = (int)(y * scaleY);
                    Color color;
                    lock (lockToObject)
                    {
                        color = GetPixel(sourceX, sourceY, image, orgImgData);
                    }
                    lock (lockToObject)
                    {
                        SetPixel(x, y, color, NNBitmap, NNBitmapData);
                    }
                }
            });
            UnlockBits(image, orgImgData);
            UnlockBits(NNBitmap, NNBitmapData);
            return NNBitmap;
        }

        private static MyBitmap LockBits(Bitmap bitmap)
        {
            int Width = bitmap.Width;
            int Height = bitmap.Height;
            int PixelCount = Width * Height;
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            int Depth = Bitmap.GetPixelFormatSize(bitmap.PixelFormat);
            if (Depth != 8 && Depth != 24 && Depth != 32)
            {
                throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
            }
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int step = Depth / 8;
            byte[] Pixels = new byte[PixelCount * step];
            IntPtr Iptr = bitmapData.Scan0;
            Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            return new MyBitmap(bitmapData, Pixels, Depth, Iptr);
        }
        private static void UnlockBits(Bitmap bitmap, MyBitmap myBitmap)
        {
            Marshal.Copy(myBitmap.PixelsOfBitmap, 0, myBitmap.Iptr, myBitmap.PixelsOfBitmap.Length);
            bitmap.UnlockBits(myBitmap.BitmapData);
        }

        private static Color GetPixel(int x, int y, Bitmap bitmap, MyBitmap myBitmap)
        {
            Color colorToGet = Color.Empty;
            int colorCount = myBitmap.Depth / 8;
            int i = ((y * bitmap.Width) + x) * colorCount;
            if (i > myBitmap.PixelsOfBitmap.Length - colorCount)
                throw new IndexOutOfRangeException();
            if (myBitmap.Depth == 32)
            {
                byte b = myBitmap.PixelsOfBitmap[i];
                byte g = myBitmap.PixelsOfBitmap[i + 1];
                byte r = myBitmap.PixelsOfBitmap[i + 2];
                byte a = myBitmap.PixelsOfBitmap[i + 3];
                colorToGet = Color.FromArgb(a, r, g, b);
            }
            if (myBitmap.Depth == 24)
            {
                byte b = myBitmap.PixelsOfBitmap[i];
                byte g = myBitmap.PixelsOfBitmap[i + 1];
                byte r = myBitmap.PixelsOfBitmap[i + 2];
                colorToGet = Color.FromArgb(r, g, b);
            }
            if (myBitmap.Depth == 8)
            {
                byte c = myBitmap.PixelsOfBitmap[i];
                colorToGet = Color.FromArgb(c, c, c);
            }
            return colorToGet;
        }

        private static void SetPixel(int x, int y, Color color, Bitmap bitmap, MyBitmap myBitmap)
        {
            int cCount = myBitmap.Depth / 8;
            int i = ((y * bitmap.Width) + x) * cCount;

            if (myBitmap.Depth == 32)
            {
                myBitmap.PixelsOfBitmap[i] = color.B;
                myBitmap.PixelsOfBitmap[i + 1] = color.G;
                myBitmap.PixelsOfBitmap[i + 2] = color.R;
                myBitmap.PixelsOfBitmap[i + 3] = color.A;
            }
            if (myBitmap.Depth == 24)
            {
                myBitmap.PixelsOfBitmap[i] = color.B;
                myBitmap.PixelsOfBitmap[i + 1] = color.G;
                myBitmap.PixelsOfBitmap[i + 2] = color.R;
            }
            if (myBitmap.Depth == 8)
            {
                myBitmap.PixelsOfBitmap[i] = color.B;
            }
        }
    }
}
