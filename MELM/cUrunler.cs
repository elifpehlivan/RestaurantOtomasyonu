using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace MELM
{
    class cUrunler
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int UrunID;
        private int UrunTurNo;
        private string UrunAdı;
        private decimal Fiyat;
        private string Açıklama;
        #endregion

        #region Properties
        public int UrunID1 { get => UrunID; set => UrunID = value; }
        public int UrunTurNo1 { get => UrunTurNo; set => UrunTurNo = value; }
        public string UrunAdı1 { get => UrunAdı; set => UrunAdı = value; }
        public decimal Fiyat1 { get => Fiyat; set => Fiyat = value; }
        public string Açıklama1 { get => Açıklama; set => Açıklama = value; } 
        #endregion

        public void UrunleriListeleByUrunAdı(ListView lv, string UrunAdı)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Urunler where Durum =0 and UrunAdi like '%' +@UrunAdi+ '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@UrunAdi", SqlDbType.VarChar).Value = UrunAdı;
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
                        lv.Items[sayac].SubItems.Add(dr["KategoriID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["UrunAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Acıklama"].ToString());
                        lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["Fiyat"].ToString()));
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

        public int UrunEkle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Urunler(UrunAdi, KategoriID, Acıklama, Fiyat) values (@UrunAdi, @KategoriID, @Acıklama, @Fiyat)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@UrunAdi", SqlDbType.VarChar).Value = u.UrunAdı;
                cmd.Parameters.Add("@KategoriID", SqlDbType.Int).Value = u.UrunTurNo;
                cmd.Parameters.Add("@Acıklama", SqlDbType.VarChar).Value = u.Açıklama;
                cmd.Parameters.Add("@Fiyat", SqlDbType.Money).Value = u.Fiyat;

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

        public void UrunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Urunler.*, KategoriAdi from Urunler Inner Join Kategoriler on Kategoriler.ID = Urunler.KategoriID where Urunler.Durum = 0", con);
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
                        lv.Items[sayac].SubItems.Add(dr["KategoriID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KategoriAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["UrunAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["Fiyat"].ToString()));
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

        public int UrunleriGuncelle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Urunler set UrunAdi=@UrunAdi, KategoriID = @KategoriID, Acıklama=@Acıklama, Fiyat=@Fiyat where ID=@UrunID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@UrunAdi", SqlDbType.VarChar).Value = u.UrunAdı;
                cmd.Parameters.Add("@KategoriID", SqlDbType.Int).Value = u.UrunTurNo;
                cmd.Parameters.Add("@Acıklama", SqlDbType.VarChar).Value = u.Açıklama;
                cmd.Parameters.Add("@Fiyat", SqlDbType.Money).Value = u.Fiyat;
                cmd.Parameters.Add("@UrunID", SqlDbType.Int).Value = u.UrunID;

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

        public int UrunleriSil(cUrunler u, int kat)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "Update Urunler set Durum = 1 where";
            if(kat == 0)
            {
                sql += "KategoriID = @UrunID";
            }
            else
            {
                sql += "ID = @UrunID";
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@UrunID", SqlDbType.Int).Value = u.UrunID;

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

        public void UrunleriListeleByUrunID(ListView lv, int UrunID)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Urunler.*, KategoriAdi from Urunler Inner Join Kategoriler on Kategoriler.ID = Urunler.KategoriID where Urunler.Durum = 0 and Urunler.KategoriID = @UrunID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
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
                        lv.Items[sayac].SubItems.Add(dr["KategoriID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KategoriAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["UrunAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["Fiyat"].ToString()));
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

        public void UrunleriListeleİstatistiklereGore(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT  top  10  Urunler.UrunAdi, SUM(Satıslar.Adet) as Adeti from Kategoriler INNER JOIN Urunler on Kategoriler.ID = Urunler.KategoriID INNER JOIN Satıslar on Urunler.ID = Satıslar.UrunID INNER JOIN Adisyonlar on Satıslar.AdisyonID = Adisyonlar.ID where(CONVERT(datetime, Tarih, 104) between CONVERT(datetime, @Baslangic, 104) and CONVERT(datetime, @Bitis, 104)) group by Urunler.UrunAdi order by Adeti desc", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    dr = cmd.ExecuteReader();
                    int sayac = 0;

                    while (dr.Read())
                    {
                        lv.Items.Add(dr["UrunAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adeti"].ToString());
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

        public void UrunleriListeleİstatistiklereGoreUrunID(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis, int UrunKategoriID)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT  top  10  Urunler.UrunAdi, SUM(Satıslar.Adet) as Adeti from Kategoriler INNER JOIN Urunler on Kategoriler.ID = Urunler.KategoriID INNER JOIN Satıslar on Urunler.ID = Satıslar.UrunID INNER JOIN Adisyonlar on Satıslar.AdisyonID = Adisyonlar.ID where(CONVERT(datetime, Tarih, 104) between CONVERT(datetime, @Baslangic, 104) and CONVERT(datetime, @Bitis, 104)) and (Urunler.KategoriID = @KategoriID) group by Urunler.UrunAdi order by Adeti desc", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@KategoriID", SqlDbType.Int).Value = UrunKategoriID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                    dr = cmd.ExecuteReader();
                    int sayac = 0;

                    while (dr.Read())
                    {
                        lv.Items.Add(dr["UrunAdi"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["Adeti"].ToString());
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
    }
}
