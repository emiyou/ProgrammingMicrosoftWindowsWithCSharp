using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace HundredPixelsSquare
{
    public class HundredPixelsSquare:PrintableForm
    {
        public static void Main()
        {
            Application.Run(new HundredPixelsSquare());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public HundredPixelsSquare()
        {
            Text = "Hundred Pixels Square";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            grfx.FillRectangle(new SolidBrush(clr),100,100,100,100);
        }
    }
}
