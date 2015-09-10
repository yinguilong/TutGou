using OnlineNative.Domain.Event;
using OnlineNative.Model.Enum;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Model
 *文件名：  Order
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:58:18 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:58:18 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineNative.Domain.Model
{
    public class Order : AggregateRoot
    {
        private List<OrderItem> _orderItems = new List<OrderItem>();

        #region Public Properties
        // 获取或设置订单的状态
        public DictOrderStatus Status { get; set; }

        /// <summary>
        /// 获取或设置订单的创建日期
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 获取或设置订单的发货日期
        /// </summary>
        public DateTime? DispatchedDate { get; set; }

        /// <summary>
        /// 获取或设置订单的派送日期
        /// </summary>
        public DateTime? DeliveredDate { get; set; }
        public virtual List<OrderItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
            set
            {
                _orderItems = value;
            }
        }
        //[NotMapped]
        public virtual User User { get; set; }

        public Address DeliveryAddress
        {
            get;
            set;
        }
        // 在严格的业务系统中，金额往往以Money模式实现。有关Money模式，请参见：http://martinfowler.com/eaaCatalog/money.html
        public decimal Subtotal
        {
            get
            {
                return this.OrderItems.Sum(p => p.ItemAmout);
            }
        }

        #endregion

        #region Ctor
        public Order()
        {
            CreatedDate = DateTime.Now;
            Status = DictOrderStatus.创建;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// 当客户完成收货后，对销售订单进行确认。
        /// </summary>
        public void Confirm()
        {
            DomainEvent.Publish<OrderConfirmedEvent>(new OrderConfirmedEvent(this) { ConfirmedDate = DateTime.Now, OrderId = this.Id, UserEmailAddress = this.User.Email });
        }

        /// <summary>
        /// 处理发货。
        /// </summary>
        public void Dispatch()
        {
            DomainEvent.Publish<OrderDispatchedEvent>(new OrderDispatchedEvent(this) { DispatchedDate = DateTime.Now, OrderId = this.Id, UserEmailAddress = this.User.Email });
        }
        #endregion
    }
}
