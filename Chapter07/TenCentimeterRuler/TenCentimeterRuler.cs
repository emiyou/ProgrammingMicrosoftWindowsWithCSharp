using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using HundredPixelsSquare;

namespace TenCentimeterRuler
{
    public class TenCentimeterRuler:PrintableForm
    {

        public static void Main()
        {
            Application.Run(new TenCentimeterRuler());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public TenCentimeterRuler()
        {
            Text = "Ten-Centimeter Ruler";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            Pen pen = new Pen(clr);
            using (Brush brush = new SolidBrush(clr))
            {
                const int xOffset = 10;
                const int yOffset = 10;
                grfx.DrawPolygon(pen,new[]
                {
                    MMConv(grfx,new PointF(xOffset,yOffset)),
                    MMConv(grfx,new PointF(xOffset+100,yOffset)),
                    MMConv(grfx,new PointF(xOffset+100,yOffset+10)),
                    MMConv(grfx,new PointF(xOffset,yOffset+10))
                });
                StringFormat strfmt = new StringFormat();
                strfmt.Alignment = StringAlignment.Center;
                for (int i = 1; i < 100; i++)
                {
                    if (i % 10 == 0)
                    {
                        grfx.DrawLine(pen,MMConv(grfx,new PointF(xOffset+i,yOffset)),MMConv(grfx,new PointF(xOffset+i,yOffset+5)));
                        grfx.DrawString((i / 10).ToString(), Font, brush, MMConv(grfx, new PointF(xOffset + i, yOffset + 5)));
                    }
                    else if (i % 5 == 0)
                    {
                        grfx.DrawLine(pen, MMConv(grfx, new PointF(xOffset + i, yOffset)),
                            MMConv(grfx, new PointF(xOffset + i, yOffset + 3.3f)));
                    }
                    else
                    {
                        grfx.DrawLine(pen, MMConv(grfx, new PointF(xOffset + i, yOffset)), MMConv(grfx, new PointF(xOffset + i, yOffset + 2.5f)));
                    }
                }
            }
        }

        private PointF MMConv(Graphics grfx, PointF pointf)
        {
            pointf.X *= grfx.DpiX / 25.4f;
            pointf.Y *= grfx.DpiY / 25.4F;
            return pointf;
        }

    }
}
