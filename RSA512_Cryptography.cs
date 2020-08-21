using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBSecurity_Lab04_Public
{
    class RSA512_Cryptography
    {
        public static void makeKey(string pubKeyPath, string priKeyPath)
        {
            //call a RSA csp instance to generate a key pair
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(512);
            // generate the keypair
            RSAParameters prikey = csp.ExportParameters(true);
            RSAParameters pubkey = csp.ExportParameters(false);
            //write the keys and store in separated files
            string pubKeyString;
            {
                StringWriter sw = new StringWriter();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, pubkey);
                pubKeyString = sw.ToString();
                File.WriteAllText(pubKeyPath, pubKeyString);
            }
            string priKeyString;
            {
                StringWriter sw = new StringWriter();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, prikey);
                priKeyString = sw.ToString();
                File.WriteAllText(priKeyPath, priKeyString);
            }
        }
        public static byte[] encryptText(string pubkeyPath, string plainText)
        {
            string pubKeyString;
            using (StreamReader reader = new StreamReader(pubkeyPath))
            {
                pubKeyString = reader.ReadToEnd();
            }
            StringReader sr = new StringReader(pubKeyString);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters((RSAParameters)xs.Deserialize(sr));
            byte[] plainByte = Encoding.UTF8.GetBytes(plainText);
            return rsa.Encrypt(plainByte, false);
        }
        public static string decryptText(string priKeyPath, byte[] cipherText)
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();

            string priKeyString;
            {
                priKeyString = File.ReadAllText(priKeyPath);
                StringReader sr = new StringReader(priKeyString);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                RSAParameters priKey = (RSAParameters)xs.Deserialize(sr);
                csp.ImportParameters(priKey);
            }
            
            byte[] plainByte = csp.Decrypt(cipherText, false);
            return Encoding.UTF8.GetString(plainByte);
        }
    }
}
