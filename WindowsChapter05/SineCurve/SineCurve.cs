using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace SineCurve
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class SineCurve:PrintableForm.PrintableForm
    {
        public new static void Main()
        {
            Application.Run(new SineCurve());
        }

        public SineCurve()
        {
            Text = "Sine Curve";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            PointF[] aptf = new PointF[cx];
            for (int i = 0; i < cx; i++)
            {
                aptf[i].X = i;
                aptf[i].Y = ((float)cy / 2) * (1 - (float) Math.Sin(i * 2 * Math.PI / (cx - 1)));
            }
            grfx.DrawLines(new Pen(clr),aptf );
        }
    }
}
