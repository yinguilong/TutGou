/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Model
 *文件名：  Category
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/14/2015 11:58:02 AM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/14/2015 11:58:02 AM
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

namespace OnlineNative.Domain.Model
{
    public class Category : AggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
