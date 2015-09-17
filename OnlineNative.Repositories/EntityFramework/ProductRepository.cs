/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  ProductRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 4:31:25 PM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineNative.Domain.Model;
using OnlineNative.Domain.Repositories;
using OnlineNative.Domain;

namespace OnlineNative.Repositories.EntityFramework
{
    // 商品仓储的实现
    public class ProductRepository : EntityFrameworkRepository<NativeProduct>, IProductRepository
    {
        #region Ctor

        public ProductRepository(IRepositoryContext context)
            : base(context)
        {
        }
        #endregion

        // 获得最新方法
        public IEnumerable<NativeProduct> GetNewProducts(int count = 0)
        {
            var ctx = this.EfContext.DbContext as OnlineNativeDbContext;
            if (ctx == null)
                return null;
            var query = from p in ctx.NativeProduct
                        where p.IsNew == true
                        select p;
            if (count == 0)
                return query.ToList();
            else
                return query.Take(count).ToList();
        }
    }
}
