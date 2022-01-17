using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PowerUtils.Security
{
    public static class EncryptExtensions
    {
        #region CONSTANTS
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8). Default keysize is 256, so the IV must be
        // 32 bytes long. Using a 16 character string here gives us 32 bytes when converted to a byte array.
#pragma warning disable IDE1006 // Naming Styles
        private static readonly byte[] INIT_VECTOR_BYTES = Encoding.ASCII.GetBytes("AjdoI9N9JEoTnjTj");
#pragma warning restore IDE1006 // Naming Styles

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int KEY_SIZE = 256;
        #endregion


        /// <summary>
        /// Encrypt text based in passPhrase
        /// </summary>
        /// <param name="text">Text to encrypt</param>
        /// <param name="passPhrase">Pass phrase</param>
        /// <returns>Cipher text</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="text">text</paramref> parameter is null.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="passPhrase">passPhrase</paramref> parameter is null.</exception>
        public static string Encrypt(this string text, string passPhrase)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if(passPhrase == null)
            {
                throw new ArgumentNullException(nameof(passPhrase));
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            using(var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(KEY_SIZE / 8);
                using(var aes = Aes.Create())
                {
                    aes.Mode = CipherMode.CBC;
                    using(var encryptor = aes.CreateEncryptor(keyBytes, INIT_VECTOR_BYTES))
                    {
                        using(var memoryStream = new MemoryStream())
                        {
                            using(var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Decrypt cipher text
        /// </summary>
        /// <param name="cipherText">Cipher text to decrypt</param>
        /// <param name="passPhrase">Pass phrase</param>
        /// <returns>Original text</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="cipherText">cipherText</paramref> parameter is null.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="passPhrase">passPhrase</paramref> parameter is null.</exception>
        public static string Decrypt(this string cipherText, string passPhrase)
        {
            if(cipherText == null)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if(passPhrase == null)
            {
                throw new ArgumentNullException(nameof(passPhrase));
            }

            var cipherTextBytes = Convert.FromBase64String(cipherText);
            using(var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(KEY_SIZE / 8);
                using(var aes = Aes.Create())
                {
                    aes.Mode = CipherMode.CBC;
                    using(var decryptor = aes.CreateDecryptor(keyBytes, INIT_VECTOR_BYTES))
                    {
                        using(var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using(var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
    }
}
