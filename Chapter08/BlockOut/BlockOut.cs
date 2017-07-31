using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace BlockOut
{
    class BlockOut:Form
    {
        private bool bBlocking, bValidBox;
        private Point ptBeg, ptEnd;
        private Rectangle rectBox;

        public static void Main()
        {
            Application.Run(new BlockOut());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public BlockOut()
        {
            Text = "Blockout Rectangle with Mouse";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            ResizeRedraw=true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ptBeg = ptEnd = new Point(e.X, e.Y);
                Graphics grfx = CreateGraphics();
                grfx.DrawRectangle(new Pen(ForeColor),Rect(ptBeg,ptEnd) );
                grfx.Dispose();
                bBlocking = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs mea)
        {
            if (bBlocking)
            {
                Graphics grfx = CreateGraphics();
                grfx.DrawRectangle(new Pen(BackColor),Rect(ptBeg,ptEnd) );
                ptEnd = new Point(mea.X, mea.Y);
                grfx.DrawRectangle(new Pen(ForeColor),Rect(ptBeg,ptEnd) );
                //Invalidate();
            }   
        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            if (bBlocking && mea.Button == MouseButtons.Left)
            {
                Graphics grfx = CreateGraphics();
                rectBox = Rect(ptBeg, new Point(mea.X, mea.Y));
                grfx.DrawRectangle(new Pen(ForeColor), rectBox);
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
                grfx.FillRectangle(new SolidBrush(ForeColor),rectBox );
            }
            if (bBlocking)
            {
                grfx.DrawRectangle(new Pen(ForeColor),Rect(ptBeg,ptEnd) );
            }
        }

        Rectangle Rect(Point ptFirst, Point ptSecond)
        {
            return new Rectangle(Math.Min(ptFirst.X, ptSecond.X), Math.Min(ptFirst.Y, ptSecond.Y),
                Math.Abs(ptFirst.X - ptSecond.X), Math.Abs(ptFirst.Y - ptSecond.Y));
        }
    }
}
