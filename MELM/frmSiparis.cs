using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MELM
{
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }
        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;

                default:
                    MessageBox.Show("Sayı Giriniz.");
                    break;
            }
        }
        int TableID = 0; int AdditionID = 0;
        private void frmSiparis_Load(object sender, EventArgs e)
        {
            lblMasaNo.Text = cGenel.ButtonValue;
            cMasalar ms = new cMasalar();
            TableID = ms.TableGetbyNumber(cGenel.ButtonName);
            if (ms.TableGetbyState(TableID, 2) == true || (ms.TableGetbyState(TableID, 4) == true))
            {
                cAdisyon Ad = new cAdisyon();
                AdditionID = Ad.getByAddition(TableID);
                cSiparis orders = new cSiparis();
                orders.getByOrder(lvSiparisler, AdditionID);
            }

            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
        }

        private void btnAdet_TextChanged(object sender, EventArgs e)
        {

        }
        cUrunCesitleri uc = new cUrunCesitleri();
        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnAnaYemek1);
        }

        private void btnİçecekler8_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnİçecekler8);
        }

        private void btnTatlılar7_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnTatlılar7);
        }

        private void btnSalatalar6_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnSalatalar6);
        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnFastFood5);
        }

        private void btnÇorbalar2_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnÇorbalar2);
        }

        private void btnMakarnalar4_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnMakarnalar4);
        }

        private void btnAraSıcaklar3_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenü, btnAraSıcaklar3);
        }
        int sayac = 0; int sayac2 = 0;
        private void lvMenü_DoubleClick(object sender, EventArgs e)
        {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }



            if (lvMenü.Items.Count > 0)
            {
                sayac = lvSiparisler.Items.Count;
                lvSiparisler.Items.Add(lvMenü.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenü.SelectedItems[0].SubItems[2].Text);
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenü.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());

                lvYeniEklenenler.Items.Add(AdditionID.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenü.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(TableID.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());
                sayac2++;
                txtAdet.Text = "";
            }
        }
        ArrayList silinenler = new ArrayList();

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            cMasalar masa = new cMasalar();
            frmMasalar ms = new frmMasalar();
            cAdisyon newAddition = new cAdisyon();
            cSiparis saveOrder = new cSiparis();
            bool sonuc = false;
            if (masa.TableGetbyState(TableID, 1) == true)
            {
                newAddition.ServisTurNo1 = 1;
               
                newAddition.PersonelID1 = 1;
                newAddition.MasaID1 = TableID;
                newAddition.Tarih1 = DateTime.Now;
                sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(cGenel.ButtonName, 2);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.MasaID1 = TableID;
                        saveOrder.UrunID1 = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID1 = newAddition.getByAddition(TableID);
                        saveOrder.Adet1 = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);

                        saveOrder.setSaveOrder(saveOrder);

                    }
                    this.Close();
                    ms.Show();
                }
            }
            else if (masa.TableGetbyState(TableID, 2) == true || masa.TableGetbyState(TableID, 4) == true)
            {
                
                if (lvYeniEklenenler.Items.Count > 0)
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        saveOrder.MasaID1 = TableID;
                        saveOrder.UrunID1 = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        saveOrder.AdisyonID1 = newAddition.getByAddition(TableID);
                        saveOrder.Adet1 = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                   
                }
                if (silinenler.Count > 0)
                {
                    foreach (string item in silinenler)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }
                }
                this.Close();
                ms.Show();
            }
            else if (masa.TableGetbyState(TableID, 3) == true)
            {
               
                masa.setChangeTableState(cGenel.ButtonName, 4);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.MasaID1 = TableID;
                        saveOrder.UrunID1 = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID1 = newAddition.getByAddition(TableID);
                        saveOrder.Adet1 = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);

                        saveOrder.setSaveOrder(saveOrder);

                    }
                    this.Close();
                    ms.Show();
                }

            }
            

        }

        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparisler.Items.Count > 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    cSiparis saveOrder = new cSiparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }
                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);
            }
        }
        
        private void btnOdeme_Click(object sender, EventArgs e)
        {
            cGenel.ServisTurNo = 1;
            cGenel.AdisyonID = AdditionID.ToString();
            frmBill frm = new frmBill();
            this.Close();
            frm.Show();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if(txtAra.Text == "")
            {
                txtAra.Text = "";
            }
            else
            {
                cUrunCesitleri cu = new cUrunCesitleri();
                cu.getByProductSearch(lvMenü, Convert.ToInt32(txtAra.Text));
            }

        }
    }
}
