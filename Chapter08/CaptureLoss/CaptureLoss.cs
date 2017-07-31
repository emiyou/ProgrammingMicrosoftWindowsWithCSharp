using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace CaptureLoss
{
    class CaptureLoss:Form
    {
        public static void Main()
        {
            Application.Run(new CaptureLoss());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public CaptureLoss()
        {
            Text = "Capture Loss";
            CaptureLossWindow win=new CaptureLossWindow();
            win.form = this;
            win.AssignHandle(Handle);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Invalidate();
        }

        public void OnLostCapture()
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            if (Capture)
            {
                grfx.FillRectangle(Brushes.Red, ClientRectangle);
            }
            else
            {
                grfx.FillRectangle(Brushes.Gray, ClientRectangle);
            }
        }

        class CaptureLossWindow:NativeWindow
        {
            public CaptureLoss form;
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 533)
                {
                    form.OnLostCapture();   
                }
                base.WndProc(ref m);
            }
        }
    }
}
