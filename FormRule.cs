using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oto2dvcfg
{
    public partial class FormRule : Form
    {
        public static string sendtext = String.Empty;
        public static bool boolAdd = false;
        public static bool editMode = false;
        public static string ruleName = String.Empty;
        public static string ruleFind = String.Empty;
        public static string ruleReplace = String.Empty;
        public FormRule()
        {
            InitializeComponent();
        }
        private void FormRule_Load(object sender, EventArgs e)
        {
            FormRule formRule = new FormRule();
            if (editMode == true)
            {
                formRule.Text = "Edit rule";
                nfcButton1.Text = "Edit";
                textName.Text = ruleName;
                textFind.Text = ruleFind;
                textReplace.Text = ruleReplace;
            }
            else
            {
                textName.Text = String.Empty;
                textFind.Text = String.Empty;
                textReplace.Text = String.Empty;
            }
            nfcButton1.Focus();
        }

        private void NfcButton1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textFind.Text))
            {
                sendtext = textName.Text + "," + textFind.Text + "," + textReplace.Text;
                Console.WriteLine(sendtext);
                boolAdd = true;
                this.Close();
            }
            else if(String.IsNullOrEmpty(textFind.Text))
            {
                MessageBox.Show("Find text box is empty!", "ヽ（≧□≦）ノ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Invalid input!", "ヽ（≧□≦）ノ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SetAdd2false()
        {
            boolAdd = false;
        }
    }
}
