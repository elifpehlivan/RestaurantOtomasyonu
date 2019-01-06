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
    class cAdisyon
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int ID;
        private int ServisTurNo;
        private decimal Tutar;
        private DateTime Tarih;
        private int PersonelID;
        private int Durum;
        private int MasaID;
        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int ServisTurNo1 { get => ServisTurNo; set => ServisTurNo = value; }
        public decimal Tutar1 { get => Tutar; set => Tutar = value; }
        public DateTime Tarih1 { get => Tarih; set => Tarih = value; }
        public int PersonelID1 { get => PersonelID; set => PersonelID = value; }
        public int Durum1 { get => Durum; set => Durum = value; }
        public int MasaID1 { get => MasaID; set => MasaID = value; } 
        #endregion
        //Açık olan masanın adisyon numarası.
        public int getByAddition(int MasaID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID from Adisyonlar where MasaID = @MasaID order by ID desc", con);

            cmd.Parameters.Add("@MasaID", SqlDbType.Int).Value = MasaID;
            try
            {
                if( con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MasaID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return MasaID;
        }

        public bool setByAdditionNew(cAdisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyonlar(ServisTurNo, PersonelID, MasaID, Durum, Tarih) values (@ServisTurNo, @PersonelID, @MasaID, @Durum, @Tarih)", con);
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = Bilgiler.ServisTurNo;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PersonelID;
                cmd.Parameters.Add("@MasaID", SqlDbType.Int).Value = Bilgiler.MasaID;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = 0;

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

        public void AdisyonKapat(int AdisyonID, int Durum)
        {
            

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Adisyonlar set Durum = @Durum where ID = @AdisyonID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("AdisyonID", SqlDbType.Int).Value = AdisyonID;
                cmd.Parameters.Add("Durum", SqlDbType.Int).Value = Durum;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            
        }

        public int PaketAdisyonIDbulAdedi()
        {
            int miktar = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) as Sayi from Adisyonlar where (Durum = 0) and (ServisTurNo = 2)", con);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                miktar = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            return miktar;
        }

        public void AcikPaketAdisyonlar(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select PaketSiparis.MusteriID, Müsteriler.Adı + ' ' + Müsteriler.Soyadı as Müsteri, Adisyonlar.ID as AdisyonID from PaketSiparis Inner Join Müsteriler on Müsteriler.ID = PaketSiparis.MusteriID Inner Join Adisyonlar on Adisyonlar.ID = PaketSiparis.AdisyonID where Adisyonlar.Durum = 0", con);
            SqlDataReader dr = null;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while(dr.Read())
                {
                    lv.Items.Add(dr["MusteriID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Müsteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AdisyonID"].ToString());
                    sayac++;
                }
               
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
           
        }

        public int MusteriSonAdisyonID(int MusteriID)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Adisyonlar.ID from Adisyonlar Inner Join PaketSiparis on PaketSiparis.AdisyonID = Adisyonlar.ID where PaketSiparis.Durum = 0 and Adisyonlar.Durum = 0 and PaketSiparis.MusteriID = @MusteriID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;

                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
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

            return sonuc;

        }

        public void MusteriDetaylar(ListView lv, int MusteriID)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select PaketSiparis.MusteriID, PaketSiparis.AdisyonID, Müsteriler.Adı, Müsteriler.Soyadı, CONVERT(varchar(10), Adisyonlar.Tarih, 104) as Tarih from Adisyonlar Inner Join PaketSiparis on PaketSiparis.AdisyonID = Adisyonlar.ID Inner Join Müsteriler on Müsteriler.ID = PaketSiparis.MusteriID where Adisyonlar.ServisTurNo = 2 and PaketSiparis.MusteriID = @MusteriID", con);

            cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                int sayac = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["MusteriID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Adı"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Soyadı"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Tarih"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AdisyonID"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
        }

        public int RezervasyonAdisyonAc(cAdisyon bilgiler)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyonlar(ServisTurNo, PersonelID, MasaID, Tarih) values (@ServisTurNo, @PersonelID, @MasaID, @Tarih); Select scope_IDENTITY()", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = bilgiler.ServisTurNo;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = bilgiler.PersonelID;
                cmd.Parameters.Add("@MasaID", SqlDbType.Int).Value = bilgiler.MasaID;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = bilgiler.Tarih;

                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
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
            return sonuc;
        }
    }
}
