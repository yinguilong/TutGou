using OnlineNative.Events;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Event
 *文件名：  IDomainEventHandler
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:48:10 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:48:10 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/

namespace OnlineNative.Domain.Event
{
    public interface IDomainEventHandler<in TDomainEvent> : IEventHandler<TDomainEvent>
        where TDomainEvent : class, IDomainEvent
    {

    }
}
