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
using Latihan_POS.Class;
namespace Latihan_POS
{
    public partial class MainForm : MaterialForm
    {
        //public int idCust = 0;
        //public int idBarang = 0;
        DataSet ds;
        DataTable dmas;
        clsCustomer cst;
        clsBarang brg;
        clsPenjualanMaster jmt;
        public int jualstate = 0;
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
            clsSupplier sp = new clsSupplier();
            sp.Daftar(dgvSupplier);
        }
        public void connectdbbarang()
        {
            clsBarang Brg = new clsBarang();
            Brg.Daftar(dgvbarang);
        }
        public void connectdbcustomer()
        {
            clsCustomer cs = new clsCustomer();
            cs.Daftar(dgvCustomer);
        }
        public void connectdbpenjualanmaster()
        {
            clsPenjualanMaster jm = new clsPenjualanMaster();
            if (jualstate == 1)
            {                
                ds = new DataSet();
                jm.Daftar(dgvSementara, "pos_penjualan").Fill(ds, "pos_penjualan");
                dgvSementara.Refresh();
            }
            else if (jualstate == 2)
            {
                ds = new DataSet();
                jm.Daftar(dgvSementara, "pos_Customer").Fill(ds, "pos_Customer");
            }
            else
            {
                ds = new DataSet();
                jm.Daftar(dgvSementara, "pos_barang").Fill(ds, "pos_barang");
            }
        }
        public void connectdbpenjualandetail()
        {
            clsPenjualanDetails jd = new clsPenjualanDetails();
            jd.setPenjualan(jmt);
            jd.Daftar(dgvJual);
        }

        //BARANG CONTROL START
        #region BARANG
        private void btnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsBarang Brg = new clsBarang();
            try{
                Brg.SetKode(txtKode.Text);
                Brg.SetNama(txtNama.Text);
                Brg.SetJlhawal(Convert.ToInt32(txtJlhAwal.Text));
                Brg.SetHargahpp(Convert.ToDecimal(txtHPP.Text));
                Brg.SetHargajual(Convert.ToDecimal(txtJual.Text));
                Brg.SetCreatetime(DateTime.Now);
                Brg.SetUpdatetime(DateTime.Now);
                jlhrecord = Brg.InsertBarang();
                MessageBox.Show(jlhrecord.ToString() + " saved successfully", "Success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void ebtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsBarang Brg = new clsBarang();
            try
            {
                Brg.SetKode(etxtKode.Text);
                Brg.SetNama(etxtNama.Text);
                Brg.SetJlhawal(Convert.ToInt32(etxtJlhAwal.Text));
                Brg.SetHargahpp(Convert.ToDecimal(etxtHPP.Text));
                Brg.SetHargajual(Convert.ToDecimal(etxtJual.Text));
                Brg.SetCreatetime(DateTime.Now);
                Brg.SetUpdatetime(DateTime.Now);
                jlhrecord = Brg.UpdateBarang(Convert.ToInt32(etxtID.Text));
                MessageBox.Show(jlhrecord.ToString() + " saved successfully", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void dBtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsBarang Brg = new clsBarang();
            try
            {
                jlhrecord = Brg.DeleteBarang(Convert.ToInt32(dtxtID.Text));
                MessageBox.Show(jlhrecord.ToString() + " deleted successfully", "Success");
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
        private void dBtnReset_Click(object sender, EventArgs e)
        {
            dtxtID.Clear();
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
        #endregion  
        //BARANG CONTROL END

        //CUSTOMER CONTROL START
        #region CUSTOMER
        private void csInputbtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsCustomer cs = new clsCustomer();
            try
            {
                cs.SetKode(csInputtxtKode.Text);
                cs.SetNama(csInputtxtNama.Text);
                cs.SetAlamat(csInputtxtAlamat.Text);
                cs.SetEmail(csInputtxtEmail.Text);
                cs.SetTelepon(csInputtxtTelepon.Text);
                cs.SetPos(csInputtxtKodePos.Text);
                cs.SetCreatetime(DateTime.Now);
                cs.SetUpdatedtime(DateTime.Now);
                jlhrecord = cs.InsertCustomer();
                MessageBox.Show(jlhrecord.ToString() + " saved successfully", "Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void csEditbtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsCustomer cs = new clsCustomer();
            try
            {
                cs.SetKode(csEdittxtKode.Text);
                cs.SetNama(csEdittxtNama.Text);
                cs.SetAlamat(csEdittxtAlamat.Text);
                cs.SetEmail(csEdittxtEmail.Text);
                cs.SetTelepon(csEdittxtTelepon.Text);
                cs.SetPos(csEdittxtKodePos.Text);
                cs.SetUpdatedtime(DateTime.Now);
                jlhrecord = cs.UpdateCustomer(Convert.ToInt32(csEdittxtID.Text));
                MessageBox.Show(jlhrecord.ToString() + " updated successfully", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void csDeletebtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsCustomer cs = new clsCustomer();
            try
            {
                jlhrecord = cs.DeleteCustomer(Convert.ToInt32(csDeletetxtID.Text));
                MessageBox.Show(jlhrecord.ToString() + " deleted successfully", "Success");
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

        private void csEditbtnReset_Click(object sender, EventArgs e)
        {
            csEdittxtID.Clear();
            csEdittxtKode.Clear();
            csEdittxtNama.Clear();
            csEdittxtAlamat.Clear();
            csEdittxtEmail.Clear();
            csEdittxtTelepon.Clear();
            csEdittxtKodePos.Clear();
        }

        private void csDeletebtnReset_Click(object sender, EventArgs e)
        {
            csDeletetxtID.Clear();
        }

        private void csDeleteChoose_Click(object sender, EventArgs e)
        {
            flag_csdeletechoose = true;
            materialTabControl3.SelectedTab = cdaftar;
            connectdbcustomer();
        }

        private void csEditChoose_Click(object sender, EventArgs e)
        {
            flag_cseditchoose = true;
            materialTabControl3.SelectedTab = cdaftar;
            connectdbcustomer();
        }
        private void materialTabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl3.SelectedTab == cdaftar)
            {
                connectdbcustomer();
            }
            else
            {
                flag_cseditchoose = false;
                flag_csdeletechoose = false;
            }
        }
        #endregion
        //CUSTOMER CONTROL END

        //SUPPLIER CONTROL START
        #region CONTROL
        private void spInputbtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsSupplier sp = new clsSupplier();
            try
            {
                sp.SetKode(spInputtxtKode.Text);
                sp.SetNama(spInputtxtNama.Text);
                sp.SetAlamat(spInputtxtAlamat.Text);
                sp.SetEmail(spInputtxtEmail.Text);
                sp.SetTelepon(spInputtxtTelepon.Text);
                sp.SetPos(spInputtxtKodePos.Text);
                sp.SetCreatetime(DateTime.Now);
                sp.SetUpdatedtime(DateTime.Now);
                jlhrecord = sp.InsertSupplier();
                MessageBox.Show(jlhrecord.ToString() + " saved successfully", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void spEditbtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsSupplier sp = new clsSupplier();
            try
            {
                sp.SetKode(spEdittxtKode.Text);
                sp.SetNama(spEdittxtNama.Text);
                sp.SetAlamat(spEdittxtAlamat.Text);
                sp.SetEmail(spEdittxtEmail.Text);
                sp.SetTelepon(spEdittxtTelepon.Text);
                sp.SetPos(spEdittxtKodePos.Text);
                sp.SetUpdatedtime(DateTime.Now);
                jlhrecord = sp.UpdateSupplier(Convert.ToInt32(spEdittxtID.Text));
                MessageBox.Show(jlhrecord.ToString() + " updated successfully", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void spDeletebtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsSupplier sp = new clsSupplier();
            try
            {
                jlhrecord = sp.DeleteSupplier(Convert.ToInt32(spDeletetxtID.Text));
                MessageBox.Show(jlhrecord.ToString() + " deleted successfully", "Success");
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
        

        private void spEditbtnReset_Click(object sender, EventArgs e)
        {
            spEdittxtID.Clear();
            spEdittxtKode.Clear();
            spEdittxtNama.Clear();
            spEdittxtAlamat.Clear();
            spEdittxtEmail.Clear();
            spEdittxtTelepon.Clear();
            spEdittxtKodePos.Clear();
        }
        private void spDeletetbtnReset_Click(object sender, EventArgs e)
        {
            spDeletetxtID.Clear();
        }
        private void spDeleteChoose_Click(object sender, EventArgs e)
        {
            flag_spdeletechoose = true;
            materialTabControl5.SelectedTab = sdaftar;
            connectdbsupplier();
        }

        private void spEditChoose_Click(object sender, EventArgs e)
        {
            flag_speditchoose = true;
            materialTabControl5.SelectedTab = sdaftar;
            connectdbsupplier();
        }
        private void materialTabControl5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl5.SelectedTab == sdaftar)
            {
                connectdbsupplier();
            }
            else
            {
                flag_speditchoose = false;
                flag_spdeletechoose = false;
            }
        }
        #endregion
        //SUPPLIER CONTROL END

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
                    csEdittxtEmail.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                    csEdittxtTelepon.Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                    csEdittxtKodePos.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
                    materialTabControl3.SelectedTab = cedit;
                    flag_cseditchoose = false;
                }
                else if (flag_csdeletechoose == true)
                {
                    csDeletetxtID.Text = dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                    materialTabControl3.SelectedTab = cdelete;
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
                    spEdittxtEmail.Text = dgvSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
                    spEdittxtTelepon.Text = dgvSupplier.Rows[e.RowIndex].Cells[5].Value.ToString();
                    spEdittxtKodePos.Text = dgvSupplier.Rows[e.RowIndex].Cells[6].Value.ToString();
                    materialTabControl5.SelectedTab = sedit;
                    flag_speditchoose = false;
                }
                else if (flag_spdeletechoose == true)
                {
                    spDeletetxtID.Text = dgvSupplier.Rows[e.RowIndex].Cells[0].Value.ToString();
                    materialTabControl5.SelectedTab = sdelete;
                    flag_spdeletechoose = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
        }
  
        //PENJUALAN START
        private void materialTabControl6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dmas = new DataTable();
            BindingSource bs = new BindingSource();
            bs.DataSource = dmas;
            dgvSementara.DataSource = bs;
        }
        private void materialTabControl7_SelectedIndexChanged(object sender, EventArgs e)
        {
                dmas = new DataTable();
                BindingSource bs = new BindingSource();
                bs.DataSource = dmas;
                dgvSementara.DataSource = bs;
        }

        private void JualKodeSearch_Click(object sender, EventArgs e)
        {
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_penjualan";
            clsPenjualanMaster.Daftar().Fill(dmas);

        }

        private void JualCustSearch_Click(object sender, EventArgs e)
        {
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_customer";
            clsCustomer.Daftar().Fill(dmas);
        }

        private void JualBarangSearch_Click(object sender, EventArgs e)
        {
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_barang";
            clsBarang.Daftar().Fill(dmas);
        }

        private void JualAdd_Click(object sender, EventArgs e)
        {
            int insertupdatemaster = 0;
            int insertupdatedetail = 0;
            int jlhrecordmaster = 0;
            int jlhrecorddetail = 0;
            clsPenjualanMaster jm = new clsPenjualanMaster();
            clsPenjualanDetails jd = new clsPenjualanDetails();
            try
            {
                jlhrecordmaster = jm.SearchSell(JualtxtKode.Text);
                if (jlhrecordmaster == 0)
                {
                    //INSERT
                    jm.setCustomer(cst);
                    jm.SetKode(JualtxtKode.Text);
                    jm.SetCreatetime(DateTime.Now);
                    jm.SetUpdatetime(DateTime.Now);
                    insertupdatemaster = jm.AddSell();
                    jd.SetBarang(brg);
                    jd.setPenjualan(jm);
                    jd.SetHargaBarang(Convert.ToDecimal(JualtxtHrgBarang.Text));
                    jd.SetKuantitas(Convert.ToInt32(JualtxtKuantitas.Text));
                    jd.SetCreatetime(DateTime.Now);
                    jd.SetUpdatedtime(DateTime.Now);
                    jd.AddSellDetail();
                    jmt = jm;
                    MessageBox.Show(insertupdatemaster.ToString() + " saved successfully", "DB Penjualan Master");
                }
                else 
                {
                    //UPDATE
                    jm.setCustomer(cst);
                    jm.SetUpdatetime(DateTime.Now);
                    insertupdatemaster = jm.UpdateSell(JualtxtKode.Text);
                    jd.setPenjualan(jm);
                    jd.SetBarang(brg);
                    jd.SetHargaBarang(Convert.ToDecimal(JualtxtHrgBarang.Text));
                    jd.SetKuantitas(Convert.ToInt32(JualtxtKuantitas.Text));
                    jlhrecorddetail = jd.SearchSell();
                    if (jlhrecorddetail >= 1)
                    {
                        //UPDATE DETAIL
                        jd.SetUpdatedtime(DateTime.Now);
                        insertupdatedetail = jd.UpdateSellDetail();
                    }
                    else
                    {
                        //INSERT DETAIL
                        jd.SetCreatetime(DateTime.Now);
                        jd.SetUpdatedtime(DateTime.Now);
                        insertupdatedetail = jd.AddSellDetail();
                    }
                    MessageBox.Show(insertupdatemaster.ToString() + " updated successfully", "DB Penjualan Master");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert");
            }
            connectdbpenjualandetail();
        }

        private void JualtxtKuantitas_TextChanged(object sender, EventArgs e)
        {
            if (JualtxtKuantitas.Text.Trim().Length == 0 || JualtxtHrgBarang.Text.Trim().Length == 0) JualtxtSubtotal.Text = "0.00";
            else
            {
                decimal jlh = Convert.ToDecimal(JualtxtKuantitas.Text);
                decimal harga = Convert.ToDecimal(JualtxtHrgBarang.Text);
                JualtxtSubtotal.Text = string.Format("{0 : 0.00}", jlh * harga);
            }
        }

        private void dgvSementara_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return;
            if (dmas.TableName == "pos_barang")
            {
                brg = new clsBarang();
                brg.setProperties(dmas.Rows[e.RowIndex]);
                JualtxtBarang.Text = brg.nama;
                JualtxtHrgBarang.Text = brg.harga_jual.ToString();
                materialTabControl6.SelectedTab = penjualan;
            }
            else if(dmas.TableName == "pos_customer")
            {
                cst = new clsCustomer();
                cst.setProperties(dmas.Rows[e.RowIndex]);
                JualtxtCustomer.Text = cst.nama;
                materialTabControl6.SelectedTab = penjualan;
            }
            else if(dmas.TableName == "pos_penjualan")
            {
                cst = new clsCustomer();
                jmt = new clsPenjualanMaster();
                jmt.setProperties(dmas.Rows[e.RowIndex]);
                JualtxtKode.Text = jmt.kode;
                JualtxtCustomer.Text = jmt.customer.nama;
                cst.SetID(jmt.customer.ID);
                materialTabControl6.SelectedTab = penjualan;
                connectdbpenjualandetail();
            }
        }
    }
}
