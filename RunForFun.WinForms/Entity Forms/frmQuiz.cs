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
    public partial class frmQuiz : Form
    {
        public int Score { get; set; }
        
        Quiz quizer = new Quiz();
        QuizBO qb = new QuizBO();
        public frmQuiz()
        {
            InitializeComponent();
            Score = 0;
        }


        private void btnQuizResult_Click(object sender, EventArgs e)
        {
            List<RadioButton> rightradiobuttons = new List<RadioButton>();
            rightradiobuttons.Add(radioButton1);
            rightradiobuttons.Add(radioButton5);
            rightradiobuttons.Add(radioButton8);
            rightradiobuttons.Add(radioButton15);
            rightradiobuttons.Add(radioButton17);
            rightradiobuttons.Add(radioButton12);
            rightradiobuttons.Add(radioButton21);
            rightradiobuttons.Add(radioButton22);

            List<RadioButton> wrongrbuttons = new List<RadioButton>();
            wrongrbuttons.Add(radioButton10);
            wrongrbuttons.Add(radioButton2);
            wrongrbuttons.Add(radioButton3);
            wrongrbuttons.Add(radioButton4);
            wrongrbuttons.Add(radioButton6);
            wrongrbuttons.Add(radioButton7);
            wrongrbuttons.Add(radioButton9);
            wrongrbuttons.Add(radioButton11);
            wrongrbuttons.Add(radioButton13);
            wrongrbuttons.Add(radioButton14);
            wrongrbuttons.Add(radioButton16);
            wrongrbuttons.Add(radioButton18);
            wrongrbuttons.Add(radioButton19);
            wrongrbuttons.Add(radioButton20);
            wrongrbuttons.Add(radioButton23);
            wrongrbuttons.Add(radioButton24);

            foreach (var rButtons in rightradiobuttons)
            {
                if (rButtons.Checked)
                {
                    Score += 5;
                }
            }
            foreach (var rButtons in wrongrbuttons)
            {
                if (rButtons.Checked)
                {
                    Score += 0;
                }
            }
                if (Name == null)
                {
                    MessageBox.Show("Please, enter your name.");
                }
                quizer.Name = txtName.Text;
                quizer.Score = Score;
                qb.Insert(quizer);
                MessageBox.Show($"Hey {quizer.Name}, your score -> {quizer.Score} ");
            
        }
        
        private void btnQuizRank_Click(object sender, EventArgs e)
        {
            frmAnswersRanking frm = new frmAnswersRanking();
            frm.ShowDialog();
        }

        
    }
}
