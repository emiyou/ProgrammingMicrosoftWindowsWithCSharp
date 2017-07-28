using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using HundredPixelsSquare;

namespace TryOneInchEllipse
{
    class TryOneInchEllipse:PrintableForm
    {
        public static void Main()
        {
            Application.Run(new TryOneInchEllipse());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public TryOneInchEllipse()
        {
            Text = "Try One-Inch Ellipse";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            grfx.DrawEllipse(new Pen(clr), 0, 0, grfx.DpiX, grfx.DpiY);
        }
    }
}
