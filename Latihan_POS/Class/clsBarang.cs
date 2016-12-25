using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Latihan_POS.Class
{
    class clsBarang
    {
        private static string table = "pos_barang";
        public int ID { private set; get; }
        public string kode { private set; get; }
        public string nama { private set; get; }
        public int jlh_awal { private set; get; }
        public decimal harga_hpp { private set; get; }
        public decimal harga_jual { private set; get; }
        public DateTime created_at { private set; get; }
        public DateTime updated_at { private set; get; }

        public void SetID(int id)
        {
            this.ID = id;
        }
        public void SetKode(string kode)
        {
            this.kode = kode;
        }
        public void SetNama(string nama)
        {
            this.nama = nama;
        }
        public void SetJlhawal(int jlh_awal)
        {
            this.jlh_awal = jlh_awal;
        }
        public void SetHargahpp(decimal harga_hpp)
        {
            this.harga_hpp = harga_hpp;
        }
        public void SetHargajual(decimal harga_jual)
        {
            this.harga_jual = harga_jual;
        }
        public void SetCreatetime(DateTime created_at)
        {
            this.created_at = created_at;
        }
        public void SetUpdatetime(DateTime updated_at)
        {
            this.updated_at = updated_at;
        }
        public MySqlDataAdapter SelectFromTable()
        {
            MySqlDataAdapter da;
            string selectString = "SELECT * FROM " + table;
            da = new MySqlDataAdapter(selectString, clsDatabase.con);
            try
            {
                clsDatabase.openDB();
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
        public int InsertBarang()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "Insert into " + table + " (Kode,Nama,Jumlah_Awal,Harga_HPP,Harga_Jual,Created_at,Updated_at) values (@kode,@nama,@jlhawal,@hargahpp,@hargajual,@create,@update)";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@kode", kode);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@jlhawal", jlh_awal);
                cmd.Parameters.AddWithValue("@hargahpp", harga_hpp);
                cmd.Parameters.AddWithValue("@hargajual", harga_jual);
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
            return jlhrecord;
        }
        public int UpdateBarang(int id)
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "UPDATE " + table + " SET Kode = @kode, Nama = @nama, Jumlah_Awal = @jlhawal, Harga_HPP = @hargahpp, Harga_Jual = @hargajual, Updated_at = @update WHERE ID = @id";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@kode", kode);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@jlhawal", jlh_awal);
                cmd.Parameters.AddWithValue("@hargahpp", harga_hpp);
                cmd.Parameters.AddWithValue("@hargajual", harga_jual);
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
            return jlhrecord;
        }
        public int DeleteBarang(int id)
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "delete from " + table + " where ID = @id";
            cmd.CommandText = sqlcmd;
            try
            {
                clsDatabase.openDB();
                cmd.Parameters.AddWithValue("@id", id);
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
        public MySqlDataAdapter Daftar(DataGridView dgv)
        {
            MySqlDataAdapter da;
            DataSet ds;
            string select = "SELECT * FROM " + table;
            try
            {
                clsDatabase.openDB();
                ds = new DataSet();
                da = new MySqlDataAdapter(select, clsDatabase.con);
                da.SelectCommand.ExecuteScalar();
                da.Fill(ds, table);
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.DataSource = ds.Tables[table];
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
                da = new MySqlDataAdapter(select, clsDatabase.con);
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
            this.nama = row[2].ToString();
            this.jlh_awal = Convert.ToInt32(row[3]);
            this.harga_hpp = Convert.ToDecimal(row[4]);
            this.harga_jual = Convert.ToDecimal(row[5]);
            this.created_at = Convert.ToDateTime(row[6]);
            this.updated_at = Convert.ToDateTime(row[7]);
        }

    }
}
