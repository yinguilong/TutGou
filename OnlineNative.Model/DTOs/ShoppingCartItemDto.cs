﻿/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  ShoppingCartItemDto
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 10:53:43 AM
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
    public class ShoppingCartItemDto
    {
        public string Id { get; set; }

        public int? Quantity { get; set; }

        public ProductDto Product { get; set; }

        public decimal? ItemAmount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}

