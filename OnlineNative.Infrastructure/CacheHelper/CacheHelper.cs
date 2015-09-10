using Memcached.Client;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Infrastructure.CacheHelper
 *文件名：  CacheHelper
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/8/2015 2:44:12 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/8/2015 2:44:12 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineNative.Infrastructure.Utils;

namespace OnlineNative.Infrastructure
{
    public class CacheHelper
    {
        private static readonly string CacheServer = ConfigurationManager.AppSettings["CacheServer"];
        private static readonly MemcachedClient Mc;
        static CacheHelper()
        {
            Mc = new MemcachedClient();
        }

        public static void Set<T>(string key, T obj) where T : class
        {

            try
            {
                Mc.EnableCompression = false;
                if (obj != null)
                {
                    Mc.Set(key, obj);
                    //Mc.Set(key, DataJsonParse.JsonSerializer<T>(obj));
                    //Mc.Set(key, Newtonsoft.Json.JavaScriptConvert.SerializeObject(obj));
                }
            }
            catch (Exception ex)
            {
               Common.Log(ex);
            }
        }

        public static void Set<T>(string key, T obj, DateTime expiry) where T : class
        {
            if (obj == null) return;
            try
            {
                Mc.EnableCompression = false;
                Mc.Set(key, obj, expiry);
            }
            catch (Exception ex)
            {
                Common.Log(ex);
            }
        }

        /// <summary>
        /// 更新一个对象的内容及过期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        public static void UpdateObj<T>(string key, T obj, DateTime expiry) where T : class
        {
            if (obj == null)
                return;
            try
            {
                Mc.EnableCompression = false;
                Mc.Replace(key, obj, expiry);
            }
            catch (Exception ex)
            {
                Common.Log(ex);
            }
        }

        public static T Get<T>(string key)
        {
            try
            {
                if (Mc.KeyExists(key))
                {
                    return (T)Mc.Get(key);
                    //return   Newtonsoft.Json.JavaScriptConvert.DeserializeObject<T>(Mc.Get(key).ToString());
                    //return DataJsonParse.ParseFromJson<T>(Mc.Get(key).ToString());
                }
            }
            catch (Exception ex)
            {
                Common.Log(ex);
            }
            return default(T);
        }

        public static bool FlushAll()
        {
            try
            {
                return Mc.FlushAll();
            }
            catch (Exception ex)
            {
                Common.Log(ex);
                return false;
            }
        }

        public static bool DeleteCacheByKey(string key)
        {
            try
            {
                return Mc.Delete(key);
            }
            catch (Exception ex)
            {
                Common.Log(ex);
                return false;
            }
        }

        public static void MemcachedPoolinitialize()
        {
            char[] separator = { ',' };
            string[] serverlist = CacheServer.Split(separator);

            // initialize the pool for memcache servers  
            try
            {
                SockIOPool pool = SockIOPool.GetInstance();
                if (pool != null)
                {
                    pool.SetServers(serverlist);

                    pool.InitConnections = 3;
                    pool.MinConnections = 3;
                    pool.MaxConnections = 50;

                    pool.SocketConnectTimeout = 1000;
                    pool.SocketTimeout = 3000;

                    pool.MaintenanceSleep = 30;
                    pool.Failover = true;

                    pool.Nagle = false;
                    pool.Initialize();
                }
            }
            catch (Exception ex)
            {
                Common.Log(ex);
            }
        }

        public static void MemcachedPoolDestory()
        {
            if (SockIOPool.GetInstance() != null)
                SockIOPool.GetInstance().Shutdown();
        }
    }
}
