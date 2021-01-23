using RunForFun.Business.RunForFunBO;
using RunForFun.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RunForFun.Model.Constant.Enums;

namespace RunForFun.WinForms.Entity_Forms
{
    public partial class frmContact : Form
    {
        ContactBO cb = new ContactBO();

        public Contact SelectedContact { get; set; }
        public frmContact(LoginType type)
        {
            InitializeComponent();
            if (type == LoginType.Employee)
            {
                dataGridView1.DataSource = null;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                txtresult.ReadOnly = true;
                contextMenuStrip1.Visible = false;
            }
            else
            {
                btnSend.Visible = false;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cb.GetList();
                btnSend.Visible = false;

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Waiting...");
            Contact cn = new Contact
            {
                UserName = txtusername.Text,
                Email = txtEmail.Text,
                Message = richTextBox1.Text,
                Result = txtresult.Text
            };
            if (cb.Insert(cn))
            {
                if (cb.SendProblem(cn))
                {
                    MessageBox.Show("Mail sent!");
                }
            }
            else
            {
                MessageBox.Show("Incorrect operation! Check your transactions.");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Waiting ...");
            SelectedContact.Result = txtresult.Text;

            if (cb.Edit(SelectedContact))
            {
                string eMail = txtEmail.Text;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("cerenprojects@gmail.com", "Gerund123.");
                MailMessage msg = new MailMessage("cerenprojects@gmail.com", eMail);
                msg.Subject = "Message of problem examined.";
                msg.IsBodyHtml = true;
                msg.Body = $"<h4>Thank you for your message, problem examined. :)</h4>";
                client.Send(msg);
                MessageBox.Show("Mail sent!");
            }
            else
            {
                MessageBox.Show("Test");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete it?", "Deleting...", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    var rows = dataGridView1.SelectedRows;
                    bool isSuccess = false;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        var s = rows[i].DataBoundItem as Contact;
                        if (cb.Delete(s.Id))
                        {
                            isSuccess = true;
                        }
                    }
                    if (isSuccess)
                    {
                        MessageBox.Show("Successful Deleting");
                    }
                    else
                    {
                        MessageBox.Show("Error...");
                    }
                }
            }
        }

        private void frmContact_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1, new Point(e.Location.X, e.Location.Y - contextMenuStrip1.Height));
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cb.GetList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedContact = dataGridView1.Rows[e.RowIndex].DataBoundItem as Contact;
            txtresult.Text = SelectedContact.Result;
            txtusername.ReadOnly = true;
            txtEmail.ReadOnly = true;
            richTextBox1.ReadOnly = true;


        }
    }
}
