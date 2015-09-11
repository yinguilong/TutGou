using OnlineNative.Domain;
using OnlineNative.Domain.Model;
using OnlineNative.Domain.Repositories;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Repositories.EntityFramework
 *文件名：  CategoryRepository
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/11/2015 11:56:33 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Repositories.EntityFramework
{
    // 类别仓储的实现
    public class CategoryRepository : EntityFrameworkRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(IRepositoryContext context)
            : base(context)
        {
        }


    }
}