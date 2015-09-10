using OnlineNative.Domain;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Repositories.EntityFramework.ModelConfigurations
 *文件名：  NativeProductTypeConfiguration
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/17/2015 2:56:40 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/17/2015 2:56:40 PM
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
using OnlineNative.Domain.Model;

namespace OnlineNative.Repositories.EntityFramework.ModelConfigurations
{
    public class NativeProductTypeConfiguration : EntityTypeConfiguration<NativeProduct>
    {
        #region Ctor

        public NativeProductTypeConfiguration()
        {
            HasKey<Guid>(l => l.Id);
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Description)
                .IsRequired();
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);
            Property(p => p.ImageUrl)
                .HasMaxLength(255);
            Property(p => p.UnitPrice)
                .IsRequired()
                .HasColumnType("numeric");
        }
        #endregion
    }
}
