using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Latihan_POS
{
    public partial class Daftar_Barang : Form
    {
        public Daftar_Barang()
        {
            InitializeComponent();
        }

        private void Daftar_Barang_Load(object sender, EventArgs e)
        {
            this.Text="Daftar Barang";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int JlhAwal = Convert.ToInt32(txtJlhAwal.Text);
            decimal HPP = Convert.ToDecimal(txtHPP.Text);
            decimal Jual = Convert.ToDecimal(txtJual.Text);
            string con = "Server=localhost;Port=3306;Database=db_barang;Uid=root;password=''";
            MySqlConnection db_con = new MySqlConnection(con);
            MySqlCommand cmd = db_con.CreateCommand();
            cmd.CommandText="insert into pos_barang (Kode,Nama,Jumlah_Awal,Harga_HPP,Harga_Jual,Created_at,Updated_at) values (@code,@name,@initialvalue,@HPP,@sellingprice,@create,@update)";
            cmd.Parameters.AddWithValue("@code", txtKode.Text);
            cmd.Parameters.AddWithValue("@name", txtNama.Text);
            cmd.Parameters.AddWithValue("@initialvalue", JlhAwal);
            cmd.Parameters.AddWithValue("@HPP", HPP);
            cmd.Parameters.AddWithValue("@sellingprice", Jual);
            cmd.Parameters.AddWithValue("@create", DateTime.Now);
            cmd.Parameters.AddWithValue("@update", DateTime.Now);
            try
            {
                db_con.Open();
                cmd.ExecuteNonQuery();
                db_con.Close();
                MessageBox.Show("Saved Successfully");
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
