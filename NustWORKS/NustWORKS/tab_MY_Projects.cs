using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NustWORKS.Properties;

namespace NustWORKS
{
    public partial class tab_MY_Projects : UserControl
    {
        public readonly Dashboard Dashboard;
        public readonly ProjectType Type;
        public tab_MY_Projects(Dashboard dashboard, ProjectType type)
        {
            InitializeComponent();
            this.Dashboard = dashboard;
            this.Type = type;
        }

        private void tab_MY_Projects_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            if (Type == ProjectType.My)
            {
                var projects = Server.GetMyProjects();
                foreach (var proj in projects)
                    flowLayoutPanel1.Controls.Add(new projectbox_My_Projects(Dashboard,proj));
            }
            else if (Type == ProjectType.Others)
            {
                var projects = Server.GetAvailableProjects();
                foreach (var proj in projects)
                    flowLayoutPanel1.Controls.Add(new projectbox_Available_Projects(Dashboard,proj));
            }
            else
            {
                var projects = Server.GetWorkingProjects();
                foreach (var proj in projects)
                    flowLayoutPanel1.Controls.Add(new projectbox_Working_Projects(Dashboard,proj));
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public enum ProjectType
        {
            My,
            Others,
            Working
        }
    }
}
