using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CheckerWithChildren;

namespace CheckerWithChildAndFocus
{
    class CheckerWithChildAndFocus:CheckerWithChildren.CheckerWithChildren
    {
        public new static void Main()
        {
            Application.Run(new CheckerWithChildAndFocus());
        }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public CheckerWithChildAndFocus()
        {
            Text = "Checke rWith Child And Focus";
        }

        protected override void CreateChildren()
        {

            CheckerChildren=new CheckerChildWithFocus[YNum,XNum];
            for (int y = 0; y < YNum; y++)
            {
                for (int x = 0; x < XNum; x++)
                {
                    CheckerChildren[y, x]=new CheckerChildWithFocus();
                    CheckerChildren[y, x].Parent = this;
                }
            }
        }

    }
}
