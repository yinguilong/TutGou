using System.Web.Mvc;

namespace OnlineNative.Web.Areas.products
{
    public class productsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "products";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "products_default",
                "products/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
