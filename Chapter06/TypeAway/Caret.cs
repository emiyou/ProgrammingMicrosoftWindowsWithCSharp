using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TypeAway
{
    public class Caret
    {
        [DllImport("user32.dll")]
        public static extern int CreateCaret(IntPtr hwnd, IntPtr hbm, int cx, int cy);

        [DllImport("user32.dll")]
        public static extern int DestroyCaret();

        [DllImport("user32.dll")]
        public static extern int SetCaretPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern int ShowCaret(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int HideCaret(IntPtr hwnd);

        private Control ctrl;
        private Size size;
        private Point ptPos;
        private bool bVisible;

        private Caret()
        {
            
        }

        public Caret(Control ctrl)
        {
            this.ctrl = ctrl;
            Position=Point.Empty;
            Size = new Size(1, ctrl.Font.Height);
            Control.GotFocus += ControlOnGotFocus;
            Control.LostFocus += ControlOnLostFocus;
            if (ctrl.Focused)
            {
                ControlOnGotFocus(ctrl,new EventArgs());
            }
        }

        public Control Control
        {
            get { return ctrl; }
        }

        public Size Size
        {
            get { return size;}
            set { size = value; }
        }

        public Point Position
        {
            get { return ptPos;}
            set
            {
                ptPos = value;
                SetCaretPos(ptPos.X, ptPos.Y);
            }
        }

        public bool Visibility
        {
            get { return bVisible; }
            set
            {
                bVisible = value;
                if (bVisible)
                {
                    ShowCaret(Control.Handle);
                }
                else
                {
                    HideCaret(Control.Handle);
                }
            }
        }

        public void Show()
        {
            Visibility = true;
        }

        public void Hide()
        {
            Visibility = false;
        }

        public void Dispose()
        {
            if (ctrl.Focused)
            {
                ControlOnLostFocus(ctrl,new EventArgs());
            }
            Control.GotFocus -= ControlOnGotFocus;
            Control.LostFocus -= ControlOnLostFocus;
        }

        void ControlOnGotFocus(object obj, EventArgs ea)
        {
            CreateCaret(Control.Handle, IntPtr.Zero, Size.Width, Size.Height);
            SetCaretPos(Position.X, Position.Y);
            Show();
        }

        void ControlOnLostFocus(object obj, EventArgs ea)
        {
            Hide();
            DestroyCaret();
        }

    }
}
