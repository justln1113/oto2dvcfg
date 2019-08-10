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
        public static string[] otoreadline(string otoPath)
        {
            StreamReader otoSRE = new StreamReader(otoPath, System.Text.Encoding.Default); //給ReadToEnd使用的Reader
            StreamReader otoSR = new StreamReader(otoPath, System.Text.Encoding.Default); //給ReadLine使用的Reader
            StreamReader hi2roRead = new StreamReader("hi-ro.txt", System.Text.Encoding.Default); //讀取假名轉羅馬字典檔
            string[] hi2roLines = hi2roRead.ReadToEnd().Split('\n');
            hi2roRead.Close();
            int otoLinesCount = otoSRE.ReadToEnd().Split('\n').Length; //計算oto行數
            otoSRE.Close();

            string[] otolines = otoSR.ReadToEnd().Split('\n');
            return otolines;
        }
    }
}
