/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Model
 *文件名：  ReadonlyCollection
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/8/2015 10:27:54 AM
 *描述：
 *常量字段
 *=====================================================================
 *修改标记
 *修改时间：7/8/2015 10:27:54 AM
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

namespace OnlineNative.Infrastructure
{
    public class ReadonlyCollection
    {
        public static readonly string CLIENTSESSIONNAME = "ClientSessionName_OnlineNative_User";
        public static readonly string CLIENTSESSIONNAMECOOKIEVALUE = "SessionName_OnlineNative_User";
        public static readonly string SERVERBEFOREKEY = "CustomUserSession_OnlineNative_";
        public static readonly string ROOTDOMAIN = ConfigurationManager.AppSettings["RootDomain"];
    }
}
