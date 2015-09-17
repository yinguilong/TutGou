using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineNative.Model.DTOs;
namespace OnlineNative.Web.Areas.users.Controllers
{
    public class usersController : BaseController
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
        public ActionResult CreateUser(UserDto user)
        {

            return View();
        }
        public string CheckUserNickName(string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return "用户名不能为空";
            }

            var tuserLogin = new UserDto(); //userBll.GetUserByNickName(nickName.Replace(" ", ""), CurrentOperator.DealerId);
            if (tuserLogin == null)
            {
                return "true";
            }
            //else if (userId.HasValue && userId.Value > 0 && tuserLogin.UserId == userId.Value)
            //{
            //    return "true";
            //}
            return "该昵称不可用，请更换";
        }
        public string CheckUserAccount(string LoginAccount)
        {
            if (string.IsNullOrEmpty(LoginAccount))
            {
                return "账号不能为空";
            }

            var tuserLogin = new UserDto(); //userBll.GetUserByNickName(nickName.Replace(" ", ""), CurrentOperator.DealerId);
            if (tuserLogin == null)
            {
                return "true";
            }
            //else if (userId.HasValue && userId.Value > 0 && tuserLogin.UserId == userId.Value)
            //{
            //    return "true";
            //}
            return "该账号不可用，请更换";
        }
    }
}
