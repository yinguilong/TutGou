using OnlineNative.Domain.Repositories;
using OnlineNative.Infrastructure;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Model
 *文件名：  ShoppingCartItem
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 3:06:17 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 3:06:17 PM
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
    public class ShoppingCartItem : AggregateRoot
    {
        public int Quantity { get; set; }

        public virtual NativeProduct Product { get; set; }

        public virtual ShoppingCart ShoopingCart { get; set; }

        public decimal ItemAmount
        {
            get
            {
                return this.Product.UnitPrice * this.Quantity;
            }
        }

        #region  Public Methods

        // 将当前的购物车中的项目转换为订单项
        public OrderItem ConvertToOrderItem()
        {
            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                Product = this.Product,
                Quantity = this.Quantity
            };
            return orderItem;
        }
        /// <summary>
        /// 根据商品ID和商品数量创建订单项
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderItem CreateOrderItemByProductId()
        {
            var productRepository = ServiceLocator.Instance.GetService<IProductRepository>();
            var product = productRepository.GetByKey(this.Product.Id);
            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                Product = product,
                Quantity = this.Quantity
            };
            return orderItem;
        }
        public void UpdateQuantity(int quantity)
        {
            this.Quantity = quantity;
        }
        #endregion
    }
}
