using OnlineNative.Domain.Model;
using OnlineNative.Events.Bus;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Event.EventHandlers
 *文件名：  OrderConfirmedEventHandler
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:56:26 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:56:26 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using OnlineNative.Model.Enum;
namespace OnlineNative.Domain.Event.EventHandlers
{
    public class OrderConfirmedEventHandler : IDomainEventHandler<OrderConfirmedEvent>
    {
        private readonly IEventBus _bus;

        public OrderConfirmedEventHandler(IEventBus bus)
        {
            _bus = bus;
        }

        #region IDomainEventHandler Member
        // 事件处理器只对事件源的状态进行更新，事件状态的持久化而是在EventBus中进行处理的。
        public void Handle(OrderConfirmedEvent @event)
        {
            // 获得事件源对象
            var order = @event.Source as Order;
            // 更新事件源对象的属性
            if (order == null) return;

            order.DeliveredDate = @event.ConfirmedDate;
            order.Status = DictOrderStatus.已派送;

            // 把事件推送到EventBus中进行进一步处理
            _bus.Publish<OrderConfirmedEvent>(@event);
        }
        #endregion 
    }
}
