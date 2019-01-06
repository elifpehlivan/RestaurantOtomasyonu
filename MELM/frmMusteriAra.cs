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
    public partial class frmMusteriArama : Form
    {
        public frmMusteriArama()
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

        private void btnYeniMüşteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme m = new MusteriEkleme();
            cGenel.MusteriEkleme = 1;
            m.btnGüncelle.Visible = false;
            m.btnEkle.Visible = true;
            this.Close();
            m.Show();
        }

        private void frmMusteriArama_Load(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.MusterileriGetir(lvMusteriler);
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMusteriGüncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                MusteriEkleme frm = new MusteriEkleme();
                cGenel.MusteriEkleme = 1;
                cGenel.MusteriID = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                frm.btnEkle.Visible = false;
                frm.btnGüncelle.Visible = true;
                
                this.Close();
                frm.Show();
            }
            
        }

        private void btnGeriDön2_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void txtMusteriAdı_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.MusteriGetirAd(lvMusteriler, txtMusteriAdı.Text);
        }

        private void txtSoyadı_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.MusteriGetirSoyadı(lvMusteriler,txtSoyadı.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.MusteriGetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if(txtAdisyonID.Text != "")
            {
                cGenel.AdisyonID = txtAdisyonID.Text;
                cPaketler c = new cPaketler();

                bool sonuc = c.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonID.Text));

                if(sonuc)
                {
                    frmBill frm = new frmBill();
                    cGenel.ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Böyle bir adisyon bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Aramak istediğiniz adisyonu yazınız.");
            }
        }

        private void txtMusteriAdı_Click(object sender, EventArgs e)
        {
            txtSoyadı.Enabled = false;
            txtTelefon.Enabled = false;
            txtMusteriAdı.Enabled = true;
        }

        private void txtSoyadı_Click(object sender, EventArgs e)
        {
            txtSoyadı.Enabled = true;
            txtTelefon.Enabled = false;
            txtMusteriAdı.Enabled = false;
        }

        private void txtTelefon_Click(object sender, EventArgs e)
        {
            txtSoyadı.Enabled = false;
            txtTelefon.Enabled = true;
            txtMusteriAdı.Enabled = false;
        }

        private void txtMusteriAdı_Leave(object sender, EventArgs e)
        {
            txtSoyadı.Enabled = true;
            txtTelefon.Enabled = true;
            txtMusteriAdı.Enabled = true;
        }

        private void txtSoyadı_Leave(object sender, EventArgs e)
        {
            txtSoyadı.Enabled = true;
            txtTelefon.Enabled = true;
            txtMusteriAdı.Enabled = true;
        }

        private void txtTelefon_Leave(object sender, EventArgs e)
        {
            txtSoyadı.Enabled = true;
            txtTelefon.Enabled = true;
            txtMusteriAdı.Enabled = true;

          
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            
           frmSiparisKontrol frm = new frmSiparisKontrol();
           this.Close();
           frm.Show();
        }
    }
}
