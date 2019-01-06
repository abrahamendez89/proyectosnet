using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomFiltersMVC
{

    class PrimitiveToStringConverter_ : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(decimal?); 
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class SeguridadCAF
    {                
        public static T DeserializarObjeto<T>(string mensajeDesencriptado)
        {
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };

            T resultado = JsonConvert.DeserializeObject<T>(mensajeDesencriptado, serializerSettings);

            return resultado;
        }

        private static string Serializar(object resultado)
        {
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, DateTimeZoneHandling = DateTimeZoneHandling.Unspecified, DateFormatString = "yyyy-MM-ddTHH:mm:ss", Converters = { new PrimitiveToStringConverter_() } };

            string resultadoSerializado = JsonConvert.SerializeObject(resultado, serializerSettings);

            return resultadoSerializado;
        }

        private static bool ValidarChecksum(Dictionary<string, string> mensajeDeserializado)
        {
            return mensajeDeserializado["checksum"].ToLower() == GenerarChecksum(mensajeDeserializado["mensaje"]).ToLower();
        }

        public static string GenerarChecksum(string contenido)
        {
            string theString = contenido;

            string hash;
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                hash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(theString))
                ).Replace("-", String.Empty);
            }

            return hash;
        }
        
        public static String EncriptarSha256(String valor)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(valor));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            
            return Sb.ToString();
        }
                        
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        
        public static string SerializarObjeto(object objetoDeserializado)
        {
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, DateTimeZoneHandling = DateTimeZoneHandling.Unspecified, DateFormatString = "yyyy-MM-ddTHH:mm:ss", Converters = { new PrimitiveToStringConverter_() } };

            string mensajeSerializado = JsonConvert.SerializeObject(objetoDeserializado, serializerSettings);

            return mensajeSerializado;
        }

        static byte[] generateRandomIV()
        {
            byte[] byteArray = new byte[16];
            new Random().NextBytes(byteArray);

            return byteArray;
        }


        static byte[] EncryptStringToBytes_Aes_TEST(string plainText, byte[] Key)
        {
            byte[] encrypted;
            byte[] IV;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;

                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                aesAlg.Mode = CipherMode.CBC;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption. 
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            var combinedIvCt = new byte[IV.Length + encrypted.Length];
            Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
            Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

            // Return the encrypted bytes from the memory stream. 
            return combinedIvCt;

        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");

            byte[] encrypted;
            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = Key;
                aesAlg.IV = generateRandomIV();

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");

            var iv = new byte[16];
            var ct = new byte[cipherText.Length - 16];

            Array.Copy(cipherText, 0, iv, 0, iv.Length);
            Array.Copy(cipherText, 16, ct, 0, ct.Length);

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = Key;
                aesAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(ct))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public static string Encriptar(string texto, string contrasena)
        {
            var passArray = GetBytes(contrasena);
            var cryptoArray = EncryptStringToBytes_Aes(texto, passArray);

            return Convert.ToBase64String(cryptoArray);
        }
        private static RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        private static byte[] EncryptCBC(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
            .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        private static byte[] DecryptCBC(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
            .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        private static String EncryptCBCStr(String plainText, String key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(EncryptCBC(plainBytes, GetRijndaelManaged(key)));
        }

        private static String DecryptCBCStr(String encryptedText, String key)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(DecryptCBC(encryptedBytes, GetRijndaelManaged(key)));
        }
        public static String DesencriptarAES(String encriptado, String encryptKey)
        {
            var decryptCBC = DecryptCBCStr(encriptado, encryptKey);
            return decryptCBC;
        }
        public static string EncriptarAES(String valor, String encryptKey)
        {
            var cypherCBC = EncryptCBCStr(valor, encryptKey);
            return cypherCBC;
        }

        public static string Desencriptar(string texto, string contrasena)
        {
            var desencriptado = "";

            try
            {
                var passArray = GetBytes(contrasena);

                var cryptoArray = Convert.FromBase64String(texto);
                desencriptado = DecryptStringFromBytes_Aes(cryptoArray, passArray);
            }
            catch (Exception ex)
            {
                desencriptado = null;
            }

            return desencriptado;
        }

    }
}
