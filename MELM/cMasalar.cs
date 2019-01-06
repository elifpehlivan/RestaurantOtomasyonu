using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MELM
{
    class cMasalar
    {
        #region Fields
        private int ID;
        private int Kapasite;
        private int ServisTuru;
        private int Durum;
        private int Onay;
        private string MasaBilgi;
        #endregion

        #region Properties
        public int ID1 { get => ID; set => ID = value; }
        public int Kapasite1 { get => Kapasite; set => Kapasite = value; }
        public int ServisTuru1 { get => ServisTuru; set => ServisTuru = value; }
        public int Durum1 { get => Durum; set => Durum = value; }
        public int Onay1 { get => Onay; set => Onay = value; }
        public string MasaBilgi1 { get => MasaBilgi; set => MasaBilgi = value; }
        #endregion

        cGenel gnl = new cGenel();
        public String SessionSum(int state, string MasaID)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Tarih, MasaID from Adisyonlar Right Join Masalar on Adisyonlar.MasaID = Masalar.ID where Masalar.Durum = @Durum and Adisyonlar.Durum = 0 and Masalar.ID = @MasaID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@MasaID", SqlDbType.Int).Value = Convert.ToInt32(MasaID);

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["Tarih"]).ToString();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            
            return dt;
        }

        public int TableGetbyNumber(string TableValue)
        {
            string aa = TableValue;
            int lenght = aa.Length;
            if (lenght > 8)
            {
                return Convert.ToInt32(aa.Substring(lenght - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(lenght - 1, 1));
            }
            
        }

        public bool TableGetbyState(int ButtonName, int state)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Durum from Masalar where ID=@TableID and Durum=@state",con);

            cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;
           try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                String Hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }

        public void setChangeTableState(string ButonName, int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Masalar Set Durum = @Durum where ID=@MasaNo",con);
            string MasaNo = "";
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string aa = ButonName;
            int uzunluk = aa.Length;

            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            if(uzunluk > 8)
            {
                MasaNo = aa.Substring(uzunluk - 2 , 2);
            }
            else
            {
                MasaNo = aa.Substring(uzunluk - 1, 1);
            }
            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = MasaNo;
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public void MasaKapasitesiveDurumuGetir(ComboBox cb)
        {
            cb.Items.Clear();
            string durum = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Masalar", con);
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cMasalar c = new cMasalar();
                if(c.Durum==2)
                {
                    durum = "DOLU";
                }
                else if(c.Durum==4)
                {
                    durum = "REZERVE";
                }
                c.Kapasite = Convert.ToInt32(dr["Kapasite"]);
                c.MasaBilgi = "Masa No:" + dr["ID"].ToString() + "Kapasitesi:" + dr["Kapasite"].ToString();
                c.ID = Convert.ToInt32(dr["ID"]);
                cb.Items.Add(c);
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public override string ToString()
        {
            return MasaBilgi;
        }
    }
    
}
