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
    class cPersonelGorev
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int PersonelGorevID;
        private string Tanım;
        #endregion

        #region Properties
        public int PersonelGorevID1 { get => PersonelGorevID; set => PersonelGorevID = value; }
        public string Tanım1 { get => Tanım; set => Tanım = value; } 
        #endregion

        public void PersonelGorevGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString); 
            SqlCommand cmd = new SqlCommand("Select * from PersonelGorevleri", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    cPersonelGorev c = new cPersonelGorev();
                    c.PersonelGorevID = Convert.ToInt32(dr["ID"].ToString());
                    c.Tanım = dr["Gorev"].ToString();
                    cb.Items.Add(c);
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            dr.Close();
            con.Close();
        }

        public string PersonelGorevTanım(int per)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Gorev from PersonelGorevleri where ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = per;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            
            con.Close();

            return sonuc;
        }

        public override string ToString()
        {
            return Tanım;
        }
    }
}
