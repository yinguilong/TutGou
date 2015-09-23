using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineNative.Model.DTOs;
using OnlineNative.Model.Contracts;
using OnlineNative.Infrastructure;
using OnlineNative.Infrastructure.Utils;
namespace OnlineNative.Web.Areas.users.Controllers
{
    public class usersController : BaseController
    {
        //
        // GET: /users/users/
        private readonly IUserService _userServiceImp = ServiceLocator.Instance.GetService<IUserService>();
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
            if (user != null)
            {
                var list = new List<UserDto>();
                list.Add(user);
                _userServiceImp.CreateUsers(list);
            }
            //这里应该跳转到注册完毕的页面
            return Alert("注册成功");
        }
        public string CheckUserNickName(string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return "用户名不能为空";
            }
            var tuserLogin = _userServiceImp.GetUserByName(UserName); //userBll.GetUserByNickName(nickName.Replace(" ", ""), CurrentOperator.DealerId);
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
            //IUserService _userServiceImp = ServiceLocator.Instance.GetService<IUserService>();
            var tuserLogin = _userServiceImp.GetUserByLoginAccount(LoginAccount); //userBll.GetUserByNickName(nickName.Replace(" ", ""), CurrentOperator.DealerId);
            if (tuserLogin == null)
            {
                return "true";
            }
            return "该账号不可用，请更换";
        }
    }
}
