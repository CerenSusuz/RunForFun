using RunForFun.Business.RunForFunBO;
using RunForFun.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunForFun.WinForms.Main_Forms
{
    public partial class frmNewAccount : Form
    {
        UserBO ub = new UserBO();
        public frmNewAccount()
        {
            InitializeComponent();
        }
        private void btnPicAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtpic.Text = openFileDialog1.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ApplicationUser au = new ApplicationUser
            {
                FullName = txtFName.Text,
                UserName = txtUName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                BirthDate = dateTimePickerBD.Value,
                Picture = txtpic.Text
            };
            if (ub.Insert(au))
            {
                MessageBox.Show("New account registration successful");
            }
            else
            {
                MessageBox.Show("Incorrect operation! Check your transactions.");
            }
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void frmNewAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmWelcome frm = new frmWelcome();
            frm.ShowDialog();
        }
    }
}
