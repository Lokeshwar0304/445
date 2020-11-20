using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
    public class Encryption
    {
        public string encryption(string String_to_encrypt)
        {
            string Key_for_encryption = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            byte[] bytes_to_encrypt = Encoding.Unicode.GetBytes(String_to_encrypt);
            using (Aes val_of_crypter = Aes.Create())
            {
                Rfc2898DeriveBytes encrypter_bytes = new Rfc2898DeriveBytes(Key_for_encryption, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76,
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        });
                val_of_crypter.Key = encrypter_bytes.GetBytes(32);
                val_of_crypter.IV = encrypter_bytes.GetBytes(16);
                using (MemoryStream memory_stream = new MemoryStream())
                {
                    using (CryptoStream Crypto_stream = new CryptoStream(memory_stream, val_of_crypter.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        Crypto_stream.Write(bytes_to_encrypt, 0, bytes_to_encrypt.Length);
                        Crypto_stream.Close();
                    }
                    String_to_encrypt = Convert.ToBase64String(memory_stream.ToArray());
                }
            }
            return String_to_encrypt;
        }
    }
}
