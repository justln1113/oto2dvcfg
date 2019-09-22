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
    public partial class FormWavDoesnotExists : Form
    {
        public static List<string> notExistsList = new List<string>();
        public FormWavDoesnotExists()
        {
            InitializeComponent();
        }

        private void FormWavDoesnotExists_Load(object sender, EventArgs e)
        {
            foreach (string notExists in notExistsList)
            {
                listBox1.Items.Add(notExists);
            }
        }
    }
}
