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
    public partial class projectbox_Working_Projects : UserControl
    {
        public readonly ProjectInfo Project;
        public readonly Dashboard Dashboard;
        public projectbox_Working_Projects(Dashboard dashboard, ProjectInfo project)
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

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                Server.FinishProject(Project.ProjectId);
                ((Panel)Parent).Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete project!");
            }
        }

        private void projectbox_Working_Projects_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                Dashboard.ShowTab(new tab_View_Others_Profile(Server.GetUser(Project.Client)));
            }
            catch (Exception ex)
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
