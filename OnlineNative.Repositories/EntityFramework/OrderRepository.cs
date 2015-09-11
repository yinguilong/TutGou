using OnlineNative.Domain;
using OnlineNative.Domain.Model;
using OnlineNative.Domain.Repositories;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  OrderRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:53:01 AM
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
    // 订单仓储的实现类
    public class OrderRepository : EntityFrameworkRepository<Order>, IOrderRepository
    {
        public OrderRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}