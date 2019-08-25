using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oto2dvcfg
{
    public partial class FormFAR : Form
    {
        FormRule formRule = new FormRule();
        public FormFAR()
        {
            InitializeComponent();
        }
        #region Draggable form
        private bool mouseDown; //For draggble form
        private Point lastLocation;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            formRule.ShowDialog(this);
            if (FormRule.boolAdd == true)
            {
                string[] input = FormRule.sendtext.Split(',');
                ListViewItem[] lvs = new ListViewItem[1];
                lvs[0] = new ListViewItem(new string[]
                    {
                    input[0],
                    input[1],
                    input[2],
                    });
                listView1.Items.AddRange(lvs);
                FormRule.SetAdd2false();
            }
            else
            {

            }
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1 && listView1.SelectedItems.Count > 0)
            {
                FormRule.editMode = true;
                FormRule.ruleName = listView1.SelectedItems[0].SubItems[0].Text;
                FormRule.ruleFind = listView1.SelectedItems[0].SubItems[1].Text;
                FormRule.ruleReplace = listView1.SelectedItems[0].SubItems[2].Text;
                formRule.ShowDialog(this);
                string[] input = FormRule.sendtext.Split(',');
                listView1.SelectedItems[0].SubItems[0].Text = input[0];
                listView1.SelectedItems[0].SubItems[1].Text = input[1];
                listView1.SelectedItems[0].SubItems[2].Text = input[2];
                FormRule.editMode = false;
                FormRule.SetAdd2false();
            }
            else if (listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("You can only select one rule to edit", "~~>_<~~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }
        }

        private void NfcButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NfcButton1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count >= 1)
            {
                StreamWriter writeTmp = new StreamWriter(File.OpenWrite("FindAndReplace.tmp"), Encoding.Default);

                foreach (ListViewItem item in listView1.Items)
                {
                    writeTmp.WriteLine(item.SubItems[0].Text + "," + item.SubItems[1].Text + "," + item.SubItems[2].Text);
                }
                writeTmp.Flush();
                writeTmp.Close();
                Close();
            }
            else
            {
                Close();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count >= 1)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Template file|*.txt";
                saveFileDialog1.Title = "Save template file";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writeTemplate = new StreamWriter(File.OpenWrite(saveFileDialog1.FileName), Encoding.Default);
                    foreach (ListViewItem item in listView1.Items)
                    {
                        writeTemplate.WriteLine(item.SubItems[0].Text + "," + item.SubItems[1].Text + "," + item.SubItems[2].Text);
                    }
                    writeTemplate.Flush();
                    writeTemplate.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {

            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            string line = String.Empty;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Template file|*.txt";
            openFileDialog1.Title = "Open template file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();
                StreamReader readTemplate = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                while ((line = readTemplate.ReadLine()) != null)
                {
                    string[] input = line.Split(',');
                    ListViewItem[] lvs = new ListViewItem[1];
                    lvs[0] = new ListViewItem(new string[]
                        {
                            input[0],
                            input[1],
                            input[2],
                        });
                    listView1.Items.AddRange(lvs);
                }
                readTemplate.Close();
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }
        }

        private void FormFAR_Load(object sender, EventArgs e)
        {
            if (File.Exists("FindAndReplace.tmp"))
            {
                string line = String.Empty;
                StreamReader readTMP = new StreamReader("FindAndReplace.tmp", Encoding.Default);
                while ((line = readTMP.ReadLine()) != null && line != String.Empty)
                {
                    string[] input = line.Split(',');
                    ListViewItem[] lvs = new ListViewItem[1];
                    lvs[0] = new ListViewItem(new string[]
                        {
                            input[0],
                            input[1],
                            input[2],
                        });
                    listView1.Items.AddRange(lvs);
                }
                readTMP.Close();
            }
        }
    }
}
