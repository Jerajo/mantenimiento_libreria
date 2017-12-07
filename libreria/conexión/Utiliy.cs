using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
        public static bool CompareByteArray(Byte[] arrayA, Byte[] arrayB)
        {
            if (arrayA.Length != arrayB.Length)
                return false;

            for (int i = 0; i <= arrayA.Length - 1; i++)
                if (!arrayA[i].Equals(arrayB[i]))
                    return false;
            return true;
        }
        //https://stackoverflow.com/questions/11413576/how-to-implement-triple-des-in-c-sharp-complete-example

        /// <summary>
        /// Encriptacion en Triple Des o 3DES
        /// </summary>
        /// <param name="strEncriptar"></param>
        /// <param name="bytPK"></param>
        /// <returns></returns>
        public static string Encriptar(string strEncriptar, byte[] bytPK)
        {

            TripleDESCryptoServiceProvider Tdes = new TripleDESCryptoServiceProvider();
            byte[] encrypted = null;
            byte[] returnValue = null;

            try
            {
                Tdes.Key = bytPK;
                Tdes.Mode = CipherMode.ECB;
                Tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform crypT = Tdes.CreateEncryptor();
                byte[] toEncrypt = UTF8Encoding.UTF8.GetBytes(strEncriptar);
                encrypted = crypT.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

            }
            catch { }
            finally { Tdes.Clear();  }

            return Convert.ToBase64String(returnValue, 0, returnValue.Length);
        }

        public static string Desencriptar(byte[] bytDesEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] tempArray = new byte[miRijndael.IV.Length];
            byte[] encrypted = new byte[bytDesEncriptar.Length - miRijndael.IV.Length];
            string returnValue = string.Empty;

            try
            {
                miRijndael.Key = bytPK;

                Array.Copy(bytDesEncriptar, tempArray, tempArray.Length);
                Array.Copy(bytDesEncriptar, tempArray.Length, encrypted, 0, encrypted.Length);
                miRijndael.IV = tempArray;

                returnValue = System.Text.Encoding.UTF8.GetString((miRijndael.CreateDecryptor()).TransformFinalBlock(encrypted, 0, encrypted.Length));
            }
            catch { }
            finally { miRijndael.Clear(); }

            return returnValue;
        }

        public static string Encriptar(string strEncriptar, string strPK)
        {
            return Encriptar(strEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
        }

        public static string Desencriptar(byte[] bytDesEncriptar, string strPK)
        {
            return Desencriptar(bytDesEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
        }
    }
}
