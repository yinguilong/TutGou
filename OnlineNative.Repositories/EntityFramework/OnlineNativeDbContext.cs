/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  OnlineNativeDbContext
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 10:36:41 AM
 *描述：
 *数据库链接上下文
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 10:36:41 AM
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

using System.Data.Entity;
using OnlineNative.Domain.Model;
using OnlineNative.Repositories.EntityFramework.ModelConfigurations;

namespace OnlineNative.Repositories
{
    public class OnlineNativeDbContext : DbContext
    {
        public OnlineNativeDbContext()
            : base("OnlineNativeDbContext")
        {

        }
        public DbSet<NativeProduct> NativeProduct { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategorization> ProductCategorization { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }

        public DbSet<Role> Roles
        {
            get;
            set;
        }
        public DbSet<UserRole> UserRoles
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Configurations
                .Add(new UserTypeConfiguration())
                .Add(new NativeProductTypeConfiguration())
                .Add(new CategoryTypeConfiguration())
                .Add(new ProductCategorizationTypeConfiguration())
                .Add(new OrderItemTypeConfiguration())
                .Add(new OrderTypeConfiguration())
                .Add(new ShoppingCartItemTypeConfiguration())
                .Add(new ShoppingCartTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
