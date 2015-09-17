/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Model
 *文件名：  User
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 3:02:50 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 3:02:50 PM
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

namespace OnlineNative.Domain.Model
{
    public class User : AggregateRoot
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginAccount { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDisabled { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime? LastLogonDate { get; set; }

        public string Contact { get; set; }
        //用户的联系地址
        public Address ContactAddress { get; set; }

        //用户的收货地址
        public IEnumerable<Address> ReciveAddress { get; set; }
        //用户的发货地址
        public Address DeliveryAddress { get; set; }

        public IEnumerable<Order> Orders
        {
            get
            {
                IEnumerable<Order> result = null;
                //DomainEvent.Handle<GetUserOrdersEvent>(new GetUserOrdersEvent(this),
                //    (e, ret, exc) =>
                //    {
                //        result = e.Orders;
                //    });
                return result;
            }
        }

        public override string ToString()
        {
            return this.UserName;
        }

        #region Public Methods

        public void Disable()
        {
            this.IsDisabled = true;
        }

        public void Enable()
        {
            this.IsDisabled = false;
        }

        // 为当前用户创建购物篮。
        public ShoppingCart CreateShoppingCart()
        {
            var shoppingCart = new ShoppingCart { User = this };
            return shoppingCart;
        }
        #endregion
    }
}
