using System;
using System.Drawing;
using System.Windows.Forms;
using CheckerWithChildren;

namespace CheckerWithChildAndFocus
{
    class CheckerChildWithFocus:CheckerChild
    {
        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Focused)
            {
                e.Graphics.DrawEllipse(new Pen(ForeColor),ClientRectangle );
            }
        }
    }
}
