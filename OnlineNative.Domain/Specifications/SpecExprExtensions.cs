/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Specifications
 *文件名：  SpecExprExtensions
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 10:18:24 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 10:18:24 PM
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
    public static class SpecExprExtensions
    {
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> one)
        {
            var candidateExpr = one.Parameters[0];
            var body = Expression.Not(one.Body);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> one,
            Expression<Func<T, bool>> another)
        {
            // 首先定义好一个ParameterExpression
            var candidateExpr = Expression.Parameter(typeof(T), "candidate");
            var parameterReplacer = new ParameterReplacer(candidateExpr);

            // 将表达式树的参数统一替换成我们定义好的candidateExpr
            var left = parameterReplacer.Replace(one.Body);
            var right = parameterReplacer.Replace(another.Body);

            var body = Expression.And(left, right);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> one, Expression<Func<T, bool>> another)
        {
            var candidateExpr = Expression.Parameter(typeof(T), "candidate");
            var parameterReplacer = new ParameterReplacer(candidateExpr);

            var left = parameterReplacer.Replace(one.Body);
            var right = parameterReplacer.Replace(another.Body);
            var body = Expression.Or(left, right);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        } 
    }
}
