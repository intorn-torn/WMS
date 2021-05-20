using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wireframe
{
    public partial class frmPicking_Next : Form
    {
        public frmPicking_Next()
        {
            InitializeComponent();
            cbComment6_1.Items.Add("Bad package");
            cbComment6_1.Items.Add("Expire");
            cbComment6_1.Items.Add("Low quality");
        }
    }
}
