using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace PoePoem
{
    class PoePoem:Form
    {
        private const string StrAnnabelLee =
            "It was many and many a year ago,\n" +
            "  In a kingdom by the sea\n" +
            "That a maiden there lived whom you may know\n" +
            "  By the name of Annabel Lee;\x2014\n" +
            "And the maiden who lived with no other thought\n" +
            "  Than to love and be loved by me\n" +
            "\n" +
            "I was a child and she was a child\n" +
            "  In this kingdom by the sea\n" +
            "But we loved with a love that was more than love\x0214\n" +
            "  I and my annabel Lee\n" +
            "With a love that the winged seraphs of Heaven\n" +
            "  Coveted her and me\n" +
            "\n" +
            "任侠平生愿\n" +
            "一叶边舟莲波滟\n" +
            "秋水墨色染\n" +
            "如见美人眼波怜\n" +
            "故人久未见\n" +
            "焚诗煮酒杯未满\n" +
            "风长卷\n" +
            "轻将红袖挽\n" +
            "请君三尺剑\n" +
            "烽火城头沥肝胆\n" +
            "借君三十年\n" +
            "繁花万里好江山\n" +
            "翻千册案卷\n" +
            "谜雾遮眼心事高悬 ";

        private readonly int iTextLines;
        private int iClientLines, iStartLine;
        private float cyText;

        public static void Main()
        {
            if (!SystemInformation.MouseWheelPresent)
            {
                MessageBox.Show("Program needs a mouse with a mouse wheel!", "PoePoem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            Application.Run(new PoePoem());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public PoePoem()
        {
            Text = "\"Annabel Lee\" by Edgar Allan Poe";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            ResizeRedraw = true;
            int iIndex = 0;
            while ((iIndex = StrAnnabelLee.IndexOf('\n', iIndex)) != -1)
            {
                iTextLines++;
                iIndex++;
            }
            Graphics grfx = CreateGraphics();
            cyText = Font.GetHeight(grfx);
            grfx.Dispose();
            OnResize(EventArgs.Empty);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            iClientLines = (int)Math.Floor(ClientSize.Height / cyText);
            iStartLine = Math.Max(0, Math.Min(iStartLine, iTextLines - iClientLines));
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int iScroll = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            iStartLine -= iScroll;
            iStartLine = Math.Max(0, Math.Min(iStartLine, iTextLines - iClientLines));
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            grfx.DrawString(StrAnnabelLee,Font,new SolidBrush(ForeColor),0,-iStartLine*cyText );
        }
    }
}
