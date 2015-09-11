using OnlineNative.Domain.Model;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Domain.Repositories
 *文件名：  IOrderRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:51:46 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Repositories
{
    // 订单仓储接口
    public interface IOrderRepository : IRepository<Order>
    {
    }
}