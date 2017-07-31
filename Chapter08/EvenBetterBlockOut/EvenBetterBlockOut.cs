using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvenBetterBlockOut
{
    class EvenBetterBlockOut : Form,ICaptureLossNotify
    {
        private bool bBlocking, bValidBox;
        private Point ptBeg, ptEnd;
        private Rectangle rectBox;

        public static void Main()
        {
            Application.Run(new EvenBetterBlockOut());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public EvenBetterBlockOut()
        {
            Text = "Even Better Blockout";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            CaptureLossNotifyWindow win=new CaptureLossNotifyWindow();
            win.control = this;
            win.AssignHandle(Handle);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001B')
            {
                Capture = false;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ptBeg = ptEnd = new Point(e.X, e.Y);
                Graphics grfx = CreateGraphics();
                grfx.DrawRectangle(new Pen(ForeColor), Rect(ptBeg, ptEnd));
                grfx.Dispose();
                bBlocking = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs mea)
        {
            if (bBlocking)
            {
                Graphics grfx = CreateGraphics();
                grfx.DrawRectangle(new Pen(BackColor), Rect(ptBeg, ptEnd));
                ptEnd = new Point(mea.X, mea.Y);
                grfx.DrawRectangle(new Pen(ForeColor), Rect(ptBeg, ptEnd));
                grfx.Dispose();
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            if (bBlocking)
            {
                Graphics grfx = CreateGraphics();
                rectBox = Rect(ptBeg, new Point(mea.X, mea.Y));
                grfx.DrawRectangle(new Pen(BackColor), rectBox);
                grfx.Dispose();

                bBlocking = false;
                bValidBox = true;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            if (bValidBox)
            {
                grfx.FillRectangle(new SolidBrush(ForeColor), rectBox);
            }
            if (bBlocking)
            {
                grfx.DrawRectangle(new Pen(ForeColor), Rect(ptBeg, ptEnd));
            }
        }

        Rectangle Rect(Point ptFirst, Point ptSecond)
        {
            return new Rectangle(Math.Min(ptFirst.X, ptSecond.X), Math.Min(ptFirst.Y, ptSecond.Y),
                Math.Abs(ptFirst.X - ptSecond.X), Math.Abs(ptFirst.Y - ptSecond.Y));
        }

        public void OnLostCapture()
        {
            if (bBlocking)
            {
                Graphics grfx = CreateGraphics();
                grfx.DrawRectangle(new Pen(BackColor),Rect(ptBeg,ptEnd) );
                grfx.Dispose();
                bBlocking = false;
                Invalidate();
            }
        }
    }
}
