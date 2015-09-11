/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Domain.Model
 *文件名：  UserRole
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:15:22 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Model
{
    public class UserRole : AggregateRoot
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public static UserRole CreateUserRole(User user, Role role)
        {
            return new UserRole() { UserId = user.Id, RoleId = role.Id };
        }
    }
}

