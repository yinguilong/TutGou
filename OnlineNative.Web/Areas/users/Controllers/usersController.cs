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
            if (IsHaveAccount)
            {
                return RedirectToAction("UserLoginLoad");
            }
            else if (CurrentOperator != null)
            {
                return RedirectToAction("yonghuzhanghao");
            }
            else
            {
                return RedirectToAction("UserCreateLoad");
            }
        }
        #region 用户注册相关
        /// <summary>
        /// 用户注册加载页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserCreateLoad()
        {

            return View();
        }
        /// <summary>
        /// 用户注册逻辑
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult CreateUser(UserDto user)
        {
            if (user != null)
            {
                var list = new List<UserDto>();
                list.Add(user);
                _userServiceImp.CreateUsers(list);
                UserLogin(user);//注册完毕直接登录
            }
            //这里应该跳转到注册完毕的页面
            return RedirectToAction("UserHaveRegisted", new { LoginAccount = user.LoginAccount });
        }
        /// <summary>
        /// 验证用户名是否可用
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public string CheckUserName(string UserName)
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
        /// <summary>
        /// 验证账号是否可用
        /// </summary>
        /// <param name="LoginAccount"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 用户注册成功后中转页面
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult UserHaveRegisted(UserDto user)
        {
            var tUser = _userServiceImp.GetUserByLoginAccount(user.LoginAccount);
            ViewData["userName"] = tUser.UserName;
            return View();
        }
        #endregion
        #region 用户登录
        /// <summary>
        /// 用户登录逻辑
        /// </summary>
        /// <param name="user"></param>
        [NonAction]
        public void UserLogin(UserDto user)
        {
            var tUser = _userServiceImp.GetUserByLoginAccount(user.LoginAccount);
            if (tUser.Password.Equals(user.Password))//登录成功
            {
                if (tUser.IsDisabled.Value)//说明不可用
                {
                    //待定
                    return;
                }
                var currentUser = CustomUserSession.GetCurrentUserByTuser(tUser);//获取当前登录用户信息
                CustomUserSession.SaveSessionForLogin(currentUser);
            }
        }
        public ActionResult UserLoginLoad()
        {
            return View();
        }
        /// <summary>
        /// 用户登录action
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult UserLoginFromPage(UserDto user)
        {
            UserLogin(user);
            return Redirect("http://www.tutgou.com");
        }
        #endregion
    }
}
