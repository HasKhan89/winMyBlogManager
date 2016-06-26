using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Wissen.SC501.Common
{
    public class DatabaseIslemleri
    {
        // properties..
        public SqlConnection Baglanti { get; private set; }
        public SqlCommand SorguCalistirici { get; private set; }

        // Constructor
        public DatabaseIslemleri()
        {
            string sifreli = ConfigurationManager.ConnectionStrings["baglanti_cumlesi"].ConnectionString;

            Sifreleyici sifreleyici = new Sifreleyici();
            string sifresiz = sifreleyici.SifreCoz(sifreli);

            Baglanti = new SqlConnection(sifresiz);

            SorguCalistirici = new SqlCommand();
            SorguCalistirici.Connection = Baglanti;
        }

        public void SorguCalistir(string sorgu)
        {
            SorguCalistirici.CommandText = sorgu;

            try
            {
                Baglanti.Open();
                SorguCalistirici.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new Exception("Hata oluştu.");
                throw ex;
            }
            finally
            {
                if(Baglanti.State != ConnectionState.Closed || Baglanti.State != ConnectionState.Broken)
                {
                    Baglanti.Close();
                }
            }
            
        }

        public DataTable SelectYap(string sorgu)
        {
            SorguCalistirici.CommandText = sorgu;
            SqlDataAdapter adaptor = new SqlDataAdapter(SorguCalistirici);

            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);

            return tablo;
        }
    }
}
