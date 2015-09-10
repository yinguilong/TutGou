/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Model.Enum
 *文件名：  DictOrderStatus
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 3:09:43 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 3:09:43 PM
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

namespace OnlineNative.Model.Enum
{
    public enum DictOrderStatus
    {
        取消 = -1,
        创建 = 0, // 订单已被创建待付款
        已付款 = 1, // 订单已付款
        订单已仓库拣货 = 2, // 订单已仓库拣货
        已发货 = 3, // 已发货
        已派送 = 4 // 已派送
    }
}
