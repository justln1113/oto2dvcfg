using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oto2dvcfg
{
    class cfgProcess
    {
        public static string AddDigit(double input)
        {
            if (input > 1)
            {
                return input.ToString("F15");
            }
            else
            {
                return input.ToString("F16");
            }
        }
    }
}
