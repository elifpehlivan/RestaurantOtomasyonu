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
    public partial class MusteriEkleme : Form
    {
        public MusteriEkleme()
        {
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAdı.Text == "" || txtMusteriSoyadı.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin ad ve soyad alanlarını doldurunuz.");
                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    c.MusteriAdı1 = txtMusteriAdı.Text;
                    c.MusteriSoyadı1 = txtMusteriSoyadı.Text;
                    c.Telefon1 = txtTelefon.Text;
                    c.Email1 = txtEmail.Text;
                    c.Adres1 = txtAdres.Text;
                    c.MusteriID1 = Convert.ToInt32(txtMusteriNo.Text);
                    bool sonuc = c.MusteriBilgileriGuncelle(c);
                   
                    if (sonuc)
                    {
                       

                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri güncellenemedi !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde kayıt bulunmaktadır !");
                    }
                }

            }
            else
            {
                MessageBox.Show("Lütfen en az 7 karakterli bir numara giriniz.");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(txtTelefon.Text.Length > 6)
            {
                if(txtMusteriAdı.Text == "" || txtMusteriSoyadı.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin ad ve soyad alanlarını doldurunuz.");
                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    bool sonuc = c.MusteriVarmı(txtTelefon.Text);

                    if(!sonuc)
                    {
                        c.MusteriAdı1 = txtMusteriAdı.Text;
                        c.MusteriSoyadı1 = txtMusteriSoyadı.Text;
                        c.Telefon1 = txtTelefon.Text;
                        c.Email1 = txtEmail.Text;
                        c.Adres1 = txtAdres.Text;
                        txtMusteriNo.Text = c.MusteriEkle(c).ToString();

                        if(txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri eklenemedi !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde kayıt bulunmaktadır !");
                    }
                }

            }
            else
            {
                MessageBox.Show("Lütfen en az 7 karakterli bir numara giriniz.");
            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if(cGenel.MusteriEkleme == 0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                cGenel.MusteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if(cGenel.MusteriEkleme == 1)
            {
                
                cGenel.MusteriEkleme = 0;
                
            }
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

        private void MusteriEkleme_Load(object sender, EventArgs e)
        {
            if(cGenel.MusteriID > 0)
            {
                cMusteriler c = new cMusteriler();
                txtMusteriNo.Text = cGenel.MusteriID.ToString();
                c.MusterileriGetirID(Convert.ToInt32(txtMusteriNo.Text), txtMusteriAdı, txtMusteriSoyadı, txtTelefon, txtAdres, txtEmail);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            frmMusteriArama frm = new frmMusteriArama();
            this.Close();
            frm.Show();
        }
    }
}
