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
        public readonly string Type;
        public tab_MY_Projects(string type)
        {
            InitializeComponent();

        }

        private void tab_MY_Projects_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            var projects = Server.GetMyProjects();
            foreach (var proj in projects)
                flowLayoutPanel1.Controls.Add(new projectbox_My_Projects(proj));
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
