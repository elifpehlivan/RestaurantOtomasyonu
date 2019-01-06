using System;
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
    public partial class frmRezervasyon : Form
    {
        public frmRezervasyon()
        {
            InitializeComponent();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.MusterileriGetir(lvMusteriler);

            cMasalar masa = new cMasalar();
            masa.MasaKapasitesiveDurumuGetir(cbMasa);
            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Time;
        }

        private void txtMusteriAdı_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.MusteriGetirAd(lvMusteriler, txtMusteriAdı.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.MusteriGetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.MusteriGetirAd(lvMusteriler, txtAdres.Text);
        }
        void Temizle()
        {
            txtAdres.Clear();
            txtKisiSayisi.Clear();
            txtMasa.Clear();
            txtTarih.Clear();
           
        }

        private void btnRezervasyonAc_Click(object sender, EventArgs e)
        {
            cRezervasyonlar r = new cRezervasyonlar();
            if(lvMusteriler.SelectedItems.Count > 0)
            {
                bool sonuc = r.RezervasyonAcıkmıKontrol(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                if(!sonuc)
                {
                    if(txtTarih.Text != "")
                    {
                        if(txtKisiSayisi.Text != "")
                        {
                            cMasalar masa = new cMasalar();
                            if (masa.TableGetbyState(Convert.ToInt32(txtMasaNo.Text),1))
                            {
                                cAdisyon a = new cAdisyon();
                                a.Tarih1 = Convert.ToDateTime(txtTarih.Text);
                                a.ServisTurNo1 = 1;
                                a.MasaID1 = Convert.ToInt32(txtMasaNo.Text);
                                a.PersonelID1 = cGenel.PersonelID;

                                r.ClientID1 = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                                r.TableID1 = Convert.ToInt32(txtMasaNo.Text);
                                r.Date1 = Convert.ToDateTime(txtTarih.Text);
                                r.ClientCount1 = Convert.ToInt32(txtKisiSayisi.Text);
                                r.Description1 = txtAcıklama.Text;

                                r.AdditionID1 = a.RezervasyonAdisyonAc(a);
                                sonuc = r.RezervasyonAc(r);

                                masa.setChangeTableState(txtMasaNo.Text,4);
                                if(sonuc)
                                {
                                    MessageBox.Show("Rezervasyon başarıyla Açılmıştır.");
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon kayıdı gerçekleşememiştir!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon yapılan masa şuan dolu!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen kişi sayısını seçiniz!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir tarih seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Bu müşteri üzerine açık bir rezervasyon bulunmaktadır!");
                }
            }
        }

        private void dtTarih_MouseEnter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_Enter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_MouseLeave(object sender, EventArgs e)
        {
            dtTarih.Width = 23;
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtTarih.Value.ToString();
        }

        private void cbKisiSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = cbKisiSayisi.SelectedItem.ToString();
        }

        private void cbMasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Enabled = true;
            txtMasa.Text = cbMasa.SelectedItem.ToString();

            cMasalar Kapasitesi = (cMasalar)cbMasa.SelectedItem;
            int kapasite = Kapasitesi.Kapasite1;
            txtMasaNo.Text = Convert.ToString(Kapasitesi.ID1);

            cbKisiSayisi.Items.Clear();
            for(int i = 0; i < kapasite; i++)
            {
                cbKisiSayisi.Items.Add(i + 1);
            }

        }

        private void cbMasa_MouseEnter(object sender, EventArgs e)
        {
            cbMasa.Width = 200;
        }

        private void cbMasa_MouseLeave(object sender, EventArgs e)
        {
            cbMasa.Width = 23;
        }

        private void cbKisiSayisi_MouseLeave(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 23;
        }

        private void cbKisiSayisi_MouseEnter(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 100;
        }

        private void btnSiparisKontrol_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol sp = new frmSiparisKontrol();
            this.Close();
            sp.Show();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme frm = new MusteriEkleme();
            cGenel.MusteriEkleme = 0;
            frm.btnGüncelle.Visible = false;
            frm.btnEkle.Visible = true;
            this.Close();
            frm.Show();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if(lvMusteriler.SelectedItems.Count > 0)
            {
                MusteriEkleme m = new MusteriEkleme();
                cGenel.MusteriEkleme = 0;
                cGenel.MusteriID = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                m.btnGüncelle.Visible = true;
                m.btnEkle.Visible = false;
                this.Close();
                m.Show();
            }
        }
    }
}
