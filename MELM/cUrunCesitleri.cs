using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MELM
{
    class cUrunCesitleri
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int UrunTurNo;
        private string KategoriAdi;
        private string Acıklama;
        #endregion

        #region Properties
        public int UrunTurNo1 { get => UrunTurNo; set => UrunTurNo = value; }
        public string KategoriAdi1 { get => KategoriAdi; set => KategoriAdi = value; }
        public string Acıklama1 { get => Acıklama; set => Acıklama = value; }
        #endregion
        public void getByProductTypes(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select UrunAdi, Fiyat, Urunler.ID from Kategoriler Inner Join Urunler on Kategoriler.ID = Urunler.KategoriID where Urunler.KategoriID = @KategoriID", con);

            string aa = btn.Name;
            int uzunluk = aa.Length;

            cmd.Parameters.Add("@KategoriID", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while(dr.Read())
            {
                Cesitler.Items.Add(dr["UrunAdi"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["Fiyat"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void getByProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Urunler where ID=@ID", con);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = txt;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["UrunAdi"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["Fiyat"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void UrunCesitleriniGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Kategoriler where Durum = 0", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cUrunCesitleri uc = new cUrunCesitleri();
                        uc.UrunTurNo = Convert.ToInt32(dr["ID"]);
                        uc.KategoriAdi = dr["KategoriAdi"].ToString();
                        uc.Acıklama = dr["Acıklama"].ToString();

                        cb.Items.Add(uc);
                    }
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

        public void UrunCesitleriniGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Kategoriler where Durum = 0", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    dr = cmd.ExecuteReader();
                    int sayac = 0;

                    while (dr.Read())
                    {
                        lv.Items.Add(dr["ID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KategoriAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Acıklama"].ToString());
                        sayac++;
                    }
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

        public void UrunCesitleriniGetir(ListView lv, string Source)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Kategoriler where Durum = 0 and KategoriAdi like '%' +@Source+ '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = Source;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    dr = cmd.ExecuteReader();
                    int sayac = 0;

                    while (dr.Read())
                    {
                        lv.Items.Add(dr["ID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KategoriAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Acıklama"].ToString());
                        sayac++;
                    }
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

        public int UrunKategoriEkle(cUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Kategoriler(KategoriAdi, Acıklama) values (@KategoriAdi, @Acıklama)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@KategoriAdi", SqlDbType.VarChar).Value = u.KategoriAdi;
                cmd.Parameters.Add("@Acıklama", SqlDbType.VarChar).Value = u.Acıklama;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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

        public int UrunKategoriGuncelle(cUrunCesitleri u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Kategoriler set KategoriAdi=@KategoriAdi, Acıklama=@Acıklama where ID=@KategoriID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@KategoriAdi", SqlDbType.VarChar).Value = u.KategoriAdi;
                cmd.Parameters.Add("@Acıklama", SqlDbType.VarChar).Value = u.Acıklama;
                cmd.Parameters.Add("@KategoriID", SqlDbType.Int).Value = u.UrunTurNo;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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

        public int UrunKategoriSil(int ID)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Kategoriler set Durum = 1 where ID=@KategoriID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@KategoriID", SqlDbType.Int).Value = ID;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
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

        public override string ToString()
        {
            return KategoriAdi1;
        }

    }
}
