using System;
using System.Text;

namespace PowerUtils.Security
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class EncodeExtensions
    {
        /// <summary>
        /// Encode text to base64
        /// </summary>
        /// <param name="text">Text to encode</param>
        /// <returns>Base64</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="text">text</paramref> parameter is null.</exception>
        [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
        public static string ToBase64(this string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Decode base64 to original text
        /// </summary>
        /// <param name="base64">Base64</param>
        /// <returns>Original text</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="base64">base64</paramref> parameter is null.</exception>
        [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
        public static string FromBase64(this string base64)
        {
            if(base64 == null)
            {
                throw new ArgumentNullException(nameof(base64));
            }

            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
