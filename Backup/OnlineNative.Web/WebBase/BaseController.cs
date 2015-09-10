using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineNative.Model;

namespace OnlineNative.Web
{
    public class BaseController : Controller
    {
        public CurrentUser CurrentOperator
        {
            get
            {
                return CustomUserSession.Get();
            }
        }
        /// <summary>
        /// 弹框提示
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public ActionResult Alert(string content, string directUrl = "")
        {
            var contentResult = new ContentResult
            {
                Content = string.Format("<script>alert('{0}');window.history.back();</script>", content)
            };
            if (!string.IsNullOrEmpty(directUrl))
            {
                contentResult.Content = string.Format("<script>alert('{0}');window.location.href='{1}'</script>", content, directUrl);
            }
            return contentResult;
        }
    }
}