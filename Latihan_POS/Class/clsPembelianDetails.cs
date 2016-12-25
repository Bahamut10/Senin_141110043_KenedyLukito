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
    class clsPembelianDetails
    {
        private static string table = "pos_pembelian_detail";
        public clsBarang barang { private set; get; }
        public clsPembelianMaster pembelianmaster { private set; get; }
        public decimal harga_hpp { private set; get; }
        public int kuantitas { private set; get; }
        public DateTime created_at { private set; get; }
        public DateTime updated_at { private set; get; }
        public void setPembelian(clsPembelianMaster pembelianmaster)
        {
            this.pembelianmaster = pembelianmaster;
        }
        public void SetBarang(clsBarang barang)
        {
            this.barang = barang;
        }
        public void SetHargaHPP(decimal harga_hpp)
        {
            this.harga_hpp = harga_hpp;
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
        public int SearchBuy()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string select = "SELECT * FROM pos_pembelian_detail WHERE Id_pembelian = @idpembelian and Id_barang = @idbarang";
            clsDatabase.openDB();
            cmd.Connection = clsDatabase.con;
            cmd.CommandText = select;
            da.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("@idpembelian", pembelianmaster.ID);
                cmd.Parameters.AddWithValue("@idbarang", barang.ID);
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

        public int AddBuyDetail()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "insert into " + table + " (Id_pembelian, Id_barang, Harga_HPP, Kuantitas, Created_at, Updated_at) value (@idpembelian,@idbarang,@hargahpp,@kuantitas,@create,@update)";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@idpembelian", pembelianmaster.ID);
                cmd.Parameters.AddWithValue("@idbarang", barang.ID);
                cmd.Parameters.AddWithValue("@hargahpp", harga_hpp);
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
        public int UpdateBuyDetail()
        {
            int jlhrecord = 0;
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            string sqlcmd = "update " + table + " set Harga_HPP = @hargahpp, Kuantitas = @kuantitas, Updated_at = @update where Id_pembelian = @idpembelian and Id_barang = @idbarang";
            cmd.CommandText = sqlcmd;
            try
            {
                cmd.Parameters.AddWithValue("@idpembelian", pembelianmaster.ID);
                cmd.Parameters.AddWithValue("@idbarang", barang.ID);
                cmd.Parameters.AddWithValue("@hargahpp", harga_hpp);
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
        public int DeleteBuyDetail(string code)
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
            string select = "SELECT * FROM " + table + " WHERE Id_pembelian = @idpembelian";
            try
            {
                clsDatabase.openDB();
                ds = new DataSet();
                da = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = clsDatabase.con;
                cmd.CommandText = select;
                cmd.Parameters.AddWithValue("@idpembelian", pembelianmaster.ID);
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
        public MySqlDataAdapter DaftarShow(DataGridView dgv, string table)
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
    }
}
