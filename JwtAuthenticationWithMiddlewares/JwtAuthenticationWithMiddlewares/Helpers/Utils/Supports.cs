﻿using System.Security.Cryptography;
using System.Text;

namespace JwtAuthenticationWithMiddlewares.Helpers.Utils
{
    public class Supports
    {
        public static string GenerateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
