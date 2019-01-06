using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MELM
{
    class cPaketler
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int ID;
        private int AdditionID;
        private int ClientID;
        private int Description;
        private int State;
        private int PayTypeID;
        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int AdditionID1 { get => AdditionID; set => AdditionID = value; }
        public int ClientID1 { get => ClientID; set => ClientID = value; }
        public int Description1 { get => Description; set => Description = value; }
        public int State1 { get => State; set => State = value; }
        public int PayTypeID1 { get => PayTypeID; set => PayTypeID = value; }
        #endregion
        //Paket servisi açma
        public bool OrderServiceOpen(cPaketler order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into PaketSiparis(AdisyonID, MusteriID, OdemeTurID, Acıklama) values (@AdisyonID, @MusteriID, @OdemeTurID, @Acıklama)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonID", SqlDbType.Int).Value = order.AdditionID;
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = order.ClientID;
                cmd.Parameters.Add("@OdemeTurID", SqlDbType.Int).Value = order.PayTypeID;
                cmd.Parameters.Add("@Acıklama", SqlDbType.VarChar).Value = order.Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
        //Paket servisi kapatma.
        public void OrderServiceClose(int AdditionID)
        {
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update PaketSiparis set PaketSiparis.Durum = 1 where PaketSiparis.AdisyonID = @AdditionID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonID", SqlDbType.Int).Value = AdditionID;
               
                Convert.ToBoolean(cmd.ExecuteNonQuery());
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
        //Açılan adisyon ve paket siparişe ait ön girilen ödeme tür ID
        public int OdemeTurIDGetir(int AdisyonID)
        {
            int OdemeTurID = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select PaketSiparis.OdemeTurID from PaketSiparis Inner Join Adisyonlar on PaketSiparis.AdisyonID = Adisyonlar.ID where Adisyonlar.ID = @AdisyonID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonID", SqlDbType.Int).Value = AdisyonID;
                
                OdemeTurID = Convert.ToInt32(cmd.ExecuteScalar());
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
            return OdemeTurID;
        }
        //Sipariş kontrol için müşteriye ait açık olan en son adisyon nosu getirme
        //Bir müşteriye ait 2 tane siparişin açık olamayacağını belirtiyoruz.
        public int MusteriSonAdisyonIDGetir(int MusteriID)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Adisyonlar.ID from Adisyonlar Inner Join PaketSiparis on PaketSiparis.AdisyonID = Adisyonlar.ID where (Adisyonlar.Durum = 0) and (PaketSiparis.Durum = 0) and PaketSiparis.MusteriID = @MusteriID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;

                no = Convert.ToInt32(cmd.ExecuteScalar());
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
            return no;
        }
        //Müşteri arama ekranında adisyonbul butonu adisyon açık mı değil mi kontrol etme.
        public bool getCheckOpenAdditionID(int AdditionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Adisyonlar where (Durum = 0) and (ID=@AdditionID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdditionID", SqlDbType.Int).Value = AdditionID;
                
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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


    }
}
