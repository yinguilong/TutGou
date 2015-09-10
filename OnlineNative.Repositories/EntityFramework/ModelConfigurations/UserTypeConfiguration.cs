using OnlineNative.Domain.Model;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Repositories.EntityFramework.ModelConfigurations
 *文件名：  UserTypeConfiguration
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/17/2015 2:49:19 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/17/2015 2:49:19 PM
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
    public class UserTypeConfiguration: EntityTypeConfiguration<User>
    {
        public UserTypeConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.UserName)
                .IsRequired()
                .HasMaxLength(20);
            Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(20);
            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(80);
            // 不加下面的配置，将会出现下面的错误，更多解决方案参考：http://www.tuicool.com/articles/M7RbAj
            // The conversion of a datetime2 data type to a datetime data type resulted in an out-of-range value.
            //Property(c => c.RegisteredDate)
            //    .HasColumnType("timestamp without time zone")
            //    .HasPrecision(0);

            ToTable("Users");
        }
    }
}
