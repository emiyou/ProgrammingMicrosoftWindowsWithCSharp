using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace MouseConnectWaitCursor
{
    class MouseConnectWaitCursor:MouseConnect.MouseConnect
    {
        public new static void Main()
        {
            Application.Run(new MouseConnectWaitCursor());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public MouseConnectWaitCursor()
        {
            Text = "Mouse Connect with wait cursor";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            base.OnPaint(e);
            Cursor.Hide();
            Cursor.Current = Cursors.Arrow;
        }
    }
}
