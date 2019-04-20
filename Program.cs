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
using System.Windows.Forms;

namespace ClipboardTopDownDib
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
