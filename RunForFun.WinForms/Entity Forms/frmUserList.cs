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
    public partial class frmUserList : Form
    {
        UserBO ub = new UserBO();
        public ApplicationUser SelectedUser { get; set; }
        public frmUserList()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            var list = ub.GetList();
            var newList = list.Where(x => x.UserName.ToLower().Contains(searchText)).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = newList;
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
                        var s = rows[i].DataBoundItem as ApplicationUser;
                        UserBO au = new UserBO();
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ub.GetList();
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ub.GetList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedUser = dataGridView1.Rows[e.RowIndex].DataBoundItem as ApplicationUser;
            int choosen = dataGridView1.SelectedCells[0].RowIndex;
            txtpassword.Text = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            pictureBox1.ImageLocation = SelectedUser.Picture;
        }

        private void frmUserList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1, new Point(e.Location.X, e.Location.Y - contextMenuStrip1.Height));
            }
        }

        
    }
}
