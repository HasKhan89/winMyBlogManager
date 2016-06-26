using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winMyBlogManager
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public bool GizliMi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
