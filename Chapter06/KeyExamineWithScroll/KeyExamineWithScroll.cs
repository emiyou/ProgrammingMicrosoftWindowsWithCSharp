using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyExamineWithScroll
{
    class KeyExamineWithScroll:KeyExamine.KeyExamine
    {
        public new static void Main()
        {
            Application.Run(new KeyExamineWithScroll());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public KeyExamineWithScroll()
        {
            Text += " With Scroll";
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        public static extern int ScrollWindow(IntPtr hwnd, int cx, int cy, ref Rect rectScroll, ref Rect rectClip);

        protected override void ScrollLines()
        {
            Rect rect;
            rect.Left = 0;
            rect.Top = Font.Height;
            rect.Right = ClientSize.Width;
            rect.Bottom = ClientSize.Height;
            ScrollWindow(Handle, 0, -Font.Height, ref rect, ref rect);
        }
    }
}
