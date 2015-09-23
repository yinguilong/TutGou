/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Repositories.Contracts
 *文件名：  IEntityFrameworkRepositoryContext
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 9:54:23 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 9:54:23 PM
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
using OnlineNative.Domain.Repositories;

namespace OnlineNative.Repositories.EntityFramework
{
    public interface IEntityFrameworkRepositoryContext : IRepositoryContext
    {
        #region Properties
        OnlineNativeDbContext DbContext { get; }
        #endregion
    }
}
