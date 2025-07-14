using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repository.Helper
{
    public static class EncDecPassword
    {
        public const string SecretKey = "@123secretkeydontshare";

        public static string EncryptPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }
            else
            {
                password = password + SecretKey;
                var passwordInBytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(passwordInBytes);
            }
        }

        public static string DecryptPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }
            else
            {
                var encodedBytes = Convert.FromBase64String(password);
                var actualPassword = Encoding.UTF8.GetString(encodedBytes);
                actualPassword = actualPassword.Substring(0, actualPassword.Length - SecretKey.Length);
                return actualPassword;

            }
        }
    }
}
