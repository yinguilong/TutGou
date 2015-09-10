/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Specifications
 *文件名：  ExpressionSpecification
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 10:07:39 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 10:07:39 PM
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
    public class ExpressionSpecification<T> : Specification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;
        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<T, bool>> Expression
        {
            get { return _expression; }
        }
    }
}
