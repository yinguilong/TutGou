﻿/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Infrastructure.Utils
 *文件名：  CryptHelper
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/23/2015 10:01:14 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Infrastructure.Utils
{
    public class CryptHelper
    {
        private static readonly SymmetricAlgorithm MobjCryptoService;
        private static readonly string Key;
        static CryptHelper()
        {
            MobjCryptoService = new RijndaelManaged();
            Key = "tutgou_(%&hj7x89H$yuBI0456FtmaT5&Hufsdf*h%(HilJ$lhj!y6&(*jkP87jH7";
        }

        private static byte[] GetLegalKey()
        {
            string sTemp = Key;
            MobjCryptoService.GenerateKey();
            byte[] bytTemp = MobjCryptoService.Key;
            int keyLength = bytTemp.Length;
            if (sTemp.Length > keyLength)
                sTemp = sTemp.Substring(0, keyLength);
            else if (sTemp.Length < keyLength)
                sTemp = sTemp.PadRight(keyLength, ' ');
            return Encoding.ASCII.GetBytes(sTemp);
        }

        private static byte[] GetLegalIV()
        {
            string sTemp = "tutgou_E4ghj*Ghg7!rNIfb&fds3543fdsHdf#sfdsfds(u%g6HJ($jhWk7&!hg4ui%$hjk";
            MobjCryptoService.GenerateIV();
            byte[] bytTemp = MobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return Encoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        /// 加密 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encrypto(string source)
        {
            byte[] bytIn = Encoding.UTF8.GetBytes(source);
            MemoryStream ms = new MemoryStream();
            MobjCryptoService.Key = GetLegalKey();
            MobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = MobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }


        /// <summary>
        /// 解密 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decrypto(string source)
        {
            byte[] bytIn = Convert.FromBase64String(source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            MobjCryptoService.Key = GetLegalKey();
            MobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = MobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}