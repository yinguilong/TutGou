/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Domain.Repositories
 *文件名：  IProductRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 4:30:00 PM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineNative.Domain.Model;

namespace OnlineNative.Domain.Repositories
{
    public interface IProductRepository : IRepository<NativeProduct>
    {
        IEnumerable<NativeProduct> GetNewProducts(int count = 0);
    }
}

