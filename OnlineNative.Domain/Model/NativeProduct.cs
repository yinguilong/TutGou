/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Model
 *文件名：  NativeProduct
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 4:24:07 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 4:24:07 PM
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineNative.Domain.Model
{
    public class NativeProduct : AggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public string InitialAddress { get; set; }
        public bool IsNew { get; set; }
        public int ShopId { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
