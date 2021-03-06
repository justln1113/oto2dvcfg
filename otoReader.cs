﻿using System;
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
            string aliasType = String.Empty;
            if (input.Contains(" "))
            {
                if (input.Contains("-") || input.Contains("・"))
                {
                    if ((input.IndexOf("-") > 1) || (input.IndexOf("・") > 1))
                    {
                        aliasType = "VX";
                    }
                    else
                    {
                        aliasType = "CV";
                    }
                    
                }
                else
                {
                    aliasType = "VX";
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
            hi2roRead.Close();
            return output;
        }

        public static string[] ReadDict_n()
        {
            StreamReader hi2roRead = new StreamReader("hi-ro-n.txt", System.Text.Encoding.Default); //讀取假名轉羅馬字典檔
            string[] output = hi2roRead.ReadToEnd().Split('\n');
            hi2roRead.Close();
            return output;
        }

        public static int lineCount(string path)
        {
            StreamReader counter = new StreamReader(path, System.Text.Encoding.Default);
            int otoLinesCount = counter.ReadToEnd().Split('\n').Length - 1; //計算oto行數
            return otoLinesCount;
        }

        public static string FindAndReplace(string input)
        {
            if (File.Exists("FindAndReplace.tmp"))
            {
                string line = String.Empty;
                StreamReader readTMP = new StreamReader("FindAndReplace.tmp", Encoding.Default);
                while ((line = readTMP.ReadLine()) != null && line != String.Empty)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        string[] D = line.Split(',');
                        input = input.Replace(D[1], D[2]);
                    }
                    else
                    {
                        continue;
                    }
                }
                readTMP.Close();
            }
            return input;
        }

        public static string hi2ro(string input)
        {
            foreach (string lineDict in ReadDict())
            {
                string[] D = lineDict.Split('=');
                input = input.Replace(D[0], D[1]);
            }
            return input;
        }

        public static string hi2ron(string input, string aliasType)
        {
            List<string> replaceN = new List<string>();
            replaceN.Add("ん");
            replaceN.Add("n");
            foreach (string lineDict in ReadDict_n())
            {
                if (input.Contains(" ") && input.IndexOf("y", input.IndexOf(" ")) >= 1) continue;
                string[] D = lineDict.Split('=');
                input = input.Replace(D[0], D[1]);
            }
            foreach (string lineDict in ReadDict())
            {
                string[] D = lineDict.Split('=');
                input = input.Replace(D[0], D[1].Replace("N", "n"));
            }
                return input;
        }

    }
}
