using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Wissen.SC501.Common
{
    public class Sifreleyici
    {
        public string Sifrele(string metin)
        {
            if (string.IsNullOrEmpty(metin))
            {
                throw new ArgumentNullException("Şifrelenecek veri yok");
            }

            string anahtar = ConfigurationManager.AppSettings["anahtar"];

            byte[] aryKey = Encoding.UTF8.GetBytes(anahtar); // BURAYA 8 bit string DEĞER GİRİN
            byte[] aryIV = Encoding.UTF8.GetBytes(anahtar); // BURAYA 8 bit string DEĞER GİRİN

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cs);

            writer.Write(metin);
            writer.Flush();

            cs.FlushFinalBlock();
            writer.Flush();

            string sonuc = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

            writer.Dispose();
            cs.Dispose();
            ms.Dispose();

            return sonuc;
        }

        public string SifreCoz(string sifreliMetin)
        {
            if (string.IsNullOrEmpty(sifreliMetin))
            {
                throw new ArgumentNullException("Şifre çözülecek veri yok.");
            }

            string anahtar = ConfigurationManager.AppSettings["anahtar"];

            byte[] aryKey = Encoding.UTF8.GetBytes(anahtar); // BURAYA 8 bit string DEĞER GİRİN
            byte[] aryIV = Encoding.UTF8.GetBytes(anahtar); // BURAYA 8 bit string DEĞER GİRİN

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(sifreliMetin));
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cs);
            string sonuc = reader.ReadToEnd();

            reader.Dispose();
            cs.Dispose();
            ms.Dispose();

            return sonuc;
        }
    }
}
