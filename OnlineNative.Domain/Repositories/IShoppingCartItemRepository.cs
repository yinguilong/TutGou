using OnlineNative.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Repositories
{
    public interface IShoppingCartItemRepository : IRepository<ShoppingCartItem>
    {
        ShoppingCartItem FindItem(ShoppingCart shoppingCart, NativeProduct product);
    }
}