﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oto2dvcfg
{
    public class BaseTextBox : TextBox
    {
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //private static extern IntPtr LoadLibrary(string lpFileName);
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams prams = base.CreateParams;
        //        if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
        //        {
        //            prams.ExStyle |= 0x020; // transparent 
        //            prams.ClassName = "RICHEDIT50W";
        //        }
        //        return prams;
        //    }
        //}

        public BaseTextBox()
        {
            //InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            // | ControlStyles.UserPaint
        }
    }
}
