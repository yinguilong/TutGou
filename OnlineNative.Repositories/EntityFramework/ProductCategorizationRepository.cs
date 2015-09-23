using OnlineNative.Domain.Model;
using OnlineNative.Domain.Repositories;
using OnlineNative.Infrastructure;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  ProductCategorizationRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/22/2015 3:39:27 PM
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

    public class ProductCategorizationRepository : EntityFrameworkRepository<ProductCategorization>, IProductCategorizationRepository
    {
        public ProductCategorizationRepository(IRepositoryContext context)
            : base(context)
        {
        }

        public IEnumerable<NativeProduct> GetProductsForCategory(Category category)
        {
            var context = EfContext.DbContext;
            if (context == null)
                throw new InvalidOperationException("指定的仓储上下文（Repository Context）无效.");

            var query = from product in context.NativeProduct
                        from categorization in context.ProductCategorization
                        where product.Id == categorization.ProductId &&
                              categorization.CategoryId == category.Id
                        select product;

            return query.ToList();
        }

        public PagedResult<NativeProduct> GetProductsForCategoryWithPagination(Category category, int pageNumber, int pageSize)
        {
            var context = EfContext.DbContext;
            if (context == null)
                throw new InvalidOperationException("指定的仓储上下文（Repository Context）无效.");

            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;

            var query = from product in context.NativeProduct
                        from categorization in context.ProductCategorization
                        where product.Id == categorization.ProductId &&
                              categorization.CategoryId == category.Id
                        orderby product.Name ascending
                        select product;

            var pagedQuery = query.Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
            return pagedQuery == null ? null : new PagedResult<NativeProduct>(pagedQuery.Key.Total, (pagedQuery.Key.Total + pageSize - 1) / pageSize, pageSize, pageNumber, pagedQuery.Select(p => p).ToList());
        }
        public Category GetCategoryForProduct(NativeProduct product)
        {
            var context = EfContext.DbContext;
            if (context == null) throw new InvalidOperationException("指定的仓储上下文（Repository Context）无效。");

            var query = from category in context.Category
                        from categorization in context.ProductCategorization
                        where categorization.ProductId == product.Id &&
                              categorization.CategoryId == category.Id
                        select category;
            return query.FirstOrDefault();
        }
    }
}