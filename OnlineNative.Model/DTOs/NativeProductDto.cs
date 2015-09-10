/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  NativeProductDto
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/9/2015 9:29:59 AM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/9/2015 9:29:59 AM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/

namespace OnlineNative.Model.DTOs
{
    public class NativeProductDto
    {
        public string Id { get; set; }
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? UnitPrice { get; set; }

        public string ImageUrl { get; set; }

        public bool? IsNew { get; set; }

        public CategoryDto Category { get; set; }
    }
}
