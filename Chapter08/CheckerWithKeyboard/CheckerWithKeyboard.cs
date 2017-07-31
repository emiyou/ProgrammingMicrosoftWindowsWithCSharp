using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace CheckerWithKeyboard
{
    class CheckerWithKeyboard:Checker.Checker
    {
        public new static void Main()
        {
            Application.Run(new CheckerWithKeyboard()); 
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public CheckerWithKeyboard()
        {
            Text = "Checker With Keyboard";
        }

        protected override void OnGotFocus(EventArgs e)
        {
            Cursor.Show();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Cursor.Hide();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Point ptCursor = PointToClient(Cursor.Position);
            int x = Math.Max(0, Math.Min(XNum - 1, ptCursor.X / CxBlock));
            int y = Math.Max(0, Math.Min(YNum - 1, ptCursor.Y / CyBlock));
            switch (e.KeyCode)
            {
                case Keys.Up:
                    y--;
                    break;
                case Keys.Left:
                    x--;
                    break;
                case Keys.Right:
                    x++;
                    break;
                case Keys.Down:
                    y++;
                    break;
                case Keys.Home:
                    x = y = 0;
                    break;
                case Keys.End:
                    x = XNum - 1;
                    y = YNum - 1;
                    break;
                case Keys.Enter:
                case Keys.Space:
                    AbChecked[y, x] = !AbChecked[y, x];
                    Invalidate(new Rectangle(x * CxBlock, y * CyBlock, CxBlock, CyBlock));
                    return;
                default:
                    return;
            }
            x = (x + XNum) % XNum;
            y = (y + YNum) % YNum;
            Cursor.Position = PointToScreen(new Point(x * CxBlock + CxBlock / 2,y * CyBlock + CyBlock / 2));
        }
    }
}
