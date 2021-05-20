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
    public partial class frmHeadheld : Form
    {
        public frmHeadheld()
        {
            InitializeComponent();

            dtgvSotre5.Rows.Add(
                new object[]
                {
                    1,
                    "Salt",
                    30,
                    "5/1/2021",
                    "A-02",
                }
                );
            dtgvSotre5.Rows.Add(
                new object[]
                {
                    2,
                    "Sugar",
                    20,
                    "5/1/2021",
                    "B-02",
                }
                );
            dtgvSotre5.Rows.Add(
                new object[]
                {
                    3,
                    "Pepper",
                    60,
                    "5/1/2021",
                    "C-02",
                }
                );
            dtgvSotre5.Rows.Add(
                new object[]
                {
                    4,
                    "Meat",
                    30,
                    "5/1/2021",
                    "D-02",
                }
                );


            dataGridView2.Rows.Add(
                new object[]
                {
                    1,
                    "Sugar",
                    70,
                    "4/1/2021",
                    "B-01",
                }
                );
            dataGridView2.Rows.Add(
                new object[]
                {
                    2,
                    "Pepper",
                    20,
                    "1/1/2021",
                    "C-01",
                }
                );
            dataGridView2.Rows.Add(
                new object[]
                {
                    3,
                    "Salt",
                    30,
                    "1/1/2021",
                    "A-01",
                }
                );
            dataGridView2.Rows.Add(
                new object[]
                {
                    4,
                    "Meat",
                    50,
                    "1/1/2021",
                    "D-01",
                }
                );
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
