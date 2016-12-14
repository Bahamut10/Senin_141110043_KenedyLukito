using MaterialSkin.Controls;
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
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            con.Open();
            try
            {
                da = new MySqlDataAdapter();
                string sql = String.Concat("Insert into pos_barang (Kode,Nama,Jumlah_Awal,Harga_HPP,Harga_Jual,Created_at,Updated_at) values ('", txtKode.Text, "','", txtNama.Text, "',", Convert.ToInt32(txtJlhAwal.Text), ",", Convert.ToDecimal(txtHPP.Text), ",", Convert.ToDecimal(txtJual.Text), ",NOW(), NOW())");
                da.InsertCommand = new MySqlCommand(sql, con);
                string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Saved Successfully");
                MessageBox.Show(mess, "Success");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
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
        private void csInputbtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            con.Open();
            try
            {
                da = new MySqlDataAdapter();
                string sql = String.Concat("Insert into pos_customer (Kode,Nama,Alamat,Created_at,Updated_at) values ('", csInputtxtKode.Text, "','", csInputtxtNama.Text, "','", csInputtxtAlamat.Text, "',NOW(), NOW())");
                da.InsertCommand = new MySqlCommand(sql, con);
                string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Saved Successfully");
                MessageBox.Show(mess, "Success");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }

        }

        private void csInputbtnReset_Click(object sender, EventArgs e)
        {
            csInputtxtKode.Clear();
            csInputtxtNama.Clear();
            csInputtxtAlamat.Clear();
        }

        private void csInputbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            DataSet ds;
            try
            {
                con.Open();
                ds = new DataSet();
                da = new MySqlDataAdapter("SELECT * FROM pos_customer", con);
                da.Fill(ds, "pos_customer");
                dgvCustomer.ReadOnly = true;
                dgvCustomer.AllowUserToAddRows = false;
                dgvCustomer.AllowUserToDeleteRows = false;
                dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCustomer.DataSource = ds.Tables["pos_customer"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void materialTabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero Datetime=True");
            MySqlDataAdapter da;
            DataSet ds;
            try
            {
                con.Open();
                ds = new DataSet();
                da = new MySqlDataAdapter("SELECT * FROM pos_barang", con);
                da.Fill(ds, "pos_barang");
                dgvbarang.ReadOnly = true;
                dgvbarang.AllowUserToAddRows = false;
                dgvbarang.AllowUserToDeleteRows = false;
                dgvbarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvbarang.DataSource = ds.Tables["pos_barang"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void spInputbtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            con.Open();
            try
            {
                da = new MySqlDataAdapter();
                string sql = String.Concat("Insert into pos_supplier (Kode,Nama,Alamat,Created_at,Updated_at) values ('", spInputtxtKode.Text, "','", spInputtxtNama.Text, "','", spInputtxtAlamat.Text, "',NOW(), NOW())");
                da.InsertCommand = new MySqlCommand(sql, con);
                string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Saved Successfully");
                MessageBox.Show(mess, "Success");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void spInputbtnReset_Click(object sender, EventArgs e)
        {
            spInputtxtKode.Clear();
            spInputtxtNama.Clear();
            spInputtxtAlamat.Clear();
        }

        private void spInputbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void materialTabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            DataSet ds;
            try
            {
                con.Open();
                ds = new DataSet();
                da = new MySqlDataAdapter("SELECT * FROM pos_supplier", con);
                da.Fill(ds, "pos_supplier");
                dgvSupplier.ReadOnly = true;
                dgvSupplier.AllowUserToAddRows = false;
                dgvSupplier.AllowUserToDeleteRows = false;
                dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSupplier.DataSource = ds.Tables["pos_supplier"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void ebtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            try
            {
                con.Open();
                da = new MySqlDataAdapter();
                string sql = String.Concat("update pos_barang set Kode=", etxtKode.Text, ",Nama=", etxtNama.Text, ",Jumlah_Awal=", Convert.ToInt32(etxtJlhAwal.Text), ",Harga_HPP=", Convert.ToDecimal(etxtHPP.Text), ",Harga_Jual=", Convert.ToDecimal(etxtJual.Text), ",Created_at=NOW(),Updated_at=NOW() where ", etxtID.Text, "=pos_barang.ID");
                da.InsertCommand = new MySqlCommand(sql, con);
                string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Updated Successfully");
                MessageBox.Show(mess, "Success");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void ebtnReset_Click(object sender, EventArgs e)
        {
            etxtKode.Clear();
            etxtNama.Clear();
            etxtJlhAwal.Clear();
            etxtHPP.Clear();
            etxtJual.Clear();
        }

        private void ebtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void csEditbtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            try
            {
                con.Open();
                da = new MySqlDataAdapter();
                string sql = String.Concat("update pos_customer set Kode=", csEdittxtKode.Text, ",Nama=", csEdittxtNama.Text, ",Alamat=", csEdittxtAlamat.Text, ",Created_at=NOW(),Updated_at=NOW() where ", csEdittxtID.Text, "=pos_customer.ID");
                da.InsertCommand = new MySqlCommand(sql, con);
                string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Updated Successfully");
                MessageBox.Show(mess, "Success");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void csEditbtnReset_Click(object sender, EventArgs e)
        {
            csEdittxtKode.Clear();
            csEdittxtNama.Clear();
            csEdittxtAlamat.Clear();
        }

        private void csEditbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spEditbtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            try
            {
                con.Open();
                da = new MySqlDataAdapter();
                string sql = String.Concat("update pos_supplier set Kode=", spEdittxtKode.Text, ",Nama='", spEdittxtNama.Text, "',Alamat='", spEdittxtAlamat.Text, "',Created_at = NOW(),Updated_at = NOW() where ", spEdittxtID.Text, "=pos_supplier.ID");
                da.InsertCommand = new MySqlCommand(sql, con);
                string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Updated Successfully");
                MessageBox.Show(mess, "Success");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void spEditbtnReset_Click(object sender, EventArgs e)
        {
            spEdittxtKode.Clear();
            spEdittxtNama.Clear();
            spEdittxtAlamat.Clear();
        }

        private void spEditbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            DialogResult dialogresult = MessageBox.Show("Do you really want to delete this record?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    da = new MySqlDataAdapter();
                    string sql = String.Concat("delete from pos_barang where pos_barang.ID=", dtxtID.Text);
                    da.InsertCommand = new MySqlCommand(sql, con);
                    string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Deleted Successfully");
                    MessageBox.Show(mess, "Success");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert");
                }
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            dtxtID.Clear();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void csDeletebtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            DialogResult dialogresult = MessageBox.Show("Do you really want to delete this record?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    da = new MySqlDataAdapter();
                    string sql = String.Concat("delete from pos_customer where pos_customer.ID=", csDeletetxtID.Text);
                    da.InsertCommand = new MySqlCommand(sql, con);
                    string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Deleted Successfully");
                    MessageBox.Show(mess, "Success");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert");
                }
            }
        }

        private void csDeletebtnReset_Click(object sender, EventArgs e)
        {
            csDeletetxtID.Clear();
        }

        private void csDeletebtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spDeletebtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            DialogResult dialogresult = MessageBox.Show("Do you really want to delete this record?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    da = new MySqlDataAdapter();
                    string sql = String.Concat("delete from pos_supplier where pos_supplier.ID=", spDeletetxtID.Text);
                    da.InsertCommand = new MySqlCommand(sql, con);
                    string mess = String.Concat(da.InsertCommand.ExecuteNonQuery(), " Record Deleted Successfully");
                    MessageBox.Show(mess, "Success");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert");
                }
            }
        }
    }
}
