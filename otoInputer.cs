using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oto2dvcfg
{
    class otoInputer
    {
        public static string[] OtoInput(string Input)
        {
            string[] otoInputs = Input.Replace("=", ",").Split(',');
            return otoInputs;
        }
    }
}
