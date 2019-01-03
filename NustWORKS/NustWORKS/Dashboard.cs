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
        /// <summary>
        /// Event of TextBox
        /// </summary>
        void Enter1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search Project")
            {
                textBox1.Text = string.Empty;
            }
        }
        void Leave1(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "Search Project";
            }
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
            ShowTab(new tab_MY_Projects(this, tab_MY_Projects.ProjectType.My));

        }

        private void tab_MY_Projects1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTab(new tab_View_Profile());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowTab(new tab_MY_Projects(this, tab_MY_Projects.ProjectType.Working));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowTab(new tab_Add_Project());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ShowTab(Control Tab)
        {
            panel7.Controls.Add(Tab);
            Tab.Dock = DockStyle.Fill;
            Tab.BringToFront();
        }

        private void textbox1_click(object sender, EventArgs e)
        {
            ShowTab(new tab_MY_Projects(this, tab_MY_Projects.ProjectType.Others));
        }
    }
}
