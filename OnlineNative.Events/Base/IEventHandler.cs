/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Events.Base
 *文件名：  IEventHandler
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 1:56:09 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 1:56:09 PM
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

namespace OnlineNative.Events
{
    public interface IEventHandler<in TEvent>
        where TEvent:IEvent
    {
        // 处理给定的事件
        void Handle(TEvent @event);
    }
}
