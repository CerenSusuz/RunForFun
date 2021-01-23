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
    public partial class frmMovies : Form
    {
        MovieBO mb = new MovieBO();
        Movie m = new Movie();
        public Movie SelectedMovie { get; set; }
        public frmMovies(LoginType type)
        {
            InitializeComponent();
            if (type == LoginType.Employee)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            var list = mb.GetList();
            var newList = list.Where(x => x.Name.ToLower().Contains(searchText)).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = newList;
        }

        private void frmMovies_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mb.GetList();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mb.GetList();
        }

        private void frmMovies_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1, new Point(e.Location.X, e.Location.Y - contextMenuStrip1.Height));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SelectedMovie.VideoSite = txtURL.Text;
            SelectedMovie.Trailer = txttrailer.Text;
            SelectedMovie.Picture = txtpicture.Text;
            pictureBox1.ImageLocation = SelectedMovie.Picture;
            SelectedMovie.VideoSite = txtURL.Text;
            if (mb.Update(SelectedMovie))
            {
                MessageBox.Show("Edit OK!");
            }
            else
            {
                MessageBox.Show("Error...");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedMovie = dataGridView1.Rows[e.RowIndex].DataBoundItem as Movie;
            txttrailer.Text = SelectedMovie.Trailer;
            txtURL.Text = SelectedMovie.VideoSite;
            pictureBox1.ImageLocation = SelectedMovie.Picture;
            axWindowsMediaPlayer1.URL = SelectedMovie.Trailer;
            txtpicture.Text = SelectedMovie.Picture;
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
                        var s = rows[i].DataBoundItem as Movie;
                        if (mb.Delete(s.Id))
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie m = new Movie
            {
                
            };
            if (mb.Insert(m))
            {
                MessageBox.Show("Adding OK boss");
            }
            else
            {
                MessageBox.Show("Incorrect operation! Check your transactions.");
            }

        }

        private void addMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd frm = new frmAdd();
            frm.ShowDialog();
        }

        

        private void btnWatch_Click(object sender, EventArgs e)
        {
            if (txtURL.Text == "")
            {
                MessageBox.Show("There is no movie in here.");
            }
            txtURL.Text = SelectedMovie.VideoSite;
            frmWatch frm = new frmWatch(txtURL.Text);
            frm.ShowDialog();
        }

        private void solveQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuiz frm = new frmQuiz();
            frm.ShowDialog();
        }
    }
}
