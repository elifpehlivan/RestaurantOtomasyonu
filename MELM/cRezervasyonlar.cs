using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MELM
{
    class cRezervasyonlar
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int ID;
        private int TableID;
        private int ClientID;
        private DateTime Date;
        private int ClientCount;
        private string Description;
        private int AdditionID;
        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int TableID1 { get => TableID; set => TableID = value; }
        public int ClientID1 { get => ClientID; set => ClientID = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        public int ClientCount1 { get => ClientCount; set => ClientCount = value; }
        public string Description1 { get => Description; set => Description = value; }
        public int AdditionID1 { get => AdditionID; set => AdditionID = value; } 
        #endregion
        //MüşteriID masa numarasına göre..
        public int getByClientIDFromRezervasyonlar(int TableID)
        {
            int ClientID = 0;

            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 MusteriID from Rezervasyonlar where MasaID = @MasaID order by MusteriID desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("MasaID", SqlDbType.Int).Value = TableID;
                

                ClientID = Convert.ToInt32(cmd.ExecuteScalar());
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




            return ClientID;
        }
        //Hesap kapatırken rezervasyonlu masayı kapattık.
        public bool RezervationClose(int AdisyonID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Rezervasyonlar set Durum = 1 where AdisyonID = @AdisyonID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonID", SqlDbType.Int).Value = AdisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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

            return result;
        }
        //Rezervasyonları Getir
        public void MusteriIDGetirFromRezervasyon(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MusteriID, (Adı + Soyadı) as Musteri from Rezervasyonlar Inner Join Müsteriler on Rezervasyonlar.MusteriID = Müsteriler.ID where Rezervasyonlar.Durum = 0", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MusteriID"].ToString());
                lv.Items[i].SubItems.Add(dr["Musteri"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        //Eski Rezervasyonları Getir
        public void EskiRezervasyonlarıGetir(ListView lv, int MusteriID)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MusteriID, Adı, Soyadı, AdisyonID, Tarih from Rezervasyonlar Inner Join Müsteriler on Rezervasyonlar.MusteriID = Müsteriler.ID where Rezervasyonlar.MusteriID = @MusteriID and Rezervasyonlar.Durum = 0 order by Rezervasyonlar.ID desc", con);
            cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = MusteriID;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MusteriID"].ToString());
                lv.Items[i].SubItems.Add(dr["Adı"].ToString());
                lv.Items[i].SubItems.Add(dr["Soyadı"].ToString());
                lv.Items[i].SubItems.Add(dr["Tarih"].ToString());
                lv.Items[i].SubItems.Add(dr["AdisyonID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        //En son rezervasyon tarihini getir
        public DateTime EnSonRezervasyonTarihi(int MusteriID)
        {
            DateTime Tarih = new DateTime();
            Tarih = DateTime.Now;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Tarih from Rezervasyonlar where Rezervasyonlar.MusteriID = @MusteriID and Rezervasyonlar.Durum = 1 order by Rezervasyonlar.ID desc", con);
            cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = MusteriID;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            Tarih = Convert.ToDateTime(cmd.ExecuteScalar());
            
            con.Dispose();
            con.Close();
            return Tarih;
        }
        //Açık rezervasyonların sayısını getir
        public int AçıkRezervasyonSayısı()
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Count(*) from Rezervasyonlar where Rezervasyonlar.Durum = 0", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch(SqlException ex)
            {
                throw;
            }
            con.Dispose();
            con.Close();
            return sonuc;
        }
        //Rezervasyon açık mı kontrolü
        public bool RezervasyonAcıkmıKontrol(int MusteriID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 Rezervasyonlar.ID from Rezervasyonlar where MusteriID = @MusteriID and Durum = 1 order by ID desc", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = MusteriID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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

            return result;
        }
        //Rezervasyonları açar
        public bool RezervasyonAc(cRezervasyonlar r)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Rezervasyonlar (MusteriID, MasaID, AdisyonID, KisiSayisi, Tarih, Acıklama, Durum) values (@MusteriID, @MasaID, @AdisyonID, @KisiSayisi, @Tarih, @Acıklama, 1)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = r.ClientID;
                cmd.Parameters.Add("MasaID", SqlDbType.Int).Value = r.TableID;
                cmd.Parameters.Add("AdisyonID", SqlDbType.Int).Value = r.AdditionID;
                cmd.Parameters.Add("KisiSayisi", SqlDbType.Int).Value = r.ClientCount;
                cmd.Parameters.Add("Tarih", SqlDbType.Date).Value = r.Date;
                cmd.Parameters.Add("Acıklama", SqlDbType.VarChar).Value = r.Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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

            return result;
        }
        
        public int RezerveMasaIDGetir(int MusteriID)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MasaID from INNER JOIN Adisyonlar on Rezervasyonlar.AdisyonID = Adisyon.ID where (Rezervasyonlar.Durum = 1) and Adisyonlar.Durum=0 and Rezervasyonlar.MusteriID=@MusteriID", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = MusteriID;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw;
            }
            con.Dispose();
            con.Close();
            return sonuc;
        }
    }
}
