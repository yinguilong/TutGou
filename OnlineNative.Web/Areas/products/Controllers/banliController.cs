using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Helpers;
namespace OnlineNative.Web.Areas.products.Controllers
{
    public class banliController : BaseController
    {
        //
        // GET: /products/banli/
        [Route("tutechan-zhuanmai-qianxi-banli")]
        public ActionResult Index()
        {
            //这是为了测试git的修改
            return View("~/Areas/products/Views/banli/Index.cshtml");
        }

    }
}
