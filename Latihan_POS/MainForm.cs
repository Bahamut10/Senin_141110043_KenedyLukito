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
        public bool flag_beditchoose = false;
        public bool flag_bdeletechoose = false;
        public bool flag_cseditchoose = false;
        public bool flag_csdeletechoose = false;
        public bool flag_speditchoose = false;
        public bool flag_spdeletechoose = false;
        
        public MainForm()
        {
            InitializeComponent();
        }
        public void connectdbsupplier()
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
        public void connectdbbarang()
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
        public void connectdbcustomer()
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
            if (materialTabControl2.SelectedTab.Name == "cdaftar")
            {
                connectdbcustomer();
            }
            else
            {
                flag_cseditchoose = false;
                flag_csdeletechoose = false;
            }
        }

        private void materialTabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl4.SelectedTab == bdaftar)
            {
                connectdbbarang();
            }
            else 
            { 
                flag_beditchoose = false;
                flag_bdeletechoose = false;
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
            if (materialTabControl3.SelectedTab.Name == "sdaftar")
            {
                connectdbsupplier();
            }
            else
            {
                flag_speditchoose = false;
                flag_spdeletechoose = false;
            }
        }
        private void ebtnOK_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            string mess;
            try
            {
                con.Open();
                da = new MySqlDataAdapter();
                string sql = String.Concat("update pos_barang set Kode='", etxtKode.Text, "',Nama='", etxtNama.Text, "',Jumlah_Awal=", Convert.ToInt32(etxtJlhAwal.Text), ",Harga_HPP=", Convert.ToDecimal(etxtHPP.Text), ",Harga_Jual=", Convert.ToDecimal(etxtJual.Text), ",Updated_at=NOW() where ", etxtID.Text, "=pos_barang.ID");
                da.UpdateCommand = new MySqlCommand(sql, con);
                if (da.UpdateCommand.ExecuteNonQuery() == 0)
                {
                    mess = "Record not found";
                    MessageBox.Show(mess, "Alert");
                }
                else
                {
                    mess = String.Concat(da.UpdateCommand.ExecuteNonQuery(), " Record Updated Successfully");
                    MessageBox.Show(mess, "Success");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void ebtnReset_Click(object sender, EventArgs e)
        {
            etxtID.Clear();
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
            string mess;
            try
            {
                con.Open();
                da = new MySqlDataAdapter();
                string sql = String.Concat("update pos_customer set Kode='", csEdittxtKode.Text, "',Nama='", csEdittxtNama.Text, "',Alamat='", csEdittxtAlamat.Text, "',Updated_at=NOW() where ", csEdittxtID.Text, "=pos_customer.ID");
                da.UpdateCommand = new MySqlCommand(sql, con);
                if (da.UpdateCommand.ExecuteNonQuery() == 0)
                {
                    mess = "Record not found";
                    MessageBox.Show(mess, "Alert");
                }
                else
                {
                    mess = String.Concat(da.UpdateCommand.ExecuteNonQuery(), " Record Updated Successfully");
                    MessageBox.Show(mess, "Success");
                }
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
            string mess;
            try
            {
                con.Open();
                da = new MySqlDataAdapter();
                string sql = String.Concat("update pos_supplier set Kode='", spEdittxtKode.Text, "',Nama='", spEdittxtNama.Text, "',Alamat='", spEdittxtAlamat.Text, "',Updated_at = NOW() where ", spEdittxtID.Text, "=pos_supplier.ID");
                da.UpdateCommand = new MySqlCommand(sql, con);
                if (da.UpdateCommand.ExecuteNonQuery() == 0)
                {
                    mess = "Record not found";
                    MessageBox.Show(mess, "Alert");
                }
                else
                {
                    mess = String.Concat(da.UpdateCommand.ExecuteNonQuery(), " Record Updated Successfully");
                    MessageBox.Show(mess, "Success");
                }
                con.Close();
                mess = "";
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
            //dDeletebtnOK
            MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true");
            MySqlDataAdapter da;
            string mess;
            DialogResult dialogresult = MessageBox.Show("Do you really want to delete this record?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    da = new MySqlDataAdapter();
                    string sql = String.Concat("delete from pos_barang where pos_barang.ID=", dtxtID.Text);
                    da.DeleteCommand = new MySqlCommand(sql, con);
                    if (da.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        mess = "Record not found";
                        MessageBox.Show(mess, "Alert");
                    }
                    else
                    {
                        mess = String.Concat(da.DeleteCommand.ExecuteNonQuery()+1, " Record Deleted Successfully");
                        MessageBox.Show(mess, "Success");
                    }
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
            string mess;
            DialogResult dialogresult = MessageBox.Show("Do you really want to delete this record?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    da = new MySqlDataAdapter();
                    string sql = String.Concat("delete from pos_customer where pos_customer.ID=", csDeletetxtID.Text);
                    da.DeleteCommand = new MySqlCommand(sql, con);
                    if (da.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        mess = "Record not found";
                        MessageBox.Show(mess, "Alert");
                    }
                    else
                    {
                        mess = String.Concat(da.DeleteCommand.ExecuteNonQuery()+1, " Record Deleted Successfully");
                        MessageBox.Show(mess, "Success");
                    }
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
            string mess;
            DialogResult dialogresult = MessageBox.Show("Do you really want to delete this record?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    da = new MySqlDataAdapter();
                    string sql = String.Concat("delete from pos_supplier where pos_supplier.ID=", spDeletetxtID.Text);
                    da.DeleteCommand = new MySqlCommand(sql, con);
                    if (da.DeleteCommand.ExecuteNonQuery() == 0)
                    {
                        mess = "Record not found";
                        MessageBox.Show(mess, "Alert");
                    }
                    else
                    {
                        mess = String.Concat(da.DeleteCommand.ExecuteNonQuery()+1, " Record Deleted Successfully");
                        MessageBox.Show(mess, "Success");
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert");
                }
            }
        }

        private void dgvbarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (flag_beditchoose == true)
                {
                    etxtID.Text = dgvbarang.Rows[e.RowIndex].Cells[0].Value.ToString();
                    etxtKode.Text = dgvbarang.Rows[e.RowIndex].Cells[1].Value.ToString();
                    etxtNama.Text = dgvbarang.Rows[e.RowIndex].Cells[2].Value.ToString();
                    etxtJlhAwal.Text = dgvbarang.Rows[e.RowIndex].Cells[3].Value.ToString();
                    etxtHPP.Text = dgvbarang.Rows[e.RowIndex].Cells[4].Value.ToString();
                    etxtJual.Text = dgvbarang.Rows[e.RowIndex].Cells[5].Value.ToString();
                    materialTabControl4.SelectedTab = bedit;
                    flag_beditchoose = false;
                }
                else if (flag_bdeletechoose == true)
                {
                    dtxtID.Text = dgvbarang.Rows[e.RowIndex].Cells[0].Value.ToString();
                    materialTabControl4.SelectedTab = bdelete;
                    flag_bdeletechoose = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (flag_cseditchoose == true)
                {
                    csEdittxtID.Text = dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                    csEdittxtKode.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                    csEdittxtNama.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                    csEdittxtAlamat.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                    materialTabControl2.SelectedTab = cedit;
                    flag_cseditchoose = false;
                }
                else if (flag_csdeletechoose == true)
                {
                    csDeletetxtID.Text = dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                    materialTabControl2.SelectedTab = cdelete;
                    flag_csdeletechoose = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (flag_speditchoose == true)
                {
                    spEdittxtID.Text = dgvSupplier.Rows[e.RowIndex].Cells[0].Value.ToString();
                    spEdittxtKode.Text = dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
                    spEdittxtNama.Text = dgvSupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
                    spEdittxtAlamat.Text = dgvSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
                    materialTabControl3.SelectedTab = sedit;
                    flag_speditchoose = false;
                }
                else if (flag_spdeletechoose == true)
                {
                    spDeletetxtID.Text = dgvSupplier.Rows[e.RowIndex].Cells[0].Value.ToString();
                    materialTabControl3.SelectedTab = sdelete;
                    flag_spdeletechoose = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }

        private void bchoose_Click(object sender, EventArgs e)
        {
            flag_beditchoose = true;
            materialTabControl4.SelectedTab = bdaftar;
            connectdbbarang();
        }
        private void bDeleteChoose_Click(object sender, EventArgs e)
        {
            flag_bdeletechoose = true;
            materialTabControl4.SelectedTab = bdaftar;
            connectdbbarang();
        }

        private void spDeleteChoose_Click(object sender, EventArgs e)
        {
            flag_spdeletechoose = true;
            materialTabControl3.SelectedTab = sdaftar;
            connectdbsupplier();
        }

        private void spEditChoose_Click(object sender, EventArgs e)
        {
            flag_speditchoose = true;
            materialTabControl3.SelectedTab = sdaftar;
            connectdbsupplier();
        }

        private void csDeleteChoose_Click(object sender, EventArgs e)
        {
            flag_csdeletechoose = true;
            materialTabControl2.SelectedTab = cdaftar;
            connectdbcustomer();
        }

        private void csEditChoose_Click(object sender, EventArgs e)
        {
            flag_cseditchoose = true;
            materialTabControl2.SelectedTab = cdaftar;
            connectdbcustomer();
        }
    }
}
