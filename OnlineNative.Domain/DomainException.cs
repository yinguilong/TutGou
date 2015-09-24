/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Domain
 *文件名：  DomainException
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/24/2015 9:39:24 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain
{
    public class DomainException : Exception
    {
        #region Ctor
        public DomainException()
            : base()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }
        public DomainException(string message, Exception innerException) : base(message, innerException) { }

        public DomainException(string format, params object[] args) : base(string.Format(format, args)) { }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        #endregion
    }
}