using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace MouseConnect
{
    public class MouseConnect:Form
    {
        private const int MaxPoints = 1000;
        private int iNumPoints;
        private Point[] apoint = new Point[MaxPoints];

        public static void Main()
        {
            Application.Run(new MouseConnect());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public MouseConnect()
        {
            Text = "MouseConnect";
            ForeColor = SystemColors.WindowText;
            BackColor = SystemColors.Window;
            ClientSize += ClientSize;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                iNumPoints = 0;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                apoint[iNumPoints++] = new Point(e.X, e.Y);
                Graphics grfx = CreateGraphics();
                grfx.DrawLine(new Pen(ForeColor),e.X,e.Y,e.X,e.Y+1 );
                grfx.Dispose();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            Pen pen = new Pen(ForeColor);
            for (int i = 0; i < iNumPoints - 1; i++)
            {
                for (int j = i + 1; j < iNumPoints; j++)
                {
                    grfx.DrawLine(pen, apoint[i], apoint[j]);
                }
            }
        }
    }
}
