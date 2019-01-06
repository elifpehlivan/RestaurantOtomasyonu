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
    class cMusteriler
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int MusteriID;
        private string MusteriAdı;
        private string MusteriSoyadı;
        private string Telefon;
        private string Adres;
        private string Email;
        #endregion

        #region Properties
        public int MusteriID1 { get => MusteriID; set => MusteriID = value; }
        public string MusteriAdı1 { get => MusteriAdı; set => MusteriAdı = value; }
        public string MusteriSoyadı1 { get => MusteriSoyadı; set => MusteriSoyadı = value; }
        public string Telefon1 { get => Telefon; set => Telefon = value; }
        public string Adres1 { get => Adres; set => Adres = value; }
        public string Email1 { get => Email; set => Email = value; } 
        #endregion

        public bool MusteriVarmı(string tlf)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "MusteriVarmı";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;

            
            if(con.State == ConnectionState.Closed)
            {
                con.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);
                }
                catch(SqlException ex)
                {
                    string hata = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return sonuc;
        }

        public int MusteriEkle(cMusteriler m)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Müsteriler(Adı, Soyadı, Adres, Telefon, Email) values (@Adı, @Soyadı, @Adres, @Telefon, @Email); select SCOPE_IDENTITY()", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@Adı", SqlDbType.VarChar).Value = m.MusteriAdı;
                cmd.Parameters.Add("@Soyadı", SqlDbType.VarChar).Value = m.MusteriSoyadı;
                cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = m.Adres;
                cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = m.Telefon;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = m.Email;

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

        public bool MusteriBilgileriGuncelle(cMusteriler m)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Müsteriler set Adı=@Adı, Soyadı=@Soyadı, Adres=@Adres, Telefon=@Telefon, Email=@Email where ID=@MusteriID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@Adı", SqlDbType.VarChar).Value = m.MusteriAdı;
                cmd.Parameters.Add("@Soyadı", SqlDbType.VarChar).Value = m.MusteriSoyadı;
                cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = m.Adres;
                cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = m.Telefon;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = m.Email;
                cmd.Parameters.Add("@MusteriID", SqlDbType.VarChar).Value = m.MusteriID;

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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

        public void MusterileriGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Müsteriler", con);
            SqlDataReader dr = null;

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();

                    dr = cmd.ExecuteReader();
                    int sayac = 0;

                    while(dr.Read())
                    {
                        lv.Items.Add(dr["ID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Soyadı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Telefon"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adres"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Email"].ToString());
                        sayac++;
                    }
                }
            }
            catch(SqlException ex)
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
        //Müşterileri ID'ye gröe getirme.
        public void MusterileriGetirID(int MusteriID, TextBox Adı, TextBox Soyadı, TextBox tlf, TextBox Adres, TextBox Email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Müsteriler where ID=@MusteriID", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("MusteriID", SqlDbType.Int).Value = MusteriID;

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        Adı.Text = dr["Adı"].ToString();
                        Soyadı.Text = dr["Soyadı"].ToString();
                        tlf.Text = dr["Telefon"].ToString();
                        Adres.Text = dr["Adres"].ToString();
                        Email.Text = dr["Email"].ToString();
                    }
                }
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void MusteriGetirAd(ListView lv, string MusteriAdı)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Müsteriler where Adı like @MusteriAdı + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("MusteriAdı", SqlDbType.VarChar).Value = MusteriAdı;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Soyadı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Telefon"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adres"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Email"].ToString());

                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void MusteriGetirSoyadı(ListView lv, string MusteriSoyadı)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Müsteriler where Soyadı like @MusteriSoyadı + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("MusteriSoyadı", SqlDbType.VarChar).Value = MusteriSoyadı;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Soyadı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Telefon"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adres"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Email"].ToString());

                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void MusteriGetirTlf(ListView lv, string Telefon)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Müsteriler where Telefon like @Tlf + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("Tlf", SqlDbType.VarChar).Value = Telefon;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Soyadı"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Telefon"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adres"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Email"].ToString());

                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
    }
}
