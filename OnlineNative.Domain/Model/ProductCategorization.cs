/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Domain.Model
 *文件名：  ProductCategorization
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/23/2015 11:22:47 AM
 *描述：
 *
/************************************************************************************/
using System;

namespace OnlineNative.Domain.Model
{
    public class ProductCategorization : AggregateRoot
    {

        public ProductCategorization()
        { }

        public ProductCategorization(Guid productId, Guid categoryId)
        {
            this.CategoryId = categoryId;
            this.ProductId = productId;
        }

        public Guid CategoryId { get; set; }

        public Guid ProductId { get; set; }

        public override string ToString()
        {
            return string.Format("CategoryID: {0}, ProductID: {1}", this.CategoryId, this.ProductId);
        }

        // 通过商品对象和分类对象来创建商品分类对象
        public static ProductCategorization CreateCategorization(NativeProduct product, Category category)
        {
            return new ProductCategorization(product.Id, category.Id);
        }
    }
}

