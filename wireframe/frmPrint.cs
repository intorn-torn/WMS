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
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
            dtgvPreviewPrint8.Rows.Add(
                new object[]
                {
                    1,
                    "Salt",
                    30,
                    "5/1/2021",
                    "A-03",
                    "5/1/2021:15.15",
                    01,
                    "-",
                    "-",
                    "Storage",
                    "-"
                }
                );
            dtgvPreviewPrint8.Rows.Add(
                new object[]
                {
                    2,
                    "Sugar",
                    30,
                    "5/1/2021",
                    "B-02",
                    "5/1/2021:13.20",
                    02,
                    "9/1/2021:14.43",
                    "02",
                    "Delivery",
                    "-"
                }
                );
            dtgvPreviewPrint8.Rows.Add(
                new object[]
                {
                    3,
                    "Pepper",
                    60,
                    "5/1/2021",
                    "C-02",
                    "5/1/2021:9.40",
                    02,
                    "7/1/2021:9.36",
                    "01",
                    "Rid",
                    "Expire"
                }
                );
            dtgvPreviewPrint8.Rows.Add(
                new object[]
                {
                    4,
                    "Meat",
                    10,
                    "5/1/2021",
                    "D-02",
                    "5/1/2021:8.30",
                    01,
                    "7/1/2021:8.53",
                    "01",
                    "Delivery",
                    "-"
                }
                );

            dtgvUser8.Rows.Add(
                new object[]
                {
                    1,
                    "Intorn",
                    "Warehouse",
                }
                );
            dtgvUser8.Rows.Add(
                new object[]
                {
                    2,
                    "Iton",
                    "Warehouse",
                }
                );
        }
    }
}
