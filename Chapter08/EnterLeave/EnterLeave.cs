using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EnterLeave
{
    class EnterLeave:Form
    {
        private bool bInside;

        public static void Main()
        {
            Application.Run(new EnterLeave());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public EnterLeave()
        {
            Text = "Enter/Leave";
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            bInside = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            bInside = false;
            Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            Graphics grfx = CreateGraphics();
            grfx.Clear(Color.Red);
            Thread.Sleep(100);
            grfx.Clear(Color.Green);
            grfx.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            grfx.Clear(bInside ? Color.Green : BackColor);
        }
    }
}
