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
    class clsPenjualanDetails
    {
        private static string table = "pos_penjualan_detail";
        public clsBarang barang { private set; get; }
        public clsPenjualanMaster penjualanmaster { private set; get; }
        public decimal harga_barang { private set; get; }
        public int kuantitas { private set; get; }
        public DateTime created_at { private set; get; }
        public DateTime updated_at { private set; get; }
        public void setPenjualan(clsPenjualanMaster penjualanmaster)
        {
            this.penjualanmaster = penjualanmaster;
        }
        public void SetBarang(clsBarang barang)
        {
            this.barang = barang;   
        }
        public void SetHargaBarang(decimal harga_barang)
        {
            this.harga_barang = harga_barang;
        }
        public void SetKuantitas(int kuantitas)
        {
            this.kuantitas = kuantitas;
        }
        public void SetCreatetime(DateTime created_at)
        {
            this.created_at = created_at;
        }
        public void SetUpdatedtime(DateTime updated_at)
        {
            this.updated_at = updated_at;
        }
        public int SearchSell()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string select = "SELECT * FROM pos_penjualan_detail WHERE Id_penjualan = @idpenjualan and Id_barang = @idbarang";
            clsDatabase.openDB();
            cmd.Connection = clsDatabase.con;
            cmd.CommandText = select;
            da.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("@idpenjualan", penjualanmaster.ID);
                cmd.Parameters.AddWithValue("@idbarang", barang.ID);
                DataSet ds = new DataSet();
                da.SelectCommand.ExecuteNonQuery();
                da.Fill(ds, "penjualan");
                jlhrecord = ds.Tables["penjualan"].Rows.Count;
                clsDatabase.closeDB();
            }
            catch (Exception ex)
            {
                clsDatabase.closeDB();
                throw new Exception(ex.Message);
            }
            return jlhrecord;
        }
        
        public int AddSellDetail()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "insert into " + table + " (Id_penjualan, Id_barang, Harga_barang, Kuantitas, Created_at, Updated_at) value (@idpenjualan,@idbarang,@hargabarang,@kuantitas,@create,@update)";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@idpenjualan", penjualanmaster.ID);
                cmd.Parameters.AddWithValue("@idbarang", barang.ID);
                cmd.Parameters.AddWithValue("@hargabarang", harga_barang);
                cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
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
        public int UpdateSellDetail()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "update " + table + " set Harga_Barang = @hargabarang, Kuantitas = @kuantitas, Updated_at = @update where Id_penjualan = @idpenjualan and Id_barang = @idbarang";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@idpenjualan", penjualanmaster.ID);
                cmd.Parameters.AddWithValue("@idbarang", barang.ID);
                cmd.Parameters.AddWithValue("@hargabarang", harga_barang);
                cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
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
        public int DeleteSellDetail(string code)
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
        public MySqlDataAdapter Daftar(DataGridView dgv)
        {
            MySqlDataAdapter da;
            DataSet ds;
            string select = "SELECT * FROM " + table + " WHERE Id_penjualan = @idpenjualan";
            try
            {
                clsDatabase.openDB();
                ds = new DataSet();
                da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = clsDatabase.con;
                cmd.CommandText = select;
                cmd.Parameters.AddWithValue("@idpenjualan", penjualanmaster.ID);
                da.SelectCommand = cmd;
                da.SelectCommand.ExecuteNonQuery();
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
