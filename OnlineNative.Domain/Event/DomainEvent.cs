using OnlineNative.Events;
using OnlineNative.Infrastructure;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Event
 *文件名：  DomainEvent
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:50:48 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:50:48 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Event
{
    public class DomainEvent : IDomainEvent
    {
        #region Private Fields
        private readonly IEntity _source;
        #endregion

        #region Ctor

        public DomainEvent()
        {
        }

        public DomainEvent(IEntity source)
        {
            _source = source;
        }

        #endregion

        #region IDomainEvent Members
        public IEntity Source
        {
            get { return _source; }
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
            set { Id = value; }
        }

        public DateTime TimeStamp
        {
            get { return DateTime.UtcNow; }
            set { TimeStamp = value; }
        }
        #endregion

        #region Public Static Methods

        public static void Publish<TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : class, IDomainEvent
        {
            // 找到对应的事件处理器来对事件进行处理
            var handlers = ServiceLocator.Instance.ResolveAll<IDomainEventHandler<TDomainEvent>>();
            foreach (var handler in handlers)
            {
                if (handler.GetType().IsDefined(typeof(HandlesAsynchronouslyAttribute), false))
                    Task.Factory.StartNew(() => handler.Handle(domainEvent));
                else
                    handler.Handle(domainEvent);
            }
        }

        public static void Publish<TDomainEvent>(TDomainEvent domainEvent, Action<TDomainEvent, bool, Exception> callback, TimeSpan? timeout = null)
            where TDomainEvent : class, IDomainEvent
        {
            var handlers = ServiceLocator.Instance.ResolveAll<IDomainEventHandler<TDomainEvent>>();
            if (handlers != null && handlers.Any())
            {
                var tasks = new List<Task>();
                try
                {
                    foreach (var handler in handlers)
                    {
                        if (handler.GetType().IsDefined(typeof(HandlesAsynchronouslyAttribute), false))
                        {
                            tasks.Add(Task.Factory.StartNew(() => handler.Handle(domainEvent)));
                        }
                        else
                            handler.Handle(domainEvent);
                    }
                    if (tasks.Count > 0)
                    {
                        if (timeout == null)
                            Task.WaitAll(tasks.ToArray());
                        else
                            Task.WaitAll(tasks.ToArray(), timeout.Value);
                    }
                    callback(domainEvent, true, null);
                }
                catch (Exception ex)
                {
                    callback(domainEvent, false, ex);
                }
            }
            else
                callback(domainEvent, false, null);
        }
        #endregion
    }
}
