using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio;

namespace oto2dvcfg
{
    public partial class FormPreview : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public string DVCFGoutput;

        public FormPreview()
        {
            InitializeComponent();
        }
        private void FormPreview_Load(object sender, EventArgs e)
        {
            string settings = Form1.sendtext.Remove(Form1.sendtext.Length - 1);
            richTextBox1.Text = "{" + settings + "\n" + "}";
        }

        private void FormPreview_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormPreview_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string[] dvcfgWriter
            (
            string wavPath,
            string langType,
            string[] srcType,
            string[] wavName,
            string[] symbol,
            string[] offset,
            string[] consonant,
            string[] cutoff,
            string[] Upreutterance,
            string[] Overlap,
            int otoLinesCount,
            string pitch
            )
        {
            int counter;
            string tailPoint;
            string vowelEnd;
            List<string> settings = new List<string>();
            if (langType == "JPN")
            {
                for (counter = 0; counter < otoLinesCount; counter++)
                {
                    NAudio.Wave.WaveFileReader waveFileReader = new NAudio.Wave.WaveFileReader(wavPath + wavName[counter]);
                    TimeSpan wavTimeSpan = waveFileReader.TotalTime;
                    double wavTime = Convert.ToDouble(wavTimeSpan.TotalSeconds) * 1000;
                    if (srcType[counter] == "CV")
                    {
                        if (Convert.ToDouble(cutoff[counter]) < 0)
                        {
                            tailPoint = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.06);
                        }
                        else
                        {
                            tailPoint = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        }
                        double connectPoint = 0.05999999865889549;
                        string endTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 + Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        //pitch
                        string preutterance = cfgProcess.AddDigit(Convert.ToDouble(Upreutterance[counter]) / 1000 + 0.06);
                        //srcType
                        string startTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 - 0.06);
                        //symbol
                        //tailPoint
                        DateTime updateTime = DateTime.Now;
                        //vowelEnd
                        string vowelStart = cfgProcess.AddDigit(Convert.ToDouble(consonant[counter]) / 1000 + 0.06);
                        //wavName
                        settings.Add
                            (
                                "\n" +
                                "   \"" + pitch + "->" + symbol[counter].Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\" : {\n" +
                                "      \"connectPoint\" : " + connectPoint + ",\n" +
                                "      \"endTime\" : " + endTime + ",\n" +
                                "      \"pitch\" : \"" + pitch + "\",\n" +
                                "      \"preutterance\" : " + preutterance + ",\n" +
                                "      \"srcType\" : \"" + srcType[counter].Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\",\n" +
                                "      \"startTime\" : " + startTime + ",\n" +
                                "      \"symbol\" : \"" + symbol[counter] + "\",\n" +
                                "      \"tailPoint\" : " + tailPoint + ",\n" +
                                "      \"updateTime\" : \"" + updateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\",\n" +
                                "      \"vowelEnd\" : " + vowelEnd + ",\n" +
                                "      \"vowelStart\" : " + vowelStart + ",\n" +
                                "      \"wavName\" : \"" + wavName[counter] + "\"\n" +
                                "   },"
                            );
                    }
                    else if (srcType[counter] == "-CV")
                    {
                        if (Convert.ToDouble(cutoff[counter]) < 0)
                        {
                            tailPoint = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.06);
                        }
                        else
                        {
                            tailPoint = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        }
                        double connectPoint = 0.05999999865889549;
                        string endTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 + Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        //pitch
                        string preutterance = cfgProcess.AddDigit(Convert.ToDouble(Upreutterance[counter]) / 1000 + 0.06);
                        //srcType
                        string startTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 - 0.06 - connectPoint);
                        //symbol
                        //tailPoint
                        DateTime updateTime = DateTime.Now;
                        //vowelEnd
                        string vowelStart = cfgProcess.AddDigit(Convert.ToDouble(consonant[counter]) / 1000 + 0.06);
                        //wavName
                        settings.Add
                            (
                                "\n" +
                                "   \"" + pitch + "->" + symbol[counter].Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\" : {\n" +
                                "      \"connectPoint\" : " + connectPoint + ",\n" +
                                "      \"endTime\" : " + endTime + ",\n" +
                                "      \"pitch\" : \"" + pitch + "\",\n" +
                                "      \"preutterance\" : " + preutterance + ",\n" +
                                "      \"srcType\" : \"" + srcType[counter].Replace("-", "") + "\",\n" +
                                "      \"startTime\" : " + startTime + ",\n" +
                                "      \"symbol\" : \"" + symbol[counter].Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\",\n" +
                                "      \"tailPoint\" : " + tailPoint + ",\n" +
                                "      \"updateTime\" : \"" + updateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\",\n" +
                                "      \"vowelEnd\" : " + vowelEnd + ",\n" +
                                "      \"vowelStart\" : " + vowelStart + ",\n" +
                                "      \"wavName\" : \"" + wavName[counter] + "\"\n" +
                                "   },"
                            );
                    }
                    else if (srcType[counter] == "VX")
                    {
                        double connectPoint = 0.05999999865889549;
                        string endTime = String.Empty;
                        if (Convert.ToDouble(cutoff[counter]) < 0)
                        {
                            endTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + connectPoint);
                        }
                        else
                        {
                            endTime = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + connectPoint);
                        }
                        string startTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 + Convert.ToDouble(Overlap[counter]) / 1000 - 0.06);
                        tailPoint = cfgProcess.AddDigit(Convert.ToDouble(consonant[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.06);
                        DateTime updateTime = DateTime.Now;
                        settings.Add
                            (
                                "\n" +
                                "   \"" + pitch + "->" + symbol[counter].Replace(" ", "_").Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace("_R", "_-") + "\" : {\n" +
                                "      \"connectPoint\" : " + connectPoint + ",\n" +
                                "      \"endTime\" : " + endTime + ",\n" +
                                "      \"pitch\" : \"" + pitch + "\",\n" +
                                "      \"srcType\" : \"" + srcType[counter] + "\",\n" +
                                "      \"startTime\" : " + startTime + ",\n" +
                                "      \"symbol\" : \"" + symbol[counter].Replace(" ", "_").Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace("_R", "_-") + "\",\n" +
                                "      \"tailPoint\" : " + tailPoint + ",\n" +
                                "      \"updateTime\" : \"" + updateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\",\n" +
                                "      \"wavName\" : \"" + wavName[counter] + "\"\n" +
                                "   },"
                            );
                    }
                    else
                    {
                        //這裡是INDLE
                        continue;
                    }
                }
            }







            else
            {
                for (counter = 0; counter < otoLinesCount; counter++)
                {
                    NAudio.Wave.WaveFileReader waveFileReader = new NAudio.Wave.WaveFileReader(wavPath + wavName[counter]);
                    TimeSpan wavTimeSpan = waveFileReader.TotalTime;
                    double wavTime = Convert.ToDouble(wavTimeSpan.TotalSeconds) * 1000;
                    if (srcType[counter] == "CV")
                    {
                        if (Convert.ToDouble(cutoff[counter]) < 0)
                        {
                            tailPoint = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.06);
                        }
                        else
                        {
                            tailPoint = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        }
                        double connectPoint = 0.05999999865889549;
                        string endTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 + Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        //pitch
                        string preutterance = cfgProcess.AddDigit(Convert.ToDouble(Upreutterance[counter]) / 1000 + 0.06);
                        //srcType
                        string startTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 - 0.06);
                        //symbol
                        //tailPoint
                        DateTime updateTime = DateTime.Now;
                        //vowelEnd
                        string vowelStart = cfgProcess.AddDigit(Convert.ToDouble(consonant[counter]) / 1000 + 0.06);
                        //wavName
                        settings.Add
                            (
                                "\n" +
                                "   \"" + pitch + "->" + symbol[counter].Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\" : {\n" +
                                "      \"connectPoint\" : " + connectPoint + ",\n" +
                                "      \"endTime\" : " + endTime + ",\n" +
                                "      \"pitch\" : \"" + pitch + "\",\n" +
                                "      \"preutterance\" : " + preutterance + ",\n" +
                                "      \"srcType\" : \"" + srcType[counter].Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\",\n" +
                                "      \"startTime\" : " + startTime + ",\n" +
                                "      \"symbol\" : \"" + symbol[counter] + "\",\n" +
                                "      \"tailPoint\" : " + tailPoint + ",\n" +
                                "      \"updateTime\" : \"" + updateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\",\n" +
                                "      \"vowelEnd\" : " + vowelEnd + ",\n" +
                                "      \"vowelStart\" : " + vowelStart + ",\n" +
                                "      \"wavName\" : \"" + wavName[counter] + "\"\n" +
                                "   },"
                            );
                    }
                    else if (srcType[counter] == "-CV")
                    {
                        if (Convert.ToDouble(cutoff[counter]) < 0)
                        {
                            tailPoint = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(-Convert.ToDouble(cutoff[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.06);
                        }
                        else
                        {
                            tailPoint = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.115);
                            vowelEnd = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        }
                        double connectPoint = 0.05999999865889549;
                        string endTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 + Convert.ToDouble(cutoff[counter]) / 1000 + 0.06);
                        //pitch
                        string preutterance = cfgProcess.AddDigit(Convert.ToDouble(Upreutterance[counter]) / 1000 + 0.06);
                        //srcType
                        string startTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 - 0.06);
                        //symbol
                        //tailPoint
                        DateTime updateTime = DateTime.Now;
                        //vowelEnd
                        string vowelStart = cfgProcess.AddDigit(Convert.ToDouble(consonant[counter]) / 1000 + 0.06);
                        //wavName
                        settings.Add
                            (
                                "\n" +
                                "   \"" + pitch + "->" + symbol[counter].Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\" : {\n" +
                                "      \"connectPoint\" : " + connectPoint + ",\n" +
                                "      \"endTime\" : " + endTime + ",\n" +
                                "      \"pitch\" : \"" + pitch + "\",\n" +
                                "      \"preutterance\" : " + preutterance + ",\n" +
                                "      \"srcType\" : \"" + srcType[counter].Replace("-", "") + "\",\n" +
                                "      \"startTime\" : " + startTime + ",\n" +
                                "      \"symbol\" : \"" + symbol[counter].Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\",\n" +
                                "      \"tailPoint\" : " + tailPoint + ",\n" +
                                "      \"updateTime\" : \"" + updateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\",\n" +
                                "      \"vowelEnd\" : " + vowelEnd + ",\n" +
                                "      \"vowelStart\" : " + vowelStart + ",\n" +
                                "      \"wavName\" : \"" + wavName[counter] + "\"\n" +
                                "   },"
                            );
                    }
                    else if (srcType[counter] == "VX")
                    {
                        double connectPoint = 0.05999999865889549;
                        string endTime = String.Empty;
                        if (Convert.ToDouble(cutoff[counter]) < 0)
                        {
                            endTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + connectPoint);
                        }
                        else
                        {
                            endTime = cfgProcess.AddDigit(wavTime / 1000 - Convert.ToDouble(offset[counter]) / 1000 - Convert.ToDouble(cutoff[counter]) / 1000 + connectPoint);
                        }
                        string startTime = cfgProcess.AddDigit(Convert.ToDouble(offset[counter]) / 1000 + Convert.ToDouble(Overlap[counter]) / 1000 - 0.06);
                        tailPoint = cfgProcess.AddDigit(Convert.ToDouble(consonant[counter]) / 1000 - Convert.ToDouble(Overlap[counter]) / 1000 + 0.06);
                        DateTime updateTime = DateTime.Now;
                        settings.Add
                            (
                                "\n" +
                                "   \"" + pitch + "->" + symbol[counter].Replace(" ", "_").Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace("_R", "_-") + "\" : {\n" +
                                "      \"connectPoint\" : " + connectPoint + ",\n" +
                                "      \"endTime\" : " + endTime + ",\n" +
                                "      \"pitch\" : \"" + pitch + "\",\n" +
                                "      \"srcType\" : \"" + srcType[counter] + "\",\n" +
                                "      \"startTime\" : " + startTime + ",\n" +
                                "      \"symbol\" : \"" + symbol[counter].Replace(" ", "_").Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace("_R", "_-") + "\",\n" +
                                "      \"tailPoint\" : " + tailPoint + ",\n" +
                                "      \"updateTime\" : \"" + updateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\",\n" +
                                "      \"wavName\" : \"" + wavName[counter] + "\"\n" +
                                "   },"
                            );
                    }
                    else
                    {
                        //這裡是INDLE
                        continue;
                    }
                }
            }

            return settings.ToArray();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "DeepVocal Config file|*.dvcfg";
            saveFileDialog1.Title = "Save DVCFG file";
            saveFileDialog1.FileName = "voice.dvcfg";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                streamWriter.WriteLine(richTextBox1.Text);
                streamWriter.Close();
            }
        }
    }
}
