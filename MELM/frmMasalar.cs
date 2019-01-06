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
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
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

        private void lblAcik_Click(object sender, EventArgs e)
        {

        }

        private void lblRezerve_Click(object sender, EventArgs e)
        {

        }

        private void lblDolu_Click(object sender, EventArgs e)
        {

        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa1.Text.Length;

            cGenel.ButtonValue = btnMasa1.Text.Substring(uzunluk-6,6);
            cGenel.ButtonName = btnMasa1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa2.Text.Length;

            cGenel.ButtonValue = btnMasa2.Text.Substring(uzunluk - 6, 6);
            cGenel.ButtonName = btnMasa2.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa3.Text.Length;

            cGenel.ButtonValue = btnMasa3.Text.Substring(uzunluk - 6, 6);
            cGenel.ButtonName = btnMasa3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa4.Text.Length;

            cGenel.ButtonValue = btnMasa4.Text.Substring(uzunluk - 6, 6);
            cGenel.ButtonName = btnMasa4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa5.Text.Length;

            cGenel.ButtonValue = btnMasa5.Text.Substring(uzunluk - 6, 6);
            cGenel.ButtonName = btnMasa5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa6.Text.Length;

            cGenel.ButtonValue = btnMasa6.Text.Substring(uzunluk - 6, 6);
            cGenel.ButtonName = btnMasa6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa7.Text.Length;

            cGenel.ButtonValue = btnMasa7.Text.Substring(uzunluk - 6, 6);
            cGenel.ButtonName = btnMasa7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa8.Text.Length;

            cGenel.ButtonValue = btnMasa8.Text.Substring(uzunluk - 6, 6);
            cGenel.ButtonName = btnMasa8.Name;
            this.Close();
            frm.ShowDialog();
        }
        cGenel gnl = new cGenel();
        private void frmMasalar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Durum,ID from Masalar",con);
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach(Control Item in this.Controls)
                {
                    if(Item is Button)
                    {
                        if (Item.Name == "btnMasa" + dr["ID"].ToString() && dr["Durum"].ToString() == "1")
                        {
                            Item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.bos);
                        }
                        else if (Item.Name == "btnMasa" + dr["ID"].ToString() && dr["Durum"].ToString() == "2")
                        {
                           Item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolu);
                        }
                        else if (Item.Name == "btnMasa" + dr["ID"].ToString() && dr["Durum"].ToString() == "3")
                        {
                            Item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.açıkrezerve);
                        }
                        else if (Item.Name == "btnMasa" + dr["ID"].ToString() && dr["Durum"].ToString() == "4")
                        {
                            Item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.rezerve);
                        }
                       
                    }
                }
            }
            dr.Close();
            con.Close();
        }
    }
}
