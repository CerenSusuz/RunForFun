using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunForFun.WinForms.Entity_Forms
{
    public partial class frmWatch : Form
    {
        public string WebSite { get; set; }
        public frmWatch(string webSite)
        {
            InitializeComponent();
            WebSite = webSite;
        }

        private void frmWatch_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = WebSite;

        }

        private void frmWatch_FormClosing(object sender, FormClosingEventArgs e)
        {

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            DialogResult dr = MessageBox.Show("Are you sure to exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Application.ExitThread();
            }
        }
    }
}
