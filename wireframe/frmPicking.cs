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
    public partial class frmPicking : Form
    {
        public frmPicking()
        {
            InitializeComponent();

            //dtgvSearch
            DataGridViewButtonColumn btn_pick = new DataGridViewButtonColumn();
            btn_pick.HeaderText = "Pick";
            btn_pick.Name = "Pick";
            btn_pick.Text = "Pick";
            btn_pick.UseColumnTextForButtonValue = true;

            //Show data on dtgvSearch
            dtgvSearch6.DataSource = pSelect_Catalog();
            dtgvSearch6.Columns.Add(btn_pick);
            for (int i = 0; i < dtgvSearch6.Columns.Count; i++)
            {
                dtgvSearch6.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvSearch6.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            //dtgvBook
            DataGridViewButtonColumn btn_Cancel = new DataGridViewButtonColumn();
            btn_Cancel.HeaderText = "Cancel";
            btn_Cancel.Name = "Cancel";
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseColumnTextForButtonValue = true;

            //Show data on dtgvBook
            dtgvBook.DataSource = pBook_Table();
            dtgvBook.Columns.Add(btn_Cancel);
            for (int i = 0; i < dtgvSearch6.Columns.Count; i++)
            {
                dtgvBook.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvBook.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //Combobox picking
            cbComment6_1.Items.Add("Bad package");
            cbComment6_1.Items.Add("Expire");
            cbComment6_1.Items.Add("Low quality");
            panelPick.Hide();

        }

        private void dtgvSearch6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvSearch6.Columns[e.ColumnIndex].Name == "Pick")
            {
                    panelPick.Show();
                lbMat.Text = Convert.ToString(dtgvSearch6.CurrentRow.Cells[2].Value);
                txbQuantityPick6_1.Text = Convert.ToString(dtgvSearch6.CurrentRow.Cells[3].Value);
                nuQuanPick.Maximum = Convert.ToInt32(dtgvSearch6.CurrentRow.Cells[3].Value);
                nuQuanPick.Minimum = 0;

                lbComment6_1.Hide();
                cbComment6_1.Hide();

            }
        }

        private void rbPick6_1_CheckedChanged_1(object sender, EventArgs e)
        {
            lbComment6_1.Hide();
            cbComment6_1.Hide();
            cbComment6_1.ResetText();
        }

        private void rbRid6_1_CheckedChanged_1(object sender, EventArgs e)
        {
            lbComment6_1.Show();
            cbComment6_1.Show();
        }

        private void dtgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvBook.Columns[e.ColumnIndex].Name == "Cancel")
            {
                if (dtgvBook.RowCount > 1)
                {
                    dtgvBook.Rows.Remove(dtgvBook.Rows[e.RowIndex]);
                }
            }
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btnSearch6_Click(object sender, EventArgs e)
        {

        }

        private static DataTable pSelect_Catalog()
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  อ่านค่าจาก Store pSelect_Catalog
                SqlParameterCollection param = new SqlCommand().Parameters;
                ds = new DBClass().SqlExcSto("pSelect_Catalog", "DbSet", param);
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

        // Hide panelPick
        private void btnCancel6_1_Click_1(object sender, EventArgs e)
        {
            panelPick.Hide();
            txbQuantityPick6_1.Clear();
            cbComment6_1.ResetText();
            nuQuanPick.Value = 0;
            rbPick6_1.Checked = false;
            rbRid6_1.Checked = false;
        }

        private void btnConfirm6_1_Click(object sender, EventArgs e)
        {
            //Insert data to SQLServer for edit data base
            try
            {
                //Change Matname ==> Matcode for send to SQL Server
                int MaterialCode = 0;
                if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[2].Value) == "Salt")
                {
                    MaterialCode = 1;
                }
                else if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[2].Value) == "Sugar")
                {
                    MaterialCode = 2;
                }
                else if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[2].Value) == "Pepper")
                {
                    MaterialCode = 3;
                }
                else if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[2].Value) == "Meat")
                {
                    MaterialCode = 4;
                }
                //Change ZoneName ==> ZoneCode for send to SQL Server
                string ZoneA = "A-0"; string ZoneB = "B-0"; string ZoneC = "A-C"; string ZoneE = "E-0"; int count = 1;
                for (int i = 1; i < 10; i++)
                {
                    if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[5].Value) == ZoneA + i)
                    {
                        count = 10 + i;
                    }
                    else if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[5].Value) == ZoneB + i)
                    {
                        count = 20 + i;
                    }
                    else if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[5].Value) == ZoneC + i)
                    {
                        count = 30 + i;
                    }
                    else if (Convert.ToString(dtgvSearch6.CurrentRow.Cells[5].Value) == ZoneE + i)
                    {
                        count = 40 + i;
                    }
                }

                DataTable dataTable = pBook_Mat(dtgvBook.RowCount
                     , MaterialCode
                     , Convert.ToInt16(nuQuanPick.Text)
                     , Convert.ToString(dtgvSearch6.CurrentRow.Cells[4].Value)
                     , count
                     , Convert.ToInt16(Global.EmployeeCodes)
                     , cbComment6_1.Text);
                MessageBox.Show("Book Success");
                dtgvBook.DataSource = pBook_Table();

                panelPick.Hide();
                txbQuantityPick6_1.Clear();
                cbComment6_1.ResetText();
                nuQuanPick.Value = 0;
                rbPick6_1.Checked = false;
                rbRid6_1.Checked = false;
            }
            catch
            {
                MessageBox.Show("Book Failed");
            }
        }

        private static DataTable pBook_Table()
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  อ่านค่าจาก Store pBook_Table
                SqlParameterCollection param = new SqlCommand().Parameters;
                ds = new DBClass().SqlExcSto("pBook_Table", "DbSet", param);
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

        private static DataTable pBook_Mat(int ID, int Matcode, int Quantity, string Lotnumber, int Zone, int eCode, string Comment)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  Edit data(@ID INT, @Matcode int, @Quantity int, @Zone int, @Lotnumber varchar(15), int eCode, Comment VARCHAR(50))
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;
                param.AddWithValue("@Matcode", SqlDbType.VarChar).Value = Matcode;
                param.AddWithValue("@Quantity", SqlDbType.VarChar).Value = Quantity;
                param.AddWithValue("@Lotnumber", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Lotnumber) || Lotnumber == "-" ? DBNull.Value : (object)Lotnumber;
                param.AddWithValue("@Zone", SqlDbType.VarChar).Value = Zone;
                param.AddWithValue("@eCode", SqlDbType.VarChar).Value = eCode;
                param.AddWithValue("@Comment", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Comment) || Comment == "-" ? DBNull.Value : (object)Comment;
                ds = new DBClass().SqlExcSto("pBook_Mat", "DbSet", param);

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
