using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace PrintableTenCentimeterRuler
{
    class PrintableTenCentimeterRuler:TenCentimeterRuler.TenCentimeterRuler
    {
        public new static void Main()
        {
            Application.Run(new PrintableTenCentimeterRuler());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public PrintableTenCentimeterRuler()
        {
            Text = "Pritable" + Text;
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            grfx.PageUnit = GraphicsUnit.Pixel;
            base.DoPage(grfx, clr, cx, cy);
        }
    }
}
