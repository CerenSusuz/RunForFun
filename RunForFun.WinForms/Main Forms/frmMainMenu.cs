using RunForFun.WinForms.Entity_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RunForFun.Model.Constant.Enums;

namespace RunForFun.WinForms.Main_Forms
{
    public partial class frmMainMenu : Form
    {
        public LoginType _type { get; set; }
        public frmMainMenu(LoginType type)
        {
            InitializeComponent();
            if (type == LoginType.Employee)
            {
                adminSettingsToolStripMenuItem.Visible = false;
                _type = type;
            }
            else
            {
               menuToolStripMenuItem.Visible = false;
            }
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMovies frm = new frmMovies(_type);
            frm.ShowDialog();
        }

        private void commentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmComment frm = new frmComment(_type);
            frm.ShowDialog();
        }

        private void contactToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmContact frm = new frmContact(_type);
            frm.ShowDialog();
        }

        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComment frm = new frmComment(_type);
            frm.ShowDialog();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContact frm = new frmContact(_type);
            frm.ShowDialog();
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserList frm = new frmUserList();
            frm.ShowDialog();
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           if (dr == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

        }

        //private void frmMainMenu_Load(object sender, EventArgs e)
        //{
        //    SoundPlayer sound = new SoundPlayer();
        //    sound.SoundLocation = Application.StartupPath + "\\sounds\\pew.wav";
        //    sound.Play();

        //}
    }
}


