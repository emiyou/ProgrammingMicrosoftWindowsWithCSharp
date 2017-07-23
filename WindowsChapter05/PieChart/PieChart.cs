using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace PieChart
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class PieChart:PrintableForm.PrintableForm
    {
        private int[] aiValues = {50, 100, 25, 150, 100, 75};

        public new static void Main()
        {
            Application.Run(new PieChart());
        }

        public PieChart()
        {
            Text = "PieChart";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            Rectangle rect = new Rectangle(50, 50, 200, 200);
            Pen pen = new Pen(clr);
            int iTotal = 0;
            float fAngle = 0, fSweep;
            foreach (int aiValue in aiValues)
            {
                iTotal += aiValue;
            }
            foreach (int aiValue in aiValues)
            {
                fSweep = 360f * aiValue / iTotal;
                DrawPieSlice(grfx, pen, rect, fAngle, fSweep);
                fAngle += fSweep;
            }
        }

        protected virtual void DrawPieSlice(Graphics grfx, Pen pen, Rectangle rect, float fAngle, float fSweep)
        {
            grfx.DrawPie(pen, rect, fAngle, fSweep);
        }
    }
}
