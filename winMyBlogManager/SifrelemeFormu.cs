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
    public partial class SifrelemeFormu : Form
    {
        Sifreleyici sifreleyici = new Sifreleyici();

        public SifrelemeFormu()
        {
            InitializeComponent();
        }

        private void btnSifrele_Click(object sender, EventArgs e)
        {
            txtSifreli.Text = sifreleyici.Sifrele(txtSifresiz.Text);
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            txtSifresiz.Text = sifreleyici.SifreCoz(txtSifreli.Text);
        }
    }
}
