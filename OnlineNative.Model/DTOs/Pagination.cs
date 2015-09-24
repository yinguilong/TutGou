/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  Pagination
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/24/2015 10:31:35 AM
 *描述：
 *
/************************************************************************************/

namespace OnlineNative.Model.DTOs
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? TotalPages { get; set; }

        public override string ToString()
        {
            return string.Format("PageSize={0} PageNumber={1} TotalPages={2}",
                this.PageSize,
                this.PageNumber,
                this.TotalPages ?? 0);
        }
    }
}

