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
using NAudio;
using NAudio.Wave;
using UTAUVoiceBankConfig;

namespace oto2dvcfg
{
    public partial class Form1 : Form
    {
        public static bool _ChangeLanguage = false; //This will indicate if the void needs to be called
        public static string _Language = ""; //This will indicate our new language
        public static string sendtext = String.Empty; //This variable will be sent to formPreview when buttonGenerate click
        public static Double LoadingPerCentSend = 0;
        private bool mouseDown; //For draggble form
        private Point lastLocation;//For draggble form
        public bool hiroChecked = false;
        public NFCButton openOTO;
        public static FormLoading formLoading = new FormLoading();
        #region For undo redo function
        private List<object> StateList = new List<object>();
        private int Index = 0;
        #endregion
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
            listView1.FullRowSelect = true;
            listView1.Scrollable = true;
            listView1.MultiSelect = true;
            #region undo redo setup
            var InitialState = new object();
            StateList.Add(InitialState);
            #endregion

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

            dvcfgCalculator DC = new dvcfgCalculator();
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
                selectItem.SubItems[8].Text = "INDIE";
                if (checkHI2RON.Checked == true)
                {
                    selectItem.SubItems[11].Text = otoReader.hi2ron(otoReader.FindAndReplace(selectItem.SubItems[12].Text), selectItem.SubItems[8].Text);
                    if (!String.IsNullOrEmpty(selectItem.SubItems[11].Text))
                    {
                        selectItem.SubItems[2].Text = selectItem.SubItems[11].Text;
                    }
                }
            }
        }

        private void ToolStripMenuItemTurn2CV_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectItem in listView1.SelectedItems)
            {
                selectItem.SubItems[8].Text = "CV";
                if (checkHI2RON.Checked == true)
                {
                    selectItem.SubItems[11].Text = otoReader.hi2ron(otoReader.FindAndReplace(selectItem.SubItems[12].Text), selectItem.SubItems[8].Text);
                    if (!String.IsNullOrEmpty(selectItem.SubItems[11].Text))
                    {
                        selectItem.SubItems[2].Text = selectItem.SubItems[11].Text;
                    }
                }
            }
        }

        private void ToolStripMenuItemTurn2VX_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectItem in listView1.SelectedItems)
            {
                selectItem.SubItems[8].Text = "VX";
                if (checkHI2RON.Checked == true)
                {
                    selectItem.SubItems[11].Text = otoReader.hi2ron(otoReader.FindAndReplace(selectItem.SubItems[12].Text), "VX");
                    if (!String.IsNullOrEmpty(selectItem.SubItems[11].Text))
                    {
                        selectItem.SubItems[2].Text = selectItem.SubItems[11].Text;
                    }
                }
            }
        }
        #endregion

        private void CheckHI2RO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHI2RO.Checked == true && checkHI2RON.Checked == true)
            {
                checkHI2RON.Checked = false;
                hiroChecked = true;
            }

            if (checkHI2RO.Checked == true && checkFARpreview.Checked == true)
            {
                hiroChecked = true;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[9].Text = otoReader.hi2ro(otoReader.FindAndReplace(eachItem.SubItems[12].Text));
                    if (!String.IsNullOrEmpty(eachItem.SubItems[9].Text))
                    {
                        eachItem.SubItems[2].Text = eachItem.SubItems[9].Text;
                    }
                }
            }
            else if (checkHI2RO.Checked == true && checkFARpreview.Checked == false)
            {
                hiroChecked = true;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[9].Text = otoReader.hi2ro(eachItem.SubItems[12].Text);
                    if (!String.IsNullOrEmpty(eachItem.SubItems[9].Text))
                    {
                        eachItem.SubItems[2].Text = eachItem.SubItems[9].Text;
                    }
                }
            }
            else if (checkHI2RO.Checked == false && checkFARpreview.Checked == true)
            {
                hiroChecked = false;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[2].Text = otoReader.FindAndReplace(eachItem.SubItems[12].Text);
                }
            }
            else if (checkHI2RO.Checked == false && checkFARpreview.Checked == false)
            {
                hiroChecked = false;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[2].Text = eachItem.SubItems[12].Text;
                }
            }
        }

        private void CheckFARpreview_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFARpreview.Checked == true && hiroChecked == false)
            {
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[10].Text = otoReader.FindAndReplace(eachItem.SubItems[12].Text);
                    if (!String.IsNullOrEmpty(eachItem.SubItems[10].Text))
                    {
                        eachItem.SubItems[2].Text = eachItem.SubItems[10].Text;
                    }
                }
            }
            else if (checkFARpreview.Checked == true && checkHI2RO.Checked == true)
            {
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[10].Text = otoReader.FindAndReplace(otoReader.hi2ro(eachItem.SubItems[12].Text));
                    if (!String.IsNullOrEmpty(eachItem.SubItems[10].Text))
                    {
                        eachItem.SubItems[2].Text = eachItem.SubItems[10].Text;
                    }
                }
            }
            else if (checkFARpreview.Checked == true && checkHI2RON.Checked == true)
            {
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[10].Text = otoReader.FindAndReplace(otoReader.hi2ron(eachItem.SubItems[12].Text, eachItem.SubItems[8].Text));
                    if (!String.IsNullOrEmpty(eachItem.SubItems[10].Text))
                    {
                        eachItem.SubItems[2].Text = eachItem.SubItems[10].Text;
                    }
                }
            }
            else if (checkFARpreview.Checked == false && hiroChecked == false)
            {
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[2].Text = eachItem.SubItems[12].Text;
                }
            }
            else if (checkFARpreview.Checked == false && checkHI2RO.Checked == true)
            {
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[2].Text = eachItem.SubItems[9].Text;
                }
            }
            else if (checkFARpreview.Checked == false && checkHI2RON.Checked == true)
            {
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[2].Text = eachItem.SubItems[11].Text;
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

        private void CheckHI2ROn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHI2RON.Checked == true && checkHI2RO.Checked == true)
            {
                checkHI2RO.Checked = false;
            }
            if (checkHI2RON.Checked == true && checkFARpreview.Checked == true)
            {
                hiroChecked = true;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[11].Text = otoReader.hi2ron(otoReader.FindAndReplace(eachItem.SubItems[12].Text), eachItem.SubItems[8].Text);
                    if (!String.IsNullOrEmpty(eachItem.SubItems[11].Text))
                    {
                        eachItem.SubItems[2].Text = eachItem.SubItems[11].Text;
                    }
                }
            }
            else if (checkHI2RON.Checked == true && checkFARpreview.Checked == false)
            {
                hiroChecked = true;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[11].Text = otoReader.hi2ron(eachItem.SubItems[12].Text, eachItem.SubItems[8].Text);
                    if (!String.IsNullOrEmpty(eachItem.SubItems[9].Text))
                    {
                        eachItem.SubItems[2].Text = eachItem.SubItems[11].Text;
                    }
                }
            }
            else if (checkHI2RON.Checked == false && checkFARpreview.Checked == true)
            {
                hiroChecked = false;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[2].Text = otoReader.FindAndReplace(eachItem.SubItems[12].Text);
                }
            }
            else if (checkHI2RON.Checked == false && checkFARpreview.Checked == false)
            {
                hiroChecked = false;
                foreach (ListViewItem eachItem in listView1.Items)
                {
                    eachItem.SubItems[2].Text = eachItem.SubItems[12].Text;
                }
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (File.Exists("FindAndReplace.tmp"))
            {
                File.Delete("FindAndReplace.tmp");
            }
            formLoading.Close();
            this.Close();
        }

        public void ButtonGenerate_Click(object sender, EventArgs e)
        {
            formLoading.Show();
            formLoading.Update();
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
                formLoading.Hide();
                return;
            }
            if (string.IsNullOrEmpty(textPitch.Text))
            {
                MessageBox.Show("Pitch is empty!", "ヽ(*。>Д<)o゜", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                formLoading.Hide();
                return;
            }
            string wavPath = String.Empty; //For send text
            if (textOTOpath.Text.Length > 0)
            {
                StreamReader otoSRE = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default);
                string calcType = String.Empty;

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
                wavPath = wavFolder;
                string[] output = FormPreview.dvcfgWriter
                    (
                        wavPath, 
                        aliasType, 
                        wavName, 
                        alias, 
                        offset, 
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
                formLoading.Hide();
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
                        formLoading.Show();
                        formLoading.Update();
                        textOTOpath.Text = openFileDialog1.FileName; //取得開啟的檔案路徑
                        string otoPath = textOTOpath.Text;
                        if (otoReader.lineCount(otoPath) - 2 < 0)
                        {
                            MessageBox.Show("oto file is empty.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            formLoading.Hide();
                        }
                        else
                        {
                            List<string> lines = new List<string>();
                            List<string> wavNameList = new List<string>();
                            string line;
                            int counter = 0;
                            float LoadingLine = 0;
                            float LoadingPerCent = 0;

                            labelOTOint.Text = Convert.ToString(otoReader.lineCount(otoPath));
                            
                            OTO oto = new OTO();
                            oto.Load(textOTOpath.Text);

                            for (int i = 0; i < oto.lineCount; i++)
                            {
                                ListViewItem[] lvs = new ListViewItem[1];
                                string hi2ro = string.Empty;
                                string aliasType = otoReader.get_aliasType(oto.otoMap[i].Alias);
                                lvs[0] = new ListViewItem(new string[]
                                    {
                                        (i + 1).ToString(),
                                        oto.otoMap[i].File,
                                        oto.otoMap[i].Alias,
                                        oto.otoMap[i].Offset.ToString(),
                                        oto.otoMap[i].Consonant.ToString(),
                                        oto.otoMap[i].Cutoff.ToString(),
                                        oto.otoMap[i].Preutter.ToString(),
                                        oto.otoMap[i].Overlap.ToString(),
                                        aliasType,
                                        otoReader.hi2ro(oto.otoMap[i].Alias),
                                        otoReader.FindAndReplace(oto.otoMap[i].Alias),
                                        otoReader.hi2ron(oto.otoMap[i].Alias, aliasType),
                                        oto.otoMap[i].Alias
                                    }
                                    );
                                listView1.Items.AddRange(lvs);
                            }

                            #region old
                            //StreamReader otoSR = new StreamReader(textOTOpath.Text, System.Text.Encoding.Default); //給ReadLine使用的Reader
                            //while ((line = otoSR.ReadLine()) != null)
                            //{
                            //    string[] otoInputer = OtoInput(line); //輸入一條oto設定進otoSpliter方法
                            //    if (otoInputer.Length < 7)
                            //    {
                            //        MessageBox.Show("Wrong oto format.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            //        formLoading.Hide();
                            //        return;
                            //    }
                            //    else
                            //    {
                            //        LoadingPerCent = LoadingLine / (otoReader.lineCount(otoPath));
                            //        string hi2ro = string.Empty;
                            //        aliasType = otoReader.get_aliasType(otoInputer[1]);
                            //        ListViewItem[] lvs = new ListViewItem[1];
                            //        lvs[0] = new ListViewItem(new string[]
                            //        {
                            //            Convert.ToString(counter + 1) , //行數
                            //            otoInputer[0], //Wav Name
                            //            otoInputer[1], //Alias
                            //            otoInputer[2], //Offsest
                            //            otoInputer[3], //Consonant
                            //            otoInputer[4], //Cutoff
                            //            otoInputer[5], //Preutterance
                            //            otoInputer[6], //Overlap
                            //            aliasType, //DV需要設定種類
                            //            otoReader.hi2ro(otoInputer[1]),
                            //            otoReader.FindAndReplace(otoInputer[1]),
                            //            otoReader.hi2ron(otoInputer[1], aliasType),
                            //            otoInputer[1]
                            //        }
                            //        );
                            //        listView1.Items.AddRange(lvs);
                            //        counter++;
                            //        LoadingLine++;
                            //        //Console.WriteLine(Math.Round(LoadingPerCent, 3, MidpointRounding.AwayFromZero) * 100 + "%");
                            //        LoadingPerCentSend = Math.Round(LoadingPerCent, 3, MidpointRounding.AwayFromZero);
                            //        FormLoading.PCrefresh();
                            //        formLoading.Refresh();
                            //        formLoading.Update();
                            //    }
                            //}
                            //otoSR.Close();
                            #endregion

                            for (counter = 0; counter < listView1.Items.Count; counter++)
                            {
                                wavNameList.Add(listView1.Items[counter].SubItems[1].Text);
                                wavName = wavNameList.Distinct().ToArray();
                            }

                            #region Does wav file exists?
                            string wavFolder = string.Empty;
                            string wavPath = string.Empty;
                            bool WavDoesnotExists = false;
                            FormWavDoesnotExists formWavDoesnotExists = new FormWavDoesnotExists();
                            if (!string.IsNullOrEmpty(textOTOpath.Text))
                            {
                                wavFolder = textOTOpath.Text.Remove(textOTOpath.Text.LastIndexOf(@"\") + 1); //For detaction
                            }
                            wavPath = wavFolder;
                            foreach (string wavName in wavName)
                            {
                                if (File.Exists(wavFolder + wavName))
                                {

                                }
                                else
                                {
                                    WavDoesnotExists = true;
                                    FormWavDoesnotExists.notExistsList.Add(wavName);
                                }
                            }
                            if (WavDoesnotExists == true)
                            {
                                formWavDoesnotExists.ShowDialog();
                                listView1.Items.Clear();
                                errorMessageInListView();
                            }
                            #endregion
                        }
                        formLoading.Hide();
                    }
                    else
                    {
                        errorMessageInListView();
                    }
                }
                else
                {
                    MessageBox.Show("OTO file not exists.", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    formLoading.Hide();
                    errorMessageInListView();
                }
            }

        }

        private void Button1_Click(object sender, EventArgs e) //Undo Redo test
        {
            Edit();
            string output = String.Empty;
            string checkHI2RObool = String.Empty;
            string checkHI2RONbool = String.Empty;
            string FARbool = String.Empty;
            if (checkHI2RO.Checked == true)
            {
                checkHI2RObool = "true";
            }
            else if (checkHI2RON.Checked == true)
            {
                checkHI2RONbool = "true";
            }
            else if (hiroChecked == false)
            {
                checkHI2RObool = "false";
                checkHI2RONbool = "false";
            }
            if (checkFARpreview.Checked == true)
            {
                FARbool = "true";
            }
            else
            {
                FARbool = "false";
            }
            foreach (ListViewItem item in listView1.Items)
            {
                StateList[Index] += 
                    item.SubItems[0].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," + 
                    item.SubItems[1].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[2].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[3].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[4].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[5].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[6].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[7].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[8].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[9].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[10].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "," +
                    item.SubItems[11].Text.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "\n";
            }
            Console.WriteLine(StateList[Index]);
            Console.WriteLine(checkHI2RObool + "," + checkHI2RONbool + "," + FARbool);
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            string wavPath = textOTOpath.Text.Remove(textOTOpath.Text.LastIndexOf(@"\") + 1);
            WaveOutEvent waveOut = new WaveOutEvent();
            WaveFileReader waveFileReader = new WaveFileReader(wavPath + listView1.SelectedItems[0].SubItems[1].Text);
            waveOut.Init(waveFileReader);
            waveOut.Play();
        }
        private void errorMessageInListView()
        {
            //ListViewItem[] lvs = new ListViewItem[5];
            //lvs[0] = new ListViewItem(new string[] { "", "放棄啦！" });
            //lvs[1] = new ListViewItem(new string[] { "", "不幹啦！ " });
            //lvs[2] = new ListViewItem(new string[] { "", "讀個oto累死啦～" });
            //lvs[3] = new ListViewItem(new string[] { "", "跟你要了檔案你又不給" });
            //lvs[4] = new ListViewItem(new string[] { "", "是要列個啥(╯°□°）╯︵ ┻━┻" });

            //this.listView1.Items.AddRange(lvs);
        }

        private void buttonFindAndReplace_Click(object sender, EventArgs e)
        {
            FormFAR formFAR = new FormFAR();
            formFAR.ShowDialog(this);
            foreach (ListViewItem eachItem in listView1.Items)
            {
                eachItem.SubItems[10].Text = otoReader.FindAndReplace(eachItem.SubItems[2].Text);
                eachItem.SubItems[9].Text = otoReader.FindAndReplace(eachItem.SubItems[9].Text);
            }
        }

        public void optionChanged(object sender, EventArgs e)
        {

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

        private object State
        {
            get
            {
                return StateList[Index];
            }
            set
            {
                StateList[Index] = value;
            }
        }

        private void Redo()
        {
            if (Index < StateList.Count - 1)
            {
                Index++;
            }
        }

        private void Undo()
        {
            if (Index > 0)
            {
                Index--;
            }
        }

        private void Edit()
        {
            var NewState = new object();

            StateList.RemoveRange(Index + 1, StateList.Count - Index - 1);
            StateList.Add(NewState);
            Index++;
        }
    }
}
