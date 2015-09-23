using AutoMapper;
using OnlineNative.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineNative.Web.WebBase
{
    public class PassWordResolver : ValueResolver<string, string>
    {
        protected override string ResolveCore(string source)
        {
            return CryptHelper.Encrypto(source);
        }
    }
}