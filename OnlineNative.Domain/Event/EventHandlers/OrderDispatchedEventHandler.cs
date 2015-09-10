using OnlineNative.Domain.Model;
using OnlineNative.Events.Bus;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Event.EventHandlers
 *文件名：  OrderDispatchedEventHandler
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 3:15:06 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 3:15:06 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using OnlineNative.Model.Enum;

namespace OnlineNative.Domain.Event.EventHandlers
{
    public class OrderDispatchedEventHandler : IDomainEventHandler<OrderDispatchedEvent>
    {
        private readonly IEventBus _bus;


        public OrderDispatchedEventHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public void Handle(OrderDispatchedEvent @event)
        {
            // 获得事件源对象
            var order = @event.Source as Order;
            // 更新事件源对象的属性
            if (order == null) return;

            order.DeliveredDate = @event.DispatchedDate;
            order.Status =DictOrderStatus.已发货;

            // 这里把领域事件认为是一种消息，推送到EventBus中进行进一步处理。
            _bus.Publish<OrderDispatchedEvent>(@event);
        }
    }
}
