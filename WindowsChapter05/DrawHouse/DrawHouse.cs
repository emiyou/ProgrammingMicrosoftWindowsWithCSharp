using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawHouse
{
    class DrawHouse:PrintableForm.PrintableForm
    {
        public new static void Main()
        {
            Application.Run(new DrawHouse());
        }

        public DrawHouse()
        {
            Text = "Draw a house in one line";
        }

        protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            
            grfx.DrawLines(new Pen(clr),new Point[]
            {
                new Point(cx/4,3*cy/4),
                new Point(cx/4,cy/2), 
                new Point(cx/2,cy/4), 
                new Point(3*cx/4,cy/2), 
                new Point(3*cx/4,3*cy/4), 
                new Point(cx/4,cy/2), 
                new Point(3*cx/4,cy/2), 
                new Point(cx/4,3*cy/4), 
                new Point(3*cx/4,3*cy/4), 
            } );
        }
    }
}
