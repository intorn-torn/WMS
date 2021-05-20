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
    public partial class frmEditUser : Form
    {
        public frmEditUser()
        {
            InitializeComponent();
            dataGridView1.Rows.Add(
                new object[]
                {
                    1,
                    "Intorn",
                    "Warehouse",
                    "User",
                    "Online",
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    2,
                    "Iton",
                    "Warehouse",
                    "User",
                    "Offline",
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    3,
                    "Iron",
                    "QC",
                    "User",
                    "Offline",
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    4,
                    "Torn",
                    "Warehouse",
                    "Admin",
                    "Online",
                }
                );
        }
    }
}
