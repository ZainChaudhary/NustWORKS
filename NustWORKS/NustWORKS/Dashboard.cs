using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NustWORKS
{
    public partial class Dashboard : Form
    {

        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Instance = new tab_MY_Projects("My");
            panel7.Controls.Add(Instance);
            Instance.Dock = DockStyle.Fill;
            Instance.BringToFront();

        }

        private void tab_MY_Projects1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel7.Controls.Contains(tab_View_Profile.Instance))
            {
                panel7.Controls.Add(tab_View_Profile.Instance);
                tab_View_Profile.Instance.Dock = DockStyle.Fill;
                tab_View_Profile.Instance.BringToFront();
            }
            else
                tab_View_Profile.Instance.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Instance = new tab_MY_Projects("My");
            panel7.Controls.Add(Instance);
            Instance.Dock = DockStyle.Fill;
            Instance.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel7.Controls.Contains(tab_Add_Project.Instance))
            {
                panel7.Controls.Add(tab_Add_Project.Instance);
                tab_Add_Project.Instance.Dock = DockStyle.Fill;
                tab_Add_Project.Instance.BringToFront();
            }
            else
                tab_Add_Project.Instance.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
