using System;
using System.Security.Cryptography;
using System.Text;

namespace PowerUtils.Security
{
    public static class HashExtensions
    {
        /// <summary>
        /// Convert a text to hash MD5
        /// </summary>
        /// <param name="text">Text input</param>
        /// <returns>MD5</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="text">text</paramref> parameter is null.</exception>
        public static string ToMD5(this string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            using(var hash = MD5.Create())
            {
                return hash._hashingText(text);
            }
        }

        /// <summary>
        /// Convert a text to hash SHA1
        /// </summary>
        /// <param name="text">Text input</param>
        /// <returns>SHA1</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="text">text</paramref> parameter is null.</exception>
        public static string ToSHA1(this string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            using(var hash = SHA1.Create())
            {
                return hash._hashingText(text);
            }
        }

        /// <summary>
        /// Convert a text to hash SHA256
        /// </summary>
        /// <param name="text">Text input</param>
        /// <returns>SHA256</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="text">text</paramref> parameter is null.</exception>
        public static string ToSHA256(this string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var result = new StringBuilder();

            using(var hash = SHA256.Create())
            {
                var encoding = Encoding.UTF8;
                var crypto = hash.ComputeHash(encoding.GetBytes(text));

                foreach(var @byte in crypto)
                {
                    result.Append(@byte.ToString("x2"));
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Convert a text to hash SHA384
        /// </summary>
        /// <param name="text">Text input</param>
        /// <returns>SHA384</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="text">text</paramref> parameter is null.</exception>
        public static string ToSHA384(this string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            using(var hash = SHA384.Create())
            {
                return hash._hashingText(text);
            }
        }

        /// <summary>
        /// Convert a text to hash SHA512
        /// </summary>
        /// <param name="text">Text input</param>
        /// <returns>SHA512</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="text">text</paramref> parameter is null.</exception>
        public static string ToSHA512(this string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            using(var hash = SHA512.Create())
            {
                return hash._hashingText(text);
            }
        }

        private static string _hashingText(this HashAlgorithm hash, string text)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            var hashBytes = hash.ComputeHash(textBytes);

            // Convert the byte array to hexadecimal string
            var sb = new StringBuilder();
            for(var count = 0; count < hashBytes.Length; count++)
            {
                sb.Append(hashBytes[count].ToString("x2")); // "x" to return the hash in lower case and "X" to return hash in upper case
            }

            return sb.ToString();
        }
    }
}
