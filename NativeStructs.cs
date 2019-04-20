////////////////////////////////////////////////////////////////////////////////
//
// clipboard-top-down-dib
//
// This software is provided under the MIT License:
//   Copyright (C) 2019 Nicholas Hayes
//
// See LICENSE.md in the project root for more information.
//
/////////////////////////////////////////////////////////////////////////////////

using System.Runtime.InteropServices;

namespace ClipboardTopDownDib
{
    internal static class NativeStructs
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;

            public static readonly int SizeOf = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
        }
    }
}
