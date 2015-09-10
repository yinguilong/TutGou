/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.AggregateRoot
 *文件名：  AggregateRoot
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 4:14:28 PM
 *描述：
 *聚合跟基类
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 4:14:28 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public Guid Id
        {
            get;
            set;
        }

        #region Object Member

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            IAggregateRoot ar = obj as IAggregateRoot;
            if (ar == null)
                return false;
            return this.Id == ar.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
