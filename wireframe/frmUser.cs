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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
            panel4.Hide();

            //Create Delete button
            DataGridViewButtonColumn btn_del = new DataGridViewButtonColumn();
            btn_del.HeaderText = "Delete";
            btn_del.Name = "Delete";
            btn_del.Text = "Delete";
            btn_del.UseColumnTextForButtonValue = true;

            //Create Edit button
            DataGridViewButtonColumn btn_edit = new DataGridViewButtonColumn();
            btn_edit.HeaderText = "Edit";
            btn_edit.Name = "Edit";
            btn_edit.Text = "Edit";
            btn_edit.UseColumnTextForButtonValue = true;

            //Show data on dtgv
            dtgvUser9.DataSource = pUser_List();
            dtgvUser9.Columns.Add(btn_edit);
            dtgvUser9.Columns.Add(btn_del);
            for (int i = 0; i < dtgvUser9.Columns.Count; i++)
            {
                dtgvUser9.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvUser9.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgvUser8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvUser9.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (dtgvUser9.RowCount > 1)
                {
                    dtgvUser9.Rows.Remove(dtgvUser9.Rows[e.RowIndex]);
                }
            }
        }
        
        //Panel Create user show
        private void btnCreateUser9_Click(object sender, EventArgs e)
        {
            panel4.Show();
        }

        private static DataTable pUser_List()
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  อ่านค่าจาก Store pUser_List
                SqlParameterCollection param = new SqlCommand().Parameters;
                ds = new DBClass().SqlExcSto("pUser_List", "DbSet", param);
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

        private void btnConfirm9_Click(object sender, EventArgs e)
        {
            DataTable dataTable = pCreate_User(dtgvUser9.Rows.Count
                , txbUser10.Text
                , txbPassword10.Text
                , Convert.ToInt32(txbEmployee10.Text)
                , Convert.ToInt32(txbDepartment10.Text)
                , Convert.ToInt32(txbRole10.Text));
            if (true)
            {
                MessageBox.Show("Create user Success");
                txbUser10.Clear();
                txbPassword10.Clear();
                txbEmployee10.Clear();
                txbDepartment10.Clear();
                txbRole10.Clear();

                dtgvUser9.DataSource = pUser_List();
                panel4.Hide();
            }
        }

        private void btnCancel10_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private static DataTable pCreate_User(int ID, string UserName, string Password, int eCode, int dCode, int rCode)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  Create User (int @ID, VARCHAR(20) @UserName, VARCHAR(20) @Password, int eCode, int dCode, int rCode)
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;
                param.AddWithValue("@UserName", SqlDbType.VarChar).Value = string.IsNullOrEmpty(UserName) || UserName == "-" ? DBNull.Value : (object)UserName;
                param.AddWithValue("@Password", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Password) || Password == "-" ? DBNull.Value : (object)Password;
                param.AddWithValue("@eCode", SqlDbType.VarChar).Value = eCode;
                param.AddWithValue("@dCode", SqlDbType.VarChar).Value = dCode;
                param.AddWithValue("@rCode", SqlDbType.VarChar).Value = rCode;
                ds = new DBClass().SqlExcSto("pCreate_User", "DbSet", param);

                return ds.Tables[0];
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
