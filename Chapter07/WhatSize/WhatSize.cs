﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HundredPixelsSquare;

namespace WhatSize
{
    public class WhatSize:PrintableForm
    {
        public static void Main()
        {
            Application.Run(new WhatSize());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public WhatSize()
        {
            Text = "What Size?";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            Brush brush = new SolidBrush(clr);
            int y = 0;
            DoIt(grfx,brush,ref y,GraphicsUnit.Pixel);
            DoIt(grfx, brush, ref y, GraphicsUnit.Display);
            DoIt(grfx, brush, ref y, GraphicsUnit.Document);
            DoIt(grfx, brush, ref y, GraphicsUnit.Inch);
            DoIt(grfx, brush, ref y, GraphicsUnit.Millimeter);
            DoIt(grfx, brush, ref y, GraphicsUnit.Point);
        }


        void DoIt(Graphics grfx, Brush brush, ref int y, GraphicsUnit gu)
        {
            GraphicsState gs = grfx.Save();
            grfx.PageUnit = gu;
            grfx.PageScale = 1;
            SizeF sizef = grfx.VisibleClipBounds.Size;
            grfx.Restore(gs);
            grfx.DrawString(gu + ":" + sizef, Font, brush, 0, y);
            y += (int) Math.Ceiling(Font.GetHeight());
        }
    }
}
