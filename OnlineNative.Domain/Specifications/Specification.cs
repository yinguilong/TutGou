/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Specifications
 *文件名：  Specification
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 10:06:07 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 10:06:07 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public static Specification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new ExpressionSpecification<T>(expression);
        }

        #region ISpecification<T> Members
        public bool IsSatisfiedBy(T candidate)
        {
            return this.Expression.Compile()(candidate);
        }

        public abstract Expression<Func<T, bool>> Expression { get; }
        #endregion
    }
}
