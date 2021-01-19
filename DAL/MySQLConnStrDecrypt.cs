using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DAL
{
    public class MySQLConnStrDecrypt
    {
        /// <summary>
        /// 读取txt文件
        /// </summary>
        /// <param name="path">配置文件路径</param>
        /// <returns></returns>
        private static string ReadTxt(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            return sr.ReadLine();
        }

        #region DES对称解密

        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// 
        /// DES解密字符串        
        /// 待解密的字符串
        /// 解密密钥,要求为8位,和加密密钥相同
        /// 解密成功返回解密后的字符串，失败返源串
        public static string DecryptDES(string decryptString, string decryptKey)
        {

            byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
            byte[] rgbIV = Keys;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());

        }

        #endregion

        /// <summary>
        /// 解密数据库连接字段
        /// </summary>
        /// <returns></returns>
        public static string EncryptMySQLConntStr()
        {
            string SettingPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Setting.txt";
            string objEncrypt_Old = ReadTxt(SettingPath);
            string objEncrypt_New = DecryptDES(objEncrypt_Old, "DES#Pola");
            return objEncrypt_New;
        }
    }
}
