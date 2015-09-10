using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Helpers;

namespace OnlineNative.Web.Areas.products.Controllers
{
    public class productController : Controller
    {
        //
        // GET: /products/product/

        [Route("tutechan-liebiao")]
        public ActionResult Index()
        {
            //应该去数据库查列表
            return View("~/Areas/products/Views/product/Index.cshtml");
        }

    }
}
