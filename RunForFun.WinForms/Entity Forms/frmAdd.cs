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
    public partial class frmAdd : Form
    {
        MovieBO mb = new MovieBO();
        public frmAdd()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtpicture.Text = openFileDialog1.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie m = new Movie
            {
                Name = txtName.Text,
                Starring = rtxtStars.Text,
                Director = txtDirector.Text,
                Country = txtCountry.Text,
                Imdb = txtImdb.Text,
                ReleaseDate = dateTimePicker1.Value,
                RunningTime = txtRTime.Text,
                Type = txtType.Text,
                VideoSite = txtVSite.Text,
                Trailer = txtTrailer.Text,
                Picture = txtpicture.Text
            };
            if (mb.Insert(m))
            {
                MessageBox.Show("New movie registration successful");
            }
            else
            {
                MessageBox.Show("Incorrect operation! Check your transactions.");
            }
            this.Hide();
        }

        private void btnVideoSite_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtVSite.Text = openFileDialog1.FileName;
        }

        private void btnTrailer_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtTrailer.Text = openFileDialog1.FileName;
        }

        private void btnpic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtpicture.Text = openFileDialog1.FileName;
        }

        
    }
}
