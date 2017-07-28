using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using HundredPixelsSquare;

namespace DotsPerInch
{
    class DotsPerInch:PrintableForm
    {
        public static void Main()
        {
            Application.Run(new DotsPerInch());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public DotsPerInch()
        {
            Text = "Dots Per Inch";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            grfx.DrawString(string.Format("DpiX={0}\nDpiY={1}",grfx.DpiX,grfx.DpiY),Font,new SolidBrush(clr),0,0);
        }
    }
}
