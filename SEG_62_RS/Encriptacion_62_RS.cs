using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SEG_62_RS
{
    public class Encriptacion_62_RS
    {
        public static string EncriptarSHA256_62_RS(string input_62_RS)
        {
            using (SHA256 md5_62_RS = SHA256.Create())
            {
                byte[] inputBytes_62_RS = Encoding.ASCII.GetBytes(input_62_RS);
                byte[] hashBytes_62_RS = md5_62_RS.ComputeHash(inputBytes_62_RS);

                StringBuilder sb_62_RS = new StringBuilder();
                for (int i = 0; i < hashBytes_62_RS.Length; i++)
                {
                    sb_62_RS.Append(hashBytes_62_RS[i].ToString("X2"));
                }
                return sb_62_RS.ToString();
            }
        }

        public static string EncriptarReversible(string texto)
        {
            return texto;
        }

    }
}
