using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace libreria { 

    public static class Utiliy
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public static class Encriptador
    {
        public static string KEY = "AbcDefGhiJklMnoQrsTuvWx0";
        //https://stackoverflow.com/questions/11413576/how-to-implement-triple-des-in-c-sharp-complete-example

        /// <summary>
        /// Encriptacion en Triple Des o 3DES
        /// </summary>
        /// <param name="strEncriptar"></param>
        /// <param name="bytPK"></param>
        /// <returns></returns>
        public static string Encriptar(string strEncriptar, string bytPK)
        {

            TripleDESCryptoServiceProvider Tdes = new TripleDESCryptoServiceProvider();
            byte[] encrypted = null;
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(bytPK);
            try
            {
                Tdes.Key = keyArray;
                Tdes.Mode = CipherMode.ECB;
                Tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform crypT = Tdes.CreateEncryptor();
                byte[] toEncrypt = UTF8Encoding.UTF8.GetBytes(strEncriptar);
                encrypted = crypT.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { Tdes.Clear();  }

            return Convert.ToBase64String(encrypted, 0, encrypted.Length);
        }

        public static string Desencriptar(string bytDesEncriptar, string bytPK)
        {

            byte[] toEncrypt = Convert.FromBase64String(bytDesEncriptar);
            byte[] resultArray = { };
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(bytPK);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            try
            {
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. 
                //We choose ECB(Electronic code Book)

                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                 resultArray = cTransform.TransformFinalBlock(
                                     toEncrypt, 0, toEncrypt.Length);
                

            }
            catch { }
            finally { tdes.Clear(); }
            //Release resources held by TripleDes Encryptor                
            
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        //public static string Encriptar(string strEncriptar, string strPK)
        //{
        //    return Encriptar(strEncriptar, Convert.FromBase64String(strPK));
        //}

        //public static string Desencriptar(string bytDesEncriptar, string strPK)
        //{
        //    return Desencriptar(bytDesEncriptar,  Convert.FromBase64String(strPK) );
        //}
    }
}
