using Microsoft.Practices.EnterpriseLibrary.Caching;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Infrastructure.Caching
 *文件名：  EntLibCacheProvider
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/18/2015 9:30:38 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Infrastructure.Caching
{
    public class EntLibCacheProvider : ICacheProvider
    {
        // 获得CacheManager实例，该实例的注册通过cachingConfiguration进行注册进去的，具体看配置文件
        private readonly ICacheManager _cacheManager = CacheFactory.GetCacheManager();

        #region ICahceProvider

        public void Add(string key, string valueKey, object value)
        {
            Dictionary<string, object> dict = null;
            if (_cacheManager.Contains(key))
            {
                dict = (Dictionary<string, object>)_cacheManager[key];
                dict[valueKey] = value;
            }
            else
            {
                dict = new Dictionary<string, object> { { valueKey, value } };
            }

            _cacheManager.Add(key, dict);
        }

        public void Update(string key, string valueKey, object value)
        {
            Add(key, valueKey, value);
        }

        public object Get(string key, string valueKey)
        {
            if (!_cacheManager.Contains(key)) return null;
            var dict = (Dictionary<string, object>)_cacheManager[key];
            if (dict != null && dict.ContainsKey(valueKey))
                return dict[valueKey];
            else
                return null;
        }

        // 从缓存中移除对象
        public void Remove(string key)
        {
            _cacheManager.Remove(key);
        }

        // 判断指定的键值的缓存是否存在
        public bool Exists(string key)
        {
            return _cacheManager.Contains(key);
        }

        // 判断指定的键值和缓存键值的缓存是否存在
        public bool Exists(string key, string valueKey)
        {
            return _cacheManager.Contains(key) &&
               ((Dictionary<string, object>)_cacheManager[key]).ContainsKey(valueKey);
        }
        #endregion
    }
}