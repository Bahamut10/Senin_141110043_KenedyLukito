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
            this.Dock = DockStyle.Fill;
        }

        private void Daftar_Barang_Load(object sender, EventArgs e)
        {
            this.Text="Daftar Barang";
            this.WindowState = FormWindowState.Maximized;        
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string con = "Server=localhost;Port=3306;Database=db_barang;Uid=root;password=''";
            MySqlConnection db_con = new MySqlConnection(con);
            MySqlCommand cmd = db_con.CreateCommand();
            cmd.CommandText="insert into pos_barang (Kode,Nama,Jumlah_Awal,Harga_HPP,Harga_Jual,Created_at,Updated_at) values (@code,@name,@initialvalue,@HPP,@sellingprice,@create,@update)";
            try
            {
                cmd.Parameters.AddWithValue("@code", txtKode.Text);
                cmd.Parameters.AddWithValue("@name", txtNama.Text);
                cmd.Parameters.AddWithValue("@initialvalue", Convert.ToInt32(txtJlhAwal.Text));
                cmd.Parameters.AddWithValue("@HPP", Convert.ToDecimal(txtHPP.Text));
                cmd.Parameters.AddWithValue("@sellingprice", Convert.ToDecimal(txtJual.Text));
                cmd.Parameters.AddWithValue("@create", DateTime.Now);
                cmd.Parameters.AddWithValue("@update", DateTime.Now);
                db_con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully", "Success");
                db_con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtKode.Clear();
            txtNama.Clear();
            txtJlhAwal.Clear();
            txtHPP.Clear();
            txtJual.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
