using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Latihan_POS.Class
{
    class clsPembelianMaster
    {
        private static string table = "pos_pembelian";
        public int ID { private set; get; }
        public string kode { private set; get; }
        public clsSupplier supplier { private set; get; }
        public DateTime created_at { private set; get; }
        public DateTime updated_at { private set; get; }
        public void setSupplier(clsSupplier supplier)
        {
            this.supplier = supplier;
        }
        public void SetID(int id)
        {
            this.ID = id;
        }
        public void SetKode(string kode)
        {
            this.kode = kode;
        }
        public void SetCreatetime(DateTime created_at)
        {
            this.created_at = created_at;
        }
        public void SetUpdatetime(DateTime updated_at)
        {
            this.updated_at = updated_at;
        }
        public int SearchBuy(string code)
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string select = "SELECT * FROM " + table + " WHERE Kode = @code";
            clsDatabase.openDB();
            cmd.Connection = clsDatabase.con;
            cmd.CommandText = select;
            da.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("@code", code);
                DataSet ds = new DataSet();
                da.SelectCommand.ExecuteNonQuery();
                da.Fill(ds, "pembelian");
                jlhrecord = ds.Tables["pembelian"].Rows.Count;
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
            return jlhrecord;
        }
        public int AddBuy()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "insert into " + table + " (Kode,ID_supplier,Created_at,Updated_at) value (@kode,@idsupplier,@create,@update)";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@kode", kode);
                cmd.Parameters.AddWithValue("@idsupplier", supplier.ID);
                cmd.Parameters.AddWithValue("@create", created_at);
                cmd.Parameters.AddWithValue("@update", updated_at);
                clsDatabase.openDB();
                cmd.Connection = clsDatabase.con;
                da.InsertCommand = cmd;
                jlhrecord = da.InsertCommand.ExecuteNonQuery();
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
            searchID();
            return jlhrecord;
        }
        public int UpdateBuy(string code)
        {
            this.kode = code;
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "update " + table + " set Id_supplier = @idsupplier, Updated_at = @update where Kode = @code";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@idsupplier", supplier.ID);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@update", updated_at);
                clsDatabase.openDB();
                cmd.Connection = clsDatabase.con;
                da.UpdateCommand = cmd;
                jlhrecord = da.UpdateCommand.ExecuteNonQuery();
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
            searchID();
            return jlhrecord;
        }
        public int DeleteBuy(string code)
        {
            int jlhrecord = 0;
            clsDatabase.openDB();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "delete from " + table + " where Kode = @code";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@code", code);
                clsDatabase.openDB();
                cmd.Connection = clsDatabase.con;
                da.DeleteCommand = cmd;
                jlhrecord = da.DeleteCommand.ExecuteNonQuery();
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
            return jlhrecord;
        }
        public MySqlDataAdapter Daftar(DataGridView dgv, string table)
        {
            MySqlDataAdapter da;
            DataSet ds;
            string select = "SELECT * FROM " + table;
            try
            {
                clsDatabase.openDB();
                ds = new DataSet();
                da = new MySqlDataAdapter(select, clsDatabase.con);
                da.Fill(ds, table);
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.DataSource = ds.Tables[table];
                dgv.Refresh();
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
            return da;
        }
        public static MySqlDataAdapter Daftar()
        {
            MySqlDataAdapter da;
            string select = "SELECT * FROM " + table;
            try
            {
                clsDatabase.openDB();
                da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = clsDatabase.con;
                cmd.CommandText = select;
                da.SelectCommand = cmd;
                da.SelectCommand.ExecuteScalar();
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
            return da;
        }
        public void setProperties(DataRow row)
        {
            this.ID = Convert.ToInt32(row[0]);
            this.kode = row[1].ToString();
            this.created_at = Convert.ToDateTime(row[3]);
            this.updated_at = Convert.ToDateTime(row[4]);
            this.supplier = new clsSupplier();
            this.supplier.SetID(Convert.ToInt32(row[2]));

            // SEARCH supplier BY ID
            MySqlDataAdapter da = new MySqlDataAdapter();
            string selectAll = "SELECT * FROM pos_supplier WHERE id = @id";

            MySqlCommand cmd;
            cmd = new MySqlCommand(selectAll, clsDatabase.con);
            cmd.Parameters.AddWithValue("@id", supplier.ID);
            da.SelectCommand = cmd;
            try
            {
                clsDatabase.openDB();
                DataTable dtc = new DataTable();
                da.SelectCommand.ExecuteNonQuery();
                da.Fill(dtc);
                clsDatabase.closeDB();

                this.supplier.SetNama(dtc.Rows[0][2].ToString());
                this.supplier.SetAlamat(dtc.Rows[0][3].ToString());
                this.supplier.SetPos(dtc.Rows[0][4].ToString());
                this.supplier.SetTelepon(dtc.Rows[0][5].ToString());
                this.supplier.SetEmail(dtc.Rows[0][6].ToString());
                this.supplier.SetCreatetime(Convert.ToDateTime(dtc.Rows[0][7]));
                this.supplier.SetUpdatedtime(Convert.ToDateTime(dtc.Rows[0][8]));
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
        }
        private void searchID()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            string selectAll = "SELECT id FROM " + table + " WHERE kode = @kode";

            MySqlCommand cmd;
            cmd = new MySqlCommand(selectAll, clsDatabase.con);
            cmd.Parameters.AddWithValue("@kode", this.kode);
            da.SelectCommand = cmd;
            try
            {
                clsDatabase.openDB();
                DataSet ds = new DataSet();
                da.SelectCommand.ExecuteNonQuery();
                da.Fill(ds, "searchID");
                clsDatabase.closeDB();

                this.ID = Convert.ToInt32(ds.Tables["searchID"].Rows[0][0]);
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
        }
    }
}
