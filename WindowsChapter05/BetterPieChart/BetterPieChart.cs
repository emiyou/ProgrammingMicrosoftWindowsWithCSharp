using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace BetterPieChart
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class BetterPieChart:PieChart.PieChart
    {
        public new static void Main()
        {
            Application.Run(new BetterPieChart());
        }

        public BetterPieChart()
        {
            Text = "BetterPieChart";
        }

        protected override void DrawPieSlice(Graphics grfx, Pen pen, Rectangle rect, float fAngle, float fSweep)
        {
            float fSlice = (float) (2 * Math.PI * (fAngle + fSweep / 2) / 360);
            rect.Offset((int) (Math.Cos(fSlice)*rect.Width / 10 ), (int) (Math.Sin(fSlice)*rect.Height / 10));
            base.DrawPieSlice(grfx, pen, rect, fAngle, fSweep);
        }
    }
}
