using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Encriptador.Cifrado
{
    public class CifradoAES
    {
        private static int _iterations = 2;
        private static int _keySize = 256;

        private static string _hash = "SHA1";
        private static string _salt = "aselrias38490a32"; // Random
        private static string _vector = "8947az34awl34kjq"; // Random
        private static String password = "llave!@123$";

        //public static string DesencriptarTexto(String textoEncriptado)
        //{
        //    // Obtener la representación en bytes del texto cifrado  
        //    if (textoEncriptado == null || textoEncriptado.Equals("")) return "";

        //    Rijndael RijndaelAlg = Rijndael.Create();

        //    RijndaelAlg.GenerateKey();
        //    RijndaelAlg.GenerateIV();

        //    byte[] Key = RijndaelAlg.Key;
        //    byte[] IV = RijndaelAlg.IV;

        //    byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);
        //    // Crear un arreglo de bytes para almacenar los datos descifrados  
        //    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        //    // Crear una instancia del algoritmo de Rijndael  
        //    // Crear un flujo en memoria con la representación de bytes de la información cifrada  
        //    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
        //    // Crear un flujo de descifrado basado en el flujo de los datos  
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream, RijndaelAlg.CreateDecryptor(Key, IV), CryptoStreamMode.Read);
        //    // Obtener los datos descifrados obteniéndolos del flujo de descifrado  
        //    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //    // Cerrar los flujos utilizados  
        //    memoryStream.Close();
        //    cryptoStream.Close();
        //    // Retornar la representación de texto de los datos descifrados  
        //    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        //}
        //public static string EncriptarTexto(String textoAEncriptar)
        //{
        //    if (textoAEncriptar == null || textoAEncriptar.Equals("")) return "";
            
        //    // Crear una instancia del algoritmo de Rijndael  
        //    Rijndael RijndaelAlg = Rijndael.Create();
        //    RijndaelAlg.GenerateKey();
        //    RijndaelAlg.GenerateIV();

        //    byte[] Key = RijndaelAlg.Key;
        //    byte[] IV = RijndaelAlg.IV;

        //    // Establecer un flujo en memoria para el cifrado  
        //    MemoryStream memoryStream = new MemoryStream();
        //    // Crear un flujo de cifrado basado en el flujo de los datos  
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream,
        //                                                 RijndaelAlg.CreateEncryptor(Key, IV),
        //                                                 CryptoStreamMode.Write);
        //    // Obtener la representación en bytes de la información a cifrar  
        //    byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(textoAEncriptar);
        //    // Cifrar los datos enviándolos al flujo de cifrado  
        //    cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);
        //    cryptoStream.FlushFinalBlock();
        //    // Obtener los datos datos cifrados como un arreglo de bytes  
        //    byte[] cipherMessageBytes = memoryStream.ToArray();
        //    // Cerrar los flujos utilizados  
        //    memoryStream.Close();
        //    cryptoStream.Close();
        //    // Retornar la representación de texto de los datos cifrados  
        //    return Convert.ToBase64String(cipherMessageBytes);
        //}  


        public static string EncriptarTexto(string textoAEncriptar)
        {
            if (textoAEncriptar == null || textoAEncriptar.Equals("")) return "";
            return Encrypt<AesManaged>(textoAEncriptar, password);
        }
        private static string Encrypt<T>(string value, string password)
                where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Encoding.ASCII.GetBytes(value);

            byte[] encrypted;
            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes =
                    new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
            return Convert.ToBase64String(encrypted);
        }

        public static string DesencriptarTexto(string textoEncriptado)
        {
            if (textoEncriptado == null || textoEncriptado.Equals("")) return "";
            return Decrypt<AesManaged>(textoEncriptado, password);
        }
        private static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return String.Empty;
                }

                cipher.Clear();
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }


    }
}
