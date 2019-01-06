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
    public partial class frmSiparisKontrol : Form
    {
        public frmSiparisKontrol()
        {
            InitializeComponent();
        }

        private void frmSiparisKontrol_Load(object sender, EventArgs e)
        {
            cAdisyon c = new cAdisyon();
            int ButonSayisi = c.PaketAdisyonIDbulAdedi();
            c.AcikPaketAdisyonlar(lvMusteriler);
            int alt = 50;
            int sol = 1;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(ButonSayisi)));

            for(int i = 1; i <= ButonSayisi; i++)
            {
                Button btn = new Button();

                btn.AutoSize = false;
                btn.Size = new Size(175, 80);
                btn.FlatStyle = FlatStyle.Popup;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;
                btn.Text = lvMusteriler.Items[i - 1].SubItems[1].Text;
                btn.Font = new Font(btn.Font.FontFamily.Name,18);
                btn.Location = new Point(sol, alt);
                this.Controls.Add(btn);

                sol += btn.Width + 5;

                if(i == 2)
                {
                    sol = 1;
                    alt += 50;
                }
                btn.Click += new EventHandler(DinamikMethod);
                btn.MouseEnter += new EventHandler(DinamikMethod2);
            }
        }
        
        protected void DinamikMethod(object sender, EventArgs e)
        {
            cAdisyon c = new cAdisyon();
            Button DinamikButon = (sender as Button);
            frmBill frm = new frmBill();
            cGenel.ServisTurNo = 2;
            cGenel.AdisyonID = Convert.ToString(c.MusteriSonAdisyonID(Convert.ToInt32(DinamikButon.Name)));
            frm.Show();
        }

        protected void DinamikMethod2(object sender, EventArgs e)
        {
            Button DinamikButon = (sender as Button);
            cAdisyon c = new cAdisyon();
            c.MusteriDetaylar(lvMusteriDetayları, Convert.ToInt32(DinamikButon.Name));
            SonSiparisTarihi();
            lvSatısDetayları.Items.Clear();
            cSiparis s = new cSiparis();
            cGenel.ServisTurNo = 2;
            cGenel.AdisyonID = Convert.ToString(c.MusteriSonAdisyonID(Convert.ToInt32(DinamikButon.Name)));
            lblGenelToplam.Text = s.GenelToplamBul(Convert.ToInt32(DinamikButon.Name)).ToString() + "TL";
            
        }
        void SonSiparisTarihi()
        {
            if(lvMusteriDetayları.Items.Count > 0)
            {
                int s = lvMusteriDetayları.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetayları.Items[s - 1].SubItems[3].Text;
                txtToplamTutar.Text = s + "Adet";
            }
        }
        void Toplam()
        {
            int KayitSayisi = lvSatısDetayları.Items.Count;
            decimal Toplam = 0;
            for(int i = 0; i < KayitSayisi; i++)
            {
                Toplam += Convert.ToDecimal(lvSatısDetayları.Items[i].SubItems[2].Text) * Convert.ToDecimal(lvSatısDetayları.Items[i].SubItems[3].Text);
            }
            lblToplamSiparis.Text = Toplam.ToString() + "TL";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvMusteriDetayları_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvMusteriDetayları.SelectedItems.Count > 0)
            {
                cSiparis c = new cSiparis();
                c.AdisyonPaketSiparisDetayları(lvSatısDetayları, Convert.ToInt32(lvMusteriDetayları.SelectedItems[0].SubItems[4].Text));
                Toplam();
                lblGenelToplam.Text = c.GenelToplamBul(Convert.ToInt32(lvMusteriDetayları.SelectedItems[0].SubItems[0].Text)).ToString() + "TL";
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
    }
}
