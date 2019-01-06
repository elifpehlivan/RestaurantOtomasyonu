using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MELM
{
    class cOdeme
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int OdemeID;
        private int AdisyonID;
        private int OdemeTurID;
        private Decimal AraToplam;
        private Decimal Indirim;
        private Decimal KDVTutarı;
        private Decimal GenelToplam;
        private DateTime Tarih;
        private int MusteriID;
        #endregion

        #region Properties
        public int OdemeID1 { get => OdemeID; set => OdemeID = value; }
        public int AdisyonID1 { get => AdisyonID; set => AdisyonID = value; }
        public int OdemeTurID1 { get => OdemeTurID; set => OdemeTurID = value; }
        public decimal AraToplam1 { get => AraToplam; set => AraToplam = value; }
        public decimal Indirim1 { get => Indirim; set => Indirim = value; }
        public decimal KDVTutarı1 { get => KDVTutarı; set => KDVTutarı = value; }
        public decimal GenelToplam1 { get => GenelToplam; set => GenelToplam = value; }
        public DateTime Tarih1 { get => Tarih; set => Tarih = value; }
        public int MusteriID1 { get => MusteriID; set => MusteriID = value; } 
        #endregion
        //Müşterinin masa hesabını kapatıyoruz.
        public bool BillClose(cOdeme bill)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into HesapOdemeleri(AdisyonID, OdemeTuruID, MusteriID, AraToplam, KDVTutarı, Indirim, ToplamTutar) values (@AdisyonID, @OdemeTuruID, @MusteriID, @AraToplam, @KDVTutarı, @Indirim, @ToplamTutar)",con);

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("AdisyonID", SqlDbType.Int).Value = bill.AdisyonID;
                cmd.Parameters.Add("OdemeTuruID", SqlDbType.Int).Value = bill.OdemeTurID;
                cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = bill.MusteriID;
                cmd.Parameters.Add("AraToplam", SqlDbType.Money).Value = bill.AraToplam;
                cmd.Parameters.Add("KDVTutarı", SqlDbType.Money).Value = bill.KDVTutarı;
                cmd.Parameters.Add("Indirim", SqlDbType.Money).Value = bill.Indirim;
                cmd.Parameters.Add("ToplamTutar", SqlDbType.Money).Value = bill.GenelToplam;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            return result;
        }
        //Müşterinin toplam harcamasını buluyoruz.
        public decimal SumTotalForClientID(int ClientID)
        {
            decimal total = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(ToplamTutar) as Total from HesapOdemeleri where MusteriID = @ClientID", con);
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID;
                total = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
           
            return total;
        }
    }
}
