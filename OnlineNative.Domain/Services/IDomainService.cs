﻿using OnlineNative.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Services
{
    // 领域服务接口
    public interface IDomainService
    {
        /// <summary>
        /// 直接下单待付款
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Order CreateOrderDirect(User user, NativeProduct product, int count);
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="user"></param>
        /// <param name="shoppingCartItems"></param>
        /// <returns></returns>
        Order CreateOrderByItem(User user, List<ShoppingCartItem> shoppingCartItems);
        Order CreateOrder(User user, ShoppingCart shoppingCart);

        /// <summary>
        /// 将指定的商品归类到指定的商品分类中。
        /// </summary>
        /// <param name="product">需要归类的商品。</param>
        /// <param name="category">商品分类。</param>
        /// <returns>用以表述商品及其分类之间关系的实体。</returns>
        ProductCategorization Categorize(NativeProduct product, Category category);

        /// <summary>
        /// 将指定的商品从其所属的商品分类中移除。
        /// </summary>
        /// <param name="product">商品。</param>
        /// <param name="category">分类，若为NULL，则表示从所有分类中移除。</param>
        void Uncategorize(NativeProduct product, Category category = null);

        /// <summary>
        /// 将指定的用户赋予特定的角色。
        /// </summary>
        /// <param name="user">用户实体。</param>
        /// <param name="role">角色实体。</param>
        /// <returns>用以表述用户及其角色之间关系的实体。</returns>
        UserRole AssignRole(User user, Role role);

        /// <summary>
        /// 将指定的用户从角色中移除。
        /// </summary>
        /// <param name="user">用户实体。</param>
        /// <param name="role">角色实体，若为NULL，则表示从所有角色中移除。</param>
        void UnassignRole(User user, Role role = null);
    }
}