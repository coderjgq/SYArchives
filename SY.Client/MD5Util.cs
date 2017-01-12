using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
namespace SY.Client
{
    class MD5Util
    {
        public static string GeneratePassword(string password)
        {
            byte[] result = Encoding.Default.GetBytes(password);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本
        }
    }
}
