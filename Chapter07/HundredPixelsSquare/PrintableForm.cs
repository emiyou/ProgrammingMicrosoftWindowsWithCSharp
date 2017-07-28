using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HundredPixelsSquare
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public class PrintableForm : Form
    {
        //public static void Main()
        //{
        //    Application.Run(new PrintableForm());
        //}

        public PrintableForm()
        {
            Text = "PrintableForm";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            DoPage(grfx, ForeColor, ClientSize.Width, ClientSize.Height);
        }

        protected override void OnClick(EventArgs ea)
        {
            PrintDocument prndoc = new PrintDocument();
            prndoc.DocumentName = Text;
            prndoc.PrintPage += PrintDocumentOnPrintPage;
            prndoc.Print();
        }

        void PrintDocumentOnPrintPage(object obj, PrintPageEventArgs ppea)
        {
            Graphics grfx = ppea.Graphics;
            SizeF sizef = grfx.VisibleClipBounds.Size;
            DoPage(grfx, Color.Black, (int)sizef.Width, (int)sizef.Height);
        }

        protected virtual void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            Pen pen = new Pen(clr);
            grfx.DrawLine(pen, 0, 0, cx - 1, cy - 1);
            grfx.DrawLine(pen, 0, cy - 1, cx - 1, 0);
        }
    }
}
