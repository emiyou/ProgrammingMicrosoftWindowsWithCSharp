using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AntiAlias
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class AntiAlias:Form
    {
        public static void Main()
        {
            Application.Run(new AntiAlias());
        }

        public AntiAlias()
        {
            Text = "Anti-Alias Demo";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            //ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            Pen pen = new Pen(ForeColor);
            //grfx.SmoothingMode=SmoothingMode.None;
            grfx.SmoothingMode = SmoothingMode.HighQuality;
            grfx.PixelOffsetMode=PixelOffsetMode.HighQuality;
            grfx.PixelOffsetMode=PixelOffsetMode.Default;
            grfx.DrawLine(pen, 2, 2, 18, 10);
        }

    }
}
