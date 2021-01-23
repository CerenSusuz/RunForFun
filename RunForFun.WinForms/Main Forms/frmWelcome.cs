using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace RunForFun.WinForms.Main_Forms
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void btnNewAc_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNewAccount frm = new frmNewAccount();
            frm.ShowDialog();
        }

        //private void frmWelcome_Load(object sender, EventArgs e)
        //{

        //    SoundPlayer sound = new SoundPlayer();
        //    sound.SoundLocation = Application.StartupPath + "\\sounds\\wahwah.wav";
        //    sound.Play();
        //}
    }
}
