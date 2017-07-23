using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Spiral
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class Spiral:PrintableForm.PrintableForm
    {
        public new static void Main()
        {
            Application.Run(new Spiral());
        }

        public Spiral()
        {
            Text = "Spiral";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            const int iNumRevs = 20;
            int iNumPoints = iNumRevs * 2 * (cx + cy);
            PointF[] aptf = new PointF[iNumPoints];
            float fAngle, fScale;
            for (int i = 0; i < iNumPoints; i++)
            {
                fAngle = (float) (i * 2 * Math.PI / (((float)iNumPoints) / iNumRevs));
                fScale = 1 - (float) i / iNumPoints;
                aptf[i].X = (float) (((float)cx) / 2 * (1 + fScale * Math.Cos(fAngle)));
                aptf[i].Y = (float)(((float)cy) / 2 * (1 + fScale * Math.Sin(fAngle)));
            }
            grfx.DrawLines(new Pen(clr),aptf );
        }
    }
}
