using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using HundredPixelsSquare;

namespace TenCentimeterRulerAuto
{
    class TenCentimeterRulerAuto:PrintableForm
    {
        public static void Main()
        {
            Application.Run(new TenCentimeterRulerAuto());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public TenCentimeterRulerAuto()
        {
            Text = "Ten-Centimeter Ruler(Auto)";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            Pen pen = new Pen(clr, 0.25f);
            Brush brush = new SolidBrush(clr);
            const int xOffset = 10;
            const int yOffset = 10;
            grfx.PageUnit=GraphicsUnit.Millimeter;
            grfx.PageScale = 1;
            grfx.DrawRectangle(pen, xOffset, yOffset, 100, 10);
            StringFormat strfmt = new StringFormat();
            strfmt.Alignment = StringAlignment.Center;
            for (int i = 1; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    grfx.DrawLine(pen,new PointF(xOffset+i,yOffset),new PointF(xOffset+i,yOffset+5));
                    grfx.DrawString((i / 10).ToString(), Font, brush, xOffset + i, yOffset + 5);
                }else if (i % 5 == 0)
                {
                    grfx.DrawLine(pen, new PointF(xOffset + i, yOffset), new PointF(xOffset + i, yOffset + 3.3f));
                }
                else
                {
                    grfx.DrawLine(pen, new PointF(xOffset + i, yOffset), new PointF(xOffset + i, yOffset + 2.5f));
                }
            }
        }
    }
}
