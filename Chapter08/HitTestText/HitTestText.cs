using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace HitTestText
{
    class HitTestText:TypeAway.TypeAway
    {
        public new static void Main()
        {
            Application.Run(new HitTestText());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public HitTestText()
        {
            Text += " with Hit-Testing";
            Cursor = Cursors.IBeam;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (StrText.Length == 0)
            {
                return;
            }
            Graphics grfx = CreateGraphics();
            float xPrev = 0;
            int i;
            for (i = 0; i < StrText.Length; i++)
            {
                SizeF sizef = grfx.MeasureString(StrText.Substring(0, i + 1),
                    Font, PointF.Empty, StringFormat.GenericTypographic);
                if (Math.Abs(e.X - xPrev) < Math.Abs(e.X - sizef.Width))
                {
                    break;
                }
            }
            Insert = i;
            grfx.Dispose();
            PositionCaret();
        }
    }
}
