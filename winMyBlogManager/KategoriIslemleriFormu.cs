using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wissen.SC501.Common;

namespace winMyBlogManager
{
    public partial class KategoriIslemleriFormu : Form
    {
        public KategoriIslemleriFormu()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            DatabaseIslemleri db = new DatabaseIslemleri();

            string sorgu = "INSERT INTO Kategoriler VALUES(@Adi,@Aciklama,@GizliMi,GETDATE())";

            try
            {
                db.SorguCalistirici.Parameters.AddWithValue("@Adi", txtAdi.Text);
                db.SorguCalistirici.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                db.SorguCalistirici.Parameters.AddWithValue("@GizliMi", chkGizliMi.Checked);

                db.SorguCalistir(sorgu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            KategorileriYukle();
        }

        private void KategoriIslemleriFormu_Load(object sender, EventArgs e)
        {
            KategorileriYukle();
        }

        private void KategorileriYukle()
        {
            lstKategoriler.Items.Clear();

            DatabaseIslemleri db = new DatabaseIslemleri();
            DataTable dt = db.SelectYap("SELECT KategoriID, Adi, Aciklama, GizliMi, OlusturmaTarihi FROM Kategoriler");

            foreach (DataRow row in dt.Rows)
            {
                // Veriler DataRow'un hücrelerinden okunur.
                int id = (int)row["KategoriID"];
                string ad = row["Adi"].ToString();
                string ack = row["Aciklama"].ToString();
                bool gizli = (bool)row["GizliMi"];
                DateTime olTarih = (DateTime)row["OlusturmaTarihi"];

                // Kategori nesnesi oluşturularak, veriler set edilir.
                Kategori kategori = new Kategori();
                kategori.KategoriID = id;
                kategori.Adi = ad;
                kategori.Aciklama = ack;
                kategori.GizliMi = gizli;
                kategori.OlusturmaTarihi = olTarih;

                lstKategoriler.Items.Add(kategori);
            }
        }

        private void lstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Listbox'dan seçim yapılmamışsa metot sonlandırılır.
            if (lstKategoriler.SelectedIndex == -1)
            {
                return; // Metodu sonlandır..
            }

            // Seçili Kategori nesnesi listbox'dan elde edilir.
            Kategori k = (Kategori)lstKategoriler.SelectedItem;

            // Kontrollere veriler yüklenir.
            txtAdi.Text = k.Adi;
            txtAciklama.Text = k.Aciklama;
            chkGizliMi.Checked = k.GizliMi;
            txtOlusturmaTarihi.Text = k.OlusturmaTarihi.ToShortDateString();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtAdi.Clear();
            txtAciklama.Clear();
            txtOlusturmaTarihi.Clear();
            chkGizliMi.Checked = false;

            lstKategoriler.SelectedIndex = -1;  // hiçbirini seçme..
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedIndex == -1)
            {
                MessageBox.Show("Durr, kendine gel.. Bir kategori seçiniz.");
                return;
            }

            DatabaseIslemleri db = new DatabaseIslemleri();

            Kategori k = (Kategori)lstKategoriler.SelectedItem;

            string sorgu = "UPDATE Kategoriler SET Adi=@Adi, Aciklama=@Aciklama, GizliMi=@GizliMi WHERE KategoriID=@ID";

            try
            {
                db.SorguCalistirici.Parameters.AddWithValue("@Adi", txtAdi.Text);
                db.SorguCalistirici.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                db.SorguCalistirici.Parameters.AddWithValue("@GizliMi", chkGizliMi.Checked);
                db.SorguCalistirici.Parameters.AddWithValue("@ID", k.KategoriID);

                db.SorguCalistir(sorgu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            KategorileriYukle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedIndex == -1)
            {
                MessageBox.Show("Durr, kendine gel.. Bir kategori seçiniz.");
                return;
            }

            DatabaseIslemleri db = new DatabaseIslemleri();
            Kategori k = (Kategori)lstKategoriler.SelectedItem;

            string sorgu = "DELETE FROM Kategoriler WHERE KategoriID=@ID";

            try
            {
                db.SorguCalistirici.Parameters.AddWithValue("@ID", k.KategoriID);

                db.SorguCalistir(sorgu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            KategorileriYukle();
        }
    }
}
