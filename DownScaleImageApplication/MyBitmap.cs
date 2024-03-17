using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownScaleImageApplication
{
    internal class MyBitmap
    {
        public byte[] PixelsOfBitmap { get; set; }
        public int Depth { get; set; }
        public IntPtr Iptr { get; set; }
        public BitmapData BitmapData { get; set; }
        public MyBitmap(BitmapData bitmapData, byte[] pixels, int depth, IntPtr iptr)
        {
            BitmapData = bitmapData;
            PixelsOfBitmap = pixels;
            Depth = depth;
            Iptr = iptr;
        }
    }
}
