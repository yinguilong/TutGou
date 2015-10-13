using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineNative.Web.Areas.orders.Controllers
{
    public class ordersController : BaseController
    {
        //
        // GET: /orders/orders/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 团购直接下单，待付款
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateOrders()
        {
            return View();
        }

    }
}
