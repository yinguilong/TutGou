using OnlineNative.Domain;
using OnlineNative.Domain.Model;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  ShoppingCartItemRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:37:55 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Repositories.EntityFramework
{
    public class ShoppingCartItemRepository : EntityFrameworkRepository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(IRepositoryContext context)
            : base(context)
        {
        }

        #region IShoppingCartItemRepository Members
        public ShoppingCartItem FindItem(ShoppingCart shoppingCart, NativeProduct product)
        {
            return GetBySpecification(Specification<ShoppingCartItem>.Eval
                (sci => sci.ShoopingCart.Id == shoppingCart.Id &&
                 sci.Product.Id == product.Id), elp => elp.Product);
        }

        #endregion
    }
}