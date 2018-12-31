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
    public partial class projectbox_Available_Projects : UserControl
    {
        public readonly ProjectInfo Project;
        public projectbox_Available_Projects(ProjectInfo project)
        {
            Project = project;
            lblTitle.Text = project.Name;
            int budget = project.Budget;
            lblPrice.Text = budget.ToString("B");
            lblMessage.Text = project.Details;

            int projid = project.ProjectId;

            InitializeComponent();
        }

        private void projectbox_Available_Projects_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
        }
    }
}
