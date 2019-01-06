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
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void frmSetting_Load(object sender, EventArgs e)
        {
            cPersoneller cp = new cPersoneller();
            cPersonelGorev cpg = new cPersonelGorev();
            string Gorev = cpg.PersonelGorevTanım(cGenel.GorevID);
            if(Gorev == "Müdür")
            {
                cp.PersonelGetbyInformation(cbPersonel);
                cpg.PersonelGorevGetir(cbGorevi);
                cp.PersonelBilgileriniGetirLV(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreT.ReadOnly = true;
                lblBilgi.Text = "Mevki : Müdür / Yetki Sınırsız / Kullanıcı : " + cp.PersonelBilgiGetirİsim(cGenel.PersonelID);
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                lblBilgi.Text = "Mevki : Müdür / Yetki Sınırlı / Kullanıcı : " + cp.PersonelBilgiGetirİsim(cGenel.PersonelID);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if(txtYeniSifre.Text.Trim() != "" || txtYeniSifreT.Text.Trim() != "")
            {

                if(txtYeniSifre.Text == txtYeniSifreT.Text)
                {

                    if(txtPersonelID.Text != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.PersonelSifreDegistir(Convert.ToInt32(txtPersonelID.Text), txtYeniSifre.Text);
                        if(sonuc)
                        {
                            MessageBox.Show("Şifre değiştirme işlemi başarıyla gerçekleşmiştir.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz !");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil !");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız !");
            }
        }

        private void cbGorevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersonelGorev c = (cPersonelGorev)cbGorevi.SelectedItem;
            txtGorevID.Text = Convert.ToString(c.PersonelGorevID1);
        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller c = (cPersoneller)cbPersonel.SelectedItem;
            txtPersonelID.Text = Convert.ToString(c.PersonelID1);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = false;
            btnEkle.Enabled = true;
            btnBilgiDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreT.ReadOnly = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(lvPersoneller.SelectedItems.Count > 0)
            {

                if(MessageBox.Show("Silmek istediğinizden emin misiniz ?", "UYARI !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cPersoneller c = new cPersoneller();
                    bool sonuc = c.PersonelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));

                    if(sonuc)
                    {
                        MessageBox.Show("Kayıt başarıyla silinmiştir.");
                        c.PersonelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinirken bir hata oluştu !");
                    }
                }
                else
                {
                    MessageBox.Show("Kayıt seçiniz.");
                }
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(txtAd.Text.Trim() != "" & txtSoyad.Text.Trim() != "" & txtSifre.Text.Trim() != "" & txtSifreT.Text.Trim() != "" & txtGorevID.Text.Trim() != "")
            {

                if((txtSifreT.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length > 5 || txtSifreT.Text.Length > 5))
                {
                    cPersoneller c = new cPersoneller();
                    c.PersonelAdı1 = txtAd.Text.Trim();
                    c.PersonelSoyadı1 = txtSoyad.Text.Trim();
                    c.PersonelParola1 = txtSifre.Text;
                    c.PersonelGorevID1 = Convert.ToInt32(txtGorevID.Text);
                    bool sonuc = c.PersonelEkle(c);

                    if(sonuc)
                    {
                        MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                        c.PersonelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenirken bir hata oluştu !");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil !");
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {



                if (txtAd.Text != "" || txtSoyad.Text != "" || txtSifre.Text != "" || txtSifreT.Text != "" || txtGorevID.Text != "")
                {

                    if ((txtSifreT.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length > 5 || txtSifreT.Text.Length > 5))
                    {
                        cPersoneller c = new cPersoneller();
                        c.PersonelAdı1 = txtAd.Text.Trim();
                        c.PersonelSoyadı1 = txtSoyad.Text.Trim();
                        c.PersonelParola1 = txtSifre.Text;
                        c.PersonelGorevID1 = Convert.ToInt32(txtGorevID.Text);
                        bool sonuc = c.PersonelGuncelle(c, Convert.ToInt32(txtPersonelID.Text));

                        if (sonuc)
                        {
                            MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                            c.PersonelBilgileriniGetirLV(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt eklenirken bir hata oluştu !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler aynı değil !");
                    }
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız.");
                }
            }
            else
            {
                MessageBox.Show("Kayıt seçiniz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() != "" || textBox7.Text.Trim() != "")
            {

                if (textBox8.Text == textBox7.Text)
                {

                    if (cGenel.PersonelID.ToString() != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.PersonelSifreDegistir(Convert.ToInt32(cGenel.PersonelID), textBox8.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre değiştirme işlemi başarıyla gerçekleşmiştir.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz !");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil !");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız !");
            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                btnSil.Enabled = true;
                txtPersonelID.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                cbGorevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;
                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                btnSil.Enabled = false;
            }
        }
    }
}
