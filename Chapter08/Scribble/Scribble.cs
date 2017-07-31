using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Scribble
{
    class Scribble:Form
    {
        private bool bTracking;
        private Point ptLast;

        public static void Main()
        {
            Application.Run(new Scribble());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Scribble()
        {
            Text = "Scribble";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            //ResizeRedraw = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ptLast = new Point(e.X, e.Y);
            bTracking = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!bTracking)
            {
                return;
            }
            Point ptNew = new Point(e.X, e.Y);
            Graphics grfx = CreateGraphics();
            grfx.DrawLine(new Pen(ForeColor),ptLast,ptNew );
            grfx.Dispose();
            ptLast = ptNew;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            bTracking = false;
        }
    }
}
