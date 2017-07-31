using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace Checker
{
    public class Checker:Form
    {
        protected const int XNum = 5;
        protected const int YNum = 4;
        protected bool[,] AbChecked=new bool[YNum,XNum];
        protected int CxBlock, CyBlock;

        public static void Main()
        {
            Application.Run(new Checker());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Checker()
        {
            Text = "Checker";
            ForeColor = SystemColors.WindowText;
            BackColor = SystemColors.Window;
            ResizeRedraw = true;
            OnResize(EventArgs.Empty);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CxBlock = ClientSize.Width / XNum;
            CyBlock = ClientSize.Height / YNum;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            int x = e.X / CxBlock;
            int y = e.Y / CyBlock;
            if (x < XNum && y < YNum)
            {
                AbChecked[y, x] = !AbChecked[y, x];
                Invalidate(new Rectangle(x * CxBlock, y * CyBlock, CxBlock, CyBlock));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            Pen pen = new Pen(ForeColor);
            for (int y = 0; y < YNum; y++)
            {
                for (int x = 0; x < XNum; x++)
                {
                    grfx.DrawRectangle(pen, x * CxBlock, y * CyBlock, CxBlock, CyBlock);
                    if (AbChecked[y, x])
                    {
                        grfx.DrawLine(pen, x * CxBlock, y * CyBlock, (x + 1) * CxBlock, (y + 1) * CyBlock);
                        grfx.DrawLine(pen, x * CxBlock, (y + 1) * CyBlock, (x + 1) * CxBlock, y * CyBlock);
                    }
                }
            }
        }
    }
}
