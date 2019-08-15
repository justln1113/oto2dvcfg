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
using System.Globalization;
using System.Drawing.Drawing2D;

namespace oto2dvcfg
{
    public partial class Form1 : Form
    {
        public static bool _ChangeLanguage = false; //This will indicate if the void needs to be called
        public static string _Language = ""; //This will indicate our new language
        private bool mouseDown;
        private Point lastLocation;
        public string[] wavName, consonant, alias, offset, cutoff, preutterance, overlap, aliasType;
        public StreamWriter stream;
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
        //public TransparentTextBox textOTOpath;
        public NFCButton openOTO;
        public Form1()
        {
            InitializeComponent();
            this.listView1.FullRowSelect = true;
            this.listView1.Scrollable = true;
            this.listView1.MultiSelect = true;

            openOTO = new NFCButton();
            openOTO.BackColor = Color.Transparent;
            openOTO.BackgroundImage = oto2dvcfg.Properties.Resources.buttonAddNormal;
            openOTO.Cursor = Cursors.Hand;
            openOTO.FlatStyle = FlatStyle.Flat;
            openOTO.FlatAppearance.BorderSize = 0;
            openOTO.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            openOTO.FlatAppearance.CheckedBackColor = Color.Transparent;
            openOTO.FlatAppearance.MouseOverBackColor = Color.Transparent;
            openOTO.FlatAppearance.MouseDownBackColor = Color.Transparent;
            openOTO.ForeColor = Color.Transparent;
            openOTO.Location = new Point(161, 42);
            openOTO.Size = new Size(38, 38);
            openOTO.Click += OpenOTO_Click;
            openOTO.MouseDown += OpenOTO_MouseDown;
            openOTO.MouseUp += OpenOTO_MouseUp;
            this.Controls.Add(this.openOTO);

            buttonClose.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            buttonClose.FlatAppearance.CheckedBackColor = Color.Transparent;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.Transparent;

            //textOTOpath = new TransparentTextBox();
            //textOTOpath.Location = new System.Drawing.Point(222, 50);
            //textOTOpath.Size = new System.Drawing.Size(625, 24);
            //textOTOpath.BorderStyle = BorderStyle.None;
            //textOTOpath.BackColor = Color.Transparent;
        }

        private void OpenOTO_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static string sendtext = "";

        private void optionChangedList(object sender, ItemCheckedEventArgs e)
        {

        }

        private void ComboLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLang.SelectedItem.ToString() == "English")
            {
                ChangeLanguage("en");
            }
            else if(comboLang.SelectedItem.ToString() == "繁體中文")
            {
                ChangeLanguage("zh_TW");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo TheCulture = new CultureInfo("en-US", false);
            NumberFormatInfo NumFmtInf = TheCulture.NumberFormat;
            NumFmtInf.NumberDecimalSeparator = ".";
        }

        private void ListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Selected = true;
                }
            }
            else if(e.KeyCode == Keys.Delete)
            {
                ToolStripMenuItemDel_Click(null, null);
            }
            else
            {
                    
            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }
            foreach (ListViewItem eachItem in listView1.Items)
            {
                counter++;
                eachItem.SubItems[0].Text = counter.ToString();
            }
            labelOTOint.Text = listView1.Items.Count.ToString();
        }

        private void OpenOTO_MouseDown(object sender, MouseEventArgs e)
        {
            openOTO.FlatAppearance.BorderSize = 0;
            openOTO.ForeColor = Color.Transparent;
            openOTO.BackgroundImage = oto2dvcfg.Properties.Resources.buttonAddActive;
        }

        private void OpenOTO_MouseUp(object sender, MouseEventArgs e)
        {
            openOTO.FlatAppearance.BorderSize = 0;
            openOTO.ForeColor = Color.Transparent;
            openOTO.BackgroundImage = oto2dvcfg.Properties.Resources.buttonAddNormal;
        }

        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.Location = new Point(1111 - 6, 49 - 6);
            buttonClose.Size = new Size(36, 36);
            buttonClose.BackgroundImage = oto2dvcfg.Properties.Resources.buttonCloseActive;
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.Location = new Point(1111, 49);
            buttonClose.Size = new Size(24, 24);
            buttonClose.BackgroundImage = oto2dvcfg.Properties.Resources.buttonCloseNormal;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            stream = new StreamWriter("temphi2ro.tmp");
            stream.WriteLine();
            //int size = this.Size.Height;
            //while (size > 600)
            //{
            //    size--;
            //    this.Size = new Size(this.Size.Width, size);
            //}
            //while (size > 100)
            //{
            //    size -= 2;
            //    this.Size = new Size(this.Size.Width, size);
            //}
            //while (size > 1)
            //{
            //    size--;
            //    this.Size = new Size(this.Size.Width, size);
            //}
            this.Close();
        }

        private void CheckHI2RO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Console.WriteLine("TESTING");
        }


        public void ButtonGenerate_Click(object sender, EventArgs e)
        {
            int counter;
            string wavPath = String.Empty;
            if (textOTOpath.Text.Length < 1)
            {
                MessageBox.Show("OTO path is empty!", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                StreamReader otoSRE = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default);
                string calcType = String.Empty;
                if (radioButtonJCVVC.Checked)
                {
                    calcType = "JPN";
                }
                else if (radioButtonCCVVC.Checked)
                {
                    calcType = "Default";
                }
                else
                {
                    calcType = "Default";
                }
                List<string> aliasList = new List<string>();
                List<string> aliasTypeList = new List<string>();
                List<string> wavNameList = new List<string>();
                List<string> offsetList = new List<string>();
                List<string> consonantList = new List<string>();
                List<string> cutoffList = new List<string>();
                List<string> preutteranceList = new List<string>();
                List<string> overlapList = new List<string>();

                for (counter = 0; counter < listView1.Items.Count; counter++)
                {
                    wavNameList.Add(listView1.Items[counter].SubItems[1].Text);
                    wavName = wavNameList.ToArray();
                    if (checkHI2RO.Checked)
                    {
                        aliasList.Add(listView1.Items[counter].SubItems[9].Text.Replace("\n", "").Replace("\t", "").Replace("\r", ""));
                        alias = aliasList.ToArray();
                    }
                    else
                    {
                        aliasList.Add(listView1.Items[counter].SubItems[2].Text.Replace("\n", "").Replace("\t", "").Replace("\r", ""));
                        alias = aliasList.ToArray();
                    }
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
                    folderBrowserDialog1.Description = "Please select your wav file folder.";
                    //this.folderBrowserDialog1.SelectedPath = Directory.GetCurrentDirectory();
                    folderBrowserDialog1.ShowDialog();
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        wavPath = folderBrowserDialog1.SelectedPath + "\\";
                        if (File.Exists(wavPath + wavName[6]))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Wav file does not exist.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                string[] output = FormPreview.dvcfgWriter(wavPath, calcType, aliasType, wavName, alias, offset, consonant, cutoff, preutterance, overlap, listView1.Items.Count - 1, textPitch.Text);
                sendtext = "";
                foreach (string s in output)
                {
                    sendtext += s;
                }
                FormPreview formPreview = new FormPreview();
                formPreview.ShowDialog(this);
            }
        }


        public string[] OtoInput(string Input)
        {
            string[] otoInputs = Input.Replace("=", ",").Split(',');
            return otoInputs;
        }

        public void OpenOTO_Click(object sender, EventArgs e)
         {
            openOTO.BackgroundImage = oto2dvcfg.Properties.Resources.buttonAddActive;
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "UTAU voicebank config file (oto.ini)|oto.ini|All files(*.*)|*.*"; //新增開啟檔案視窗

                this.listView1.Items.Clear();
                this.labelOTOint.Text = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK) //若開啟檔案成功
                {
                    if (File.Exists(openFileDialog1.FileName))
                    {

                        textOTOpath.Text = openFileDialog1.FileName; //取得開啟的檔案路徑
                        string otoPath = textOTOpath.Text;
                        if (otoReader.lineCount(otoPath) - 2 < 0)
                        {
                            MessageBox.Show("oto file is empty.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            List<string> lines = new List<string>();
                            string line;
                            int counter = 0;
                            string aliasType;

                            StreamReader otoSR = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default); //給ReadLine使用的Reader
                            while ((line = otoSR.ReadLine()) != null)
                            {
                                string[] otoInputer = OtoInput(line); //輸入一條oto設定進otoSpliter方法
                                if (otoInputer.Length < 7)
                                {
                                    MessageBox.Show("Wrong oto format.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                    return;
                                }
                                else
                                {
                                    //if (checkHI2RO.Checked)
                                    //{
                                    //    foreach (string lineDict in otoReader.ReadDict())
                                    //    {
                                    //        string[] D = lineDict.Split('=');
                                    //        otoInputer[1] = otoInputer[1].Replace(D[0].ToString(), D[1].ToString());
                                    //    }
                                    //}
                                    //else
                                    //{

                                    //}
                                    string hi2ro = string.Empty;
                                    aliasType = otoReader.get_aliasType(otoInputer[1]);
                                    foreach (string lineDict in otoReader.ReadDict())
                                    {
                                        string[] D = lineDict.Split('=');
                                        otoInputer[1] = otoInputer[1].Replace(D[0], D[1]);
                                    }

                                    ListViewItem[] lvs = new ListViewItem[1];
                                    lvs[0] = new ListViewItem(new string[]
                                    {
                                        Convert.ToString(counter + 1) , //行數
                                        otoInputer[0], //Wav Name
                                        OtoInput(line)[1], //Alias
                                        otoInputer[2], //Offsest
                                        otoInputer[3], //Consonant
                                        otoInputer[4], //Cutoff
                                        otoInputer[5], //Preutterance
                                        otoInputer[6], //Overlap
                                        aliasType, //DV需要設定種類
                                        otoInputer[1]
                                    }
                                    );
                                    this.listView1.Items.AddRange(lvs);
                                    counter++;
                                }
                            }
                            otoSR.Close();
                            labelOTOint.Text = Convert.ToString(otoReader.lineCount(otoPath) - 1);
                        }
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
                else
                {
                    MessageBox.Show("OTO file not exists.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    ListViewItem[] lvs = new ListViewItem[5];
                    lvs[0] = new ListViewItem(new string[] { "", "放棄啦！" });
                    lvs[1] = new ListViewItem(new string[] { "", "不幹啦！ " });
                    lvs[2] = new ListViewItem(new string[] { "", "讀個oto累死啦～" });
                    lvs[3] = new ListViewItem(new string[] { "", "跟你要了檔案你又不給" });
                    lvs[4] = new ListViewItem(new string[] { "", "是要列個啥(╯°□°）╯︵ ┻━┻" });

                    this.listView1.Items.AddRange(lvs);
                }
            }

        }

        public void optionChanged(object sender, EventArgs e)
        {
            //listView1.Items.Clear();
            //List<string> lines = new List<string>();
            //string line;
            //int counter = 0;
            //string aliasType;
            //if (textOTOpath.Text.Length < 1)
            //{
            //    MessageBox.Show("OTO path is empty!", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    StreamReader otoSR = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default); //給ReadLine使用的Reader
            //    while ((line = otoSR.ReadLine()) != null)
            //    {
            //        string[] otoInputer = OtoInput(line); //輸入一條oto設定進otoSpliter方法

            //        if (checkHI2RO.Checked)
            //        {
            //            foreach (string lineDict in otoReader.ReadDict())
            //            {
            //                string[] D = lineDict.Split('=');
            //                otoInputer[1] = otoInputer[1].Replace(D[0].ToString(), D[1].ToString());
            //            }
            //        }
            //        else
            //        {

            //        }
            //        aliasType = otoReader.get_aliasType(otoInputer[1]);
            //        ListViewItem[] lvs = new ListViewItem[1];
            //        lvs[0] = new ListViewItem(new string[]
            //        {
            //                Convert.ToString(counter + 1) , //行數
            //                otoInputer[0], //Wav Name
            //                otoInputer[1], //Alias
            //                otoInputer[2], //Offsest
            //                otoInputer[3], //Consonant
            //                otoInputer[4], //Cutoff
            //                otoInputer[5], //Preutterance
            //                otoInputer[6], //Overlap
            //                aliasType //DV需要設定種類
            //        }
            //        );
            //        this.listView1.Items.AddRange(lvs);
            //        counter++;
            //    }
            //}
        }

        public void listRefresh(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {

            }
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager crm = new ComponentResourceManager(typeof(Form1));
                crm.ApplyResources(c, c.Name, new CultureInfo(lang));
                _Language = lang; //Sets the language to lang
                _ChangeLanguage = true; //Indicates that the void needs to be called through the TWO other forms as well
            }
        }
    }
}
