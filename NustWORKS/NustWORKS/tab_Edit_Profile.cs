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
        public tab_Edit_Profile()
        {
            InitializeComponent();
        }
    }
}
