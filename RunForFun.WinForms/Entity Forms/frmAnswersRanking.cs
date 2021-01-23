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

namespace RunForFun.WinForms.Entity_Forms
{
    public partial class frmAnswersRanking : Form
    {
        QuizBO qb = new QuizBO();
        public frmAnswersRanking()
        {
            InitializeComponent();
        }

        private void frmAnswersRanking_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = qb.GetList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var searchText = textBox1.Text.ToLower();
            var movie = qb.GetList();
            var newList = movie.Where(x => x.Name.ToLower().Contains(searchText)).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = qb.GetList();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = qb.GetList();
        }

        private void frmAnswersRanking_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(new Point(e.Location.X, e.Location.Y - contextMenuStrip1.Height));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
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
                        var s = rows[i].DataBoundItem as Quiz;
                        QuizBO au = new QuizBO();
                        if (au.Delete(s.Id))
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
    }
}
