using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
    public class Decryption
    {
        public string decryption(string String_to_decrypt)
        {
            string key_to_encrypt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            String_to_decrypt = String_to_decrypt.Replace(" ", "+");
            byte[] cypher_Bytes = Convert.FromBase64String(String_to_decrypt);

            using (Aes cryptor_one = Aes.Create())
            {
                Rfc2898DeriveBytes decryptor_bytes = new Rfc2898DeriveBytes(key_to_encrypt, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76,
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        });
                cryptor_one.Key = decryptor_bytes.GetBytes(32);
                cryptor_one.IV = decryptor_bytes.GetBytes(16);
                using (MemoryStream memory_stream = new MemoryStream())
                {
                    using (CryptoStream cs_decrypt = new CryptoStream(memory_stream, cryptor_one.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs_decrypt.Write(cypher_Bytes, 0, cypher_Bytes.Length);
                        cs_decrypt.Close();
                    }
                    String_to_decrypt = Encoding.Unicode.GetString(memory_stream.ToArray());
                }
            }
            return String_to_decrypt;

        }
    }
}
