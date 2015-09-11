using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineNative.Web.Areas.users.Controllers
{
    public class usersController : Controller
    {
        //
        // GET: /users/users/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserCreateLoad()
        {
            return View();
        }
    }
}
