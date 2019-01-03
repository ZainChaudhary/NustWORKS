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
        public readonly Dashboard Dashboard;
        public projectbox_Available_Projects(Dashboard dashboard,ProjectInfo project)
        {
            Project = project;
            Dashboard = dashboard;
            InitializeComponent();
            lblTitle.Text = project.Name;
            int budget = project.Budget;
            lblPrice.Text = budget.ToString();
            lblMessage.Text = project.Details;

            int projid = project.ProjectId;
        }

        private void projectbox_Available_Projects_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                Server.AcceptProject(Project.ProjectId, Project.Client, "WORKING", "NONE");
                ((Panel)Parent).Controls.Remove(this);
            }
            catch
            {
                MessageBox.Show("Fail to accept project!");
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                Dashboard.ShowTab(new tab_View_Others_Profile(Server.GetUser(Project.Client)));
            }
            catch
            {
                MessageBox.Show("Unable to view profile.");
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                Dashboard.ShowTab(new tab_Project_Description(Project));
            }
            catch
            {
                MessageBox.Show("Unable to view profile.");
            }
        }
    }
}
