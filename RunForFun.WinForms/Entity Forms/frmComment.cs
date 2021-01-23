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
using static RunForFun.Model.Constant.Enums;

namespace RunForFun.WinForms.Entity_Forms
{
    public partial class frmComment : Form
    {
        CommentBO cb = new CommentBO();
        public Comment SelectedComment { get; set; }
        public frmComment(LoginType type)
        {
            InitializeComponent();
            if (type == LoginType.Employee)
            {
                contextMenuStrip1.Visible = false;
                btnDelete.Visible = false;
                label4.Visible = false;
                txtSearch.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cb.GetList();
                btnSend.Visible = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Comment c = new Comment
            {
               UserName = txtUname.Text,
               Description = richTextBox1.Text,
               Point = txtPoint.Text
            };
            if (cb.Insert(c))
            {
                MessageBox.Show("New comment registration successful");
            }
            else
            {
                MessageBox.Show("Incorrect operation! Check your transactions.");
            }
            this.Hide();
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
                        var s = rows[i].DataBoundItem as Comment;
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cb.GetList();
        }

        private void frmComment_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(new Point(e.Location.X, e.Location.Y - contextMenuStrip1.Height));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            var movie = cb.GetList();
            var newList = movie.Where(x => x.UserName.ToLower().Contains(searchText)).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cb.GetList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedComment = dataGridView1.Rows[e.RowIndex].DataBoundItem as Comment;
            txtUname.Text = SelectedComment.UserName;
            richTextBox1.Text = SelectedComment.Description;
            txtPoint.Text = SelectedComment.Point;
        }

    }
 }

