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
    public partial class frmCatalog : Form
    {
        public frmCatalog()
        {
            InitializeComponent();

            panelEdit.Hide();

            //Window Setting
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;

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
            dtgvCatalog3.DataSource = pSelect_Catalog();
            dtgvCatalog3.Columns.Add(btn_edit);
            dtgvCatalog3.Columns.Add(btn_del);
            for (int i = 0; i < dtgvCatalog3.Columns.Count; i++)
            {
                dtgvCatalog3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvCatalog3.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        
        //Delete row button
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvCatalog3.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (dtgvCatalog3.RowCount > 1)
                {
                    dtgvCatalog3.Rows.Remove(dtgvCatalog3.Rows[e.RowIndex]);
                }
            }
            else if(dtgvCatalog3.Columns[e.ColumnIndex].Name == "Edit")
            {
                //Show panel Edit
                    panelEdit.Show();
                    txbMatcode.Text = dtgvCatalog3.CurrentRow.Cells[3].Value.ToString();
                    txbQuantity.Text = dtgvCatalog3.CurrentRow.Cells[4].Value.ToString();
                    txbLotnumber.Text = dtgvCatalog3.CurrentRow.Cells[5].Value.ToString();
                    txbZonecode.Text = dtgvCatalog3.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Insert data to SQLServer for edit data base
            try
            {
                DataTable dataTable = pUpdate(Convert.ToInt16(txbMatcode.Text)
                     , Convert.ToInt16(txbQuantity.Text)
                     , txbLotnumber.Text
                     , Convert.ToInt16(txbZonecode.Text)
                     , Convert.ToInt32(dtgvCatalog3.CurrentRow.Cells["ID"].Value));
                MessageBox.Show("Edit Success");
                panelEdit.Hide();
                dtgvCatalog3.DataSource = pSelect_Catalog();
            }
            catch
            {
                MessageBox.Show("Check your Matcode and ZoneID");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Cancel Edit
            panelEdit.Hide();
            txbMatcode.Clear();
            txbQuantity.Clear();
            txbLotnumber.Clear();
            txbZonecode.Clear();
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

        //Search show
        private void btnSearch3_Click(object sender, EventArgs e)
        {
            if(txbMaterial3.Text.Length == 0)
            {
                DataTable dataTable = pSelect_Lot(txbLotNumber3.Text + "%");
                if (dataTable.Rows.Count > 0)
                {
                    dtgvCatalog3.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Catalog not found");
                }
            }
            else if (txbLotNumber3.Text.Length == 0)
            {
                DataTable dataTable = pSelect_Mat(txbMaterial3.Text + "%");
                if (dataTable.Rows.Count > 0)
                {
                    dtgvCatalog3.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Catalog not found");
                }
            }
            else if(txbMaterial3.Text.Length != 0 && txbLotNumber3.Text.Length != 0)
            {
                DataTable dataTable = pSelect_Mat_Lot(txbMaterial3.Text + "%", txbLotNumber3.Text + "%");
                if (dataTable.Rows.Count > 0)
                {
                    dtgvCatalog3.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Catalog not found");
                }
            }
        }

        //Material search Mat&Lot
        private static DataTable pSelect_Mat_Lot(string Matcode, string Lotnumber)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  pProcessCheckLogin(@Matcode varchar(10), @Lotnumber varchar(15))
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@Matcode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Matcode) || Matcode == "-" ? DBNull.Value : (object)Matcode;
                param.AddWithValue("@Lotnumber", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Lotnumber) || Lotnumber == "-" ? DBNull.Value : (object)Lotnumber;
                ds = new DBClass().SqlExcSto("pSelect_Mat_Lot", "DbSet", param);

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

        //Material search Mat
        private static DataTable pSelect_Mat(string Matcode)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  pProcessCheckLogin(@Matcode varchar(10))
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@Matcode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Matcode) || Matcode == "-" ? DBNull.Value : (object)Matcode;
                ds = new DBClass().SqlExcSto("pSelect_Mat", "DbSet", param);

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

        //Material search Lot
        private static DataTable pSelect_Lot(string Lotnumber)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  Search Lotnumber (@Lotnumber varchar(15))
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@Lotnumber", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Lotnumber) || Lotnumber == "-" ? DBNull.Value : (object)Lotnumber;
                ds = new DBClass().SqlExcSto("pSelect_Lot", "DbSet", param);

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

        private static DataTable pUpdate(int Matcode, int Quantity, string Lotnumber, int Zone, int ID )
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  Edit data(@Matcode int, @Quantity int, @Zone int, @ID INT, @Lotnumber varchar(15))
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@Matcode", SqlDbType.VarChar).Value = Matcode;
                param.AddWithValue("@Quantity", SqlDbType.VarChar).Value = Quantity;
                param.AddWithValue("@Lotnumber", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Lotnumber) || Lotnumber == "-" ? DBNull.Value : (object)Lotnumber;
                param.AddWithValue("@Zone", SqlDbType.VarChar).Value = Zone;
                param.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;
                ds = new DBClass().SqlExcSto("pUpdate", "DbSet", param);

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

        //Back button
        private void btnBack3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFunctionMenu a = new frmFunctionMenu();
            a.Show();
        }

    }
}
