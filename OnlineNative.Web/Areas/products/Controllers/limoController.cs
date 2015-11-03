using StackExchange.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineNative.Web.Areas.products.Controllers
{
    public class limoController : BaseController
    {
        //
        // GET: /products/limo/
        [Route("tutechan-zhuanmai-qianxi-limo")]
        public ActionResult Index()
        {
            return View("~/Areas/products/Views/limo/Index.cshtml");
        }

    }
}
