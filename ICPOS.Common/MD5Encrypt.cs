using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Common
{
    public class MD5Encrypt
    {

        ///   <summary>
        ///   给一个字符串进行MD5加密
        ///   </summary>
        ///   <param   name="strText">待加密字符串</param>
        ///   <returns>加密后的字符串</returns>
        public static string MD5(string strText)
        {
            strText = "!@#" + strText + "$%^";
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.UTF8Encoding.Default.GetBytes(strText));
            return System.Text.UTF8Encoding.Default.GetString(result);
        }
    }
}
