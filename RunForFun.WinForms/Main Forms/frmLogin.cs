using RunForFun.Business.RunForFunBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RunForFun.Model.Constant.Enums;

namespace RunForFun.WinForms.Main_Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void linkLabelForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgot frm = new frmForgot();
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserBO ub = new UserBO();
            if (ub.Login(txtUserName.Text, txtPassword.Text))
            {
                var type = txtUserName.Text.ToLower() == "admin" ? LoginType.Administrator : LoginType.Employee;
                this.Hide();
                frmMainMenu frm = new frmMainMenu(type);
                frm.Show();
            }
            else
            {
                MessageBox.Show("There is no account like that");
            }
        }
    }
}
