using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Quiz.Utility
{
    public static class UtilityManager
    {
        public static void GetAge(DateTime brithDate, out int days, out int months, out int years)
        {

            TimeSpan t = DateTime.Now.Subtract(brithDate);
            DateTime v = new DateTime(1, 1, 1);
            DateTime vv = v.AddDays(t.TotalDays);

            days = vv.Day - 1;
            months = vv.Month - 1;
            years = vv.Year - 1;


        }
        public static int  GetAgeYear(DateTime brithDate)
        {

            TimeSpan t = DateTime.Now.Subtract(brithDate);
            DateTime v = new DateTime(1, 1, 1);
            DateTime vv = v.AddDays(t.TotalDays);

            return  vv.Year - 1;


        }

        public static string CreateRandomString(int length)
        {
            length -= 12; //12 digits are the counter
            if (length <= 0)
                throw new ArgumentOutOfRangeException("length");
            long count = System.Threading.Interlocked.Increment(ref length);
            Byte[] randomBytes = new Byte[length * 3 / 4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            byte[] buf = new byte[8];
            buf[0] = (byte)count;
            buf[1] = (byte)(count >> 8);
            buf[2] = (byte)(count >> 16);
            buf[3] = (byte)(count >> 24);
            buf[4] = (byte)(count >> 32);
            buf[5] = (byte)(count >> 40);
            buf[6] = (byte)(count >> 48);
            buf[7] = (byte)(count >> 56);
            return Convert.ToBase64String(buf) + Convert.ToBase64String(randomBytes);
        }

        public static string GetIpAddress()  // Get IP Address
        {
            string ip = "";
            IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
            IPAddress[] addr = ipEntry.AddressList;
            ip = addr[2].ToString();
            return ip;
        }
        public static string GetCompCode()  // Get Computer Name
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            return strHostName;
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}