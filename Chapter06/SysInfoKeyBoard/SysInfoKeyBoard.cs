using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace SysInfoKeyBoard
{
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    class SysInfoKeyBoard:SysInfoReflection.SysInfoReflection
    {
        public new static void Main()
        {
            Application.Run(new SysInfoKeyBoard());
        }

        public SysInfoKeyBoard()
        {
            Text = "System Infomation: Keyboard";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Point pt = AutoScrollPosition;
            pt.X = -pt.X;
            pt.Y = -pt.Y;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if ((e.Modifiers & Keys.Control) == Keys.Control)
                    {
                        pt.X += ClientSize.Width;
                    }
                    else
                    {
                        pt.X += Font.Height;
                    }
                    break;
                case Keys.Left:
                    if ((e.Modifiers & Keys.Control) == Keys.Control)
                    {
                        pt.X -= ClientSize.Width;
                    }
                    else
                    {
                        pt.X -= Font.Height;
                    }
                    break;
                case Keys.Down:
                    pt.Y += Font.Height;
                    break;
                case Keys.Up:
                    pt.Y -= Font.Height;
                    break;
                case Keys.PageDown:
                    pt.Y += Font.Height * (ClientSize.Height / Font.Height);
                    break;
                case Keys.PageUp:
                    pt.Y -= Font.Height * (ClientSize.Height / Font.Height);
                    break;
                case Keys.Home:
                    pt = Point.Empty;
                    break;
                case Keys.End:
                    pt.Y = 100000;
                    break;
            }
            AutoScrollPosition = pt;
        }
    }
}
