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

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardTopDownDib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            pictureBox.Image = new Bitmap(typeof(Program), "A_Lion.jpg");
        }

        private void CopyImageToClipboardButton_Click(object sender, EventArgs e)
        {
            Bitmap image = pictureBox.Image as Bitmap;

            if (image != null)
            {
                PlaceDibOnClipboard(image);
            }
        }

        private static void PlaceDibOnClipboard(Bitmap image)
        {
            byte[] dibBytes = CreateDib(image);

            if (dibBytes != null)
            {
                Clipboard.Clear();
                Clipboard.SetData(DataFormats.Dib, new MemoryStream(dibBytes));
            }
        }

        private static unsafe byte[] CreateDib(Bitmap image)
        {
            byte[] dibBytes = null;

            byte[] imageData = GetImageDataBytes(image);

            if (imageData != null)
            {
                const int ColorTableSize = 12;

                dibBytes = new byte[NativeStructs.BITMAPINFOHEADER.SizeOf + ColorTableSize + imageData.Length];

                fixed (byte* ptr = &dibBytes[0])
                {
                    NativeStructs.BITMAPINFOHEADER* header = (NativeStructs.BITMAPINFOHEADER*)ptr;

                    // Write the header.
                    header->biSize = (uint)NativeStructs.BITMAPINFOHEADER.SizeOf;
                    header->biWidth = image.Width;
                    header->biHeight = -image.Height;
                    header->biPlanes = 1;
                    header->biBitCount = 32;
                    header->biCompression = NativeConstants.BI_BITFIELDS;
                    header->biSizeImage = (uint)imageData.Length;

                    // Write the color masks.
                    IntPtr colorMaskOffset = new IntPtr(ptr + NativeStructs.BITMAPINFOHEADER.SizeOf);

                    Marshal.WriteInt32(colorMaskOffset, 0, 0x00FF0000);
                    Marshal.WriteInt32(colorMaskOffset, 4, 0x0000FF00);
                    Marshal.WriteInt32(colorMaskOffset, 8, 0x000000FF);
                }

                Buffer.BlockCopy(imageData, 0, dibBytes, NativeStructs.BITMAPINFOHEADER.SizeOf + ColorTableSize, imageData.Length);
            }

            return dibBytes;
        }

        private static byte[] GetImageDataBytes(Bitmap image)
        {
            byte[] imageData = null;

            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            try
            {
                imageData = new byte[data.Stride * data.Height];
                Marshal.Copy(data.Scan0, imageData, 0, imageData.Length);
            }
            finally
            {
                image.UnlockBits(data);
            }

            return imageData;
        }
    }
}
