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
    public partial class tab_Edit_Profile : UserControl
    {
        public static tab_Edit_Profile _instance;
        public static tab_Edit_Profile Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new tab_Edit_Profile();
                return _instance;

            }
        }
        public UserInfo User { get; private set; }
        public tab_Edit_Profile()
        {
            User = Server.CurrentUser;
            InitializeComponent();
            fn.Text = User.FirstName;
            ln.Text = User.LastName;
            cms.Text = User.CMS;
            mail.Text = User.Email;
            phone.Text = User.PhoneNo;
        }

        private void tab_Edit_Profile_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (Server.UpdateUser(cms.Text, fn.Text, ln.Text, phone.Text, mail.Text))
                    MessageBox.Show("Profile Updated!");
                else
                    MessageBox.Show("Unable to update profile!");
            }
            catch
            {
                MessageBox.Show("A user with same CMS or email already exists. Please enter valid input.");
            }
        }
    }
}
