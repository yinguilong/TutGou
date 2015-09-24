using OnlineNative.Model.DTOs;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.Contracts
 *文件名：  IOrderService
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/24/2015 9:27:15 AM
 *描述：订单服务
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Model.Contracts
{
    public interface IOrderService
    {

        // 获得指定用户的购物车中商品数量
        int GetShoppingCartItemCount(Guid userId);

        // 将指定的商品添加到指定客户的购物车
        void AddProductToCart(Guid customerId, Guid productId, int quantity);

        // 根据指定的客户获取客户的购物车信息
        ShoppingCartDto GetShoppingCart(Guid customerId);

        // 
        void UpdateShoppingCartItem(Guid shoppingCartItemId, int quantity);

        void DeleteShoppingCartItem(Guid shoppingCartItemId);

        OrderDto Checkout(Guid customerId);

        OrderDto GetOrder(Guid orderId);

        IList<OrderDto> GetOrdersForUser(Guid userId);

        IList<OrderDto> GetAllOrders();

        // 销售订单确认。
        void Confirm(Guid orderId);

        // 确认发货
        void Dispatch(Guid orderId);
    }
}