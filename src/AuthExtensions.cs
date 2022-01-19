using System;
using System.Text;

namespace PowerUtils.Security
{
    public static class UtilsAuth
    {
        /// <summary>
        /// Encode username and password to basic authentication (btoa) [Beautiful to Awful]
        /// </summary>
        /// <param name="username">Username of the authentication</param>
        /// <param name="password">Password of the authentication</param>
        /// <returns>Basic authentication without prefix 'basic'</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="username">username</paramref> parameter is null.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="password">password</paramref> parameter is null.</exception>
        public static string ToBasicAuth(string username, string password)
        {
            if(username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            if(password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
        }

        /// <summary>
        /// Decode from basic authentication (atob) [Awful to Beautiful]
        /// </summary>
        /// <param name="auth">Basic authentication</param>
        /// <returns>Username and password</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="auth">auth</paramref> parameter is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="auth">auth</paramref> parameter is not a basic authentication.</exception>
#if NET462
        public static Tuple<string, string> FromBasicAuth(this string auth)
#else
        public static (string Username, string Password) FromBasicAuth(this string auth)
#endif
        {
            if(auth == null)
            {
                throw new ArgumentNullException(nameof(auth));
            }


            string credentials;
            try
            {
                credentials = Encoding.UTF8.GetString(Convert.FromBase64String(auth));
            }
            catch
            {
                throw new ArgumentException("Invalid authentication.", nameof(auth));
            }


            var credentialsArray = credentials.Split(':');
            if(credentialsArray.Length != 2)
            {
                throw new ArgumentException("Invalid authentication.", nameof(auth));
            }

#if NET462
            return new Tuple<string, string>(credentialsArray[0], credentialsArray[1]);
#else
            return (credentialsArray[0], credentialsArray[1]);
#endif

        }
    }
}
