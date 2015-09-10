using OnlineNative.Domain.Model;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Repositories.EntityFramework.ModelConfigurations
 *文件名：  OrderTypeConfiguration
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/17/2015 3:12:34 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/17/2015 3:12:34 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Repositories.EntityFramework.ModelConfigurations
{
    public class OrderTypeConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderTypeConfiguration()
        {
            HasKey<Guid>(s => s.Id);
            Property(s => s.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Ignore(p => p.Subtotal);
        }
    }
}
