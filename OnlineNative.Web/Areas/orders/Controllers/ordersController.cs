using OnlineNative.Infrastructure;
using OnlineNative.Model.Contracts;
using OnlineNative.Model.DTOs;
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
        private readonly IProductService _productServiceImp = ServiceLocator.Instance.GetService<IProductService>();
        private readonly IOrderService _orderServiceImp = ServiceLocator.Instance.GetService<IOrderService>();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 团购直接下单，待付款
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult CreateOrders(ProductDto porduct, int? count)
        {
            var currentUser = CurrentOperator;
            var userDto = new UserDto()
            {
                Id = CurrentOperator.UserID.ToString()
            };
            _orderServiceImp.CreateOrderDirect(userDto, porduct, count ?? 0);
            return Alert("下单成功","/zhongzhuan?note=下单成功！立即支付？&url=/lijizhifu");//需要跳转到待付款界面吧？
        }

    }
}
