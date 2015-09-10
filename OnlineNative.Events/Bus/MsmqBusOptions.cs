/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Events.Bus
 *文件名：  MsmqBusOptions
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 2:24:00 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 2:24:00 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System.Messaging;

namespace OnlineNative.Events.Bus
{
    public class MsmqBusOptions
    {
        public bool SharedModeDenyReceive { get; set; }
        public bool EnableCache { get; set; }
        public QueueAccessMode QueueAccessMode { get; set; }
        public string Path { get; set; }
        public bool UseInternalTransaction { get; set; }
        public IMessageFormatter MessageFormatter { get; set; }

        public MsmqBusOptions(string path, bool sharedModeDenyReceive, bool enableCache, QueueAccessMode queueAccessMode, bool useInternalTransaction, IMessageFormatter messageFormatter)
        {
            this.SharedModeDenyReceive = sharedModeDenyReceive;
            this.EnableCache = enableCache;
            this.QueueAccessMode = queueAccessMode;
            this.Path = path;
            this.UseInternalTransaction = useInternalTransaction;
            this.MessageFormatter = messageFormatter;
        }

        public MsmqBusOptions(string path)
            : this(path, false, false, QueueAccessMode.SendAndReceive, false, new XmlMessageFormatter())
        { }

        public MsmqBusOptions(string path, bool useInternalTransaction)
            : this(path, false, false, QueueAccessMode.SendAndReceive, useInternalTransaction, new XmlMessageFormatter())
        { }
    }
}
