/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  OrderDto
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 10:30:11 AM
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
    public class OrderDto
    {
        public string Id { get; set; }

        public OrderStatusDto? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserContact { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }

        public string UserAddressCountry { get; set; }
        public string UserAddressState { get; set; }
        public string UserAddressCity { get; set; }
        public string UserAddressStreet { get; set; }
        public string UserAddressZip { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
        public decimal? Subtotal { get; set; }
    }
}

