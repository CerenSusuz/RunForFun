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

namespace RunForFun.WinForms.Main_Forms
{
    public partial class frmForgot : Form
    {
        public frmForgot()
        {
            InitializeComponent();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Waiting...");
            UserBO ub = new UserBO();
            if (ub.ForgotPassword(txtEmail.Text))
            {
                MessageBox.Show("Mail sent! Please check your email");
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no account like that");
            }
        }
    }
}
