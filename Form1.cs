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
using System.Reflection;

namespace oto2dvcfg
{

    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        //public string wavname, alias, offsets;
        public string[] wavName, consonant, alias, offset, cutoff, preutterance, overlap, aliasType;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            this.listView1.FullRowSelect = true;
            this.listView1.Scrollable = true;
        }
        public static string sendtext = "";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Console.WriteLine("TESTING");
        }


        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            int counter;
            string wavPath = String.Empty;
            StreamReader otoSRE = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default);
            int otoLinesCount = otoSRE.ReadToEnd().Split('\n').Length - 1; //計算oto行數
            string langType = String.Empty;
            if (checkBox1.Checked)
            {
                langType = "JPN";
            }
            List<string> aliasList = new List<string>();
            List<string> aliasTypeList = new List<string>();
            List<string> wavNameList = new List<string>();
            List<string> offsetList = new List<string>();
            List<string> consonantList = new List<string>();
            List<string> cutoffList = new List<string>();
            List<string> preutteranceList = new List<string>();
            List<string> overlapList = new List<string>();
            
            for (counter = 0; counter < otoLinesCount; counter++)
            {
                wavNameList.Add(listView1.Items[counter].SubItems[1].Text);
                wavName = wavNameList.ToArray();

                aliasList.Add(listView1.Items[counter].SubItems[2].Text.Replace("\n", ""));
                alias = aliasList.ToArray();

                offsetList.Add(listView1.Items[counter].SubItems[3].Text);
                offset = offsetList.ToArray();

                consonantList.Add(listView1.Items[counter].SubItems[4].Text);
                consonant = consonantList.ToArray();

                cutoffList.Add(listView1.Items[counter].SubItems[5].Text);
                cutoff = cutoffList.ToArray();

                preutteranceList.Add(listView1.Items[counter].SubItems[6].Text);
                preutterance = preutteranceList.ToArray();

                overlapList.Add(listView1.Items[counter].SubItems[7].Text);
                overlap = overlapList.ToArray();

                aliasTypeList.Add(listView1.Items[counter].SubItems[8].Text);
                aliasType = aliasTypeList.ToArray();
            }
            Console.WriteLine(textOTOpath.Text.Remove(textOTOpath.Text.LastIndexOf(@"\")));
            if (File.Exists(textOTOpath.Text.Remove(textOTOpath.Text.LastIndexOf(@"\") + 1) + wavName[6]))
            {
                wavPath = textOTOpath.Text.Remove(textOTOpath.Text.LastIndexOf(@"\") + 1);
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                //this.folderBrowserDialog1.SelectedPath = Directory.GetCurrentDirectory();
                folderBrowserDialog1.ShowDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                }
            }
            string[] output = FormPreview.dvcfgWriter(wavPath, langType, aliasType, wavName, alias, offset, consonant, cutoff, preutterance, overlap, otoLinesCount - 1, textPitch.Text);
            sendtext = "";
            foreach (string s in output)
            {
                sendtext += s;
            }
            FormPreview formPreview = new FormPreview();
            formPreview.ShowDialog(this);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


      
            public void OpenOTO_Click(object sender, EventArgs e)
            {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "UTAU voicebank config file (oto.ini)|oto.ini|All files(*.*)|*.*"; //新增開啟檔案視窗

                this.listView1.Items.Clear();
                this.labelOTOint.Text = "";



                if (openFileDialog1.ShowDialog() == DialogResult.OK) //若開啟檔案成功
                {
                    textOTOpath.Text = openFileDialog1.FileName; //取得開啟的檔案路徑

                    List<string> lines = new List<string>();
                    string line;
                    int counter = 0;
                    bool AliasHasSpace;
                    string aliasType;

                    StreamReader otoSRE = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default); //給ReadToEnd使用的Reader
                    StreamReader otoSR = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default); //給ReadLine使用的Reader
                    StreamReader hi2roRead = new StreamReader("hi-ro.txt", System.Text.Encoding.Default); //讀取假名轉羅馬字典檔
                    string[] hi2roLines = hi2roRead.ReadToEnd().Split('\n');
                    hi2roRead.Close();
                    int otoLinesCount = otoSRE.ReadToEnd().Split('\n').Length; //計算oto行數
                    otoSRE.Close();
                    while ((line = otoSR.ReadLine()) != null)
                    {
                        string[] otoInputer = otoSpliter.OtoInput(line); //輸入一條oto設定進otoSpliter方法
                        string counterST = Convert.ToString(counter + 1);

                        if (otoInputer[1].IndexOf(" ") < 0)
                        {
                            AliasHasSpace = false;
                        }
                        else
                        {
                            AliasHasSpace = true;
                        }
                        if (AliasHasSpace == true)
                        {
                            if (otoInputer[1].IndexOf("-") < 0)
                            {
                                aliasType = "VX";
                            }
                            else
                            {
                                if (otoInputer[1].IndexOf("-") > 1)
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
                        if(checkBox1.Checked)
                        {
                            foreach (string lineDict in hi2roLines)
                            {
                                string[] D = lineDict.Split('=');
                                otoInputer[1] = otoInputer[1].Replace(D[0].ToString(), D[1].ToString());
                            }
                        }
                        else
                        {

                        }
                        ListViewItem[] lvs = new ListViewItem[1];
                        lvs[0] = new ListViewItem(new string[]
                        {
                            counterST , //行數
                            otoInputer[0], //Wav Name
                            otoInputer[1], //Alias
                            otoInputer[2], //Offsest
                            otoInputer[3], //Consonant
                            otoInputer[4], //Cutoff
                            otoInputer[5], //Preutterance
                            otoInputer[6], //Overlap
                            aliasType //DV需要設定種類
                        }
                        );
                        this.listView1.Items.AddRange(lvs);
                        counter++;
                    }
                    otoSR.Close();
                    string otoLinesCountST = Convert.ToString(otoLinesCount - 2);
                    labelOTOint.Text = (otoLinesCountST);
                }
                else
                {
                    ListViewItem[] lvs = new ListViewItem[5];
                    lvs[0] = new ListViewItem(new string[] { "", "放棄啦！" });
                    lvs[1] = new ListViewItem(new string[] { "", "不幹啦！ " });
                    lvs[2] = new ListViewItem(new string[] { "", "讀個oto累死啦～" });
                    lvs[3] = new ListViewItem(new string[] { "", "跟你要了檔案你又不給" });
                    lvs[4] = new ListViewItem(new string[] { "", "是要列個啥(╯°□°）╯︵ ┻━┻" });

                this.listView1.Items.AddRange(lvs);

                //listView1.Items.Add("", "放棄啦！");
                //listView1.Items.Add("", "不幹啦！ ");
                //listView1.Items.Add("", "讀個oto累死啦～");
                //listView1.Items.Add("", "跟你要了檔案你又不給");
                //listView1.Items.Add("", "是要列個啥(╯°□°）╯︵ ┻━┻");
            }

            }

        }
    }
}
