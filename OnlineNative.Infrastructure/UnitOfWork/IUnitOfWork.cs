/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Infrastructure.UnitOfWork
 *文件名：  IUnitOfWork
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 9:43:06 PM
 *描述：
 *单元工作模式
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 9:43:06 PM
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

namespace OnlineNative.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
