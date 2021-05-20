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
    public partial class frmStore : Form
    {
        public frmStore()
        {
            InitializeComponent();
            //Datagrid for take ID
            dtgvAll_Inbound.DataSource = pAlltr_Inbound();
            dtgvAllMattrack.DataSource = pAllCatalog();

            dtgvAllMattrack.Hide();
            dtgvCatalog.Hide();
            dtgvAll_Inbound.Hide();

            //Create Delete button
            DataGridViewButtonColumn btn_del = new DataGridViewButtonColumn();
            btn_del.HeaderText = "Delete";
            btn_del.Name = "Delete";
            btn_del.Text = "Delete";
            
            btn_del.UseColumnTextForButtonValue = true;

            //Show data on dtgv
            dtgvStore.DataSource = pStore_Table();
            dtgvStore.Columns.Add(btn_del);
            for (int i = 0; i < dtgvStore.Columns.Count; i++)
            {
                dtgvStore.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvStore.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //Create Delete button
            DataGridViewButtonColumn btn_del2 = new DataGridViewButtonColumn();
            btn_del2.HeaderText = "Cancel";
            btn_del2.Name = "Cancel";
            btn_del2.Text = "Cancel";

            btn_del2.UseColumnTextForButtonValue = true;
            //Show data on dtgv
            dtgvVerify.DataSource = pStore_Table();
            dtgvVerify.Columns.Add(btn_del2);
            for (int i = 0; i < dtgvStore.Columns.Count; i++)
            {
                dtgvVerify.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvVerify.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //Show data on dtgv
            dtgvCatalog.DataSource = pSelect_Catalog();
            for (int i = 0; i < dtgvCatalog.Columns.Count; i++)
            {
                dtgvCatalog.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dtgvCatalog.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        //Back to function menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFunctionMenu a = new frmFunctionMenu();
            a.Show();
        }

        private void dtgvStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvStore.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (dtgvStore.RowCount > 1)
                {
                    dtgvStore.Rows.Remove(dtgvStore.Rows[e.RowIndex]);
                }
            }
        }

        private void dtgvVerify_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvVerify.Columns[e.ColumnIndex].Name == "Cancel")
            {
                if (dtgvVerify.RowCount > 1)
                {
                    dtgvVerify.Rows.Remove(dtgvVerify.Rows[e.RowIndex]);
                }
            }
        }

        //Store Mat
        int Zone;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int number = 1;
            //Store Salt to zone A
            if (Convert.ToInt32(txbMaterial4.Text) == 1 )
            {
                string slot = "A-0";
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;

                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (
                            Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;
                    }
                    else if(Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;

                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 10 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                    else if (number == 10)
                    {
                        MessageBox.Show("Zone A is full");
                        break;
                    }
                }

            }
            //Store Sugar to zone-B
            else if (Convert.ToInt32(txbMaterial4.Text) == 2)
            {
                string slot = "B-0";
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (
                            Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (
                            Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 20 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                    else if (number == 10)
                    {
                        MessageBox.Show("Zone B is full");
                        break;
                    }
                }
            }
            //Store Pepper to zone-C
            else if (Convert.ToInt32(txbMaterial4.Text) == 3)
            {
                string slot = "C-0";
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (
                            Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (
                            Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 30 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                    else if (number == 10)
                    {
                        MessageBox.Show("Zone C is full");
                        break;
                    }
                }
            }
            //Store Meat to zone-E
            else if (Convert.ToInt32(txbMaterial4.Text) == 4)
            {
                string slot = "E-0";
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (
                            Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int k = 0; k < dtgvCatalog.RowCount; k++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[k].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int l = 0; l < dtgvCatalog.RowCount; l++)
                {
                    dtgvCatalog.Sort(dtgvCatalog.Columns[4], ListSortDirection.Ascending);
                    if (
                            Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvCatalog.Rows[l].Cells[4].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int i = 0; i < dtgvStore.RowCount; i++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Ascending);
                    if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[i].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                }
                for (int j = 0; j < dtgvStore.RowCount; j++)
                {
                    dtgvStore.Sort(dtgvStore.Columns[5], ListSortDirection.Descending);
                    if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) != slot + number && (number != 10))
                    {
                        Zone = 40 + number;
                    }
                    else if (Convert.ToString(dtgvStore.Rows[j].Cells[5].Value) == slot + number)
                    {
                        number++;
                    }
                    else if (number == 10)
                    {
                        MessageBox.Show("Zone E is full");
                        break;
                    }
                }
            }
            else if (txbMaterial4.Text == "")
            {

            }
            //Insert data to SQL Server
            if (number != 10)
            {
                DataTable dataTable = pStore_Inbound(dtgvAll_Inbound.Rows.Count 
                  , Convert.ToInt32(txbMaterial4.Text)
                  , Convert.ToInt32(txbQuantity4.Text)
                  , txbLotNumber4.Text
                  , Zone
                  , Convert.ToInt32(Global.EmployeeCodes));

                MessageBox.Show("Add Success");
                dtgvStore.DataSource = pStore_Table();
                dtgvVerify.DataSource = pStore_Table();
                txbMaterial4.Clear();
                txbQuantity4.Clear();
                txbLotNumber4.Clear();
            }
            else
            {
                dtgvStore.DataSource = pStore_Table();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbMaterial4.Clear();
            txbQuantity4.Clear();
            txbLotNumber4.Clear();
        }

        //Process Inbound
        private static DataTable pStore_Inbound(int ID, int Matcode, int Quantity, string Lotnumber, int ZoneID, int eCode)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  Edit data(@Matcode int, @Quantity int, @Zone int, @ID INT, @Lotnumber varchar(15))
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;
                param.AddWithValue("@Matcode", SqlDbType.VarChar).Value = Matcode;
                param.AddWithValue("@Quantity", SqlDbType.VarChar).Value = Quantity;
                param.AddWithValue("@Lotnumber", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Lotnumber) || Lotnumber == "-" ? DBNull.Value : (object)Lotnumber;
                param.AddWithValue("@ZoneID", SqlDbType.VarChar).Value = ZoneID;
                param.AddWithValue("@eCode", SqlDbType.VarChar).Value = eCode;
                ds = new DBClass().SqlExcSto("pStore_Inbound", "DbSet", param);

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

        //Verify Inbound table ==> Catalog table
        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Matname ==> Matcode for send to SQL Server
                int MaterialCode = 0;
                if(Convert.ToString(dtgvVerify.CurrentRow.Cells[2].Value) == "Salt")
                {
                    MaterialCode = 1;
                }
                else if (Convert.ToString(dtgvVerify.CurrentRow.Cells[2].Value) == "Sugar")
                {
                    MaterialCode = 2;
                }
                else if (Convert.ToString(dtgvVerify.CurrentRow.Cells[2].Value) == "Pepper")
                {
                    MaterialCode = 3;
                }
                else if (Convert.ToString(dtgvVerify.CurrentRow.Cells[2].Value) == "Meat")
                {
                    MaterialCode = 4;
                }
                //Change ZoneName ==> ZoneCode for send to SQL Server
                string ZoneA = "A-0"; string ZoneB = "B-0"; string ZoneC = "A-C"; string ZoneE = "E-0"; int count = 1; 
                for (int i = 1; i < 10; i++)
                {
                    if (Convert.ToString(dtgvVerify.CurrentRow.Cells[5].Value) == ZoneA + i)
                    {
                        count = 10 + i ;
                    }
                    else if (Convert.ToString(dtgvVerify.CurrentRow.Cells[5].Value) == ZoneB + i)
                    {
                        count = 20 + i;
                    }
                    else if (Convert.ToString(dtgvVerify.CurrentRow.Cells[5].Value) == ZoneC + i)
                    {
                        count = 30 + i;
                    }
                    else if (Convert.ToString(dtgvVerify.CurrentRow.Cells[5].Value) == ZoneE + i)
                    {
                        count = 40 + i;
                    }
                }
                //Send data in dtgvVerify to SQL Server
                DataTable dataTable = pVerifyInbound(dtgvAllMattrack.RowCount
                     , MaterialCode
                     , Convert.ToInt32(Global.EmployeeCodes)
                     , Convert.ToInt32(dtgvVerify.CurrentRow.Cells[3].Value)
                     , Convert.ToString(dtgvVerify.CurrentRow.Cells[4].Value)
                     , count
                     , Convert.ToInt32(dtgvVerify.CurrentRow.Cells[1].Value));
                MessageBox.Show("Store Success");

                dtgvVerify.DataSource = pStore_Table();
                MessageBox.Show("" + Convert.ToInt32(dtgvVerify.CurrentRow.Cells[1].Value));
            }
            catch
            {

            }

        }

        private static DataTable pVerifyInbound(int ID, int Matcode, int eCode, int Quantity, string Lotnumber, int Zone, int @CurrentID)
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  Edit data(@ID int, @Matcode int, @eCode int, @Quantity int, @Zone int, @Lotnumber varchar(15), @CurrentID int)
                SqlParameterCollection param = new SqlCommand().Parameters;
                param.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;
                param.AddWithValue("@Matcode", SqlDbType.VarChar).Value = Matcode;
                param.AddWithValue("@eCode", SqlDbType.VarChar).Value = eCode;
                param.AddWithValue("@Quantity", SqlDbType.VarChar).Value = Quantity;
                param.AddWithValue("@Lotnumber", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Lotnumber) || Lotnumber == "-" ? DBNull.Value : (object)Lotnumber;
                param.AddWithValue("@Zone", SqlDbType.VarChar).Value = Zone;
                param.AddWithValue("@CurrentID", SqlDbType.VarChar).Value = CurrentID;

                ds = new DBClass().SqlExcSto("pVerifyInbound", "DbSet", param);

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

        //Show data on Store table
        private static DataTable pStore_Table()
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                SqlParameterCollection param = new SqlCommand().Parameters;
                ds = new DBClass().SqlExcSto("pStore_Table", "DbSet", param);
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

        //For Cound ID
        private static DataTable pAlltr_Inbound()
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                SqlParameterCollection param = new SqlCommand().Parameters;
                ds = new DBClass().SqlExcSto("pAlltr_Inbound", "DbSet", param);
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

        //For count Catalog ID
        private static DataTable pAllCatalog()
        {
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //  อ่านค่าจาก Store pUser_List
                SqlParameterCollection param = new SqlCommand().Parameters;
                ds = new DBClass().SqlExcSto("pAllCatalog", "DbSet", param);
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
    }
}
