/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  ProductDto
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 10:31:11 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Model.DTOs
{
    public class ProductDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? UnitPrice { get; set; }

        public string ImageUrl { get; set; }

        public bool? IsNew { get; set; }

        public CategoryDto Category { get; set; }
    }
}

