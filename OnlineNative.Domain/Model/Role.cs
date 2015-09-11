/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Domain.Model
 *文件名：  Role
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 10:57:50 AM
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
    public class Role : AggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

