/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Repositories
 *文件名：  IRepositoryContext
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 9:49:51 PM
 *描述：
 *仓储上下文接口
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 9:49:51 PM
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
using OnlineNative.Infrastructure;

namespace OnlineNative.Domain
{
    public interface IRepositoryContext : IUnitOfWork
    {
        // 用来标识仓储上下文
        Guid Id { get; }

        void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;

        void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;

        void RegisterDeleted<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;
    }
}
