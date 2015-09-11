using OnlineNative.Domain;
using OnlineNative.Domain.Model;
using OnlineNative.Domain.Repositories;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  UserRoleRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:30:19 AM
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
    public class UserRoleRepository : EntityFrameworkRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IRepositoryContext context)
            : base(context) { }

        public Role GetRoleForUser(User user)
        {
            var context = EfContext.DbContext as OnlineNativeDbContext;
            if (context != null)
            {
                var query = from role in context.Roles
                            from userRole in context.UserRoles
                            from usr in context.Users
                            where role.Id == userRole.RoleId &&
                                usr.Id == userRole.UserId &&
                                usr.Id == user.Id
                            select role;
                return query.FirstOrDefault();
            }
            throw new InvalidOperationException("The provided repository context is invalid.");
        }
    }
}

