using System;
using System.IO;
using System.Security.Cryptography;

namespace Inspire
{
    public class Encryption
    {
        protected Encryption()
        {
            //  constructor logic
        }

        // Encrypting array of bytes 
        private static byte[] Encrypt(byte[] inputData, byte[] pwd, byte[] value)
        {

            // store bytes in memory stream 
            MemoryStream stream = new MemoryStream();

            Rijndael rij = Rijndael.Create();
            rij.Key = pwd;
            rij.IV = value;
            CryptoStream cStream = new CryptoStream(stream, rij.CreateEncryptor(), CryptoStreamMode.Write);

            cStream.Write(inputData, 0, inputData.Length);
            cStream.Close();
            byte[] encryptedData = stream.ToArray();
            return encryptedData;
        }


        // Returns Rijndael encrypted string.
        public string Encrypt(string inputData, string pwd, int bits)
        {
            byte[] Bytes = System.Text.Encoding.Unicode.GetBytes(inputData);
            PasswordDeriveBytes pwdBytes = new PasswordDeriveBytes(pwd, new byte[] { 0x10, 0x40, 0x00, 0x34, 0x1A, 0x70, 0x01, 0x34, 0x56, 0xFF, 0x99, 0x77, 0x4C, 0x22, 0x49 });

            if (bits == 128)
            {
                byte[] encryptedData = Encrypt(Bytes, pwdBytes.GetBytes(16), pwdBytes.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else if (bits == 192)
            {
                byte[] encryptedData = Encrypt(Bytes, pwdBytes.GetBytes(24), pwdBytes.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else if (bits == 256)
            {
                byte[] encryptedData = Encrypt(Bytes, pwdBytes.GetBytes(32), pwdBytes.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else
            {
                // append all bits
                return string.Concat(bits);
            }
        }

        // Decrypt the byte array 
        private static byte[] Decrypt(byte[] outputData, byte[] pwd, byte[] value)
        {

            MemoryStream stream = new MemoryStream();
            Rijndael rij = Rijndael.Create();
            rij.Key = pwd;
            rij.IV = value;
            CryptoStream cStream = new CryptoStream(stream, rij.CreateDecryptor(), CryptoStreamMode.Write);
            cStream.Write(outputData, 0, outputData.Length);
            cStream.Close();
            byte[] decryptedData = stream.ToArray();
            return decryptedData;
        }

        // Decrypt the string.
        public string Decrypt(string str, string pwd, int bits)
        {
            byte[] Bytes = Convert.FromBase64String(str);
            PasswordDeriveBytes pwdBytes = new PasswordDeriveBytes(pwd,
              new byte[] { 0x10, 0x40, 0x00, 0x34, 0x1A, 0x70, 0x01, 0x34, 0x56, 0xFF, 0x99, 0x77, 0x4C, 0x22, 0x49 });

            if (bits == 128)
            {
                byte[] decryptedData = Decrypt(Bytes, pwdBytes.GetBytes(16), pwdBytes.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            else if (bits == 192)
            {
                byte[] decryptedData = Decrypt(Bytes, pwdBytes.GetBytes(24), pwdBytes.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            else if (bits == 256)
            {
                byte[] decryptedData = Decrypt(Bytes, pwdBytes.GetBytes(32), pwdBytes.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            else
            {
                return string.Concat(bits);
            }

        }
    }

}
