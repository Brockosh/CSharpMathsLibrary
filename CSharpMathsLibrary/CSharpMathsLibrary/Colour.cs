using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public struct Colour
    {
        public UInt32 colour;
        public byte red
        {
            get { return (byte)(colour >> 24 & 0xff); }
            set { colour = (colour & 0x00ffffff) | ((UInt32)value << 24); }
        }

        public byte green
        {
            get { return (byte)(colour >> 16 & 0xff); }
            set { colour = (colour & 0xff00ffff) | ((UInt32)value << 16); }
        }

        public byte blue
        {
            get { return (byte)(colour >> 8 & 0xff); }
            set { colour = (colour & 0xffff00ff) | ((UInt32)value << 8); }
        }

        public byte alpha
        {
            get { return (byte)(colour & 0xff); }
            set { colour = (colour & 0xffffff00) | (UInt32)value; }
        }

        public Colour(byte r, byte g, byte b, byte a)
        {
            colour = ((UInt32)r << 24) | ((UInt32)g << 16) | ((UInt32)b << 8) | a;
        }
    }
}
