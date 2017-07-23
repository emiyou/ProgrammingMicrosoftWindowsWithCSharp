using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace OutlineClientRectangle
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class OutlineClientRectangle:PrintableForm.PrintableForm
    {
        public new static void Main()
        {
            Application.Run(new OutlineClientRectangle());
        }

        public OutlineClientRectangle()
        {
            Text = "OutlineClientRectangle";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            grfx.DrawRectangle(Pens.Red, 0, 0, cx - 1, cy - 1);
        }
    }
}
