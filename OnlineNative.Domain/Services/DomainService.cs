﻿using OnlineNative.Domain.Model;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Domain.Services
 *文件名：  DomainService
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:44:19 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineNative.Model.Enum;
using OnlineNative.Domain.Repositories;
using System.Linq.Expressions;

namespace OnlineNative.Domain.Services
{
    // 领域服务类型
    // 牵涉到多个实体的操作可以把这些操作封装到领域服务里
    public class DomainService : IDomainService
    {
        #region Private Fields
        private readonly IRepositoryContext _repositoryContext;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductCategorizationRepository _productCategorizationRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IProductRepository _productRepository;
        #endregion

        #region Ctor

        public DomainService(IRepositoryContext repositoryContext,
            IOrderRepository orderRepository,
            IShoppingCartItemRepository shoppingCartItemRepository,
            ICategoryRepository categoryRepository,
            IProductCategorizationRepository productCategorizationRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository)
        {
            _repositoryContext = repositoryContext;
            _orderRepository = orderRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _productCategorizationRepository = productCategorizationRepository;
            _userRoleRepository = userRoleRepository;
            _productRepository = productRepository;
        }

        #endregion

        #region IDomainService
        /// <summary>
        /// 创建订单，涉及到的操作有2个：1. 把购物车中的项中购物车移除； 2.创建一个订单。
        /// 这两个操作必须同时完成或失败。
        /// </summary>
        /// <param name="user"></param>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        public Order CreateOrder(User user, ShoppingCart shoppingCart)
        {
            var order = new Order();
            var shoppingCartItems =
                _shoppingCartItemRepository.GetAll(
                    new ExpressionSpecification<ShoppingCartItem>(s => s.ShoopingCart.Id == shoppingCart.Id));
            if (shoppingCartItems == null || !shoppingCartItems.Any())
                throw new InvalidOperationException("购物篮中没有任何物品");

            order.OrderItems = new List<OrderItem>();
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderItem = shoppingCartItem.ConvertToOrderItem();
                orderItem.Order = order;
                order.OrderItems.Add(orderItem);
                _shoppingCartItemRepository.Remove(shoppingCartItem);
            }
            order.User = user;
            order.Status = DictOrderStatus.创建;//先创建订单，付款需要用到订单号
            _orderRepository.Add(order);
            _repositoryContext.Commit();
            return order;
        }
        /// <summary>
        /// 下单，没有付款
        /// </summary>
        /// <param name="user"></param>
        /// <param name="shoppingCartItems"></param>
        /// <returns></returns>
        public Order CreateOrderByItem(User user, List<ShoppingCartItem> shoppingCartItems)
        {
            var order = new Order();
            if (shoppingCartItems == null || !shoppingCartItems.Any())
            {
                throw new InvalidOperationException("购物篮中没有任何物品");
            }
            order.OrderItems = new List<OrderItem>();
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                if (shoppingCartItem != null && shoppingCartItem.Id != null)
                {
                    var orderItem = shoppingCartItem.CreateOrderItemByProductId();
                    orderItem.Order = order;
                    order.OrderItems.Add(orderItem);
                    var item = _shoppingCartItemRepository.GetByExpression(x => x.Id == shoppingCartItem.Id);
                    if (item != null)
                        _shoppingCartItemRepository.Remove(item);
                }
            }
            order.User = user;
            order.Status = DictOrderStatus.创建;//先创建订单，付款需要用到订单号
            _orderRepository.Add(order);
            _repositoryContext.Commit();
            return order;
            //var shoppingCartItems=shoppingCart.Id
        }
        /// <summary>
        /// 团购直接下单、待付款
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Order CreateOrderDirect(User user, NativeProduct product, int count)
        {
            var order = new Order();
            if (count == 0 || product == null)
            {
                throw new InvalidOperationException("没有任何商品购买");
            }
            order.OrderItems = new List<OrderItem>();
            var orderItem = new OrderItem();
            orderItem.Id = Guid.NewGuid();
            orderItem.Product = product;
            orderItem.Quantity = count;
            orderItem.Order = order;
            order.OrderItems.Add(orderItem);
            order.User = user;
            order.DeliveryAddress = user.DeliveryAddress;
            order.Status = DictOrderStatus.创建;//先创建订单，付款需要用到订单号
            _orderRepository.Add(order);
            _repositoryContext.Commit();
            return order;
        }
        // 将指定的商品归类到指定的商品分类中。
        public ProductCategorization Categorize(NativeProduct product, Category category)
        {
            if (product == null)
                throw new ArgumentNullException("product");
            if (category == null)
                throw new ArgumentNullException("category");

            var productCategorization =
                _productCategorizationRepository.GetBySpecification(
                    Specification<ProductCategorization>.Eval(c => c.ProductId == product.Id));
            if (productCategorization == null)
            {
                productCategorization = ProductCategorization.CreateCategorization(product, category);
                _productCategorizationRepository.Add(productCategorization);
            }
            else
            {
                productCategorization.CategoryId = category.Id;
                _productCategorizationRepository.Update(productCategorization);
            }

            _repositoryContext.Commit();
            return productCategorization;
        }

        // 将指定的商品从其所属的商品分类中移除
        public void Uncategorize(NativeProduct product, Category category = null)
        {
            Expression<Func<ProductCategorization, bool>> specExpress = null
                ;
            if (category == null)
                specExpress = p => p.ProductId == product.Id;
            else
                specExpress = p => p.ProductId == product.Id && p.CategoryId == category.Id;
            var productCategorization = _productCategorizationRepository.GetByExpression(specExpress);
            if (productCategorization == null) return;

            _productCategorizationRepository.Remove(productCategorization);
            _repositoryContext.Commit();
        }

        // 将指定的用户赋予特定的角色。
        public UserRole AssignRole(User user, Role role)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (role == null)
                throw new ArgumentNullException("role");
            var userRole = _userRoleRepository.GetBySpecification(Specification<UserRole>.Eval(ur => ur.UserId == user.Id));
            if (userRole == null)
            {
                userRole = UserRole.CreateUserRole(user, role);
                _userRoleRepository.Add(userRole);
            }
            else
            {
                userRole.RoleId = role.Id;
                _userRoleRepository.Update(userRole);
            }

            _repositoryContext.Commit();
            return userRole;
        }

        // 将指定的用户从角色中移除。
        public void UnassignRole(User user, Role role = null)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            Expression<Func<UserRole, bool>> specExpression = null;
            if (role == null)
                specExpression = ur => ur.UserId == user.Id;
            else
                specExpression = ur => ur.UserId == user.Id && ur.RoleId == role.Id;

            UserRole userRole = _userRoleRepository.GetBySpecification(Specification<UserRole>.Eval(specExpression));

            if (userRole == null) return;

            _userRoleRepository.Remove(userRole);
            _repositoryContext.Commit();
        }
        #endregion

    }
}