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
    
    class cPersoneller
    {
        
        cGenel gnl = new cGenel();
        #region Fields
        private int PersonelID;
        private int PersonelGorevID;
        private string PersonelAdı;
        private string PersonelSoyadı;
        private string PersonelParola;
        private string PersonelKullaniciAdi;
        private bool PersonelDurum;
        private object sqlDbType;
        #endregion

        #region Properties
       
        public int PersonelID1 { get => PersonelID; set => PersonelID = value; }
        public int PersonelGorevID1 { get => PersonelGorevID; set => PersonelGorevID = value; }
        public string PersonelAdı1 { get => PersonelAdı; set => PersonelAdı = value; }
        public string PersonelSoyadı1 { get => PersonelSoyadı; set => PersonelSoyadı = value; }
        public string PersonelParola1 { get => PersonelParola; set => PersonelParola = value; }
        public string PersonelKullaniciAdi1 { get => PersonelKullaniciAdi; set => PersonelKullaniciAdi = value; }
        public bool PersonelDurum1 { get => PersonelDurum; set => PersonelDurum = value; }
        #endregion  //Daha düzenli bir kod yapısı olsun diye oluşturduk.
        public bool PersonelEntryControl(String password, int UserID)
         
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString); //Connection ile veri tabanına bağlandık.
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@ID and Parola=@password", con);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = UserID;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
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
                string hata = ex.Message;
                throw;
            }
            return result;
        }
        public void PersonelGetbyInformation(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //Connection ile veri tabanına bağlandık.
            SqlCommand cmd = new SqlCommand("Select * from Personeller", con);
            
            
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            SqlDataReader dr = cmd.ExecuteReader(); //Okumayı kapattık.
            while(dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p.PersonelID = Convert.ToInt32(dr["ID"]);
                p.PersonelGorevID = Convert.ToInt32(dr["GorevID"]);
                p.PersonelAdı = Convert.ToString(dr["Adı"]);
                p.PersonelSoyadı = Convert.ToString(dr["Soyadı"]);
                p.PersonelParola = Convert.ToString(dr["Parola"]);
                p.PersonelKullaniciAdi = Convert.ToString(dr["KullanıcıAdı"]);
                p.PersonelDurum = Convert.ToBoolean(dr["Durum"]);
                cb.Items.Add(p);
            }
            dr.Close();
            con.Close(); //Bağlantıyı kapattık.
            
        }
        public override string ToString()
        {
            return PersonelAdı + " " + PersonelSoyadı; 
        }

        public void PersonelBilgileriniGetirLV(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); 
            SqlCommand cmd = new SqlCommand("Select Personeller.*, PersonelGorevleri.Gorev from Personeller Inner Join PersonelGorevleri on PersonelGorevleri.ID = Personeller.GorevID where Personeller.Durum = 0", con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GorevID"].ToString());
                lv.Items[i].SubItems.Add(dr["Gorev"].ToString());
                lv.Items[i].SubItems.Add(dr["Adı"].ToString());
                lv.Items[i].SubItems.Add(dr["Soyadı"].ToString());
                lv.Items[i].SubItems.Add(dr["KullanıcıAdı"].ToString());
                i++;
            }
            dr.Close();
            con.Close(); 

        }

        public void PersonelBilgileriniGetirIDLV(ListView lv, int perID)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Personeller.*, PersonelGorevleri.Gorev from Personeller Inner Join PersonelGorevleri on PersonelGorevleri.ID = Personeller.GorevID where Personeller.Durum = 0 and Personeller.ID = perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GorevID"].ToString());
                lv.Items[i].SubItems.Add(dr["Gorev"].ToString());
                lv.Items[i].SubItems.Add(dr["Adı"].ToString());
                lv.Items[i].SubItems.Add(dr["Soyadı"].ToString());
                lv.Items[i].SubItems.Add(dr["KullanıcıAdı"].ToString());
                i++;
            }
            dr.Close();
            con.Close();

        }

        public string PersonelBilgiGetirİsim(int perID)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Adı from Personeller where Personeller.Durum = 0 and Personeller.ID = perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToString(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                
            }
            con.Close();
            return sonuc;
        }

        public bool PersonelSifreDegistir(int PersonelID, string password)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Personeller set Parola = @password where ID = @PersonelID", con);
            cmd.Parameters.Add("PersonelID", SqlDbType.Int).Value = PersonelID;
            cmd.Parameters.Add("password", SqlDbType.VarChar).Value = password;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw;
            }
            con.Close();


            return sonuc;
        }

        public bool PersonelEkle(cPersoneller cp)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Personeller(Adı, Soyadı, Parola, GorevID) values (@Adı, @Soyadı, @Parola, @GorevID)", con);
            cmd.Parameters.Add("Adı", SqlDbType.VarChar).Value = PersonelAdı;
            cmd.Parameters.Add("Soyadı", SqlDbType.VarChar).Value = PersonelSoyadı;
            cmd.Parameters.Add("Parola", SqlDbType.VarChar).Value = PersonelParola;
            cmd.Parameters.Add("GorevID", SqlDbType.Int).Value = PersonelGorevID;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw;
            }
            con.Close();


            return sonuc;
        }

        public bool PersonelGuncelle(cPersoneller cp, int perID)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Personeller set Adı = @Adı, Soyadı = @Soyadı, Parola = @Parola, GorevID = @GorevID where ID = @perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;
            cmd.Parameters.Add("Adı", SqlDbType.VarChar).Value = PersonelAdı;
            cmd.Parameters.Add("Soyadı", SqlDbType.VarChar).Value = PersonelSoyadı;
            cmd.Parameters.Add("Parola", SqlDbType.VarChar).Value = PersonelParola;
            cmd.Parameters.Add("GorevID", SqlDbType.Int).Value = PersonelGorevID;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw;
            }
            con.Close();


            return sonuc;
        }

        public bool PersonelSil(int perID)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Personeller set Durum = 1 where ID = @perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw;
            }
            con.Close();


            return sonuc;
        }
    }


}


