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
    public partial class frmMutfak : Form
    {
        public frmMutfak()
        {
            InitializeComponent();
        }

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            cUrunCesitleri AnaKategori = new cUrunCesitleri();
            AnaKategori.UrunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;

            label6.Visible = false;
            txtAra.Visible = false;

            cUrunler c = new cUrunler();
            c.UrunleriListele(lvGıdaListesi);
        }
        private void Temizle()
        {
            txtGıdaAdı.Clear();
            txtGıdaFiyatı.Clear();
            txtGıdaFiyatı.Text = string.Format("{0:##0.00}",0);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGıdaAdı.Text.Trim() == "" || txtGıdaFiyatı.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda adı, fiyatı veya kategorisi seçilmemiştir!", "Dikkat! Bilgiler eksik.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat1 = Convert.ToDecimal(txtGıdaFiyatı.Text);
                    c.UrunAdı1 = txtGıdaAdı.Text;
                    c.Açıklama1 = "Ürün eklendi.";
                    c.UrunTurNo1 = UrunTurNo;

                    int sonuc = c.UrunEkle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Eklenmiştir.");
                        //cbKategoriler_SelectedIndexChanged(sender, e);
                        Yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAdı.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir kategori ismi giriniz.", "Dikkat! Bilgiler eksik.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gıda = new cUrunCesitleri();
                    gıda.KategoriAdi1 = txtKategoriAdı.Text;
                    gıda.Acıklama1 = txtAcıklama.Text;
                    int sonuc = gıda.UrunKategoriEkle(gıda);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori eklenmiştir.");
                        Yenile();
                        Temizle();
                    }
                }
            }
        }
        int UrunTurNo = 0;
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunler u = new cUrunler();
            if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
            {
                u.UrunleriListele(lvGıdaListesi);
            }
            else
            {
                cUrunCesitleri cesit = (cUrunCesitleri)cbKategoriler.SelectedItem;
                UrunTurNo = cesit.UrunTurNo1;
                u.UrunleriListeleByUrunID(lvGıdaListesi, UrunTurNo);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGıdaAdı.Text.Trim() == "" || txtGıdaFiyatı.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda adı, fiyatı veya kategorisi seçilmemiştir!", "Dikkat! Bilgiler eksik.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat1 = Convert.ToDecimal(txtGıdaFiyatı.Text);
                    c.UrunAdı1 = txtGıdaAdı.Text;
                    c.UrunID1 = Convert.ToInt32(txtUrunID.Text);
                    c.UrunTurNo1 = UrunTurNo;
                    c.Açıklama1 = "Ürün güncellendi.";
                    int sonuc = c.UrunleriGuncelle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün güncellenmiştir.");
                        Yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriID.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz.", "Dikkat! Bilgiler eksik.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gıda = new cUrunCesitleri();
                    gıda.KategoriAdi1 = txtKategoriAdı.Text;
                    gıda.Acıklama1 = txtAcıklama.Text;
                    gıda.UrunTurNo1 = Convert.ToInt32(txtKategoriID.Text);
             
                    int sonuc = gıda.UrunKategoriGuncelle(gıda);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori güncellenmiştir.");
                        gıda.UrunCesitleriniGetir(lvKategoriler);
                        Temizle();
                    }
                }
            }
        }

        private void lvGıdaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvGıdaListesi.SelectedItems.Count > 0)
            {
                txtGıdaAdı.Text = lvGıdaListesi.SelectedItems[0].SubItems[3].Text;
                txtGıdaFiyatı.Text = lvGıdaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunID.Text = lvGıdaListesi.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
                txtKategoriAdı.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtKategoriID.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                txtAcıklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (lvGıdaListesi.SelectedItems.Count > 0)
                {


                    if (MessageBox.Show("Ürün silmekte emin misiniz ?", "Dikkat! Bilgiler silinecek !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cUrunler c = new cUrunler();
                        c.UrunID1 = Convert.ToInt32(txtUrunID.Text);
                        int sonuc = c.UrunleriSil(c, 1);
                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün silinmiştir.");
                            
                            //cbKategoriler_SelectedIndexChanged(sender, e);
                            Yenile();
                            Temizle();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ürün silmek için bir ürün seçiniz.", "Ürün seçmediniz !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (lvKategoriler.SelectedItems.Count > 0)
                {



                    if (MessageBox.Show("Ürün silmekte emin misiniz ?", "Dikkat! Bilgiler silinecek !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cUrunCesitleri uc = new cUrunCesitleri();
                        int sonuc = uc.UrunKategoriSil(Convert.ToInt32(txtKategoriID.Text));
                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün silinmiştir.");
                            cUrunler c = new cUrunler();
                            c.UrunID1 = Convert.ToInt32(txtKategoriID.Text);
                            c.UrunleriSil(c, 0);
                            Yenile();
                            Temizle();
                        }
                    }
                }
            }
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

        private void btnBul_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            txtAra.Visible = true;
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if(rbAltKategori.Checked)
            {
                cUrunler u = new cUrunler();
                u.UrunleriListeleByUrunAdı(lvGıdaListesi, txtAra.Text);
            }
            else
            {
                cUrunCesitleri uc = new cUrunCesitleri();
                uc.UrunCesitleriniGetir(lvKategoriler, txtAra.Text);
            }
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGıdaListesi.Visible = true;
            Yenile();
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGıdaListesi.Visible = false;
            Yenile();
        }
        private void Yenile()
        {
            cUrunCesitleri uc = new cUrunCesitleri();
            uc.UrunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            uc.UrunCesitleriniGetir(lvKategoriler);
            cUrunler c = new cUrunler();
            c.UrunleriListele(lvGıdaListesi);
        }
    }
}
