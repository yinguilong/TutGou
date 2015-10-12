using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Helpers;
using OnlineNative.Model.DTOs;
using OnlineNative.Model.Contracts;
using OnlineNative.Infrastructure;

namespace OnlineNative.Web.Areas.products.Controllers
{
    public class productController : BaseController
    {
        //
        // GET: /products/product/
        private readonly IProductService _productServiceImp = ServiceLocator.Instance.GetService<IProductService>();
        [Route("tutechan-liebiao")]
        public ActionResult Index()
        {
            //应该去数据库查列表
            return View("~/Areas/products/Views/product/Index.cshtml");
        }
        /// <summary>
        /// 添加商品加载页面
        /// </summary>
        /// <returns></returns>
        [Route("shangpintianjia")]
        public ActionResult productaddload()
        {
            return View("~/Areas/products/Views/product/productaddload.cshtml");
        }
        public ActionResult productadd(ProductDto product)
        {
            var list=new List<ProductDto>();
            list.Add(product);
            _productServiceImp.CreateProducts(list);
            return Alert("添加成功", "/shangpintianjia");
        }
    }
}
