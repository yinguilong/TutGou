/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  ProductDtoWithPagination
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/24/2015 10:10:43 AM
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
    public class ProductDtoWithPagination
    {
        public Pagination Pagination { get; set; }
        public List<ProductDto> ProductDtos { get; set; }
    }
}

