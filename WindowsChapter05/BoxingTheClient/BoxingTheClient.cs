﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace BoxingTheClient
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class BoxingTheClient:PrintableForm.PrintableForm
    {
        public new static void Main()
        {
            Application.Run(new BoxingTheClient());
        }

        public BoxingTheClient()
        {
            Text = "Boxing the client";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            Point[] apt =
            {
                new Point(0, 0),
                new Point(0,cy-1),
                new Point(cx-1,cy-1),
                new Point(cx-1,0),
                new Point(0,0)
            };
            grfx.DrawLines(new Pen(clr),apt );
        }
    }
}
