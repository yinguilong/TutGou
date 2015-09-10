/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Events.Base
 *文件名：  IEventAggregator
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 1:54:33 PM
 *描述：
 *事件聚合
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 1:54:33 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Events
{
    public interface IEventAggregator
    {
        void Register<TEvent>(IEventHandler<TEvent> domainEventHandler)
          where TEvent : class, IEvent;
        void Register<TEvent>(IEnumerable<IEventHandler<TEvent>> domainEventHandlers)
            where TEvent : class, IEvent;

        void Handle<TEvent>(TEvent domainEvent)
           where TEvent : class, IEvent;
        void Handle<TEvent>(TEvent domainEvent, Action<TEvent, bool, Exception> callback, TimeSpan? timeout = null)
            where TEvent : class, IEvent;
    }
}
