/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  ProductCategorizationDto
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 10:58:45 AM
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
    public class ProductCategorizationDto
    {
        public string Id { get; set; }

        public Guid CategoryId { get; set; }

        public Guid ProductId { get; set; } 
    }
}

