using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oto2dvcfg
{
    class otoReader
    {
        public static string get_aliasType(string input)
        {
            bool AliasHasSpace;
            string aliasType = String.Empty;
            if (input.IndexOf(" ") < 0)
            {
                AliasHasSpace = false;
            }
            else
            {
                AliasHasSpace = true;
            }
            if (AliasHasSpace == true)
            {
                if (input.IndexOf("-") < 0)
                {
                    aliasType = "VX";
                }
                else
                {
                    if (input.IndexOf("-") > 1)
                    {
                        aliasType = "VX";
                    }
                    else
                    {
                        aliasType = "-CV";
                    }
                }
            }
            else
            {
                aliasType = "CV";
            }

            return aliasType;
        }

        public static string[] ReadDict()
        {
            StreamReader hi2roRead = new StreamReader("hi-ro.txt", System.Text.Encoding.Default); //讀取假名轉羅馬字典檔
            string[] output = hi2roRead.ReadToEnd().Split('\n');
            return output;
        }

        public static int lineCount(string path)
        {
            StreamReader counter = new StreamReader(path, System.Text.Encoding.Default);
            int otoLinesCount = counter.ReadToEnd().Split('\n').Length; //計算oto行數
            return otoLinesCount;
        }
        
    }
}
