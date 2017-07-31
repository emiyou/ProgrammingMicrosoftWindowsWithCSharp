using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TypeAway
{
    public class TypeAway:Form
    {
        public static void Main()
        {
            Application.Run(new TypeAway());
        }

        protected Caret Caret;
        protected string StrText = "";
        protected int Insert;

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public TypeAway()
        {
            Text = "Type Away";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            FontHeight = 24;
            Caret = new Caret(this);
            Caret.Size = new Size(2, Font.Height);
            Caret.Position = new Point(0, 0);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Caret.Hide();
            Graphics grfx = CreateGraphics();
            grfx.FillRectangle(new SolidBrush(BackColor),new RectangleF(PointF.Empty, grfx.MeasureString(StrText,Font,PointF.Empty,StringFormat.GenericTypographic)) );
            switch (e.KeyChar)
            {
                case '\b':
                    if (Insert > 0)
                    {
                        StrText = StrText.Substring(0, Insert - 1) + StrText.Substring(Insert);
                        Insert -= 1;
                    }
                    break;
                case '\r':
                case '\n':
                    break;
                default:
                    if (Insert == StrText.Length)
                    {
                        StrText += e.KeyChar;
                    }
                    else
                    {
                        StrText = StrText.Substring(0, Insert) + e.KeyChar + StrText.Substring(Insert);
                    }
                    Insert++;
                    break;
            }
            grfx.TextRenderingHint=TextRenderingHint.AntiAlias;
            grfx.DrawString(StrText,Font,new SolidBrush(ForeColor),0,0,StringFormat.GenericTypographic );
            
            grfx.Dispose();
            PositionCaret();
            Caret.Show();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    if (Insert > 0)
                    {
                        Insert--;
                    }
                    break;
                case Keys.Right:
                    if (Insert < StrText.Length)
                    {
                        Insert++;
                    }
                    break;
                case Keys.Home:
                    Insert = 0;
                    break;
                case Keys.End:
                    Insert = StrText.Length;
                    break;
                case Keys.Delete:
                    if (Insert < StrText.Length)
                    {
                        Insert++;
                        OnKeyPress(new KeyPressEventArgs('\b'));
                    }
                    break;
                default:
                    return;
            }
            PositionCaret();
        }

        protected void PositionCaret()
        {
            Graphics grfx = CreateGraphics();
            string str = StrText.Substring(0, Insert);
            StringFormat strfmt=StringFormat.GenericTypographic;
            strfmt.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            SizeF sizef = grfx.MeasureString(str, Font, PointF.Empty, strfmt);
            Caret.Position = new Point((int) sizef.Width, 0);
            grfx.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            grfx.TextRenderingHint=TextRenderingHint.AntiAlias;
            grfx.DrawString(StrText,Font,new SolidBrush(ForeColor),0,0,StringFormat.GenericTypographic );
        }
    }
}
