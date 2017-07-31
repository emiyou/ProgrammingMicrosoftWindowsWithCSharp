using System;
using System.Drawing;
using System.Windows.Forms;

namespace CheckerWithChildren
{
    public class CheckerChild:UserControl
    {
        private bool bChecked;

        public CheckerChild()
        {
            ResizeRedraw = true;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            bChecked = !bChecked;
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space:
                    OnClick(EventArgs.Empty);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            Pen pen = new Pen(ForeColor);
            grfx.DrawRectangle(pen, ClientRectangle);
            if (bChecked)
            {
                grfx.DrawLine(pen, 0, 0, ClientSize.Width, ClientSize.Height);
                grfx.DrawLine(pen, 0, ClientSize.Height, ClientSize.Width,0 );
            }
        }
    }
}
