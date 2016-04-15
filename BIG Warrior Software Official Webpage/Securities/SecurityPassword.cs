using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BIG_Warrior_Software_Official_Webpage.Securities
{
    public static class SecurityPassword
    {
        public static string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputbytes = Encoding.ASCII.GetBytes(input);
            byte[] hashbytes = md5.ComputeHash(inputbytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashbytes.Length; i++)
            {
                sb.Append(hashbytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
