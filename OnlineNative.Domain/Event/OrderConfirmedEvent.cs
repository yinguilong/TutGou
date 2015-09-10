/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Event
 *文件名：  OrderConfirmedEvent
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:55:09 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:55:09 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;

namespace OnlineNative.Domain.Event
{
    public class OrderConfirmedEvent : DomainEvent
    {
        #region Ctor
        public OrderConfirmedEvent() { }
        public OrderConfirmedEvent(IEntity source) : base(source) { }
        #endregion

        #region Public Properties
        /// <summary>
        /// 获取或设置订单确认的日期。
        /// </summary>
        public DateTime ConfirmedDate { get; set; }
        public string UserEmailAddress { get; set; }
        public Guid OrderId { get; set; }
        #endregion 
    }
}
