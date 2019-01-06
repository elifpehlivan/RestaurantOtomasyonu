using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MELM
{
    class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int ID;
        private int PersonelID;
        private string Islem;
        private DateTime Tarih;
        private bool Durum;
        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int PersonelID1 { get => PersonelID; set => PersonelID = value; }
        public string Islem1 { get => Islem; set => Islem = value; }
        public DateTime Tarih1 { get => Tarih; set => Tarih = value; }
        public bool Durum1 { get => Durum; set => Durum = value; }
        #endregion

        public bool PersonelActionSave(cPersonelHareketleri ph)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into PersonelHareketleri(PersonelID,Islem,Tarih) Values(@PersonelID,@Islem,@Tarih)",con);
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = ph.PersonelID;
                cmd.Parameters.Add("@Islem", SqlDbType.VarChar).Value = ph.Islem;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = ph.Tarih;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(SqlException ex)
            {
                string Hata = ex.Message;
                throw;
            }

            return result;
        }
    }
}
