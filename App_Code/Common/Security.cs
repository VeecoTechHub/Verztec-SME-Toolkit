using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
using System.Security.Permissions;
using System.Diagnostics;
using System.IO;

namespace ABSSecurity
{
    public class Security
    {
        private static byte[] KEY_64 = { 49, 86, 90, 159, 100, 20, 218, 40 };
        private static byte[] IV_64 = { 45, 101, 250, 45, 90, 99, 150, 30 };

        public Security()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Password Encryption and Decryption
        /// <summary>
        ///Method to Encrypt Normal password string in to encrypted format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Encrypt(string value)
        {
            string strReturn = string.Empty;
            try
            {
                if (value != "")
                {
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
                    StreamWriter sw = new StreamWriter(cs);
                    sw.Write(value);
                    sw.Flush();
                    cs.FlushFinalBlock();
                    ms.Flush();
                    //convert back to a string 
                    strReturn = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return strReturn;
        }


        /// <summary>
        ///Method Decrypt the Encrypted password in to normal string format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Decrypt(string value)
        {
            string strReturn = string.Empty;
            try
            {
                if (value != "")
                {
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    //convert from string to byte array 
                    byte[] buffer = Convert.FromBase64String(value);
                    MemoryStream ms = new MemoryStream(buffer);
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
                    StreamReader sr = new StreamReader(cs);
                    strReturn = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return strReturn;
        }

        #endregion
    }
}
