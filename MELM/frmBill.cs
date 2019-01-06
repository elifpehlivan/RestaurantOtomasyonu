using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MELM
{
    public partial class frmBill : Form
    {
        public frmBill()
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
        cSiparis cs = new cSiparis();
        int OdemeTuru = 0;
        private void frmBill_Load(object sender, EventArgs e)
        {
            
            if (cGenel.ServisTurNo == 1)
            {
                lblAdisyonID.Text = cGenel.AdisyonID;
                txtIndirimTutarı.TextChanged += new EventHandler(txtIndirimTutarı_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonID.Text));
                if(lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for(int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lbToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lbOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lbOdenecek.Text) * 18 / 100;
                    lbKDV.Text = string.Format("{0:0.000}", kdv);
                }
                if (chkIndirim.Checked)
                {
                    gbIndirim.Visible = false;
                }
                else
                {
                    gbIndirim.Visible = true;
                }
                txtIndirimTutarı.Clear();
            }
            else if(cGenel.ServisTurNo == 2)
            {
                lblAdisyonID.Text = cGenel.AdisyonID;
                cPaketler pc = new cPaketler();
                OdemeTuru = pc.OdemeTurIDGetir(Convert.ToInt32(lblAdisyonID.Text));
                txtIndirimTutarı.TextChanged += new EventHandler(txtIndirimTutarı_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonID.Text));

                if(OdemeTuru == 1)
                {
                   rbKrediKarti.Checked = true;
                }
                else if(OdemeTuru == 2)
                {
                    rbNakit.Checked = true;
                }
                else if (OdemeTuru == 3)
                {
                    rbTicket.Checked = true;
                }

                
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                       
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                        

                    }
                    lbToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lbOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lbOdenecek.Text) * 18 / 100;
                    lbKDV.Text = string.Format("{0:0.000}", kdv);
                }
                if (chkIndirim.Checked)
                {
                    gbIndirim.Visible = false;
                }
                else
                {
                    gbIndirim.Visible = true;
                }
                txtIndirimTutarı.Clear();
            }
        }

        private void txtIndirimTutarı_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtIndirimTutarı.Text) < Convert.ToDecimal(lbToplamTutar.Text))
                {
                    try
                    {
                        lbIndırım.Text = string.Format("{0:0.000}", Convert.ToDecimal(txtIndirimTutarı.Text));
                    }
                    catch (SqlException ex)
                    {
                        lbIndırım.Text = string.Format("{0:0.000}", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim tutarı toplam tutardan fazla olamaz.");
                }
            }
            catch (SqlException ex)
            {
                lbIndırım.Text = string.Format("{0:0.000}", 0);
            }
        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIndirim.Checked)
            {
                gbIndirim.Visible = true;
                txtIndirimTutarı.Clear();
            }
            else
            {
                gbIndirim.Visible = false;
                txtIndirimTutarı.Clear();
            }
        }

        private void lbIndırım_TextChanged(object sender, EventArgs e)
        {
            if(Convert.ToDecimal(lbIndırım.Text) > 0)
            {
                decimal ödenecek = 0;
                lbOdenecek.Text = lbToplamTutar.Text;
                ödenecek = Convert.ToDecimal(lbOdenecek.Text) - Convert.ToDecimal(lbIndırım.Text);
                lbOdenecek.Text = string.Format("{0:0.000}", ödenecek);
            }
            decimal kdv = Convert.ToDecimal(lbOdenecek.Text)*18/100;
            lbKDV.Text = string.Format("{0:0.000}", kdv);
        }

        cMasalar masalar = new cMasalar();
        cRezervasyonlar rezerve = new cRezervasyonlar();
        private void button2_Click(object sender, EventArgs e)
        {
            if(cGenel.ServisTurNo == 1)
            {
                int MasaID = masalar.TableGetbyNumber(cGenel.ButtonName);
                int MusteriID = 0;

                if (masalar.TableGetbyState(MasaID, 4) == true)
                {
                    MusteriID = rezerve.getByClientIDFromRezervasyonlar(MasaID);
                }
                else
                {
                    MusteriID = 1;
                }
                int OdemeTurID = 0;

                if(rbNakit.Checked)
                {
                    OdemeTurID = 1;
                }
                if (rbKrediKarti.Checked)
                {
                    OdemeTurID = 2;
                }
                if (rbTicket.Checked)
                {
                    OdemeTurID = 3;
                }

                cOdeme odeme = new cOdeme();
                // AdisyonID, OdemeTuruID, MusteriID, AraToplam, KDVTutarı, Indirim, ToplamTutar

                odeme.AdisyonID1 = Convert.ToInt32(lblAdisyonID.Text);
                odeme.OdemeTurID1 = OdemeTurID;
                odeme.MusteriID1 = MusteriID;
                odeme.AraToplam1 = Convert.ToDecimal(lbOdenecek.Text);
                odeme.KDVTutarı1 = Convert.ToDecimal(lbKDV.Text);
                odeme.GenelToplam1 = Convert.ToDecimal(lbToplamTutar.Text);
                odeme.Indirim1 = Convert.ToDecimal(lbIndırım.Text);

                bool result = odeme.BillClose(odeme);
                if(result)
                {
                    MessageBox.Show("Hesap kapatılmıştır.");
                    masalar.setChangeTableState(Convert.ToString(MasaID), 1);
                    cRezervasyonlar c = new cRezervasyonlar();
                    c.RezervationClose(Convert.ToInt32(lblAdisyonID.Text));

                    cAdisyon a = new cAdisyon();
                    a.AdisyonKapat(Convert.ToInt32(lblAdisyonID.Text), 0);

                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu !");
                }
               
            } //Paket Sipariş
            else if(cGenel.ServisTurNo == 2)
            {
                cOdeme odeme = new cOdeme();
                // AdisyonID, OdemeTuruID, MusteriID, AraToplam, KDVTutarı, Indirim, ToplamTutar

                odeme.AdisyonID1 = Convert.ToInt32(lblAdisyonID.Text);
                odeme.OdemeTurID1 = OdemeTuru;
                odeme.MusteriID1 = 1; //Paket sipariş ID
                odeme.AraToplam1 = Convert.ToDecimal(lbOdenecek.Text);
                odeme.KDVTutarı1 = Convert.ToDecimal(lbKDV.Text);
                odeme.GenelToplam1 = Convert.ToDecimal(lbToplamTutar.Text);
                odeme.Indirim1 = Convert.ToDecimal(lbIndırım.Text);

                bool result = odeme.BillClose(odeme);
                if (result)
                {
                   
                    cAdisyon a = new cAdisyon();
                    a.AdisyonKapat(Convert.ToInt32(lblAdisyonID.Text), 1);

                    cPaketler p = new cPaketler();
                    p.OrderServiceClose(Convert.ToInt32(lblAdisyonID.Text));
                    MessageBox.Show("Hesap kapatılmıştır.");

                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu !");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        Font Baslık = new Font("Verdana", 15, FontStyle.Bold);
        Font AltBaslık = new Font("Verdana", 12, FontStyle.Regular);
        Font Icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("MELM RESTAURANT", Baslık, sb, 350, 100, st);
            e.Graphics.DrawString("-----------------------------", AltBaslık, sb, 350, 120, st);
            e.Graphics.DrawString("Ürün Adı                    Adet                 Fiyat", AltBaslık, sb, 150, 250, st);
            e.Graphics.DrawString("---------------------------------------------------------", AltBaslık, sb, 150, 280, st);
            for(int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, Icerik, sb, 150, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, Icerik, sb, 350, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[3].Text, Icerik, sb, 420, 300 + i * 30, st);
            }
            e.Graphics.DrawString("-----------------------------------", AltBaslık, sb, 150, 300 + 30 * lvUrunler.Items.Count, st);
            e.Graphics.DrawString("Indirim Tutarı : ---------------------" + lbIndırım.Text + "TL", AltBaslık, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 1), st);
            e.Graphics.DrawString("KDV Tutarı : ---------------------" + lbKDV.Text + "TL", AltBaslık, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutar : -------------------" + lbToplamTutar.Text + "TL",  AltBaslık, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutar: -------------------" + lbOdenecek.Text + "TL", AltBaslık, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 4), st);
        }
    }
}
