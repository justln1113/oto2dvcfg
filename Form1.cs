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
        public static string sendtext = String.Empty; //This variable will be sent to formPreview when buttonGenerate click
        private bool mouseDown; //For draggble form
        private Point lastLocation;
        public NFCButton openOTO;
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
        public Form1()
        {
            InitializeComponent();
            this.listView1.FullRowSelect = true;
            this.listView1.Scrollable = true;
            this.listView1.MultiSelect = true;

            #region Add button "open OTO"
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
            #endregion

            #region Close button properties
            buttonClose.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            buttonClose.FlatAppearance.CheckedBackColor = Color.Transparent;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            #endregion
        }

        private void ComboLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectLang = comboLang.SelectedItem.ToString();
            if (SelectLang == "English")
            {
                ChangeLanguage("en");
            }
            else if(SelectLang == "繁體中文")
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

        #region Right click menu
        private void ToolStripMenuItemTurn2INDLE_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectItem in listView1.SelectedItems)
            {
                selectItem.SubItems[8].Text = "INDLE";
            }
        }

        private void ToolStripMenuItemTurn2CV_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectItem in listView1.SelectedItems)
            {
                selectItem.SubItems[8].Text = "CV";
            }
        }

        private void ToolStripMenuItemTurn2VX_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectItem in listView1.SelectedItems)
            {
                selectItem.SubItems[8].Text = "VX";
            }
        }
        #endregion

        private void NfcButton1_Click(object sender, EventArgs e)
        {
            FormFAR formFAR = new FormFAR();
            formFAR.ShowDialog(this);
            foreach (ListViewItem eachItem in listView1.Items)
            {
                eachItem.SubItems[10].Text = otoReader.FindAndReplace(eachItem.SubItems[2].Text);
                eachItem.SubItems[9].Text = otoReader.FindAndReplace(eachItem.SubItems[9].Text);
            }
        }

        private void CheckHI2RO_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.Items)
            {
                if (!String.IsNullOrEmpty(eachItem.SubItems[9].Text))
                {
                    string changerA = eachItem.SubItems[2].Text;
                    string changerB = eachItem.SubItems[9].Text;
                    eachItem.SubItems[9].Text = changerA;
                    eachItem.SubItems[2].Text = changerB;
                    changerA = String.Empty; changerB = String.Empty;
                }
                else
                {

                }
            }
        }

        private void CheckFARpreview_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.Items)
            {
                eachItem.SubItems[10].Text = otoReader.FindAndReplace(eachItem.SubItems[2].Text);
            }
            foreach (ListViewItem eachItem in listView1.Items)
            {
                if (!String.IsNullOrEmpty(eachItem.SubItems[10].Text))
                {
                    string changerA = eachItem.SubItems[2].Text;
                    string changerB = eachItem.SubItems[10].Text;
                    eachItem.SubItems[10].Text = changerA;
                    eachItem.SubItems[2].Text = changerB;
                    changerA = String.Empty; changerB = String.Empty;
                }
                else
                {

                }
            }
        }

        private void ToolStripMenuItemCopyAlias_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Clipboard.SetText(listView1.SelectedItems[0].SubItems[2].Text);
            }
            else
            {
                string copy = String.Empty;
                List<string> copys = new List<string>();
                foreach (ListViewItem eachItem in listView1.SelectedItems)
                {
                    copys.Add(eachItem.SubItems[2].Text);
                }
                for (int counter = 0; counter < listView1.SelectedItems.Count; counter++)
                {
                    copy = copys.ToArray()[counter];
                }
                Clipboard.SetText(copy.Remove(copy.Length - 1));
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (File.Exists("FindAndReplace.tmp"))
            {
                File.Delete("FindAndReplace.tmp");
            }
            this.Close();
        }

        public void ButtonGenerate_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 1)
            {

            }
            int counter;
            string wavFolder;
            if (!String.IsNullOrEmpty(textOTOpath.Text))
            {
               wavFolder  = textOTOpath.Text.Remove(textOTOpath.Text.LastIndexOf(@"\") + 1); //For detaction
            }
            else
            {
                MessageBox.Show("OTO path is empty!", "ヽ(*。>Д<)o゜", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string wavPath = String.Empty; //For send text
            if (textOTOpath.Text.Length > 0)
            {
                StreamReader otoSRE = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default);
                string calcType = String.Empty;

                #region Calculation method detection
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
                #endregion

                #region List registration
                List<string> aliasList = new List<string>();
                List<string> aliasTypeList = new List<string>();
                List<string> wavNameList = new List<string>();
                List<string> offsetList = new List<string>();
                List<string> consonantList = new List<string>();
                List<string> cutoffList = new List<string>();
                List<string> preutteranceList = new List<string>();
                List<string> overlapList = new List<string>();
                #endregion

                #region Save list view item to arrays
                for (counter = 0; counter < listView1.Items.Count; counter++)
                {
                    wavNameList.Add(listView1.Items[counter].SubItems[1].Text);
                    wavName = wavNameList.ToArray();

                    #region alias list
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
                    #endregion

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
                #endregion


                //Attention
                #region Does file exists?
                int ExistsFileCount = new int();
                int fileCount = new int();
                //Exists files count
                foreach (string wavName in wavName)
                {
                    if (File.Exists(wavFolder + wavName))
                    {
                        ExistsFileCount++;
                    }
                    else
                    {

                    }
                    fileCount++;
                }
                if (ExistsFileCount > fileCount / 2)
                {
                    wavPath = wavFolder;
                    foreach (string wavName in wavName)
                    {
                        if (File.Exists(wavFolder + wavName))
                        {

                        }
                        else
                        {
                            MessageBox.Show("\"" + wavName + "\" " + "does not exists, do you want to continue?", "＞︿＜", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    folderBrowserDialog1.Description = "Please select your wav file folder.";
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
                #endregion //

                string[] output = FormPreview.dvcfgWriter
                    (
                        wavPath, 
                        calcType, 
                        aliasType, 
                        wavName, 
                        alias, offset, 
                        consonant, 
                        cutoff, 
                        preutterance, 
                        overlap, 
                        listView1.Items.Count - 1, 
                        textPitch.Text
                    );

                sendtext = String.Empty;
                foreach (string s in output)
                {
                    sendtext += s;
                }
                FormPreview formPreview = new FormPreview();
                formPreview.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("OTO path is empty!", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                openFileDialog1.Filter = "UTAU voicebank config file|oto.ini|INI file (*.ini)|*.ini|All files(*.*)|*.*"; //新增開啟檔案視窗

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
                                        otoInputer[1],
                                        otoReader.FindAndReplace(OtoInput(line)[1])
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
