using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace CheckerWithChildren
{
    public class CheckerWithChildren:Form
    {
        protected const int XNum = 5;
        protected const int YNum = 4;
        protected CheckerChild[,] CheckerChildren;

        public static void Main()
        {
            Application.Run(new CheckerWithChildren());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public CheckerWithChildren()
        {
            Text = "Checker With Children";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            CreateChildren();
            OnResize(EventArgs.Empty);
        }

        protected virtual void CreateChildren()
        {
            CheckerChildren=new CheckerChild[YNum,XNum];
            for (int y = 0; y < YNum; y++)
            {
                for (int x = 0; x < XNum; x++)
                {
                    CheckerChildren[y,x]=new CheckerChild();
                    CheckerChildren[y, x].Parent = this;
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            int cx = ClientSize.Width / XNum;
            int cy = ClientSize.Height / YNum;
            for (int y = 0; y < YNum; y++)
            {
                for (int x = 0; x < XNum; x++)
                {
                    CheckerChildren[y, x].Location = new Point(x * cx, y * cy);
                    CheckerChildren[y, x].Size = new Size(cx, cy);
                }
            }
        }
    }
}
