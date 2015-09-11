using OnlineNative.Domain.Model;
using OnlineNative.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Repositories
{
    public interface IProductCategorizationRepository : IRepository<ProductCategorization>
    {
        // 获取指定分类下的所有商品信息
        IEnumerable<NativeProduct> GetProductsForCategory(Category category);

        /// <summary>
        /// 以分页的方式，获取指定分类下的所有商品信息
        /// </summary>
        /// <param name="category">指定的商品分类</param>
        /// <param name="pageNumber">所请求的分页页码</param>
        /// <param name="pageSize">所请求的页大小</param>
        /// <returns>指定分类下的某页的商品信息</returns>
        PagedResult<NativeProduct> GetProductsForCategoryWithPagination(Category category, int pageNumber, int pageSize);

        /// <summary>
        /// 获取商品所属的商品分类。
        /// </summary>
        /// <param name="product">商品信息。</param>
        /// <returns>商品分类。</returns>
        Category GetCategoryForProduct(NativeProduct product);
    }
}