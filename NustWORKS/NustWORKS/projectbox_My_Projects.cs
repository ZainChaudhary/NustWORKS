using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NustWORKS
{
    public partial class projectbox_My_Projects : UserControl
    {
        public readonly ProjectInfo Project;
        public projectbox_My_Projects(ProjectInfo project)
        {
            InitializeComponent();
            Project = project;
            lblTitle.Text = project.Name;
            int budget = project.Budget;
            lblPrice.Text = budget.ToString();
            lblMessage.Text = project.Details;

            int projid = project.ProjectId;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void lblBudget_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void projectbox_My_Projects_Load(object sender, EventArgs e)
        {

        }
    }
}
