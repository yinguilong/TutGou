using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Helpers;

namespace OnlineNative.Web.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        [Route("shouye")]
        public ActionResult Index()
        {
            return View("/Views/Home/Index_Fresh.cshtml");
        }
        [Route("zhongzhuan")]
        public ActionResult zhongzhuan(string note, string url)
        {
            ViewData["note"] = note;
            ViewData["url"] = url;
            return View("/Views/Home/zhongzhuan.cshtml");
        }
    }
}
