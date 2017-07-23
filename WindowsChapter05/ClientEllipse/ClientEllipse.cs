using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace ClientEllipse
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class ClientEllipse:PrintableForm.PrintableForm
    {
        public new static void Main()
        {
            Application.Run(new ClientEllipse());
        }

        public ClientEllipse()
        {
            Text = "ClientEllipse";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            grfx.DrawEllipse(new Pen(clr),0,0,cx-1,cy-1);
        }
    }
}
