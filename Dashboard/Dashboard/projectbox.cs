using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class projectbox : UserControl
    {
        public projectbox()
        {
            InitializeComponent();
        }

        #region Properties

        private Color _iconBack;
        private string _title;
        private string _message;
        private string _price;
        private Image _icon;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value;lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public Color IconBackground
        {
            get { return _iconBack; }
            set { _iconBack = value; panel1.BackColor= value; }
        }

        [Category("Custom Props")]
        public string Message
        {
            get { return _message; }
            set { _message = value; lblMessage.Text = value; }
        }


        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set { _price = value;lblPrice.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value;pictureBox1.Image = value; }
        }


        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void projectbox_Load(object sender, EventArgs e)
        {

        }

        private void projectbox_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void projectbox_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 255, 240);
        }
    }
}
