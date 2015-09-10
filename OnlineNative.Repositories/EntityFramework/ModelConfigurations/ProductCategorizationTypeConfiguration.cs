/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework.ModelConfigurations
 *文件名：  ProductCategorizationTypeConfiguration
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/23/2015 4:47:50 PM
 *描述：
 *
/************************************************************************************/
using OnlineNative.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineNative.Repositories.EntityFramework.ModelConfigurations
{
    public class ProductCategorizationTypeConfiguration : EntityTypeConfiguration<ProductCategorization>
    {
        public ProductCategorizationTypeConfiguration()
        {
            HasKey<Guid>(c => c.Id);
            Property(c => c.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.ProductId)
                .IsRequired();
            Property(c => c.CategoryId)
                .IsRequired();
        }
    }
}
