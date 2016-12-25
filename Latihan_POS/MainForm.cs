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
        int isJualorBeli = 0;
        bool fieldstat = true;
        DataSet ds;
        DataTable dmas;
        clsCustomer cst;
        clsSupplier spt;
        clsBarang brg;
        clsPenjualanMaster jmt;
        clsPembelianMaster bmt;
        public int jualstate = 0;
        public int belistate = 0;
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
            jm.Daftar(dgvJualMaster, "pos_penjualan");
        }
        public void connectdbpenjualandetail()
        {
            clsPenjualanDetails jd = new clsPenjualanDetails();
            jd.setPenjualan(jmt);
            jd.Daftar(dgvJual);
        }
        public void connectdbpenjualandetaildaftar()
        {
            clsPenjualanDetails jd = new clsPenjualanDetails();
            jd.DaftarShow(dgvJualDetail, "pos_penjualan_detail");
        }
        public void connectdbpembelianmaster()
        {
            clsPembelianMaster bm = new clsPembelianMaster();
            bm.Daftar(dgvBeliMaster, "pos_pembelian");
        }
        public void connectdbpembeliandetaildaftar()
        {
            clsPembelianDetails bd = new clsPembelianDetails();
            bd.DaftarShow(dgvBeliDetail, "pos_pembelian_detail");
        }
        public void connectdbpembeliandetail()
        {
            clsPembelianDetails bd = new clsPembelianDetails();
            bd.setPembelian(bmt);
            bd.Daftar(dgvBeli);
        }
        //BARANG CONTROL START
        #region BARANG
        private void btnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsBarang Brg = new clsBarang();
            try{
                foreach (Control i in binput.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
                foreach (Control i in bedit.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
                if (fieldstat == false)
                {
                    MessageBox.Show("Input field may not be empty", "Alert");
                }
                else MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void dBtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsBarang Brg = new clsBarang();
            try
            {
                foreach (Control i in bdelete.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
                foreach (Control i in cinput.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
                foreach (Control i in cedit.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
                foreach (Control i in cdelete.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
        #region SUPPLIER
        private void spInputbtnOK_Click(object sender, EventArgs e)
        {
            int jlhrecord = 0;
            clsSupplier sp = new clsSupplier();
            try
            {
                foreach (Control i in sinput.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
                foreach (Control i in sedit.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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
                foreach (Control i in sdelete.Controls)
                {
                    if (i is MaterialSingleLineTextField && ((i as MaterialSingleLineTextField).Text).Trim().Length == 0)
                    {
                        throw new Exception("Input field may not be empty");
                    }
                }
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

        //CELL CLICK
        #region cellclick
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
        #endregion
        //CELL CLICK END

        //PENJUALAN START
        #region PENJUALAN
        private void materialTabControl6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dmas = new DataTable();
            BindingSource bs = new BindingSource();
            bs.DataSource = dmas;
            dgvSementara.DataSource = bs;

            if (materialTabControl6.SelectedTab == daftartransaksi)
            {
                connectdbpenjualanmaster();
                connectdbpenjualandetaildaftar();
                connectdbpembelianmaster();
                connectdbpembeliandetaildaftar();
            }
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
            isJualorBeli = 1;
            totalharga();
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_penjualan";
            clsPenjualanMaster.Daftar().Fill(dmas);

        }

        private void JualCustSearch_Click(object sender, EventArgs e)
        {
            isJualorBeli = 1;
            totalharga();
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_customer";
            clsCustomer.Daftar().Fill(dmas);
        }

        private void JualBarangSearch_Click(object sender, EventArgs e)
        {
            isJualorBeli = 1;
            totalharga();
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_barang";
            clsBarang.Daftar().Fill(dmas);
        }

        private void JualAdd_Click(object sender, EventArgs e)
        {
            isJualorBeli = 1;
            fieldstat = true;
            try
            {
                foreach (Control i in penjualan.Controls)
                {
                    if (i is MaterialSingleLineTextField)
                    {
                        if (((i as MaterialSingleLineTextField).Text).Trim().Length == 0 || (i as MaterialSingleLineTextField).Text == "Click Search")
                        {
                            fieldstat = false;
                        }
                    }
                }
                    int insertupdatemaster = 0;
                    int insertupdatedetail = 0;
                    int jlhrecordmaster = 0;
                    int jlhrecorddetail = 0;
                    clsPenjualanMaster jm = new clsPenjualanMaster();
                    clsPenjualanDetails jd = new clsPenjualanDetails();
                    jlhrecordmaster = jm.SearchSell(JualtxtKode.Text);
                    if (jlhrecordmaster == 0 && fieldstat == true)
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
                        jmt = jm;
                        if (Convert.ToInt32(JualtxtKuantitas.Text) > jd.barang.jlh_awal)
                        {
                            MessageBox.Show("Not Enough Stock");
                        }
                        else
                        {
                            jd.AddSellDetail();
                            MessageBox.Show(insertupdatemaster.ToString() + " saved successfully", "DB Penjualan Master");
                        }
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
                            if (Convert.ToInt32(JualtxtKuantitas.Text) > jd.barang.jlh_awal)
                            {
                                MessageBox.Show("Not Enough Stock");
                            }
                            else
                            {
                                insertupdatedetail = jd.UpdateSellDetail();
                                MessageBox.Show(insertupdatemaster.ToString() + " updated successfully", "DB Penjualan Master");
                            }
                        }
                        else
                        {
                            //INSERT DETAIL
                            jd.SetCreatetime(DateTime.Now);
                            jd.SetUpdatedtime(DateTime.Now);
                            if (Convert.ToInt32(JualtxtKuantitas.Text) > jd.barang.jlh_awal)
                            {
                                MessageBox.Show("Not Enough Stock");
                            }
                            else
                            {
                                insertupdatedetail = jd.AddSellDetail();
                                MessageBox.Show(insertupdatemaster.ToString() + " saved successfully", "DB Penjualan Master");
                            }

                        }
                    }
                    connectdbpenjualandetail();
                    totalharga();
                }
            catch (Exception ex)
            {
                if (fieldstat == false)
                {
                    MessageBox.Show("Input field may not be empty", "Alert");
                }
                else MessageBox.Show(ex.Message, "Alert");
            }
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
            if (isJualorBeli == 1)
            {
                if (dmas.TableName == "pos_barang")
                {
                    brg = new clsBarang();
                    brg.setProperties(dmas.Rows[e.RowIndex]);
                    JualtxtBarang.Text = brg.nama;
                    JualtxtHrgBarang.Text = brg.harga_jual.ToString();
                    materialTabControl6.SelectedTab = penjualan;
                }
                else if (dmas.TableName == "pos_customer")
                {
                    cst = new clsCustomer();
                    cst.setProperties(dmas.Rows[e.RowIndex]);
                    JualtxtCustomer.Text = cst.nama;
                    materialTabControl6.SelectedTab = penjualan;
                }
                else if (dmas.TableName == "pos_penjualan")
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
                isJualorBeli = 0;
            }
            else if(isJualorBeli == 2)
            {
                if (dmas.TableName == "pos_barang")
                {
                    brg = new clsBarang();
                    brg.setProperties(dmas.Rows[e.RowIndex]);
                    BelitxtBarang.Text = brg.nama;
                    BelitxtHPP.Text = brg.harga_hpp.ToString();
                    materialTabControl6.SelectedTab = pembelian;
                }
                else if (dmas.TableName == "pos_supplier")
                {
                    spt = new clsSupplier();
                    spt.setProperties(dmas.Rows[e.RowIndex]);
                    BelitxtSupplier.Text = spt.nama;
                    materialTabControl6.SelectedTab = pembelian;
                }
                else if (dmas.TableName == "pos_pembelian")
                {
                    spt = new clsSupplier();
                    bmt = new clsPembelianMaster();
                    bmt.setProperties(dmas.Rows[e.RowIndex]);
                    BelitxtKode.Text = bmt.kode;
                    BelitxtSupplier.Text = bmt.supplier.nama;
                    spt.SetID(bmt.supplier.ID);
                    materialTabControl6.SelectedTab = pembelian;
                    connectdbpembeliandetail();
                }
                isJualorBeli = 0;
            }
        }
        private void JualReset_Click(object sender, EventArgs e)
        {
            JualtxtKode.Clear();
            JualtxtCustomer.Text = "Click Search";
            JualtxtBarang.Text = "Click Search";
            JualtxtHrgBarang.Clear();
            JualtxtKuantitas.Clear();
            JualtxtSubtotal.Text = "0.00";
            JualtxtTotalHarga.Text = "0.00";
        }
        #endregion
        //PENJUALAN END

        //PEMBELIAN START
        #region PEMBELIAN
        private void BeliAdd_Click(object sender, EventArgs e)
        {
            isJualorBeli = 2;
            fieldstat = true;
            try
            {
                foreach (Control i in pembelian.Controls)
                {
                    if (i is MaterialSingleLineTextField)
                    {
                        if (((i as MaterialSingleLineTextField).Text).Trim().Length == 0 || (i as MaterialSingleLineTextField).Text == "Click Search")
                        {
                            fieldstat = false;
                        }
                    }
                }
                int insertupdatemaster = 0;
                int insertupdatedetail = 0;
                int jlhrecordmaster = 0;
                int jlhrecorddetail = 0;
                clsPembelianMaster bm = new clsPembelianMaster();
                clsPembelianDetails bd = new clsPembelianDetails();
                jlhrecordmaster = bm.SearchBuy(BelitxtKode.Text);
                if (jlhrecordmaster == 0 && fieldstat == true)
                {
                    //INSERT
                    bm.setSupplier(spt);
                    bm.SetKode(BelitxtKode.Text);
                    bm.SetCreatetime(DateTime.Now);
                    bm.SetUpdatetime(DateTime.Now);
                    insertupdatemaster = bm.AddBuy();
                    bd.SetBarang(brg);
                    bd.setPembelian(bm);
                    bd.SetHargaHPP(Convert.ToDecimal(BelitxtHPP.Text));
                    bd.SetKuantitas(Convert.ToInt32(BelitxtKuantitas.Text));
                    bd.SetCreatetime(DateTime.Now);
                    bd.SetUpdatedtime(DateTime.Now);
                    bmt = bm;
                    if (Convert.ToInt32(BelitxtKuantitas.Text) > bd.barang.jlh_awal)
                    {
                        MessageBox.Show("Not Enough Stock");
                    }
                    else
                    {
                        bd.AddBuyDetail();
                        MessageBox.Show(insertupdatemaster.ToString() + " saved successfully", "DB pembelian Master");
                    }
                }
                else
                {
                    //UPDATE
                    bm.setSupplier(spt);
                    bm.SetUpdatetime(DateTime.Now);
                    insertupdatemaster = bm.UpdateBuy(BelitxtKode.Text);
                    bd.setPembelian(bm);
                    bd.SetBarang(brg);
                    bd.SetHargaHPP(Convert.ToDecimal(BelitxtHPP.Text));
                    bd.SetKuantitas(Convert.ToInt32(BelitxtKuantitas.Text));
                    jlhrecorddetail = bd.SearchBuy();
                    if (jlhrecorddetail >= 1)
                    {
                        //UPDATE DETAIL
                        bd.SetUpdatedtime(DateTime.Now);
                        if (Convert.ToInt32(BelitxtKuantitas.Text) < 0)
                        {
                            MessageBox.Show("Please Insert the Correct Value");
                        }
                        else
                        {   
                            insertupdatedetail = bd.UpdateBuyDetail();
                            MessageBox.Show(insertupdatemaster.ToString() + " updated successfully", "DB pembelian Master");
                        }
                    }
                    else
                    {
                        //INSERT DETAIL
                        bd.SetCreatetime(DateTime.Now);
                        bd.SetUpdatedtime(DateTime.Now);
                        if (Convert.ToInt32(BelitxtKuantitas.Text) < 1)
                        {
                            MessageBox.Show("Please Insert the Correct Value");
                        }
                        else
                        {
                            insertupdatedetail = bd.AddBuyDetail();
                            MessageBox.Show(insertupdatemaster.ToString() + " saved successfully", "DB pembelian Master");
                        }

                    }
                }
                connectdbpembeliandetail();
                totalharga();
            }
            catch (Exception ex)
            {
                if (fieldstat == false)
                {
                    MessageBox.Show("Input field may not be empty", "Alert");
                }
                else MessageBox.Show(ex.Message, "Alert");
            }
        }
        private void BelitxtKuantitas_TextChanged(object sender, EventArgs e)
        {
            if (BelitxtKuantitas.Text.Trim().Length == 0 || BelitxtHPP.Text.Trim().Length == 0) BelitxtSubtotal.Text = "0.00";
            else
            {
                decimal jlh = Convert.ToDecimal(BelitxtKuantitas.Text);
                decimal harga = Convert.ToDecimal(BelitxtHPP.Text);
                BelitxtSubtotal.Text = string.Format("{0 : 0.00}", jlh * harga);
            }
        }
        private void BeliSearchKode_Click(object sender, EventArgs e)
        {
            isJualorBeli = 2;
            totalharga();
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_pembelian";
            clsPembelianMaster.Daftar().Fill(dmas);
        }

        private void BeliSearchSupplier_Click(object sender, EventArgs e)
        {
            isJualorBeli = 2;
            totalharga();
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_supplier";
            clsSupplier.Daftar().Fill(dmas);
        }

        private void BeliSearchBarang_Click(object sender, EventArgs e)
        {
            isJualorBeli = 2;
            totalharga();
            materialTabControl6.SelectedTab = daftartransaksi;
            materialTabControl7.SelectedTab = daftarsementara;
            dmas.TableName = "pos_barang";
            clsBarang.Daftar().Fill(dmas);
        }
        private void BeliReset_Click(object sender, EventArgs e)
        {
            BelitxtKode.Clear();
            BelitxtSupplier.Text = "Click Search";
            BelitxtBarang.Text = "Click Search";
            BelitxtHPP.Clear();
            BelitxtKuantitas.Clear();
            BelitxtSubtotal.Text = "0.00";
            BelitxtTotal.Text = "0.00";
        }
        public void totalharga()
        {
            //TOTAL HARGA
            decimal tot = 0, par1, par2;
            if (isJualorBeli == 1)
            {
                foreach (DataGridViewRow i in dgvJual.Rows)
                {
                    par1 = Convert.ToDecimal(i.Cells["Harga_barang"].Value);
                    par2 = Convert.ToDecimal(i.Cells["Kuantitas"].Value);
                    tot += par1 * par2;
                }
                JualtxtTotalHarga.Text = string.Format("{0:N}", tot);
            }
            else if (isJualorBeli == 2)
            {
                foreach (DataGridViewRow i in dgvBeli.Rows)
                {
                    par1 = Convert.ToDecimal(i.Cells["Harga_HPP"].Value);
                    par2 = Convert.ToDecimal(i.Cells["Kuantitas"].Value);
                    tot += par1 * par2;
                }
                BelitxtTotal.Text = string.Format("{0:N}", tot);
            }
        }
        #endregion       
        //PEMBELIAN END
    }
}
