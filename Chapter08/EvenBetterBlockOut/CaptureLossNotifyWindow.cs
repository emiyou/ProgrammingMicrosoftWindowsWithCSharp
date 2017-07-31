using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvenBetterBlockOut
{
    public interface ICaptureLossNotify
    {
        void OnLostCapture();
    }

    public class CaptureLossNotifyWindow:NativeWindow
    {
        public ICaptureLossNotify control;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 533)
            {
                control.OnLostCapture();
            }
            base.WndProc(ref m);
        }
    }
}
