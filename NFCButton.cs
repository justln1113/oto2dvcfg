using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oto2dvcfg
{
    public class NFCButton : Button //NoFocusCueButton
    {
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}
