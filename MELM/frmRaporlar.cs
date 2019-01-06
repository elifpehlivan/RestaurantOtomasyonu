using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MELM
{
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
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

        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            Istatistik("Ana Yemekler Grafiği", 1, Color.Red);
        }

        private void btnİçecekler8_Click(object sender, EventArgs e)
        {
            Istatistik("Icecekler Grafiği", 8, Color.Orange);
        }
        private void Istatistik(string gfName, int KatID, Color renk)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = renk;
            cUrunler u = new cUrunler();
            lvIstatistik.Items.Clear();
            u.UrunleriListeleİstatistiklereGoreUrunID(lvIstatistik, dtBaslangıc, dtBitis, KatID);
            gbIstatistik.Text = gfName;

            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text, lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek istatistik yok. Başka bir zaman dilimi seçiniz.");
            }
        }

        private void btnTatlılar7_Click(object sender, EventArgs e)
        {
            Istatistik("Tatlılar Grafiği", 7, Color.Pink);
        }

        private void btnSalatalar6_Click(object sender, EventArgs e)
        {
            Istatistik("Salatalar Grafiği", 6, Color.Green);
        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            Istatistik("FastFood Grafiği", 5, Color.Brown);
        }

        private void btnÇorbalar2_Click(object sender, EventArgs e)
        {
            Istatistik("Çorbalar Grafiği", 2, Color.Blue);
        }

        private void btnMakarnalar4_Click(object sender, EventArgs e)
        {
            Istatistik("Makarnalar Grafiği", 4, Color.Purple);
        }

        private void btnAraSıcaklar3_Click(object sender, EventArgs e)
        {
            Istatistik("Ara Sıcaklar Grafiği", 3, Color.Gray);
        }

        private void btnZRaporu_Click(object sender, EventArgs e)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = Color.Yellow;
            cUrunler u = new cUrunler();
            lvIstatistik.Items.Clear();
            u.UrunleriListeleİstatistiklereGore(lvIstatistik, dtBaslangıc, dtBitis);
            gbIstatistik.Text = "Tüm Ürünler";

            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text, lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek istatistik yok. Başka bir zaman dilimi seçiniz.");
            }
        }
    }
}
