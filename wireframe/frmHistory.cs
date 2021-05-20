using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static wireframe.InterfaceDB;

namespace wireframe
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();



            //Show data on dtgv
            dtgvHistory7.DataSource = pHistory_Table();
            for (int i = 0; i < dtgvHistory7.Columns.Count; i++)
            {
                dtgvHistory7.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvHistory7.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPrint a = new frmPrint();
            a.Show();
        }

        private static DataTable pHistory_Table()
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  อ่านค่าจาก Store pUser_List
                SqlParameterCollection param = new SqlCommand().Parameters;
                ds = new DBClass().SqlExcSto("pHistory_Table", "DbSet", param);
                dataTable = ds.Tables[0];
            }
            catch (SqlException)
            {
                dataTable = null;
            }
            catch (Exception)
            {
                dataTable = null;
            }
            return dataTable;
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
