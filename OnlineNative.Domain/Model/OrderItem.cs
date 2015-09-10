/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Model
 *文件名：  OrderItem
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:59:21 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:59:21 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;

namespace OnlineNative.Domain.Model
{
    public class OrderItem : IEntity
    {
        #region IEnity Member
        public Guid Id { get; set; }
        #endregion

        public int Quantity { get; set; }
        public virtual NativeProduct Product { get; set; }

        // 包含当前订单项的订单对象
        public virtual Order Order { get; set; }

        public decimal ItemAmout
        {
            get
            {
                return this.Product.UnitPrice * this.Quantity;
            }
        }

        #region Object Member
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;
            OrderItem other = obj as OrderItem;
            if ((object)other == null)
                return false;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion

        #region Public Static Operator Overrides
        public static bool operator ==(OrderItem a, OrderItem b)
        {
            if ((object)a == null)
            {
                return (object)b == null;
            }
            return a.Equals(b);
        }

        public static bool operator !=(OrderItem a, OrderItem b)
        {
            return !(a == b);
        }
        #endregion
    }
}
