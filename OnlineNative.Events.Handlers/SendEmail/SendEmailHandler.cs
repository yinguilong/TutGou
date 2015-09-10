/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Events.Handlers.SendEmail
 *文件名：  SendEmailHandler
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:43:23 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:43:23 PM
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
using OnlineNative.Events;
using OnlineNative.Domain.Event;
using OnlineNative.Infrastructure.Utils;

namespace OnlineNative.Events.Handlers
{
    [HandlesAsynchronously]
    public class SendEmailHandler : IEventHandler<OrderDispatchedEvent>, IEventHandler<OrderConfirmedEvent>
    {
        // 处理确认收货事件
        public void Handle(OrderConfirmedEvent @event)
        {
            try
            {
                Common.SendEmail(@event.UserEmailAddress,
                    "您的订单已经确认收货",
                    string.Format("您的订单 {0} 已于 {1} 确认收货。有关订单的更多信息，请与系统管理员联系。",
                    @event.OrderId.ToString().ToUpper(), @event.ConfirmedDate));
            }
            catch (Exception ex)
            {
                // 如遇异常，直接记Log
                Common.Log(ex);
            }
        }

        // 处理发货事件
        public void Handle(OrderDispatchedEvent @event)
        {
            try
            {
                Common.SendEmail(@event.UserEmailAddress,
                    "您的订单已经发货",
                    string.Format("您的订单 {0} 已于 {1} 发货。有关订单的更多信息，请与系统管理员联系。",
                    @event.OrderId.ToString().ToUpper(), @event.DispatchedDate));
            }
            catch (Exception ex)
            {
                // 如遇异常，直接记Log
                Common.Log(ex);
            }
        }
    }
}
