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
        public ActionResult CreateOrders()
        {
            return View();
        }

    }
}
