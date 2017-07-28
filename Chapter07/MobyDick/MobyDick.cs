using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using HundredPixelsSquare;

namespace MobyDick
{
    class MobyDick:PrintableForm
    {
        public static void Main()
        {
            Application.Run(new MobyDick());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public MobyDick()
        {
            Text = "Moby Dick";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            grfx.RotateTransform(45);
            //grfx.TranslateTransform(cx / 2, cy / 2);
            grfx.DrawString("Call me ishmael. Some years ago \x2014 never"+
                "mind how long precisely \x2014having little"+
                "Hello,fine,thank you, and you?"+"My Name is Lileilei" +
                            "What's you name",Font,new SolidBrush(clr),new RectangleF(0,0,cx,cy) );
            
        }
    }
}
