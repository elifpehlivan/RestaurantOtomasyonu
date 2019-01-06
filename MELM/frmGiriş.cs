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
    public partial class frmGiriş : Form
    {
        public MessageBoxIcon YesNo { get; private set; }

        public frmGiriş()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            cPersoneller p = new cPersoneller();
            bool result = p.PersonelEntryControl(txtSifre.Text, cGenel.PersonelID);

            if(result)
            {
                cPersonelHareketleri ch = new cPersonelHareketleri();
                ch.PersonelID1 = cGenel.PersonelID;
                ch.Islem1 = "Giriş Yaptı.";
                ch.Tarih1 = DateTime.Now;
                ch.PersonelActionSave(ch);

                this.Hide();
                frmMenu menu = new frmMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Yanlış Şifre", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)cbKullanici.SelectedItem;
            cGenel.PersonelID = p.PersonelID1;
            cGenel.GorevID = p.PersonelGorevID1;
        }
        
        private void frmGiriş_Load(object sender, EventArgs e)
        {
            cPersoneller p = new cPersoneller();
            p.PersonelGetbyInformation(cbKullanici);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
