using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace ScribbleWithSave
{
    class ScribbleWithSave:Form
    {
        private ArrayList arrlstApts = new ArrayList();
        private ArrayList arrlstPts;
        private bool bTracking;

        public static void Main()
        {
            Application.Run(new ScribbleWithSave());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public ScribbleWithSave()
        {
            Text = "Scribble With Save";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            ResizeRedraw = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            arrlstPts = new ArrayList();
            arrlstPts.Add(new Point(e.X, e.Y));
            bTracking = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!bTracking)
            {
                return;
            }
            arrlstPts.Add(new Point(e.X, e.Y));
            Graphics grfx = CreateGraphics();
            grfx.DrawLine(new Pen(ForeColor),(Point)arrlstPts[arrlstPts.Count-1], (Point)arrlstPts[arrlstPts.Count - 2]);
            grfx.Dispose();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!bTracking)
            {
                return;
            }
            Point[] apt = (Point[]) arrlstPts.ToArray(typeof(Point));
            arrlstApts.Add(apt);
            bTracking = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            Pen pen = new Pen(ForeColor);
            for (int i = 0; i < arrlstApts.Count; i++)
            {
                grfx.DrawLines(pen, (Point[]) arrlstApts[i]);
            }
        }
    }
}
