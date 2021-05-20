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
    public partial class frmFunctionMenu : Form
    {
        public frmFunctionMenu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
        }

        private void form5_Click(object sender, EventArgs e)
        {
            frmHeadheld a = new frmHeadheld();
            a.Show();
        }


        private void btnCatalog_Click(object sender, EventArgs e)
        {
            frmCatalog a = new frmCatalog();
            a.Show();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            frmStore a = new frmStore();
            a.Show();
        }

        private void btnPicking_Click(object sender, EventArgs e)
        {
            frmPicking a = new frmPicking();
            a.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmHistory a = new frmHistory();
            a.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser a = new frmUser();
            a.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin a = new frmLogin();
            a.Show();
            this.Hide();
        }
    }

}
