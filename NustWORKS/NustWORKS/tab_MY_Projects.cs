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
        public static tab_MY_Projects _instance;
        public static tab_MY_Projects Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new tab_MY_Projects();
                return _instance;

            }
        }
        public tab_MY_Projects()
        {
            InitializeComponent();

        }

        private void tab_MY_Projects_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void populateItems()
        {
            //populating it here
            projectbox[] projectboxes = new projectbox[20];
            //looping through each item
            for (int i = 0; i < projectboxes.Length; i++)
            {
                projectboxes[i] = new projectbox();
                projectboxes[i].Width = flowLayoutPanel1.Width;
                projectboxes[i].Icon = Resources.user2_64;
                projectboxes[i].IconBackground = Color.White;
                projectboxes[i].Title = "Get some Title";
                projectboxes[i].Message = "Get the Description of the Project";
                projectboxes[i].Price = "RS XX/-";

                //add the flow layout
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(projectboxes[i]);

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
