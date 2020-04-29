using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    class dataProcessing
    {
        /// <summary>
        /// 订单生成
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderNo()
        {
            Random ran = new Random();
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), ran.Next(999));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="明文"></param>
        /// <param name="秘钥"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptStr, string key)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
