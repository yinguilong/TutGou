using AutoMapper;
using OnlineNative.Domain;
using OnlineNative.Domain.Model;
using OnlineNative.Model.DTOs;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Service
 *文件名：  ApplicationService
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 10:48:04 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Service
{
    public class ApplicationService
    {
        private readonly IRepositoryContext _repositoryContext;

        protected ApplicationService(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        protected IRepositoryContext RepositorytContext
        {
            get { return this._repositoryContext; }
        }

        #region Protected Methods

        // 判断给定字符串是否是Guid.Empty
        protected bool IsEmptyGuidString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;
            var guid = new Guid(s);
            return guid == Guid.Empty;
        }


        // 处理简单的聚合创建逻辑。
        protected TDtoList PerformCreateObjects<TDtoList, TDto, TAggregateRoot>(TDtoList dataTransferObjects,
            IRepository<TAggregateRoot> repository,
            Action<TDto> processDto = null,
            Action<TAggregateRoot> processAggregateRoot = null)
            where TDtoList : List<TDto>, new()
            where TAggregateRoot : class, IAggregateRoot
        {
            if (dataTransferObjects == null)
                throw new ArgumentNullException("dataTransferObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");
            TDtoList result = new TDtoList();
            if (dataTransferObjects.Count <= 0) return result;
            var ars = new List<TAggregateRoot>();

            foreach (var dto in dataTransferObjects)
            {
                if (processDto != null)
                    processDto(dto);
                var ar = Mapper.Map<TDto, TAggregateRoot>(dto);
                if (processAggregateRoot != null)
                    processAggregateRoot(ar);
                ars.Add(ar);
                repository.Add(ar);
            }

            RepositorytContext.Commit();
            ars.ForEach(ar => result.Add(Mapper.Map<TAggregateRoot, TDto>(ar)));
            return result;
        }

        // 处理简单的聚合更新操作。
        protected TDtoList PerformUpdateObjects<TDtoList, TDataObject, TAggregateRoot>(TDtoList dataTransferObjects,
            IRepository<TAggregateRoot> repository,
            Func<TDataObject, string> idFunc,
            Action<TAggregateRoot, TDataObject> updateAction)
            where TDtoList : List<TDataObject>, new()
            where TAggregateRoot : class, IAggregateRoot
        {
            if (dataTransferObjects == null)
                throw new ArgumentNullException("dataTransferObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");
            if (idFunc == null)
                throw new ArgumentNullException("idFunc");
            if (updateAction == null)
                throw new ArgumentNullException("updateAction");
            TDtoList result = null;
            if (dataTransferObjects.Count > 0)
            {
                result = new TDtoList();
                foreach (var dto in dataTransferObjects)
                {
                    if (IsEmptyGuidString(idFunc(dto)))
                        throw new ArgumentNullException("Id");
                    var id = new Guid(idFunc(dto));
                    var ar = repository.GetByKey(id);
                    updateAction(ar, dto);
                    repository.Update(ar);
                    result.Add(Mapper.Map<TAggregateRoot, TDataObject>(ar));
                }

                RepositorytContext.Commit();
            }
            return result;
        }

        // 处理简单的删除聚合根的操作。
        protected void PerformDeleteObjects<TAggregateRoot>(IList<string> ids, IRepository<TAggregateRoot> repository, Action<Guid> preDelete = null, Action<Guid> postDelete = null)
            where TAggregateRoot : class, IAggregateRoot
        {
            if (ids == null)
                throw new ArgumentNullException("ids");
            if (repository == null)
                throw new ArgumentNullException("repository");
            foreach (var id in ids)
            {
                var guid = new Guid(id);
                if (preDelete != null)
                    preDelete(guid);
                var ar = repository.GetByKey(guid);
                repository.Remove(ar);
                if (postDelete != null)
                    postDelete(guid);
            }

            RepositorytContext.Commit();
        }

        #endregion
    }
}