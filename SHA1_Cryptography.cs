using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DBSecurity_Lab04_Public
{
    class SHA1_Cryptography
    {
        public static byte[] SHA1Hashing(string plaintext)
        {
            byte[] data = Encoding.UTF8.GetBytes(plaintext);
            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(data);
        }
    }
}
