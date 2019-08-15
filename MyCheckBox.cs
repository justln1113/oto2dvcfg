using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oto2dvcfg
{
    class MyCheckBox : CheckBox
    {
        protected override bool ShowFocusCues
        {
            get { return false; }
        }
    }
}
