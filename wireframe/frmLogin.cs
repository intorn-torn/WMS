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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            dtgvLogin.Hide();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txbPassword.Text = "";
            txbUser.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            DataTable dataTable = pProcessCheckLogin(txbUser.Text, txbPassword.Text);
            if (dataTable.Rows.Count > 0)
            {
                frmFunctionMenu menuPage = new frmFunctionMenu();
                menuPage.Show();
                this.Hide();
                dtgvLogin.DataSource = pProcessCheckLogin(txbUser.Text, txbPassword.Text);
                Global.EmployeeCodes = dtgvLogin.Rows[0].Cells[1].Value.ToString();
                //dtgvLogin.Show();
                MessageBox.Show("Login as : "+Global.EmployeeCodes);
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private static DataTable pProcessCheckLogin(string username, string password)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  pProcessCheckLogin(@username varchar(20), @password varchar(20))
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@username", SqlDbType.VarChar).Value = string.IsNullOrEmpty(username) || username == "-" ? DBNull.Value : (object)username;
                param.AddWithValue("@password", SqlDbType.VarChar).Value = string.IsNullOrEmpty(password) || password == "-" ? DBNull.Value : (object)password;
                ds = new DBClass().SqlExcSto("pProcessCheckLogin", "DbSet", param);

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

    }

}
