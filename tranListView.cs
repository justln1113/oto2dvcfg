using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oto2dvcfg
{
    public class tranListView : ListView
    {
        public void TransparantBackground()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}
