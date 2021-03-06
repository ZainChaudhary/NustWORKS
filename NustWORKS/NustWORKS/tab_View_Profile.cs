﻿using System;
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
    public partial class tab_View_Profile : UserControl
    {
        public static tab_View_Profile _instance;
        public static tab_View_Profile Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new tab_View_Profile();
                return _instance;
            }
        }
        public readonly UserInfo User = Server.CurrentUser;
        public tab_View_Profile()
        {
            InitializeComponent();
            bunifuThinButton22_Click(null, null);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (!((Dashboard)this.ParentForm).panel7.Controls.Contains(tab_Edit_Profile.Instance))
            {
                ((Dashboard)this.ParentForm).panel7.Controls.Add(tab_Edit_Profile.Instance);
                tab_Edit_Profile.Instance.Dock = DockStyle.Fill;
                tab_Edit_Profile.Instance.BringToFront();
            }
            else
                tab_Edit_Profile.Instance.BringToFront();
        }

        private void tab_View_Profile_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            fn.Text = User.FirstName;
            ln.Text = User.LastName;
            mail.Text = User.Email;
            phone.Text = User.PhoneNo;
            cms.Text = User.CMS;
        }
    }
}
