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
using System.Globalization;

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
        public void FormPreview_Load(object sender, EventArgs e)
        {
            string settings = String.Empty;
            if (Form1.sendtext.Length > 0)
            {
                settings = Form1.sendtext.Remove(Form1.sendtext.Length - 2);
            }
            else
            {
                MessageBox.Show("Failed to generate.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.Close();
                return;
            } 
            richTextBox1.Text = "{\n" + settings + "\n" + "}";
            Form1.formLoading.Hide();
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
            List<string> settings = new List<string>();
            for (int i = 0; i < otoLinesCount+1; i++)
            {
                if (!File.Exists(wavPath + wavName[i])) continue;
                NAudio.Wave.WaveFileReader waveFileReader = new NAudio.Wave.WaveFileReader(wavPath + wavName[i]);
                TimeSpan wavTimeSpan = waveFileReader.TotalTime;

                dvcfgCalculator DC = new dvcfgCalculator
                {
                    SrcType = srcType[i],
                    Offset = Convert.ToDouble(offset[i]),
                    Consonant = Convert.ToDouble(consonant[i]),
                    Cutoff = Convert.ToDouble(cutoff[i]),
                    UTAUPreutterance = Convert.ToDouble(Upreutterance[i]),
                    Overlap = Convert.ToDouble(Overlap[i]),
                    WavTime = Convert.ToDouble(wavTimeSpan.TotalSeconds) * 1000
                };

                switch (srcType[i])
                {
                    case "CV":
                        settings.Add(
                            $"   \"{pitch}->{DC.StartNoteDetact(symbol[i])}\" : {{\n" +
                            $"      \"connectPoint\" : {DC.ToString(DC.ConnectPoint)},\n" +
                            $"      \"endTime\" : {DC.ToString(DC.EndTime)},\n" +
                            $"      \"pitch\" : \"{pitch}\",\n" +
                            $"      \"preutterance\" : {DC.ToString(DC.DVPreuttrance)},\n" +
                            $"      \"srcType\" : \"CV\",\n" +
                            $"      \"startTime\" : {DC.ToString(DC.StartTime)},\n" +
                            $"      \"symbol\" : \"{DC.StartNoteDetact(symbol[i])}\",\n" +
                            $"      \"tailPoint\" : {DC.ToString(DC.TailPoint)},\n" +
                            $"      \"updateTime\" : \"{DC.UpdateTime}\",\n" +
                            $"      \"vowelEnd\" : {DC.ToString(DC.VowelEnd)},\n" +
                            $"      \"vowelStart\" : {DC.ToString(DC.VowelStart)},\n" +
                            $"      \"wavName\" : \"{wavName[i]}\"\n" +
                            $"   }},\n"
                            );
                        break;
                    case "VX":
                        settings.Add(
                            $"   \"{pitch}->{symbol[i].Replace(" ", "_")}\" : {{\n" +
                            $"      \"connectPoint\" : {DC.ToString(DC.ConnectPoint)},\n" +
                            $"      \"endTime\" : {DC.ToString(DC.EndTime)},\n" +
                            $"      \"pitch\" : \"{pitch}\",\n" +
                            $"      \"srcType\" : \"VX\",\n" +
                            $"      \"startTime\" : {DC.ToString(DC.StartTime)},\n" +
                            $"      \"symbol\" : \"{symbol[i].Replace(" ", "_")}\",\n" +
                            $"      \"tailPoint\" : {DC.ToString(DC.TailPoint)},\n" +
                            $"      \"updateTime\" : \"{DC.UpdateTime}\",\n" +
                            $"      \"wavName\" : \"{wavName[i]}\"\n" +
                            $"   }},\n"
                            );
                        break;
                    case "INDIE":
                        settings.Add(
                            $"   \"{pitch}->{symbol[i]}\" : {{\n" +
                            $"      \"endPoint\" : {DC.ToString(DC.VowelEnd + DC.ConnectPoint)},\n" +
                            $"      \"endTime\" : {DC.ToString(DC.EndTime)},\n" +
                            $"      \"pitch\" : \"{pitch}\",\n" +
                            $"      \"srcType\" : \"INDIE\",\n" +
                            $"      \"startPoint\" : {DC.ToString(DC.ConnectPoint)},\n" +
                            $"      \"startTime\" : {DC.ToString(DC.StartTime)},\n" +
                            $"      \"symbol\" : \"{symbol[i]}\",\n" +
                            $"      \"updateTime\" : \"{DC.UpdateTime}\",\n" +
                            $"      \"wavName\" : \"{wavName[i]}\"\n" +
                            $"   }},\n"
                            );
                        break;
                    default:
                        throw new Exception("Unable to parse src type");
                }

                DC.Clear();
            }
            
            return settings.ToArray();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "DeepVocal Config file|*.dvcfg";
            saveFileDialog1.Title = "Save DVCFG file";
            saveFileDialog1.FileName = "voice.dvcfg";
            if (saveFileDialog1.FileName != String.Empty)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                    streamWriter.WriteLine(richTextBox1.Text);
                    streamWriter.Flush();
                    streamWriter.Close();
                    MessageBox.Show("Save success", "^_^", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                else
                {

                }
            }
        }
    }
}
