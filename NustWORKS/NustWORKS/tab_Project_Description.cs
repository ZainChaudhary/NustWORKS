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
    public partial class tab_Project_Description : UserControl
    {
        public readonly ProjectInfo Project;
        public tab_Project_Description(ProjectInfo project)
        {
            
            

            InitializeComponent();
            Project = project;
            lblTitle.Text = project.Name;
            int budget = project.Budget;
            lblPrice.Text = budget.ToString();
            lblMessage.Text = project.Details;
            lbltime.Text = project.Duration;
        }

        private void tab_Project_Description_Load(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void clientname_Click(object sender, EventArgs e)
        {

        }
    }
}
