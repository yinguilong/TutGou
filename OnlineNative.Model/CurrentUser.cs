/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Model
 *文件名：  CurrentUser
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/8/2015 10:15:06 AM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/8/2015 10:15:06 AM
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

namespace OnlineNative.Model
{
    [Serializable]
    public class CurrentUser
    {
        /// <summary>
        /// 用户级别
        /// </summary>
        public int SystemLevel { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string LoginAccount { get; set; }

    }
}
