using Microsoft.Practices.Unity.InterceptionExtension;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Infrastructure.InterceptionBehaviors
 *文件名：  ExceptionLoggingBehavior
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/18/2015 11:03:14 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Infrastructure.InterceptionBehaviors
{
    public class ExceptionLoggingBehavior : IInterceptionBehavior
    {
        /// <summary>
        /// 需要拦截的对象类型的接口
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        /// <summary>
        /// 通过该方法来拦截调用并执行所需要的拦截行为
        /// </summary>
        /// <param name="input">调用拦截目标时的输入信息</param>
        /// <param name="getNext">通过行为链来获取下一个拦截行为的委托</param>
        /// <returns>从拦截目标获得的返回信息</returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // 执行目标方法
            var methodReturn = getNext().Invoke(input, getNext);
            // 方法执行后的处理
            if (methodReturn.Exception != null)
            {
                Utils.Common.Log(methodReturn.Exception);
            }

            return methodReturn;
        }

        // 表示当拦截行为被调用时，是否需要执行某些操作
        public bool WillExecute
        {
            get { return true; }
        }
    }
}