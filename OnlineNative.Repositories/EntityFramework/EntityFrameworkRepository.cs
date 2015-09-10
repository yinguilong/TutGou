/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  EntityFrameworkRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/1/2015 10:00:18 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/1/2015 10:00:18 PM
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

using OnlineNative.Domain;
using System.Linq.Expressions;
using System.Data.SqlClient;
namespace OnlineNative.Repositories
{
    public class EntityFrameworkRepository<TAggregateRoot>:IRepository<TAggregateRoot> 
        where TAggregateRoot: class, IAggregateRoot
    {
        private readonly IEntityFrameworkRepositoryContext _efContext;

        protected EntityFrameworkRepository(IRepositoryContext context)
        {
            var efContext = context as IEntityFrameworkRepositoryContext;
            if (efContext != null)
                this._efContext = efContext;
        }

        private MemberExpression GetMemberInfo(LambdaExpression lambda)
        {
            if (lambda == null)
                throw new ArgumentNullException("lambda");

            MemberExpression memberExpr = null;

            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpr =
                        ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    memberExpr = lambda.Body as MemberExpression;
                    break;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        private string GetEagerLoadingPath(Expression<Func<TAggregateRoot, dynamic>> eagerLoadingProperty)
        {
            var memberExpression = this.GetMemberInfo(eagerLoadingProperty);
            var parameterName = eagerLoadingProperty.Parameters.First().Name;
            var memberExpressionStr = memberExpression.ToString();
            var path = memberExpressionStr.Replace(parameterName + ".", "");
            return path;
        }

        protected IEntityFrameworkRepositoryContext EfContext
        {
            get { return this._efContext; }
        }

        public void Add(TAggregateRoot aggregateRoot)
        {
            // 调用IEntityFrameworkRepositoryContext的RegisterNew方法将实体添加进DbContext.DbSet对象中
            _efContext.RegisterNew(aggregateRoot);
        }

        public TAggregateRoot GetByKey(Guid key)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().First(a => a.Id == key);
        }

        public TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> spec)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().FirstOrDefault(spec.Expression);
        }

        public TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().FirstOrDefault(expression);
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification)
        {
            return GetAll(specification, null, SortOrder.Unspecified);
        }


        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = _efContext.DbContext.Set<TAggregateRoot>().Where(specification.Expression);
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.SortBy(sortPredicate).ToList();
                        break;
                    case SortOrder.Descending:
                        return query.SortByDescending(sortPredicate).ToList();
                        break;
                    default:
                        break;
                }
            }

            return query.ToList();
        }

        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            var count = _efContext.DbContext.Set<TAggregateRoot>().Count(specification.IsSatisfiedBy);
            return count != 0;
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterDeleted(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterModified(aggregateRoot);
        }

        #region 饥饿加载方式实现
        public TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = _efContext.DbContext.Set<TAggregateRoot>();
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                return dbquery.Where(specification.Expression).FirstOrDefault();
            }
            else
                return dbset.Where(specification.Expression).FirstOrDefault();
        }

        public IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, eagerLoadingProperties);
        }

        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, eagerLoadingProperties);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return GetAll(specification, null, SortOrder.Unspecified, eagerLoadingProperties);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = _efContext.DbContext.Set<TAggregateRoot>();
            IQueryable<TAggregateRoot> queryable = null;
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(specification.Expression);
            }
            else
                queryable = dbset.Where(specification.Expression);

            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return queryable.SortBy(sortPredicate).ToList();
                    case SortOrder.Descending:
                        return queryable.SortByDescending(sortPredicate).ToList();
                    default:
                        break;
                }
            }
            return queryable.ToList();
        }
        #endregion 
    }
}
