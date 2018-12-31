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
    public partial class tab_View_Others_Profile : UserControl
    {
        public readonly UserInfo User;
        public tab_View_Others_Profile(UserInfo user)
        {
            User = user;
            cms.Text = user.CMS;
            mail.Text = user.Email;
            phone.Text = user.PhoneNo;
            fn.Text = user.FirstName;
            ln.Text = user.LastName;


            InitializeComponent();
        }

        private void cms_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
