/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Events.Bus
 *文件名：  IBus
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:13:28 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:13:28 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;

using OnlineNative.Infrastructure;
namespace OnlineNative.Events.Bus
{
    public interface IBus : IDisposable, IUnitOfWork
    {
        Guid Id { get; }

        void Publish<TMessage>(TMessage message)
            where TMessage : class, IEvent;

        void Publish<TMessage>(IEnumerable<TMessage> messages)
           where TMessage : class, IEvent;

        void Clear();
    }
}
