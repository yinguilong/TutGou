/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Infrastructure
 *文件名：  DisposableObject
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:20:25 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:20:25 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;

namespace OnlineNative.Infrastructure
{
    public abstract class DisposableObject : IDisposable
    {
        ~DisposableObject()
        {
            this.Dispose(false);
        }

        protected abstract void Dispose(bool disposing);

        protected void ExplicitDispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.ExplicitDispose();
        }
        #endregion
    }
}
