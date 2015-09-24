using OnlineNative.Infrastructure;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Repositories
 *文件名：  IRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 10:01:53 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 10:01:53 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        #region Methods
        void Add(TAggregateRoot aggregateRoot);

        // 根据聚合根的ID值，从仓储中读取聚合根
        TAggregateRoot GetByKey(Guid key);

        TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> spec);

        TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression);

        // 读取所有聚合根。
        IEnumerable<TAggregateRoot> GetAll();

        // 以指定的排序字段和排序方式，从仓储中读取所有聚合根。
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);

        //  根据指定的规约获取聚合根
        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification);

        // 根据指定的规约,以指定的排序字段和排序方式，从仓储中读取聚合根
        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);

        // 返回一个值，该值表示符合指定规约条件的聚合根是否存在。
        bool Exists(ISpecification<TAggregateRoot> specification);

        void Remove(TAggregateRoot aggregateRoot);

        void Update(TAggregateRoot aggregateRoot);

        #region 分页支持
     
        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize);

        PagedResult<TAggregateRoot> GetAll(
            ISpecification<TAggregateRoot> specification,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize);

        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize,
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        PagedResult<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize,
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        #endregion
        #endregion
        #region 饥饿加载方式

        TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        #endregion
    }
}
