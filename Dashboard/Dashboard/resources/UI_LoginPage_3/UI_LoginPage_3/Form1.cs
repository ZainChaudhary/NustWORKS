using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI_LoginPage_3
{
    //partial class
    public partial class Form1 : Form
    {

        //Create instance object
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        Label logreg = new Label();

        public Form1()
        {
            InitializeComponent();

            this.Size = new Size (320, 480);
            pictureBox2.Image = Properties.Resources._lock;
            pictureBox2.Enabled = false;
        }

        /// <summary>
        /// Form Load
        /// </summary>
        private void Form1Load(object sender, EventArgs e)
        {
            //Set properties
            timer1.Tick += new EventHandler(timer1_go);
            timer2.Tick += new EventHandler(timer2_go);
            timer1.Interval = 10;
            timer2.Interval = 5;
            timer1.Start();
        }

        /// <summary>
        /// Definition for timer function
        /// </summary>
        void timer1_go(object sender, EventArgs e)
        {
            Logoposition();
        }
        //
        void timer2_go(object sender, EventArgs e)
        {
            if (logreg.Text == "Register")
            {
                reg();
            }
            else if (logreg.Text == "Login")
            {
                log();
            }
        }

        /// <summary>
        /// Create animation
        /// </summary>
        int go = 1;
        #region
        //logo postion
        void Logoposition()
        {
            if(panel1.Left == 0)
            {
                pictureBox1.Top += go;
                if(pictureBox1.Top > 50)
                {
                    timer1.Stop();
                }
            }
            if(panel2.Left == 0)
            {
                pictureBox1.Top -= go;
                if(pictureBox1.Top < 34)
                {
                    timer1.Stop();
                }
            }
        }

        //line animation
        void line()
        {
            if (panel1.Left == 0)
            {
                bunifuSeparator2.LineThickness = 2;
                bunifuSeparator2.LineColor = Color.FromArgb(0, 173, 239);
                bunifuSeparator1.LineThickness = 1;
                bunifuSeparator1.LineColor = Color.Silver;
            }
            if (panel2.Left == 0)
            {
                bunifuSeparator2.LineThickness = 1;
                bunifuSeparator2.LineColor = Color.Silver;
                bunifuSeparator1.LineThickness = 2;
                bunifuSeparator1.LineColor = Color.FromArgb(0, 173, 239);
            }
        }

        //slide panel
        int move_speed = 20;
        void reg()
        {
            if (panel2.Left > 0)
            {
                timer1.Start();
                line();

                panel1.Left -= move_speed;
                panel2.Left -= move_speed;
                if (panel2.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }
        void log()
        {
            if (panel1.Left < 0)
            {
                timer1.Start();
                line();

                panel2.Left += move_speed;
                panel1.Left += move_speed;
                if (panel1.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }

        //image of key
        void unlock()
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                pictureBox2.Image = Properties.Resources.show;
            }
            else
            {
                textBox2.PasswordChar = '*';
                pictureBox2.Image = Properties.Resources._lock;
            }
        }
        #endregion
        
        /// <summary>
        /// Event of TextBox
        /// </summary>
        void Enter1(object sender, EventArgs e)
        {
            if (textBox1.Text == "CMS ID")
            {
                textBox1.Text = string.Empty;
            }
        }
        void Leave1(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "CMS ID";
            }
        }
        void Enter2(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.PasswordChar = '*';
                pictureBox2.Enabled = true;
                textBox2.Text = string.Empty;
            }
        }
        void Leave2(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.PasswordChar = '\0';
                pictureBox2.Enabled = false;
                textBox2.Text = "Password";
            }
        }
        void Enter3(object sender, EventArgs e)
        {
            if (textBox3.Text == "First Name")
            {
                textBox3.Text = string.Empty;
            }
        }
        void Leave3(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "First Name";
            }
        }
        void Enter4(object sender, EventArgs e)
        {
            if (textBox4.Text == "Last Name")
            {
                textBox4.Text = string.Empty;
            }
        }
        void Leave4(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                textBox4.Text = "Last Name";
            }
        }
        void Enter5(object sender, EventArgs e)
        {
            if (textBox5.Text == "CMS ID")
            {
                textBox5.Text = string.Empty;
            }
        }
        void Leave5(object sender, EventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                textBox5.Text = "CMS ID";
            }
        }
        void Enter6(object sender, EventArgs e)
        {
            if (textBox6.Text == "Password")
            {
                textBox6.PasswordChar = '*';
                textBox6.Text = string.Empty;
            }
        }
        void Leave6(object sender, EventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                textBox6.PasswordChar = '\0';
                textBox6.Text = "Password";
            }
        }
        void Enter7(object sender, EventArgs e)
        {
            if (textBox7.Text == "Phone No")
            {
                textBox7.Text = string.Empty;
            }
        }
        void Leave7(object sender, EventArgs e)
        {
            if (textBox7.Text == string.Empty)
            {
                textBox7.Text = "Phone No";
            }
        }
        void Enter8(object sender, EventArgs e)
        {
            if (textBox8.Text == "Email")
            {
                textBox8.Text = string.Empty;
            }
        }
        void Leave8(object sender, EventArgs e)
        {
            if (textBox8.Text == string.Empty)
            {
                textBox8.Text = "Email";
            }
        }

        /// <summary>
        /// Event of label Register&ogin
        /// </summary>
        private void Register(object sender, EventArgs e)
        {
            Label lr = (Label)sender;

            logreg = lr; 
            timer2.Start(); 
        }

        //Event of image
        private void lockun(object sender, EventArgs e)
        {
            unlock();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }
    }
}
