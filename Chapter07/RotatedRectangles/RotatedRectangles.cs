﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HundredPixelsSquare;

namespace RotatedRectangles
{
    class RotatedRectangles:PrintableForm
    {
        public static void Main()
        {
            Application.Run(new RotatedRectangles());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public RotatedRectangles()
        {
            Text = "Rotated Rectangles";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            Pen pen = new Pen(clr);
            grfx.PageUnit=GraphicsUnit.Pixel;
            PointF[] aptf = {(PointF) grfx.VisibleClipBounds.Size};
            grfx.PageUnit=GraphicsUnit.Inch;
            grfx.PageScale = 0.01f;
            grfx.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device,
                aptf);
            grfx.TranslateTransform(aptf[0].X / 2, aptf[0].Y / 2);
            for (int i = 0; i < 36; i++)
            {
                grfx.DrawRectangle(pen, 0, 0, 100, 100);
                grfx.RotateTransform(10);
            }
        }
    }
}
