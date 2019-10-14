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
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
            //while (Form1.LoadingPerCentSend < 1)
            //{
            //    panelLoad.Width = Convert.ToInt32(461 * Form1.LoadingPerCentSend);
            //}
        }
        private void FormLoading_Load(object sender, EventArgs e)
        {
            
        }
        public static void PCrefresh()
        {
            //461
            
            //Console.WriteLine(Form1.LoadingPerCentSend);
        }
    }
}
