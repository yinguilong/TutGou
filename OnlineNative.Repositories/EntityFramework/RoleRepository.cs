using OnlineNative.Domain;
using OnlineNative.Domain.Model;
using OnlineNative.Domain.Repositories;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  RoleRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:35:55 AM
 *描述：
 *
/************************************************************************************/

namespace OnlineNative.Repositories.EntityFramework
{
    public class RoleRepository : EntityFrameworkRepository<Role>, IRoleRepository
    {
        public RoleRepository(IRepositoryContext context)
            : base(context)
        { }

    }
}