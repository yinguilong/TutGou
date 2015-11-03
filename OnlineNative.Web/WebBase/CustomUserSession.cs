using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineNative.Model;
using OnlineNative.Infrastructure;
using OnlineNative.Infrastructure.Extensions;
using OnlineNative.Infrastructure.Utils;
using OnlineNative.Model.DTOs;

namespace OnlineNative.Web
{
    public class CustomUserSession
    {
        private static string CurrentHostHeader
        {
            get
            {
                var url = HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToLower();
                var host = url.Split('.');
                return host[0];
            }
        }

        public static string SessionId
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[ReadonlyCollection.CLIENTSESSIONNAME] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[ReadonlyCollection.CLIENTSESSIONNAME][ReadonlyCollection.CLIENTSESSIONNAMECOOKIEVALUE]) && Validate(HttpContext.Current.Request.Cookies[ReadonlyCollection.CLIENTSESSIONNAME][ReadonlyCollection.CLIENTSESSIONNAMECOOKIEVALUE]))
                {
                    return HttpContext.Current.Request.Cookies[ReadonlyCollection.CLIENTSESSIONNAME][ReadonlyCollection.CLIENTSESSIONNAMECOOKIEVALUE];
                }
                for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
                {
                    var matchCookie = HttpContext.Current.Request.Cookies[i];
                    if (matchCookie[ReadonlyCollection.CLIENTSESSIONNAMECOOKIEVALUE] != null && Validate(matchCookie[ReadonlyCollection.CLIENTSESSIONNAMECOOKIEVALUE]))
                    {
                        return matchCookie[ReadonlyCollection.CLIENTSESSIONNAMECOOKIEVALUE];
                    }

                }
                return "";
            }
        }

        public static CurrentUser Get()
        {
            string key = ReadonlyCollection.SERVERBEFOREKEY + SessionId;
            return CacheHelper.Get<CurrentUser>(key);
        }

        public static string SaveSessionForLogin(CurrentUser value)
        {

            if (value == null) return "";
            try
            {
                string sessionId = CreateSessionId();
                string key = ReadonlyCollection.SERVERBEFOREKEY + sessionId;
                var expiry = DateTime.Now.AddHours(6);
                CacheHelper.Set(key, value, expiry);
                var obj = CacheHelper.Get<CurrentUser>(key);
                CacheHelper.Set(value.UserID.ToString(), key);
                HttpContext.Current.Response.Cookies.Add(ReadonlyCollection.CLIENTSESSIONNAME, ReadonlyCollection.CLIENTSESSIONNAMECOOKIEVALUE, sessionId);
                return sessionId;
            }
            catch (Exception exp)
            {
                Common.Log(exp.ToString());
                return "";
            }
        }
        public static CurrentUser GetCurrentUserByTuser(UserDto user)
        {
            var currentUser = new CurrentUser();
            currentUser.SystemLevel = 1;
            currentUser.LoginAccount = user.LoginAccount;
            currentUser.UserID = new Guid(user.Id);
            currentUser.UserName = user.UserName;
            return currentUser;
        }
        public static void Clear()
        {
            var cookie = HttpContext.Current.Response.Cookies[ReadonlyCollection.CLIENTSESSIONNAME];
            if (cookie != null)
            {
                HttpContext.Current.Response.Cookies.Expired(ReadonlyCollection.CLIENTSESSIONNAME);
                HttpContext.Current.Session[ReadonlyCollection.CLIENTSESSIONNAME] = null;
                string key = ReadonlyCollection.SERVERBEFOREKEY + cookie.ToString();
                CacheHelper.DeleteCacheByKey(key);
            }
        }

        public static string CreateSessionId()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool Validate(string id)
        {
            try
            {
                Guid testGuid;
                if (!Guid.TryParse(id, out testGuid))
                    return false;

                if (id == testGuid.ToString())
                    return true;
            }
            catch (Exception ex)
            {
                Common.Log(ex);
            }
            return false;
        }
    }
}