/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Infrastructure.Caching
 *文件名：  CacheAttribute
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/18/2015 9:46:57 AM
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
     [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class CacheAttribute : Attribute
    {
        public CachingMethod Method { get; set; }

        public bool IsForce { get; set; }

        // 缓存相关的方法名称，该参数仅在Remove的方式用到
        public string[] CorrespondingMethodNames { get; set; }

        public CacheAttribute(CachingMethod method)
        {
            this.Method = method;
        }

        public CacheAttribute(CachingMethod method, params string[] correspondingMethodNames)
            : this(method)
        {
            this.CorrespondingMethodNames = correspondingMethodNames;
        }
    }
 }