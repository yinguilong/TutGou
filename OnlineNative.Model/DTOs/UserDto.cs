/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Model.DTOs
 *文件名：  UserDto
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 10:25:57 AM
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
    public class UserDto
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsDisabled { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public DateTime? LastLogonDate { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto ContactAddress { get; set; }
        public AddressDto DeliveryAddress { get; set; }

        public RoleDto Role { get; set; }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}

