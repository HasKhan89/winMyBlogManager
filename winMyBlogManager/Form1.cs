using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace winMyBlogManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuKategoriIslemleri_Click(object sender, EventArgs e)
        {
            KategoriIslemleriFormu frm = new KategoriIslemleriFormu();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = ConfigurationManager.AppSettings["UygulamaAdi"];
            this.mnuIslemler.Text = ConfigurationManager.AppSettings["İşlemlerMenuBasligi"];

            string yeniGosterilsinMiAppSettings = 
                ConfigurationManager.AppSettings["YeniGosterilsinMi"];

            bool yeniGosterilsinMi = bool.Parse(yeniGosterilsinMiAppSettings);

            //if (yeniGosterilsinMi == true)
            //    btnYeni.Visible = true;
            //else
            //    btnYeni.Visible = false;

            btnYeni.Visible = yeniGosterilsinMi;
        }

        private void mnuSifreleyici_Click(object sender, EventArgs e)
        {
            SifrelemeFormu frm = new SifrelemeFormu();
            frm.ShowDialog();
        }
    }
}
