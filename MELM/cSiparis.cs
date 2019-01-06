using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace MELM
{
    class cSiparis
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int ID;
        private int AdisyonID;
        private int UrunID;
        private int Adet;
        private int MasaID;
        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int AdisyonID1 { get => AdisyonID; set => AdisyonID = value; }
        public int UrunID1 { get => UrunID; set => UrunID = value; }
        public int Adet1 { get => Adet; set => Adet = value; }
        public int MasaID1 { get => MasaID; set => MasaID = value; } 
        #endregion

        public void getByOrder(ListView lv, int AdisyonID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select UrunAdi, Fiyat, Satıslar.ID, Satıslar.UrunID, Satıslar.Adet from Satıslar Inner Join Urunler on Satıslar.UrunID = Urunler.ID where AdisyonID = @AdisyonID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonID", SqlDbType.Int).Value = AdisyonID;
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while(dr.Read())
                {
                    lv.Items.Add(dr["UrunAdi"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Adet"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["UrunID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["Fiyat"]) * Convert.ToDecimal(dr["Adet"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

                    sayac++;
                }
            }
            catch(SqlException ex)
            {
                string Hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }

        public bool setSaveOrder(cSiparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satıslar(AdisyonID, UrunID, MasaID, Adet) values (@AdisyonNo, @UrunID, @MasaID, @Adet)", con);
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler.AdisyonID;
                cmd.Parameters.Add("@UrunID", SqlDbType.Int).Value = Bilgiler.UrunID;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler.Adet;
                cmd.Parameters.Add("@MasaID", SqlDbType.Int).Value = Bilgiler.MasaID;
                
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }

        public void setDeleteOrder(int SatisID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete from Satıslar where ID=@SatısID", con);

            cmd.Parameters.Add("@SatısID", SqlDbType.Int).Value = SatisID;
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public decimal GenelToplamBul(int MusteriID)
        {
            decimal GenelToplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select SUM(Satıslar.Adet * Urunler.Fiyat) as Fiyat from Müsteriler Inner Join PaketSiparis on Müsteriler.ID = PaketSiparis.MusteriID Inner Join Adisyonlar on Adisyonlar.ID = PaketSiparis.AdisyonID Inner Join Satıslar on Adisyonlar.ID = Satıslar.AdisyonID Inner Join Urunler on Satıslar.UrunID = Urunler.ID where (PaketSiparis.MusteriID = @MusteriID) and (PaketSiparis.Durum = 0)", con);
            cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = MusteriID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                    GenelToplam = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return GenelToplam;

        }

        public void AdisyonPaketSiparisDetayları(ListView lv, int AdisyonID)
        {
            lv.Items.Clear();
            decimal GenelToplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Satıslar.ID as SatısID, Urunler.UrunAdi, Urunler.Fiyat, Satıslar.Adet from Satıslar Inner Join Adisyonlar on Adisyonlar.ID = Satıslar.AdisyonID Inner Join Urunler on Urunler.ID = Satıslar.UrunID where Satıslar.AdisyonID = @AdisyonID", con);
            cmd.Parameters.Add("AdisyonID", SqlDbType.Int).Value = AdisyonID;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                int i = 0;
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lv.Items.Add(dr["SatısID"].ToString());
                    lv.Items[i].SubItems.Add(dr["UrunAdi"].ToString());
                    lv.Items[i].SubItems.Add(dr["Adet"].ToString());
                    lv.Items[i].SubItems.Add(dr["Fiyat"].ToString());

                    i++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }
    }
}
