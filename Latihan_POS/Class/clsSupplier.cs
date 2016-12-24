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
    class clsSupplier
    {
        private static string table = "pos_supplier";
        public string kode { private set; get; }
        public string nama { private set; get; }
        public string alamat { private set; get; }
        public string email { private set; get; }
        public string telepon { private set; get; }
        public string pos { private set; get; }
        public DateTime created_at { private set; get; }
        public DateTime updated_at { private set; get; }
        public void SetKode(string kode)
        {
            this.kode = kode;
        }
        public void SetNama(string nama)
        {
            this.nama = nama;
        }
        public void SetAlamat(string alamat)
        {
            this.alamat = alamat;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public void SetTelepon(string telepon)
        {
            this.telepon = telepon;
        }
        public void SetPos(string pos)
        {
            this.pos = pos;
        }
        public void SetCreatetime(DateTime created_at)
        {
            this.created_at = created_at;
        }
        public void SetUpdatedtime(DateTime updated_at)
        {
            this.updated_at = updated_at;
        }
        public int InsertSupplier()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "Insert into " + table + " (Kode,Nama,Alamat,Email,No_Telepon,Kode_Pos,Created_at,Updated_at) values (@kode,@nama,@alamat,@email,@telepon,@pos,@create,@update)";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@kode", kode);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telepon", telepon);
                cmd.Parameters.AddWithValue("@pos", pos);
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
        public int UpdateSupplier(int id)
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "update " + table + " set Kode=@kode,Nama=@nama,Alamat=@alamat,Email=@email,No_Telepon=@telepon,Kode_Pos=@pos,Updated_at=@update where " + table + ".ID=" + id;
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@kode", kode);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telepon", telepon);
                cmd.Parameters.AddWithValue("@pos", pos);
                cmd.Parameters.AddWithValue("@create", created_at);
                cmd.Parameters.AddWithValue("@update", updated_at);
                clsDatabase.openDB();
                cmd.Connection = clsDatabase.con;
                da.UpdateCommand = cmd;
                jlhrecord = da.UpdateCommand.ExecuteNonQuery();
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return jlhrecord;
        }
        public int DeleteSupplier(int id)
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "delete from " + table + " where "+ table +".ID=" + id;
            cmd.CommandText = sqlcmd;
            try
            {
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
    }
}
